using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public class Admin : NguoiDung
    {
        public Admin()
        {
            VaiTro = VaiTro.Admin;
        }

        public Admin(int id, string tenDangNhap, string matKhau, bool hoatDong, DateTime ngayTao)
            : base(id, tenDangNhap, matKhau, VaiTro.Admin, hoatDong, ngayTao) { }
    }
}
