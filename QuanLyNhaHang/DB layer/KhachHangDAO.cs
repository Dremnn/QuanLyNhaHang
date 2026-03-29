using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
