using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
//using WFA2014._07._21;
namespace Thietbibaohanh
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Dangnhap());
            // Application.Run(new HoaDonBanHang());
            // Application.Run(new Report());
            //Application.Run(new ReportHDBH());
            //Application.Run(new FormMain());
            Application.Run(new NhanVien());

        }

       
        //internal static Report FindForm( string name)
        //{
        //    //throw new NotImplementedException();
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
        //            return (Report)f;
        //        return null;
        //    }
        //}
        //public static 
        //public static Form FindForm(string name)
        //{
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
        //            return f;
        //        return null;
        //    }
        //}
    }
}
