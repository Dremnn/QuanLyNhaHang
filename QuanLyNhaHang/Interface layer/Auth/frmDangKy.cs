using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyNhaHang.BL_layer;

namespace QuanLyNhaHang.Interface_layer.Auth
{
    public partial class frmDangKy : Form
    {
        private NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();

        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string xacNhanMatKhau = txtXacNhanMatKhau.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau)
                || string.IsNullOrEmpty(xacNhanMatKhau) || string.IsNullOrEmpty(hoTen)
                || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (tenDangNhap.Length < 6)
            {
                MessageBox.Show("Tên đăng nhập phải từ 6 ký tự trở lên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhau.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải từ 6 ký tự trở lên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ketQua = nguoiDungBLL.dangKy(tenDangNhap, matKhau, hoTen, soDienThoai);

            if (!ketQua)
            {
                MessageBox.Show("Tên đăng nhập hoặc SĐT đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHoTen_Click(object sender, EventArgs e)
        {
            txtHoTen.PlaceholderText = "";
        }

        private void txtSoDienThoai_Click(object sender, EventArgs e)
        {
            txtSoDienThoai.PlaceholderText = "";
        }

        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.PlaceholderText = "";
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.PlaceholderText = "";
        }

        private void txtXacNhanMatKhau_Click(object sender, EventArgs e)
        {
            txtXacNhanMatKhau.PlaceholderText = "";
        }

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtHoTen.Text))
                txtHoTen.PlaceholderText = "Họ tên";
        }

        private void txtSoDienThoai_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoDienThoai.Text))
                txtSoDienThoai.PlaceholderText = "Số điện thoại";
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
                txtTenDangNhap.PlaceholderText = "Tên đăng nhập";
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhau.Text))
                txtMatKhau.PlaceholderText = "Mật khẩu";
        }

        private void txtXacNhanMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXacNhanMatKhau.Text))
                txtXacNhanMatKhau.PlaceholderText = "Xác nhận mật khẩu";
        }
    }
}
