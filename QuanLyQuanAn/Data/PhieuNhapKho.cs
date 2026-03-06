using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class PhieuNhapKho
    {
        public int ID { get; set; }
        public DateTime NgayNhap { get; set; }
        public int NhanVienID { get; set; }
        public int NhaCungCapID { get; set; }
        public double TongTien {  get; set; }
        public string TrangThai {  get; set; }
        public string? GhiChu {  get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;
        public virtual NhaCungCap NhaCungCap { get; set; } = null!;

        public virtual ObservableCollectionListSource<PhieuNhapKho_ChiTiet> PhieuNhapKho_ChiTiet { get; } = new();
        [NotMapped]
        public class DanhSachPhieuNhapKho
        {
            public int ID { get; set; }
            public int NhanVienID { get; set; }
            public string HoVaTenNhanVien { get; set; }
            public int NhaCungCapID { get; set; }
            public string TenNhaCungCap { get; set; }
            public DateTime NgayNhap { get; set; }
            public double? TongTien { get; set; }
            public string TrangThai { get; set; }
            public string? XemChiTiet { get; set; }

            public string? GhiChu { get; set; }


        }

    }
}

