namespace TestControls
{
    partial class Form1
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
            this.bedCardControl1 = new BedCard.Controls.BedCardControl();
            this.SuspendLayout();
            // 
            // bedCardControl1
            // 
            this.bedCardControl1.AutoScroll = true;
            this.bedCardControl1.BackColor = System.Drawing.Color.White;
            this.bedCardControl1.BedContextFields = null;
            this.bedCardControl1.BedHeight = 160;
            this.bedCardControl1.BedWidth = 162;
            this.bedCardControl1.DataSource = null;
            this.bedCardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bedCardControl1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.bedCardControl1.LicenseKey = "xjZftkgkO4WG7FlzlbcciA==";
            this.bedCardControl1.Location = new System.Drawing.Point(0, 0);
            this.bedCardControl1.Name = "bedCardControl1";
            this.bedCardControl1.SelectedBed = null;
            this.bedCardControl1.SelectedBedIndex = -1;
            this.bedCardControl1.Size = new System.Drawing.Size(407, 322);
            this.bedCardControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 322);
            this.Controls.Add(this.bedCardControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private BedCard.Controls.BedCardControl bedCardControl1;
    }
}