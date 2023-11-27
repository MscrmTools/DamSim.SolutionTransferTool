using Microsoft.Crm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DamSim.SolutionTransferTool
{
    public partial class MissingComponentsControl : UserControl
    {
        private int orderColumn = -1;

        public MissingComponentsControl()
        {
            InitializeComponent();
        }

        public event EventHandler OnClose;

        public MissingComponent[] Components { get; internal set; }
        public Dictionary<int, string> ComponentsTypes { get; internal set; }
        public bool IsMaximized { get; set; }

        public void DisplayCentered()
        {
            btnMaximize.Text = "Maximize";
            Width = Convert.ToInt32(Parent.Width * 0.7);
            Height = Convert.ToInt32(Parent.Height * 0.7);
            Location = new Point(Parent.Width / 2 - Width / 2, Parent.Height / 2 - Height / 2);
            IsMaximized = false;
        }

        public void ShowData()
        {
            lvMissingComponents.Items.Clear();
            var lvis = new List<ListViewItem>();
            foreach (var c in Components)
            {
                if (lvis.Any(l => ((MissingComponent)l.Tag).RequiredComponent.SchemaName == c.RequiredComponent.SchemaName && ((MissingComponent)l.Tag).RequiredComponent.Type == c.RequiredComponent.Type && ((MissingComponent)l.Tag).RequiredComponent.Id == c.RequiredComponent.Id)) continue;

                var requiredComponentType = ComponentsTypes.ContainsKey(c.RequiredComponent.Type) ? ComponentsTypes[c.RequiredComponent.Type] : "(Unknown)";

                var lvi = new ListViewItem($"{c.RequiredComponent.DisplayName}{(c.RequiredComponent.ParentDisplayName.Length > 0 ? " (" + c.RequiredComponent.ParentDisplayName + ")" : "")}") { Tag = c };
                lvi.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem{Text = c.RequiredComponent.SchemaName },
                    new ListViewItem.ListViewSubItem{Text = c.RequiredComponent.Id.ToString() },
                    new ListViewItem.ListViewSubItem{Text = requiredComponentType },
                    new ListViewItem.ListViewSubItem{Text = c.RequiredComponent.Solution },

                    //new ListViewItem.ListViewSubItem{Text = c.DependentComponent.DisplayName },
                    //new ListViewItem.ListViewSubItem{Text = c.DependentComponent.SchemaName },
                    //new ListViewItem.ListViewSubItem{Text = c.DependentComponent.Id.ToString() },
                    //new ListViewItem.ListViewSubItem{Text = c.DependentComponent.Type.ToString() },
                    //new ListViewItem.ListViewSubItem{Text = c.DependentComponent.Solution },
                });

                lvis.Add(lvi);
            }

            lvMissingComponents.Items.AddRange(lvis.ToArray());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke(this, new EventArgs());
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "CSV file (*.csv)|*.csv" })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.Default))
                    {
                        writer.WriteLine("Required Component,Schema Name,Id,Type,Solution");
                        foreach (ListViewItem item in lvMissingComponents.Items)
                        {
                            writer.WriteLine($"{item.SubItems[0].Text},{item.SubItems[1].Text},{item.SubItems[2].Text},{item.SubItems[3].Text},{item.SubItems[4].Text}");
                        }
                    }

                    if (DialogResult.Yes == MessageBox.Show(this, $"File successfully saved to {sfd.FileName}\n\nDo you want to open the file?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        Process.Start(sfd.FileName);
                    }
                }
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (btnMaximize.Text == "Maximize")
            {
                btnMaximize.Text = "Reduce";
                Width = Parent.Width;
                Height = Parent.Height;
                Location = new Point(0, 0);
                IsMaximized = true;
            }
            else
            {
                DisplayCentered();
            }
        }

        private void lvMissingComponents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == orderColumn)
            {
                lvMissingComponents.ListViewItemSorter = new ListViewItemComparer(e.Column, lvMissingComponents.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
            }
            else
            {
                orderColumn = e.Column;
                lvMissingComponents.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
            lvMissingComponents.Sort();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}