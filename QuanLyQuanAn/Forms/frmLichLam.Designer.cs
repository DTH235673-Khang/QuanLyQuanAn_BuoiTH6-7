namespace QuanLyQuanAn.Forms
{
    partial class frmLichLam
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            btnXuat = new Button();
            btnNhap = new Button();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dtpNgayPhanCong = new DateTimePicker();
            label3 = new Label();
            cboCaLam = new ComboBox();
            label2 = new Label();
            cboNhanVien = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            TenCa = new DataGridViewTextBoxColumn();
            NgayPhanCong = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(dtpNgayPhanCong);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboCaLam);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(18, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(886, 108);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lịch làm";
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(737, 64);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 17;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(637, 64);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 16;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(537, 64);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(437, 64);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 29);
            btnHuyBo.TabIndex = 14;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(337, 64);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 13;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(237, 64);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(137, 64);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(37, 64);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dtpNgayPhanCong
            // 
            dtpNgayPhanCong.Location = new Point(409, 31);
            dtpNgayPhanCong.Name = "dtpNgayPhanCong";
            dtpNgayPhanCong.Size = new Size(250, 27);
            dtpNgayPhanCong.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(337, 33);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 4;
            label3.Text = "Ngày(*):";
            // 
            // cboCaLam
            // 
            cboCaLam.FormattingEnabled = true;
            cboCaLam.Location = new Point(745, 30);
            cboCaLam.Name = "cboCaLam";
            cboCaLam.Size = new Size(133, 28);
            cboCaLam.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(665, 33);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 2;
            label2.Text = "Ca làm(*):";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(123, 30);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(208, 28);
            cboNhanVien.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 33);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên(*):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(18, 131);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(886, 268);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách lịch làm";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTenNhanVien, TenCa, NgayPhanCong });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(880, 242);
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
            // TenCa
            // 
            TenCa.DataPropertyName = "TenCa";
            TenCa.HeaderText = "Ca làm";
            TenCa.MinimumWidth = 6;
            TenCa.Name = "TenCa";
            // 
            // NgayPhanCong
            // 
            NgayPhanCong.DataPropertyName = "NgayPhanCong";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            NgayPhanCong.DefaultCellStyle = dataGridViewCellStyle8;
            NgayPhanCong.HeaderText = "Ngày phân công";
            NgayPhanCong.MinimumWidth = 6;
            NgayPhanCong.Name = "NgayPhanCong";
            // 
            // frmLichLam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 419);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmLichLam";
            Text = "Lịch làm";
            Load += frmLichLam_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private ComboBox cboNhanVien;
        private DateTimePicker dtpNgayPhanCong;
        private Label label3;
        private ComboBox cboCaLam;
        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn TenCa;
        private DataGridViewTextBoxColumn NgayPhanCong;
        private Button btnXuat;
        private Button btnNhap;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
    }
}