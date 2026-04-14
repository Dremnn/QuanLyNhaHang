using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhaHang.BL_layer;
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.Interface_layer.FrmNhanVien
{
    public partial class frmNhanVienMain : Form
    {
        private BanBLL banBLL = new BanBLL();
        private DonHangBLL donHangBLL = new DonHangBLL();
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private ChiTietDonBLL chiTietDonBLL = new ChiTietDonBLL();
        private ThanhToanBLL thanhToanBLL = new ThanhToanBLL();
        private MonAnBLL monAnBLL = new MonAnBLL();
        private DanhMucBLL danhMucBLL = new DanhMucBLL();

        private int selectedDonHangId = -1;

        public frmNhanVienMain()
        {
            InitializeComponent();
        }

        // ==========================================
        // LOAD FORM
        // ==========================================
        private void frmNhanVienMain_Load(object sender, EventArgs e)
        {
            lblNhanVien.Text = $"Nhân viên: {SessionHelper.CurrentUser.TenDangNhap}";

            cboTrangThaiBan.Items.Clear();
            cboTrangThaiBan.Items.Add("Trong");
            cboTrangThaiBan.Items.Add("CóKhách");
            cboTrangThaiBan.Items.Add("DatTruoc");
            cboTrangThaiBan.Items.Add("Dong");
            cboTrangThaiBan.SelectedIndex = 0;

            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.Add("TienMat");
            cboPhuongThuc.Items.Add("ChuyenKhoan");
            cboPhuongThuc.Items.Add("QuetThe");
            cboPhuongThuc.Items.Add("ViDienTu");
            cboPhuongThuc.SelectedIndex = 0;

            // Gán sự kiện cho button danh mục
            btnTatCa.Click += (s, ev) => loadMonAnNV(0);
            btnMonCom.Click += (s, ev) => loadMonAnNV(1);
            btnMonCanh.Click += (s, ev) => loadMonAnNV(2);
            btnMonThem.Click += (s, ev) => loadMonAnNV(3);
            btnGiaiKhat.Click += (s, ev) => loadMonAnNV(4);

            loadMonAnNV(0);
            loadDanhSachBan();
            loadDonHangDangMo();
        }

        // ==========================================
        // TAB QUẢN LÝ BÀN
        // ==========================================
        private void loadDanhSachBan()
        {
            dgvBan.DataSource = null;
            dgvBan.Rows.Clear();
            dgvBan.Columns.Clear();

            dgvBan.Columns.Add("colBanId", "ID");
            dgvBan.Columns.Add("colSoBan", "Số Bàn");
            dgvBan.Columns.Add("colSoCho", "Số Chỗ");
            dgvBan.Columns.Add("colTrangThai", "Trạng Thái");

            List<Ban> list = banBLL.getAll();
            foreach (Ban ban in list)
            {
                dgvBan.Rows.Add(ban.Id, ban.SoBan, ban.SoCho, ban.TrangThai.ToString());
            }

            dgvBan.ReadOnly = true;
            dgvBan.AllowUserToAddRows = false;
            dgvBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvBan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBan.SelectedRows.Count == 0) return;
            string trangThai = dgvBan.SelectedRows[0].Cells["colTrangThai"].Value.ToString();
            cboTrangThaiBan.SelectedItem = trangThai;
        }

        private void btnCapNhatBan_Click(object sender, EventArgs e)
        {
            if (dgvBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int banId = Convert.ToInt32(dgvBan.SelectedRows[0].Cells["colBanId"].Value);
            string trangThai = cboTrangThaiBan.SelectedItem.ToString();

            bool ketQua = banBLL.updateTrangThai(banId, trangThai);
            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSachBan();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyDatBan_Click(object sender, EventArgs e)
        {
            if (dgvBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trangThai = dgvBan.SelectedRows[0].Cells["colTrangThai"].Value.ToString();
            if (trangThai == "Trong")
            {
                MessageBox.Show("Bàn này chưa có đặt!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int banId = Convert.ToInt32(dgvBan.SelectedRows[0].Cells["colBanId"].Value);

            List<DonHang> danhSach = donHangBLL.getAllDangMo();
            DonHang donHang = danhSach.Find(dh =>
                dh.BanId == banId && dh.TrangThai == TrangThaiDonHang.ChoDuyet);

            if (donHang == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng để huỷ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận huỷ đặt bàn {dgvBan.SelectedRows[0].Cells["colSoBan"].Value}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = donHangBLL.huyDatBan(donHang.Id);
            if (ketQua)
            {
                MessageBox.Show("Huỷ đặt bàn thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSachBan();
                loadDonHangDangMo();
            }
            else
            {
                MessageBox.Show("Huỷ thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // TAB ĐƠN HÀNG
        // ==========================================
        private void loadDonHangDangMo()
        {
            dgvDonHang.DataSource = null;
            dgvDonHang.Rows.Clear();
            dgvDonHang.Columns.Clear();

            dgvDonHang.Columns.Add("colDHId", "Mã đơn");
            dgvDonHang.Columns.Add("colDHBan", "Bàn");
            dgvDonHang.Columns.Add("colDHKhach", "Khách hàng");
            dgvDonHang.Columns.Add("colDHTrangThai", "Trạng thái");
            dgvDonHang.Columns.Add("colDHNgayTao", "Ngày tạo");

            List<DonHang> list = donHangBLL.getAllDangMo();
            foreach (DonHang dh in list)
            {
                dgvDonHang.Rows.Add(
                    dh.Id,
                    dh.SoBan,
                    dh.TenKhachHang,
                    dh.TrangThai.ToString(),
                    dh.NgayTao.ToString("dd/MM/yyyy HH:mm")
                );
            }

            dgvDonHang.ReadOnly = true;
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvChiTiet.Rows.Clear();
            dgvChiTiet.Columns.Clear();
            selectedDonHangId = -1;
        }

        private void dgvDonHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDonHang.SelectedRows.Count == 0) return;

            selectedDonHangId = Convert.ToInt32(dgvDonHang.SelectedRows[0].Cells["colDHId"].Value);

            lblMaDon.Text = $"Mã đơn: #{selectedDonHangId}";

            decimal tongTien = chiTietDonBLL.tinhTongTien(selectedDonHangId);
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0}đ";
            lblTienThanhToan.Text = $"Tiền thanh toán: {tongTien:N0}đ";
            nudTienGiam.Value = 0;

            loadChiTietDon(selectedDonHangId);
        }

        private void loadChiTietDon(int donHangId)
        {
            dgvChiTiet.Rows.Clear();
            dgvChiTiet.Columns.Clear();

            dgvChiTiet.Columns.Add("colCTId", "ID");
            dgvChiTiet.Columns.Add("colCTTenMon", "Tên món");
            dgvChiTiet.Columns.Add("colCTSoLuong", "Số lượng");
            dgvChiTiet.Columns.Add("colCTDonGia", "Đơn giá");
            dgvChiTiet.Columns.Add("colCTThanhTien", "Thành tiền");

            List<ChiTietDon> list = chiTietDonBLL.getByDonHangId(donHangId);
            decimal tongTien = 0;

            foreach (ChiTietDon ct in list)
            {
                dgvChiTiet.Rows.Add(
                    ct.Id,
                    ct.TenMon,
                    ct.SoLuong,
                    ct.DonGia.ToString("N0"),
                    ct.ThanhTien.ToString("N0")
                );
                tongTien += ct.ThanhTien;
            }

            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            lblTongTien.Text = $"Tổng tiền: {tongTien:N0}đ";
        }

        // ── THAY THẾ: xoá timKhachHangTheoSDT, taoKhachVangLai, chonBan cũ ──
        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            List<Ban> danhSachTrong = banBLL.getBanTrong();
            if (danhSachTrong.Count == 0)
            {
                MessageBox.Show("Không có bàn trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? khachHangId = null;

            DialogResult coTaiKhoan = MessageBox.Show(
                "Khách có tài khoản không?", "Tạo đơn hàng",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (coTaiKhoan == DialogResult.Yes)
            {
                // Mở form tìm khách — bạn tự thiết kế
                frmTimKhachHang frmTim = new frmTimKhachHang();
                if (frmTim.ShowDialog() != DialogResult.OK) return;
                khachHangId = frmTim.KhachHangId;
            }
            else
            {
                // Mở form khách vãng lai — bạn tự thiết kế
                frmKhachVangLai frmVangLai = new frmKhachVangLai();
                if (frmVangLai.ShowDialog() != DialogResult.OK) return; // đóng = dừng hẳn
                khachHangId = frmVangLai.KhachHangId;
            }

            // Mở form chọn bàn — bạn tự thiết kế
            frmChonBan frmBan = new frmChonBan(danhSachTrong);
            if (frmBan.ShowDialog() != DialogResult.OK) return;
            int banId = frmBan.BanIdDuocChon;

            bool ketQua = donHangBLL.datBan(banId, khachHangId);
            if (ketQua)
            {
                MessageBox.Show("Tạo đơn hàng thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDonHangDangMo();
                loadDanhSachBan();
            }
            else
            {
                MessageBox.Show("Tạo đơn hàng thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── THAY THẾ: xoá phần tự gen form chọn món cũ ──
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (selectedDonHangId == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmChonMon frm = new frmChonMon(monAnBLL.getAll());
            if (frm.ShowDialog() != DialogResult.OK) return;

            bool ketQua = chiTietDonBLL.themMon(
                selectedDonHangId, frm.MonAnId, frm.SoLuong, null);

            if (ketQua)
            {
                MessageBox.Show("Thêm món thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadChiTietDon(selectedDonHangId);
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món muốn xoá!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int chiTietId = Convert.ToInt32(dgvChiTiet.SelectedRows[0].Cells["colCTId"].Value);

            DialogResult confirm = MessageBox.Show(
                "Xác nhận xoá món này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = chiTietDonBLL.xoaMon(chiTietId);
            if (ketQua)
            {
                MessageBox.Show("Xoá món thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadChiTietDon(selectedDonHangId);
            }
            else
            {
                MessageBox.Show("Xoá món thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatTrangThai_Click(object sender, EventArgs e)
        {
            if (selectedDonHangId == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trangThaiHienTai = dgvDonHang.SelectedRows[0]
                .Cells["colDHTrangThai"].Value.ToString();

            string trangThaiMoi = nextTrangThai(trangThaiHienTai);
            if (trangThaiMoi == null)
            {
                MessageBox.Show("Đơn hàng đã ở trạng thái cuối!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Chuyển trạng thái sang: {trangThaiMoi}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = donHangBLL.updateTrangThai(selectedDonHangId, trangThaiMoi);
            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDonHangDangMo();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string nextTrangThai(string current)
        {
            switch (current)
            {
                case "ChoDuyet": return "DangCheBien";
                case "DangCheBien": return "DaPhucVu";
                case "DaPhucVu": return "YeuCauTinh";
                default: return null;
            }
        }

        // ==========================================
        // TAB THANH TOÁN
        // ==========================================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedDonHangId == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tienGiam = nudTienGiam.Value;
            string phuongThuc = cboPhuongThuc.SelectedItem.ToString();
            string ghiChu = txtGhiChu.Text.Trim();

            PhuongThucThanhToan pt = (PhuongThucThanhToan)Enum.Parse(
                typeof(PhuongThucThanhToan), phuongThuc);

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận thanh toán đơn hàng #{selectedDonHangId}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = thanhToanBLL.thanhToan(selectedDonHangId, tienGiam, pt, ghiChu);
            if (ketQua)
            {
                xuatHoaDon(selectedDonHangId, tienGiam, pt);

                loadDonHangDangMo();
                loadDanhSachBan();
                nudTienGiam.Value = 0;
                txtGhiChu.Text = "";
                lblMaDon.Text = "Mã đơn: --";
                lblTongTien.Text = "Tổng tiền: 0đ";
                lblTienThanhToan.Text = "Tiền thanh toán: 0đ";
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xuatHoaDon(int donHangId, decimal tienGiam, PhuongThucThanhToan phuongThuc)
        {
            List<ChiTietDon> list = chiTietDonBLL.getByDonHangId(donHangId);
            decimal tongTien = chiTietDonBLL.tinhTongTien(donHangId);
            decimal tienThanhToan = tongTien - tienGiam;

            string hoaDon = "========== HOÁ ĐƠN ==========\n";
            hoaDon += $"Mã đơn   : #{donHangId}\n";
            hoaDon += $"Ngày     : {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            hoaDon += "------------------------------\n";

            foreach (ChiTietDon ct in list)
                hoaDon += $"{ct.TenMon,-20} {ct.SoLuong} x {ct.DonGia:N0}đ = {ct.ThanhTien:N0}đ\n";

            hoaDon += "------------------------------\n";
            hoaDon += $"Tổng tiền    : {tongTien:N0}đ\n";
            hoaDon += $"Giảm giá     : {tienGiam:N0}đ\n";
            hoaDon += $"Thanh toán   : {tienThanhToan:N0}đ\n";
            hoaDon += $"Phương thức  : {phuongThuc}\n";
            hoaDon += "==============================\n";
            hoaDon += "     Cảm ơn quý khách!\n";

            MessageBox.Show(hoaDon, "Hoá đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nudTienGiam_ValueChanged(object sender, EventArgs e)
        {
            if (selectedDonHangId == -1) return;

            decimal tongTien = chiTietDonBLL.tinhTongTien(selectedDonHangId);
            decimal tienThanhToan = tongTien - nudTienGiam.Value;
            lblTienThanhToan.Text = $"Tiền thanh toán: {tienThanhToan:N0}đ";
        }

        // ==========================================
        // TAB THỰC ĐƠN — giữ nguyên vì đây là dynamic UI hợp lệ
        // ==========================================

        private void loadMonAnNV(int danhMucId)
        {
            lvMonAnNV.Items.Clear();

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(100, 100);
            imgList.ColorDepth = ColorDepth.Depth32Bit;

            List<MonAn> list = danhMucId == 0
                ? monAnBLL.getAll()
                : monAnBLL.getByDanhMuc(danhMucId);

            int index = 0;
            foreach (MonAn mon in list)
            {
                string fullPath = System.IO.Path.Combine(
                    Application.StartupPath, mon.AnhUrl ?? "");

                Image img = System.IO.File.Exists(fullPath)
                    ? Image.FromFile(fullPath)
                    : Properties.Resources.default_image;

                imgList.Images.Add(img);

                ListViewItem item = new ListViewItem();
                item.Text = $"{mon.TenMon}\n{mon.GiaBan:N0}đ";
                item.ImageIndex = index;
                item.Tag = mon;

                if (!mon.ConHang)
                    item.ForeColor = Color.Gray;

                lvMonAnNV.Items.Add(item);
                index++;
            }

            lvMonAnNV.LargeImageList = imgList;
            lvMonAnNV.View = View.LargeIcon;
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

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void lblNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void lblMaDon_Click(object sender, EventArgs e)
        {

        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTienThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabDonHang_Click(object sender, EventArgs e)
        {

        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabBan_Click(object sender, EventArgs e)
        {

        }

        private void cboTrangThaiBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lvMonAnNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlDanhMucNV_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {

        }

        private void btnMonCom_Click(object sender, EventArgs e)
        {

        }

        private void btnMonCanh_Click(object sender, EventArgs e)
        {

        }

        private void btnMonThem_Click(object sender, EventArgs e)
        {

        }

        private void btnGiaiKhat_Click(object sender, EventArgs e)
        {

        }

        private void tabThucDon_Click(object sender, EventArgs e)
        {

        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}