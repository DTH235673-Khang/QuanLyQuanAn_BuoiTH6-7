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
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmBangCong : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id;

        public frmBangCong()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            cboThang.Enabled = giaTri;
            cboNam.Enabled = giaTri;
            btnXem.Enabled = giaTri;
            cboNhanVien.Enabled = giaTri;
            btnIn.Enabled = giaTri;
            btnOut.Enabled = giaTri;
            btnXuat.Enabled = giaTri;
            btnNhap.Enabled = giaTri;
            btnSua.Enabled = giaTri;
        }
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }

        private void NapDuLieuChoComboBox()
        {
            // Nạp danh sách tháng 1-12
            cboThang.DataSource = Enumerable.Range(1, 12).ToList();

            // Nạp danh sách năm (ví dụ từ 2025 đến 2030)
            cboNam.DataSource = Enumerable.Range(2025, 6).ToList();
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            // Kiểm tra an toàn: Nếu chưa chọn giá trị thì thoát hàm, không chạy code bên dưới
            if (cboThang.SelectedValue == null || cboNam.SelectedValue == null)
            {
                MessageBox.Show("ComboBox chưa có dữ liệu hoặc chưa chọn tháng/năm!");
                return;
            }
            try
            {
                // Ép kiểu an toàn
                int thang = Convert.ToInt32(cboThang.SelectedValue);
                int nam = Convert.ToInt32(cboNam.SelectedValue);
                var bc = context.BangCong.Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam).ToList();
                if (bc.Count == 0 && thang != DateTime.Now.Month)
                {
                    MessageBox.Show($"Không có chấm công phát sinh trong tháng {thang} năm {nam}",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BatTatChucNang(true);
                    var bangcong = context.BangCong.Select(bc => new
                    {
                        bc.ID,
                        bc.Ngay,
                        HoVaTenNhanVien = bc.NhanVien.HoVaTen,
                        bc.GioVaoThucTe,
                        bc.GioRaThucTe,
                        bc.SoGioLam
                    }).ToList();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = bangcong;
                    dataGridView.DataSource = bangcong;

                }

            }
            catch (Exception ex)
            {
                // Debug lỗi nếu có vấn đề về kết nối CSDL
                Console.WriteLine("Lỗi truy vấn: " + ex.Message);
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNhanVien.SelectedValue == null || cboNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để check-in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dataGridView.AutoGenerateColumns = false;
                int nhanVienId = (int)cboNhanVien.SelectedValue;
                DateTime bayGio = DateTime.Now;

                DateTime gioRaMacDinh = bayGio.Date.AddDays(1);

                double soGioLam = (gioRaMacDinh - bayGio).TotalHours;

                var checkInMoi = new BangCong
                {
                    NhanVienID = nhanVienId,
                    Ngay = DateOnly.FromDateTime(bayGio.Date),
                    GioVaoThucTe = bayGio,
                    GioRaThucTe = gioRaMacDinh,
                    SoGioLam = (float)soGioLam
                };
                var check = context.BangCong.FirstOrDefault(b => b.Ngay == checkInMoi.Ngay && b.NhanVienID == checkInMoi.NhanVienID);
                if (check != null && check.GioRaThucTe > checkInMoi.GioVaoThucTe)
                    MessageBox.Show("Nhân viên đã check in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    context.BangCong.Add(checkInMoi);
                    context.SaveChanges();
                    MessageBox.Show($"Check-in thành công cho nhân viên: {cboNhanVien.Text}\nGiờ vào: {bayGio.ToString("HH:mm:ss")}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnXem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBangCong_Load(object sender, EventArgs e)
        {
            NapDuLieuChoComboBox();
            cboThang.SelectedItem = DateTime.Now.Month;
            cboNam.SelectedItem = DateTime.Now.Year;
            LayNhanVienVaoComboBox();
            btnXem_Click(sender, e);

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNhanVien.SelectedValue == null || cboNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dataGridView.AutoGenerateColumns = false;
                int nhanVienId = (int)cboNhanVien.SelectedValue;
                var check = context.BangCong.FirstOrDefault(b => b.Ngay == DateOnly.FromDateTime(DateTime.Now) && b.NhanVienID == nhanVienId);
                if (check != null)
                {
                    check.GioRaThucTe = DateTime.Now;
                    check.SoGioLam = (float)(check.GioRaThucTe - check.GioVaoThucTe).TotalHours;
                    context.BangCong.Update(check);
                    context.SaveChanges();
                    MessageBox.Show($"Check-out thành công cho nhân viên: {cboNhanVien.Text}\nGiờ ra: {DateTime.Now.ToString("HH:mm:ss")}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmBangCong_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnXuat_Click(object sender, EventArgs e)
        {
            int thang = Convert.ToInt32(cboThang.SelectedValue);
            int nam = Convert.ToInt32(cboNam.SelectedValue);
            var bc = context.BangCong.Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam).ToList();
            if (bc.Count == 0 )
            {
                MessageBox.Show($"Không có chấm công phát sinh trong tháng {thang} năm {nam}",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var data = context.BangCong.Where(b => b.Ngay.Month == thang && b.Ngay.Year == nam)
                .GroupBy(b => b.NhanVien.HoVaTen)
                .Select(g => new
                {
                    Ten = g.Key,
                    Tong = g.Sum(x => x.SoGioLam),
                    ChiTiet = g.ToList()
                }).ToList();

            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Nhân Viên");
            dt.Columns.Add("Tổng Giờ", typeof(double));
            int ngay=0;
            switch (thang)
            {
                case 1:ngay = 31;break;
                case 2:ngay = 28;break;
                case 3:ngay = 31;break;
                case 4:ngay = 30;break;
                case 5:ngay = 31;break;
                case 6:ngay = 30;break;
                case 7:ngay = 31;break;
                case 8:ngay = 31;break;
                case 9:ngay = 31;break;
                case 10:ngay = 30;break;
                case 11:ngay = 30;break;
                case 12:ngay = 31;break;
            }
            if (nam%400==0 && thang==2)
            {
                ngay = 29;
            }    
            for (int i = 1; i <= ngay; i++) dt.Columns.Add(i+"/"+thang, typeof(double));

            // Đổ dữ liệu vào DataTable
            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                dr["Tên Nhân Viên"] = item.Ten;
                dr["Tổng Giờ"] = Math.Round((double)item.Tong, 2);
                foreach (var c in item.ChiTiet) dr[c.Ngay.Day+"/"+thang] = Math.Round((double)c.SoGioLam, 2);
                dt.Rows.Add(dr);
            }

            SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel|*.xlsx", FileName = $"BangCong_{thang}_{nam}.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(dt, "BangCong");

                // Format 2 số lẻ cho cột Tổng Giờ và các ngày
                ws.Range("B2:AG" + (dt.Rows.Count + 1)).Style.NumberFormat.Format = "0.00";
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);
                MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

