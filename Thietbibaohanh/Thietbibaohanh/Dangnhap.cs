using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace Thietbibaohanh
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }
        
        private void btnDN_Click(object sender, EventArgs e)
        {
            SqlConnection connec = new SqlConnection(@"Server = DESKTOP-710QFTF\SQLEXPRESS; database = LTHSK; User =sa; pwd=123456");
            try
            {
                connec.Open();
                string sTenDangNhap = txtUser.Text;
                string sMatKhau = txtPw.Text;
                string sql = "select * from dbo.tblNhanVien where sTenDangNhap = '" + sTenDangNhap + "' and sMatKhau = '" + sMatKhau + "'";
                SqlCommand command = new SqlCommand(sql,connec);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMain f = new FormMain();
                    f.ShowDialog();
                    this.Hide();
                    //Application.Exit();
                    //this.Show();
                    //FormMain f = new FormMain();
                    //f.ShowDialog();
                    //f.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)

                Application.Exit();
        }

        private void Dangnhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
