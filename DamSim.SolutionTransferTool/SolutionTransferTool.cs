using DamSim.SolutionTransferTool.AppCode;
using DamSim.SolutionTransferTool.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.WebServiceClient;
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
using static DamSim.SolutionTransferTool.BaseToProcess;

namespace DamSim.SolutionTransferTool
{
    public partial class SolutionTransferTool : MultipleConnectionsPluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        #region Variables

        private readonly MainForm mForm;
        private readonly ProgressForm pForm;
        private bool cancelPending;
        private OrganizationRequest currentRequest;
        private string lastConnectionName;
        private Guid lastImportId;
        private IOrganizationService lastTargetService;
        private MissingComponentsControl mcControl;
        private Settings oneTimeSettings;
        private Dictionary<OrganizationRequest, ProgressItem> progressItems;
        private Settings settings;
        private SettingsForm sForm;
        private Dictionary<int, string> solutionComponentTypes = new Dictionary<int, string>();
        private ConnectionDetail sourceDetail;
        private IOrganizationService sourceService;
        private System.Timers.Timer timer = new System.Timers.Timer();
        private List<BaseToProcess> toProcessList = new List<BaseToProcess>();

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
            pForm.OnRetry += PForm_OnRetry;
            pForm.Show(dpMain, DockState.DockRight);

