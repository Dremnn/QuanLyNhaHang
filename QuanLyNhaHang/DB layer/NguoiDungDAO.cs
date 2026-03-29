using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.DB_layer
{
    public class NguoiDungDAO
    {
        // Tìm người dùng theo tên đăng nhập
        public NguoiDung getByTenDangNhap(string tenDangNhap)
        {
            NguoiDung nguoiDung = null;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"SELECT Id, TenDangNhap, MatKhau, VaiTro, HoatDong, NgayTao
                               FROM NguoiDung
                               WHERE TenDangNhap = @tenDangNhap";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nguoiDung = mapToNguoiDung(reader);
                }
            }

            return nguoiDung;
        }

        // Kiểm tra tên đăng nhập đã tồn tại chưa
        public bool isTenDangNhapExists(string tenDangNhap)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = "SELECT COUNT(1) FROM NguoiDung WHERE TenDangNhap = @tenDangNhap";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Thêm người dùng mới (dùng khi đăng ký)
        public int insert(NguoiDung nguoiDung)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro, HoatDong)
                               VALUES (@tenDangNhap, @matKhau, @vaiTro, @hoatDong);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", nguoiDung.TenDangNhap);
                cmd.Parameters.AddWithValue("@matKhau", nguoiDung.MatKhau);
                cmd.Parameters.AddWithValue("@vaiTro", nguoiDung.VaiTro.ToString());
                cmd.Parameters.AddWithValue("@hoatDong", nguoiDung.HoatDong);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());  // trả về Id vừa tạo
            }
        }

        // Map dữ liệu từ reader sang object
        private NguoiDung mapToNguoiDung(SqlDataReader reader)
        {
            VaiTro vaiTro = (VaiTro)Enum.Parse(typeof(VaiTro), reader["VaiTro"].ToString());

            return new NguoiDung(
                id: Convert.ToInt32(reader["Id"]),
                tenDangNhap: reader["TenDangNhap"].ToString(),
                matKhau: reader["MatKhau"].ToString(),
                vaiTro: vaiTro,
                hoatDong: Convert.ToBoolean(reader["HoatDong"]),
                ngayTao: Convert.ToDateTime(reader["NgayTao"])
            );
        }
    }
}
