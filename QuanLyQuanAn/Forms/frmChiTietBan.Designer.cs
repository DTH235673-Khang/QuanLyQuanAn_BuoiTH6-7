namespace QuanLyQuanAn.Forms
{
    partial class frmChiTietBan
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
            btnMoBan = new Button();
            btnThanhToan = new Button();
            btnChinhSua = new Button();
            btnChuyenBan = new Button();
            txtBanMoi = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnMoBan
            // 
            btnMoBan.BackColor = Color.FromArgb(0, 192, 0);
            btnMoBan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMoBan.Location = new Point(12, 31);
            btnMoBan.Name = "btnMoBan";
            btnMoBan.Size = new Size(120, 29);
            btnMoBan.TabIndex = 0;
            btnMoBan.Text = "Mở bàn";
            btnMoBan.UseVisualStyleBackColor = false;
            btnMoBan.Click += btnMoBan_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.FromArgb(0, 192, 0);
            btnThanhToan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThanhToan.Location = new Point(138, 31);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(189, 29);
            btnThanhToan.TabIndex = 1;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnChinhSua
            // 
            btnChinhSua.BackColor = Color.FromArgb(0, 192, 0);
            btnChinhSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChinhSua.Location = new Point(333, 31);
            btnChinhSua.Name = "btnChinhSua";
            btnChinhSua.Size = new Size(193, 29);
            btnChinhSua.TabIndex = 2;
            btnChinhSua.Text = "Chỉnh sửa";
            btnChinhSua.UseVisualStyleBackColor = false;
            btnChinhSua.Click += btnChinhSua_Click;
            // 
            // btnChuyenBan
            // 
            btnChuyenBan.BackColor = Color.FromArgb(0, 192, 0);
            btnChuyenBan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChuyenBan.Location = new Point(216, 90);
            btnChuyenBan.Name = "btnChuyenBan";
            btnChuyenBan.Size = new Size(152, 29);
            btnChuyenBan.TabIndex = 4;
            btnChuyenBan.Text = "Chuyển bàn";
            btnChuyenBan.UseVisualStyleBackColor = false;
            btnChuyenBan.Click += btnChuyenBan_Click;
            // 
            // txtBanMoi
            // 
            txtBanMoi.Location = new Point(58, 90);
            txtBanMoi.Name = "txtBanMoi";
            txtBanMoi.Size = new Size(152, 27);
            txtBanMoi.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 94);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 6;
            label1.Text = "Bàn:";
            // 
            // frmChiTietBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 161);
            Controls.Add(label1);
            Controls.Add(txtBanMoi);
            Controls.Add(btnChuyenBan);
            Controls.Add(btnChinhSua);
            Controls.Add(btnThanhToan);
            Controls.Add(btnMoBan);
            Name = "frmChiTietBan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi Tiết Bàn";
            Load += frmChiTietBan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMoBan;
        private Button btnThanhToan;
        private Button btnChinhSua;
        private Button btnChuyenBan;
        private TextBox txtBanMoi;
        private Label label1;
    }
}