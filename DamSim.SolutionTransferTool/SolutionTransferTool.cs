using DamSim.SolutionTransferTool.AppCode;
using DamSim.SolutionTransferTool.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.WebServiceClient;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace DamSim.SolutionTransferTool
{
    public partial class SolutionTransferTool : MultipleConnectionsPluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        #region Variables

        private readonly MainForm mForm;
        private readonly ProgressForm pForm;
        private OrganizationRequest currentRequest;
        private string lastConnectionName;
        private Guid lastImportId;
        private IOrganizationService lastTargetService;
        private Dictionary<OrganizationRequest, ProgressItem> progressItems;
        private ConnectionDetail sourceDetail;
        private IOrganizationService sourceService;

        #endregion Variables

        #region Constructor

        public SolutionTransferTool()
        {
            InitializeComponent();

            dpMain.Theme = new VS2015LightTheme();

            mForm = new MainForm();
            mForm.TargetOrganizationRemoved += MForm_TargetOrganizationRemoved;
            mForm.TargetOrganizationRequested += MForm_TargetOrganizationRequested;
            mForm.Show(dpMain, DockState.Document);

            pForm = new ProgressForm();
            pForm.Show(dpMain, DockState.DockRight);

            var sForm = new SettingsForm();
            sForm.Show(dpMain, DockState.DockRight);
        }

        #endregion Constructor

        #region Forms events callback

        private void MForm_TargetOrganizationRemoved(object sender, TargetOrganizationsEventArgs e)
        {
            var toRemove = AdditionalConnectionDetails.FirstOrDefault(c => !e.TargetOrganizations.Contains(c));
            RemoveAdditionalOrganization(toRemove);
        }

        private void MForm_TargetOrganizationRequested(object sender, EventArgs e)
        {
            AddAdditionalOrganization();
        }

        #endregion Forms events callback

        #region XrmToolbox

        public string HelpUrl => "https://github.com/MscrmTools/DamSim.SolutionTransferTool/wiki";
        public string RepositoryName => "DamSim.SolutionTransferTool";

        public string UserName => "MscrmTools";

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            Settings.Instance.Save();

            base.ClosingPlugin(info);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            ConnectionDetail = detail;
            if (actionName == "AdditionalOrganization")
            {
                AdditionalConnectionDetails.Add(detail);

                if (newService is OrganizationServiceProxy proxy)
                {
                    proxy.Timeout = detail.Timeout;
                }
                else if (newService is OrganizationWebProxyClient client)
                {
                    client.InnerChannel.OperationTimeout = detail.Timeout;
                }

                mForm.DisplayTargetOrganizations(AdditionalConnectionDetails.ToList());
            }
            else
            {
                sourceDetail = detail;
                sourceService = newService;
                RetrieveSolutions();

                mForm.SetSourceOrganization(detail);
            }
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            mForm.DisplayTargetOrganizations(AdditionalConnectionDetails.ToList());
        }

        #endregion XrmToolbox

        #region UI Events

        private void Pi_LogFileRequested(object sender, DownloadLogEventArgs e)
        {
            DownloadLogFile(e.ImportJobId);
        }

        private void tsbFindMissingDependencies_Click(object sender, EventArgs e)
        {
            var child = new MissingComponentsForm();
            child.ShowMissingComponents(ParentForm, lastTargetService, lastConnectionName, sourceService, lastImportId);
        }

        private void TsbLoadSolutionsClick(object sender, EventArgs e)
        {
            ExecuteMethod(RetrieveSolutions);
        }

        private void tsbSwitchOrgs_Click(object sender, EventArgs e)
        {
            if (AdditionalConnectionDetails.Count > 1)
            {
                MessageBox.Show(this,
                    @"Switch can only be performed when no more than one target organization is defined",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var tempDetail = sourceDetail;
            sourceDetail = AdditionalConnectionDetails.FirstOrDefault();
            ConnectionDetail = AdditionalConnectionDetails.FirstOrDefault();
            AdditionalConnectionDetails.Clear();

            if (tempDetail != null)
            {
                AdditionalConnectionDetails.Add(tempDetail);
            }

            mForm.SwitchSourceAndTarget(tempDetail, sourceDetail);

            if (sourceDetail != null)
            {
                sourceService = sourceDetail.GetCrmServiceClient();
                base.UpdateConnection(sourceService, sourceDetail, "", null);
                RetrieveSolutions();
            }
        }

        private void TsbTransfertSolutionClick(object sender, EventArgs e)
        {
            if (mForm.SelectedSolutions.Count == 0 || !AdditionalConnectionDetails.Any())
            {
                MessageBox.Show(@"You have to select a source solution and a target organization to continue.", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var solutionsToTransfer = PreparareSolutionsToTransfer();
            if (solutionsToTransfer.Count == 0)
            {
                return;
            }

            var requests = new List<OrganizationRequest>();
            progressItems = new Dictionary<OrganizationRequest, ProgressItem>();

            foreach (var solution in solutionsToTransfer)
            {
                PrepareExportRequest(solution, requests);

                foreach (var detail in AdditionalConnectionDetails)
                {
                    PrepareImportRequest(detail, solution, requests);
                }
            }

            if (!Settings.Instance.Managed && Settings.Instance.Publish)
            {
                foreach (var detail in AdditionalConnectionDetails)
                {
                    PreparePublishRequest(detail, requests);
                }
            }

            // Add items to progress form
            pForm.Items = progressItems.Values.ToList();
            pForm.Start();

            pForm.Show(dpMain, DockState.DockRight);

            ToggleWaitMode(true);

            WorkAsync(new WorkAsyncInfo
            {
                AsyncArgument = requests,
                Work = (bw, evt) =>
                {
                    var requestsList = (List<OrganizationRequest>)evt.Argument;
                    var solutionName = string.Empty;
                    byte[] solutionFileContent = null;

                    if (sourceService is OrganizationServiceProxy proxy)
                    {
                        proxy.Timeout = Settings.Instance.Timeout;
                    }
                    else if (sourceService is OrganizationWebProxyClient client)
                    {
                        client.InnerChannel.OperationTimeout = Settings.Instance.Timeout;
                    }

                    foreach (var request in requestsList)
                    {
                        currentRequest = request;
                        if (request is ExportSolutionRequest exportRequest)
                        {
                            solutionName = exportRequest.SolutionName;

                            progressItems[currentRequest].Solution = solutionName;
                            progressItems[currentRequest].Start();

                            var exportResponse = (ExportSolutionResponse)sourceService.Execute(exportRequest);
                            solutionFileContent = exportResponse.ExportSolutionFile;

                            progressItems[currentRequest].Success();
                        }
                        else if (request is ImportSolutionRequest isr)
                        {
                            var progressItem = progressItems[request];
                            progressItem.Solution = solutionName;
                            progressItem.Start();

                            lastConnectionName = progressItem.Detail.ConnectionName;
                            lastTargetService = progressItem.Detail.GetCrmServiceClient();

                            if (((CrmServiceClient)lastTargetService).OrganizationServiceProxy != null)
                            {
                                ((CrmServiceClient)lastTargetService).OrganizationServiceProxy.Timeout = Settings.Instance.Timeout;
                            }
                            else if (((CrmServiceClient)lastTargetService).OrganizationWebProxyClient != null)
                            {
                                ((CrmServiceClient)lastTargetService).OrganizationWebProxyClient.InnerChannel.OperationTimeout = Settings.Instance.Timeout;
                            }

                            lastImportId = isr.ImportJobId;

                            isr.CustomizationFile = solutionFileContent;
                            lastTargetService.Execute(isr);

                            progressItem.Success();
                        }
                        else if (request is PublishAllXmlRequest publishRequest)
                        {
                            var progressItem = progressItems[request];
                            progressItem.Start();

                            lastTargetService = progressItem.Detail.GetCrmServiceClient();
                            lastTargetService.Execute(publishRequest);

                            progressItem.Success();
                        }
                    }
                },
                PostWorkCallBack = evt =>
                {
                    ToggleWaitMode(false);
                    string message;

                    if (evt.Error != null)
                    {
                        progressItems[currentRequest].Error();

                        message = $"An error occured: {evt.Error.Message}";
                        MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tsbFindMissingDependencies.Enabled = true;
                    }
                    else
                    {
                        message = "Import finished successfully!";
                        MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            });
        }

        #endregion UI Events

        #region Methods

        private void DownloadLogFile(Guid importJobId)
        {
            var dialog = new FolderBrowserDialog();

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastFolderUsed))
                dialog.SelectedPath = Properties.Settings.Default.LastFolderUsed;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LastFolderUsed = dialog.SelectedPath;
                Properties.Settings.Default.Save();

                ToggleWaitMode(true);

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Downloading log file",
                    Work = (sender, e) =>
                    {
                        var importLogRequest = new RetrieveFormattedImportJobResultsRequest
                        {
                            ImportJobId = importJobId
                        };
                        var importLogResponse = (RetrieveFormattedImportJobResultsResponse)lastTargetService.Execute(importLogRequest);

                        var filePath = $@"{dialog.SelectedPath}\{DateTime.Now:yyyy_MM_dd__HH_mm}.xml";
                        File.WriteAllText(filePath, importLogResponse.FormattedResults);

                        e.Result = filePath;
                    },
                    PostWorkCallBack = e =>
                    {
                        if (e.Error != null)
                        {
                            var message = string.Format("An error was encountered while downloading the log file.{0}Error:{0}{1}",
                                Environment.NewLine, e.Error.Message);
                            MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (
                                MessageBox.Show(
                                    $@"Download completed!

Would you like to open the file now ({e.Result})?

(Microsoft Excel is required)",
                                    @"File Download", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                                DialogResult.Yes)
                            {
                                Process.Start("Excel.exe", e.Result.ToString());
                            }
                        }

                        ToggleWaitMode(false);
                    }
                });
            }
        }

        private List<Entity> PreparareSolutionsToTransfer()
        {
            var solutionsToTransfer = new List<Entity>();
            if (mForm.SelectedSolutions.Count > 1)
            {
                // Open dialog to order solutions import
                foreach (var solution in mForm.SelectedSolutions)
                {
                    solutionsToTransfer.Add(solution);
                }

                var dialog = new SolutionOrderDialog(solutionsToTransfer);
                if (dialog.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    solutionsToTransfer = dialog.Solutions;
                }
                else
                {
                    return new List<Entity>();
                }
            }
            else
            {
                solutionsToTransfer.Add(mForm.SelectedSolutions.First());
            }

            return solutionsToTransfer;
        }

        private void PrepareExportRequest(Entity solution, List<OrganizationRequest> requests)
        {
            var request = new ExportSolutionRequest
            {
                Managed = Settings.Instance.Managed,
                SolutionName = solution.GetAttributeValue<string>("uniquename"),
                ExportAutoNumberingSettings = Settings.Instance.ExportAutoNumberingSettings,
                ExportCalendarSettings = Settings.Instance.ExportCalendarSettings,
                ExportCustomizationSettings = Settings.Instance.ExportCustomizationSettings,
                ExportEmailTrackingSettings = Settings.Instance.ExportEmailTrackingSettings,
                ExportGeneralSettings = Settings.Instance.ExportGeneralSettings,
                ExportIsvConfig = Settings.Instance.ExportIsvConfig,
                ExportMarketingSettings = Settings.Instance.ExportMarketingSettings,
                ExportOutlookSynchronizationSettings = Settings.Instance.ExportOutlookSynchronizationSettings,
                ExportRelationshipRoles = Settings.Instance.ExportRelationshipRoles,
                ExportSales = Settings.Instance.ExportSales
            };

            if (ConnectionDetail.OrganizationMajorVersion >= 8)
            {
                request.ExportExternalApplications = Settings.Instance.ExportExternalApplications;
            }

            progressItems.Add(request, new ProgressItem
            {
                Type = Enumerations.RequestType.Export,
                Detail = sourceDetail,
                Solution = solution.GetAttributeValue<string>("friendlyname"),
                Request = request
            });

            requests.Add(request);
        }

        private void PrepareImportRequest(ConnectionDetail detail, Entity solution, List<OrganizationRequest> requests)
        {
            var request = new ImportSolutionRequest
            {
                ConvertToManaged = Settings.Instance.ConvertToManaged,
                OverwriteUnmanagedCustomizations = Settings.Instance.OverwriteUnmanagedCustomizations,
                PublishWorkflows = Settings.Instance.PublishWorkflows,
                ImportJobId = Guid.NewGuid()
            };

            if (ConnectionDetail.OrganizationMajorVersion >= 8)
            {
                request.HoldingSolution = Settings.Instance.HoldingSolution;
                request.SkipProductUpdateDependencies = Settings.Instance.SkipProductUpdateDependencies;
            }

            var pi = new ProgressItem
            {
                Type = Enumerations.RequestType.Import,
                Detail = detail,
                Solution = solution.GetAttributeValue<string>("friendlyname"),
                Request = request
            };
            pi.LogFileRequested += Pi_LogFileRequested;
            progressItems.Add(request, pi);

            requests.Add(request);
        }

        private void PreparePublishRequest(ConnectionDetail detail, List<OrganizationRequest> requests)
        {
            var request = new PublishAllXmlRequest();
            progressItems.Add(request, new ProgressItem
            {
                Type = Enumerations.RequestType.Publish,
                Detail = detail,
                Request = request
            });

            requests.Add(request);
        }

        /// <summary>
        /// Retrieves unmanaged solutions from the source organization
        /// </summary>
        private void RetrieveSolutions()
        {
            var sourceSolutionsQuery = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet("publisherid", "installedon", "version", "uniquename", "friendlyname", "description"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("ismanaged", ConditionOperator.Equal, false),
                        new ConditionExpression("isvisible", ConditionOperator.Equal, true),
                        new ConditionExpression("uniquename", ConditionOperator.NotEqual, "Default")
                    }
                }
            };

            var solutions = sourceService.RetrieveMultiple(sourceSolutionsQuery);

            mForm.DisplaySolutions(solutions.Entities.ToList());
        }

        #endregion Methods

        private void ToggleWaitMode(bool on)
        {
            if (on)
            {
                Cursor = Cursors.WaitCursor;
                tsbTransfertSolution.Enabled = false;
                tsbLoadSolutions.Enabled = false;
                tsbFindMissingDependencies.Enabled = false;
                tsbSwitchOrgs.Enabled = false;
            }
            else
            {
                tsbTransfertSolution.Enabled = true;
                tsbLoadSolutions.Enabled = true;
                tsbFindMissingDependencies.Enabled = true;
                tsbSwitchOrgs.Enabled = true;

                Cursor = Cursors.Default;
            }
        }
    }
}