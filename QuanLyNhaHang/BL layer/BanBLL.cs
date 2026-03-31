using System.Collections.Generic;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.BL_layer
{
    public class BanBLL
    {
        private BanDAO banDAO = new BanDAO();

        public List<Ban> getBanTrong()
        {
            return banDAO.getBanTrong();
        }

        public bool updateTrangThai(int banId, string trangThai)
        {
            return banDAO.updateTrangThai(banId, trangThai);
        }
    }
}