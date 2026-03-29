using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    public enum PhuongThucThanhToan
    {
        TienMat,
        ChuyenKhoan,
        QuetThe,
        ViDienTu
    }

    public enum TrangThaiThanhToan
    {
        ThanhCong,
        ThatBai,
        HoanTien
    }

    public class ThanhToan
    {
        public int Id { get; set; }
        public int DonHangId { get; set; }
        public decimal TongTien { get; set; }
        public decimal TienGiam { get; set; } = 0;
        public decimal TienThanhToan { get; set; }
        public PhuongThucThanhToan PhuongThuc { get; set; } = PhuongThucThanhToan.TienMat;
        public TrangThaiThanhToan TrangThai { get; set; } = TrangThaiThanhToan.ThanhCong;
        public string GhiChu { get; set; }
        public DateTime NgayThanhToan { get; set; } = DateTime.Now;

        public ThanhToan() { }

        public ThanhToan(int donHangId, decimal tongTien, decimal tienGiam,
                         PhuongThucThanhToan phuongThuc)
        {
            DonHangId = donHangId;
            TongTien = tongTien;
            TienGiam = tienGiam;
            TienThanhToan = tongTien - tienGiam;
            PhuongThuc = phuongThuc;
        }
    }
}
