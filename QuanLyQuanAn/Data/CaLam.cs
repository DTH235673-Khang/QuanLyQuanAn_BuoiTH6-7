using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class CaLam
    {
        public int Id { get; set; }
        public string TenCa { get; set; }
        public TimeOnly GioBatDau { get; set; }
        public TimeOnly GioKetThuc { get; set; }
        public float HeSoLuong { get; set; }
        public virtual ObservableCollectionListSource<LichLam> LichLam { get; } = new();

    }
}
