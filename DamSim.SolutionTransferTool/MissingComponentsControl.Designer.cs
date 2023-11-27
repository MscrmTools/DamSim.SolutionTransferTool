namespace DamSim.SolutionTransferTool
{
    partial class MissingComponentsControl
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lvMissingComponents = new System.Windows.Forms.ListView();
            this.chRcDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRcSchemaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRcId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRcType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRcSolution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDcDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDcSchemaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDcId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDcType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDcSolution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblHeaderTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(1864, 78);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Variable Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(13, 10);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(550, 37);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Missing components in target environment";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExportExcel);
            this.pnlBottom.Controls.Add(this.btnMaximize);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 834);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(1864, 65);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.Location = new System.Drawing.Point(1628, 10);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(113, 45);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.Text = "Maximize";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(1741, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 45);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMain.Controls.Add(this.lvMissingComponents);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 78);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1864, 756);
            this.pnlMain.TabIndex = 2;
            // 
            // lvMissingComponents
            // 
            this.lvMissingComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRcDisplayName,
            this.chRcSchemaName,
            this.chRcId,
            this.chRcType,
            this.chRcSolution});
            this.lvMissingComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMissingComponents.FullRowSelect = true;
            this.lvMissingComponents.GridLines = true;
            this.lvMissingComponents.HideSelection = false;
            this.lvMissingComponents.Location = new System.Drawing.Point(10, 10);
            this.lvMissingComponents.Name = "lvMissingComponents";
            this.lvMissingComponents.Size = new System.Drawing.Size(1844, 736);
            this.lvMissingComponents.TabIndex = 0;
            this.lvMissingComponents.UseCompatibleStateImageBehavior = false;
            this.lvMissingComponents.View = System.Windows.Forms.View.Details;
            this.lvMissingComponents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvMissingComponents_ColumnClick);
            // 
            // chRcDisplayName
            // 
            this.chRcDisplayName.Text = "Required component";
            this.chRcDisplayName.Width = 150;
            // 
            // chRcSchemaName
            // 
            this.chRcSchemaName.Text = "Schema name";
            this.chRcSchemaName.Width = 150;
            // 
            // chRcId
            // 
            this.chRcId.Text = "ID";
            this.chRcId.Width = 150;
            // 
            // chRcType
            // 
            this.chRcType.Text = "Type";
            this.chRcType.Width = 150;
            // 
            // chRcSolution
            // 
            this.chRcSolution.Text = "Solution";
            this.chRcSolution.Width = 150;
            // 
            // chDcDisplayName
            // 
            this.chDcDisplayName.Text = "Required component";
            this.chDcDisplayName.Width = 150;
            // 
            // chDcSchemaName
            // 
            this.chDcSchemaName.Text = "Schema name";
            this.chDcSchemaName.Width = 150;
            // 
            // chDcId
            // 
            this.chDcId.Text = "ID";
            this.chDcId.Width = 150;
            // 
            // chDcType
            // 
            this.chDcType.Text = "Type";
            this.chDcType.Width = 150;
            // 
            // chDcSolution
            // 
            this.chDcSolution.Text = "Solution";
            this.chDcSolution.Width = 150;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportExcel.Location = new System.Drawing.Point(1415, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(213, 45);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Export to Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // MissingComponentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "MissingComponentsControl";
            this.Size = new System.Drawing.Size(1864, 899);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.ListView lvMissingComponents;
        private System.Windows.Forms.ColumnHeader chRcDisplayName;
        private System.Windows.Forms.ColumnHeader chRcSchemaName;
        private System.Windows.Forms.ColumnHeader chRcId;
        private System.Windows.Forms.ColumnHeader chRcType;
        private System.Windows.Forms.ColumnHeader chRcSolution;
        private System.Windows.Forms.ColumnHeader chDcDisplayName;
        private System.Windows.Forms.ColumnHeader chDcSchemaName;
        private System.Windows.Forms.ColumnHeader chDcId;
        private System.Windows.Forms.ColumnHeader chDcType;
        private System.Windows.Forms.ColumnHeader chDcSolution;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnExportExcel;
    }
}
