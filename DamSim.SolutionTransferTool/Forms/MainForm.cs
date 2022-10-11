using DamSim.SolutionTransferTool.AppCode;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class MainForm : DockContent
    {
        private int currentsColumnOrder;
        private string solutionUrlBase;

        public MainForm()
        {
            InitializeComponent();
        }

        public event EventHandler<TargetOrganizationsEventArgs> TargetOrganizationRemoved;

        public event EventHandler TargetOrganizationRequested;

        public List<Entity> SelectedSolutions => lstSourceSolutions.SelectedItems.Cast<ListViewItem>()
            .Select(i => (Entity)i.Tag).ToList();

        public void DisplaySolutions(List<Entity> solutions)
        {
            lstSourceSolutions.Items.Clear();

            if (solutions == null)
            {
                return;
            }

            foreach (var solution in solutions)
            {
                var item = new ListViewItem
                {
                    Tag = solution,
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

        public void DisplayTargetOrganizations(List<ConnectionDetail> details)
        {
            lstTargetEnvironments.Clear();
            lstTargetEnvironments.Items.AddRange(details
                .Select(cd => new ListViewItem(cd.ConnectionName) { Tag = cd }).ToArray());
        }

        public void SetSourceOrganization(ConnectionDetail detail)
        {
            if (detail == null)
            {
                lblSource.Text = @"Not selected yet (use XrmToolBox connect button)";
                lblSource.ForeColor = Color.Red;
                return;
            }

            solutionUrlBase = detail.WebApplicationUrl;

            lblSource.Text = detail.ConnectionName;
            lblSource.ForeColor = Color.Green;
        }

        public void SwitchSourceAndTarget(ConnectionDetail source, ConnectionDetail target)
        {
            if (lstTargetEnvironments.SelectedItems.Count > 1)
            {
                MessageBox.Show(this,
                    @"Switch can only be performed when no more than one target organization is defined",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var tempDetail = source;
            DisplayTargetOrganizations(new List<ConnectionDetail> { tempDetail });

            SetSourceOrganization(target);
        }

        public void UpdateSolutionVersion(Entity solution)
        {
            var item = lstSourceSolutions.Items.Cast<ListViewItem>()
                .FirstOrDefault(x => ((Entity)x.Tag).Id == solution.Id);

            if (item == null) return;
            item.SubItems[2].Text = solution.GetAttributeValue<string>("version");
        }

        private void btnAddTarget_Click(object sender, EventArgs e)
        {
            TargetOrganizationRequested?.Invoke(this, new EventArgs());
        }

        private void lstSourceSolutions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != currentsColumnOrder)
            {
                currentsColumnOrder = e.Column;
                lstSourceSolutions.Sorting = SortOrder.Descending;
            }

            lstSourceSolutions.Sorting = lstSourceSolutions.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lstSourceSolutions.ListViewItemSorter = new ListViewItemComparer(e.Column, lstSourceSolutions.Sorting);

            lstSourceSolutions.Sort();
        }

        private void lstSourceSolutions_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSourceSolutions.SelectedItems.Count > 0)
            {
                Process.Start(solutionUrlBase + $"/tools/solution/edit.aspx?id={lstSourceSolutions.SelectedItems[0].Tag}");
            }
        }

        private void lstTargetEnvironments_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstTargetEnvironments.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem item in lstTargetEnvironments.Items)
                {
                    if (item.Selected)
                    {
                        lstTargetEnvironments.Items.Remove(item);
                    }
                }

                TargetOrganizationRemoved?.Invoke(this, new TargetOrganizationsEventArgs
                {
                    TargetOrganizations =
                        lstTargetEnvironments.Items.Cast<ListViewItem>().Select(i => (ConnectionDetail)i.Tag).ToList()
                });
            }
        }
    }
}