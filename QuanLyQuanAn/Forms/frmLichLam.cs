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
    public partial class frmLichLam : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;

        public frmLichLam()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboCaLam.Enabled = giaTri;
            cboNhanVien.Enabled = giaTri;
            dtpNgayPhanCong.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }
        public void LayCaLamVaoComboBox()
        {
            cboCaLam.DataSource = context.CaLam.ToList();
            cboCaLam.ValueMember = "ID";
            cboCaLam.DisplayMember = "TenCa";
        }


        private void frmLichLam_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayCaLamVaoComboBox();
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            var listLichLam = context.LichLam.Select(ll => new
            {
                ll.ID,
                ll.NhanVienID,
                ll.CaLamID,
                HoVaTenNhanVien = ll.NhanVien.HoVaTen,
                Tenca = ll.CaLam.TenCa,
                ll.NgayPhanCong
            }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = listLichLam;
            cboNhanVien.DataBindings.Clear();
            cboNhanVien.DataBindings.Add("SelectedValue", bindingSource, "NhanVienID", false, DataSourceUpdateMode.Never);
            cboCaLam.DataBindings.Clear();
            cboCaLam.DataBindings.Add("SelectedValue", bindingSource, "CaLamID", false, DataSourceUpdateMode.Never);
            dtpNgayPhanCong.DataBindings.Clear();
            dtpNgayPhanCong.DataBindings.Add("Value", bindingSource, "NgayPhanCong", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            xuLyThem = true;
            BatTatChucNang(true);
            cboNhanVien.Text = "";
            cboCaLam.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa lịch làm?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                LichLam ll = context.LichLam.Find(id);
                if (ll != null)
                {
                    context.LichLam.Remove(ll);
                }
                context.SaveChanges();
                frmLichLam_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboCaLam.SelectedItem == null)
                MessageBox.Show("Vui lòng chọn ca làm việc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboNhanVien.SelectedItem == null)
                MessageBox.Show("Vui lòng chọn nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DateTime ngay = dtpNgayPhanCong.Value;

                if (ngay < DateTime.Now)
                {
                    MessageBox.Show("Chỉ có thể xếp lịch cho ngày trong tương lai và lịch đột xuất cho ngày hôm nay", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int nvid = (int)cboNhanVien.SelectedValue;
                int calamid = (int)cboCaLam.SelectedValue;
                bool daTonTai = context.LichLam.Any(x => x.NhanVienID == nvid
                                          && x.CaLamID == calamid
                                          && x.NgayPhanCong == ngay);
                if (daTonTai)
                {
                    MessageBox.Show("Nhân viên này đã được phân công ca này vào ngày đã chọn!", "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (xuLyThem)
                {
                    LichLam ll = new LichLam();
                    ll.CaLamID = (int)cboCaLam.SelectedValue;
                    ll.NhanVienID = (int)cboNhanVien.SelectedValue;
                    ll.NgayPhanCong = dtpNgayPhanCong.Value;
                    context.LichLam.Add(ll);
                    context.SaveChanges();
                }
                else
                {
                    LichLam ll = context.LichLam.Find(id);
                    if (ll != null)
                    {
                        ll.CaLamID = (int)cboCaLam.SelectedValue;
                        ll.NhanVienID = (int)cboNhanVien.SelectedValue;
                        ll.NgayPhanCong = dtpNgayPhanCong.Value;
                        context.LichLam.Update(ll);
                        context.SaveChanges();
                    }
                }
                frmLichLam_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmLichLam_Load(sender, e);
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
                                    string ca = r["TenCa"].ToString();
                                    var caid = context.CaLam.FirstOrDefault(r => r.TenCa == ca);
                                    string nv = r["NhanVien"].ToString();
                                    var nvid = context.NhanVien.FirstOrDefault(r => r.HoVaTen == nv);

                                    DateTime d = DateTime.Parse(r["NgayPhanCong"].ToString());
                                    if (ca.IsNullOrEmpty() || nv.IsNullOrEmpty() || d == null || caid == null || nvid == null)
                                    {
                                        throw new Exception("");
                                    }
                                    bool daTonTai = context.LichLam.Any(x => x.NhanVienID == nvid.ID
                                          && x.CaLamID == caid.Id
                                         && x.NgayPhanCong.Date == d.Date);
                                    if (daTonTai)
                                    {
                                        throw new Exception("Trùng");

                                    }
                                    LichLam ll = new LichLam();
                                    ll.NhanVienID = nvid.ID;
                                    ll.CaLamID = caid.Id;
                                    ll.NgayPhanCong = d;
                                    context.LichLam.Add(ll);
                                    context.SaveChanges(); // Lưu ngay từng dòng để bắt lỗi chính xác dòng đó
                                    thanhCong++;
                                }
                                catch(Exception ex) 
                                {
                                    // Nếu dòng này lỗi, rollback entry đó và tăng biến thất bại
                                    thatBai++;
                                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    // Tùy chọn: Log lỗi hoặc bỏ qua để tiếp tục dòng sau
                                }
                            }

                            MessageBox.Show(string.Format("Kết quả nhập dữ liệu:\n- Thành công: {0}\n- Thất bại: {1}", thanhCong, thatBai),
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmLichLam_Load(sender, e);
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
            saveFileDialog.FileName = "LichLam_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenCa", typeof(string)),
                    new DataColumn("NhanVien", typeof(String)),
                    new DataColumn("NgayPhanCong", typeof(DateTime)),
                    });
                    var lichLam = context.LichLam.ToList();
                    if (lichLam != null)
                    {
                        foreach (var p in lichLam)
                        {
                            var nv=context.NhanVien.FirstOrDefault(r=>r.ID==p.NhanVienID);
                            var ca=context.CaLam.FirstOrDefault(r=>r.Id==p.CaLamID);
                            table.Rows.Add(p.ID, ca.TenCa, nv.HoVaTen,p.NgayPhanCong);
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "LichLam");
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