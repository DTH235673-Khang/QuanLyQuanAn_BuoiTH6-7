using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmPhieuNhapKho_ChiTiet : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        string tablename = "";
        BindingList<DanhSachPhieuNhapKho_ChiTiet> phieuNhapKhoChiTiet = new BindingList<DanhSachPhieuNhapKho_ChiTiet>();

        public frmPhieuNhapKho_ChiTiet(int maPhieu)
        {
            InitializeComponent();
            id = maPhieu;
        }
        public frmPhieuNhapKho_ChiTiet()
        {
            InitializeComponent();
        }
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }
        public void LayNhaCungCapVaoComboBox()
        {
            cboNhaCungCap.DataSource = context.NhaCungCap.ToList();
            cboNhaCungCap.ValueMember = "ID";
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
        }
        public void LayNguyenLieuVaoComboBox()
        {
            cboNguyenLieu.DataSource = context.NguyenLieu.ToList();
            cboNguyenLieu.ValueMember = "ID";
            cboNguyenLieu.DisplayMember = "TenNguyenLieu";
        }
        public void BatTatChucNang()
        {
            if (id == 0 && dataGridView.Rows.Count == 0) // Thêm
            {
                // Xóa trắng các trường
                cboNhaCungCap.Text = "";
                cboNhanVien.Text = "";
                cboNguyenLieu.Text = "";
                numSoLuongNhap.Value = 1;
                numDonGiaNhap.Value = 0;
            }
            // Nút lưu và xóa chỉ sáng khi có sản phẩm
            btnLuuPhieu.Enabled = dataGridView.Rows.Count > 0;
            btnXoa.Enabled = dataGridView.Rows.Count > 0;
        }

        private void frmPhieuNhapKho_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayNhaCungCapVaoComboBox();
            LayNguyenLieuVaoComboBox();
            dataGridView.AutoGenerateColumns = false;

            if (id != 0) // Đã tồn tại chi tiết
            {
                var phieuNhapKho = context.PhieuNhapKho.Where(r => r.ID == id).SingleOrDefault();
                cboNhanVien.SelectedValue = phieuNhapKho.NhanVienID;
                cboNhaCungCap.SelectedValue = phieuNhapKho.NhaCungCapID;
                txtGhiChu.Text = phieuNhapKho.GhiChu;
                var ct = context.PhieuNhapKho_ChiTiet.Where(r => r.PhieuNhapKhoID == id).Select(r => new DanhSachPhieuNhapKho_ChiTiet
                {
                    ID = r.ID,
                    PhieuNhapKhoID = r.PhieuNhapKhoID,
                    NguyenLieuID = r.NguyenLieuID,
                    TenNguyenLieu = r.NguyenLieu.TenNguyenLieu,
                    SoLuongNhap = r.SoLuongNhap,
                    GiaNhap = r.GiaNhap,
                    ThanhTien = Convert.ToInt32(r.SoLuongNhap * r.GiaNhap)
                }).ToList();
                phieuNhapKhoChiTiet = new BindingList<DanhSachPhieuNhapKho_ChiTiet>(ct);
            }
            dataGridView.DataSource = phieuNhapKhoChiTiet;
            BatTatChucNang();
        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNguyenLieu.Text))
                MessageBox.Show("Vui lòng chọn nguyên liệu cần nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuongNhap.Value <= 0)
                MessageBox.Show("Số lượng nhập phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGiaNhap.Value <= 0)
                MessageBox.Show("Đơn giá nhập sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            {
                int maSanPham = Convert.ToInt32(cboNguyenLieu.SelectedValue.ToString());
                var chiTiet = phieuNhapKhoChiTiet.FirstOrDefault(x => x.NguyenLieuID == maSanPham);
                // Nếu đã tồn tại sản phẩm thì cập nhật thông tin 
                if (chiTiet != null)
                {
                    chiTiet.SoLuongNhap = Convert.ToInt32(numSoLuongNhap.Value);
                    chiTiet.GiaNhap = Convert.ToInt32(numDonGiaNhap.Value);
                    chiTiet.ThanhTien = Convert.ToInt32(numSoLuongNhap.Value * numDonGiaNhap.Value);
                    dataGridView.Refresh();
                }
                else // Nếu chưa có sản phẩm thì thêm vào
                {
                    // Nếu chưa có sản phẩm nào
                    DanhSachPhieuNhapKho_ChiTiet ct = new DanhSachPhieuNhapKho_ChiTiet
                    {
                        ID = 0,
                        PhieuNhapKhoID = id,
                        NguyenLieuID = maSanPham,
                        TenNguyenLieu = cboNguyenLieu.Text,
                        SoLuongNhap = Convert.ToInt32(numSoLuongNhap.Value),
                        GiaNhap = Convert.ToInt32(numDonGiaNhap.Value),
                        ThanhTien = Convert.ToInt32(numSoLuongNhap.Value * numDonGiaNhap.Value)
                    };
                    phieuNhapKhoChiTiet.Add(ct);
                }
                BatTatChucNang();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNguyenLieu = Convert.ToInt32(dataGridView.CurrentRow.Cells["NguyenLieuID"].Value.ToString());
            var chiTiet = phieuNhapKhoChiTiet.FirstOrDefault(x => x.NguyenLieuID == maNguyenLieu);
            if (chiTiet != null)
            {
                phieuNhapKhoChiTiet.Remove(chiTiet);
            }
            BatTatChucNang();
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNhanVien.Text))
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboNhaCungCap.Text))
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (id != 0) // Đã tồn tại chi tiết thì chỉ cập nhật
                {
                    PhieuNhapKho p = context.PhieuNhapKho.Find(id);
                    if (p != null)
                    {
                        p.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                        p.NhaCungCapID = Convert.ToInt32(cboNhaCungCap.SelectedValue.ToString());
                        p.GhiChu = txtGhiChu.Text;
                        context.PhieuNhapKho.Update(p);
                        // Xóa chi tiết cũ
                        var old = context.PhieuNhapKho_ChiTiet.Where(r => r.PhieuNhapKhoID == id).ToList();
                        context.PhieuNhapKho_ChiTiet.RemoveRange(old);
                        // Thêm lại chi tiết mới
                        double tongtien = 0;
                        foreach (var item in phieuNhapKhoChiTiet.ToList())
                        {
                            PhieuNhapKho_ChiTiet ct = new PhieuNhapKho_ChiTiet();
                            ct.PhieuNhapKhoID = (id != 0) ? id : p.ID;
                            ct.NguyenLieuID = item.NguyenLieuID;
                            ct.SoLuongNhap = item.SoLuongNhap;
                            ct.GiaNhap = item.GiaNhap;
                            tongtien += ct.GiaNhap * ct.SoLuongNhap;

                            context.PhieuNhapKho_ChiTiet.Add(ct);
                        }
                        p.TongTien = tongtien;
                        context.SaveChanges();

                    }
                }
                else // Thêm mới
                {
                    PhieuNhapKho p = new PhieuNhapKho();
                    p.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                    p.NhaCungCapID = Convert.ToInt32(cboNhaCungCap.SelectedValue.ToString());
                    p.NgayNhap = DateTime.Now;
                    p.GhiChu = txtGhiChu.Text;
                    p.TrangThai = "Chưa duyệt";
                    context.PhieuNhapKho.Add(p);
                    context.SaveChanges();
                    // Thêm chi tiết
                    double tongtien = 0;
                    foreach (var item in phieuNhapKhoChiTiet.ToList())
                    {
                        PhieuNhapKho_ChiTiet ct = new PhieuNhapKho_ChiTiet();
                        ct.PhieuNhapKhoID = p.ID;
                        ct.NguyenLieuID = item.NguyenLieuID;
                        ct.SoLuongNhap = item.SoLuongNhap;
                        ct.GiaNhap = item.GiaNhap;
                        tongtien += ct.GiaNhap * ct.SoLuongNhap;
                        context.PhieuNhapKho_ChiTiet.Add(ct);
                    }
                    p.TongTien = tongtien;
                    context.SaveChanges();
                }
                MessageBox.Show("Đã lưu thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void cboNguyenLieu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int maNguyenLieu = Convert.ToInt32(cboNguyenLieu.SelectedValue.ToString());
            var nguyenLieu = context.NguyenLieu.Find(maNguyenLieu);
            numDonGiaNhap.Value = nguyenLieu.GiaNhap;

        }
    }
}
