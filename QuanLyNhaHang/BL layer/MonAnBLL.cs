using System;
using System.Collections.Generic;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class MonAnBLL
    {
        private MonAnDAO monAnDAO = new MonAnDAO();

        public List<MonAn> getAll()
        {
            return monAnDAO.getAll();
        }

        public List<MonAn> getByDanhMuc(int danhMucId)
        {
            return monAnDAO.getByDanhMuc(danhMucId);
        }

        public bool insert(MonAn monAn)
        {
            if (string.IsNullOrEmpty(monAn.TenMon))
                return false;

            if (monAn.GiaBan <= 0)
                return false;

            return monAnDAO.insert(monAn) > 0;
        }

        public bool update(MonAn monAn)
        {
            if (string.IsNullOrEmpty(monAn.TenMon))
                return false;

            if (monAn.GiaBan <= 0)
                return false;

            return monAnDAO.update(monAn);
        }

        public bool delete(int id)
        {
            return monAnDAO.delete(id);
        }

        public bool updateConHang(int id, bool conHang)
        {
            return monAnDAO.updateConHang(id, conHang);
        }

        public decimal TinhGiaThucTe(MonAn mon)
        {
            // Nếu không phải là danh mục Combo (id = 5), trả về giá Database
            if (mon.DanhMucId != 8)
                return mon.GiaBan;

            List<MonAn> all = monAnDAO.getAll();
            ComboMonAn comboPattern = null;

            // 50: Combo Sinh Viên (Giảm 10%)
            if (mon.Id == 28)
            {
                comboPattern = new ComboMonAn("Combo Sinh Viên", 0.1m);
                comboPattern.ThemMon(all.Find(m => m.Id == 1));  // Cơm sườn
                comboPattern.ThemMon(all.Find(m => m.Id == 12)); // Canh chua
            }
            // 51: Combo BestSeller (Giảm 10%)
            else if (mon.Id == 29)
            {
                comboPattern = new ComboMonAn("Combo BestSeller", 0.1m);
                comboPattern.ThemMon(all.Find(m => m.Id == 4));  // Cơm sườn bì chả
                comboPattern.ThemMon(all.Find(m => m.Id == 12)); // Canh chua
                comboPattern.ThemMon(all.Find(m => m.Id == 22)); // Sting
            }
            // 52: Combo FullToping (Giảm 15% cho khách sộp)
            else if (mon.Id == 30)
            {
                comboPattern = new ComboMonAn("Combo FullToping", 0.15m);
                comboPattern.ThemMon(all.Find(m => m.Id == 4));  // Cơm sườn bì chả
                comboPattern.ThemMon(all.Find(m => m.Id == 19)); // Tốp mỡ
                comboPattern.ThemMon(all.Find(m => m.Id == 18)); // Trứng ốp la
                comboPattern.ThemMon(all.Find(m => m.Id == 12)); // Canh chua
                comboPattern.ThemMon(all.Find(m => m.Id == 22)); // Sting
            }

            if (comboPattern != null) return comboPattern.TinhGia();

            return mon.GiaBan;
        }
    }
}