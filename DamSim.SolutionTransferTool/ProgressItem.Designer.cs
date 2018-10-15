namespace DamSim.SolutionTransferTool
{
    partial class ProgressItem
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressItem));
            this.lblAction = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.ilProgress = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.llDownloadLog = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(77, 7);
            this.lblAction.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(235, 32);
            this.lblAction.TabIndex = 1;
            this.lblAction.Tag = "Importing Solution {0}";
            this.lblAction.Text = "Importing Solution";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(77, 42);
            this.lblDirection.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(332, 32);
            this.lblDirection.TabIndex = 2;
            this.lblDirection.Text = "To organization ITL PROD 365";
            // 
            // ilProgress
            // 
            this.ilProgress.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilProgress.ImageStream")));
            this.ilProgress.TransparentColor = System.Drawing.Color.Transparent;
            this.ilProgress.Images.SetKeyName(0, "hourglass.png");
            this.ilProgress.Images.SetKeyName(1, "play-rounded-button.png");
            this.ilProgress.Images.SetKeyName(2, "error.png");
            this.ilProgress.Images.SetKeyName(3, "checked.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbProgress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(73, 118);
            this.panel1.TabIndex = 6;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbProgress.Image = global::DamSim.SolutionTransferTool.Properties.Resources.progressbar;
            this.pbProgress.Location = new System.Drawing.Point(7, 26);
            this.pbProgress.Margin = new System.Windows.Forms.Padding(6);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(59, 59);
            this.pbProgress.TabIndex = 0;
            this.pbProgress.TabStop = false;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.llDownloadLog);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgress.Location = new System.Drawing.Point(73, 81);
            this.pnlProgress.Margin = new System.Windows.Forms.Padding(6);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(730, 37);
            this.pnlProgress.TabIndex = 7;
            // 
            // lblProgress
            // 
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgress.Location = new System.Drawing.Point(0, 0);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.lblProgress.Size = new System.Drawing.Size(730, 37);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Tag = "Started at {0}";
            this.lblProgress.Text = "Progress : 15% (Started at 04/10/2018 12:13:45)";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llDownloadLog
            // 
            this.llDownloadLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llDownloadLog.AutoSize = true;
            this.llDownloadLog.Location = new System.Drawing.Point(571, 8);
            this.llDownloadLog.Name = "llDownloadLog";
            this.llDownloadLog.Size = new System.Drawing.Size(159, 25);
            this.llDownloadLog.TabIndex = 8;
            this.llDownloadLog.TabStop = true;
            this.llDownloadLog.Text = "Download log file";
            this.llDownloadLog.Visible = false;
            this.llDownloadLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDownloadLog_LinkClicked);
            // 
            // ProgressItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.lblAction);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ProgressItem";
            this.Size = new System.Drawing.Size(803, 118);
            this.Load += new System.EventHandler(this.ProgressItem_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ImageList ilProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.LinkLabel llDownloadLog;
    }
}
