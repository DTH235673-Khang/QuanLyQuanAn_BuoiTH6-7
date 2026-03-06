namespace QuanLyQuanAn.Forms
{
    partial class frmPhieuNhapKho_ChiTiet
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
            btnThoat = new Button();
            btnLuuPhieu = new Button();
            btnXoa = new Button();
            btnXacNhanBan = new Button();
            numSoLuongNhap = new NumericUpDown();
            label6 = new Label();
            numDonGiaNhap = new NumericUpDown();
            label5 = new Label();
            cboNguyenLieu = new ComboBox();
            label4 = new Label();
            btnInPhieu = new Button();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            cboNhaCungCap = new ComboBox();
            cboNhanVien = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtGhiChu = new TextBox();
            label3 = new Label();
            NguyenLieuID = new DataGridViewTextBoxColumn();
            TenNguyenLieu = new DataGridViewTextBoxColumn();
            GiaNhap = new DataGridViewTextBoxColumn();
            SoLuongNhap = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numSoLuongNhap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaNhap).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Red;
            btnThoat.Location = new Point(534, 443);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(123, 29);
            btnThoat.TabIndex = 20;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.ForeColor = Color.Blue;
            btnLuuPhieu.Location = new Point(276, 443);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(123, 29);
            btnLuuPhieu.TabIndex = 18;
            btnLuuPhieu.Text = "Lưu phiếu...";
            btnLuuPhieu.UseVisualStyleBackColor = true;
            btnLuuPhieu.Click += btnLuuPhieu_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(790, 60);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(123, 29);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXacNhanBan
            // 
            btnXacNhanBan.Location = new Point(661, 59);
            btnXacNhanBan.Name = "btnXacNhanBan";
            btnXacNhanBan.Size = new Size(123, 29);
            btnXacNhanBan.TabIndex = 11;
            btnXacNhanBan.Text = "Xác nhận nhập";
            btnXacNhanBan.UseVisualStyleBackColor = true;
            btnXacNhanBan.Click += btnXacNhanBan_Click;
            // 
            // numSoLuongNhap
            // 
            numSoLuongNhap.Location = new Point(448, 61);
            numSoLuongNhap.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuongNhap.Name = "numSoLuongNhap";
            numSoLuongNhap.Size = new Size(191, 27);
            numSoLuongNhap.TabIndex = 10;
            numSoLuongNhap.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(448, 38);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 9;
            label6.Text = "Số lượng nhập(*):";
            // 
            // numDonGiaNhap
            // 
            numDonGiaNhap.Location = new Point(250, 62);
            numDonGiaNhap.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGiaNhap.Name = "numDonGiaNhap";
            numDonGiaNhap.Size = new Size(191, 27);
            numDonGiaNhap.TabIndex = 8;
            numDonGiaNhap.ThousandsSeparator = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 38);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 7;
            label5.Text = "Giá nhập(*):";
            // 
            // cboNguyenLieu
            // 
            cboNguyenLieu.FormattingEnabled = true;
            cboNguyenLieu.Location = new Point(27, 61);
            cboNguyenLieu.Name = "cboNguyenLieu";
            cboNguyenLieu.Size = new Size(216, 28);
            cboNguyenLieu.TabIndex = 6;
            cboNguyenLieu.SelectionChangeCommitted += cboNguyenLieu_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 38);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 6;
            label4.Text = "Nguyên liệu(*):";
            // 
            // btnInPhieu
            // 
            btnInPhieu.Location = new Point(405, 443);
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.Size = new Size(123, 29);
            btnInPhieu.TabIndex = 19;
            btnInPhieu.Text = "In phiếu...";
            btnInPhieu.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnXacNhanBan);
            groupBox2.Controls.Add(numSoLuongNhap);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numDonGiaNhap);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cboNguyenLieu);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(8, 143);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(921, 294);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết phiếu";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { NguyenLieuID, TenNguyenLieu, GiaNhap, SoLuongNhap, ThanhTien });
            dataGridView.Location = new Point(14, 106);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(899, 188);
            dataGridView.TabIndex = 13;
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(585, 33);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(289, 28);
            cboNhaCungCap.TabIndex = 3;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(151, 33);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(303, 28);
            cboNhanVien.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(460, 36);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhà cung cấp(*):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 36);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên lập(*):";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboNhaCungCap);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(8, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(921, 125);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập kho";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(94, 79);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(780, 27);
            txtGhiChu.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 82);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 4;
            label3.Text = "Ghi chú:";
            // 
            // NguyenLieuID
            // 
            NguyenLieuID.DataPropertyName = "NguyenLieuID";
            NguyenLieuID.HeaderText = "ID";
            NguyenLieuID.MinimumWidth = 6;
            NguyenLieuID.Name = "NguyenLieuID";
            // 
            // TenNguyenLieu
            // 
            TenNguyenLieu.DataPropertyName = "TenNguyenLieu";
            TenNguyenLieu.HeaderText = "Nguyên liệu";
            TenNguyenLieu.MinimumWidth = 6;
            TenNguyenLieu.Name = "TenNguyenLieu";
            // 
            // GiaNhap
            // 
            GiaNhap.DataPropertyName = "GiaNhap";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N2";
            GiaNhap.DefaultCellStyle = dataGridViewCellStyle1;
            GiaNhap.HeaderText = "Giá nhập";
            GiaNhap.MinimumWidth = 6;
            GiaNhap.Name = "GiaNhap";
            // 
            // SoLuongNhap
            // 
            SoLuongNhap.DataPropertyName = "SoLuongNhap";
            SoLuongNhap.HeaderText = "Số lượng";
            SoLuongNhap.MinimumWidth = 6;
            SoLuongNhap.Name = "SoLuongNhap";
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = Color.Blue;
            dataGridViewCellStyle2.Format = "N2";
            ThanhTien.DefaultCellStyle = dataGridViewCellStyle2;
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            // 
            // frmPhieuNhapKho_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 488);
            Controls.Add(btnThoat);
            Controls.Add(btnLuuPhieu);
            Controls.Add(btnInPhieu);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmPhieuNhapKho_ChiTiet";
            Text = "Phiếu nhập kho chi tiết";
            Load += frmPhieuNhapKho_ChiTiet_Load;
            ((System.ComponentModel.ISupportInitialize)numSoLuongNhap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaNhap).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnThoat;
        private Button btnLuuPhieu;
        private Button btnXoa;
        private Button btnXacNhanBan;
        private NumericUpDown numSoLuongNhap;
        private Label label6;
        private NumericUpDown numDonGiaNhap;
        private Label label5;
        private ComboBox cboNguyenLieu;
        private Label label4;
        private Button btnInPhieu;
        private GroupBox groupBox2;
        private ComboBox cboNhaCungCap;
        private ComboBox cboNhanVien;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtGhiChu;
        private Label label3;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn NguyenLieuID;
        private DataGridViewTextBoxColumn TenNguyenLieu;
        private DataGridViewTextBoxColumn GiaNhap;
        private DataGridViewTextBoxColumn SoLuongNhap;
        private DataGridViewTextBoxColumn ThanhTien;
    }
}