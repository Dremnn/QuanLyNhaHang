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

        public List<DonHang> getAllDangMo()
        {
            return donHangDAO.getAllDangMo();
        }

        public bool datBan(int banId, int? khachHangId)
        {
            List<Ban> danhSachTrong = banDAO.getBanTrong();
            bool banConTrong = danhSachTrong.Exists(b => b.Id == banId);

            if (!banConTrong)
                return false;

            DonHang donHang = new DonHang(
                banId: banId,
                khachHangId: khachHangId,
                nguoiDungId: null,
                ghiChu: null
            );

            int newId = donHangDAO.insert(donHang);
            if (newId <= 0)
                return false;

            banDAO.updateTrangThai(banId, "CóKhách");
            return true;
        }

        public bool huyDatBan(int donHangId)
        {
            // Lấy banId trước khi huỷ
            int banId = donHangDAO.getBanIdByDonHang(donHangId);

            // Huỷ đơn hàng
            bool ketQua = donHangDAO.huyDonHang(donHangId);
            if (!ketQua)
                return false;

            // Cập nhật trạng thái bàn về Trống
            banDAO.updateTrangThai(banId, "Trong");
            return true;
        }

        public bool updateTrangThai(int donHangId, string trangThai)
        {
            return donHangDAO.updateTrangThai(donHangId, trangThai);
        }
    }
}
