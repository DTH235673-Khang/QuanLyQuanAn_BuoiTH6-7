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
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmCaLam : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        public frmCaLam()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenCaLam.Enabled = giaTri;
            txtGioBatDau.Enabled = giaTri;
            txtGioKetThuc.Enabled = giaTri;
            txtHeSoLuong.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmCaLam_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            List<CaLam> ca = new List<CaLam>();
            ca = context.CaLam.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ca;
            txtTenCaLam.DataBindings.Clear();
            txtTenCaLam.DataBindings.Add("Text", bindingSource, "TenCa", false, DataSourceUpdateMode.Never);
            txtGioBatDau.DataBindings.Clear();
            txtGioBatDau.DataBindings.Add("Text", bindingSource, "GioBatdau", false, DataSourceUpdateMode.Never);
            txtGioKetThuc.DataBindings.Clear();
            txtGioKetThuc.DataBindings.Add("Text", bindingSource, "GioKetThuc", false, DataSourceUpdateMode.Never);
            txtHeSoLuong.DataBindings.Clear();
            txtHeSoLuong.DataBindings.Add("Text", bindingSource, "HeSoLuong", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenCaLam.Clear();
            txtGioBatDau.Clear();
            txtGioKetThuc.Clear();
            txtHeSoLuong.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa ca làm?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                CaLam ca = context.CaLam.Find(id);
                if (ca != null)
                {
                    context.CaLam.Remove(ca);
                }
                context.SaveChanges();
                frmCaLam_Load(sender, e);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenCaLam.Text))
                MessageBox.Show("Vui lòng nhập tên ca làm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtGioBatDau.Text.IsNullOrEmpty())
                MessageBox.Show("Vui lòng nhập giờ bắt đầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtGioKetThuc.Text.IsNullOrEmpty())
                MessageBox.Show("Vui lòng nhập giờ bắt đầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtHeSoLuong.Text.IsNullOrEmpty())
                MessageBox.Show("Vui lòng nhập hệ số lương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!CheckDinhDangTime(txtGioBatDau.Text, "Giờ bắt đầu"))
                return;
            else if (!CheckDinhDangTime(txtGioKetThuc.Text, "Giờ kết thúc"))
                return;
            else if (string.IsNullOrWhiteSpace(txtHeSoLuong.Text) || !float.TryParse(txtHeSoLuong.Text, out float hsl) || hsl <= 0)
                MessageBox.Show("Hệ số lương phải là số và lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TimeOnly batDau = TimeOnly.Parse(txtGioBatDau.Text);
                TimeOnly ketThuc = TimeOnly.Parse(txtGioKetThuc.Text);

                if (ketThuc <= batDau)
                {
                    MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu!", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                bool daTonTai = context.CaLam.Any(x => x.TenCa == txtTenCaLam.Text
                    && x.GioBatDau == batDau
                     && x.GioKetThuc==ketThuc
                     && x.HeSoLuong==Convert.ToSingle(txtHeSoLuong.Text));
                if (daTonTai)
                {
                    MessageBox.Show("Ca làm đã tồn tại", "Lỗi");
                    return;
                }


                if (xuLyThem)
                {
                    CaLam ca = new CaLam();
                    ca.TenCa = txtTenCaLam.Text;
                    ca.GioBatDau = TimeOnly.Parse(txtGioBatDau.Text);
                    ca.GioKetThuc = TimeOnly.Parse(txtGioKetThuc.Text);
                    ca.HeSoLuong = Convert.ToSingle(txtHeSoLuong.Text);
                    context.CaLam.Add(ca);
                    context.SaveChanges();
                }
                else
                {
                    CaLam ca = context.CaLam.Find(id);
                    if (ca != null)
                    {
                        ca.TenCa = txtTenCaLam.Text;
                        ca.GioBatDau = TimeOnly.Parse(txtGioBatDau.Text);
                        ca.GioKetThuc = TimeOnly.Parse(txtGioKetThuc.Text);
                        ca.HeSoLuong = Convert.ToSingle(txtHeSoLuong.Text);
                        context.CaLam.Update(ca);
                        context.SaveChanges();
                    }
                }
                frmCaLam_Load(sender, e);
            }
        }
        private bool CheckDinhDangTime(string input, string fieldName)
        {
            if (TimeOnly.TryParse(input,out _))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"{fieldName} không đúng định dạng thời gian (Ví dụ hợp lệ: 08:30, 14:00:00)",
                                "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmCaLam_Load(sender, e);
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
                                    string ten = r["TenCaLam"].ToString();
                                    string it= r["GioBatDau"].ToString();
                                    string ot = r["GioKetThuc"].ToString();
                                    float hsl = Convert.ToSingle(r["HeSoLuong"].ToString());
                                    if (ten.IsNullOrEmpty() ||it.IsNullOrEmpty()||ot.IsNullOrEmpty()||hsl<=0 )
                                    {
                                        throw new Exception("");
                                    }
                                    bool daTonTai = context.CaLam.Any(x => x.TenCa ==ten
                                         && x.GioBatDau == TimeOnly.Parse(it)
                                         && x.GioKetThuc == TimeOnly.Parse(ot)
                                         && x.HeSoLuong == hsl);
                                    if (daTonTai)
                                    {
                                        throw new Exception("Trùng");
                                    }


                                    CaLam ca = new CaLam();
                                    ca.TenCa = ten;
                                    ca.GioBatDau=TimeOnly.Parse(it);
                                    ca.GioKetThuc=TimeOnly.Parse(ot);
                                    ca.HeSoLuong = hsl;
                                    context.CaLam.Add(ca);
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

                            frmCaLam_Load(sender, e);
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
            saveFileDialog.FileName = "CaLam_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenCaLam", typeof(string)),
                    new DataColumn("GioBatDau", typeof(TimeOnly)),
                    new DataColumn("GioKetThuc", typeof(TimeOnly)),
                    new DataColumn("HeSoLuong", typeof(string))
                    });
                    var caLam = context.CaLam.ToList();
                    if (caLam != null)
                    {
                        foreach (var p in caLam)
                            table.Rows.Add(p.Id, p.TenCa,p.GioBatDau,p.GioKetThuc,p.HeSoLuong);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "CaLam");
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
