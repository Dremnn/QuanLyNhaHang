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
    public partial class frmTimKhachHang : Form
    {
        public int? KhachHangId { get; private set; } = null;
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private KhachHang _khachTimDuoc = null;

        public frmTimKhachHang() { InitializeComponent(); }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập SĐT!");
                return;
            }

            _khachTimDuoc = khachHangBLL.getBySoDienThoai(txtSDT.Text.Trim());
            if (_khachTimDuoc == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng!");
                btnXacNhan.Enabled = false;
                return;
            }

            lblKetQua.Text = $"Tìm thấy: {_khachTimDuoc.HoTen} - {_khachTimDuoc.SoDienThoai}";
            btnXacNhan.Enabled = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (_khachTimDuoc == null) return;
            KhachHangId = _khachTimDuoc.KhachHangId;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
