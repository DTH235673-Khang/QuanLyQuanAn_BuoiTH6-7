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

namespace QuanLyQuanAn.Forms
{
    public partial class frmChiTietBan : Form
    {
       QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        string tablename; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        public frmChiTietBan(string ban)
        {
            InitializeComponent();
            tablename = ban;
        }
        public frmChiTietBan(int s)
        {
            InitializeComponent();
            btnMoBan.Enabled = false;
            tablename = s.ToString();
        }

        private void btnMoBan_Click(object sender, EventArgs e)
        {

            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(tablename))
            {
                chiTiet.ShowDialog();
                var re = context.Ban.FirstOrDefault(r => r.TenBan == tablename);
                HoaDon hd = context.HoaDon.FirstOrDefault(r => r.BanID.Equals(re.ID) && r.trangthai == 0);
                if (hd != null)
                {
                    Ban b = context.Ban.FirstOrDefault(r => r.TenBan.Contains(tablename));
                    b.TrangThai = "1";
                    context.SaveChanges();
                }

            }
            this.Close();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            var re = context.Ban.FirstOrDefault(r => r.TenBan == tablename);
            var hd = context.HoaDon.FirstOrDefault(r => r.BanID == re.ID);
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(hd.ID))
            {
                chiTiet.ShowDialog();
            }
            this.Close();

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Ban b = context.Ban.FirstOrDefault(r => r.TenBan.Contains(tablename));
            HoaDon hd = context.HoaDon.FirstOrDefault(r => r.BanID.Equals(b.ID) && r.trangthai == 0);
            if (b != null)
            {
                b.TrangThai = "0";
                hd.trangthai = 1;

            }
            context.SaveChanges();
            this.Close();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (txtBanMoi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập bàn sẽ chuyển tới!", "Thông báo");
                return;
            }
            Ban b_canchuyen = context.Ban.FirstOrDefault(r => r.TenBan.Contains(tablename));
            Ban b_goc = context.Ban.FirstOrDefault(r => r.TenBan.Contains(txtBanMoi.Text));
            HoaDon hd_canchuyen = context.HoaDon.FirstOrDefault(r => r.BanID.Equals(b_canchuyen.ID) && r.trangthai == 0);

            if (b_goc != null && b_goc.TrangThai == "0")
            {
                hd_canchuyen.BanID = b_goc.ID;
                b_canchuyen.TrangThai = "0";
                b_goc.TrangThai = "1";
                context.SaveChanges();
            }
            else if (b_goc == null)
            {
                MessageBox.Show("Bàn mới không tồn tại!", "Thông báo");
            }
            else if (b_goc.TrangThai == "1")
            {
                DialogResult r = MessageBox.Show("Bàn " + txtBanMoi.Text + " đang có khách:" +
                    "\n +Bấm Yes nếu bạn muốn gộp 2 bàn lại " +
                    "\n +Bấm No nếu bạn chỉ muốn switch 2 bàn " +
                    "\n +Bấm Cancel nếu bạn muốn dừng thao tác", "Thông báo", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    HoaDon hd_goc = context.HoaDon.FirstOrDefault(r => r.BanID.Equals(b_goc.ID) && r.trangthai == 0);
                    var cthd = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == hd_canchuyen.ID);
                    foreach (var item in cthd)
                    {
                        var montrung = context.HoaDon_ChiTiet.FirstOrDefault(ct => ct.HoaDonID.Equals(hd_goc.ID) && ct.ThucAnID == item.ThucAnID);
                        if (montrung != null)
                        {
                            montrung.SoLuongBan += item.SoLuongBan;
                            context.HoaDon_ChiTiet.Remove(item);
                        }
                        else
                        {
                            item.HoaDonID = hd_goc.ID;
                        }
                    }
                    context.SaveChanges();
                    context.HoaDon.Remove(hd_canchuyen);
                    b_canchuyen.TrangThai = "0";
                    hd_goc.TongTien = context.HoaDon_ChiTiet.Where(ct => ct.HoaDonID == hd_goc.ID).Sum(ct => ct.DonGiaBan * ct.SoLuongBan);
                    context.SaveChanges();
                }
                else if (r == DialogResult.No)
                {
                    HoaDon hd_goc = context.HoaDon.FirstOrDefault(r => r.BanID.Equals(b_goc.ID) && r.trangthai == 0);
                    hd_canchuyen.BanID = b_goc.ID;
                    hd_goc.BanID = b_canchuyen.ID;
                    context.SaveChanges();
                }
            }
            this.Close();

        }

        private void frmChiTietBan_Load(object sender, EventArgs e)
        {

        }
    }
}

