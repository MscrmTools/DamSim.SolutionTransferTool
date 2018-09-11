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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadSolutions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTransfertSolution = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDownloadLogFile = new System.Windows.Forms.ToolStripButton();
            this.tsbFindMissingDependencies = new System.Windows.Forms.ToolStripButton();
            this.grpSourceSolution = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lstSourceSolutions = new System.Windows.Forms.ListView();
            this.uniquename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.friendlyname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installedon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddTarget = new System.Windows.Forms.Button();
            this.grpTargetSelection = new System.Windows.Forms.GroupBox();
            this.lstTargetEnvironments = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkIsvConfig = new System.Windows.Forms.CheckBox();
            this.chkRelationshipRoles = new System.Windows.Forms.CheckBox();
            this.chkOutlookSynchronization = new System.Windows.Forms.CheckBox();
            this.chkGeneral = new System.Windows.Forms.CheckBox();
            this.chkMarketing = new System.Windows.Forms.CheckBox();
            this.chkEmailTracking = new System.Windows.Forms.CheckBox();
            this.chkCustomization = new System.Windows.Forms.CheckBox();
            this.chkAutoNumering = new System.Windows.Forms.CheckBox();
            this.chkCalendar = new System.Windows.Forms.CheckBox();
            this.chkExportAsManaged = new System.Windows.Forms.CheckBox();
            this.chkConvertToManaged = new System.Windows.Forms.CheckBox();
            this.chkOverwriteUnmanagedCustomizations = new System.Windows.Forms.CheckBox();
            this.chkActivate = new System.Windows.Forms.CheckBox();
            this.chkPublish = new System.Windows.Forms.CheckBox();
            this.chkSales = new System.Windows.Forms.CheckBox();
            this.chkExternalApplications = new System.Windows.Forms.CheckBox();
            this.chkStageForUpgrade = new System.Windows.Forms.CheckBox();
            this.chkSkipProductUpdateDependencies = new System.Windows.Forms.CheckBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSwitchOrgs = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.grpSourceSolution.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpTargetSelection.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbOptions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1,
            this.tsbLoadSolutions,
            this.toolStripSeparator2,
            this.tsbTransfertSolution,
            this.toolStripSeparator4,
            this.tsbSwitchOrgs,
            this.toolStripSeparator3,
            this.tsbDownloadLogFile,
            this.tsbFindMissingDependencies});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1467, 37);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 34);
            this.btnClose.Text = "Close this tool";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbLoadSolutions
            // 
            this.tsbLoadSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadSolutions.Image")));
            this.tsbLoadSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadSolutions.Name = "tsbLoadSolutions";
            this.tsbLoadSolutions.Size = new System.Drawing.Size(181, 34);
            this.tsbLoadSolutions.Text = "Load Solutions";
            this.tsbLoadSolutions.Click += new System.EventHandler(this.TsbLoadSolutionsClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbTransfertSolution
            // 
            this.tsbTransfertSolution.Image = ((System.Drawing.Image)(resources.GetObject("tsbTransfertSolution.Image")));
            this.tsbTransfertSolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransfertSolution.Name = "tsbTransfertSolution";
            this.tsbTransfertSolution.Size = new System.Drawing.Size(198, 34);
            this.tsbTransfertSolution.Text = "Transfer solution";
            this.tsbTransfertSolution.Click += new System.EventHandler(this.TsbTransfertSolutionClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbDownloadLogFile
            // 
            this.tsbDownloadLogFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDownloadLogFile.Enabled = false;
            this.tsbDownloadLogFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbDownloadLogFile.Image")));
            this.tsbDownloadLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownloadLogFile.Name = "tsbDownloadLogFile";
            this.tsbDownloadLogFile.Size = new System.Drawing.Size(188, 34);
            this.tsbDownloadLogFile.Text = "Download Log File";
            this.tsbDownloadLogFile.ToolTipText = "This button allows you to donwload the log file from the last solution imported w" +
    "ith errors";
            this.tsbDownloadLogFile.Click += new System.EventHandler(this.BtnDownloadLogClick);
            // 
            // tsbFindMissingDependencies
            // 
            this.tsbFindMissingDependencies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFindMissingDependencies.Enabled = false;
            this.tsbFindMissingDependencies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindMissingDependencies.Name = "tsbFindMissingDependencies";
            this.tsbFindMissingDependencies.Size = new System.Drawing.Size(270, 34);
            this.tsbFindMissingDependencies.Text = "Find Missing Dependencies";
            this.tsbFindMissingDependencies.ToolTipText = "Use this button to detect what component were missing for the previous failed sol" +
    "ution import";
            this.tsbFindMissingDependencies.Click += new System.EventHandler(this.tsbFindMissingDependencies_Click);
            // 
            // grpSourceSolution
            // 
            this.grpSourceSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSourceSolution.Controls.Add(this.panel1);
            this.grpSourceSolution.Controls.Add(this.label1);
            this.grpSourceSolution.Controls.Add(this.lblSource);
            this.grpSourceSolution.Controls.Add(this.lstSourceSolutions);
            this.grpSourceSolution.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpSourceSolution.Location = new System.Drawing.Point(6, 50);
            this.grpSourceSolution.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpSourceSolution.Name = "grpSourceSolution";
            this.grpSourceSolution.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpSourceSolution.Size = new System.Drawing.Size(1456, 600);
            this.grpSourceSolution.TabIndex = 1;
            this.grpSourceSolution.TabStop = false;
            this.grpSourceSolution.Text = "Solutions";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(11, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1427, 41);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(48, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(621, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Click on \"Load Solutions\" to display and select solution to transfer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 30);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(6, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source environnement";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSource.ForeColor = System.Drawing.Color.Red;
            this.lblSource.Location = new System.Drawing.Point(249, 90);
            this.lblSource.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(154, 28);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Not selected yet";
            // 
            // lstSourceSolutions
            // 
            this.lstSourceSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSourceSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uniquename,
            this.friendlyname,
            this.version,
            this.installedon,
            this.publisher,
            this.description});
            this.lstSourceSolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lstSourceSolutions.FullRowSelect = true;
            this.lstSourceSolutions.HideSelection = false;
            this.lstSourceSolutions.Location = new System.Drawing.Point(11, 120);
            this.lstSourceSolutions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstSourceSolutions.Name = "lstSourceSolutions";
            this.lstSourceSolutions.Size = new System.Drawing.Size(1425, 460);
            this.lstSourceSolutions.TabIndex = 2;
            this.lstSourceSolutions.UseCompatibleStateImageBehavior = false;
            this.lstSourceSolutions.View = System.Windows.Forms.View.Details;
            this.lstSourceSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstSourceSolutions_ColumnClick);
            this.lstSourceSolutions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSourceSolutions_KeyDown);
            // 
            // uniquename
            // 
            this.uniquename.Text = "Name";
            this.uniquename.Width = 145;
            // 
            // friendlyname
            // 
            this.friendlyname.Text = "Friendly name";
            this.friendlyname.Width = 145;
            // 
            // version
            // 
            this.version.Text = "Version";
            this.version.Width = 80;
            // 
            // installedon
            // 
            this.installedon.Text = "Installed on";
            this.installedon.Width = 95;
            // 
            // publisher
            // 
            this.publisher.Text = "Publisher";
            this.publisher.Width = 120;
            // 
            // description
            // 
            this.description.Text = "Description";
            this.description.Width = 200;
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddTarget.Location = new System.Drawing.Point(11, 90);
            this.btnAddTarget.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(204, 46);
            this.btnAddTarget.TabIndex = 3;
            this.btnAddTarget.Text = "Add target";
            this.btnAddTarget.UseVisualStyleBackColor = true;
            this.btnAddTarget.Click += new System.EventHandler(this.BtnSelectTargetClick);
            // 
            // grpTargetSelection
            // 
            this.grpTargetSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTargetSelection.Controls.Add(this.lstTargetEnvironments);
            this.grpTargetSelection.Controls.Add(this.panel2);
            this.grpTargetSelection.Controls.Add(this.btnAddTarget);
            this.grpTargetSelection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTargetSelection.Location = new System.Drawing.Point(6, 663);
            this.grpTargetSelection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpTargetSelection.Name = "grpTargetSelection";
            this.grpTargetSelection.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpTargetSelection.Size = new System.Drawing.Size(1456, 151);
            this.grpTargetSelection.TabIndex = 4;
            this.grpTargetSelection.TabStop = false;
            this.grpTargetSelection.Text = "Target environment";
            // 
            // lstTargetEnvironments
            // 
            this.lstTargetEnvironments.Location = new System.Drawing.Point(226, 90);
            this.lstTargetEnvironments.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstTargetEnvironments.Name = "lstTargetEnvironments";
            this.lstTargetEnvironments.Size = new System.Drawing.Size(1210, 43);
            this.lstTargetEnvironments.TabIndex = 7;
            this.lstTargetEnvironments.UseCompatibleStateImageBehavior = false;
            this.lstTargetEnvironments.View = System.Windows.Forms.View.List;
            this.lstTargetEnvironments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTargetEnvironments_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(11, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1427, 41);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(48, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(801, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Click on \"Add target\" to select the organization where to import the selected sol" +
    "ution";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 30);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DamSimIcon.png");
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.panel3);
            this.gbOptions.Location = new System.Drawing.Point(6, 825);
            this.gbOptions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbOptions.Size = new System.Drawing.Size(1456, 423);
            this.gbOptions.TabIndex = 5;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.chkSkipProductUpdateDependencies);
            this.panel3.Controls.Add(this.chkStageForUpgrade);
            this.panel3.Controls.Add(this.chkExternalApplications);
            this.panel3.Controls.Add(this.chkSales);
            this.panel3.Controls.Add(this.chkIsvConfig);
            this.panel3.Controls.Add(this.chkRelationshipRoles);
            this.panel3.Controls.Add(this.chkOutlookSynchronization);
            this.panel3.Controls.Add(this.chkGeneral);
            this.panel3.Controls.Add(this.chkMarketing);
            this.panel3.Controls.Add(this.chkEmailTracking);
            this.panel3.Controls.Add(this.chkCustomization);
            this.panel3.Controls.Add(this.chkAutoNumering);
            this.panel3.Controls.Add(this.chkCalendar);
            this.panel3.Controls.Add(this.chkExportAsManaged);
            this.panel3.Controls.Add(this.chkConvertToManaged);
            this.panel3.Controls.Add(this.chkOverwriteUnmanagedCustomizations);
            this.panel3.Controls.Add(this.chkActivate);
            this.panel3.Controls.Add(this.chkPublish);
            this.panel3.Location = new System.Drawing.Point(11, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1434, 377);
            this.panel3.TabIndex = 0;
            // 
            // chkIsvConfig
            // 
            this.chkIsvConfig.AutoSize = true;
            this.chkIsvConfig.Location = new System.Drawing.Point(909, 338);
            this.chkIsvConfig.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkIsvConfig.Name = "chkIsvConfig";
            this.chkIsvConfig.Size = new System.Drawing.Size(133, 29);
            this.chkIsvConfig.TabIndex = 106;
            this.chkIsvConfig.Text = "ISV Config";
            this.chkIsvConfig.UseVisualStyleBackColor = true;
            // 
            // chkRelationshipRoles
            // 
            this.chkRelationshipRoles.AutoSize = true;
            this.chkRelationshipRoles.Location = new System.Drawing.Point(909, 297);
            this.chkRelationshipRoles.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkRelationshipRoles.Name = "chkRelationshipRoles";
            this.chkRelationshipRoles.Size = new System.Drawing.Size(198, 29);
            this.chkRelationshipRoles.TabIndex = 105;
            this.chkRelationshipRoles.Text = "Relationship Roles";
            this.chkRelationshipRoles.UseVisualStyleBackColor = true;
            // 
            // chkOutlookSynchronization
            // 
            this.chkOutlookSynchronization.AutoSize = true;
            this.chkOutlookSynchronization.Location = new System.Drawing.Point(909, 255);
            this.chkOutlookSynchronization.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkOutlookSynchronization.Name = "chkOutlookSynchronization";
            this.chkOutlookSynchronization.Size = new System.Drawing.Size(251, 29);
            this.chkOutlookSynchronization.TabIndex = 104;
            this.chkOutlookSynchronization.Text = "Outlook Synchronization";
            this.chkOutlookSynchronization.UseVisualStyleBackColor = true;
            // 
            // chkGeneral
            // 
            this.chkGeneral.AutoSize = true;
            this.chkGeneral.Location = new System.Drawing.Point(909, 170);
            this.chkGeneral.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkGeneral.Name = "chkGeneral";
            this.chkGeneral.Size = new System.Drawing.Size(107, 29);
            this.chkGeneral.TabIndex = 103;
            this.chkGeneral.Text = "General";
            this.chkGeneral.UseVisualStyleBackColor = true;
            // 
            // chkMarketing
            // 
            this.chkMarketing.AutoSize = true;
            this.chkMarketing.Location = new System.Drawing.Point(909, 214);
            this.chkMarketing.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkMarketing.Name = "chkMarketing";
            this.chkMarketing.Size = new System.Drawing.Size(124, 29);
            this.chkMarketing.TabIndex = 102;
            this.chkMarketing.Text = "Marketing";
            this.chkMarketing.UseVisualStyleBackColor = true;
            // 
            // chkEmailTracking
            // 
            this.chkEmailTracking.AutoSize = true;
            this.chkEmailTracking.Location = new System.Drawing.Point(909, 127);
            this.chkEmailTracking.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkEmailTracking.Name = "chkEmailTracking";
            this.chkEmailTracking.Size = new System.Drawing.Size(166, 29);
            this.chkEmailTracking.TabIndex = 101;
            this.chkEmailTracking.Text = "E-mail tracking";
            this.chkEmailTracking.UseVisualStyleBackColor = true;
            // 
            // chkCustomization
            // 
            this.chkCustomization.AutoSize = true;
            this.chkCustomization.Location = new System.Drawing.Point(909, 85);
            this.chkCustomization.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkCustomization.Name = "chkCustomization";
            this.chkCustomization.Size = new System.Drawing.Size(162, 29);
            this.chkCustomization.TabIndex = 100;
            this.chkCustomization.Text = "Customization";
            this.chkCustomization.UseVisualStyleBackColor = true;
            // 
            // chkAutoNumering
            // 
            this.chkAutoNumering.AutoSize = true;
            this.chkAutoNumering.Location = new System.Drawing.Point(909, 0);
            this.chkAutoNumering.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkAutoNumering.Name = "chkAutoNumering";
            this.chkAutoNumering.Size = new System.Drawing.Size(178, 29);
            this.chkAutoNumering.TabIndex = 99;
            this.chkAutoNumering.Text = "Auto-numbering";
            this.chkAutoNumering.UseVisualStyleBackColor = true;
            // 
            // chkCalendar
            // 
            this.chkCalendar.AutoSize = true;
            this.chkCalendar.Location = new System.Drawing.Point(909, 42);
            this.chkCalendar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkCalendar.Name = "chkCalendar";
            this.chkCalendar.Size = new System.Drawing.Size(118, 29);
            this.chkCalendar.TabIndex = 98;
            this.chkCalendar.Text = "Calendar";
            this.chkCalendar.UseVisualStyleBackColor = true;
            // 
            // chkExportAsManaged
            // 
            this.chkExportAsManaged.AutoSize = true;
            this.chkExportAsManaged.Location = new System.Drawing.Point(0, 0);
            this.chkExportAsManaged.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkExportAsManaged.Name = "chkExportAsManaged";
            this.chkExportAsManaged.Size = new System.Drawing.Size(357, 29);
            this.chkExportAsManaged.TabIndex = 97;
            this.chkExportAsManaged.Text = "Export selected solution as managed";
            this.chkExportAsManaged.UseVisualStyleBackColor = true;
            this.chkExportAsManaged.CheckedChanged += new System.EventHandler(this.ChkExportAsManagedCheckedChanged);
            // 
            // chkConvertToManaged
            // 
            this.chkConvertToManaged.AutoSize = true;
            this.chkConvertToManaged.Location = new System.Drawing.Point(444, 127);
            this.chkConvertToManaged.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkConvertToManaged.Name = "chkConvertToManaged";
            this.chkConvertToManaged.Size = new System.Drawing.Size(300, 29);
            this.chkConvertToManaged.TabIndex = 96;
            this.chkConvertToManaged.Text = "Convert To Managed Solution";
            this.chkConvertToManaged.UseVisualStyleBackColor = true;
            // 
            // chkOverwriteUnmanagedCustomizations
            // 
            this.chkOverwriteUnmanagedCustomizations.AutoSize = true;
            this.chkOverwriteUnmanagedCustomizations.Location = new System.Drawing.Point(444, 85);
            this.chkOverwriteUnmanagedCustomizations.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkOverwriteUnmanagedCustomizations.Name = "chkOverwriteUnmanagedCustomizations";
            this.chkOverwriteUnmanagedCustomizations.Size = new System.Drawing.Size(372, 29);
            this.chkOverwriteUnmanagedCustomizations.TabIndex = 95;
            this.chkOverwriteUnmanagedCustomizations.Text = "Overwrite Unmanaged Customizations\r\n";
            this.chkOverwriteUnmanagedCustomizations.UseVisualStyleBackColor = true;
            // 
            // chkActivate
            // 
            this.chkActivate.AutoSize = true;
            this.chkActivate.Checked = true;
            this.chkActivate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivate.Location = new System.Drawing.Point(444, 0);
            this.chkActivate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkActivate.Name = "chkActivate";
            this.chkActivate.Size = new System.Drawing.Size(355, 29);
            this.chkActivate.TabIndex = 94;
            this.chkActivate.Text = "Activate plugins steps and workflows";
            this.chkActivate.UseVisualStyleBackColor = true;
            // 
            // chkPublish
            // 
            this.chkPublish.AutoSize = true;
            this.chkPublish.Checked = true;
            this.chkPublish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPublish.Location = new System.Drawing.Point(444, 42);
            this.chkPublish.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkPublish.Name = "chkPublish";
            this.chkPublish.Size = new System.Drawing.Size(374, 29);
            this.chkPublish.TabIndex = 93;
            this.chkPublish.Text = "Publish solution after having imported it";
            this.chkPublish.UseVisualStyleBackColor = true;
            // 
            // chkSales
            // 
            this.chkSales.AutoSize = true;
            this.chkSales.Location = new System.Drawing.Point(1178, 0);
            this.chkSales.Margin = new System.Windows.Forms.Padding(6);
            this.chkSales.Name = "chkSales";
            this.chkSales.Size = new System.Drawing.Size(88, 29);
            this.chkSales.TabIndex = 107;
            this.chkSales.Text = "Sales";
            this.chkSales.UseVisualStyleBackColor = true;
            // 
            // chkExternalApplications
            // 
            this.chkExternalApplications.AutoSize = true;
            this.chkExternalApplications.Location = new System.Drawing.Point(1178, 41);
            this.chkExternalApplications.Margin = new System.Windows.Forms.Padding(6);
            this.chkExternalApplications.Name = "chkExternalApplications";
            this.chkExternalApplications.Size = new System.Drawing.Size(220, 29);
            this.chkExternalApplications.TabIndex = 108;
            this.chkExternalApplications.Text = "External Applications";
            this.chkExternalApplications.UseVisualStyleBackColor = true;
            // 
            // chkStageForUpgrade
            // 
            this.chkStageForUpgrade.AutoSize = true;
            this.chkStageForUpgrade.Location = new System.Drawing.Point(444, 170);
            this.chkStageForUpgrade.Margin = new System.Windows.Forms.Padding(6);
            this.chkStageForUpgrade.Name = "chkStageForUpgrade";
            this.chkStageForUpgrade.Size = new System.Drawing.Size(194, 29);
            this.chkStageForUpgrade.TabIndex = 109;
            this.chkStageForUpgrade.Text = "Stage for upgrade";
            this.chkStageForUpgrade.UseVisualStyleBackColor = true;
            // 
            // chkSkipProductUpdateDependencies
            // 
            this.chkSkipProductUpdateDependencies.AutoSize = true;
            this.chkSkipProductUpdateDependencies.Location = new System.Drawing.Point(444, 214);
            this.chkSkipProductUpdateDependencies.Margin = new System.Windows.Forms.Padding(6);
            this.chkSkipProductUpdateDependencies.Name = "chkSkipProductUpdateDependencies";
            this.chkSkipProductUpdateDependencies.Size = new System.Drawing.Size(340, 29);
            this.chkSkipProductUpdateDependencies.TabIndex = 110;
            this.chkSkipProductUpdateDependencies.Text = "Skip product update dependencies";
            this.chkSkipProductUpdateDependencies.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // tsbSwitchOrgs
            // 
            this.tsbSwitchOrgs.Image = global::DamSim.SolutionTransferTool.Properties.Resources.arrow_switch;
            this.tsbSwitchOrgs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwitchOrgs.Name = "tsbSwitchOrgs";
            this.tsbSwitchOrgs.Size = new System.Drawing.Size(224, 34);
            this.tsbSwitchOrgs.Text = "Switch organizations";
            this.tsbSwitchOrgs.ToolTipText = "Switch source and target organizations";
            this.tsbSwitchOrgs.Click += new System.EventHandler(this.tsbSwitchOrgs_Click);
            // 
            // SolutionTransferTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.grpTargetSelection);
            this.Controls.Add(this.grpSourceSolution);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SolutionTransferTool";
            this.Size = new System.Drawing.Size(1467, 1254);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpSourceSolution.ResumeLayout(false);
            this.grpSourceSolution.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpTargetSelection.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbOptions.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

 
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.GroupBox grpSourceSolution;
        private System.Windows.Forms.ListView lstSourceSolutions;
        private System.Windows.Forms.ColumnHeader uniquename;
        private System.Windows.Forms.ColumnHeader version;
        private System.Windows.Forms.ColumnHeader installedon;
        private System.Windows.Forms.ColumnHeader publisher;
        private System.Windows.Forms.Button btnAddTarget;
        private System.Windows.Forms.GroupBox grpTargetSelection;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader friendlyname;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadSolutions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbTransfertSolution;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkIsvConfig;
        private System.Windows.Forms.CheckBox chkRelationshipRoles;
        private System.Windows.Forms.CheckBox chkOutlookSynchronization;
        private System.Windows.Forms.CheckBox chkGeneral;
        private System.Windows.Forms.CheckBox chkMarketing;
        private System.Windows.Forms.CheckBox chkEmailTracking;
        private System.Windows.Forms.CheckBox chkCustomization;
        private System.Windows.Forms.CheckBox chkAutoNumering;
        private System.Windows.Forms.CheckBox chkCalendar;
        private System.Windows.Forms.CheckBox chkExportAsManaged;
        private System.Windows.Forms.CheckBox chkConvertToManaged;
        private System.Windows.Forms.CheckBox chkOverwriteUnmanagedCustomizations;
        private System.Windows.Forms.CheckBox chkActivate;
        private System.Windows.Forms.CheckBox chkPublish;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDownloadLogFile;
        private ListView lstTargetEnvironments;
        private ToolStripButton tsbFindMissingDependencies;
        private CheckBox chkExternalApplications;
        private CheckBox chkSales;
        private CheckBox chkSkipProductUpdateDependencies;
        private CheckBox chkStageForUpgrade;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbSwitchOrgs;
    }
}
