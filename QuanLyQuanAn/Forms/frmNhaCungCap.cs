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
    public partial class frmNhaCungCap : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<NhaCungCap> ncc = new List<NhaCungCap>();
            ncc = context.NhaCungCap.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ncc;
            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "TenNhaCungCap", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "SoDienThoai", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nhà cung cấp " + txtHoVaTen.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                NhaCungCap ncc = context.NhaCungCap.Find(id);
                if (ncc != null)
                {
                    context.NhaCungCap.Remove(ncc);
                }
                context.SaveChanges();
                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhà cung cấp?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    NhaCungCap ncc = new NhaCungCap();
                    ncc.TenNhaCungCap = txtHoVaTen.Text;
                    ncc.SoDienThoai = txtDienThoai.Text;
                    ncc.DiaChi = txtDiaChi.Text;
                    context.NhaCungCap.Add(ncc);
                    context.SaveChanges();
                }
                else
                {
                    NhaCungCap ncc = context.NhaCungCap.Find(id);
                    if (ncc != null)
                    {
                        ncc.TenNhaCungCap = txtHoVaTen.Text;
                        ncc.SoDienThoai = txtDienThoai.Text;
                        ncc.DiaChi = txtDiaChi.Text;
                        context.NhaCungCap.Update(ncc);
                        context.SaveChanges();
                    }
                }
                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmNhaCungCap_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhà cung cấp?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dataGridView.DataSource = context.NhaCungCap.Where(ncc => ncc.TenNhaCungCap.Contains(txtHoVaTen.Text)).ToList();
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
                                    string ten = r["TenNhaCungCap"].ToString();
                                    string diachi = r["DiaChi"].ToString();
                                    string dienthoai = r["SoDienThoai"].ToString();
                                    if (ten.IsNullOrEmpty() || diachi.IsNullOrEmpty() || dienthoai.IsNullOrEmpty())
                                    {
                                        throw new Exception("");
                                    }
                                    NhaCungCap ncc = new NhaCungCap();
                                    ncc.TenNhaCungCap = ten;
                                    ncc.SoDienThoai = dienthoai;
                                    ncc.DiaChi = diachi;

                                    context.NhaCungCap.Add(ncc);
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

                            frmNhaCungCap_Load(sender, e);
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
            saveFileDialog.FileName = "NhaCungCap_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenNhaCungCap", typeof(string)),
                    new DataColumn("SoDienThoai", typeof(string)),
                    new DataColumn("DiaChi", typeof(string))});
                    var nhaCungCap = context.NhaCungCap.ToList();
                    if (nhaCungCap != null)
                    {
                        foreach (var p in nhaCungCap)
                            table.Rows.Add(p.ID, p.TenNhaCungCap, p.SoDienThoai, p.DiaChi);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhaCungCap");
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
