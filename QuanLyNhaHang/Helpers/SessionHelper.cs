using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Helpers
{
    public static class SessionHelper
    {
        // Lưu user đang đăng nhập, null = chưa đăng nhập
        public static NguoiDung CurrentUser { get; private set; } = null;

        public static void login(NguoiDung nguoiDung)
        {
            CurrentUser = nguoiDung;
        }

        public static void logout()
        {
            CurrentUser = null;
        }

        public static bool isLoggedIn()
        {
            return CurrentUser != null;
        }

        public static bool isAdmin()
        {
            return CurrentUser?.VaiTro == VaiTro.Admin;
        }

        public static bool isNhanVien()
        {
            return CurrentUser?.VaiTro == VaiTro.NhanVien;
        }

        public static bool isKhachHang()
        {
            return CurrentUser?.VaiTro == VaiTro.KhachHang;
        }
    }
}
