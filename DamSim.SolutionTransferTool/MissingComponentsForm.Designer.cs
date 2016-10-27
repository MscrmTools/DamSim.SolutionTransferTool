namespace DamSim.SolutionTransferTool
{
    partial class MissingComponentsForm
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
            this.lstMissingComponents = new System.Windows.Forms.ListView();
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schemaname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.parentschemaname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFixMissing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMissingComponents
            // 
            this.lstMissingComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.type,
            this.schemaname,
            this.parentschemaname});
            this.lstMissingComponents.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstMissingComponents.Location = new System.Drawing.Point(0, 0);
            this.lstMissingComponents.Name = "lstMissingComponents";
            this.lstMissingComponents.Size = new System.Drawing.Size(587, 299);
            this.lstMissingComponents.TabIndex = 0;
            this.lstMissingComponents.UseCompatibleStateImageBehavior = false;
            this.lstMissingComponents.View = System.Windows.Forms.View.Details;        
            // 
            // schemaname
            // 
            this.schemaname.DisplayIndex = 0;
            this.schemaname.Text = "schemaname";
            this.schemaname.Width = 160;
            // 
            // parentschemaname
            // 
            this.parentschemaname.DisplayIndex = 1;
            this.parentschemaname.Text = "parentschemaname";
            this.parentschemaname.Width = 160;
            // 
            // type
            // 
            this.type.DisplayIndex = 2;
            this.type.Text = "type";
            this.type.Width = 70;
            // 
            // btnFixMissing
            // 
            this.btnFixMissing.Location = new System.Drawing.Point(467, 305);
            this.btnFixMissing.Name = "btnFixMissing";
            this.btnFixMissing.Size = new System.Drawing.Size(108, 24);
            this.btnFixMissing.TabIndex = 1;
            this.btnFixMissing.Text = "Fix Missing";
            this.btnFixMissing.UseVisualStyleBackColor = true;
            this.btnFixMissing.Click += new System.EventHandler(this.btnFixMissing_Click);
            // 
            // MissingComponentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 335);
            this.Controls.Add(this.btnFixMissing);
            this.Controls.Add(this.lstMissingComponents);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MissingComponentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MissingComponentsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstMissingComponents;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader schemaname;
        private System.Windows.Forms.ColumnHeader parentschemaname;
        private System.Windows.Forms.Button btnFixMissing;
    }
}