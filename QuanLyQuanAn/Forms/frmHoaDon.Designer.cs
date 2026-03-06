namespace QuanLyQuanAn.Forms
{
    partial class frmHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            HoVaTenKhachHang = new DataGridViewTextBoxColumn();
            NgayLap = new DataGridViewTextBoxColumn();
            TongTienHoaDon = new DataGridViewTextBoxColumn();
            XemChiTiet = new DataGridViewLinkColumn();
            btnInHoaDon = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            btnTimKiem = new Button();
            btnXuat = new Button();
            btnNhap = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Location = new Point(13, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(936, 209);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hóa đơn";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTenNhanVien, HoVaTenKhachHang, NgayLap, TongTienHoaDon, XemChiTiet });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(930, 183);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // HoVaTenNhanVien
            // 
            HoVaTenNhanVien.DataPropertyName = "HoVaTenNhanVien";
            HoVaTenNhanVien.HeaderText = "Nhân Viên";
            HoVaTenNhanVien.MinimumWidth = 6;
            HoVaTenNhanVien.Name = "HoVaTenNhanVien";
            // 
            // HoVaTenKhachHang
            // 
            HoVaTenKhachHang.DataPropertyName = "HoVaTenKhachHang";
            HoVaTenKhachHang.HeaderText = "Khách Hàng";
            HoVaTenKhachHang.MinimumWidth = 6;
            HoVaTenKhachHang.Name = "HoVaTenKhachHang";
            // 
            // NgayLap
            // 
            NgayLap.DataPropertyName = "NgayLap";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            NgayLap.DefaultCellStyle = dataGridViewCellStyle1;
            NgayLap.HeaderText = "Ngày Lập";
            NgayLap.MinimumWidth = 6;
            NgayLap.Name = "NgayLap";
            // 
            // TongTienHoaDon
            // 
            TongTienHoaDon.DataPropertyName = "TongTienHoaDon";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Blue;
            dataGridViewCellStyle2.Format = "N2";
            TongTienHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            TongTienHoaDon.HeaderText = "Tổng Tiền";
            TongTienHoaDon.MinimumWidth = 6;
            TongTienHoaDon.Name = "TongTienHoaDon";
            // 
            // XemChiTiet
            // 
            XemChiTiet.DataPropertyName = "XemChiTiet";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            XemChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            XemChiTiet.HeaderText = "Chi Tiết";
            XemChiTiet.MinimumWidth = 6;
            XemChiTiet.Name = "XemChiTiet";
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.ForeColor = Color.Black;
            btnInHoaDon.Location = new Point(147, 226);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(103, 29);
            btnInHoaDon.TabIndex = 2;
            btnInHoaDon.Text = "In hóa đơn...";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(256, 226);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 29);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa...";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(337, 226);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(418, 226);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(499, 226);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(105, 29);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm Kiếm...";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnXuat
            // 
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(610, 226);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(105, 29);
            btnXuat.TabIndex = 7;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(721, 226);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(105, 29);
            btnNhap.TabIndex = 8;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // frmHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 270);
            Controls.Add(btnNhap);
            Controls.Add(btnXuat);
            Controls.Add(btnTimKiem);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnInHoaDon);
            Controls.Add(groupBox1);
            Name = "frmHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa Đơn";
            Load += frmHoaDon_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn HoVaTenKhachHang;
        private DataGridViewTextBoxColumn NgayLap;
        private DataGridViewTextBoxColumn TongTienHoaDon;
        private DataGridViewLinkColumn XemChiTiet;
        private Button btnInHoaDon;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private Button btnTimKiem;
        private Button btnXuat;
        private Button btnNhap;
    }
}