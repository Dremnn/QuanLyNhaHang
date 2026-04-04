using QuanLyNhaHang.BL_layer;
using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer.FrmNhanVien
{
    public partial class frmKhachVangLai : Form
    {
        public int? KhachHangId { get; private set; } = null;
        private KhachHangBLL khachHangBLL = new KhachHangBLL();

        public frmKhachVangLai() { InitializeComponent(); }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text.Trim()) ||
                string.IsNullOrEmpty(txtSDT.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên và SĐT!");
                return;
            }

            KhachHang khCu = khachHangBLL.getBySoDienThoai(txtSDT.Text.Trim());
            if (khCu != null)
            {
                var confirm = MessageBox.Show(
                    $"SĐT đã có trong hệ thống: {khCu.HoTen}\nDùng thông tin này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    KhachHangId = khCu.KhachHangId;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                return;
            }

            KhachHang kh = new KhachHang(
                hoTen: txtTen.Text.Trim(),
                soDienThoai: txtSDT.Text.Trim()
            );

            int newId = khachHangBLL.insertVangLai(kh);
            if (newId > 0)
            {
                KhachHangId = newId;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo khách hàng thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
