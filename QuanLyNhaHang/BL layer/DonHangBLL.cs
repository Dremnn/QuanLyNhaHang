using System;
using System.Collections.Generic;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class DonHangBLL
    {
        private DonHangDAO donHangDAO = new DonHangDAO();

        public List<DonHang> getByKhachHangId(int khachHangId)
        {
            return donHangDAO.getByKhachHangId(khachHangId);
        }

        private BanDAO banDAO = new BanDAO();

        public bool datBan(int banId, int khachHangId)
        {
            // Kiểm tra bàn còn trống không
            List<Ban> danhSachTrong = banDAO.getBanTrong();
            bool banConTrong = danhSachTrong.Exists(b => b.Id == banId);

            if (!banConTrong)
                return false;

            // Tạo đơn hàng mới
            DonHang donHang = new DonHang(
                banId: banId,
                khachHangId: khachHangId,
                nguoiDungId: null,
                ghiChu: null
            );

            int newId = donHangDAO.insert(donHang);
            if (newId <= 0)
                return false;

            // Cập nhật trạng thái bàn → CóKhách
            banDAO.updateTrangThai(banId, "CóKhách");

            return true;
        }
    }
}
