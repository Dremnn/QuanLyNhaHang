using System;

namespace QuanLyNhaHang.Model
{
    public class MonAn : IMonAnComponent
    {
        public int Id { get; set; }
        public int DanhMucId { get; set; }
        public string TenMon { get; set; }
        public string MoTa { get; set; }
        public decimal GiaBan { get; set; }
        public bool ConHang { get; set; } = true;
        public string AnhUrl { get; set; }

        public string TenDanhMuc { get; set; }

        public MonAn() { }

        public MonAn(int id, int danhMucId, string tenMon, string moTa,
                     decimal giaBan, bool conHang, string anhUrl)
        {
            Id = id;
            DanhMucId = danhMucId;
            TenMon = tenMon;
            MoTa = moTa;
            GiaBan = giaBan;
            ConHang = conHang;
            AnhUrl = anhUrl;
        }

        public override string ToString() => $"{TenMon} - {GiaBan:N0}đ";

        // COMPOSITE PATTERN
        public string LaysTen()
        {
            return TenMon;
        }

        public decimal TinhGia()
        {
            return GiaBan;
        }
    }
}