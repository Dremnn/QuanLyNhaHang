using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class DanhMuc
    {
        public int Id { get; set; }
        public string TenDanhMuc { get; set; }
        public int ThuTu { get; set; } = 0;

        public DanhMuc() { }

        public DanhMuc(int id, string tenDanhMuc, int thuTu)
        {
            Id = id;
            TenDanhMuc = tenDanhMuc;
            ThuTu = thuTu;
        }

        public override string ToString() => TenDanhMuc;
    }
}
