using DamSim.SolutionTransferTool.AppCode;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.IO;
using System.Windows.Forms;

namespace DamSim.SolutionTransferTool
{
    public partial class ProgressItem : UserControl
    {
        public ProgressItem()
        {
            InitializeComponent();

            pbProgress.Image = ilProgress.Images[0];
            pnlProgress.Visible = false;
        }

        public event EventHandler<DownloadLogEventArgs> LogFileRequested;

        public ConnectionDetail Detail { get; set; }
        public OrganizationRequest Request { get; set; }
        public string Solution { get; set; }
        public byte[] SolutionFile { get; set; }
        public string SolutionVersion { get; set; }
        public Enumerations.RequestType Type { get; set; }

        public void Error(DateTime date)
        {
            Invoke(new Action(() =>
            {
                pbProgress.Image = ilProgress.Images[2];
                llDownloadLog.Visible = Request is ImportSolutionRequest;
                lblProgress.Text += $@" - {date:HH:mm:ss}";
            }));
        }

        public void Start()
        {
            Invoke(new Action(() =>
            {
                pnlProgress.Visible = true;
                lblProgress.Text = string.Format(lblProgress.Tag.ToString(), DateTime.Now.ToString("G"));
                pbProgress.Image = ilProgress.Images[1];
                lblPercentage.Visible = Request is ImportSolutionRequest;
            }));
        }

        public void Success(DateTime date)
        {
            Invoke(new Action(() =>
            {
                pbProgress.Image = ilProgress.Images[3];
                llDownloadLog.Visible = Request is ImportSolutionRequest || Request is ExportSolutionRequest;
                llDownloadLog.Text = Request is ImportSolutionRequest ? "Download log file" : "Download solution";
                lblProgress.Text += $@" - {date:HH:mm:ss}";
                lblPercentage.Visible = false;
            }));
        }

        internal void ReportProgress(double v)
        {
            Invoke(new Action(() =>
            {
                lblPercentage.Text = $@"{v:N0} %";
            }));
        }

        private void llDownloadLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Request is ImportSolutionRequest isr)
            {
                LogFileRequested?.Invoke(this, new DownloadLogEventArgs
                {
                    ImportJobId = isr.ImportJobId,
                    Service = Detail.GetCrmServiceClient()
                });
            }
            else if (Request is ExportSolutionRequest esr)
            {
                var sfd = new SaveFileDialog
                {
                    Filter = @"Zip file (*.zip)|*.zip",
                    FileName = $"{esr.SolutionName}_{SolutionVersion.Replace(".", "_")}{(esr.Managed ? "_managed" : "")}.zip"
                };
                if (sfd.ShowDialog(Parent) == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, this.SolutionFile);
                    MessageBox.Show(Parent, $@"File saved to {sfd.FileName}");
                }
            }
        }

        private void ProgressItem_Load(object sender, EventArgs e)
        {
            lblAction.Text = Type == Enumerations.RequestType.Publish
                ? "Publish customizations"
                : $@"{(Type == Enumerations.RequestType.Export ? "Export" : "Import")} Solution {Solution}";

            lblDirection.Text = Type == Enumerations.RequestType.Publish
                ? $@"On organization {Detail.ConnectionName}"
                : $@"{(Type == Enumerations.RequestType.Export ? "From" : "To")} organization {Detail.ConnectionName}";
        }
    }
}