            sForm = new SettingsForm();
            sForm.Show(dpMain, DockState.DockRight);
        }

        private void PForm_OnRetry(object sender, EventArgs e)
        {
            Retry();
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
            if (ConnectionDetail == null) return;

            settings.Save(ConnectionDetail?.ConnectionName);

            base.ClosingPlugin(info);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
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
                settings?.Save(ConnectionDetail?.ConnectionName);

                ConnectionDetail = detail;
                sourceDetail = detail;
                sourceService = newService;
                RetrieveSolutions();

                if (!SettingsManager.Instance.TryLoad(GetType(), out settings, ConnectionDetail.ConnectionName))
                {
                    settings = new Settings();
                }

                sForm.Settings = settings;
                mForm.SetSourceOrganization(detail);

                base.UpdateConnection(newService, detail, actionName, parameter);
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
            DownloadLogFile(e.ImportJobId, e.Service);
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
            oneTimeSettings = null;

            if (mForm.SelectedSolutions.Count == 0 || !AdditionalConnectionDetails.Any())
            {
                MessageBox.Show(this, @"You have to select a source solution and a target organization to continue.", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DoTransfer();
        }

        private void tssbTransfer_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (mForm.SelectedSolutions.Count == 0 || !AdditionalConnectionDetails.Any())
            {
                MessageBox.Show(this, @"You have to select a source solution and a target organization to continue.", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new SettingsForm(true))
            {
                dialog.Settings = (Settings)settings.Clone();
                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    oneTimeSettings = (Settings)dialog.Settings;
                    DoTransfer();
                }
            }
        }

        #endregion UI Events

        #region Methods

        private void DoTransfer()
        {
            var solutionsToTransfer = PreparareSolutionsToTransfer();
            if (solutionsToTransfer.Count == 0)
            {
                return;
            }

            if (ConnectionDetail.OrganizationMajorVersion >= 9 && ConnectionDetail.OrganizationMinorVersion >= 1)
            {
                var hasMissingConnectionReferences = false;

                foreach (var solution in solutionsToTransfer)
                {
                    foreach (var detail in AdditionalConnectionDetails)
                    {
                        hasMissingConnectionReferences = hasMissingConnectionReferences || SolutionHelper.CheckForNewConnectionReferences(solution.GetAttributeValue<string>("uniquename"), Service, detail.GetCrmServiceClient());
                    }
                }

                if (hasMissingConnectionReferences)
                {
                    var result = MessageBox.Show(this, @"It seems you are shipping new connection reference(s).

It is recommended to use Power Apps maker portal to import the solution that contains new connection references so that you can map new connection references in the target environment(s)

Are you sure you want to continue and import solution(s) using this tool?", @"New Connection reference(s) detected!",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
            }

            progressItems = new Dictionary<OrganizationRequest, ProgressItem>();
            toProcessList = new List<BaseToProcess>();

            foreach (var solution in solutionsToTransfer)
            {
                string newVersion = solution.GetAttributeValue<string>("version");

                if ((oneTimeSettings ?? settings).UpdateSourceSolutionVersionNew == UpdateVersionEnum.Yes
                    || (oneTimeSettings ?? settings).UpdateSourceSolutionVersionNew == UpdateVersionEnum.Prompt
                    )
                {
                    if ((oneTimeSettings ?? settings).VersionSchema == VersionType.Manual)
                    {
                        var dialog = new UpdateVersionForm(solution.GetAttributeValue<string>("version"), solution.GetAttributeValue<string>("friendlyname"));
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            newVersion = dialog.NewVersion;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        var computedNewVersion = GetUpdatedSolutionVersion(solution);

                        if ((oneTimeSettings ?? settings).UpdateSourceSolutionVersionNew == UpdateVersionEnum.Prompt)
                        {
                            if (DialogResult.Yes == MessageBox.Show(this,
                            $@"Do you want to update version for solution {solution.GetAttributeValue<string>("friendlyname")} ?

Current version: {solution.GetAttributeValue<string>("version")}
New version: {computedNewVersion}",
                            @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                newVersion = computedNewVersion;
                            }
                        }
                        else
                        {
                            newVersion = computedNewVersion;
                        }
                    }

                    if (solution.GetAttributeValue<string>("version") != newVersion)
                    {
                        solution["version"] = newVersion;
                        Service.Update(solution);
                        mForm.UpdateSolutionVersion(solution);
                    }
                }

                var exportItem = new ExportToProcess
                {
                    Solution = solution,
                    Previous = toProcessList.OfType<ExportToProcess>().LastOrDefault(),
                    Request = PrepareExportRequest(solution),
                    Detail = sourceDetail
                };
                toProcessList.Add(exportItem);

                foreach (var detail in AdditionalConnectionDetails)
                {
                    toProcessList.Add(new ImportToProcess
                    {
                        Solution = solution,
                        Previous = toProcessList.OfType<ImportToProcess>().LastOrDefault(x => x.Detail == detail),
                        Export = exportItem,
                        Request = PrepareImportRequest(detail, solution),
                        Detail = detail
                    });
                }
            }

            if (!(oneTimeSettings ?? settings).Managed && (oneTimeSettings ?? settings).Publish)
            {
                foreach (var detail in AdditionalConnectionDetails)
                {
                    toProcessList.Add(new PublishToProcess
                    {
                        Request = PreparePublishRequest(detail),
                        Detail = detail
                    });
                }
            }

            // Add items to progress form
            pForm.Items = progressItems.Values.ToList();
            pForm.Start();

            pForm.Show(dpMain, DockState.DockRight);

            StartExport(toProcessList.OfType<ExportToProcess>().First());

            timer.Elapsed += Timer_Elapsed;
            timer.Interval = (oneTimeSettings ?? settings).RefreshIntervalProp.TotalMilliseconds;
            timer.Start();
        }

        private void DownloadLogFile(Guid importJobId, IOrganizationService service)
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
                        var importLogResponse = (RetrieveFormattedImportJobResultsResponse)service.Execute(importLogRequest);

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
                                Process.Start("Excel.exe", $"\"{e.Result}\"");
                            }
                        }

                        ToggleWaitMode(false);
                    }
                });
            }
        }

        private string GetUpdatedSolutionVersion(Entity etpSolution)
        {
            string version = etpSolution.GetAttributeValue<string>("version");
            var versionParts = version.Split('.');
            switch (oneTimeSettings?.VersionSchema ?? settings.VersionSchema)
            {
                case VersionType.Major:
                    versionParts[0] = (int.Parse(versionParts[0]) + 1).ToString();
                    break;

                case VersionType.Minor:
                    if (versionParts.Length < 2) break;
                    versionParts[1] = (int.Parse(versionParts[1]) + 1).ToString();
                    break;

                case VersionType.Build:
                    if (versionParts.Length < 3) break;
                    versionParts[2] = (int.Parse(versionParts[2]) + 1).ToString();
                    break;

                case VersionType.Revision:
                    if (versionParts.Length < 4) break;
                    versionParts[3] = (int.Parse(versionParts[3]) + 1).ToString();
                    break;
            }

            return string.Join(".", versionParts);
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

        private ExportSolutionRequest PrepareExportRequest(Entity solution, ExportSolutionRequest request = null)
        {
            var isNull = request == null;
            if (isNull)
            {
                request = new ExportSolutionRequest();
            }

            request.Managed = (oneTimeSettings ?? settings).Managed;
            request.SolutionName = solution.GetAttributeValue<string>("uniquename");
            request.ExportAutoNumberingSettings = (oneTimeSettings ?? settings).ExportAutoNumberingSettings;
            request.ExportCalendarSettings = (oneTimeSettings ?? settings).ExportCalendarSettings;
            request.ExportCustomizationSettings = (oneTimeSettings ?? settings).ExportCustomizationSettings;
            request.ExportEmailTrackingSettings = (oneTimeSettings ?? settings).ExportEmailTrackingSettings;
            request.ExportGeneralSettings = (oneTimeSettings ?? settings).ExportGeneralSettings;
            request.ExportIsvConfig = (oneTimeSettings ?? settings).ExportIsvConfig;
            request.ExportMarketingSettings = (oneTimeSettings ?? settings).ExportMarketingSettings;
            request.ExportOutlookSynchronizationSettings = (oneTimeSettings ?? settings).ExportOutlookSynchronizationSettings;
            request.ExportRelationshipRoles = (oneTimeSettings ?? settings).ExportRelationshipRoles;
            request.ExportSales = (oneTimeSettings ?? settings).ExportSales;

            if (ConnectionDetail.OrganizationMajorVersion >= 8)
            {
                request.ExportExternalApplications = (oneTimeSettings ?? settings).ExportExternalApplications;
            }

            if (isNull)
            {
                progressItems.Add(request, new ProgressItem
                {
                    Type = Enumerations.RequestType.Export,
                    Detail = sourceDetail,
                    Solution = solution.GetAttributeValue<string>("friendlyname"),
                    SolutionVersion = solution.GetAttributeValue<string>("version"),
                    Request = request
                });
            }

            return request;
        }

        private OrganizationRequest PrepareImportRequest(ConnectionDetail detail, Entity solution, OrganizationRequest request = null)
        {
            var isPatch = solution.GetAttributeValue<string>("uniquename").ToLower().Contains("_patch_");
            var isNull = request == null;
            if (isNull)
            {
                request = (oneTimeSettings ?? settings).ImportMode == ImportModeEnum.Upgrade && !isPatch ? new StageAndUpgradeRequest() : (OrganizationRequest)new ImportSolutionRequest();
            }

            if (request is ImportSolutionRequest isr)
            {
                isr.ConvertToManaged = (oneTimeSettings ?? settings).ConvertToManaged;
                isr.OverwriteUnmanagedCustomizations = (oneTimeSettings ?? settings).OverwriteUnmanagedCustomizations;
                isr.PublishWorkflows = (oneTimeSettings ?? settings).PublishWorkflows;
                isr.ImportJobId = Guid.NewGuid();

                if (ConnectionDetail.OrganizationMajorVersion >= 8)
                {
                    isr.HoldingSolution = (oneTimeSettings ?? settings).ImportMode == ImportModeEnum.StageForUpgrade && !isPatch;
                    isr.SkipProductUpdateDependencies = (oneTimeSettings ?? settings).SkipProductUpdateDependencies;
                }
            }
            else if (request is StageAndUpgradeRequest saur)
            {
                saur.ConvertToManaged = (oneTimeSettings ?? settings).ConvertToManaged;
                saur.OverwriteUnmanagedCustomizations = (oneTimeSettings ?? settings).OverwriteUnmanagedCustomizations;
                saur.PublishWorkflows = (oneTimeSettings ?? settings).PublishWorkflows;
                saur.ImportJobId = Guid.NewGuid();

                if (ConnectionDetail.OrganizationMajorVersion >= 8)
                {
                    saur.SkipProductUpdateDependencies = (oneTimeSettings ?? settings).SkipProductUpdateDependencies;
                }
            }

            if (isNull)
            {
                var pi = new ProgressItem
                {
                    Type = Enumerations.RequestType.Import,
                    Detail = detail,
                    Solution = solution.GetAttributeValue<string>("friendlyname"),
                    SolutionVersion = solution.GetAttributeValue<string>("version"),
                    Request = request
                };
                pi.LogFileRequested += Pi_LogFileRequested;
                progressItems.Add(request, pi);
            }

            return request;
        }

        private PublishAllXmlRequest PreparePublishRequest(ConnectionDetail detail)
        {
            var request = new PublishAllXmlRequest();
            progressItems.Add(request, new ProgressItem
            {
                Type = Enumerations.RequestType.Publish,
                Detail = detail,
                Request = request
            });

            return request;
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

            var solutionComponentsQuery = new QueryExpression
            {
                EntityName = "solutioncomponentdefinition",
                ColumnSet = new ColumnSet("name", "solutioncomponenttype"),
            };

            solutionComponentTypes = new Dictionary<int, string> ();

            foreach (var def in sourceService.RetrieveMultiple(solutionComponentsQuery).Entities)
            {
                var compDef = def.GetAttributeValue<int>("solutioncomponenttype");

                if (!solutionComponentTypes.ContainsKey(compDef))
                {
                    solutionComponentTypes.Add(compDef, def.GetAttributeValue<string>("name"));
                }
                else
                {
                    solutionComponentTypes[compDef] = def.GetAttributeValue<string>("name");
                }
            }

            var opt = (RetrieveOptionSetResponse)sourceService.Execute(new RetrieveOptionSetRequest
            {
                Name = "componenttype"
            });

            foreach (var op in ((OptionSetMetadata)opt.OptionSetMetadata).Options)
            {
                if (!solutionComponentTypes.ContainsKey(op.Value.Value))
                {
                    solutionComponentTypes.Add(op.Value.Value, op.Label.UserLocalizedLabel.Label);
                }
                else
                {
                    solutionComponentTypes[op.Value.Value] = op.Label.UserLocalizedLabel.Label;
                }
            }

            mForm.DisplaySolutions(solutions.Entities.ToList());
        }

        private void StartExport(ExportToProcess etp)
        {
            if ((oneTimeSettings ?? settings).AutoExportSolutionsToDisk)
            {
                if (!Directory.Exists((oneTimeSettings ?? settings).AutoExportSolutionsFolderPath))
                {
                    MessageBox.Show(this,
                        $@"Folder {(oneTimeSettings ?? settings).AutoExportSolutionsFolderPath} does not exist! Please update settings",
                        @"Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    sForm.Show(dpMain, sForm.DockState);
                    return;
                }
            }

            ToggleWaitMode(true);

            etp.StartedOn = DateTime.Now;
            progressItems[etp.Request].Solution = etp.Solution.GetAttributeValue<string>("friendlyname");
            progressItems[etp.Request].SolutionVersion = etp.Solution.GetAttributeValue<string>("version");
            progressItems[etp.Request].Start();

            if ((oneTimeSettings ?? settings).ExportAsynchronously)
            {
                var request2 = new OrganizationRequest("ExportSolutionAsync");
                request2.Parameters = etp.Request.Parameters;

                var response2 = Service.Execute(request2);
                etp.AsyncOperationId = (Guid)response2.Results["AsyncOperationId"];
                etp.ExportJobId = (Guid)response2.Results["ExportJobId"];

                etp.IsProcessed = false;
                etp.IsProcessing = true;
                etp.Succeeded = false;

                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "",
                Work = (bw, evt) =>
                {
                    etp.IsProcessing = true;
                    etp.SolutionContent = ((ExportSolutionResponse)etp.Detail.GetCrmServiceClient().Execute(etp.Request))
                        .ExportSolutionFile;
                },
                PostWorkCallBack = evt =>
                {
                    etp.IsProcessed = true;
                    etp.IsProcessing = false;
                    etp.Succeeded = true;
                    etp.CompletedOn = DateTime.Now;
                    if (evt.Error != null)
                    {
                        etp.Succeeded = false;

                        progressItems[etp.Request].Error(DateTime.Now, evt.Error.Message);
                        pForm.ShowRetryButton(progressItems[etp.Request]);

                        ToggleWaitMode(false);
                    }
                    else
                    {
                        progressItems[etp.Request].Success(etp);
                        progressItems[etp.Request].SolutionFile = etp.SolutionContent;
                    }

                    if ((oneTimeSettings ?? settings).AutoExportSolutionsToDisk)
                    {
                        var fileName = progressItems[etp.Request].SolutionFileName;
                        var filePath = Path.Combine((oneTimeSettings ?? settings).AutoExportSolutionsFolderPath, fileName);
                        try
                        {
                            File.WriteAllBytes(filePath, etp.SolutionContent);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(this, $@"Error when saving solution {fileName} to disk.

{error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cancelPending)
            {
                foreach (var etp in toProcessList.OfType<ExportToProcess>())
                {
                    etp.IsProcessed = false;
                    etp.IsProcessing = false;
                    progressItems[etp.Request].Error(DateTime.Now.ToLocalTime(), "Export canceled by user");
                }

                foreach (var itp in toProcessList.OfType<ImportToProcess>())
                {
                    itp.IsProcessed = false;
                    itp.IsProcessing = false;
                    progressItems[itp.Request].Error(DateTime.Now.ToLocalTime(), "Export canceled by user");
                }

                foreach (var ptp in toProcessList.OfType<PublishToProcess>())
                {
                    ptp.IsProcessed = false;
                    ptp.IsProcessing = false;
                    progressItems[ptp.Request].Error(DateTime.Now.ToLocalTime(), "Export canceled by user");
                }

                timer.Stop();
                ToggleWaitMode(false);
                cancelPending = false;
                tsbCancel.Text = "Cancel";
                return;
            }

            foreach (var etp in toProcessList.OfType<ExportToProcess>())
            {
                if (!etp.IsProcessed && !etp.IsProcessing)
                {
                    StartExport(etp);
                }
                else if (etp.IsProcessing && (oneTimeSettings ?? settings).ExportAsynchronously)
                {
                    var task = etp.Detail.GetCrmServiceClient().RetrieveMultiple(new QueryExpression("asyncoperation")
                    {
                        NoLock = true,
                        ColumnSet = new ColumnSet(true),
                        Criteria =
                                {
                                    Conditions=
                                    {
                                        new ConditionExpression("asyncoperationid", ConditionOperator.Equal, etp.AsyncOperationId)
                                    }
                                }
                    }).Entities.FirstOrDefault();

                    if (task != null)
                    {
                        if (task.GetAttributeValue<OptionSetValue>("statecode")?.Value == 3)
                        {
                            etp.IsProcessed = true;
                            etp.IsProcessing = false;
                            if (task.GetAttributeValue<OptionSetValue>("statuscode")?.Value == 30)
                            {
                                var exportRecord = Service.Retrieve("exportsolutionupload", etp.ExportJobId, new ColumnSet("solutionfile"));

                                var initRequest = new InitializeFileBlocksDownloadRequest() { FileAttributeName = "solutionfile", Target = exportRecord.ToEntityReference() };
                                var initResponse = (InitializeFileBlocksDownloadResponse)Service.Execute(initRequest);

                                var increment = 4194304;
                                var from = 0;
                                var fileSize = initResponse.FileSizeInBytes;
                                byte[] downloaded = new byte[fileSize];
                                var fileContinuationToken = initResponse.FileContinuationToken;

                                while (from < fileSize)
                                {
                                    var blockRequest = new DownloadBlockRequest()
                                    {
                                        Offset = from,
                                        BlockLength = increment,
                                        FileContinuationToken = fileContinuationToken
                                    };
                                    var blockResponse = (DownloadBlockResponse)Service.Execute(blockRequest);
                                    blockResponse.Data.CopyTo(downloaded, from);
                                    from += increment;
                                }

                                etp.SolutionContent = downloaded;
                                etp.CompletedOn = DateTime.Now;

                                progressItems[etp.Request].Success(etp);
                                progressItems[etp.Request].SolutionFile = downloaded;

                                etp.Succeeded = true;

                                if ((oneTimeSettings ?? settings).AutoExportSolutionsToDisk || etp.IsSolutionDownload)
                                {
                                    var fileName = progressItems[etp.Request].SolutionFileName;
                                    var filePath = Path.Combine((oneTimeSettings ?? settings).AutoExportSolutionsFolderPath, fileName);
                                    try
                                    {
                                        File.WriteAllBytes(filePath, etp.SolutionContent);

                                        if (etp.IsSolutionDownload)
                                        {
                                            Invoke(new Action(() =>
                                            {
                                                MessageBox.Show(this, $@"Solution exported to {filePath}", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }));
                                        }
                                    }
                                    catch (Exception error)
                                    {
                                        Invoke(new Action(() =>
                                            {
                                                MessageBox.Show(this, $@"Error when saving solution {fileName} to disk.

{error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }));
                                    }
                                }
                            }
                            else
                            {
                                progressItems[etp.Request].Error(task.GetAttributeValue<DateTime>("completedon").ToLocalTime());
                                ToggleWaitMode(false);
                                timer.Stop();
                                pForm.ShowRetryButton(progressItems[etp.Request]);
                            }

                            if (toProcessList.All(tp => tp.IsProcessed))
                            {
                                timer.Stop();
                                ToggleWaitMode(false);
                            }
                        }
                        else
                        {
                            progressItems[etp.Request]
                                .ReportProgress(task.GetAttributeValue<double>("progress"), etp);
                        }
                    }
                }
            }

            foreach (var itp in toProcessList.OfType<ImportToProcess>()
                    .Where(i => /*i.Export == etp && */i.Export.IsProcessed && i.Export.Succeeded))
            {
                if (itp.Previous != null && !itp.Previous.IsProcessed || itp.IsProcessed)
                {
                    continue;
                }

                if (!itp.IsProcessing && !itp.IsProcessed)
                {
                    itp.StartedOn = DateTime.Now;
                    progressItems[itp.Request].Solution = itp.Solution.GetAttributeValue<string>("friendlyname");
                    progressItems[itp.Request].Start();
                    itp.IsProcessing = true;

                    if ((oneTimeSettings ?? settings).CheckForMissingDependencies)
                    {
                        RetrieveMissingComponentsResponse response = (RetrieveMissingComponentsResponse)itp.Detail.GetCrmServiceClient().Execute(new RetrieveMissingComponentsRequest
                        {
                            CustomizationFile = itp.Export.SolutionContent
                        });

                        if (response.MissingComponents != null && response.MissingComponents.Any())
                        {
                            if (mcControl == null)
                            {
                                mcControl = new MissingComponentsControl();
                                mcControl.Name = "MissingComponentsControl1";
                                mcControl.OnClose += (s, evt) => { Controls.Remove(mcControl); };
                            }

                            Invoke(new Action(() =>
                             {
                                 mcControl.ComponentsTypes = solutionComponentTypes;
                                 mcControl.Components = response.MissingComponents;
                                 mcControl.ShowData();
                                 Controls.Add(mcControl);
                                 mcControl.DisplayCentered();
                                 mcControl.BringToFront();
                             }));

                            progressItems[itp.Request].Error(DateTime.Now, "Your solution has missing components in the target environment");
                            itp.IsProcessing = false;
                            ToggleWaitMode(false);
                            timer.Stop();
                            pForm.ShowRetryButton(progressItems[itp.Request]);

                            return;
                        }
                    }

                    if (itp.Request is ImportSolutionRequest isr)
                    {
                        isr.CustomizationFile = itp.Export.SolutionContent;
                    }
                    else if (itp.Request is StageAndUpgradeRequest saur)
                    {
                        saur.CustomizationFile = itp.Export.SolutionContent;
                    }

                    itp.AsyncOperationId = ((ExecuteAsyncResponse)itp.Detail.GetCrmServiceClient().Execute(new ExecuteAsyncRequest
                    {
                        Request = itp.Request
                    })).AsyncJobId;

                    lastImportId = ((ImportSolutionRequest)itp.Request).ImportJobId;
                }
                else if (itp.IsProcessing)
                {
                    var task = itp.Detail.GetCrmServiceClient().RetrieveMultiple(new QueryExpression("asyncoperation")
                    {
                        NoLock = true,
                        ColumnSet = new ColumnSet(true),
                        Criteria =
                                {
                                    Conditions=
                                    {
                                        new ConditionExpression("asyncoperationid", ConditionOperator.Equal, itp.AsyncOperationId)
                                    }
                                }
                    }).Entities.FirstOrDefault();

                    if (task != null)
                    {
                        if (task.GetAttributeValue<OptionSetValue>("statecode")?.Value == 3)
                        {
                            itp.IsProcessed = true;
                            itp.IsProcessing = false;
                            itp.CompletedOn = DateTime.Now;
                            if (task.GetAttributeValue<OptionSetValue>("statuscode")?.Value == 30)
                            {
                                progressItems[itp.Request].Success(itp);
                                itp.Succeeded = true;
                            }
                            else
                            {
                                progressItems[itp.Request].Error(task.GetAttributeValue<DateTime>("completedon").ToLocalTime());
                                ToggleWaitMode(false);
                                timer.Stop();
                                pForm.ShowRetryButton(progressItems[itp.Request]);
                            }

                            if (toProcessList.All(tp => tp.IsProcessed))
                            {
                                timer.Stop();
                                ToggleWaitMode(false);
                            }
                        }
                        else
                        {
                            Guid importJobId = Guid.Empty;
                            if (itp.Request is ImportSolutionRequest isr)
                            {
                                importJobId = isr.ImportJobId;
                            }
                            else if (itp.Request is StageAndUpgradeRequest saur)
                            {
                                importJobId = saur.ImportJobId;
                            }

                            var job = itp.Detail.GetCrmServiceClient().RetrieveMultiple(new QueryExpression("importjob")
                            {
                                NoLock = true,
                                ColumnSet = new ColumnSet(true),
                                Criteria =
                                    {
                                        Conditions=
                                        {
                                            new ConditionExpression("importjobid", ConditionOperator.Equal, importJobId)
                                        }
                                    }
                            }).Entities.FirstOrDefault();

                            if (job != null)
                            {
                                progressItems[itp.Request]
                                    .ReportProgress(job.GetAttributeValue<double>("progress"), itp, job.GetAttributeValue<string>("operationcontext") == "Upgrade");
                            }
                        }
                    }
                }
            }

            foreach (var ptp in toProcessList.OfType<PublishToProcess>())
            {
                if (toProcessList.OfType<ImportToProcess>()
                        .Where(i => i.Detail == ptp.Detail)
                        .All(i => i.Succeeded)
                    && !ptp.IsProcessed && !ptp.IsProcessing)
                {
                    ptp.StartedOn = DateTime.Now;
                    progressItems[ptp.Request].Start();

                    WorkAsync(new WorkAsyncInfo
                    {
                        Message = "",
                        Work = (bw, evt) =>
                        {
                            ptp.IsProcessing = true;
                            ptp.Detail.GetCrmServiceClient().Execute(ptp.Request);
                            ptp.IsProcessed = true;
                            ptp.IsProcessing = false;
                        },
                        PostWorkCallBack = evt =>
                        {
                            if (evt.Error != null)
                                progressItems[ptp.Request].Error(DateTime.Now);
                            else
                            {
                                ptp.CompletedOn = DateTime.Now;
                                progressItems[ptp.Request].Success(ptp);
                            }

                            if (toProcessList.All(tp => tp.IsProcessed))
                            {
                                timer.Stop();
                                ToggleWaitMode(false);
                            }
                        }
                    });
                }

                if (toProcessList.OfType<ImportToProcess>()
                       .Where(i => i.Detail == ptp.Detail)
                       .Any(i => i.IsProcessed && !i.Succeeded)
                   && !ptp.IsProcessed)
                {
                    progressItems[ptp.Request].Error(DateTime.Now);
                    timer.Stop();
                    ToggleWaitMode(false);
                }
            }
        }

        #endregion Methods

        private void Retry()
        {
            if (DialogResult.Yes != MessageBox.Show(this, @"Are you sure you want to retry last failed action?",
                    @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            var firstNotSucceededProcess = toProcessList.FirstOrDefault(x => x.Succeeded == false);
            if (firstNotSucceededProcess == null)
            {
                return;
            }

            if (firstNotSucceededProcess is ExportToProcess etp)
            {
                etp.IsProcessed = false;
                StartExport(etp);
            }
            else if (firstNotSucceededProcess is ImportToProcess itp)
            {
                itp.IsProcessed = false;
                progressItems[itp.Request].Start();
            }

            foreach (var ep in toProcessList.OfType<ExportToProcess>().Where(x => x.IsProcessed == false))
            {
                PrepareExportRequest(ep.Solution, (ExportSolutionRequest)ep.Request);
            }

            foreach (var ip in toProcessList.OfType<ImportToProcess>().Where(x => x.IsProcessed == false))
            {
                PrepareImportRequest(ip.Detail, ip.Solution, ip.Request);
            }

            ToggleWaitMode(true);

            timer.Elapsed += Timer_Elapsed;
            timer.Interval = (oneTimeSettings ?? settings).RefreshIntervalProp.TotalMilliseconds;
            timer.Start();
        }

        private void SolutionTransferTool_Resize(object sender, EventArgs e)
        {
            var control = Controls.Find("MissingComponentsControl1", true);
            if (control.Length == 1)
            {
                if (((MissingComponentsControl)control[0]).IsMaximized)
                {
                    control[0].Width = Width;
                    control[0].Height = Height;
                    control[0].Location = new System.Drawing.Point(0, 0);
                }
                else
                {
                    control[0].Width = Convert.ToInt32(Width * 0.7);
                    control[0].Height = Convert.ToInt32(Height * 0.7);
                    control[0].Location = new System.Drawing.Point(Width / 2 - control[0].Width / 2, Height / 2 - control[0].Height / 2);
                }
            }
        }

        private void ToggleWaitMode(bool on)
        {
            Invoke(new Action(() =>
            {
                if (on)
                {
                    tssbTransfer.Enabled = false;
                    tsbLoadSolutions.Enabled = false;
                    tsbFindMissingDependencies.Enabled = false;
                    tsbSwitchOrgs.Enabled = false;
                    tsbExportSolutions.Enabled = false;
                    tsbDownload.Enabled = false;
                    tsbCancel.Visible = true;
                }
                else
                {
                    tsbDownload.Enabled = true;
                    tssbTransfer.Enabled = true;
                    tsbLoadSolutions.Enabled = true;
                    tsbFindMissingDependencies.Enabled = lastImportId != Guid.Empty;
                    tsbSwitchOrgs.Enabled = true;
                    tsbExportSolutions.Enabled = toProcessList.OfType<ExportToProcess>().Any(etp =>
                        etp.SolutionContent != null);
                    tsbCancel.Visible = false;
                }
            }));
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            cancelPending = true;
            tsbCancel.Text = "Cancelling...";
        }

        private void tsbDownload_Click(object sender, EventArgs e)
        {
            if (mForm.SelectedSolutions.Count == 0)
            {
                MessageBox.Show(this, @"No solution selected!", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var path = "";

            if (string.IsNullOrEmpty((oneTimeSettings ?? settings).AutoExportSolutionsFolderPath))
            {
                var dialog = new CustomFolderBrowserDialog();
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                path = dialog.FolderPath;
            }

            var solutions = mForm.SelectedSolutions;

            if ((oneTimeSettings ?? settings).ExportAsynchronously)
            {
                progressItems = new Dictionary<OrganizationRequest, ProgressItem>();
                toProcessList = new List<BaseToProcess>();

                foreach (var solution in solutions)
                {
                    var exportItem = new ExportToProcess
                    {
                        Solution = solution,
                        Previous = toProcessList.OfType<ExportToProcess>().LastOrDefault(),
                        Request = PrepareExportRequest(solution),
                        Detail = sourceDetail,
                        IsSolutionDownload = true
                    };
                    toProcessList.Add(exportItem);
                }

                pForm.Items = progressItems.Values.ToList();
                pForm.Start();

                pForm.Show(dpMain, DockState.DockRight);

                StartExport(toProcessList.OfType<ExportToProcess>().First());

                timer.Elapsed += Timer_Elapsed;
                timer.Interval = settings.RefreshIntervalProp.TotalMilliseconds;
                timer.Start();

                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "",
                Work = (bw, evt) =>
                {
                    foreach (var solution in solutions)
                    {
                        bw.ReportProgress(0, $"Exporting solution {solution.GetAttributeValue<string>("friendlyname")}...");

                        var request = new ExportSolutionRequest();
                        PrepareExportRequest(solution, request);

                        string filename = Path.Combine(path,
                            $"{solution.GetAttributeValue<string>("uniquename")}_{solution.GetAttributeValue<string>("version").Replace(".", "_")}{(request.Managed ? "_managed" : "")}.zip");
                        var contentFile = ((ExportSolutionResponse)sourceService.Execute(request)).ExportSolutionFile;
                        File.WriteAllBytes(filename, contentFile);
                    }
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $@"An error occured when exporting solution(s): {evt.Error.Message}", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(this, $@"Solution(s) exported to {path}", @"Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                }
            });
        }

        private void tsbExportSolutions_Click(object sender, EventArgs e)
        {
            var cfd = new CustomFolderBrowserDialog();
            if (cfd.ShowDialog(Parent) == DialogResult.OK)
            {
                foreach (var etp in toProcessList.OfType<ExportToProcess>())
                {
                    if (etp.SolutionContent != null)
                    {
                        string filename = Path.Combine(cfd.FolderPath,
                            $"{etp.Solution.GetAttributeValue<string>("uniquename")}_{etp.Solution.GetAttributeValue<string>("version").Replace(".", "_")}{(((ExportSolutionRequest)etp.Request).Managed ? "_managed" : "")}.zip");
                        File.WriteAllBytes(filename, etp.SolutionContent);
                    }
                }

                MessageBox.Show(this, $@"Solution(s) saved to {cfd.FolderPath}", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}