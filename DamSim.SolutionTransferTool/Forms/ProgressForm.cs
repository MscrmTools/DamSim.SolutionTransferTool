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

        public List<ProgressItem> Items { get; set; }

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
    }
}