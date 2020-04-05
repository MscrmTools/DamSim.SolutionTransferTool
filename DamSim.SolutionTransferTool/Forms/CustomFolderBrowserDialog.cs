using System;
using System.IO;
using System.Windows.Forms;

namespace DamSim.SolutionTransferTool.Forms
{
    public partial class CustomFolderBrowserDialog : Form
    {
        public CustomFolderBrowserDialog()
        {
            InitializeComponent();
        }

        public string FolderPath { get; set; }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog
            {
                Description = @"Select the folder where the solutions will be saved",
                ShowNewFolderButton = true
            };

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtFolderPath.Text = fbd.SelectedPath;
                FolderPath = fbd.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderPath.Text))
            {
                MessageBox.Show(this, @"Invalid folder specified!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FolderPath = txtFolderPath.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CustomFolderBrowserDialog_Load(object sender, EventArgs e)
        {
            txtFolderPath.Text = FolderPath;
        }
    }
}