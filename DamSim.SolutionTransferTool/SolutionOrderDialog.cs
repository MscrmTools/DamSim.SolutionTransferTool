using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DamSim.SolutionTransferTool
{
    public partial class SolutionOrderDialog : Form
    {
        public SolutionOrderDialog(List<Entity> solutions)
        {
            InitializeComponent();

            Solutions = solutions;
        }

        public List<Entity> Solutions { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Solutions.Clear();
            for (var i = 0; i < lvSolutions.Items.Count; i++)
            {
                Solutions.Add((Entity)lvSolutions.Items[i].Tag);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SolutionOrderDialog_Load(object sender, EventArgs e)
        {
            foreach (var solution in Solutions)
            {
                var item = new ListViewItem(solution.GetAttributeValue<string>("friendlyname")) { Tag = solution };

                lvSolutions.Items.Add(item);
            }
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