using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class NguoiDungBLL
    {
        private NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        private KhachHangDAO khachHangDAO = new KhachHangDAO();

        // Đăng nhập - trả về NguoiDung nếu thành công, null nếu thất bại
        public NguoiDung login(string tenDangNhap, string matKhau)
        {
            // Kiểm tra input rỗng
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                return null;

            // Tìm user trong DB
            NguoiDung nguoiDung = nguoiDungDAO.getByTenDangNhap(tenDangNhap);

            // Không tìm thấy
            if (nguoiDung == null)
                return null;

            // Tài khoản bị khoá
            if (!nguoiDung.HoatDong)
                return null;

            // Sai mật khẩu
            if (!PasswordHelper.verifyPassword(matKhau, nguoiDung.MatKhau))
                return null;

            return nguoiDung;
        }

        // Đăng ký tài khoản mới
        public bool dangKy(string tenDangNhap, string matKhau, string hoTen, string soDienThoai)
        {
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau)
                || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
                return false;

            if (nguoiDungDAO.isTenDangNhapExists(tenDangNhap))
                return false;

            // ← thêm check SĐT trùng
            if (khachHangDAO.getBySoDienThoai(soDienThoai) != null)
                return false;

            // Tạo NguoiDung
            NguoiDung nguoiDung = new NguoiDung
            {
                TenDangNhap = tenDangNhap,
                MatKhau = PasswordHelper.hashPassword(matKhau),
                VaiTro = VaiTro.KhachHang,
                HoatDong = true
            };

            int newId = nguoiDungDAO.insert(nguoiDung);
            if (newId <= 0) return false;

            KhachHang khachHang = new KhachHang(hoTen, soDienThoai)
            {
                NguoiDungId = newId
            };

            int khachHangId = khachHangDAO.insert(khachHang);
            return khachHangId > 0;
        }

        public List<NguoiDung> getAll()
        {
            return nguoiDungDAO.getAll();
        }

        public bool updateHoatDong(int id, bool hoatDong)
        {
            return nguoiDungDAO.updateHoatDong(id, hoatDong);
        }

        public bool updateVaiTro(int id, string vaiTro)
        {
            // Không cho đổi vai trò của chính mình
            if (id == SessionHelper.CurrentUser.Id)
                return false;

            return nguoiDungDAO.updateVaiTro(id, vaiTro);
        }
    }
}
