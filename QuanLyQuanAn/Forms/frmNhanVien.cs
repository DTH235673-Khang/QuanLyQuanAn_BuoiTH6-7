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
using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;
using BC = BCrypt.Net.BCrypt;

namespace QuanLyQuanAn.Forms
{
    public partial class frmNhanVien : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void LayChucVuVaoComboBox()
        {
            cboChucVu.DataSource = context.ChucVu.ToList();
            cboChucVu.ValueMember = "ID";
            cboChucVu.DisplayMember = "TenChucVu";
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboChucVu.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LayChucVuVaoComboBox();
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            var listNhanVien = context.NhanVien.Select(nv => new
            {
                nv.ID,
                nv.HoVaTen,
                nv.DienThoai,
                nv.DiaChi,
                nv.TenDangNhap,
                nv.MatKhau,
                nv.ChucVuID,
                nv.QuyenHan,
                ChucVu = nv.ChucVu.TenChucVu
            }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = listNhanVien;
            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never);
            cboChucVu.DataBindings.Clear();
            cboChucVu.DataBindings.Add("SelectedValue", bindingSource, "ChucVuID", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboChucVu.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nhân viên " + txtHoVaTen.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                NhanVien nv = context.NhanVien.Find(id);
                if (nv != null)
                {
                    context.NhanVien.Remove(nv);
                }
                context.SaveChanges();
                frmNhanVien_Load(sender, e);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                MessageBox.Show("Vui lòng nhập tên đăng nhập?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboChucVu.Text))
                MessageBox.Show("Vui lòng chọn chức vụ cho nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool daTonTai = context.NhanVien.Any(x => x.HoVaTen == txtHoVaTen.Text
                   && x.DienThoai == txtDienThoai.Text
                   && x.DiaChi == txtDiaChi.Text);
                if (daTonTai)
                {
                    MessageBox.Show("Nhân viên đã tồn tại", "Lỗi");
                    return;
                }
                if (xuLyThem)
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        MessageBox.Show("Vui lòng nhập mật khẩu?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        NhanVien nv = new NhanVien();
                        nv.HoVaTen = txtHoVaTen.Text;
                        nv.DienThoai = txtDienThoai.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.TenDangNhap = txtTenDangNhap.Text;
                        nv.MatKhau = BC.HashPassword(txtMatKhau.Text); // Mã hóa mật khẩu
                        var cv = context.ChucVu.FirstOrDefault(r => r.TenChucVu == cboChucVu.Text);
                        nv.ChucVuID = cv.ID;
                        nv.QuyenHan = (cv.TenChucVu == "Quản lý") ? true : false;
                        context.NhanVien.Add(nv);
                        context.SaveChanges();
                    }
                }
                else
                {
                    NhanVien nv = context.NhanVien.Find(id);
                    if (nv != null)
                    {
                        nv.HoVaTen = txtHoVaTen.Text;
                        nv.DienThoai = txtDienThoai.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.TenDangNhap = txtTenDangNhap.Text;
                        context.NhanVien.Update(nv);
                        if (string.IsNullOrEmpty(txtMatKhau.Text))
                            context.Entry(nv).Property(x => x.MatKhau).IsModified = false; // Giữ nguyên mật khẩu cũ
                        else
                            nv.MatKhau = BC.HashPassword(txtMatKhau.Text); // Cập nhật mật khẩu mới
                        var cv = context.ChucVu.FirstOrDefault(r => r.TenChucVu == cboChucVu.Text);
                        nv.ChucVuID = cv.ID;
                        nv.QuyenHan = (cv.TenChucVu == "Quản lý") ? true : false;
                        context.SaveChanges();
                    }
                }
                frmNhanVien_Load(sender, e);
            }

        }


        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dataGridView.DataSource = context.NhanVien.Where(nv => nv.HoVaTen.Contains(txtHoVaTen.Text)).ToList();
                BatTatChucNang(true);
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
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            // Đọc dòng tiêu đề (dòng đầu tiên)
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else // Đọc các dòng nội dung (các dòng tiếp theo)
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (table.Rows.Count > 0)
                        {
                            int thanhCong = 0;
                            int thatBai = 0;

                            foreach (DataRow r in table.Rows)
                            {
                                try
                                {
                                    string ten = r["HoVaTen"].ToString();
                                    string diachi = r["DiaChi"].ToString();
                                    string dienthoai = r["DienThoai"].ToString();
                                    string tdn = r["TenDangNhap"].ToString();
                                    string mk = r["MatKhau"].ToString();
                                    string qh = r["QuyenHan"].ToString().Trim().ToLower();
                                    string cv = r["ChucVu"].ToString();
                                    if (ten.IsNullOrEmpty() || diachi.IsNullOrEmpty() || dienthoai.IsNullOrEmpty() || cv.IsNullOrEmpty())
                                    {
                                        throw new Exception("");
                                    }
                                    else if (tdn.IsNullOrEmpty() || mk.IsNullOrEmpty() || qh.IsNullOrEmpty())
                                    {
                                        throw new Exception("");
                                    }
                                    else if ((cv == "Quản lý" && qh == "false") || (cv != "Quản lý" && qh == "true"))
                                    {
                                        throw new Exception("");
                                    }
                                    bool daTonTai = context.NhanVien.Any(x => x.HoVaTen == ten
                                        && x.DienThoai == dienthoai
                                        && x.DiaChi == diachi);
                                    if (daTonTai)
                                    {
                                        throw new Exception();
                                    }
                                    NhanVien nv = new NhanVien();
                                    nv.HoVaTen = ten;
                                    nv.DienThoai = dienthoai;
                                    nv.DiaChi = diachi;
                                    nv.TenDangNhap = tdn;
                                    nv.MatKhau = mk;
                                    nv.QuyenHan = (qh == "true") ? true : false;
                                    var chucvu = context.ChucVu.FirstOrDefault(r => r.TenChucVu == cv);
                                    nv.ChucVuID = chucvu.ID;
                                    context.NhanVien.Add(nv);
                                    context.SaveChanges(); // Lưu ngay từng dòng để bắt lỗi chính xác dòng đó
                                    thanhCong++;
                                }
                                catch
                                {
                                    // Nếu dòng này lỗi, rollback entry đó và tăng biến thất bại
                                    thatBai++;

                                    // Tùy chọn: Log lỗi hoặc bỏ qua để tiếp tục dòng sau
                                }
                            }

                            MessageBox.Show(string.Format("Kết quả nhập dữ liệu:\n- Thành công: {0}\n- Thất bại: {1}", thanhCong, thatBai),
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmNhanVien_Load(sender, e);
                        }
                        if (firstRow)
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "NhanVien_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("HoVaTen", typeof(string)),
                    new DataColumn("DienThoai", typeof(string)),
                    new DataColumn("DiaChi", typeof(string)),
                    new DataColumn("TenDangNhap", typeof(string)),
                    new DataColumn("MatKhau", typeof(string)),
                    new DataColumn("ChucVu", typeof(string)),
                    new DataColumn("QuyenHan", typeof(bool))});
                    var nhanVien = context.NhanVien.ToList();
                    if (nhanVien != null)
                    {
                        foreach (var p in nhanVien)
                        {
                            var c = context.ChucVu.FirstOrDefault(r => r.ID == p.ChucVuID);
                            table.Rows.Add(p.ID, p.HoVaTen, p.DienThoai, p.DiaChi, p.TenDangNhap, p.MatKhau, c.TenChucVu, p.QuyenHan);
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhanVien");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
