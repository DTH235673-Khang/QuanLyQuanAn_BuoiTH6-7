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

namespace QuanLyQuanAn.Forms
{
    public partial class frmNguyenLieu : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id; // Lấy mã sản phẩm (dùng cho Sửa và Xóa)

        public frmNguyenLieu()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboQuyCach.Enabled = giaTri;
            txtTenNguyenLieu.Enabled = giaTri;
            numSoLuongTon.Enabled = giaTri;
            numGiaNhap.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = giaTri;

        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachNguyenLieu> sp = new List<DanhSachNguyenLieu>();
            sp = context.NguyenLieu.Select(r => new DanhSachNguyenLieu
            {
                ID = r.ID,
                TenNguyenLieu = r.TenNguyenLieu,
                QuyCach = r.QuyCach,
                GiaNhap = r.GiaNhap,
                SoLuongTon = r.SoLuongTon
            }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;
            txtTenNguyenLieu.DataBindings.Clear();
            txtTenNguyenLieu.DataBindings.Add("Text", bindingSource, "TenNguyenLieu", false, DataSourceUpdateMode.Never);
            numSoLuongTon.DataBindings.Clear();
            numSoLuongTon.DataBindings.Add("Value", bindingSource, "SoLuongTon", false, DataSourceUpdateMode.Never);

            numGiaNhap.DataBindings.Clear();
            numGiaNhap.DataBindings.Add("Value", bindingSource, "GiaNhap", false, DataSourceUpdateMode.Never);
            cboQuyCach.DataBindings.Clear();
            cboQuyCach.DataBindings.Add("Text", bindingSource, "QuyCach", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboQuyCach.Text = "";
            txtTenNguyenLieu.Clear();
            numSoLuongTon.Value = 0;
            numGiaNhap.Value = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nguyên liệu " + txtTenNguyenLieu.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                NguyenLieu t = context.NguyenLieu.Find(id);
                if (t != null)
                {
                    context.NguyenLieu.Remove(t);
                }
                context.SaveChanges();
                frmNguyenLieu_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNguyenLieu.Text))
                MessageBox.Show("Vui lòng nhập tên nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboQuyCach.Text))
                MessageBox.Show("Vui lòng chọn quy cách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuongTon.Value < 0)
                MessageBox.Show("Số lượng tồn phải lớn hơn hoặc bằng 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numGiaNhap.Value <= 0)
                MessageBox.Show("Giá nhập phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool daTonTai = context.NguyenLieu.Any(x => x.TenNguyenLieu == txtTenNguyenLieu.Text
                    && x.QuyCach == cboQuyCach.Text
                    && x.GiaNhap==numGiaNhap.Value);
                if (daTonTai)
                {
                    MessageBox.Show("Nguyên liệu đã tồn tại", "Lỗi");
                    return;
                }
                if (xuLyThem)
                {
                    NguyenLieu t = new NguyenLieu();
                    t.TenNguyenLieu = txtTenNguyenLieu.Text;
                    t.GiaNhap = numGiaNhap.Value;
                    t.SoLuongTon = Convert.ToInt32(numSoLuongTon.Value);
                    t.QuyCach = cboQuyCach.Text;
                    context.NguyenLieu.Add(t);
                    context.SaveChanges();

                }
                else
                {
                    var t = context.NguyenLieu.Find(id);
                    if (t != null)
                    {
                        t.TenNguyenLieu = txtTenNguyenLieu.Text;
                        t.GiaNhap = numGiaNhap.Value;
                        t.SoLuongTon = Convert.ToInt32(numSoLuongTon.Value);
                        t.QuyCach = cboQuyCach.Text;

                        context.NguyenLieu.Update(t);
                        context.SaveChanges();
                    }
                }
                frmNguyenLieu_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmNguyenLieu_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            int thanhcong = 0;
                            int thatbai = 0;
                            foreach (DataRow r in table.Rows)
                            {
                                try
                                {
                                    string ten = r["TenNguyenLieu"].ToString();
                                    string quycach = r["Quycach"].ToString();
                                    int g = Convert.ToInt32(r["GiaNhap"]);
                                    int s = Convert.ToInt32(r["SoLuongTon"]);
                                    if (ten.IsNullOrEmpty() || g <= 0 || s <= 0)
                                    {
                                        throw new Exception("");
                                    }
                                    bool daTonTai = context.NguyenLieu.Any(x => x.TenNguyenLieu == ten
                                          && x.QuyCach == quycach
                                          && x.GiaNhap == g);
                                    if (daTonTai)
                                    {
                                       throw new Exception();
                                    }
                                    NguyenLieu t = new NguyenLieu();
                                    t.TenNguyenLieu = ten;
                                    t.QuyCach = quycach;
                                    t.GiaNhap = g;
                                    t.SoLuongTon =s;
                                    context.NguyenLieu.Add(t);
                                    context.SaveChanges();
                                    thanhcong++;
                                }
                                catch
                                {
                                    thatbai++;
                                }

                            }

                            context.SaveChanges();
                            MessageBox.Show(string.Format("Kết quả nhập dữ liệu:\n- Thành công: {0}\n- Thất bại: {1}", thanhcong, thatbai),
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmNguyenLieu_Load(sender, e);
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
            saveFileDialog.FileName = "NguyenLieu_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[5] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenNguyenLieu", typeof(string)),
                        new DataColumn("QuyCach", typeof(string)),
                        new DataColumn("GiaNhap", typeof(int)),
                        new DataColumn("SoLuongTon", typeof(int))});
                    var nguyenLieu = context.NguyenLieu.ToList();
                    if (nguyenLieu != null)
                    {
                        foreach (var p in nguyenLieu)
                        {
                            table.Rows.Add(p.ID, p.TenNguyenLieu, p.QuyCach, p.GiaNhap, p.SoLuongTon);
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NguyenLieu");
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
