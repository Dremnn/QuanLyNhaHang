using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class KhachHang : NguoiDung
    {
        public int KhachHangId { get; set; }
        public int? NguoiDungId { get; set; }   // NULL = vãng lai
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayTaoKH { get; set; } = DateTime.Now;
        public string HinhAnh { get; set; }

        public bool LaVangLai => NguoiDungId == null;

        // Constructor khách vãng lai
        public KhachHang(string hoTen, string soDienThoai)
        {
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            NguoiDungId = null;
            VaiTro = VaiTro.KhachHang;
            HinhAnh = null;  // Khách hàng vãng lai không có hình ảnh
        }

        // Constructor khách đã đăng ký
        public KhachHang(int id, string tenDangNhap, string matKhau, bool hoatDong, DateTime ngayTao,
                         int khachHangId, int? nguoiDungId, string hoTen, string soDienThoai,
                         string email, string diaChi, DateTime ngayTaoKH,  string hinhAnh)
            : base(id, tenDangNhap, matKhau, VaiTro.KhachHang, hoatDong, ngayTao, hinhAnh)
        {
            KhachHangId = khachHangId;
            NguoiDungId = nguoiDungId;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            Email = email;
            DiaChi = diaChi;
            NgayTaoKH = ngayTaoKH;
            HinhAnh = null;
        }
    }
}
