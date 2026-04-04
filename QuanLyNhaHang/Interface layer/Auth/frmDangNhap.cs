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
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Model;

using QuanLyNhaHang.Interface_layer.Admin;
using QuanLyNhaHang.Interface_layer.FrmNhanVien;
using QuanLyNhaHang.Interface_layer.FrmKhachHang;

namespace QuanLyNhaHang.Interface_layer.Auth
{
    public partial class frmDangNhap : Form
    {
        private NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi BLL login
            NguoiDung nguoiDung = nguoiDungBLL.login(tenDangNhap, matKhau);

            if (nguoiDung == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lưu session
            SessionHelper.login(nguoiDung);

            // Mở form tương ứng theo vai trò
            this.Hide();
            openFormByVaiTro(nguoiDung.VaiTro);
        }

        private void openFormByVaiTro(VaiTro vaiTro)
        {
            Form form;

            switch (vaiTro)
            {
                case VaiTro.Admin:
                    form = new frmAdminMain();
                    break;
                case VaiTro.NhanVien:
                    form = new frmNhanVienMain();
                    break;
                default:
                    form = new frmKhachHangMain();
                    break;
            }

            form.FormClosed += (s, e) =>
            {
                SessionHelper.logout();
                this.Show();
            };

            form.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy frmDangKy = new frmDangKy();
            this.Hide();
            frmDangKy.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.PlaceholderText = "";
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.PlaceholderText = "";
        }
        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                txtTenDangNhap.PlaceholderText = "Nhập tên đăng nhập";
            }
        }
        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                txtMatKhau.PlaceholderText = "Nhập mật khẩu";
            }
        }

    }
}
