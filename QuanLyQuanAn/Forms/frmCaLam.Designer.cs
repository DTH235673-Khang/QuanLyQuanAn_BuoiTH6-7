namespace QuanLyQuanAn.Forms
{
    partial class frmCaLam
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
            groupBox1 = new GroupBox();
            txtGioBatDau = new TextBox();
            txtGioKetThuc = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnXuat = new Button();
            btnNhap = new Button();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTenCaLam = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenCa = new DataGridViewTextBoxColumn();
            GioBatDau = new DataGridViewTextBoxColumn();
            GioKetThuc = new DataGridViewTextBoxColumn();
            HeSoLuong = new DataGridViewTextBoxColumn();
            txtHeSoLuong = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtHeSoLuong);
            groupBox1.Controls.Add(txtGioBatDau);
            groupBox1.Controls.Add(txtGioKetThuc);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtTenCaLam);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(22, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(815, 176);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin ca làm";
            // 
            // txtGioBatDau
            // 
            txtGioBatDau.Location = new Point(147, 71);
            txtGioBatDau.Name = "txtGioBatDau";
            txtGioBatDau.Size = new Size(235, 27);
            txtGioBatDau.TabIndex = 17;
            // 
            // txtGioKetThuc
            // 
            txtGioKetThuc.Location = new Point(526, 71);
            txtGioKetThuc.Name = "txtGioKetThuc";
            txtGioKetThuc.Size = new Size(235, 27);
            txtGioKetThuc.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(407, 74);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 13;
            label4.Text = "Giờ kết thúc(*): ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(407, 38);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 12;
            label3.Text = "Hệ số lương(*): ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 74);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 10;
            label2.Text = "Giờ bắt đầu(*): ";
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(707, 112);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 9;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(607, 112);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 8;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(507, 112);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(407, 112);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 29);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(307, 112);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(207, 112);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(107, 112);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(7, 112);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenCaLam
            // 
            txtTenCaLam.Location = new Point(147, 35);
            txtTenCaLam.Name = "txtTenCaLam";
            txtTenCaLam.Size = new Size(235, 27);
            txtTenCaLam.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 38);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên ca làm(*): ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(22, 194);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(815, 293);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách ca làm";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, TenCa, GioBatDau, GioKetThuc, HeSoLuong });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(809, 267);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenCa
            // 
            TenCa.DataPropertyName = "TenCa";
            TenCa.HeaderText = "Tên ca làm";
            TenCa.MinimumWidth = 6;
            TenCa.Name = "TenCa";
            // 
            // GioBatDau
            // 
            GioBatDau.DataPropertyName = "GioBatDau";
            GioBatDau.HeaderText = "Giờ băt đầu";
            GioBatDau.MinimumWidth = 6;
            GioBatDau.Name = "GioBatDau";
            // 
            // GioKetThuc
            // 
            GioKetThuc.DataPropertyName = "GioKetThuc";
            GioKetThuc.HeaderText = "Giờ kết thúc";
            GioKetThuc.MinimumWidth = 6;
            GioKetThuc.Name = "GioKetThuc";
            // 
            // HeSoLuong
            // 
            HeSoLuong.DataPropertyName = "HeSoLuong";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            HeSoLuong.DefaultCellStyle = dataGridViewCellStyle1;
            HeSoLuong.HeaderText = "Hệ số lương";
            HeSoLuong.MinimumWidth = 6;
            HeSoLuong.Name = "HeSoLuong";
            // 
            // txtHeSoLuong
            // 
            txtHeSoLuong.Location = new Point(526, 35);
            txtHeSoLuong.Name = "txtHeSoLuong";
            txtHeSoLuong.Size = new Size(235, 27);
            txtHeSoLuong.TabIndex = 18;
            // 
            // frmCaLam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 496);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "frmCaLam";
            Text = "Ca Làm";
            Load += frmCaLam_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnXuat;
        private Button btnNhap;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtTenCaLam;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtGioKetThuc;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtGioBatDau;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenCa;
        private DataGridViewTextBoxColumn GioBatDau;
        private DataGridViewTextBoxColumn GioKetThuc;
        private DataGridViewTextBoxColumn HeSoLuong;
        private TextBox txtHeSoLuong;
    }
}