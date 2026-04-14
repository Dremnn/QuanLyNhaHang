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

        public List<Ban> getAll()
        {
            return banDAO.getAll();
        }

        public bool updateTrangThai(int banId, string trangThai)
        {
            return banDAO.updateTrangThai(banId, trangThai);
        }

        public bool insert(Ban ban)
        {
            if (string.IsNullOrEmpty(ban.SoBan))
                return false;

            if (ban.SoCho <= 0)
                return false;

            return banDAO.insert(ban) > 0;
        }

        public bool update(Ban ban)
        {
            if (string.IsNullOrEmpty(ban.SoBan))
                return false;

            if (ban.SoCho <= 0)
                return false;

            return banDAO.update(ban);
        }

        public bool delete(int id)
        {
            return banDAO.delete(id);
        }
    }
}