using System.Windows.Forms;

namespace DamSim.SolutionTransferTool
{
    partial class SolutionTransferTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionTransferTool));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFindMissingDependencies = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dpMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.tsbLoadSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsbTransfertSolution = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbDownload = new System.Windows.Forms.ToolStripButton();
            this.tsbSwitchOrgs = new System.Windows.Forms.ToolStripButton();
            this.tsbExportSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadSolutions,
            this.toolStripSeparator2,
            this.tsbTransfertSolution,
            this.tsbCancel,
            this.tsbDownload,
            this.toolStripSeparator4,
            this.tsbSwitchOrgs,
            this.toolStripSeparator3,
            this.tsbFindMissingDependencies,
            this.toolStripSeparator1,
            this.tsbExportSolutions});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1440, 46);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "tsMain";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 46);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbFindMissingDependencies
            // 
            this.tsbFindMissingDependencies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFindMissingDependencies.Enabled = false;
            this.tsbFindMissingDependencies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindMissingDependencies.Name = "tsbFindMissingDependencies";
            this.tsbFindMissingDependencies.Size = new System.Drawing.Size(232, 41);
            this.tsbFindMissingDependencies.Text = "Find Missing Dependencies";
            this.tsbFindMissingDependencies.ToolTipText = "Use this button to detect what component were missing for the previous failed sol" +
    "ution import";
            this.tsbFindMissingDependencies.Click += new System.EventHandler(this.tsbFindMissingDependencies_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DamSimIcon.png");
            // 
            // dpMain
            // 
            this.dpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpMain.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dpMain.Location = new System.Drawing.Point(0, 55);
            this.dpMain.Margin = new System.Windows.Forms.Padding(5);
            this.dpMain.Name = "dpMain";
            this.dpMain.Size = new System.Drawing.Size(1440, 1199);
            this.dpMain.TabIndex = 1;
            // 
            // tsbLoadSolutions
            // 
            this.tsbLoadSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadSolutions.Image")));
            this.tsbLoadSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadSolutions.Name = "tsbLoadSolutions";
            this.tsbLoadSolutions.Size = new System.Drawing.Size(150, 41);
            this.tsbLoadSolutions.Text = "Load Solutions";
            this.tsbLoadSolutions.Click += new System.EventHandler(this.TsbLoadSolutionsClick);
            // 
            // tsbTransfertSolution
            // 
            this.tsbTransfertSolution.Image = ((System.Drawing.Image)(resources.GetObject("tsbTransfertSolution.Image")));
            this.tsbTransfertSolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransfertSolution.Name = "tsbTransfertSolution";
            this.tsbTransfertSolution.Size = new System.Drawing.Size(162, 41);
            this.tsbTransfertSolution.Text = "Transfer solution";
            this.tsbTransfertSolution.Click += new System.EventHandler(this.TsbTransfertSolutionClick);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Image = global::DamSim.SolutionTransferTool.Properties.Resources.icons8_cancel;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(83, 41);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Visible = false;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // tsbDownload
            // 
            this.tsbDownload.Image = global::DamSim.SolutionTransferTool.Properties.Resources.inbox_download;
            this.tsbDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownload.Name = "tsbDownload";
            this.tsbDownload.Size = new System.Drawing.Size(183, 41);
            this.tsbDownload.Text = "Download solution";
            this.tsbDownload.Click += new System.EventHandler(this.tsbDownload_Click);
            // 
            // tsbSwitchOrgs
            // 
            this.tsbSwitchOrgs.Image = global::DamSim.SolutionTransferTool.Properties.Resources.arrow_switch;
            this.tsbSwitchOrgs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwitchOrgs.Name = "tsbSwitchOrgs";
            this.tsbSwitchOrgs.Size = new System.Drawing.Size(195, 41);
            this.tsbSwitchOrgs.Text = "Switch organizations";
            this.tsbSwitchOrgs.ToolTipText = "Switch source and target organizations";
            this.tsbSwitchOrgs.Click += new System.EventHandler(this.tsbSwitchOrgs_Click);
            // 
            // tsbExportSolutions
            // 
            this.tsbExportSolutions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExportSolutions.Enabled = false;
            this.tsbExportSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportSolutions.Image")));
            this.tsbExportSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportSolutions.Name = "tsbExportSolutions";
            this.tsbExportSolutions.Size = new System.Drawing.Size(251, 41);
            this.tsbExportSolutions.Text = "Download exported solutions";
            this.tsbExportSolutions.Click += new System.EventHandler(this.tsbExportSolutions_Click);
            // 
            // SolutionTransferTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dpMain);
            this.Controls.Add(this.tsMain);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SolutionTransferTool";
            this.Size = new System.Drawing.Size(1200, 1045);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

 
        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsbLoadSolutions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbTransfertSolution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsbFindMissingDependencies;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbSwitchOrgs;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dpMain;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbExportSolutions;
        private ToolStripButton tsbDownload;
        private ToolStripButton tsbCancel;
    }
}
