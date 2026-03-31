using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class DonHangDAO
    {
        public List<DonHang> getByKhachHangId(int khachHangId)
        {
            List<DonHang> list = new List<DonHang>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT dh.Id, dh.BanId, dh.KhachHangId, dh.NguoiDungId,
                                      dh.TrangThai, dh.GhiChu, dh.NgayTao, dh.NgayDong,
                                      b.SoBan
                               FROM DonHang dh
                               JOIN Ban b ON b.Id = dh.BanId
                               WHERE dh.KhachHangId = @khachHangId
                               ORDER BY dh.NgayTao DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@khachHangId", khachHangId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(mapToDonHang(reader));
            }

            return list;
        }

        private DonHang mapToDonHang(SqlDataReader reader)
        {
            return new DonHang(
                banId: Convert.ToInt32(reader["BanId"]),
                khachHangId: Convert.ToInt32(reader["KhachHangId"]),
                nguoiDungId: reader["NguoiDungId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NguoiDungId"]),
                ghiChu: reader["GhiChu"].ToString()
            )
            {
                Id = Convert.ToInt32(reader["Id"]),
                TrangThai = (TrangThaiDonHang)Enum.Parse(typeof(TrangThaiDonHang), reader["TrangThai"].ToString()),
                NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                NgayDong = reader["NgayDong"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["NgayDong"]),
                SoBan = reader["SoBan"].ToString()
            };
        }

        public int insert(DonHang donHang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"INSERT INTO DonHang (BanId, KhachHangId, NguoiDungId, TrangThai, GhiChu)
                       VALUES (@banId, @khachHangId, @nguoiDungId, @trangThai, @ghiChu);
                       SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@banId", donHang.BanId);
                cmd.Parameters.AddWithValue("@khachHangId", (object)donHang.KhachHangId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@nguoiDungId", (object)donHang.NguoiDungId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@trangThai", donHang.TrangThai.ToString());
                cmd.Parameters.AddWithValue("@ghiChu", (object)donHang.GhiChu ?? DBNull.Value);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}