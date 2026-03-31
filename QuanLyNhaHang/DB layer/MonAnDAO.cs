using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class MonAnDAO
    {
        // Lấy tất cả món ăn
        public List<MonAn> getAll()
        {
            List<MonAn> list = new List<MonAn>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT m.Id, m.DanhMucId, m.TenMon, m.MoTa, 
                                      m.GiaBan, m.ConHang, m.AnhUrl, d.TenDanhMuc
                               FROM MonAn m
                               JOIN DanhMuc d ON d.Id = m.DanhMucId
                               ORDER BY d.ThuTu, m.Id, m.TenMon";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(mapToMonAn(reader));
            }

            return list;
        }

        // Lấy món ăn theo danh mục
        public List<MonAn> getByDanhMuc(int danhMucId)
        {
            List<MonAn> list = new List<MonAn>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT m.Id, m.DanhMucId, m.TenMon, m.MoTa,
                                      m.GiaBan, m.ConHang, m.AnhUrl, d.TenDanhMuc
                               FROM MonAn m
                               JOIN DanhMuc d ON d.Id = m.DanhMucId
                               WHERE m.DanhMucId = @danhMucId
                               ORDER BY m.TenMon";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@danhMucId", danhMucId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(mapToMonAn(reader));
            }

            return list;
        }

        private MonAn mapToMonAn(SqlDataReader reader)
        {
            return new MonAn(
                id: Convert.ToInt32(reader["Id"]),
                danhMucId: Convert.ToInt32(reader["DanhMucId"]),
                tenMon: reader["TenMon"].ToString(),
                moTa: reader["MoTa"].ToString(),
                giaBan: Convert.ToDecimal(reader["GiaBan"]),
                conHang: Convert.ToBoolean(reader["ConHang"]),
                anhUrl: reader["AnhUrl"].ToString()
            )
            {
                TenDanhMuc = reader["TenDanhMuc"].ToString()
            };
        }
    }
}