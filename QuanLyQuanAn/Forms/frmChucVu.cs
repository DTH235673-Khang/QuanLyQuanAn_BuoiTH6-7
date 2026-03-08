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
    public partial class frmChucVu : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;

        public frmChucVu()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenChucVu.Enabled = giaTri;
            numLuongTheoGio.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            List<ChucVu> cv = new List<ChucVu>();
            cv = context.ChucVu.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = cv;
            txtTenChucVu.DataBindings.Clear();
            txtTenChucVu.DataBindings.Add("Text", bindingSource, "TenChucVu", false, DataSourceUpdateMode.Never);
            numLuongTheoGio.DataBindings.Clear();
            numLuongTheoGio.DataBindings.Add("Value", bindingSource, "LuongTheoGio", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenChucVu.Clear();
            numLuongTheoGio.Value=0;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa chức vụ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                ChucVu cv = context.ChucVu.Find(id);
                if (cv != null)
                {
                    context.ChucVu.Remove(cv);
                }
                context.SaveChanges();
                frmChucVu_Load(sender, e);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           if (txtTenChucVu.Text.IsNullOrEmpty())
                MessageBox.Show("Vui lòng nhập tên chức vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numLuongTheoGio.Value<=0)
                MessageBox.Show("Lương theo giờ phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            else
            {
                
                bool daTonTai = context.ChucVu.Any(x => x.TenChucVu == txtTenChucVu.Text
                    && x.LuongTheoGio == numLuongTheoGio.Value
                     );
                if (daTonTai)
                {
                    MessageBox.Show("Chức vụ đã tồn tại", "Lỗi");
                    return;
                }


                if (xuLyThem)
                {
                    ChucVu cv = new ChucVu();
                    cv.TenChucVu = txtTenChucVu.Text;
                    cv.LuongTheoGio=numLuongTheoGio.Value;
                    context.ChucVu.Add(cv);
                    context.SaveChanges();
                }
                else
                {
                    ChucVu cv = context.ChucVu.Find(id);
                    if (cv != null)
                    {
                        cv.TenChucVu = txtTenChucVu.Text;
                        cv.LuongTheoGio = numLuongTheoGio.Value;
                        context.ChucVu.Update(cv);
                        context.SaveChanges();
                    }
                }
                frmChucVu_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmChucVu_Load(sender, e);
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
                                    string ten = r["TenChucVu"].ToString();
                                    Decimal luong = Convert.ToDecimal(r["LuongTheoGio"].ToString());
                                    if (ten.IsNullOrEmpty() ||luong <= 0)
                                    {
                                        throw new Exception("");
                                    }
                                    bool daTonTai = context.ChucVu.Any(x => x.TenChucVu == ten
                                         && x.LuongTheoGio ==luong);
                                    if (daTonTai)
                                    {
                                        throw new Exception("Trùng");
                                    }


                                    ChucVu cv = new ChucVu();
                                    cv.TenChucVu = ten;
                                    cv.LuongTheoGio = luong;
                                    context.ChucVu.Add(cv);
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

                            frmChucVu_Load(sender, e);
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
            saveFileDialog.FileName = "ChucVu_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenChucVu", typeof(string)),
                    new DataColumn("LuongTheoGio", typeof(int))
                    });
                    var chucVu = context.ChucVu.ToList();
                    if (chucVu != null)
                    {
                        foreach (var p in chucVu)
                            table.Rows.Add(p.ID,p.TenChucVu,p.LuongTheoGio);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "ChucVu");
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
