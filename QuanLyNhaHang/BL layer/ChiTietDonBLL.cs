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
            if (soLuong <= 0) return false;

            List<MonAn> list = monAnDAO.getAll();
            MonAn monGoc = list.Find(m => m.Id == monAnId);

            if (monGoc == null || !monGoc.ConHang) return false;

            decimal giaChot = monGoc.GiaBan;
            string ghiChuMoi = ghiChu;

            // ==========================================
            // KHU VỰC KÍCH HOẠT COMPOSITE PATTERN
            // ==========================================
            if (monGoc.DanhMucId == 8) // Kiểm tra nếu thuộc danh mục Combo
            {
                MonAnBLL bll = new MonAnBLL();
                // Gọi lại sức mạnh của Composite Pattern ở BLL để tính giá
                giaChot = bll.TinhGiaThucTe(monGoc);

                // Tự động tạo ghi chú cho bếp và in hóa đơn
                if (monGoc.Id == 28)
                    ghiChuMoi += " (Cơm Sườn, Canh Chua)";
                else if (monGoc.Id == 29)
                    ghiChuMoi += " (Cơm Sườn Bì Chả, Canh Chua, Sting)";
                else if (monGoc.Id == 30)
                    ghiChuMoi += " (Cơm Sườn Bì Chả, Tốp Mỡ, Trứng Ốp La, Canh Chua, Sting)";
            }
            // ==========================================

            ChiTietDon chiTiet = new ChiTietDon(
                donHangId: donHangId,
                monAnId: monAnId,
                soLuong: soLuong,
                donGia: giaChot, // <-- Đưa giá của Pattern xuống DB
                ghiChu: ghiChuMoi
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