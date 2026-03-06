using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;
using static QuanLyQuanAn.Data.HoaDon;
using static QuanLyQuanAn.Data.PhieuNhapKho;

namespace QuanLyQuanAn.Forms
{
    public partial class frmPhieuNhapKho : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        public frmPhieuNhapKho()
        {
            InitializeComponent();
        }

        private void frmPhieuNhapKho_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachPhieuNhapKho> p = new List<DanhSachPhieuNhapKho>();
            p = context.PhieuNhapKho.Select(r => new DanhSachPhieuNhapKho
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                NhaCungCapID = r.NhaCungCapID,
                TenNhaCungCap = r.NhaCungCap.TenNhaCungCap,
                NgayNhap = r.NgayNhap,
                TongTien = r.TongTien,
                TrangThai = r.TrangThai,
                GhiChu = r.GhiChu,
                XemChiTiet = "Xem chi tiết"
            }).ToList();
            dataGridView.DataSource = p;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmPhieuNhapKho_ChiTiet chiTiet = new frmPhieuNhapKho_ChiTiet(id))
            {
                chiTiet.ShowDialog();
                frmPhieuNhapKho_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            if (id.ToString().IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập kho càn xóa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Xác nhận xóa phiếu nhập kho " + id + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    PhieuNhapKho t = context.PhieuNhapKho.Find(id);
                    if (t != null)
                    {
                        context.PhieuNhapKho.Remove(t);
                    }
                    context.SaveChanges();
                    frmPhieuNhapKho_Load(sender, e);
                }
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            using (frmPhieuNhapKho_ChiTiet chitiet = new frmPhieuNhapKho_ChiTiet())
            {
                chitiet.ShowDialog();
                context.SaveChanges();
                frmPhieuNhapKho_Load(sender, e);
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        DataTable table1 = new DataTable();
                        IXLWorksheet worksheet1 = workbook.Worksheet(1); // Lấy sheet 1
                        bool firstRow1 = true;
                        foreach (IXLRow row in worksheet1.RowsUsed())
                        {
                            if (firstRow1)
                            {
                                foreach (IXLCell cell in row.CellsUsed()) table1.Columns.Add(cell.Value.ToString());
                                firstRow1 = false;
                            }
                            else
                            {
                                table1.Rows.Add(row.Cells(1, table1.Columns.Count).Select(c => c.Value.ToString()).ToArray());
                            }
                        }
                        int thanhcong = 0;
                        int thatbai = 0;
                        if (table1.Rows.Count > 0)
                        {

                            foreach (DataRow r in table1.Rows)
                            {
                                try
                                {
                                    var nv = context.NhanVien.FirstOrDefault(x => x.HoVaTen == r["NhanVien"].ToString());
                                    var ncc = context.NhaCungCap.FirstOrDefault(x => x.TenNhaCungCap == r["NhaCungCap"].ToString());
                                    DateTime dt = Convert.ToDateTime(r["NgayNhap"]);
                                    string tthai = r["TrangThai"].ToString();
                                    string ghichu = r["GhiChu"].ToString();
                                    double tongtien = Convert.ToDouble(r["TongTien"]);
                                    if (nv == null || ncc == null || tthai.IsNullOrEmpty() || dt == null || tongtien <= 0)
                                    {
                                        throw new Exception("Không lấy được dữ liệu");
                                    }
                                    if (nv != null && ncc != null)
                                    {
                                        PhieuNhapKho p = new PhieuNhapKho();
                                        p.NhanVienID = nv.ID;
                                        p.NhaCungCapID = ncc.ID;
                                        p.NgayNhap = dt;
                                        p.GhiChu = ghichu;
                                        p.TongTien = tongtien;
                                        p.TrangThai = tthai;
                                        context.PhieuNhapKho.Add(p);
                                        context.SaveChanges();
                                        thanhcong++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    thatbai++;
                                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                                }

                            }
                            context.SaveChanges(); // Lưu hóa đơn trước để có ID
                        }

                        DataTable table2 = new DataTable();
                        IXLWorksheet worksheet2 = workbook.Worksheet(2); // Lấy sheet 2
                        bool firstRow2 = true;
                        foreach (IXLRow row in worksheet2.RowsUsed())
                        {
                            if (firstRow2)
                            {
                                foreach (IXLCell cell in row.CellsUsed()) table2.Columns.Add(cell.Value.ToString());
                                firstRow2 = false;
                            }
                            else
                            {
                                table2.Rows.Add(row.Cells(1, table2.Columns.Count).Select(c => c.Value.ToString()).ToArray());
                            }
                        }

                        if (table2.Rows.Count > 0)
                        {
                            foreach (DataRow r2 in table2.Rows) // Chạy vòng lặp riêng cho bảng 2
                            {
                                try
                                {
                                    string tenNL = r2["NguyenLieu"].ToString();
                                    var n = context.NguyenLieu.FirstOrDefault(x => x.TenNguyenLieu == tenNL);

                                    if (n != null)
                                    {
                                        PhieuNhapKho_ChiTiet ct = new PhieuNhapKho_ChiTiet();
                                        ct.PhieuNhapKhoID = Convert.ToInt32(r2["ID"]); // Cột liên kết trong Excel
                                        ct.NguyenLieuID = n.ID;
                                        ct.SoLuongNhap = Convert.ToInt32(r2["SoLuongNhap"]);
                                        ct.GiaNhap = Convert.ToInt32(r2["GiaNhap"]);
                                        context.PhieuNhapKho_ChiTiet.Add(ct);
                                        context.SaveChanges();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                                }

                            }
                            context.SaveChanges();
                        }

                        MessageBox.Show(string.Format("Kết quả nhập dữ liệu:\n- Thành công: {0}\n- Thất bại: {1}", thanhcong, thatbai),
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPhieuNhapKho_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "PhieuNhapKho_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // --- XỬ LÝ TABLE 1: HÓA ĐƠN ---
                    DataTable tableHD = new DataTable();
                    tableHD.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("NhanVien", typeof(string)),
                new DataColumn("NhaCungCap", typeof(string)),
                new DataColumn("NgayNhap", typeof(DateTime)),
                new DataColumn("GhiChu", typeof(string)),
                new DataColumn("TrangThai",typeof(string)),
                new DataColumn("TongTien",typeof(decimal))

            });

                    var dsPhieuNhapKho = context.PhieuNhapKho.ToList();
                    if (dsPhieuNhapKho != null)
                    {
                        foreach (var p in dsPhieuNhapKho)
                        {
                            var nv = context.NhanVien.FirstOrDefault(r => r.ID == p.NhanVienID);
                            var ncc = context.NhaCungCap.FirstOrDefault(r => r.ID == p.NhaCungCapID);
                            tableHD.Rows.Add(p.ID, nv.HoVaTen, ncc.TenNhaCungCap, p.NgayNhap, p.GhiChu,p.TrangThai, p.TongTien);
                        }
                    }

                    // --- XỬ LÝ TABLE 2: CHI TIẾT HÓA ĐƠN ---
                    DataTable tableCT = new DataTable();
                    tableCT.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("NguyenLieu", typeof(string)),
                new DataColumn("SoLuongNhap", typeof(int)),
                new DataColumn("GiaNhap", typeof(int))
            });

                    var dsChiTiet = context.PhieuNhapKho_ChiTiet.ToList();
                    if (dsChiTiet != null)
                    {
                        foreach (var d in dsChiTiet)
                        {
                            var t = context.NguyenLieu.FirstOrDefault(r => r.ID == d.NguyenLieuID);
                            tableCT.Rows.Add(d.PhieuNhapKhoID, t.TenNguyenLieu, d.SoLuongNhap, d.GiaNhap);
                        }
                    }

                    // --- XUẤT RA FILE EXCEL ---
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // Thêm Sheet 1 từ tableHD
                        var sheet1 = wb.Worksheets.Add(tableHD, "HoaDon");
                        sheet1.Columns().AdjustToContents();

                        // Thêm Sheet 2 từ tableCT
                        var sheet2 = wb.Worksheets.Add(tableCT, "HoaDonChiTiet");
                        sheet2.Columns().AdjustToContents();

                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra 2 Sheet thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
    


    
