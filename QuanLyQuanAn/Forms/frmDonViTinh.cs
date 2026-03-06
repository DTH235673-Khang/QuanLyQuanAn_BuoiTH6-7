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
    public partial class frmDonViTinh : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        public frmDonViTinh()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenDonViTinh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }
        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            List<DonViTinh> dvt = new List<DonViTinh>();
            dvt = context.DonViTinh.ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dvt;
            txtTenDonViTinh.DataBindings.Clear();
            txtTenDonViTinh.DataBindings.Add("Text", bindingSource, "TenDonViTinh", false, DataSourceUpdateMode.Never);
            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenDonViTinh.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa đơn vị tính?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                DonViTinh dvt = context.DonViTinh.Find(id);
                if (dvt != null)
                {
                    context.DonViTinh.Remove(dvt);
                }
                context.SaveChanges();
                frmDonViTinh_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDonViTinh.Text))
                MessageBox.Show("Vui lòng nhập tên đơn vị tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    DonViTinh dvt = new DonViTinh();
                    dvt.TenDonViTinh = txtTenDonViTinh.Text;
                    context.DonViTinh.Add(dvt);
                    context.SaveChanges();
                }
                else
                {
                    DonViTinh dvt = context.DonViTinh.Find(id);
                    if (dvt != null)
                    {
                        dvt.TenDonViTinh = txtTenDonViTinh.Text;
                        context.DonViTinh.Update(dvt);
                        context.SaveChanges();
                    }
                }
                frmDonViTinh_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmDonViTinh_Load(sender, e);
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
                var worksheet = workbook.Worksheet(1);
                bool firstRow = true;
                string readRange = "1:1";

                foreach (IXLRow row in worksheet.RowsUsed())
                {
                    if (firstRow)
                    {
                        readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                        foreach (IXLCell cell in row.Cells(readRange))
                            table.Columns.Add(cell.Value.ToString());
                        firstRow = false;
                    }
                    else
                    {
                        DataRow newRow = table.NewRow();
                        int cellIndex = 0;
                        foreach (IXLCell cell in row.Cells(readRange))
                        {
                            newRow[cellIndex] = cell.Value.ToString();
                            cellIndex++;
                        }
                        table.Rows.Add(newRow);
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
                            string ten= r["TenDonViTinh"].ToString();
                            if(ten.IsNullOrEmpty())
                            {
                                throw new Exception("");
                            }    
                            DonViTinh dvt = new DonViTinh();
                            dvt.TenDonViTinh = ten;
                            
                            context.DonViTinh.Add(dvt);
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
                    
                    frmDonViTinh_Load(sender, e);
                }
                else if (firstRow)
                {
                    MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi cấu trúc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "DonViTinh_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[2] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("TenDonViTinh", typeof(string))});
                    var donViTinh = context.DonViTinh.ToList();
                    if (donViTinh != null)
                    {
                        foreach (var p in donViTinh)
                            table.Rows.Add(p.Id, p.TenDonViTinh);
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "DonViTinh");
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
