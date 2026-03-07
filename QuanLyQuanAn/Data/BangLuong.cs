using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Data
{
    public class BangLuong
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public int Thang {  get; set; }
        public int Nam { get; set; }
        public decimal TongGio { get; set; }
        public decimal TongLuong { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null;
    }
}
