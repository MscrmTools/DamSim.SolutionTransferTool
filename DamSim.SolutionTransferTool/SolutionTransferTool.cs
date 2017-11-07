using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using InformationPanel = XrmToolBox.Extensibility.InformationPanel;
using System.Linq;

namespace DamSim.SolutionTransferTool
{
    public partial class SolutionTransferTool : UserControl, IXrmToolBoxPluginControl, IGitHubPlugin, IHelpPlugin
    {
        #region Variables

        private int currentsColumnOrder;
        private ConnectionDetail detail;
        private Guid lastImportId;
        private Panel infoPanel;
        private string SolutionUrlBase;
        private IOrganizationService service;
        private Dictionary<string, IOrganizationService> targetServices = new Dictionary<string, IOrganizationService>();
        private KeyValuePair<string, IOrganizationService> lastTargetService;

        #endregion Variables

        #region Constructor

        public SolutionTransferTool()
        {
            InitializeComponent();

        }

        #endregion Constructor

        #region XrmToolbox

        public event EventHandler OnCloseTool;

        public event EventHandler OnRequestConnection;

        public Image PluginLogo
        {
            get { return imageList1.Images[0]; }
        }

        public IOrganizationService Service
        {
            get { return service; }
        }

        public string RepositoryName
        {
            get
            {
                return "DamSim.SolutionTransferTool";
            }
        }

        public string UserName
        {
            get
            {
                return "MscrmTools";
            }
        }

        public string HelpUrl
        {
            get
            {
                return "https://github.com/MscrmTools/DamSim.SolutionTransferTool/wiki";
            }
        }

