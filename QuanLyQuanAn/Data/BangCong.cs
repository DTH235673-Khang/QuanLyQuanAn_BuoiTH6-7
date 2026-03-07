using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Data
{
    public class BangCong
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public DateOnly Ngay {  get; set; }
        public DateTime GioVaoThucTe { get; set; }
        public DateTime GioRaThucTe { get; set; }
        public string TrangThai { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null;
    }
}
