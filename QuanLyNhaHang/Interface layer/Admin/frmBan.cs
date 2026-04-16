using QuanLyNhaHang.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer.Admin
{
    public partial class frmBan : Form
    {
        public Ban BanResult { get; private set; }
        private Ban _banEdit;

        public frmBan(Ban banEdit)
        {
            InitializeComponent();
            _banEdit = banEdit;
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            nudSoCho.Minimum = 1;
            nudSoCho.Maximum = 99;
            nudSoCho.Value = 4;

            if (_banEdit != null)
            {
                this.Text = "Sửa bàn";
                txtSoBan.Text = _banEdit.SoBan;
                nudSoCho.Value = _banEdit.SoCho;
            }
            else
            {
                this.Text = "Thêm bàn";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoBan.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập số bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BanResult = new Ban(
                id: _banEdit?.Id ?? 0,
                soBan: txtSoBan.Text.Trim(),
                soCho: (int)nudSoCho.Value,
                trangThai: TrangThaiBan.Trong
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void txtSoBan_Click(object sender, EventArgs e)
        {
            txtSoBan.PlaceholderText = "";
        }

        private void txtSoBan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoBan.Text))
            {
                txtSoBan.PlaceholderText = "Nhập tên bàn";
            }
        }

    }
}