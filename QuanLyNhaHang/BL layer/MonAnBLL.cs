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
    }
}