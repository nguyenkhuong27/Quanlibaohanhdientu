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
using System.Data;
namespace Thietbibaohanh
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        private void NhanVien_Load(object sender, EventArgs e)
        {
            showDSNV();
        }
        private DataTable getNV()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LTHSK"].ConnectionString;

            SqlCommand cmd = new SqlCommand("hienNV", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable tblNhanVien = new DataTable("tblNhanVien");
                da.Fill(tblNhanVien);
                return tblNhanVien;
            }
        }
        public void showDSNV()
        {
            using (DataTable tblNhanVien = getNV())
            {
                DataView dv = new DataView(tblNhanVien);
                dgvDVNhanvien.AutoGenerateColumns = false;
                dgvDVNhanvien.DataSource = dv;
                 btnXoa.Enabled = (dgvDVNhanvien.Rows.Count >= 0);
            }

        }
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LTHSK"].ConnectionString;
           // string procedureName = string.IsNullOrEmpty(value: btnThem.Tag.ToString()) ? "addNV" : "updateNV";
            //string PK_MaNV = Convert.ToString("" + btnThem.Tag);
            SqlCommand cmd = new SqlCommand("addNV", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@manhanvien", txtManv.Text);
            //if (PK_MaNV == "")
            //    cmd.Parameters["@manv"].Direction = ParameterDirection.Output;
            //else
            //    cmd.Parameters["@manv"].Value = PK_MaNV;
            cmd.Parameters.AddWithValue("@tennhanvien", txtTennv.Text);
            cmd.Parameters.AddWithValue("@gioitinh", txtGioitinh.Text);
            cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
            cmd.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(dtPNgaysinhnv.Text));
            cmd.Parameters.AddWithValue("@hsl", txtHsl.Text);
            cmd.Parameters.AddWithValue("@tendn", txtTendn.Text);
            cmd.Parameters.AddWithValue("@matkhau", txtMatkhau.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm nhân viên đã thêm thành công", "Kết quả",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            showDSNV();
            btnBoqua_Click(sender, e);
        }
       

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvNV = (DataView)dgvDVNhanvien.DataSource;
            DataRowView drvNV = dvNV[dgvDVNhanvien.CurrentRow.Index];

            string conn = ConfigurationManager.ConnectionStrings["LTHSK"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("updateNV", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manv", drvNV["PK_MaNV"]);
                    cmd.Parameters.AddWithValue("@tennhanvien", txtTennv.Text);
                    cmd.Parameters.AddWithValue("@gioitinh", txtGioitinh.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(dtPNgaysinhnv.Text));
                    cmd.Parameters.AddWithValue("@hsl", txtHsl.Text);
                    cmd.Parameters.AddWithValue("@tendn", txtTendn.Text);
                    cmd.Parameters.AddWithValue("@matkhau", txtMatkhau.Text);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Sửa nhân viên thành công", "Kết quả",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    showDSNV();


                }
            }
        }

        //private void chuyentrangthaisua(DataRowView drvNV)
        //{
        //    txtManv.Text = drvNV["PK_MaNV"].ToString();
        //    txtTennv.Text = drvNV["sTenNV"].ToString();
        //    txtGioitinh.Text = drvNV["sGioiTinh"].ToString();
        //    txtDiachi.Text = drvNV["sDiaChi"].ToString();
        //    dtPNgaysinhnv.Text = Convert.ToString(drvNV["dNgaysinh"]);
        //    txtHsl.Text = drvNV["fHSL"].ToString();
        //    txtTendn.Text = drvNV["sTenDangNhap"].ToString();
        //    txtMatkhau.Text = drvNV["sMatKhau"].ToString();

        //    btnThem.Text = "Cập nhật";
        //    btnThem.Tag = drvNV["PK_MaNV"].ToString();
        //    //btnSua.Enabled = btnXoa.Enabled = false;
        //txtManv.Text = drvNV["PK_MaNV"].ToString();
        //txtTennv.Text = drvNV["sTenNV"].ToString();
        //txtGioitinh.Text = drvNV["sGioiTinh"].ToString();
        //txtDiachi.Text = drvNV["sDiaChi"].ToString();
        //dtPNgaysinhnv.Text = Convert.ToString(drvNV["dNgaysinh"]);
        //txtHsl.Text = drvNV["fHSL"].ToString();
        //txtTendn.Text = drvNV["sTenDangNhap"].ToString();
        //txtMatkhau.Text = drvNV["sMatKhau"].ToString();
        //con.Open();
        //cmd.ExecuteNonQuery();
        //con.Close();
        //MessageBox.Show("Sửa nhân viên đã thêm thành công", "Kết quả",
        //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            txtManv.Text =
           txtTennv.Text =
           txtGioitinh.Text =
           txtDiachi.Text =
           txtHsl.Text =
           txtTendn.Text =
           txtMatkhau.Text = string.Empty;
            dtPNgaysinhnv.ResetText();
            txtManv.Focus();
           // btnSua.Enabled = btnXoa.Enabled = false;

            btnThem.Text = "Thêm mới";
            btnThem.Tag = string.Empty;
            showDSNV();
        }

        private void txtManv_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = (txtManv.Text.Trim().Length > 0);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có thật sự muốn xóa không?", "Khẳng định", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.No)
                return;
            try
            {
                DataView dvNV = (DataView)dgvDVNhanvien.DataSource;
                DataRowView drvNV = dvNV[dgvDVNhanvien.CurrentRow.Index];

                con.ConnectionString = ConfigurationManager.ConnectionStrings["LTHSK"].ConnectionString;

                con.ConnectionString = ConfigurationManager.ConnectionStrings["LTHSK"].ConnectionString;

                SqlCommand cmd = new SqlCommand("deleteNV", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@manv", drvNV["PK_MaNV"]);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                showDSNV();
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("foreign"))
                {
                    MessageBox.Show("Đang có dữ liệu liên quan, không xóa được", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi,thật tiếc!!!");
                }
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LTHSK"].ConnectionString;
            SqlCommand cmd = new SqlCommand("searchNV", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@manv", txtManv.Text);
            cmd.Parameters.AddWithValue("@tennhanvien", txtTennv.Text);
           
            con.Open();
            cmd.ExecuteNonQuery();
            //showDSNV();

            //Load dữ liệu
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dgvDVNhanvien.DataSource = dt;
            con.Close();

           
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string fillter = "{tblNhanVien.PK_MaNV}>0";
            if (!string.IsNullOrEmpty(txtManv.Text.Trim()))
                fillter += string.Format(" and{1} LIKE '{0}'",
                    txtManv.Text,
                    "{tblNhanVien.PK_MaNV}");
            if (!string.IsNullOrEmpty(txtTennv.Text.Trim()))
                fillter += string.Format(" and {1} LIKE '{0}'", 
                    txtTennv.Text
                    , "{tblNhanVien.sTenNV}");

            //Report rp = Program.FindForm("Report");
            //if (rp == null)
            //{
            //    rp = new Report();
            //}
            //rp.Show();
            //////rp.ShowReport("CryReportNhanVien.rpt",
            ////      fillter,
            ////      "Danh sách nhân viên");
            //rp.Activate();


            {
            }
        }

        private void dgvDVNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtManv.Text = dgvDVNhanvien.CurrentRow.Cells[0].Value.ToString();
            txtTennv.Text = dgvDVNhanvien.CurrentRow.Cells[1].Value.ToString();
            txtGioitinh.Text = dgvDVNhanvien.CurrentRow.Cells[2].Value.ToString();
            txtDiachi.Text = dgvDVNhanvien.CurrentRow.Cells[3].Value.ToString();
            dtPNgaysinhnv.Text = dgvDVNhanvien.CurrentRow.Cells[4].Value.ToString();
            txtHsl.Text = dgvDVNhanvien.CurrentRow.Cells[0].Value.ToString();
            txtTendn.Text = dgvDVNhanvien.CurrentRow.Cells[0].Value.ToString();
            txtMatkhau.Text = dgvDVNhanvien.CurrentRow.Cells[0].Value.ToString();
        }
    }
}

