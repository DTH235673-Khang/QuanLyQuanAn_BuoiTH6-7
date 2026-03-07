using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.Data;
using System.Text;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using Microsoft.IdentityModel.Tokens;




namespace QuanLyQuanAn.Forms
{
    public partial class frmThucAn : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id; // Lấy mã sản phẩm (dùng cho Sửa và Xóa)
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Images");
        public frmThucAn()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboPhanLoai.Enabled = giaTri;
            cboDonViTinh.Enabled = giaTri;
            txtTenMonAn.Enabled = giaTri;
            cboTrangThai.Enabled = giaTri;
            numDonGia.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnDoiAnh.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = giaTri;

        }
        public void LayDanhMucVaoComboBox()
        {
            cboPhanLoai.DataSource = context.DanhMuc.ToList();
            cboPhanLoai.ValueMember = "ID";
            cboPhanLoai.DisplayMember = "TenDanhMuc";
        }
        public void LayDonViTinhVaoComboBox()
        {
            cboDonViTinh.DataSource = context.DonViTinh.ToList();
            cboDonViTinh.ValueMember = "ID";
            cboDonViTinh.DisplayMember = "TenDonViTinh";
        }
        private void frmThucAn_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LayDanhMucVaoComboBox();
            LayDonViTinhVaoComboBox();
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachThucAn> sp = new List<DanhSachThucAn>();
            sp = context.ThucAn.Select(r => new DanhSachThucAn
            {
                ID = r.ID,
                DanhMucID = r.DanhMucID,
                TenDanhMuc = r.DanhMuc.TenDanhMuc,
                DonViTinhID = r.DonViTinhID,
                TenDonViTinh = r.DonViTinh.TenDonViTinh,
                TenThucAn = r.TenThucAn,
                TrangThai = r.TrangThai,
                Gia = r.Gia,
                HinhAnh = r.HinhAnh
            }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;
            cboPhanLoai.DataBindings.Clear();
            cboPhanLoai.DataBindings.Add("SelectedValue", bindingSource, "DanhMucID", false, DataSourceUpdateMode.Never);
            cboDonViTinh.DataBindings.Clear();
            cboDonViTinh.DataBindings.Add("SelectedValue", bindingSource, "DonViTinhID", false, DataSourceUpdateMode.Never);

            txtTenMonAn.DataBindings.Clear();
            txtTenMonAn.DataBindings.Add("Text", bindingSource, "TenThucAn", false, DataSourceUpdateMode.Never);
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);

            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add("Value", bindingSource, "Gia", false, DataSourceUpdateMode.Never);
            cboTrangThai.DataBindings.Clear();
            cboTrangThai.DataBindings.Add("SelectedValue", bindingSource, "TrangThai", false, DataSourceUpdateMode.Never);
            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnh.Format += (s, e) =>
            {
                if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = Path.Combine(Application.StartupPath, "hinhanh.jpg");
                }
                else
                {
                    string fileName = e.Value.ToString();
                    e.Value = Path.Combine(imagesFolder, fileName);
                }
            };
            picHinhAnh.DataBindings.Add(hinhAnh);
            dataGridView.DataSource = bindingSource;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value != null)
            {
                try
                {
                    if (e.Value is Image) return;

                    string fileName = e.Value.ToString();
                    string fullPath = Path.Combine(imagesFolder, fileName);

                    if (!File.Exists(fullPath))
                    {
                        fullPath = Path.Combine(Application.StartupPath, "hinhanh.jpg");
                    }

                    if (File.Exists(fullPath))
                    {
                        byte[] bytes = File.ReadAllBytes(fullPath);
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            Image img = Image.FromStream(ms);
                            e.Value = new Bitmap(img, 24, 24);
                        }
                        e.FormattingApplied = true;
                    }
                }
                catch { e.Value = null; }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboPhanLoai.Text = "";
            cboDonViTinh.Text = "";
            txtTenMonAn.Clear();
            txtMoTa.Clear();
            cboTrangThai.Text = "";
            numDonGia.Value = 0;
            picHinhAnh.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa món " + txtTenMonAn.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                ThucAn t = context.ThucAn.Find(id);
                if (t != null)
                {
                    context.ThucAn.Remove(t);
                }
                context.SaveChanges();
                frmThucAn_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboPhanLoai.Text))
                MessageBox.Show("Vui lòng chọn loại món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboDonViTinh.Text))
                MessageBox.Show("Vui lòng chọn đơn vị tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenMonAn.Text))
                MessageBox.Show("Vui lòng nhập tên món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboTrangThai.Text))
                MessageBox.Show("Vui lòng chọn trạng thái món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGia.Value <= 0)
                MessageBox.Show("Đơn giá phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool daTonTai = context.ThucAn.Any(x => x.TenThucAn == txtTenMonAn.Text
                   && x.Gia == numDonGia.Value
                   && x.MoTa==txtMoTa.Text
                   && x.DanhMucID == (int)cboPhanLoai.SelectedValue
                   && x.DonViTinhID== (int)cboDonViTinh.SelectedValue);
                if (daTonTai)
                {
                    MessageBox.Show("Món ăn đã tồn tại", "Lỗi");
                    return;
                }
                if (xuLyThem)
                {
                    ThucAn t = new ThucAn();
                    t.TenThucAn = txtTenMonAn.Text;
                    t.Gia = numDonGia.Value;
                    t.TrangThai = cboTrangThai.Text;
                    t.MoTa = txtMoTa.Text;
                    t.HinhAnh = "hinhanh.jpg";
                    t.DanhMucID = (int)cboPhanLoai.SelectedValue;
                    t.DonViTinhID = (int)cboDonViTinh.SelectedValue;
                    context.ThucAn.Add(t);
                    context.SaveChanges();

                }
                else
                {
                    var t = context.ThucAn.Find(id);
                    if (t != null)
                    {
                        t.TenThucAn = txtTenMonAn.Text;
                        t.Gia = numDonGia.Value;
                        t.TrangThai = cboTrangThai.Text;
                        t.MoTa = txtMoTa.Text;
                        t.DanhMucID = (int)cboPhanLoai.SelectedValue;
                        t.DonViTinhID = (int)cboDonViTinh.SelectedValue;

                        context.ThucAn.Update(t);
                        context.SaveChanges();
                    }
                }
                frmThucAn_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmThucAn_Load(sender, e);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTenMonAn.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmThucAn_Load(sender, e);
                return;
            }

            // 1. Lấy danh sách kết quả từ Database kèm theo các bảng liên quan (DanhMuc, DonViTinh)
            var ketQua = context.ThucAn
                .Where(sp => sp.TenThucAn.Contains(keyword))
                .Select(r => new DanhSachThucAn
                {
                    ID = r.ID,
                    DanhMucID = r.DanhMucID,
                    TenDanhMuc = r.DanhMuc.TenDanhMuc,
                    DonViTinhID = r.DonViTinhID,
                    TenDonViTinh = r.DonViTinh.TenDonViTinh,
                    TenThucAn = r.TenThucAn,
                    TrangThai = r.TrangThai,
                    Gia = r.Gia,
                    HinhAnh = r.HinhAnh,
                    MoTa = r.MoTa
                }).ToList();

            if (ketQua.Count > 0)
            {
                // 2. Tạo BindingSource mới để đồng bộ hóa việc chọn dòng trên Grid với các ô nhập liệu
                BindingSource bs = new BindingSource();
                bs.DataSource = ketQua;

                // 3. Cập nhật lại DataSource cho DataGridView
                dataGridView.DataSource = bs;

                // 4. Thiết lập lại DataBindings cho các Control để khi nhấn vào Grid thì thông tin hiện lên Textbox
                LamMoiBinding(bs);

                MessageBox.Show($"Tìm thấy {ketQua.Count} món ăn phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy món ăn nào với tên trên!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView.DataSource = null;
            }
        }

        // Hàm phụ trợ để tái sử dụng logic Binding (Tránh viết lặp code)
        private void LamMoiBinding(BindingSource bs)
        {
            txtTenMonAn.DataBindings.Clear();
            txtTenMonAn.DataBindings.Add("Text", bs, "TenThucAn", false, DataSourceUpdateMode.Never);

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bs, "MoTa", false, DataSourceUpdateMode.Never);

            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add("Value", bs, "Gia", false, DataSourceUpdateMode.Never);

            cboPhanLoai.DataBindings.Clear();
            cboPhanLoai.DataBindings.Add("SelectedValue", bs, "DanhMucID", false, DataSourceUpdateMode.Never);

            cboDonViTinh.DataBindings.Clear();
            cboDonViTinh.DataBindings.Add("SelectedValue", bs, "DonViTinhID", false, DataSourceUpdateMode.Never);

            cboTrangThai.DataBindings.Clear();
            cboTrangThai.DataBindings.Add("Text", bs, "TrangThai", false, DataSourceUpdateMode.Never);

            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bs, "HinhAnh");
            hinhAnh.Format += (s, e) =>
            {
                if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
                    e.Value = Path.Combine(Application.StartupPath, "hinhanh.jpg");
                else
                    e.Value = Path.Combine(imagesFolder, e.Value.ToString());
            };
            picHinhAnh.DataBindings.Add(hinhAnh);
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);

                string newImage = GenerateSlug(fileName) + ext;
                string fileSavePath = Path.Combine(imagesFolder, newImage);
                using (var stream = new FileStream(fileSavePath, FileMode.Open, FileAccess.Read))
                {
                    picHinhAnh.Image = Image.FromStream(stream);
                }

                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                ThucAn t = context.ThucAn.Find(id);
                t.HinhAnh = GenerateSlug(fileName) + ext;
                context.ThucAn.Update(t);
                context.SaveChanges();
                frmThucAn_Load(sender, e);
            }
        }

        private void btnXoayAnh_Click(object sender, EventArgs e)
        {
            if (picHinhAnh.Image != null)
            {
                try
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                    ThucAn t = context.ThucAn.Find(id);

                    if (t != null && !string.IsNullOrEmpty(t.HinhAnh))
                    {
                        string fullPath = Path.Combine(imagesFolder, t.HinhAnh);

                        if (File.Exists(fullPath))
                        {
                            Image currentImg = (Image)picHinhAnh.Image.Clone();
                            currentImg.RotateFlip(RotateFlipType.Rotate90FlipNone);

                            picHinhAnh.Image.Dispose();
                            picHinhAnh.Image = null;

                            currentImg.Save(fullPath);

                            picHinhAnh.Image = currentImg;
                            picHinhAnh.Refresh();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xoay: " + ex.Message);
                }
            }
        }
        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Xác nhận xóa ảnh này và dùng ảnh mặc định?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int selectedId = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                    var thucAn = context.ThucAn.Find(selectedId);

                    if (thucAn != null)
                    {
                        // Gán chuỗi rỗng thay vì NULL để tránh lỗi Database
                        thucAn.HinhAnh = "";

                        context.ThucAn.Update(thucAn);
                        context.SaveChanges();

                        // Giải phóng PictureBox
                        if (picHinhAnh.Image != null)
                        {
                            picHinhAnh.Image.Dispose();
                            picHinhAnh.Image = null;
                        }

                        frmThucAn_Load(sender, e);
                        MessageBox.Show("Đã chuyển về ảnh mặc định thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message));
                }
            }

        }
        public string GenerateSlug(string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return "";

            string str = phrase.ToLower();

            str = Regex.Replace(str, @"[áàảãạâấầẩẫậăắằẳẵặ]", "a");
            str = Regex.Replace(str, @"[éèẻẽẹêếềểễệ]", "e");
            str = Regex.Replace(str, @"[íìỉĩị]", "i");
            str = Regex.Replace(str, @"[óòỏõọôốồổỗộơớờởỡợ]", "o");
            str = Regex.Replace(str, @"[úùủũụưứừửữự]", "u");
            str = Regex.Replace(str, @"[ýỳỷỹỵ]", "y");
            str = Regex.Replace(str, @"[đ]", "d");

            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            str = Regex.Replace(str, @"\s+", " ").Trim();

            str = Regex.Replace(str, @"\s", "-");

            return str;
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
                                    string dm = r["DanhMuc"].ToString();
                                    string dvt = r["DonViTinh"].ToString();
                                    var dm_ = context.DanhMuc.FirstOrDefault(r => r.TenDanhMuc == dm);
                                    var dvt_ = context.DonViTinh.FirstOrDefault(r => r.TenDonViTinh == dvt);
                                    string ten = r["TenThucAn"].ToString();
                                    int d = Convert.ToInt32(r["Gia"]);
                                    if (ten.IsNullOrEmpty()|| d<=0 || dm_==null||dvt_==null)
                                    {
                                        throw new Exception("");
                                    }
                                    bool daTonTai = context.ThucAn.Any(x => x.TenThucAn == ten
                                      && x.Gia == d
                                      && x.MoTa == r["MoTa"].ToString()
                                      && x.DanhMucID == dm_.Id
                                      && x.DonViTinhID == dvt_.Id);
                                    if (daTonTai)
                                    {
                                       throw new Exception();
                                    }
                                    ThucAn t = new ThucAn();
                                    t.DanhMucID = dm_.Id;
                                    t.DonViTinhID = dvt_.Id;
                                    t.TenThucAn = ten;
                                    t.Gia = d;
                                    t.TrangThai = r["TrangThai"].ToString() ;
                                    t.MoTa = r["MoTa"].ToString();
                                    t.HinhAnh = r["HinhAnh"].ToString();
                                    context.ThucAn.Add(t);
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
                            frmThucAn_Load(sender, e);
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
            saveFileDialog.FileName = "ThucAn_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[8] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("DanhMuc", typeof(string)),
                        new DataColumn("DonViTinh", typeof(string)),
                        new DataColumn("TenThucAn", typeof(string)),
                        new DataColumn("Gia", typeof(int)),
                        new DataColumn("TrangThai", typeof(string)),
                        new DataColumn("MoTa", typeof(string)),
                        new DataColumn("HinhAnh", typeof(string))});
                    var thucAn = context.ThucAn.ToList();
                    if (thucAn != null)
                    {
                        foreach (var p in thucAn)
                        {
                            var dm = context.DanhMuc.FirstOrDefault(r => r.Id== p.DanhMucID);
                            var dvt = context.DonViTinh.FirstOrDefault(r => r.Id == p.DonViTinhID);
                            table.Rows.Add(p.ID, dm.TenDanhMuc, dvt.TenDonViTinh, p.TenThucAn, p.Gia, p.TrangThai,p.MoTa, p.HinhAnh);
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "ThucAn");
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