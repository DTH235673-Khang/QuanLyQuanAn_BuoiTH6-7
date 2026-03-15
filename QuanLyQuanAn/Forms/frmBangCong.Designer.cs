namespace QuanLyQuanAn.Forms
{
    partial class frmBangCong
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            Ngay = new DataGridViewTextBoxColumn();
            GioVaoThucTe = new DataGridViewTextBoxColumn();
            GioRaThucTe = new DataGridViewTextBoxColumn();
            SoGioLam = new DataGridViewTextBoxColumn();
            btnIn = new Button();
            btnOut = new Button();
            btnXuat = new Button();
            btnXoa = new Button();
            label1 = new Label();
            cboThang = new ComboBox();
            label3 = new Label();
            cboNam = new ComboBox();
            btnXem = new Button();
            btnSua = new Button();
            cboNhanVien = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            txtIn = new TextBox();
            label5 = new Label();
            txtOut = new TextBox();
            btnLuu = new Button();
            btnThem = new Button();
            dtpNgay = new DateTimePicker();
            label6 = new Label();
            btnXuatBangLuong = new Button();
            btnLoad = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Location = new Point(16, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(948, 241);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách chấm công";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTenNhanVien, Ngay, GioVaoThucTe, GioRaThucTe, SoGioLam });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(942, 215);
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
            HoVaTenNhanVien.HeaderText = "Nhân viên";
            HoVaTenNhanVien.MinimumWidth = 6;
            HoVaTenNhanVien.Name = "HoVaTenNhanVien";
            // 
            // Ngay
            // 
            Ngay.DataPropertyName = "Ngay";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            Ngay.DefaultCellStyle = dataGridViewCellStyle1;
            Ngay.HeaderText = "Ngày";
            Ngay.MinimumWidth = 6;
            Ngay.Name = "Ngay";
            // 
            // GioVaoThucTe
            // 
            GioVaoThucTe.DataPropertyName = "GioVaoThucTe";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "t";
            GioVaoThucTe.DefaultCellStyle = dataGridViewCellStyle2;
            GioVaoThucTe.HeaderText = "Giờ vào thực tế";
            GioVaoThucTe.MinimumWidth = 6;
            GioVaoThucTe.Name = "GioVaoThucTe";
            // 
            // GioRaThucTe
            // 
            GioRaThucTe.DataPropertyName = "GioRaThucTe";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "t";
            GioRaThucTe.DefaultCellStyle = dataGridViewCellStyle3;
            GioRaThucTe.HeaderText = "Giờ ra thực tế";
            GioRaThucTe.MinimumWidth = 6;
            GioRaThucTe.Name = "GioRaThucTe";
            // 
            // SoGioLam
            // 
            SoGioLam.DataPropertyName = "SoGioLam";
            dataGridViewCellStyle4.ForeColor = Color.Blue;
            dataGridViewCellStyle4.Format = "N2";
            SoGioLam.DefaultCellStyle = dataGridViewCellStyle4;
            SoGioLam.HeaderText = "Số giờ làm";
            SoGioLam.MinimumWidth = 6;
            SoGioLam.Name = "SoGioLam";
            // 
            // btnIn
            // 
            btnIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIn.ForeColor = Color.FromArgb(0, 192, 0);
            btnIn.Location = new Point(28, 369);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(94, 29);
            btnIn.TabIndex = 1;
            btnIn.Text = "Check In";
            btnIn.UseVisualStyleBackColor = true;
            btnIn.Click += btnIn_Click;
            // 
            // btnOut
            // 
            btnOut.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOut.ForeColor = Color.Red;
            btnOut.Location = new Point(144, 369);
            btnOut.Name = "btnOut";
            btnOut.Size = new Size(94, 29);
            btnOut.TabIndex = 2;
            btnOut.Text = "Check Out";
            btnOut.UseVisualStyleBackColor = true;
            btnOut.Click += btnOut_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(611, 26);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 3;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(264, 369);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 330);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 5;
            label1.Text = "Nhân viên:";
            // 
            // cboThang
            // 
            cboThang.FormattingEnabled = true;
            cboThang.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cboThang.Location = new Point(87, 26);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(151, 28);
            cboThang.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(264, 29);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 9;
            label3.Text = "Năm:";
            // 
            // cboNam
            // 
            cboNam.FormattingEnabled = true;
            cboNam.Items.AddRange(new object[] { "2020", "2021", "2022", "2023", "2024", "2025", "2026" });
            cboNam.Location = new Point(314, 26);
            cboNam.Name = "cboNam";
            cboNam.Size = new Size(151, 28);
            cboNam.TabIndex = 10;
            // 
            // btnXem
            // 
            btnXem.Location = new Point(497, 25);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(94, 29);
            btnXem.TabIndex = 11;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = true;
            btnXem.Click += btnXem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(384, 369);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(112, 327);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(191, 28);
            cboNhanVien.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 29);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 7;
            label2.Text = "Tháng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(334, 330);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 14;
            label4.Text = "IN:";
            // 
            // txtIn
            // 
            txtIn.Location = new Point(366, 328);
            txtIn.Name = "txtIn";
            txtIn.Size = new Size(99, 27);
            txtIn.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(472, 331);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 16;
            label5.Text = "OUT:";
            // 
            // txtOut
            // 
            txtOut.Location = new Point(518, 328);
            txtOut.Name = "txtOut";
            txtOut.Size = new Size(95, 27);
            txtOut.TabIndex = 17;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(628, 369);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 18;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(506, 369);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 19;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dtpNgay
            // 
            dtpNgay.Location = new Point(672, 327);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(250, 27);
            dtpNgay.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(619, 331);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 21;
            label6.Text = "Ngày:";
            // 
            // btnXuatBangLuong
            // 
            btnXuatBangLuong.Location = new Point(726, 26);
            btnXuatBangLuong.Name = "btnXuatBangLuong";
            btnXuatBangLuong.Size = new Size(140, 29);
            btnXuatBangLuong.TabIndex = 22;
            btnXuatBangLuong.Text = "Xuất bảng lương";
            btnXuatBangLuong.UseVisualStyleBackColor = true;
            btnXuatBangLuong.Click += btnXuatBangLuong_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(749, 369);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 23;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // frmBangCong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 411);
            Controls.Add(btnLoad);
            Controls.Add(btnXuatBangLuong);
            Controls.Add(label6);
            Controls.Add(dtpNgay);
            Controls.Add(btnThem);
            Controls.Add(btnLuu);
            Controls.Add(txtOut);
            Controls.Add(label5);
            Controls.Add(txtIn);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(cboNhanVien);
            Controls.Add(btnSua);
            Controls.Add(btnXem);
            Controls.Add(cboNam);
            Controls.Add(label3);
            Controls.Add(cboThang);
            Controls.Add(label1);
            Controls.Add(btnXoa);
            Controls.Add(btnXuat);
            Controls.Add(btnOut);
            Controls.Add(btnIn);
            Controls.Add(groupBox1);
            Name = "frmBangCong";
            Text = "Bảng công";
            Load += frmBangCong_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnIn;
        private Button btnOut;
        private Button btnXuat;
        private Button btnXoa;
        private Label label1;
        private ComboBox cboThang;
        private Label label3;
        private ComboBox cboNam;
        private Button btnXem;
        private Button btnSua;
        private ComboBox cboNhanVien;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn Ngay;
        private DataGridViewTextBoxColumn GioVaoThucTe;
        private DataGridViewTextBoxColumn GioRaThucTe;
        private DataGridViewTextBoxColumn SoGioLam;
        private Label label2;
        private Label label4;
        private TextBox txtIn;
        private Label label5;
        private TextBox txtOut;
        private Button btnLuu;
        private Button btnThem;
        private DateTimePicker dtpNgay;
        private Label label6;
        private Button btnXuatBangLuong;
        private Button btnLoad;
    }
}