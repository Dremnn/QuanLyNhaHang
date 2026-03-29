using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Kết nối thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            string hashAdmin = PasswordHelper.hashPassword("admin123");
            string hashNhanVien = PasswordHelper.hashPassword("nhanvien123");
            MessageBox.Show($"Admin: {hashAdmin}\nNhanVien: {hashNhanVien}");
        }
    }
}
