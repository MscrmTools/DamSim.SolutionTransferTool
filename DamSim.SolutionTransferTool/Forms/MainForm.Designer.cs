namespace DamSim.SolutionTransferTool.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblSource = new System.Windows.Forms.Label();
            this.scOrganizations = new System.Windows.Forms.SplitContainer();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.gbTargetOrgs = new System.Windows.Forms.GroupBox();
            this.btnAddTarget = new System.Windows.Forms.Button();
            this.grpSourceSolution = new System.Windows.Forms.GroupBox();
            this.lstSourceSolutions = new System.Windows.Forms.ListView();
            this.uniquename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.friendlyname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installedon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.scOrganizations)).BeginInit();
            this.scOrganizations.Panel1.SuspendLayout();
            this.scOrganizations.Panel2.SuspendLayout();
            this.scOrganizations.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.gbTargetOrgs.SuspendLayout();
            this.grpSourceSolution.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSource.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSource.ForeColor = System.Drawing.Color.Red;
            this.lblSource.Location = new System.Drawing.Point(2, 17);
            this.lblSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(354, 41);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Not selected yet (use XrmToolBox connect button)";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scOrganizations
            // 
            this.scOrganizations.Dock = System.Windows.Forms.DockStyle.Top;
            this.scOrganizations.Location = new System.Drawing.Point(0, 0);
            this.scOrganizations.Margin = new System.Windows.Forms.Padding(2);
            this.scOrganizations.Name = "scOrganizations";
            // 
            // scOrganizations.Panel1
            // 
            this.scOrganizations.Panel1.Controls.Add(this.gbSource);
            // 
            // scOrganizations.Panel2
            // 
            this.scOrganizations.Panel2.Controls.Add(this.gbTargetOrgs);
            this.scOrganizations.Size = new System.Drawing.Size(1074, 60);
            this.scOrganizations.SplitterDistance = 358;
            this.scOrganizations.SplitterWidth = 3;
            this.scOrganizations.TabIndex = 8;
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.lblSource);
            this.gbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSource.Location = new System.Drawing.Point(0, 0);
            this.gbSource.Margin = new System.Windows.Forms.Padding(2);
            this.gbSource.Name = "gbSource";
            this.gbSource.Padding = new System.Windows.Forms.Padding(2);
            this.gbSource.Size = new System.Drawing.Size(358, 60);
            this.gbSource.TabIndex = 0;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source environment";
            // 
            // gbTargetOrgs
            // 
            this.gbTargetOrgs.Controls.Add(this.btnAddTarget);
            this.gbTargetOrgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTargetOrgs.Location = new System.Drawing.Point(0, 0);
            this.gbTargetOrgs.Margin = new System.Windows.Forms.Padding(2);
            this.gbTargetOrgs.Name = "gbTargetOrgs";
            this.gbTargetOrgs.Padding = new System.Windows.Forms.Padding(2);
            this.gbTargetOrgs.Size = new System.Drawing.Size(713, 60);
            this.gbTargetOrgs.TabIndex = 0;
            this.gbTargetOrgs.TabStop = false;
            this.gbTargetOrgs.Text = "Target environment(s)";
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddTarget.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddTarget.Image = global::DamSim.SolutionTransferTool.Properties.Resources.plus;
            this.btnAddTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTarget.Location = new System.Drawing.Point(2, 17);
            this.btnAddTarget.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(69, 41);
            this.btnAddTarget.TabIndex = 3;
            this.btnAddTarget.Text = "Add";
            this.btnAddTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTarget.UseVisualStyleBackColor = true;
            this.btnAddTarget.Click += new System.EventHandler(this.btnAddTarget_Click);
            // 
            // grpSourceSolution
            // 
            this.grpSourceSolution.Controls.Add(this.lstSourceSolutions);
            this.grpSourceSolution.Controls.Add(this.panel1);
            this.grpSourceSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSourceSolution.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpSourceSolution.Location = new System.Drawing.Point(0, 60);
            this.grpSourceSolution.Margin = new System.Windows.Forms.Padding(4);
            this.grpSourceSolution.Name = "grpSourceSolution";
            this.grpSourceSolution.Padding = new System.Windows.Forms.Padding(4);
            this.grpSourceSolution.Size = new System.Drawing.Size(1074, 494);
            this.grpSourceSolution.TabIndex = 9;
            this.grpSourceSolution.TabStop = false;
            this.grpSourceSolution.Text = "Solutions";
            // 
            // lstSourceSolutions
            // 
            this.lstSourceSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uniquename,
            this.friendlyname,
            this.version,
            this.installedon,
            this.publisher,
            this.description});
            this.lstSourceSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSourceSolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lstSourceSolutions.HideSelection = false;
            this.lstSourceSolutions.Location = new System.Drawing.Point(4, 52);
            this.lstSourceSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.lstSourceSolutions.Name = "lstSourceSolutions";
            this.lstSourceSolutions.Size = new System.Drawing.Size(1066, 438);
            this.lstSourceSolutions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstSourceSolutions.TabIndex = 6;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 28);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(35, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Click on \"Load Solutions\" to display and select solution(s) to transfer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 20);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 554);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.grpSourceSolution);
            this.Controls.Add(this.scOrganizations);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.TabText = "Solutions and Organizations";
            this.Text = "Solutions and Environments";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.scOrganizations.Panel1.ResumeLayout(false);
            this.scOrganizations.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scOrganizations)).EndInit();
            this.scOrganizations.ResumeLayout(false);
            this.gbSource.ResumeLayout(false);
            this.gbTargetOrgs.ResumeLayout(false);
            this.grpSourceSolution.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddTarget;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.SplitContainer scOrganizations;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.GroupBox gbTargetOrgs;
        private System.Windows.Forms.GroupBox grpSourceSolution;
        private System.Windows.Forms.ListView lstSourceSolutions;
        private System.Windows.Forms.ColumnHeader uniquename;
        private System.Windows.Forms.ColumnHeader friendlyname;
        private System.Windows.Forms.ColumnHeader version;
        private System.Windows.Forms.ColumnHeader installedon;
        private System.Windows.Forms.ColumnHeader publisher;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}