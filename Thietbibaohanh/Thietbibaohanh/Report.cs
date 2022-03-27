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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            //showReport(fileName);
            showReport("CryReportNhanVien.rpt");
        }

        private void showReport(string fileName, string recordFilter="")
        {
           // CrystalDecisions.CrystalReports.Engine.ReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            ReportDocument rpt = new ReportDocument();
            string path = string.Format("{0}\\{1}",
                Application.StartupPath,
                fileName);
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
            if (!string.IsNullOrEmpty(recordFilter))
                rpt.RecordSelectionFormula= recordFilter;
            CrpNV.ReportSource = rpt;
        }
    }
}
