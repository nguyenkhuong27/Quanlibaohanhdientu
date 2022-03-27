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
using System.Configuration;

namespace Thietbibaohanh
{
    public partial class HoaDonBanHang : Form
    {
        public HoaDonBanHang()
        {
            InitializeComponent();
        }

        SqlConnection conec = null;
        string strconnection = @"Server = DESKTOP-710QFTF\SQLEXPRESS; database = LTHSK; User =sa; pwd=123456";
        private void HoaDonBanHang_Load(object sender, EventArgs e)
        {
            Hienthihoadon();
        }

        private void Hienthihoadon()
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from dbo.tblHoaDonBanHang";
            command.Connection = conec;
            SqlDataReader dataReader = command.ExecuteReader();
            lVHoadonban.Items.Clear();
            while (dataReader.Read())
            {
                string PK_MaHoaDon = dataReader.GetString(0);
                string sMaNVLap = dataReader.GetString(1);
                string sMaKH = dataReader.GetString(2);
                DateTime dTGLap = dataReader.GetDateTime(3);
                float fTongTien = (float)dataReader.GetDouble(4);
                string sTTThuTien = dataReader.GetString(5);

                ListViewItem lvi = new ListViewItem(PK_MaHoaDon + "");
                lvi.SubItems.Add(sMaNVLap);
                lvi.SubItems.Add(sMaKH);
                lvi.SubItems.Add(dTGLap + "MM/dd/yyyy");
                lvi.SubItems.Add(fTongTien + "");
                lvi.SubItems.Add(sTTThuTien);
                lVHoadonban.Items.Add(lvi);

                lvi.Tag = PK_MaHoaDon;
            }
            dataReader.Close();
        }

        private void OpenConnection()
        {
            if (conec == null)
            {
                conec = new SqlConnection(strconnection);
            }
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
        }
        private void CloseConnection()
        {
            if (conec != null && conec.State == ConnectionState.Open)
            {
                conec.Close();
            }
        }



        private void lVHoadonban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lVHoadonban.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem lvi = lVHoadonban.SelectedItems[0];
            string PK_MaHoaDon = (string)lvi.Tag;
            Hienchitiet(PK_MaHoaDon);

        }

        private void Hienchitiet(string PK_MaHoaDon)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from dbo.tblHoaDonBanHang where PK_MaHoaDon = @mahoadon";
            command.Connection = conec;
            SqlParameter parameter = new SqlParameter("@mahoadon", SqlDbType.Char);
            parameter.Value = PK_MaHoaDon;
            command.Parameters.Add(parameter);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                string sMaNVLap = dataReader.GetString(1);
                string sMaKH = dataReader.GetString(2);
                DateTime dTGLap = dataReader.GetDateTime(3);
                float fTongTien = (float)dataReader.GetDouble(4);
                string sTTThuTien = dataReader.GetString(5);
                txtMahd.Text = PK_MaHoaDon;
                txtManv.Text = sMaNVLap;
                txtMakh.Text = sMaKH;
                dTTgban.Value = dTGLap;
                txtTongtien.Text = fTongTien + "";
                txtTinhtrang.Text = sTTThuTien;
            }
            dataReader.Close();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            txtMahd.Text = "";
            txtMakh.Text = "";
            txtManv.Text = "";
            dTTgban.ResetText();
            txtTongtien.Text = "";
            txtTinhtrang.SelectedIndex = -1;
            txtMahd.Focus();

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            txtMahd.Text = "";
            txtMakh.Text = "";
            txtManv.Text = "";
            dTTgban.ResetText();
            txtTongtien.Text = "";
            txtTinhtrang.SelectedIndex = -1;
            txtMahd.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //string PK_MaHoaDon = (txtMahd.Text);
            //if (Trungma(PK_MaHoaDon) == true)
            //{
            //    MessageBox.Show("trùng mã");
            //    suathongtin();
            //}
            //else
            //{
            //      themmoi();
            //    }
            //SqlConnection con = new SqlConnection();
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["LTHSK"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {

                    //con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    //con.ConnectionString = ConnectionStrings["con"].ConnectionString;

                    using (SqlCommand cmd = new SqlCommand("addHDBH", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@mahoadon", txtMahd.Text);
                        cmd.Parameters.AddWithValue("@manvlap", txtManv.Text);
                        cmd.Parameters.AddWithValue("@makh", txtMakh.Text);
                        cmd.Parameters.AddWithValue("@tglap", Convert.ToDateTime(dTTgban.Text));
                        cmd.Parameters.AddWithValue("@tongtien", txtTongtien.Text);
                        cmd.Parameters.AddWithValue("@ttthutien", txtTinhtrang.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Thêm mặt hàng thành công", "Kết quả",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // showDSHB();
                        // btnReset_Click(sender, e);
                        Hienthihoadon();
                    }
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("PRIMARY KEY"))
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại!!", "Kết quả",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

        }

        private void suathongtin()
        {

        }

        //private bool Trungma(string pK_MaHoaDon)
        //{
        //    try
        //    {
        //        OpenConnection();
        //        SqlCommand command = new SqlCommand();
        //        command.CommandType = CommandType.Text;
        //        command.CommandText = "select * from dbo.tblHoaDonBanHang where PK_MaHoaDon = @mahoadon";
        //        command.Connection = conec;
        //        SqlParameter parameter = new SqlParameter("@mahoadon", SqlDbType.Char);
        //        parameter.Value = PK_MaHoaDon;
        //        command.Parameters.Add(parameter);
        //        SqlDataReader dataReader = command.ExecuteReader();
        //        bool tm = dataReader.Read();//kiểm tra mã có trong csdl
        //        dataReader.Close();
        //        return tm;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return false;
        //}
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (lVHoadonban.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ListViewItem lvi = lVHoadonban.SelectedItems[0];
            string PK_MaHoaDon = (string)lvi.Tag;
            DialogResult res = MessageBox.Show("Bạn có chắc chắn xóa không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Xoahoadon(PK_MaHoaDon);
            }
            }

        private void Xoahoadon(string PK_MaHoaDon)
        {
            try
            {

                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete from dbo.tblHoaDonBanHang where PK_MaHoaDon = @mahoadon";
                command.Connection = conec;
                command.Parameters.Add("@mahoadon", SqlDbType.Char).Value = PK_MaHoaDon;
                //parameter.Value = PK_MaHoaDon;
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    
                    MessageBox.Show("Xóa thành công");
                    Hienthihoadon();
                    btnXoa.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }



