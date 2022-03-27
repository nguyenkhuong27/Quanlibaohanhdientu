
namespace Thietbibaohanh
{
    partial class ReportHDBH
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
            this.CrpHDBH = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrpHDBH
            // 
            this.CrpHDBH.ActiveViewIndex = -1;
            this.CrpHDBH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrpHDBH.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrpHDBH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrpHDBH.Location = new System.Drawing.Point(0, 0);
            this.CrpHDBH.Name = "CrpHDBH";
            this.CrpHDBH.Size = new System.Drawing.Size(800, 450);
            this.CrpHDBH.TabIndex = 0;
            // 
            // ReportHDBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrpHDBH);
            this.Name = "ReportHDBH";
            this.Text = "ReportHDBH";
            this.Load += new System.EventHandler(this.ReportHDBH_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrpHDBH;
    }
}