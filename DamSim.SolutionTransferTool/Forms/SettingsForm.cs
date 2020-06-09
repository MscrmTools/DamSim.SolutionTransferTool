using DamSim.SolutionTransferTool.AppCode;
using WeifenLuo.WinFormsUI.Docking;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class SettingsForm : DockContent
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public Settings Settings
        {
            set => SettingsPropertyPanel.SelectedObject = value;
        }
    }
}