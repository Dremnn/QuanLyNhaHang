using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class ChiTietDon
    {
        public int Id { get; set; }
        public int DonHangId { get; set; }
        public int MonAnId { get; set; }
        public int SoLuong { get; set; } = 1;
        public decimal DonGia { get; set; }
        public string GhiChu { get; set; }

        // Navigation property
        public string TenMon { get; set; }

        public ChiTietDon() { }

        public ChiTietDon(int donHangId, int monAnId, int soLuong, decimal donGia, string ghiChu)
        {
            DonHangId = donHangId;
            MonAnId = monAnId;
            SoLuong = soLuong;
            DonGia = donGia;
            GhiChu = ghiChu;
        }

        public decimal ThanhTien => SoLuong * DonGia;
    }
}
