using System;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class ThanhToanDAO
    {
        public int insert(ThanhToan thanhToan)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"INSERT INTO ThanhToan 
                                    (DonHangId, TongTien, TienGiam, TienThanhToan, 
                                     PhuongThuc, TrangThai, GhiChu)
                               VALUES 
                                    (@donHangId, @tongTien, @tienGiam, @tienThanhToan,
                                     @phuongThuc, @trangThai, @ghiChu);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@donHangId", thanhToan.DonHangId);
                cmd.Parameters.AddWithValue("@tongTien", thanhToan.TongTien);
                cmd.Parameters.AddWithValue("@tienGiam", thanhToan.TienGiam);
                cmd.Parameters.AddWithValue("@tienThanhToan", thanhToan.TienThanhToan);
                cmd.Parameters.AddWithValue("@phuongThuc", thanhToan.PhuongThuc.ToString());
                cmd.Parameters.AddWithValue("@trangThai", thanhToan.TrangThai.ToString());
                cmd.Parameters.AddWithValue("@ghiChu", (object)thanhToan.GhiChu ?? DBNull.Value);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public ThanhToan getByDonHangId(int donHangId)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT Id, DonHangId, TongTien, TienGiam, 
                                      TienThanhToan, PhuongThuc, TrangThai, 
                                      GhiChu, NgayThanhToan
                               FROM ThanhToan
                               WHERE DonHangId = @donHangId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@donHangId", donHangId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    return mapToThanhToan(reader);

                return null;
            }
        }

        private ThanhToan mapToThanhToan(SqlDataReader reader)
        {
            return new ThanhToan(
                donHangId: Convert.ToInt32(reader["DonHangId"]),
                tongTien: Convert.ToDecimal(reader["TongTien"]),
                tienGiam: Convert.ToDecimal(reader["TienGiam"]),
                phuongThuc: (PhuongThucThanhToan)Enum.Parse(typeof(PhuongThucThanhToan), reader["PhuongThuc"].ToString())
            )
            {
                Id = Convert.ToInt32(reader["Id"]),
                TrangThai = (TrangThaiThanhToan)Enum.Parse(typeof(TrangThaiThanhToan), reader["TrangThai"].ToString()),
                GhiChu = reader["GhiChu"] == DBNull.Value ? null : reader["GhiChu"].ToString(),
                NgayThanhToan = Convert.ToDateTime(reader["NgayThanhToan"])
            };
        }
    }
}