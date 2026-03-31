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
    }
}