using System;
using System.Collections.Generic;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class DanhMucBLL
    {
        private DanhMucDAO danhMucDAO = new DanhMucDAO();

        public List<DanhMuc> getAll()
        {
            return danhMucDAO.getAll();
        }

        public bool insert(DanhMuc danhMuc)
        {
            if (string.IsNullOrEmpty(danhMuc.TenDanhMuc))
                return false;

            return danhMucDAO.insert(danhMuc) > 0;
        }

        public bool update(DanhMuc danhMuc)
        {
            if (string.IsNullOrEmpty(danhMuc.TenDanhMuc))
                return false;

            return danhMucDAO.update(danhMuc);
        }

        public bool delete(int id)
        {
            return danhMucDAO.delete(id);
        }
    }
}