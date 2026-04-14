using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class ChiTietDonDAO
    {
        // Lấy chi tiết theo đơn hàng
        public List<ChiTietDon> getByDonHangId(int donHangId)
        {
            List<ChiTietDon> list = new List<ChiTietDon>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT ct.Id, ct.DonHangId, ct.MonAnId, 
                                      ct.SoLuong, ct.DonGia, ct.GhiChu,
                                      m.TenMon
                               FROM ChiTietDon ct
                               JOIN MonAn m ON m.Id = ct.MonAnId
                               WHERE ct.DonHangId = @donHangId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@donHangId", donHangId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(mapToChiTietDon(reader));
            }

            return list;
        }

        // Thêm món vào đơn
        public int insert(ChiTietDon chiTiet)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"INSERT INTO ChiTietDon (DonHangId, MonAnId, SoLuong, DonGia, GhiChu)
                               VALUES (@donHangId, @monAnId, @soLuong, @donGia, @ghiChu);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@donHangId", chiTiet.DonHangId);
                cmd.Parameters.AddWithValue("@monAnId", chiTiet.MonAnId);
                cmd.Parameters.AddWithValue("@soLuong", chiTiet.SoLuong);
                cmd.Parameters.AddWithValue("@donGia", chiTiet.DonGia);
                cmd.Parameters.AddWithValue("@ghiChu", (object)chiTiet.GhiChu ?? DBNull.Value);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Xoá món khỏi đơn
        public bool delete(int chiTietId)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = "DELETE FROM ChiTietDon WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", chiTietId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật số lượng món
        public bool updateSoLuong(int chiTietId, int soLuong)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"UPDATE ChiTietDon SET SoLuong = @soLuong
                               WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@soLuong", soLuong);
                cmd.Parameters.AddWithValue("@id", chiTietId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private ChiTietDon mapToChiTietDon(SqlDataReader reader)
        {
            return new ChiTietDon(
                donHangId: Convert.ToInt32(reader["DonHangId"]),
                monAnId: Convert.ToInt32(reader["MonAnId"]),
                soLuong: Convert.ToInt32(reader["SoLuong"]),
                donGia: Convert.ToDecimal(reader["DonGia"]),
                ghiChu: reader["GhiChu"] == DBNull.Value ? null : reader["GhiChu"].ToString()
            )
            {
                Id = Convert.ToInt32(reader["Id"]),
                TenMon = reader["TenMon"].ToString()
            };
        }

        public List<MonAnBanChay> getMonBanChay(DateTime tuNgay, DateTime denNgay)
        {
            List<MonAnBanChay> list = new List<MonAnBanChay>();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT m.Id AS MonAnId, m.TenMon,
                              SUM(ct.SoLuong)              AS TongSoLuong,
                              SUM(ct.SoLuong * ct.DonGia)  AS TongDoanhThu
                       FROM ChiTietDon ct
                       JOIN MonAn m ON m.Id = ct.MonAnId
                       JOIN DonHang dh ON dh.Id = ct.DonHangId
                       WHERE dh.TrangThai = 'DaThanhToan'
                       AND CAST(dh.NgayTao AS DATE)
                           BETWEEN @tuNgay AND @denNgay
                       GROUP BY m.Id, m.TenMon
                       ORDER BY TongSoLuong DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay.Date);
                cmd.Parameters.AddWithValue("@denNgay", denNgay.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new MonAnBanChay
                    {
                        MonAnId = Convert.ToInt32(reader["MonAnId"]),
                        TenMon = reader["TenMon"].ToString(),
                        TongSoLuong = Convert.ToInt32(reader["TongSoLuong"]),
                        TongDoanhThu = Convert.ToDecimal(reader["TongDoanhThu"])
                    });
                }
            }

            return list;
        }
    }
}