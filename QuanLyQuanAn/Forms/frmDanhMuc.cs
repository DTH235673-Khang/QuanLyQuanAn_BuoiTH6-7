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
using ClosedXML.Excel;
using Microsoft.IdentityModel.Tokens;

namespace QuanLyQuanAn.Forms
{
    public partial class frmDanhMuc : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenDanhMuc.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<DanhMuc> lsp = new List<DanhMuc>();
            lsp = context.DanhMuc.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = lsp;
            txtTenDanhMuc.DataBindings.Clear();
            txtTenDanhMuc.DataBindings.Add("Text", bindingSource, "TenDanhMuc", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenDanhMuc.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool daTonTai = context.DanhMuc.Any(x => x.TenDanhMuc == txtTenDanhMuc.Text);
                if (daTonTai)
                {
                    MessageBox.Show("Danh mục đã tồn tại", "Lỗi");
                    return;
                }

                if (xuLyThem)
                {
                    DanhMuc dam = new DanhMuc();
                    dam.TenDanhMuc = txtTenDanhMuc.Text;
                    context.DanhMuc.Add(dam);
                    context.SaveChanges();
                }
                else
                {
                    DanhMuc dam = context.DanhMuc.Find(id);
                    if (dam != null)
                    {
                        dam.TenDanhMuc = txtTenDanhMuc.Text;
                        context.DanhMuc.Update(dam);
                        context.SaveChanges();
                    }
                }
                frmDanhMuc_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa danh mục?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                DanhMuc dam = context.DanhMuc.Find(id);
                if (dam != null)
                {
                    context.DanhMuc.Remove(dam);
                }
                context.SaveChanges();
                frmDanhMuc_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmDanhMuc_Load(sender, e);
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
                            int thanhCong = 0;
                            int thatBai = 0;

                            foreach (DataRow r in table.Rows)
                            {
                                try
                                {
                                    string ten= r["TenDanhMuc"].ToString();
                                    if(ten.IsNullOrEmpty())
                                    {
                                        throw new Exception("");
                                    }
                                    bool daTonTai = context.DanhMuc.Any(x => x.TenDanhMuc == ten);
                                    if (daTonTai)
                                    {
                                        throw new Exception("Trùng");
                                    }
                                    DanhMuc dm = new DanhMuc();
                                    dm.TenDanhMuc = ten;

                                    context.DanhMuc.Add(dm);
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

                            frmDanhMuc_Load(sender, e);
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
            saveFileDialog.FileName = "DanhMuc_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[2] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenDanhMuc", typeof(string))});
                    var danhMuc = context.DanhMuc.ToList();
                    if (danhMuc != null)
                    {
                        foreach (var p in danhMuc)
                            table.Rows.Add(p.Id, p.TenDanhMuc);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "DanhMuc");
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
