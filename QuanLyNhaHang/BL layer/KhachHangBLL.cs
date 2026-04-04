using System;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class KhachHangBLL
    {
        private KhachHangDAO khachHangDAO = new KhachHangDAO();

        public KhachHang getByNguoiDungId(int nguoiDungId)
        {
            return khachHangDAO.getByNguoiDungId(nguoiDungId);
        }

        public bool update(KhachHang khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.HoTen))
                return false;

            if (string.IsNullOrEmpty(khachHang.SoDienThoai))
                return false;

            return khachHangDAO.update(khachHang);
        }

        public KhachHang getBySoDienThoai(string soDienThoai)
        {
            return khachHangDAO.getBySoDienThoai(soDienThoai);
        }

        public int insertVangLai(KhachHang khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.HoTen) ||
                string.IsNullOrEmpty(khachHang.SoDienThoai))
                return -1;

            return khachHangDAO.insert(khachHang);
        }
    }
}
