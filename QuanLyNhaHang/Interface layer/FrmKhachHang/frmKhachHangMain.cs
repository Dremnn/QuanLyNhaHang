using QuanLyNhaHang.BL_layer;
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer.FrmKhachHang
{
    public partial class frmKhachHangMain : Form
    {
        private MonAnBLL monAnBLL = new MonAnBLL();
        private DanhMucBLL danhMucBLL = new DanhMucBLL();
        private DonHangBLL donHangBLL = new DonHangBLL();
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private BanBLL banBLL = new BanBLL();

        private Model.KhachHang currentKhachHang;
        private List<DanhMuc> danhMucList;

        public frmKhachHangMain()
        {
            InitializeComponent();
        }

        // ==========================================
        // LOAD FORM
        // ==========================================
        private void frmKhachHangMain_Load(object sender, EventArgs e)
        {

            // Lấy thông tin khách hàng từ session
            currentKhachHang = khachHangBLL.getByNguoiDungId(SessionHelper.CurrentUser.Id);

            // Hiển thị tên chào mừng
            lblChaoMung.Text = $"Xin chào, {currentKhachHang.HoTen}!";

            // Load dữ liệu các tab
            loadDanhMuc();
            loadMonAn(0);       // 0 = tất cả
            loadLichSuDonHang();
            loadThongTinCaNhan();
            loadDanhSachBanTrong();
        }

        // ==========================================
        // TAB THỰC ĐƠN
        // ==========================================
        private void loadDanhMuc()
        {
            danhMucList = danhMucBLL.getAll();
            pnlDanhMuc.Controls.Clear();

            // Nút "Tất cả"
            Button btnTatCa = createDanhMucButton("Tất cả", 0);
            pnlDanhMuc.Controls.Add(btnTatCa);

            // Nút từng danh mục
            foreach (DanhMuc dm in danhMucList)
            {
                Button btn = createDanhMucButton(dm.TenDanhMuc, dm.Id);
                pnlDanhMuc.Controls.Add(btn);
            }
        }

        private Button createDanhMucButton(string text, int danhMucId)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Tag = danhMucId;
            btn.Height = 35;
            btn.Width = 100;
            btn.Margin = new Padding(5);
            btn.Click += (s, e) => loadMonAn(danhMucId);
            return btn;
        }

        private void loadMonAn(int danhMucId)
        {
            lvMonAn.Items.Clear();

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(100, 100);
            imgList.ColorDepth = ColorDepth.Depth32Bit;

            List<MonAn> list = danhMucId == 0
                ? monAnBLL.getAll()
                : monAnBLL.getByDanhMuc(danhMucId);

            int index = 0;
            foreach (MonAn mon in list)
            {
                // Load ảnh
                string fullPath = Path.Combine(Application.StartupPath, mon.AnhUrl ?? "");
                Image img;

                if (!string.IsNullOrEmpty(mon.AnhUrl) && File.Exists(fullPath))
                    img = Image.FromFile(fullPath);
                else
                    img = Properties.Resources.default_image;

                imgList.Images.Add(img);

                // Tạo item
                ListViewItem item = new ListViewItem();
                item.Text = $"{mon.TenMon}\n{mon.GiaBan:N0}đ";
                item.ImageIndex = index;
                item.Tag = mon;

                if (!mon.ConHang)
                    item.ForeColor = Color.Gray;

                lvMonAn.Items.Add(item);
                index++;
            }

            lvMonAn.LargeImageList = imgList;
            lvMonAn.View = View.LargeIcon;
        }

        // ==========================================
        // TAB LỊCH SỬ ĐƠN HÀNG
        // ==========================================
        private void loadLichSuDonHang()
        {
            dgvDonHang.DataSource = null;
            dgvDonHang.Rows.Clear();
            dgvDonHang.Columns.Clear();

            dgvDonHang.Columns.Add("colId", "Mã đơn");
            dgvDonHang.Columns.Add("colBan", "Bàn");
            dgvDonHang.Columns.Add("colNgayTao", "Ngày tạo");
            dgvDonHang.Columns.Add("colTrangThai", "Trạng thái");

            List<DonHang> list = donHangBLL.getByKhachHangId(currentKhachHang.KhachHangId);

            foreach (DonHang dh in list)
            {
                dgvDonHang.Rows.Add(
                    dh.Id,
                    dh.SoBan,
                    dh.NgayTao.ToString("dd/MM/yyyy HH:mm"),
                    dh.TrangThai.ToString()
                );
            }

            // Chỉnh style
            dgvDonHang.ReadOnly = true;
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnHuyDatBan_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng muốn huỷ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy trạng thái đơn được chọn
            string trangThai = dgvDonHang.SelectedRows[0].Cells["colTrangThai"].Value.ToString();

            if (trangThai != "ChoDuyet")
            {
                MessageBox.Show("Chỉ có thể huỷ đơn hàng đang ở trạng thái Chờ Duyệt!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int donHangId = Convert.ToInt32(dgvDonHang.SelectedRows[0].Cells["colId"].Value);

            DialogResult confirm = MessageBox.Show(
                "Xác nhận huỷ đặt bàn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = donHangBLL.huyDatBan(donHangId);

            if (ketQua)
            {
                MessageBox.Show("Huỷ đặt bàn thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadLichSuDonHang();
                loadDanhSachBanTrong();
            }
            else
            {
                MessageBox.Show("Huỷ thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // TAB THÔNG TIN CÁ NHÂN
        // ==========================================
        private void loadThongTinCaNhan()
        {
            txtHoTen.Text = currentKhachHang.HoTen;
            txtSoDienThoai.Text = currentKhachHang.SoDienThoai;
            txtEmail.Text = currentKhachHang.Email;
            txtDiaChi.Text = currentKhachHang.DiaChi;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            currentKhachHang.HoTen = txtHoTen.Text.Trim();
            currentKhachHang.SoDienThoai = txtSoDienThoai.Text.Trim();
            currentKhachHang.Email = txtEmail.Text.Trim();
            currentKhachHang.DiaChi = txtDiaChi.Text.Trim();

            bool ketQua = khachHangBLL.update(currentKhachHang);

            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật tên chào mừng
                lblChaoMung.Text = $"Xin chào, {currentKhachHang.HoTen}!";
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // TAB ĐẶT BÀN
        // ==========================================
        private void loadDanhSachBanTrong()
        {
            lbDanhSachBan.Items.Clear();

            List<Ban> list = banBLL.getBanTrong();

            if (list.Count == 0)
            {
                lbDanhSachBan.Items.Add("Hiện không có bàn trống!");
                btnDatBan.Enabled = false;
                return;
            }

            btnDatBan.Enabled = true;
            foreach (Ban ban in list)
            {
                lbDanhSachBan.Items.Add($"Bàn {ban.SoBan} - {ban.SoCho} chỗ");
                // Lưu object Ban vào Tag để dùng sau
            }

            // Lưu list bàn vào Tag của ListBox
            lbDanhSachBan.Tag = list;
        }

        private void lbDanhSachBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDanhSachBan.SelectedIndex < 0) return;

            List<Ban> list = (List<Ban>)lbDanhSachBan.Tag;
            Ban banDuocChon = list[lbDanhSachBan.SelectedIndex];

            lblThongTinBan.Text = $"Bàn {banDuocChon.SoBan} - {banDuocChon.SoCho} chỗ ngồi";
        }

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            if (lbDanhSachBan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Ban> list = (List<Ban>)lbDanhSachBan.Tag;
            Ban banDuocChon = list[lbDanhSachBan.SelectedIndex];

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận đặt bàn {banDuocChon.SoBan}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = donHangBLL.datBan(banDuocChon.Id, currentKhachHang.KhachHangId);

            if (ketQua)
            {
                MessageBox.Show($"Đặt bàn {banDuocChon.SoBan} thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload lại danh sách bàn trống và lịch sử đơn
                loadDanhSachBanTrong();
                loadLichSuDonHang();
            }
            else
            {
                MessageBox.Show("Bàn vừa được đặt bởi người khác, vui lòng chọn bàn khác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                loadDanhSachBanTrong();
            }
        }


        // ==========================================
        // ĐĂNG XUẤT
        // ==========================================
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }

    }
}