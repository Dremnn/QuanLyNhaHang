using QuanLyNhaHang.Model;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer.Admin
{
    public partial class frmDanhMuc : Form
    {
        public DanhMuc DanhMucResult { get; private set; }
        private DanhMuc _danhMucEdit;

        public frmDanhMuc(DanhMuc danhMucEdit)
        {
            InitializeComponent();
            _danhMucEdit = danhMucEdit;
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            nudThuTu.Minimum = 0;
            nudThuTu.Maximum = 99;

            if (_danhMucEdit != null)
            {
                this.Text = "Sửa danh mục";
                txtTenDanhMuc.Text = _danhMucEdit.TenDanhMuc;
                nudThuTu.Value = _danhMucEdit.ThuTu;
            }
            else
            {
                this.Text = "Thêm danh mục";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDanhMuc.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DanhMucResult = new DanhMuc(
                id: _danhMucEdit?.Id ?? 0,
                tenDanhMuc: txtTenDanhMuc.Text.Trim(),
                thuTu: (int)nudThuTu.Value
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}