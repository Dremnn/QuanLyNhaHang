using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.Interface_layer.Admin
{
    public partial class frmMonAn : Form
    {
        public MonAn MonAnResult { get; private set; }
        private List<DanhMuc> _danhMucList;
        private MonAn _monAnEdit;

        public frmMonAn(List<DanhMuc> danhMucList, MonAn monAnEdit)
        {
            InitializeComponent();
            _danhMucList = danhMucList;
            _monAnEdit = monAnEdit;
        }

        private void frmMonAn_Load(object sender, EventArgs e)
        {
            // Load danh mục vào ComboBox
            cboDanhMuc.Items.Clear();
            _danhMucList.ForEach(dm => cboDanhMuc.Items.Add(dm.TenDanhMuc));
            cboDanhMuc.SelectedIndex = 0;

            chkConHang.Checked = true;

            // Nếu là sửa thì điền thông tin vào
            if (_monAnEdit != null)
            {
                this.Text = "Sửa món ăn";
                txtTenMon.Text = _monAnEdit.TenMon;
                txtGiaBan.Text = _monAnEdit.GiaBan.ToString();
                txtMoTa.Text = _monAnEdit.MoTa;
                txtAnhUrl.Text = _monAnEdit.AnhUrl;
                chkConHang.Checked = _monAnEdit.ConHang;

                // Chọn đúng danh mục
                int index = _danhMucList.FindIndex(dm => dm.Id == _monAnEdit.DanhMucId);
                if (index >= 0) cboDanhMuc.SelectedIndex = index;
            }
            else
            {
                this.Text = "Thêm món ăn";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMon.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên món!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DanhMuc danhMucChon = _danhMucList[cboDanhMuc.SelectedIndex];

            MonAnResult = new MonAn(
                id: _monAnEdit?.Id ?? 0,
                danhMucId: danhMucChon.Id,
                tenMon: txtTenMon.Text.Trim(),
                moTa: txtMoTa.Text.Trim(),
                giaBan: giaBan,
                conHang: chkConHang.Checked,
                anhUrl: txtAnhUrl.Text.Trim()
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtTenMon_Click(object sender, EventArgs e)
        {
            txtTenMon.PlaceholderText = "";
        }
        private void txtTenMon_Leave(object sender, EventArgs e)
        {
            txtTenMon.PlaceholderText = "Nhập tên món";
        }
        private void txtGiaBan_Click(object sender, EventArgs e)
        {
            txtGiaBan.PlaceholderText = "";
        }
        private void txtGiaBan_Leave(object sender, EventArgs e)
        {
            txtGiaBan.PlaceholderText = "Nhập giá bán";
        }
        private void txtMoTa_Click(object sender, EventArgs e)
        {
            txtMoTa.PlaceholderText = "";
        }
        private void txtMoTa_Leave(object sender, EventArgs e)
        {
            txtMoTa.PlaceholderText = "Nhập mô tả";
        }
    }
}