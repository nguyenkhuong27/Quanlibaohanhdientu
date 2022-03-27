
namespace Thietbibaohanh
{
    partial class Report
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
            this.CrpNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrpNV
            // 
            this.CrpNV.ActiveViewIndex = -1;
            this.CrpNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrpNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrpNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrpNV.Location = new System.Drawing.Point(0, 0);
            this.CrpNV.Name = "CrpNV";
            this.CrpNV.Size = new System.Drawing.Size(800, 450);
            this.CrpNV.TabIndex = 0;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrpNV);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrpNV;
    }
}