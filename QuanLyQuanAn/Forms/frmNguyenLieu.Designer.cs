namespace QuanLyQuanAn.Forms
{
    partial class frmNguyenLieu
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenNguyenLieu = new DataGridViewTextBoxColumn();
            QuyCach = new DataGridViewTextBoxColumn();
            SoLuongTon = new DataGridViewTextBoxColumn();
            GiaNhap = new DataGridViewTextBoxColumn();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            numGiaNhap = new NumericUpDown();
            label5 = new Label();
            txtTenNguyenLieu = new TextBox();
            cboQuyCach = new ComboBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            numSoLuongTon = new NumericUpDown();
            label3 = new Label();
            label6 = new Label();
            btnNhap = new Button();
            btnXuat = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuongTon).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(12, 184);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(931, 265);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách món ăn";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, TenNguyenLieu, QuyCach, SoLuongTon, GiaNhap });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(925, 239);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenNguyenLieu
            // 
            TenNguyenLieu.DataPropertyName = "TenNguyenLieu";
            TenNguyenLieu.HeaderText = "Nguyên liệu";
            TenNguyenLieu.MinimumWidth = 6;
            TenNguyenLieu.Name = "TenNguyenLieu";
            // 
            // QuyCach
            // 
            QuyCach.DataPropertyName = "QuyCach";
            QuyCach.HeaderText = "Quy cách";
            QuyCach.MinimumWidth = 6;
            QuyCach.Name = "QuyCach";
            // 
            // SoLuongTon
            // 
            SoLuongTon.DataPropertyName = "SoLuongTon";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Format = "N2";
            SoLuongTon.DefaultCellStyle = dataGridViewCellStyle3;
            SoLuongTon.HeaderText = "Số lượng tồn";
            SoLuongTon.MinimumWidth = 6;
            SoLuongTon.Name = "SoLuongTon";
            // 
            // GiaNhap
            // 
            GiaNhap.DataPropertyName = "GiaNhap";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = Color.Blue;
            dataGridViewCellStyle4.Format = "N2";
            GiaNhap.DefaultCellStyle = dataGridViewCellStyle4;
            GiaNhap.HeaderText = "Giá nhập";
            GiaNhap.MinimumWidth = 6;
            GiaNhap.Name = "GiaNhap";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(615, 110);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 19;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(515, 110);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 18;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(415, 110);
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
            btnLuu.Location = new Point(315, 110);
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
            btnXoa.Location = new Point(215, 110);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(115, 112);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(15, 112);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // numGiaNhap
            // 
            numGiaNhap.Location = new Point(507, 27);
            numGiaNhap.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numGiaNhap.Name = "numGiaNhap";
            numGiaNhap.Size = new Size(239, 27);
            numGiaNhap.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(390, 29);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 8;
            label5.Text = "Giá nhập(*):";
            // 
            // txtTenNguyenLieu
            // 
            txtTenNguyenLieu.Location = new Point(152, 24);
            txtTenNguyenLieu.Name = "txtTenNguyenLieu";
            txtTenNguyenLieu.Size = new Size(204, 27);
            txtTenNguyenLieu.TabIndex = 5;
            // 
            // cboQuyCach
            // 
            cboQuyCach.FormattingEnabled = true;
            cboQuyCach.Items.AddRange(new object[] { "KG", "PAK" });
            cboQuyCach.Location = new Point(121, 71);
            cboQuyCach.Name = "cboQuyCach";
            cboQuyCach.Size = new Size(235, 28);
            cboQuyCach.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 74);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 2;
            label2.Text = "Quy cách(*):";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(numSoLuongTon);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(numGiaNhap);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtTenNguyenLieu);
            groupBox1.Controls.Add(cboQuyCach);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(931, 166);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nguyên liệu";
            // 
            // numSoLuongTon
            // 
            numSoLuongTon.Location = new Point(507, 71);
            numSoLuongTon.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numSoLuongTon.Name = "numSoLuongTon";
            numSoLuongTon.Size = new Size(239, 27);
            numSoLuongTon.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 29);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 23;
            label3.Text = "Tên nguyên liệu(*):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(390, 74);
            label6.Name = "label6";
            label6.Size = new Size(114, 20);
            label6.TabIndex = 9;
            label6.Text = "Số lượng tồn(*):";
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(715, 110);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 25;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(815, 110);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 26;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // frmNguyenLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 462);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmNguyenLieu";
            Text = "Nguyên liệu";
            Load += frmNguyenLieu_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuongTon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button btnTimKiem;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private NumericUpDown numGiaNhap;
        private Label label5;
        private TextBox txtTenNguyenLieu;
        private ComboBox cboQuyCach;
        private Label label2;
        private GroupBox groupBox1;
        private Label label3;
        private Label label6;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenNguyenLieu;
        private DataGridViewTextBoxColumn QuyCach;
        private DataGridViewTextBoxColumn SoLuongTon;
        private DataGridViewTextBoxColumn GiaNhap;
        private NumericUpDown numSoLuongTon;
        private Button btnNhap;
        private Button btnXuat;
    }
}