
namespace Thietbibaohanh
{
    partial class HoaDonBanHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbThongtin = new System.Windows.Forms.GroupBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTinhtrang = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMakh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtManv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMahd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lVHoadonban = new System.Windows.Forms.ListView();
            this.PK_Ma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sMaNVLap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sMaKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dTGLap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fTongTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sTTThuTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dTTgban = new System.Windows.Forms.DateTimePicker();
            this.btnhuy = new System.Windows.Forms.Button();
            this.gbThongtin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(103, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn bán hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbThongtin
            // 
            this.gbThongtin.Controls.Add(this.btnhuy);
            this.gbThongtin.Controls.Add(this.dTTgban);
            this.gbThongtin.Controls.Add(this.btnIn);
            this.gbThongtin.Controls.Add(this.btnXoa);
            this.gbThongtin.Controls.Add(this.btnLuu);
            this.gbThongtin.Controls.Add(this.btnThem);
            this.gbThongtin.Controls.Add(this.txtTinhtrang);
            this.gbThongtin.Controls.Add(this.label7);
            this.gbThongtin.Controls.Add(this.txtTongtien);
            this.gbThongtin.Controls.Add(this.label6);
            this.gbThongtin.Controls.Add(this.label5);
            this.gbThongtin.Controls.Add(this.txtMakh);
            this.gbThongtin.Controls.Add(this.label4);
            this.gbThongtin.Controls.Add(this.txtManv);
            this.gbThongtin.Controls.Add(this.label3);
            this.gbThongtin.Controls.Add(this.txtMahd);
            this.gbThongtin.Controls.Add(this.label2);
            this.gbThongtin.Location = new System.Drawing.Point(6, 79);
            this.gbThongtin.Name = "gbThongtin";
            this.gbThongtin.Size = new System.Drawing.Size(790, 239);
            this.gbThongtin.TabIndex = 1;
            this.gbThongtin.TabStop = false;
            this.gbThongtin.Text = "Thông tin";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(530, 194);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 15;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(406, 195);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(280, 195);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(163, 196);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTinhtrang
            // 
            this.txtTinhtrang.FormattingEnabled = true;
            this.txtTinhtrang.Items.AddRange(new object[] {
            "Đã thu tiền",
            "Chưa thu tiền"});
            this.txtTinhtrang.Location = new System.Drawing.Point(581, 124);
            this.txtTinhtrang.Name = "txtTinhtrang";
            this.txtTinhtrang.Size = new System.Drawing.Size(121, 21);
            this.txtTinhtrang.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tình trạng thanh toán";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(581, 73);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(117, 20);
            this.txtTongtien.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tổng tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Thời gian bán";
            // 
            // txtMakh
            // 
            this.txtMakh.Location = new System.Drawing.Point(122, 117);
            this.txtMakh.Name = "txtMakh";
            this.txtMakh.Size = new System.Drawing.Size(117, 20);
            this.txtMakh.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã khách hàng";
            // 
            // txtManv
            // 
            this.txtManv.Location = new System.Drawing.Point(122, 69);
            this.txtManv.Name = "txtManv";
            this.txtManv.Size = new System.Drawing.Size(117, 20);
            this.txtManv.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã nhân viên";
            // 
            // txtMahd
            // 
            this.txtMahd.Location = new System.Drawing.Point(122, 26);
            this.txtMahd.Name = "txtMahd";
            this.txtMahd.Size = new System.Drawing.Size(117, 20);
            this.txtMahd.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lVHoadonban);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 253);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn";
            // 
            // lVHoadonban
            // 
            this.lVHoadonban.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PK_Ma,
            this.sMaNVLap,
            this.sMaKH,
            this.dTGLap,
            this.fTongTien,
            this.sTTThuTien});
            this.lVHoadonban.FullRowSelect = true;
            this.lVHoadonban.GridLines = true;
            this.lVHoadonban.HideSelection = false;
            this.lVHoadonban.Location = new System.Drawing.Point(12, 19);
            this.lVHoadonban.Name = "lVHoadonban";
            this.lVHoadonban.Size = new System.Drawing.Size(782, 222);
            this.lVHoadonban.TabIndex = 0;
            this.lVHoadonban.UseCompatibleStateImageBehavior = false;
            this.lVHoadonban.View = System.Windows.Forms.View.Details;
            this.lVHoadonban.SelectedIndexChanged += new System.EventHandler(this.lVHoadonban_SelectedIndexChanged);
            // 
            // PK_Ma
            // 
            this.PK_Ma.Text = "Mã hóa đơn";
            this.PK_Ma.Width = 106;
            // 
            // sMaNVLap
            // 
            this.sMaNVLap.Text = "Mã nhân viên";
            this.sMaNVLap.Width = 136;
            // 
            // sMaKH
            // 
            this.sMaKH.Text = "Mã khách hàng";
            this.sMaKH.Width = 116;
            // 
            // dTGLap
            // 
            this.dTGLap.Text = "Thời gian bán";
            this.dTGLap.Width = 137;
            // 
            // fTongTien
            // 
            this.fTongTien.Text = "Tổng tiền";
            this.fTongTien.Width = 151;
            // 
            // sTTThuTien
            // 
            this.sTTThuTien.Text = "Tình trạng";
            this.sTTThuTien.Width = 128;
            // 
            // dTTgban
            // 
            this.dTTgban.Location = new System.Drawing.Point(581, 25);
            this.dTTgban.Name = "dTTgban";
            this.dTTgban.Size = new System.Drawing.Size(179, 20);
            this.dTTgban.TabIndex = 3;
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(627, 195);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(75, 23);
            this.btnhuy.TabIndex = 16;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // HoaDonBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbThongtin);
            this.Controls.Add(this.label1);
            this.Name = "HoaDonBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoadonbanhang";
            this.Load += new System.EventHandler(this.HoaDonBanHang_Load);
            this.gbThongtin.ResumeLayout(false);
            this.gbThongtin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbThongtin;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox txtTinhtrang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMakh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtManv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMahd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lVHoadonban;
        private System.Windows.Forms.ColumnHeader PK_Ma;
        private System.Windows.Forms.ColumnHeader sMaNVLap;
        private System.Windows.Forms.ColumnHeader sMaKH;
        private System.Windows.Forms.ColumnHeader dTGLap;
        private System.Windows.Forms.ColumnHeader fTongTien;
        private System.Windows.Forms.ColumnHeader sTTThuTien;
        private System.Windows.Forms.DateTimePicker dTTgban;
        private System.Windows.Forms.Button btnhuy;
    }
}

