using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thietbibaohanh
{
    public partial class ReportHDBH : Form
    {
        public ReportHDBH()
        {
            InitializeComponent();
        }

        private void ReportHDBH_Load(object sender, EventArgs e)
        {
            showReport();
        }

        private void showReport()
        {
            ReportDocument rpt = new ReportDocument();
            string path = string.Format("{0}\\CreReportHDBH.rpt",
                Application.StartupPath);
            rpt.Load(path);
            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            logOnInfo.ConnectionInfo.ServerName = ".\\SQLEXPRESS";
            logOnInfo.ConnectionInfo.DatabaseName = "LTHSK";
            logOnInfo.ConnectionInfo.UserID = "sa";
            logOnInfo.ConnectionInfo.Password = "123456";
            //foreach (Tables t in rpt.Database.Tables)
            //{
            //    t.ApplyLogOnInfo(logOnInfo);
            //}
            CrpHDBH.ReportSource = rpt;
        }
    }
}
