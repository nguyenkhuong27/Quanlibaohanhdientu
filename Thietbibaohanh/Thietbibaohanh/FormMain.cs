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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void quảnLíNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien f = new NhanVien();
            f.ShowDialog();

        }

        private void quảnLíHóaĐơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBanHang h = new HoaDonBanHang();
            h.ShowDialog();
        }
    }
}
