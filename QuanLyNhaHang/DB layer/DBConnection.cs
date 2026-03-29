using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DB_layer
{
    public class DBConnection
    {
        private static readonly string connectionString =
            "Server=TRONGTRUNG\\SQLEXPRESS;Database=QuanLyNhaHang;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
