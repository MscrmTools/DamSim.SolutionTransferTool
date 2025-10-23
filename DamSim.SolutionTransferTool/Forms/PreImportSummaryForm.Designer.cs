namespace DamSim.SolutionTransferTool.Forms
{
    partial class PreImportSummaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.scDoNotShow = new XrmToolBox.Controls.SwitchControl();
            this.lblDoNotShow = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSolutions = new System.Windows.Forms.Panel();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chFriendlyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUniqueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCurrentVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNewVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSkipNewVersionNumber = new System.Windows.Forms.Panel();
            this.lblOnlyCheckSolWillBeUpdated = new System.Windows.Forms.Label();
            this.scSkipNewVersionNumber = new XrmToolBox.Controls.SwitchControl();
            this.lblSkipNewVersionNumber = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnlImportMode = new System.Windows.Forms.Panel();
            this.ddImportMode = new XrmToolBox.Controls.DropdownSettingsControl();
            this.lblImportMode = new System.Windows.Forms.Label();
            this.pnlPublishWorkflows = new System.Windows.Forms.Panel();
            this.scPublishWorkflows = new XrmToolBox.Controls.SwitchControl();
            this.lblPublishWorkflows = new System.Windows.Forms.Label();
            this.pnlSkipProductUpdateDeps = new System.Windows.Forms.Panel();
            this.scSkipProductUpdateDeps = new XrmToolBox.Controls.SwitchControl();
            this.lblSkipProductUpdateDeps = new System.Windows.Forms.Label();
            this.pnlOverwriteUnmanaged = new System.Windows.Forms.Panel();
            this.scOverwriteUnmanaged = new XrmToolBox.Controls.SwitchControl();
            this.lblOverwriteUnmanaged = new System.Windows.Forms.Label();
            this.pnlConvertToManaged = new System.Windows.Forms.Panel();
            this.scConvertToManaged = new XrmToolBox.Controls.SwitchControl();
            this.lblConvertToManaged = new System.Windows.Forms.Label();
            this.pnlCheckMissingDeps = new System.Windows.Forms.Panel();
            this.scCheckMissingDeps = new XrmToolBox.Controls.SwitchControl();
            this.lblCheckMissingDeps = new System.Windows.Forms.Label();
            this.pnlExportMode = new System.Windows.Forms.Panel();
            this.scImportAsManaged = new XrmToolBox.Controls.SwitchControl();
            this.lblExportMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSummaryHeader = new System.Windows.Forms.Label();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSolutions.SuspendLayout();
            this.pnlSkipNewVersionNumber.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlImportMode.SuspendLayout();
            this.pnlPublishWorkflows.SuspendLayout();
            this.pnlSkipProductUpdateDeps.SuspendLayout();
            this.pnlOverwriteUnmanaged.SuspendLayout();
            this.pnlConvertToManaged.SuspendLayout();
            this.pnlCheckMissingDeps.SuspendLayout();
            this.pnlExportMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblSummaryHeader);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(1004, 90);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.scDoNotShow);
            this.pnlBottom.Controls.Add(this.lblDoNotShow);
            this.pnlBottom.Controls.Add(this.btnStart);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 814);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(1004, 61);
            this.pnlBottom.TabIndex = 1;
            // 
            // scDoNotShow
            // 
            this.scDoNotShow.Checked = false;
            this.scDoNotShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.scDoNotShow.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scDoNotShow.Location = new System.Drawing.Point(179, 10);
            this.scDoNotShow.Margin = new System.Windows.Forms.Padding(4);
            this.scDoNotShow.Name = "scDoNotShow";
            this.scDoNotShow.Size = new System.Drawing.Size(111, 41);
            this.scDoNotShow.TabIndex = 3;
            // 
            // lblDoNotShow
            // 
            this.lblDoNotShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDoNotShow.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoNotShow.Location = new System.Drawing.Point(10, 10);
            this.lblDoNotShow.Name = "lblDoNotShow";
            this.lblDoNotShow.Size = new System.Drawing.Size(169, 41);
            this.lblDoNotShow.TabIndex = 2;
            this.lblDoNotShow.Text = "Do not show this screen";
            this.lblDoNotShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlSolutions);
            this.pnlMain.Controls.Add(this.pnlImportMode);
            this.pnlMain.Controls.Add(this.pnlPublishWorkflows);
            this.pnlMain.Controls.Add(this.pnlSkipProductUpdateDeps);
            this.pnlMain.Controls.Add(this.pnlOverwriteUnmanaged);
            this.pnlMain.Controls.Add(this.pnlConvertToManaged);
            this.pnlMain.Controls.Add(this.pnlCheckMissingDeps);
            this.pnlMain.Controls.Add(this.pnlExportMode);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1004, 724);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlSolutions
            // 
            this.pnlSolutions.Controls.Add(this.lvSolutions);
            this.pnlSolutions.Controls.Add(this.pnlSkipNewVersionNumber);
            this.pnlSolutions.Controls.Add(this.toolStrip1);
            this.pnlSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSolutions.Location = new System.Drawing.Point(10, 360);
            this.pnlSolutions.Name = "pnlSolutions";
            this.pnlSolutions.Size = new System.Drawing.Size(984, 354);
            this.pnlSolutions.TabIndex = 9;
            // 
            // lvSolutions
            // 
            this.lvSolutions.CheckBoxes = true;
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFriendlyName,
            this.chUniqueName,
            this.chCurrentVersion,
            this.chNewVersion});
            this.lvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.GridLines = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(0, 31);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(984, 289);
            this.lvSolutions.TabIndex = 9;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            // 
            // chFriendlyName
            // 
            this.chFriendlyName.Text = "Friendly name";
            this.chFriendlyName.Width = 200;
            // 
            // chUniqueName
            // 
            this.chUniqueName.Text = "Unique name";
            this.chUniqueName.Width = 150;
            // 
            // chCurrentVersion
            // 
            this.chCurrentVersion.Text = "Current version";
            this.chCurrentVersion.Width = 120;
            // 
            // chNewVersion
            // 
            this.chNewVersion.Text = "New version";
            this.chNewVersion.Width = 120;
            // 
            // pnlSkipNewVersionNumber
            // 
            this.pnlSkipNewVersionNumber.Controls.Add(this.lblOnlyCheckSolWillBeUpdated);
            this.pnlSkipNewVersionNumber.Controls.Add(this.scSkipNewVersionNumber);
            this.pnlSkipNewVersionNumber.Controls.Add(this.lblSkipNewVersionNumber);
            this.pnlSkipNewVersionNumber.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSkipNewVersionNumber.Location = new System.Drawing.Point(0, 320);
            this.pnlSkipNewVersionNumber.Name = "pnlSkipNewVersionNumber";
            this.pnlSkipNewVersionNumber.Size = new System.Drawing.Size(984, 34);
            this.pnlSkipNewVersionNumber.TabIndex = 8;
            // 
            // lblOnlyCheckSolWillBeUpdated
            // 
            this.lblOnlyCheckSolWillBeUpdated.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOnlyCheckSolWillBeUpdated.Location = new System.Drawing.Point(640, 0);
            this.lblOnlyCheckSolWillBeUpdated.Name = "lblOnlyCheckSolWillBeUpdated";
            this.lblOnlyCheckSolWillBeUpdated.Size = new System.Drawing.Size(400, 34);
            this.lblOnlyCheckSolWillBeUpdated.TabIndex = 4;
            this.lblOnlyCheckSolWillBeUpdated.Text = "Only checked solutions will have their version updated";
            this.lblOnlyCheckSolWillBeUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scSkipNewVersionNumber
            // 
            this.scSkipNewVersionNumber.Checked = false;
            this.scSkipNewVersionNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.scSkipNewVersionNumber.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scSkipNewVersionNumber.Location = new System.Drawing.Point(250, 0);
            this.scSkipNewVersionNumber.Margin = new System.Windows.Forms.Padding(4);
            this.scSkipNewVersionNumber.Name = "scSkipNewVersionNumber";
            this.scSkipNewVersionNumber.Size = new System.Drawing.Size(123, 34);
            this.scSkipNewVersionNumber.TabIndex = 3;
            // 
            // lblSkipNewVersionNumber
            // 
            this.lblSkipNewVersionNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSkipNewVersionNumber.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkipNewVersionNumber.Location = new System.Drawing.Point(0, 0);
            this.lblSkipNewVersionNumber.Name = "lblSkipNewVersionNumber";
            this.lblSkipNewVersionNumber.Size = new System.Drawing.Size(250, 34);
            this.lblSkipNewVersionNumber.TabIndex = 0;
            this.lblSkipNewVersionNumber.Text = "Skip new solution version number";
            this.lblSkipNewVersionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUp,
            this.tsbDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pnlImportMode
            // 
            this.pnlImportMode.Controls.Add(this.ddImportMode);
            this.pnlImportMode.Controls.Add(this.lblImportMode);
            this.pnlImportMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImportMode.Location = new System.Drawing.Point(10, 310);
            this.pnlImportMode.Name = "pnlImportMode";
            this.pnlImportMode.Size = new System.Drawing.Size(984, 50);
            this.pnlImportMode.TabIndex = 8;
            // 
            // ddImportMode
            // 
            this.ddImportMode.Description = null;
            this.ddImportMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddImportMode.EnumType = null;
            this.ddImportMode.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddImportMode.Location = new System.Drawing.Point(439, 0);
            this.ddImportMode.Name = "ddImportMode";
            this.ddImportMode.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.ddImportMode.PropertyName = null;
            this.ddImportMode.Size = new System.Drawing.Size(545, 50);
            this.ddImportMode.TabIndex = 2;
            this.ddImportMode.Title = null;
            this.ddImportMode.Value = null;
            // 
            // lblImportMode
            // 
            this.lblImportMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblImportMode.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportMode.Location = new System.Drawing.Point(0, 0);
            this.lblImportMode.Name = "lblImportMode";
            this.lblImportMode.Size = new System.Drawing.Size(439, 50);
            this.lblImportMode.TabIndex = 0;
            this.lblImportMode.Text = "Import mode";
            this.lblImportMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPublishWorkflows
            // 
            this.pnlPublishWorkflows.Controls.Add(this.scPublishWorkflows);
            this.pnlPublishWorkflows.Controls.Add(this.lblPublishWorkflows);
            this.pnlPublishWorkflows.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPublishWorkflows.Location = new System.Drawing.Point(10, 260);
            this.pnlPublishWorkflows.Name = "pnlPublishWorkflows";
            this.pnlPublishWorkflows.Size = new System.Drawing.Size(984, 50);
            this.pnlPublishWorkflows.TabIndex = 7;
            // 
            // scPublishWorkflows
            // 
            this.scPublishWorkflows.Checked = false;
            this.scPublishWorkflows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPublishWorkflows.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scPublishWorkflows.Location = new System.Drawing.Point(439, 0);
            this.scPublishWorkflows.Margin = new System.Windows.Forms.Padding(4);
            this.scPublishWorkflows.Name = "scPublishWorkflows";
            this.scPublishWorkflows.Size = new System.Drawing.Size(545, 50);
            this.scPublishWorkflows.TabIndex = 3;
            // 
            // lblPublishWorkflows
            // 
            this.lblPublishWorkflows.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPublishWorkflows.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublishWorkflows.Location = new System.Drawing.Point(0, 0);
            this.lblPublishWorkflows.Name = "lblPublishWorkflows";
            this.lblPublishWorkflows.Size = new System.Drawing.Size(439, 50);
            this.lblPublishWorkflows.TabIndex = 0;
            this.lblPublishWorkflows.Text = "Publish workflows";
            this.lblPublishWorkflows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSkipProductUpdateDeps
            // 
            this.pnlSkipProductUpdateDeps.Controls.Add(this.scSkipProductUpdateDeps);
            this.pnlSkipProductUpdateDeps.Controls.Add(this.lblSkipProductUpdateDeps);
            this.pnlSkipProductUpdateDeps.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSkipProductUpdateDeps.Location = new System.Drawing.Point(10, 210);
            this.pnlSkipProductUpdateDeps.Name = "pnlSkipProductUpdateDeps";
            this.pnlSkipProductUpdateDeps.Size = new System.Drawing.Size(984, 50);
            this.pnlSkipProductUpdateDeps.TabIndex = 6;
            // 
            // scSkipProductUpdateDeps
            // 
            this.scSkipProductUpdateDeps.Checked = false;
            this.scSkipProductUpdateDeps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSkipProductUpdateDeps.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scSkipProductUpdateDeps.Location = new System.Drawing.Point(439, 0);
            this.scSkipProductUpdateDeps.Margin = new System.Windows.Forms.Padding(4);
            this.scSkipProductUpdateDeps.Name = "scSkipProductUpdateDeps";
            this.scSkipProductUpdateDeps.Size = new System.Drawing.Size(545, 50);
            this.scSkipProductUpdateDeps.TabIndex = 3;
            // 
            // lblSkipProductUpdateDeps
            // 
            this.lblSkipProductUpdateDeps.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSkipProductUpdateDeps.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkipProductUpdateDeps.Location = new System.Drawing.Point(0, 0);
            this.lblSkipProductUpdateDeps.Name = "lblSkipProductUpdateDeps";
            this.lblSkipProductUpdateDeps.Size = new System.Drawing.Size(439, 50);
            this.lblSkipProductUpdateDeps.TabIndex = 0;
            this.lblSkipProductUpdateDeps.Text = "Skip product update dependencies";
            this.lblSkipProductUpdateDeps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOverwriteUnmanaged
            // 
            this.pnlOverwriteUnmanaged.Controls.Add(this.scOverwriteUnmanaged);
            this.pnlOverwriteUnmanaged.Controls.Add(this.lblOverwriteUnmanaged);
            this.pnlOverwriteUnmanaged.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOverwriteUnmanaged.Location = new System.Drawing.Point(10, 160);
            this.pnlOverwriteUnmanaged.Name = "pnlOverwriteUnmanaged";
            this.pnlOverwriteUnmanaged.Size = new System.Drawing.Size(984, 50);
            this.pnlOverwriteUnmanaged.TabIndex = 5;
            // 
            // scOverwriteUnmanaged
            // 
            this.scOverwriteUnmanaged.Checked = false;
            this.scOverwriteUnmanaged.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOverwriteUnmanaged.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scOverwriteUnmanaged.Location = new System.Drawing.Point(439, 0);
            this.scOverwriteUnmanaged.Margin = new System.Windows.Forms.Padding(4);
            this.scOverwriteUnmanaged.Name = "scOverwriteUnmanaged";
            this.scOverwriteUnmanaged.Size = new System.Drawing.Size(545, 50);
            this.scOverwriteUnmanaged.TabIndex = 3;
            // 
            // lblOverwriteUnmanaged
            // 
            this.lblOverwriteUnmanaged.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOverwriteUnmanaged.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverwriteUnmanaged.Location = new System.Drawing.Point(0, 0);
            this.lblOverwriteUnmanaged.Name = "lblOverwriteUnmanaged";
            this.lblOverwriteUnmanaged.Size = new System.Drawing.Size(439, 50);
            this.lblOverwriteUnmanaged.TabIndex = 0;
            this.lblOverwriteUnmanaged.Text = "Overwrite unmanaged customizations";
            this.lblOverwriteUnmanaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlConvertToManaged
            // 
            this.pnlConvertToManaged.Controls.Add(this.scConvertToManaged);
            this.pnlConvertToManaged.Controls.Add(this.lblConvertToManaged);
            this.pnlConvertToManaged.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConvertToManaged.Location = new System.Drawing.Point(10, 110);
            this.pnlConvertToManaged.Name = "pnlConvertToManaged";
            this.pnlConvertToManaged.Size = new System.Drawing.Size(984, 50);
            this.pnlConvertToManaged.TabIndex = 4;
            // 
            // scConvertToManaged
            // 
            this.scConvertToManaged.Checked = false;
            this.scConvertToManaged.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scConvertToManaged.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scConvertToManaged.Location = new System.Drawing.Point(439, 0);
            this.scConvertToManaged.Margin = new System.Windows.Forms.Padding(4);
            this.scConvertToManaged.Name = "scConvertToManaged";
            this.scConvertToManaged.Size = new System.Drawing.Size(545, 50);
            this.scConvertToManaged.TabIndex = 3;
            // 
            // lblConvertToManaged
            // 
            this.lblConvertToManaged.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblConvertToManaged.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvertToManaged.Location = new System.Drawing.Point(0, 0);
            this.lblConvertToManaged.Name = "lblConvertToManaged";
            this.lblConvertToManaged.Size = new System.Drawing.Size(439, 50);
            this.lblConvertToManaged.TabIndex = 0;
            this.lblConvertToManaged.Text = "Convert to managed";
            this.lblConvertToManaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCheckMissingDeps
            // 
            this.pnlCheckMissingDeps.Controls.Add(this.scCheckMissingDeps);
            this.pnlCheckMissingDeps.Controls.Add(this.lblCheckMissingDeps);
            this.pnlCheckMissingDeps.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckMissingDeps.Location = new System.Drawing.Point(10, 60);
            this.pnlCheckMissingDeps.Name = "pnlCheckMissingDeps";
            this.pnlCheckMissingDeps.Size = new System.Drawing.Size(984, 50);
            this.pnlCheckMissingDeps.TabIndex = 3;
            // 
            // scCheckMissingDeps
            // 
            this.scCheckMissingDeps.Checked = false;
            this.scCheckMissingDeps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scCheckMissingDeps.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scCheckMissingDeps.Location = new System.Drawing.Point(439, 0);
            this.scCheckMissingDeps.Margin = new System.Windows.Forms.Padding(4);
            this.scCheckMissingDeps.Name = "scCheckMissingDeps";
            this.scCheckMissingDeps.Size = new System.Drawing.Size(545, 50);
            this.scCheckMissingDeps.TabIndex = 3;
            // 
            // lblCheckMissingDeps
            // 
            this.lblCheckMissingDeps.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCheckMissingDeps.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckMissingDeps.Location = new System.Drawing.Point(0, 0);
            this.lblCheckMissingDeps.Name = "lblCheckMissingDeps";
            this.lblCheckMissingDeps.Size = new System.Drawing.Size(439, 50);
            this.lblCheckMissingDeps.TabIndex = 0;
            this.lblCheckMissingDeps.Text = "Check for missing dependencies";
            this.lblCheckMissingDeps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlExportMode
            // 
            this.pnlExportMode.Controls.Add(this.scImportAsManaged);
            this.pnlExportMode.Controls.Add(this.lblExportMode);
            this.pnlExportMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlExportMode.Location = new System.Drawing.Point(10, 10);
            this.pnlExportMode.Name = "pnlExportMode";
            this.pnlExportMode.Size = new System.Drawing.Size(984, 50);
            this.pnlExportMode.TabIndex = 1;
            // 
            // scImportAsManaged
            // 
            this.scImportAsManaged.Checked = false;
            this.scImportAsManaged.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scImportAsManaged.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scImportAsManaged.Location = new System.Drawing.Point(439, 0);
            this.scImportAsManaged.Margin = new System.Windows.Forms.Padding(4);
            this.scImportAsManaged.Name = "scImportAsManaged";
            this.scImportAsManaged.Size = new System.Drawing.Size(545, 50);
            this.scImportAsManaged.TabIndex = 5;
            this.scImportAsManaged.OnCheckedChanged += new System.EventHandler(this.scImportAsManaged_OnCheckedChanged);
            // 
            // lblExportMode
            // 
            this.lblExportMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExportMode.Font = new System.Drawing.Font("Segoe UI Variable Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportMode.Location = new System.Drawing.Point(0, 0);
            this.lblExportMode.Name = "lblExportMode";
            this.lblExportMode.Size = new System.Drawing.Size(439, 50);
            this.lblExportMode.TabIndex = 3;
            this.lblExportMode.Text = "Import as managed";
            this.lblExportMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(984, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pre Import Summary";
            // 
            // lblSummaryHeader
            // 
            this.lblSummaryHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummaryHeader.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummaryHeader.Location = new System.Drawing.Point(10, 47);
            this.lblSummaryHeader.Name = "lblSummaryHeader";
            this.lblSummaryHeader.Size = new System.Drawing.Size(984, 33);
            this.lblSummaryHeader.TabIndex = 2;
            this.lblSummaryHeader.Text = "This is a summary of the settings used to transfer selected solutions. You can ch" +
    "ange some settings now";
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUp.Image = global::DamSim.SolutionTransferTool.Properties.Resources.Arrow_Up_icon;
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(29, 28);
            this.tsbUp.Text = "Up";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // tsbDown
            // 
            this.tsbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDown.Image = global::DamSim.SolutionTransferTool.Properties.Resources.Arrow_Down_icon;
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(29, 28);
            this.tsbDown.Text = "Down";
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStart.Image = global::DamSim.SolutionTransferTool.Properties.Resources.Startup32;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.Location = new System.Drawing.Point(850, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 41);
            this.btnStart.TabIndex = 1;
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Text = "Run";
            this.btnStart.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // PreImportSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 875);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "PreImportSummaryForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlSolutions.ResumeLayout(false);
            this.pnlSolutions.PerformLayout();
            this.pnlSkipNewVersionNumber.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlImportMode.ResumeLayout(false);
            this.pnlPublishWorkflows.ResumeLayout(false);
            this.pnlSkipProductUpdateDeps.ResumeLayout(false);
            this.pnlOverwriteUnmanaged.ResumeLayout(false);
            this.pnlConvertToManaged.ResumeLayout(false);
            this.pnlCheckMissingDeps.ResumeLayout(false);
            this.pnlExportMode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlExportMode;
        private System.Windows.Forms.Label lblExportMode;
        private System.Windows.Forms.Panel pnlConvertToManaged;
        private XrmToolBox.Controls.SwitchControl scConvertToManaged;
        private System.Windows.Forms.Label lblConvertToManaged;
        private System.Windows.Forms.Panel pnlCheckMissingDeps;
        private XrmToolBox.Controls.SwitchControl scCheckMissingDeps;
        private System.Windows.Forms.Label lblCheckMissingDeps;
        private System.Windows.Forms.Panel pnlPublishWorkflows;
        private XrmToolBox.Controls.SwitchControl scPublishWorkflows;
        private System.Windows.Forms.Label lblPublishWorkflows;
        private System.Windows.Forms.Panel pnlSkipProductUpdateDeps;
        private XrmToolBox.Controls.SwitchControl scSkipProductUpdateDeps;
        private System.Windows.Forms.Label lblSkipProductUpdateDeps;
        private System.Windows.Forms.Panel pnlOverwriteUnmanaged;
        private XrmToolBox.Controls.SwitchControl scOverwriteUnmanaged;
        private System.Windows.Forms.Label lblOverwriteUnmanaged;
        private System.Windows.Forms.Panel pnlImportMode;
        private System.Windows.Forms.Label lblImportMode;
        private XrmToolBox.Controls.DropdownSettingsControl ddImportMode;
        private XrmToolBox.Controls.SwitchControl scImportAsManaged;
        private System.Windows.Forms.Panel pnlSolutions;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pnlSkipNewVersionNumber;
        private XrmToolBox.Controls.SwitchControl scSkipNewVersionNumber;
        private System.Windows.Forms.Label lblSkipNewVersionNumber;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chFriendlyName;
        private System.Windows.Forms.ColumnHeader chUniqueName;
        private System.Windows.Forms.ColumnHeader chCurrentVersion;
        private System.Windows.Forms.ColumnHeader chNewVersion;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.Button btnStart;
        private XrmToolBox.Controls.SwitchControl scDoNotShow;
        private System.Windows.Forms.Label lblDoNotShow;
        private System.Windows.Forms.Label lblOnlyCheckSolWillBeUpdated;
        private System.Windows.Forms.Label lblSummaryHeader;
        private System.Windows.Forms.Label label1;
    }
}