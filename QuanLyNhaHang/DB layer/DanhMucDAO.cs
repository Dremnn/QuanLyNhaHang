using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class DanhMucDAO
    {
        public List<DanhMuc> getAll()
        {
            List<DanhMuc> list = new List<DanhMuc>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT Id, TenDanhMuc, ThuTu
                               FROM DanhMuc
                               ORDER BY ThuTu";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DanhMuc(
                        id: Convert.ToInt32(reader["Id"]),
                        tenDanhMuc: reader["TenDanhMuc"].ToString(),
                        thuTu: Convert.ToInt32(reader["ThuTu"])
                    ));
                }
            }

            return list;
        }
    }
}