using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class ThanhToanBLL
    {
        private ThanhToanDAO thanhToanDAO = new ThanhToanDAO();
        private DonHangDAO donHangDAO = new DonHangDAO();
        private BanDAO banDAO = new BanDAO();
        private ChiTietDonDAO chiTietDonDAO = new ChiTietDonDAO();

        public bool thanhToan(int donHangId, decimal tienGiam,
                              PhuongThucThanhToan phuongThuc, string ghiChu)
        {
            // Kiểm tra đơn đã thanh toán chưa
            ThanhToan existing = thanhToanDAO.getByDonHangId(donHangId);
            if (existing != null)
                return false;

            // Tính tổng tiền
            decimal tongTien = 0;
            var chiTietList = chiTietDonDAO.getByDonHangId(donHangId);
            foreach (var ct in chiTietList)
                tongTien += ct.ThanhTien;

            // Validate tiền giảm
            if (tienGiam < 0 || tienGiam > tongTien)
                return false;

            // Tạo thanh toán
            ThanhToan thanhToan = new ThanhToan(
                donHangId: donHangId,
                tongTien: tongTien,
                tienGiam: tienGiam,
                phuongThuc: phuongThuc
            )
            {
                GhiChu = ghiChu,
                TrangThai = TrangThaiThanhToan.ThanhCong
            };

            int newId = thanhToanDAO.insert(thanhToan);
            if (newId <= 0)
                return false;

            donHangDAO.updateTrangThai(donHangId, "DaThanhToan");

            // Cập nhật trạng thái bàn → Trong
            int banId = donHangDAO.getBanIdByDonHang(donHangId);
            banDAO.updateTrangThai(banId, "Trong");

            return true;
        }

        public ThanhToan getByDonHangId(int donHangId)
        {
            return thanhToanDAO.getByDonHangId(donHangId);
        }
    }
}