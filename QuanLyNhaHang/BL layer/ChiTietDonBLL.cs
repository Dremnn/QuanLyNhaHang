using System.Collections.Generic;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class ChiTietDonBLL
    {
        private ChiTietDonDAO chiTietDonDAO = new ChiTietDonDAO();
        private MonAnDAO monAnDAO = new MonAnDAO();

        public List<ChiTietDon> getByDonHangId(int donHangId)
        {
            return chiTietDonDAO.getByDonHangId(donHangId);
        }

        public bool themMon(int donHangId, int monAnId, int soLuong, string ghiChu)
        {
            // Validate
            if (soLuong <= 0)
                return false;

            // Lấy giá hiện tại của món
            List<MonAn> list = monAnDAO.getAll();
            MonAn mon = list.Find(m => m.Id == monAnId);

            if (mon == null || !mon.ConHang)
                return false;

            ChiTietDon chiTiet = new ChiTietDon(
                donHangId: donHangId,
                monAnId: monAnId,
                soLuong: soLuong,
                donGia: mon.GiaBan,
                ghiChu: ghiChu
            );

            return chiTietDonDAO.insert(chiTiet) > 0;
        }

        public bool xoaMon(int chiTietId)
        {
            return chiTietDonDAO.delete(chiTietId);
        }

        public bool capNhatSoLuong(int chiTietId, int soLuong)
        {
            if (soLuong <= 0)
                return false;

            return chiTietDonDAO.updateSoLuong(chiTietId, soLuong);
        }

        public decimal tinhTongTien(int donHangId)
        {
            List<ChiTietDon> list = chiTietDonDAO.getByDonHangId(donHangId);
            decimal tong = 0;

            foreach (ChiTietDon ct in list)
                tong += ct.ThanhTien;

            return tong;
        }
    }
}