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
    }
}