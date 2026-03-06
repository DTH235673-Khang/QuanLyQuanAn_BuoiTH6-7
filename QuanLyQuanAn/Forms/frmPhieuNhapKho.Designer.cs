namespace QuanLyQuanAn.Forms
{
    partial class frmPhieuNhapKho
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NgayNhap = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            TenNhaCungCap = new DataGridViewTextBoxColumn();
            TongTien = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            XemChiTiet = new DataGridViewLinkColumn();
            btnXuat = new Button();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnInPhieu = new Button();
            btnTaoPhieu = new Button();
            btnNhap = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(936, 209);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách phiếu nhập kho";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, NgayNhap, HoVaTenNhanVien, TenNhaCungCap, TongTien, TrangThai, XemChiTiet });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
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
            // NgayNhap
            // 
            NgayNhap.DataPropertyName = "NgayNhap";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            NgayNhap.DefaultCellStyle = dataGridViewCellStyle5;
            NgayNhap.FillWeight = 85.47237F;
            NgayNhap.HeaderText = "Ngày nhập";
            NgayNhap.MinimumWidth = 6;
            NgayNhap.Name = "NgayNhap";
            // 
            // HoVaTenNhanVien
            // 
            HoVaTenNhanVien.DataPropertyName = "HoVaTenNhanVien";
            HoVaTenNhanVien.FillWeight = 85.47237F;
            HoVaTenNhanVien.HeaderText = "Nhân viên";
            HoVaTenNhanVien.MinimumWidth = 6;
            HoVaTenNhanVien.Name = "HoVaTenNhanVien";
            // 
            // TenNhaCungCap
            // 
            TenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            TenNhaCungCap.FillWeight = 85.47237F;
            TenNhaCungCap.HeaderText = "Nhà cung cấp";
            TenNhaCungCap.MinimumWidth = 6;
            TenNhaCungCap.Name = "TenNhaCungCap";
            // 
            // TongTien
            // 
            TongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = Color.Blue;
            dataGridViewCellStyle6.Format = "N2";
            TongTien.DefaultCellStyle = dataGridViewCellStyle6;
            TongTien.FillWeight = 85.47237F;
            TongTien.HeaderText = "Tổng tiền";
            TongTien.MinimumWidth = 6;
            TongTien.Name = "TongTien";
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.FillWeight = 85.47237F;
            TrangThai.HeaderText = "Trạng thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            // 
            // XemChiTiet
            // 
            XemChiTiet.DataPropertyName = "XemChiTiet";
            XemChiTiet.FillWeight = 85.47237F;
            XemChiTiet.HeaderText = "Chi tiết";
            XemChiTiet.MinimumWidth = 6;
            XemChiTiet.Name = "XemChiTiet";
            // 
            // btnXuat
            // 
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(669, 224);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(105, 29);
            btnXuat.TabIndex = 14;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(558, 224);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(105, 29);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm Kiếm...";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(477, 224);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 29);
            btnThoat.TabIndex = 12;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(396, 224);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(315, 224);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 29);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa...";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnInPhieu
            // 
            btnInPhieu.ForeColor = Color.Black;
            btnInPhieu.Location = new Point(206, 224);
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.Size = new Size(103, 29);
            btnInPhieu.TabIndex = 9;
            btnInPhieu.Text = "In phiếu...";
            btnInPhieu.UseVisualStyleBackColor = true;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.ForeColor = Color.Black;
            btnTaoPhieu.Location = new Point(75, 224);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(126, 29);
            btnTaoPhieu.TabIndex = 15;
            btnTaoPhieu.Text = "Tạo phiếu mới";
            btnTaoPhieu.UseVisualStyleBackColor = true;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // btnNhap
            // 
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(780, 224);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(105, 29);
            btnNhap.TabIndex = 16;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // frmPhieuNhapKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 260);
            Controls.Add(btnNhap);
            Controls.Add(btnTaoPhieu);
            Controls.Add(groupBox1);
            Controls.Add(btnXuat);
            Controls.Add(btnTimKiem);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnInPhieu);
            Name = "frmPhieuNhapKho";
            Text = "Phiếu nhập kho";
            Load += frmPhieuNhapKho_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnXuat;
        private Button btnTimKiem;
        private Button btnThoat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnInPhieu;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NgayNhap;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn TenNhaCungCap;
        private DataGridViewTextBoxColumn TongTien;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewLinkColumn XemChiTiet;
        private Button btnTaoPhieu;
        private Button btnNhap;
    }
}