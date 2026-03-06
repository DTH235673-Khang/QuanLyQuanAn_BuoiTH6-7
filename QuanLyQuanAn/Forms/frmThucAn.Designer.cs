namespace QuanLyQuanAn.Forms
{
    partial class frmThucAn
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            btnXoaAnh = new Button();
            btnXoayAnh = new Button();
            btnDoiAnh = new Button();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            picHinhAnh = new PictureBox();
            cboTrangThai = new ComboBox();
            numDonGia = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            txtMoTa = new TextBox();
            label4 = new Label();
            txtTenMonAn = new TextBox();
            label3 = new Label();
            cboDonViTinh = new ComboBox();
            label2 = new Label();
            cboPhanLoai = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenDanhMuc = new DataGridViewTextBoxColumn();
            TenDonViTinh = new DataGridViewTextBoxColumn();
            TenThucAn = new DataGridViewTextBoxColumn();
            Gia = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewImageColumn();
            btnNhap = new Button();
            btnXuat = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnXoaAnh);
            groupBox1.Controls.Add(btnXoayAnh);
            groupBox1.Controls.Add(btnDoiAnh);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(numDonGia);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtTenMonAn);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboDonViTinh);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboPhanLoai);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(961, 228);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin món ăn";
            // 
            // btnXoaAnh
            // 
            btnXoaAnh.Location = new Point(849, 119);
            btnXoaAnh.Name = "btnXoaAnh";
            btnXoaAnh.Size = new Size(94, 29);
            btnXoaAnh.TabIndex = 22;
            btnXoaAnh.Text = "Xóa ảnh";
            btnXoaAnh.UseVisualStyleBackColor = true;
            btnXoaAnh.Click += btnXoaAnh_Click;
            // 
            // btnXoayAnh
            // 
            btnXoayAnh.Location = new Point(849, 74);
            btnXoayAnh.Name = "btnXoayAnh";
            btnXoayAnh.Size = new Size(94, 29);
            btnXoayAnh.TabIndex = 21;
            btnXoayAnh.Text = "Xoay ảnh";
            btnXoayAnh.UseVisualStyleBackColor = true;
            btnXoayAnh.Click += btnXoayAnh_Click;
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.Location = new Point(849, 25);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(94, 29);
            btnDoiAnh.TabIndex = 20;
            btnDoiAnh.Text = "Đổi ảnh";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(626, 191);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 19;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(526, 191);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 18;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(426, 191);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 29);
            btnHuyBo.TabIndex = 17;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(326, 191);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 16;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(226, 191);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(126, 193);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(26, 193);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(667, 24);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(176, 157);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 12;
            picHinhAnh.TabStop = false;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Đang hoạt động", "Đã hết món" });
            cboTrangThai.Location = new Point(490, 71);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 11;
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(491, 27);
            numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(150, 27);
            numDonGia.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(390, 74);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 9;
            label6.Text = "Trạng thái(*):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(390, 29);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 8;
            label5.Text = "Đơn giá(*):";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(121, 158);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(520, 27);
            txtMoTa.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 161);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 6;
            label4.Text = "Mô tả:";
            // 
            // txtTenMonAn
            // 
            txtTenMonAn.Location = new Point(121, 116);
            txtTenMonAn.Name = "txtTenMonAn";
            txtTenMonAn.Size = new Size(520, 27);
            txtTenMonAn.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 119);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 4;
            label3.Text = "Tên món ăn(*):";
            // 
            // cboDonViTinh
            // 
            cboDonViTinh.FormattingEnabled = true;
            cboDonViTinh.Location = new Point(121, 71);
            cboDonViTinh.Name = "cboDonViTinh";
            cboDonViTinh.Size = new Size(235, 28);
            cboDonViTinh.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 74);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 2;
            label2.Text = "Đơn vị tính(*):";
            // 
            // cboPhanLoai
            // 
            cboPhanLoai.FormattingEnabled = true;
            cboPhanLoai.Location = new Point(121, 26);
            cboPhanLoai.Name = "cboPhanLoai";
            cboPhanLoai.Size = new Size(235, 28);
            cboPhanLoai.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 29);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Phân loại(*):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(10, 250);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(963, 265);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách món ăn";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, TenDanhMuc, TenDonViTinh, TenThucAn, Gia, TrangThai, HinhAnh });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(957, 239);
            dataGridView.TabIndex = 0;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenDanhMuc
            // 
            TenDanhMuc.DataPropertyName = "TenDanhMuc";
            TenDanhMuc.HeaderText = "Phân loại";
            TenDanhMuc.MinimumWidth = 6;
            TenDanhMuc.Name = "TenDanhMuc";
            // 
            // TenDonViTinh
            // 
            TenDonViTinh.DataPropertyName = "TenDonViTinh";
            TenDonViTinh.HeaderText = "Đơn vị tính";
            TenDonViTinh.MinimumWidth = 6;
            TenDonViTinh.Name = "TenDonViTinh";
            // 
            // TenThucAn
            // 
            TenThucAn.DataPropertyName = "TenThucAn";
            TenThucAn.HeaderText = "Tên món";
            TenThucAn.MinimumWidth = 6;
            TenThucAn.Name = "TenThucAn";
            // 
            // Gia
            // 
            Gia.DataPropertyName = "Gia";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            Gia.DefaultCellStyle = dataGridViewCellStyle2;
            Gia.HeaderText = "Đơn giá";
            Gia.MinimumWidth = 6;
            Gia.Name = "Gia";
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.HeaderText = "Trạng thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            // 
            // HinhAnh
            // 
            HinhAnh.DataPropertyName = "HinhAnh";
            HinhAnh.HeaderText = "Hình ảnh";
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(726, 191);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 23;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(826, 191);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 24;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // frmThucAn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 515);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmThucAn";
            Text = "Món ăn";
            Load += frmThucAn_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label3;
        private ComboBox cboDonViTinh;
        private Label label2;
        private ComboBox cboPhanLoai;
        private PictureBox picHinhAnh;
        private ComboBox cboTrangThai;
        private NumericUpDown numDonGia;
        private Label label6;
        private Label label5;
        private TextBox txtMoTa;
        private Label label4;
        private TextBox txtTenMonAn;
        private Button btnXoaAnh;
        private Button btnXoayAnh;
        private Button btnDoiAnh;
        private Button btnTimKiem;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenDanhMuc;
        private DataGridViewTextBoxColumn TenDonViTinh;
        private DataGridViewTextBoxColumn TenThucAn;
        private DataGridViewTextBoxColumn Gia;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewImageColumn HinhAnh;
        private Button btnXuat;
        private Button btnNhap;
    }
}