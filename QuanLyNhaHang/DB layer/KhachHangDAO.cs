using System;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class KhachHangDAO
    {
        public int insert(KhachHang khachHang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"INSERT INTO KhachHang (NguoiDungId, HoTen, SoDienThoai)
                               VALUES (@nguoiDungId, @hoTen, @soDienThoai);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nguoiDungId", khachHang.NguoiDungId);
                cmd.Parameters.AddWithValue("@hoTen", khachHang.HoTen);
                cmd.Parameters.AddWithValue("@soDienThoai", khachHang.SoDienThoai);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public KhachHang getByNguoiDungId(int nguoiDungId)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT Id, NguoiDungId, HoTen, SoDienThoai, Email, DiaChi, NgayTao
                               FROM KhachHang
                               WHERE NguoiDungId = @nguoiDungId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nguoiDungId", nguoiDungId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    return mapToKhachHang(reader);

                return null;
            }
        }

        public bool update(KhachHang khachHang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"UPDATE KhachHang
                               SET HoTen        = @hoTen,
                                   SoDienThoai  = @soDienThoai,
                                   Email        = @email,
                                   DiaChi       = @diaChi
                               WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hoTen", khachHang.HoTen);
                cmd.Parameters.AddWithValue("@soDienThoai", khachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@email", (object)khachHang.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@diaChi", (object)khachHang.DiaChi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", khachHang.KhachHangId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private KhachHang mapToKhachHang(SqlDataReader reader)
        {
            return new KhachHang(
                hoTen: reader["HoTen"].ToString(),
                soDienThoai: reader["SoDienThoai"].ToString()
            )
            {
                KhachHangId = Convert.ToInt32(reader["Id"]),
                NguoiDungId = reader["NguoiDungId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NguoiDungId"]),
                Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                DiaChi = reader["DiaChi"] == DBNull.Value ? null : reader["DiaChi"].ToString(),
                NgayTaoKH = Convert.ToDateTime(reader["NgayTao"])
            };
        }

        public KhachHang getBySoDienThoai(string soDienThoai)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT Id, NguoiDungId, HoTen, SoDienThoai, Email, DiaChi, NgayTao
                       FROM KhachHang
                       WHERE SoDienThoai = @soDienThoai";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    return mapToKhachHang(reader);

                return null;
            }
        }
    }
}