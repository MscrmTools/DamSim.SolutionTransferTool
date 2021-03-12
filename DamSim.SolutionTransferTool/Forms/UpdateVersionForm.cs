using System;
using System.Windows.Forms;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class UpdateVersionForm : Form
    {
        public UpdateVersionForm(string oldVersion, string solutionName)
        {
            InitializeComponent();

            label1.Text = string.Format(label1.Text, solutionName);
            txtCurrentVersion.Text = oldVersion;
            txtNewVersion.Text = oldVersion;
        }

        public string NewVersion => txtNewVersion.Text;

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!Version.TryParse(txtNewVersion.Text, out _))
            {
                MessageBox.Show(this, @"Invalid version", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}