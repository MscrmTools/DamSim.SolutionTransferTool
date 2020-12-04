using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class ProgressForm : DockContent

    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public event EventHandler OnRetry;

        public List<ProgressItem> Items { get; set; }

        public void ShowRetryButton(ProgressItem failingItem)
        {
            Invoke(new Action(() =>
            {
                var index = pnlProgress.Controls.IndexOf(failingItem);
                pnlProgress.Controls.Add(pnlRetry);
                pnlProgress.Controls.SetChildIndex(pnlRetry, index);
                pnlRetry.Visible = true;
            }));
        }

        public void Start()
        {
            pnlNew.Visible = false;
            pnlProgress.Visible = true;
            pnlProgress.Controls.Clear();

            for (var i = Items.Count - 1; i >= 0; i--)
            {
                Items[i].Dock = DockStyle.Top;
                pnlProgress.Controls.Add(Items[i]);
            }
        }

        private void btnRetry_Click(object sender, System.EventArgs e)
        {
            OnRetry?.Invoke(this, new EventArgs());
            pnlRetry.Visible = false;
        }
    }
}