using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public bool QuyenHan {  get; set; }
        public int ChucVuID { get; set; }
        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
        public virtual ObservableCollectionListSource<PhieuNhapKho> PhieuNhapKho { get; } = new();
        public virtual ObservableCollectionListSource<LichLam> LichLam { get; } = new();
        public virtual ObservableCollectionListSource<BangCong> BangCong { get; } = new();

        public virtual ChucVu ChucVu { get; set; } = null!;


    }
}
