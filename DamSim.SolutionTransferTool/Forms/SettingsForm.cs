using DamSim.SolutionTransferTool.AppCode;
using WeifenLuo.WinFormsUI.Docking;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class SettingsForm : DockContent
    {
        public SettingsForm(bool isFromOneShot = false)
        {
            InitializeComponent();

            pnlBottom.Visible = isFromOneShot;
            pnlReviewWarning.Visible = !isFromOneShot;
        }

        public Settings Settings
        {
            set => SettingsPropertyPanel.SelectedObject = value;
            get => (Settings)SettingsPropertyPanel.SelectedObject;
        }
    }
}