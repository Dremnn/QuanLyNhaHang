using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class BanDAO
    {
        // Lấy tất cả bàn đang trống
        public List<Ban> getBanTrong()
        {
            List<Ban> list = new List<Ban>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT Id, SoBan, SoCho, TrangThai
                               FROM Ban
                               WHERE TrangThai = 'Trong'
                               ORDER BY SoBan";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(mapToBan(reader));
            }

            return list;
        }

        public List<Ban> getAll()
        {
            List<Ban> list = new List<Ban>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT Id, SoBan, SoCho, TrangThai
                       FROM Ban
                       ORDER BY SoBan";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(mapToBan(reader));
            }

            return list;
        }

        // Cập nhật trạng thái bàn
        public bool updateTrangThai(int banId, string trangThai)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"UPDATE Ban SET TrangThai = @trangThai WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);
                cmd.Parameters.AddWithValue("@id", banId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private Ban mapToBan(SqlDataReader reader)
        {
            string rawTrangThai = reader["TrangThai"].ToString();
            string normalizedTrangThai = rawTrangThai
                .Replace("CóKhách", "CoKhach")
                .Replace("Có Khách", "CoKhach")
                .Replace("Đông", "Dong");

            TrangThaiBan trangThai = (TrangThaiBan)Enum.Parse(
                typeof(TrangThaiBan), normalizedTrangThai);

            return new Ban(
                id: Convert.ToInt32(reader["Id"]),
                soBan: reader["SoBan"].ToString(),
                soCho: Convert.ToInt32(reader["SoCho"]),
                trangThai: trangThai
            );
        }

        public int insert(Ban ban)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"INSERT INTO Ban (SoBan, SoCho, TrangThai)
                       VALUES (@soBan, @soCho, @trangThai);
                       SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@soBan", ban.SoBan);
                cmd.Parameters.AddWithValue("@soCho", ban.SoCho);
                cmd.Parameters.AddWithValue("@trangThai", ban.TrangThai.ToString());

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool update(Ban ban)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"UPDATE Ban
                       SET SoBan     = @soBan,
                           SoCho     = @soCho
                       WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@soBan", ban.SoBan);
                cmd.Parameters.AddWithValue("@soCho", ban.SoCho);
                cmd.Parameters.AddWithValue("@id", ban.Id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool delete(int id)
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string sql = "DELETE FROM Ban WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}