        public void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName = "", object parameter = null)
        {
            this.detail = detail;
            if (actionName == "TargetOrganization")
            {
                targetServices.Add(detail.ConnectionName, newService);
                lastTargetService = new KeyValuePair<string, IOrganizationService>(detail.ConnectionName, newService);
                lstTargetEnvironments.Items.Add(new ListViewItem{ Text = detail.ConnectionName });
            }
            else
            {
                service = newService;
                SolutionUrlBase = detail.WebApplicationUrl;
                SetConnectionLabel(detail, "Source");
                RetrieveSolutions();
            }
        }

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            InformationPanel.ChangeInformationPanelMessage(infoPanel, e.UserState.ToString());
        }

        /// <summary>
        /// Executes once the work is done, ie the solution import.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            infoPanel.Dispose();
            Controls.Remove(infoPanel);

            tsbLoadSolutions.Enabled = true;
            tsbTransfertSolution.Enabled = true;
            btnAddTarget.Enabled = true;
            Cursor = Cursors.Default;

            string message;

            if (e.Error != null)
            {
                message = string.Format("An error occured: {0}", e.Error.Message);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tsbDownloadLogFile.Enabled = true;
                tsbFindMissingDependencies.Enabled = true;
            }
            else
            {
                message = "Import finished successfully!";
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion XrmToolbox

        #region UI Events

        private void BtnCloseClick(object sender, EventArgs e)
        {
            if (OnCloseTool != null)
            {
                const string message = "Are you sure to exit?";
                if (MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                    OnCloseTool(this, null);
            }
        }

        private void BtnDownloadLogClick(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastFolderUsed))
                dialog.SelectedPath = Properties.Settings.Default.LastFolderUsed;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LastFolderUsed = dialog.SelectedPath;
                Properties.Settings.Default.Save();

                ToggleWaitMode(true);

                var worker = new BackgroundWorker();
                worker.DoWork += (o, args) => args.Result = DownloadLogFile(dialog.SelectedPath);
                worker.RunWorkerCompleted += (o, args) =>
                {
                    if (args.Error != null)
                    {
                        var message = string.Format("An error was encountered while downloading the log file.{0}Error:{0}{1}", Environment.NewLine, args.Error.Message);
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (
                            MessageBox.Show(
                                string.Format("Download completed!\r\n\r\nWould you like to open the file now ({0})?\r\n\r\n(Microsoft Excel is required)", args.Result),
                                "File Download", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                            DialogResult.Yes)
                        {
                            Process.Start("Excel.exe", args.Result.ToString());
                        }
                    }
                    ToggleWaitMode(false);
                };
                worker.RunWorkerAsync();
            }
        }

        private void BtnSelectTargetClick(object sender, EventArgs e)
        {
            if (OnRequestConnection != null)
            {
                var args = new RequestConnectionEventArgs { ActionName = "TargetOrganization", Control = this };
                OnRequestConnection(this, args);
            }
        }




        #endregion UI Events

    
        #region Methods


        /// <summary>
        /// Downloads the Log file
        /// </summary>
        /// <param name="path"></param>
        private string DownloadLogFile(string path)
        {
            var importLogRequest = new RetrieveFormattedImportJobResultsRequest
            {
                ImportJobId = lastImportId
            };
            var importLogResponse = (RetrieveFormattedImportJobResultsResponse)lastTargetService.Value.Execute(importLogRequest);

            var filePath = string.Format(@"{0}\{1}.xml", path, DateTime.Now.ToString("yyyy_MM_dd__HH_mm"));
            File.WriteAllText(filePath, importLogResponse.FormattedResults);

            return filePath;
        }

        /// <summary>
        /// Retrieves unmanaged solutions from the source organization
        /// </summary>
        private void RetrieveSolutions()
        {
            lstSourceSolutions.Items.Clear();

            var sourceSolutionsQuery = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet =
                                                   new ColumnSet(new[]
                                                                     {
                                                                         "publisherid", "installedon", "version",
                                                                         "uniquename", "friendlyname", "description"
                                                                     }),
                Criteria = new FilterExpression()
            };

            sourceSolutionsQuery.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);
            sourceSolutionsQuery.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
            sourceSolutionsQuery.Criteria.AddCondition("uniquename", ConditionOperator.NotEqual, "Default");

            var solutions = service.RetrieveMultiple(sourceSolutionsQuery);

            foreach (var solution in solutions.Entities)
            {
                var item = new ListViewItem
                {
                    Tag = solution.GetAttributeValue<Guid>("solutionid"),
                    Text = solution.GetAttributeValue<String>("uniquename")
                };
                item.SubItems.Add(solution.GetAttributeValue<String>("friendlyname"));
                item.SubItems.Add(solution.GetAttributeValue<String>("version"));
                item.SubItems.Add(solution.GetAttributeValue<DateTime>("installedon").ToString("yy-MM-dd HH:mm"));
                item.SubItems.Add(solution.GetAttributeValue<EntityReference>("publisherid").Name);
                item.SubItems.Add(solution.GetAttributeValue<String>("description"));
                lstSourceSolutions.Items.Add(item);
            }
        }

        /// <summary>
        /// Sets the connections labels on either the source/target section
        /// </summary>
        /// <param name="serviceToLabel"></param>
        /// <param name="serviceType"></param>
        private void SetConnectionLabel(ConnectionDetail detail, string serviceType)
        {
            switch (serviceType)
            {
                case "Source":
                    lblSource.Text = detail.ConnectionName;
                    lblSource.ForeColor = Color.Green;
                    break;

                //case "Target":
                //    lblTarget.Text = detail.ConnectionName;
                //    lblTarget.ForeColor = Color.Green;
                //    break;
            }
        }

        /// <summary>
        /// Exports the selected solution as a managed one, and imports it on the target organization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerDoWorkExport(object sender, DoWorkEventArgs e)
        {
            var bw = (BackgroundWorker)sender;
            var requests = (List<OrganizationRequest>)e.Argument;
            var solutionName = string.Empty;
            byte[] solutionFileContent = null;

          
               
                foreach (var request in requests)
                {
                    var exportRequest = request as ExportSolutionRequest;
                    if (exportRequest != null)
                    {
                        solutionName = exportRequest.SolutionName;

                        bw.ReportProgress(0, string.Format("Exporting solution {0} ...", solutionName));
                        var exportResponse = (ExportSolutionResponse)service.Execute(exportRequest);
                        solutionFileContent = exportResponse.ExportSolutionFile;

                       // continue;
                    }

                foreach (var targetService in targetServices)
                {
                    lastTargetService = targetService;
                    var importRequest = request as ImportSolutionRequest;
                    if (importRequest != null)
                    {
                        lastImportId = importRequest.ImportJobId;

                        bw.ReportProgress(0, string.Format("Importing solution {0} to {1}...", solutionName,targetService.Key));
                        importRequest.CustomizationFile = solutionFileContent;
                        targetService.Value.Execute(importRequest);

                     //   continue;
                    }

                    var publishRequest = request as PublishAllXmlRequest;
                    if (publishRequest != null)
                    {
                        bw.ReportProgress(0, string.Format("Publishing {0} to {1}...",solutionName,targetService.Key));
                        targetService.Value.Execute(publishRequest);
                    //    continue;
                    }
                }
            }
        }

        #endregion Methods

        public void ClosingPlugin(PluginCloseInfo info)
        {
            if (info.FormReason != CloseReason.None ||
                info.ToolBoxReason == ToolBoxCloseReason.CloseAll ||
                info.ToolBoxReason == ToolBoxCloseReason.CloseAllExceptActive)
            {
                return;
            }

            info.Cancel = MessageBox.Show(@"Are you sure you want to close this tab?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }

        public string GetCompany()
        {
            return GetType().GetCompany();
        }

        public string GetMyType()
        {
            return GetType().FullName;
        }

        public string GetVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }

        private void ChkExportAsManagedCheckedChanged(object sender, EventArgs e)
        {
            chkConvertToManaged.Enabled = !chkExportAsManaged.Checked;
            chkOverwriteUnmanagedCustomizations.Enabled = chkExportAsManaged.Checked;

            if (chkExportAsManaged.Checked)
            {
                chkConvertToManaged.Checked = false;
            }
        }

        private void lstSourceSolutions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == currentsColumnOrder)
            {
                lstSourceSolutions.Sorting = lstSourceSolutions.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                lstSourceSolutions.ListViewItemSorter = new ListViewItemComparer(e.Column, lstSourceSolutions.Sorting);
            }
            else
            {
                currentsColumnOrder = e.Column;
                lstSourceSolutions.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void TsbLoadSolutionsClick(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs { ActionName = "WhoAmI", Control = this, Parameter = null };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                RetrieveSolutions();
            }
        }

        private void TsbTransfertSolutionClick(object sender, EventArgs e)
        {
            if (lstSourceSolutions.SelectedItems.Count > 0 && targetServices.Any())
            {
                var item = lstSourceSolutions.SelectedItems[0];

                var solutionsToTransfer = new List<string>();
                if (lstSourceSolutions.SelectedItems.Count > 1)
                {
                    // Open dialog to order solutions import
                    foreach (ListViewItem sourceItem in lstSourceSolutions.SelectedItems)
                    {
                        solutionsToTransfer.Add(sourceItem.Text);
                    }

                    var dialog = new SolutionOrderDialog(solutionsToTransfer);
                    if (dialog.ShowDialog(ParentForm) == DialogResult.OK)
                    {
                        solutionsToTransfer = dialog.Solutions;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    solutionsToTransfer.Add(item.Text);
                }

                infoPanel = InformationPanel.GetInformationPanel(this, "Initializing...", 340, 120);

                var requests = new List<OrganizationRequest>();


                foreach (var solution in solutionsToTransfer)
                {
                    var importId = Guid.NewGuid();

                    requests.Add(new ExportSolutionRequest
                    {
                        Managed = chkExportAsManaged.Checked,
                        SolutionName = solution,
                        ExportAutoNumberingSettings = chkAutoNumering.Checked,
                        ExportCalendarSettings = chkCalendar.Checked,
                        ExportCustomizationSettings = chkCustomization.Checked,
                        ExportEmailTrackingSettings = chkEmailTracking.Checked,
                        ExportGeneralSettings = chkGeneral.Checked,
                        ExportIsvConfig = chkIsvConfig.Checked,
                        ExportMarketingSettings = chkMarketing.Checked,
                        ExportOutlookSynchronizationSettings = chkOutlookSynchronization.Checked,
                        ExportRelationshipRoles = chkRelationshipRoles.Checked
                    });

                    requests.Add(new ImportSolutionRequest
                    {
                        ConvertToManaged = chkConvertToManaged.Checked,
                        OverwriteUnmanagedCustomizations = chkOverwriteUnmanagedCustomizations.Checked,
                        PublishWorkflows = chkActivate.Checked,
                        ImportJobId = importId
                    });
                }

                if (!chkExportAsManaged.Checked && chkPublish.Checked)
                {
                    requests.Add(new PublishAllXmlRequest());
                }

                tsbDownloadLogFile.Enabled = false;
                tsbFindMissingDependencies.Enabled = false;
                tsbLoadSolutions.Enabled = false;
                tsbTransfertSolution.Enabled = false;
                btnAddTarget.Enabled = false;
                Cursor = Cursors.WaitCursor;

                using (var worker = new BackgroundWorker())
                {
                    worker.DoWork += WorkerDoWorkExport;
                    worker.ProgressChanged += WorkerProgressChanged;
                    worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
                    worker.WorkerReportsProgress = true;
                    worker.RunWorkerAsync(requests);
                }
            }
            else
            {
                MessageBox.Show("You have to select a source solution and a target organization to continue.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstTargetEnvironments_KeyDown(Object sender, KeyEventArgs e)
        {
            if(lstTargetEnvironments.SelectedItems.Count>0 && e.KeyCode==Keys.Delete)
            {
                foreach (ListViewItem item in lstTargetEnvironments.Items)
                {
                    if (item.Selected)
                        lstTargetEnvironments.Items.Remove(item);
                }

                ReorderTargetServices();
            }
        }

        private void ReorderTargetServices()
        {
            var oldTargetServices = targetServices;
            targetServices = new Dictionary<string, IOrganizationService>();

            foreach (ListViewItem item in lstTargetEnvironments.Items)
            {
                var serviceToAdd = oldTargetServices.First(x => x.Key == item.Text);
                targetServices.Add(serviceToAdd.Key, serviceToAdd.Value);     
            }


        }

        private void tsbFindMissingDependencies_Click(object sender, EventArgs e)
        {
            var child = new MissingComponentsForm();           
            child.ShowMissingComponents(ParentForm, lastTargetService,service,lastImportId);
        }

        private void ToggleWaitMode(bool on)
        {
            if (on)
            {
                Cursor = Cursors.WaitCursor;
                btnAddTarget.Enabled = false;
                tsbTransfertSolution.Enabled = false;
                tsbLoadSolutions.Enabled = false;
                tsbDownloadLogFile.Enabled = false;
                tsbFindMissingDependencies.Enabled = false;
            }
            else
            {
                btnAddTarget.Enabled = true;
                tsbTransfertSolution.Enabled = true;
                tsbLoadSolutions.Enabled = true;
                tsbDownloadLogFile.Enabled = true;
                tsbFindMissingDependencies.Enabled = true;

                Cursor = Cursors.Default;
            }
        }

        private void lstSourceSolutions_KeyDown(Object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && lstSourceSolutions.SelectedItems.Count>0)
            {
                System.Diagnostics.Process.Start(SolutionUrlBase+ $"/tools/solution/edit.aspx?id={lstSourceSolutions.SelectedItems[0].Tag.ToString()}");
            }
        }
    }
}