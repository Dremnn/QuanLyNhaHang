using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class NhanVien : NguoiDung
    {
        public NhanVien()
        {
            VaiTro = VaiTro.NhanVien;
        }

        public NhanVien(int id, string tenDangNhap, string matKhau, bool hoatDong, DateTime ngayTao)
            : base(id, tenDangNhap, matKhau, VaiTro.NhanVien, hoatDong, ngayTao) { }
    }
}
