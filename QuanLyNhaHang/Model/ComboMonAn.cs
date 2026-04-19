using System;
using System.Collections.Generic;

namespace QuanLyNhaHang.Model
{
    public class ComboMonAn : IMonAnComponent
    {
        public string TenCombo { get; set; }
        public decimal PhanTramGiamGia { get; set; }

        // Chứa danh sách các món ăn thật trong Database
        private List<IMonAnComponent> _danhSachMon = new List<IMonAnComponent>();

        public ComboMonAn(string tenCombo, decimal phanTramGiamGia)
        {
            TenCombo = tenCombo;
            PhanTramGiamGia = phanTramGiamGia;
        }

        public void ThemMon(IMonAnComponent mon)
        {
            if (mon != null) _danhSachMon.Add(mon);
        }

        public string LaysTen()
        {
            return TenCombo;
        }

        // Tự động cộng giá và áp dụng giảm giá 
        public decimal TinhGia()
        {
            decimal tongTienGoc = 0;
            foreach (IMonAnComponent mon in _danhSachMon)
            {
                tongTienGoc += mon.TinhGia();
            }
            return tongTienGoc * (1 - PhanTramGiamGia);
        }
    }
}