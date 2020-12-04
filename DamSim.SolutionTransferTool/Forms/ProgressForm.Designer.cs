namespace DamSim.SolutionTransferTool.Forms
{
    partial class ProgressForm
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
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pnlNew = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRetry = new System.Windows.Forms.Button();
            this.pnlRetry = new System.Windows.Forms.Panel();
            this.pnlProgress.SuspendLayout();
            this.pnlNew.SuspendLayout();
            this.pnlRetry.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProgress
            // 
            this.pnlProgress.AutoScroll = true;
            this.pnlProgress.Controls.Add(this.pnlRetry);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProgress.Location = new System.Drawing.Point(0, 0);
            this.pnlProgress.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(1200, 692);
            this.pnlProgress.TabIndex = 0;
            this.pnlProgress.Visible = false;
            // 
            // pnlNew
            // 
            this.pnlNew.Controls.Add(this.label1);
            this.pnlNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNew.Location = new System.Drawing.Point(0, 0);
            this.pnlNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlNew.Name = "pnlNew";
            this.pnlNew.Size = new System.Drawing.Size(1200, 692);
            this.pnlNew.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1200, 692);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start a solution transfer to see progress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRetry
            // 
            this.btnRetry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRetry.Location = new System.Drawing.Point(0, 10);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(1200, 46);
            this.btnRetry.TabIndex = 2;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // pnlRetry
            // 
            this.pnlRetry.Controls.Add(this.btnRetry);
            this.pnlRetry.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRetry.Location = new System.Drawing.Point(0, 0);
            this.pnlRetry.Name = "pnlRetry";
            this.pnlRetry.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlRetry.Size = new System.Drawing.Size(1200, 56);
            this.pnlRetry.TabIndex = 3;
            this.pnlRetry.Visible = false;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.pnlNew);
            this.Controls.Add(this.pnlProgress);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ProgressForm";
            this.TabText = "Progress";
            this.Text = "Progress";
            this.pnlProgress.ResumeLayout(false);
            this.pnlNew.ResumeLayout(false);
            this.pnlRetry.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Panel pnlNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Panel pnlRetry;
    }
}