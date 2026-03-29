using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public enum TrangThaiDonHang
    {
        ChoDuyet,
        DangCheBien,
        DaPhucVu,
        YeuCauTinh,
        DaThanhToan,
        Huy
    }

    public class DonHang
    {
        public int Id { get; set; }
        public int BanId { get; set; }
        public int? KhachHangId { get; set; }
        public int? NguoiDungId { get; set; }
        public TrangThaiDonHang TrangThai { get; set; } = TrangThaiDonHang.ChoDuyet;
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public DateTime? NgayDong { get; set; }

        // Navigation properties
        public string SoBan { get; set; }
        public string TenKhachHang { get; set; }
        public List<ChiTietDon> ChiTietDons { get; set; } = new List<ChiTietDon>();

        public DonHang() { }

        public DonHang(int banId, int? khachHangId, int? nguoiDungId, string ghiChu)
        {
            BanId = banId;
            KhachHangId = khachHangId;
            NguoiDungId = nguoiDungId;
            GhiChu = ghiChu;
        }

        public decimal TongTien => ChiTietDons.Sum(ct => ct.ThanhTien);
    }
}
