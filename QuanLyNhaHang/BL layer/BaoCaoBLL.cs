using System;
using System.Collections.Generic;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class BaoCaoBLL
    {
        private ThanhToanDAO thanhToanDAO = new ThanhToanDAO();
        private ChiTietDonDAO chiTietDonDAO = new ChiTietDonDAO();

        // Doanh thu theo khoảng ngày
        public decimal getDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            List<ThanhToan> list = thanhToanDAO.getByNgay(tuNgay, denNgay);
            decimal tong = 0;
            foreach (ThanhToan tt in list)
                tong += tt.TienThanhToan;
            return tong;
        }

        // Danh sách thanh toán theo khoảng ngày
        public List<ThanhToan> getBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return thanhToanDAO.getByNgay(tuNgay, denNgay);
        }

        // Món bán chạy — cần thêm query riêng
        public List<MonAnBanChay> getMonBanChay(DateTime tuNgay, DateTime denNgay)
        {
            return chiTietDonDAO.getMonBanChay(tuNgay, denNgay);
        }
    }
}