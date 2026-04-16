using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public enum VaiTro
    {
        Admin,
        NhanVien,
        KhachHang
    }

    public class NguoiDung
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public VaiTro VaiTro { get; set; }
        public bool HoatDong { get; set; } = true;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string HinhAnh { get; set; }

        public NguoiDung() { }


        public NguoiDung(int id, string tenDangNhap, string matKhau, VaiTro vaiTro, bool hoatDong, DateTime ngayTao, string hinhAnh)
        {
            Id = id;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            VaiTro = vaiTro;
            HoatDong = hoatDong;
            NgayTao = ngayTao;
            HinhAnh = hinhAnh;
        }

        public override string ToString() => $"[{VaiTro}] {TenDangNhap}";
    }
}

