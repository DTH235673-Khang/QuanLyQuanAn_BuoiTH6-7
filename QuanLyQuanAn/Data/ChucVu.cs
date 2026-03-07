using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class ChucVu
    {
        public int ID {  get; set; }
        public string TenChucVu { get; set; }
        public decimal LuongTheoGio { get; set; }
        public virtual ObservableCollectionListSource<NhanVien> NhanVien { get; } = new();


    }
}
