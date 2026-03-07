using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Data
{
    public class LichLam
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public int CaLamID { get; set; }
        public DateTime NgayPhanCong {  get; set; }
        public virtual NhanVien NhanVien { get; set; } = null;
        public virtual CaLam CaLam { get; set; } = null;
    }
}
