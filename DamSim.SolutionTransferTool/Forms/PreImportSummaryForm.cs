using DamSim.SolutionTransferTool.AppCode;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class PreImportSummaryForm : Form
    {
        private Settings currentSettings;

        public PreImportSummaryForm(Settings importSettings, List<Entity> solutions)
        {
            InitializeComponent();

            scCheckMissingDeps.Checked = importSettings.CheckForMissingDependencies;
            scConvertToManaged.Checked = importSettings.ConvertToManaged;
            scImportAsManaged.Checked = importSettings.Managed;
            scOverwriteUnmanaged.Checked = importSettings.OverwriteUnmanagedCustomizations;
            scPublishWorkflows.Checked = importSettings.PublishWorkflows;
            scSkipProductUpdateDeps.Checked = importSettings.SkipProductUpdateDependencies;
            ddImportMode.EnumType = typeof(ImportModeEnum);
            ddImportMode.Value = importSettings.ImportMode;

            if (solutions != null && solutions.Count > 0)
            {
                foreach (var solution in solutions)
                {
                    lvSolutions.Items.Add(new ListViewItem
                    {
                        Text = solution.GetAttributeValue<string>("friendlyname"),
                        Tag = solution,
                        Checked = true,
                        SubItems =
                        {
                            solution.GetAttributeValue<string>("uniquename"),
                            solution.GetAttributeValue<string>("version"),
                            solution.GetAttributeValue<string>("newversion")
                        }
                    });
                }
            }

            currentSettings = importSettings;
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            if (!scSkipNewVersionNumber.Checked)
            {
                foreach (ListViewItem item in lvSolutions.Items)
                {
                    if (item.Checked)
                    {
                        ((Entity)item.Tag)["updateversion"] = true;
                    }

                    ((Entity)item.Tag)["sortorder"] = item.Index;
                }
            }

            currentSettings.CheckForMissingDependencies = scCheckMissingDeps.Checked;
            currentSettings.ConvertToManaged = scConvertToManaged.Checked;
            currentSettings.Managed = scImportAsManaged.Checked;
            currentSettings.OverwriteUnmanagedCustomizations = scOverwriteUnmanaged.Checked;
            currentSettings.PublishWorkflows = scPublishWorkflows.Checked;
            currentSettings.SkipProductUpdateDependencies = scSkipProductUpdateDeps.Checked;
            currentSettings.ImportMode = (ImportModeEnum)ddImportMode.Value;

            currentSettings.ShowPreImportSummary = !scDoNotShow.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void scImportAsManaged_OnCheckedChanged(object sender, System.EventArgs e)
        {
            var isManaged = scImportAsManaged.Checked;

            pnlConvertToManaged.Visible = isManaged;
            pnlImportMode.Visible = isManaged;
            pnlOverwriteUnmanaged.Visible = isManaged;
            pnlPublishWorkflows.Visible = !isManaged;
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            if (lvSolutions.SelectedItems[0].Index == lvSolutions.Items.Count - 1)
                return;

            var currentIndex = lvSolutions.SelectedItems[0].Index;
            var item = lvSolutions.Items[currentIndex];
            lvSolutions.Items.RemoveAt(currentIndex);
            lvSolutions.Items.Insert(currentIndex + 1, item);
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            if (lvSolutions.SelectedItems[0].Index == 0)
                return;

            var currentIndex = lvSolutions.SelectedItems[0].Index;
            var item = lvSolutions.Items[currentIndex];
            lvSolutions.Items.RemoveAt(currentIndex);
            lvSolutions.Items.Insert(currentIndex - 1, item);
        }
    }
}