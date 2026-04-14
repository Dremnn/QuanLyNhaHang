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

        public int insert(DanhMuc danhMuc)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"INSERT INTO DanhMuc (TenDanhMuc, ThuTu)
                       VALUES (@tenDanhMuc, @thuTu);
                       SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenDanhMuc", danhMuc.TenDanhMuc);
                cmd.Parameters.AddWithValue("@thuTu", danhMuc.ThuTu);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool update(DanhMuc danhMuc)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"UPDATE DanhMuc
                       SET TenDanhMuc = @tenDanhMuc,
                           ThuTu      = @thuTu
                       WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenDanhMuc", danhMuc.TenDanhMuc);
                cmd.Parameters.AddWithValue("@thuTu", danhMuc.ThuTu);
                cmd.Parameters.AddWithValue("@id", danhMuc.Id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool delete(int id)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = "DELETE FROM DanhMuc WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}