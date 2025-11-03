using DamSim.SolutionTransferTool.AppCode;
using DamSim.SolutionTransferTool.Properties;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class MainForm : DockContent
    {
        private int currentsColumnOrder;
        private ConnectionDetail currentSourceConnectionDetail;
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

                foreach (var column in lstSourceSolutions.Columns.Cast<ColumnHeader>().Where(c => c.Tag is ConnectionDetail))
                {
                    item.SubItems.Add("");
                }

                item.SubItems.Add(solution.GetAttributeValue<DateTime>("installedon").ToString("yy-MM-dd HH:mm"));
                item.SubItems.Add(solution.GetAttributeValue<EntityReference>("publisherid").Name);
                item.SubItems.Add(solution.GetAttributeValue<String>("description"));
                lstSourceSolutions.Items.Add(item);
            }
        }

        public void DisplayTargetOrganizations(List<ConnectionDetail> details)
        {
            for (var i = gbTargetOrgs.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = gbTargetOrgs.Controls[i];
                if (ctrl is Button b && b.Tag is ConnectionDetail)
                {
                    gbTargetOrgs.Controls.RemoveAt(i);
                    ctrl.Dispose();
                }
            }

            foreach (var d in details)
            {
                if (gbTargetOrgs.Controls.OfType<Button>().Any(b => b.Tag == d))
                {
                    continue;
                }

                var btn = new Button
                {
                    Text = d.ConnectionName,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Image = Resources.delete,
                    Dock = DockStyle.Left,
                    Tag = d
                };

                var size = TextRenderer.MeasureText(d.ConnectionName, btn.Font);

                btn.Width = size.Width + 30;
                btn.Click += BtnEnv_Click;

                gbTargetOrgs.Controls.Add(btn);
                gbTargetOrgs.Controls.SetChildIndex(btn, 0);
            }

            //lstTargetEnvironments.Clear();
            //lstTargetEnvironments.Items.AddRange(details
            //    .Select(cd => new ListViewItem(cd.ConnectionName) { Tag = cd }).ToArray());
        }

        public void SetSourceOrganization(ConnectionDetail detail)
        {
            if (detail == null)
            {
                lblSource.Text = @"Not selected yet (use XrmToolBox connect button)";
                lblSource.ForeColor = Color.Red;
                return;
            }

            currentSourceConnectionDetail = detail;
            solutionUrlBase = detail.WebApplicationUrl;

            lblSource.Text = detail.ConnectionName;
            lblSource.ForeColor = Color.Green;
        }

        public void SetTargetSolutionVersion(Entity solution, ConnectionDetail detail)
        {
            var column = lstSourceSolutions.Columns.Cast<ColumnHeader>().FirstOrDefault(c => c.Tag == detail);
            if (column == null) return;
            var item = lstSourceSolutions.Items.Cast<ListViewItem>()
                .FirstOrDefault(x => ((Entity)x.Tag).Id == solution.Id);
            if (item == null) return;
            var subItem = item.SubItems.Cast<ListViewItem.ListViewSubItem>().ElementAtOrDefault(column.Index);
            if (subItem == null) return;

            subItem.Text = solution.GetAttributeValue<string>("version");

            if (subItem.Text == item.SubItems[2].Text)
            {
                subItem.BackColor = Color.LightGreen;
                subItem.ForeColor = Color.DarkGreen;
            }
            else
            {
                subItem.BackColor = SystemColors.Info;
                subItem.ForeColor = Color.DarkRed;
            }
        }

        public void SwitchSourceAndTarget(ConnectionDetail source, ConnectionDetail target)
        {
            if (gbTargetOrgs.Controls.Count > 2)
            {
                MessageBox.Show(this,
                    @"Switch can only be performed when no more than one target organization is defined",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var tempDetail = source;
            lstSourceSolutions.Columns.RemoveAt(3);
            DisplayTargetOrganizations(new List<ConnectionDetail> { tempDetail });

            SetSourceOrganization(target);

            MainForm_Resize(this, new EventArgs());
        }

        public void UpdateSolutionVersion(Entity solution)
        {
            var item = lstSourceSolutions.Items.Cast<ListViewItem>()
                .FirstOrDefault(x => ((Entity)x.Tag).Id == solution.Id);

            if (item == null) return;
            item.SubItems[2].Text = solution.GetAttributeValue<string>("version");

            foreach (var column in lstSourceSolutions.Columns.Cast<ColumnHeader>().Where(c => c.Tag is ConnectionDetail))
            {
                var subItem = item.SubItems.Cast<ListViewItem.ListViewSubItem>().ElementAtOrDefault(column.Index);
                if (subItem == null) continue;
                if (subItem.Text == item.SubItems[2].Text)
                {
                    subItem.BackColor = Color.LightGreen;
                    subItem.ForeColor = Color.DarkGreen;
                }
                else
                {
                    subItem.BackColor = SystemColors.Info;
                    subItem.ForeColor = Color.DarkRed;
                }
            }
        }

        internal void DisplayTargetOrganizationsSolutions(List<ConnectionDetail> connectionDetails, SolutionTransferTool parent)
        {
            var solutionUniqueNames = lstSourceSolutions.Items.Cast<ListViewItem>()
                .Select(i => ((Entity)i.Tag).GetAttributeValue<string>("uniquename")).ToList();

            foreach (var cd in connectionDetails)
            {
                parent.WorkAsync(new WorkAsyncInfo
                {
                    Message = null,
                    Work = (w, e) =>
                    {
                        var svc = cd.GetCrmServiceClient();
                        var query = new QueryExpression("solution")
                        {
                            ColumnSet = new ColumnSet("uniquename", "version"),
                            Criteria = new FilterExpression
                            {
                                Conditions =
                                {
                                    new ConditionExpression("uniquename", Microsoft.Xrm.Sdk.Query.ConditionOperator.In, solutionUniqueNames.ToArray())
                                }
                            }
                        };
                        var solutions = svc.RetrieveMultiple(query).Entities;
                        e.Result = new Tuple<ConnectionDetail, List<Entity>>(cd, solutions.ToList());
                    },
                    PostWorkCallBack = (e) =>
                    {
                        var result = (Tuple<ConnectionDetail, List<Entity>>)e.Result;
                        var tcd = result.Item1;
                        var solutions = result.Item2;
                        bool columnAdded = false;

                        var column = lstSourceSolutions.Columns.Cast<ColumnHeader>().FirstOrDefault(c => c.Text == tcd.ConnectionName);
                        if (column == null)
                        {
                            var colum = new ColumnHeader
                            {
                                Text = tcd.ConnectionName,
                                Tag = tcd
                            };

                            var sourceVersionColumnIndex = lstSourceSolutions.Columns.Cast<ColumnHeader>().First(c => c.Text == "Version").Index;
                            var targetIndex = sourceVersionColumnIndex;
                            do
                            {
                                targetIndex++;
                            }
                            while (lstSourceSolutions.Columns[targetIndex].Text != "Installed on");

                            lstSourceSolutions.Columns.Insert(targetIndex, colum);
                            column = lstSourceSolutions.Columns.Cast<ColumnHeader>().First(c => c.Text == tcd.ConnectionName);
                            columnAdded = true;
                        }

                        foreach (ListViewItem item in lstSourceSolutions.Items)
                        {
                            item.UseItemStyleForSubItems = false;
                            var solution = (Entity)item.Tag;
                            var targetSolution = solutions.FirstOrDefault(s => s.GetAttributeValue<string>("uniquename") == solution.GetAttributeValue<string>("uniquename"));

                            var subItem = item.SubItems.Cast<ListViewItem.ListViewSubItem>().ElementAtOrDefault(column.Index);
                            if (subItem == null || columnAdded)
                            {
                                subItem = new ListViewItem.ListViewSubItem();
                                item.SubItems.Insert(column.Index, subItem);
                            }
                            if (targetSolution != null)
                            {
                                subItem.Text = targetSolution.GetAttributeValue<string>("version");

                                if (subItem.Text == item.SubItems[2].Text)
                                {
                                    subItem.BackColor = Color.LightGreen;
                                    subItem.ForeColor = Color.DarkGreen;
                                }
                                else
                                {
                                    subItem.BackColor = SystemColors.Info;
                                    subItem.ForeColor = Color.DarkRed;
                                }
                            }
                            else
                            {
                                subItem.BackColor = Color.LightGray;
                                subItem.ForeColor = Color.Black;
                                subItem.Text = "-";
                            }
                        }
                        lstSourceSolutions.AutoResizeColumn(column.Index, ColumnHeaderAutoResizeStyle.ColumnContent);
                        lstSourceSolutions.AutoResizeColumn(column.Index, ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                });
            }
        }

        private void btnAddTarget_Click(object sender, EventArgs e)
        {
            TargetOrganizationRequested?.Invoke(this, new EventArgs());
        }

        private void BtnEnv_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag != null)
            {
                var column = lstSourceSolutions.Columns.Cast<ColumnHeader>().FirstOrDefault(c => c.Tag == ((Button)sender).Tag);
                if (column != null)
                {
                    var index = column.Index;

                    var installedOnColumn = lstSourceSolutions.Columns.Cast<ColumnHeader>().First(c => c.Text == "Installed on");

                    lstSourceSolutions.Columns.Remove(column);

                    foreach (ListViewItem item in lstSourceSolutions.Items)
                    {
                        item.SubItems.RemoveAt(index);
                    }

                    SetColors();
                }
            }

            TargetOrganizationRemoved?.Invoke(this, new TargetOrganizationsEventArgs
            {
                TargetOrganizations = scOrganizations.Panel2.Controls.OfType<Button>().Select(b => (ConnectionDetail)b.Tag).ToList()
            });
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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            var size = TextRenderer.MeasureText(lblSource.Text, lblSource.Font);

            scOrganizations.SplitterDistance = size.Width + 20;
        }

        private void SetColors()
        {
            foreach (ListViewItem item in lstSourceSolutions.Items)
            {
                item.UseItemStyleForSubItems = false;
                var solution = (Entity)item.Tag;

                foreach (var column in lstSourceSolutions.Columns.Cast<ColumnHeader>().Where(c => c.Tag is ConnectionDetail))
                {
                    var subItem = item.SubItems.Cast<ListViewItem.ListViewSubItem>().ElementAtOrDefault(column.Index);

                    if (subItem.Text == "-")
                    {
                        subItem.BackColor = Color.LightGray;
                        subItem.ForeColor = Color.Black;
                        subItem.Text = "-";
                    }
                    else if (subItem.Text == item.SubItems[2].Text)
                    {
                        subItem.BackColor = Color.LightGreen;
                        subItem.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        subItem.BackColor = SystemColors.Info;
                        subItem.ForeColor = Color.DarkRed;
                    }
                }
            }
        }
    }
}