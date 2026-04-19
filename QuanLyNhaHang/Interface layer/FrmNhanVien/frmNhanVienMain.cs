using DBConnection = QuanLyNhaHang.DB_layer.DBConnection;
using QuanLyNhaHang.BL_layer;
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

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
            lblNhanVien.Text = $"Tên      : {SessionHelper.CurrentUser.TenDangNhap}";
            lblVaiTro.Text = $"Vai trò  : {SessionHelper.CurrentUser.VaiTro}";
            lblID.Text = $"ID       : {SessionHelper.CurrentUser.Id}";
            cboTrangThaiBan.Items.Clear();
            cboTrangThaiBan.Items.Add("Trong");
            cboTrangThaiBan.Items.Add("CoKhach");
            cboTrangThaiBan.Items.Add("DatTruoc");
            cboTrangThaiBan.Items.Add("Dong");
            if (cboTrangThaiBan.Items.Count > 0) cboTrangThaiBan.SelectedIndex = 0;
            if (cboPhuongThuc.Items.Count > 0) cboPhuongThuc.SelectedIndex = 0;

            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.Add("TienMat");
            cboPhuongThuc.Items.Add("ChuyenKhoan");
            cboPhuongThuc.Items.Add("QuetThe");
            cboPhuongThuc.Items.Add("ViDienTu");
            cboPhuongThuc.SelectedIndex = 0;

            LoadDynamicDanhMuc();

            LoadAvatar(
                SessionHelper.CurrentUser.VaiTro.ToString(), 
                SessionHelper.CurrentUser.HinhAnh
             );

            loadMonAn(0);
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
            if (trangThai == "Trống")
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
                case "ChoDuyet": return "Dang" +
                        "CheBien";
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
            frmHoaDon frmHD = new frmHoaDon(selectedDonHangId);
            frmHD.ShowDialog();
        }

        private void nudTienGiam_ValueChanged(object sender, EventArgs e)
        {
            if (selectedDonHangId == -1) return;

            decimal tongTien = chiTietDonBLL.tinhTongTien(selectedDonHangId);
            decimal tienThanhToan = tongTien - nudTienGiam.Value;
            lblTienThanhToan.Text = $"Tiền thanh toán: {tienThanhToan:N0}đ";
        }

        // ==========================================
        // TAB THỰC ĐƠN 
        // ==========================================

        private void LoadDynamicDanhMuc()
        {
            // 1. Xóa hết các control cũ trong panel để tránh trùng lặp khi load lại
            flpDanhMuc.Controls.Clear();

            // 2. Tạo nút "Tất cả" mặc định
            Button btnAll = new Button();
            btnAll.Text = "Tất cả";
            btnAll.Width = 120; // Bạn có thể chỉnh kích thước theo ý muốn
            btnAll.Height = 45;
            btnAll.Click += (s, ev) => loadMonAn(0); // Gọi hàm load toàn bộ món
            flpDanhMuc.Controls.Add(btnAll);

            // 3. Lấy danh sách danh mục từ BLL
            List<DanhMuc> listDM = danhMucBLL.getAll();

            foreach (DanhMuc dm in listDM)
            {
                // 4. Khởi tạo một nút mới cho mỗi danh mục
                Button btn = new Button();
                btn.Text = dm.TenDanhMuc;
                btn.Width = 120;
                btn.Height = 45;

                // Lưu ID vào Tag để dùng khi click (hoặc dùng trực tiếp trong lambda)
                btn.Tag = dm.Id;

                // 5. Gán sự kiện Click bằng Lambda Expression
                btn.Click += (s, ev) => {
                    // Khi click sẽ gọi hàm loadMonAn với ID của danh mục đó
                    loadMonAn(dm.Id);
                };

                // 6. Đưa nút vào FlowLayoutPanel
                flpDanhMuc.Controls.Add(btn);
            }
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
                // ==========================================
                // 1. GỌI HÀM TÍNH GIÁ TỪ COMPOSITE PATTERN
                // ==========================================
                decimal giaHienThi = monAnBLL.TinhGiaThucTe(mon);

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

                // ==========================================
                // 2. THAY VÌ mon.GiaBan, TA DÙNG giaHienThi
                // ==========================================
                item.Text = $"{mon.TenMon}\n{giaHienThi:N0}đ";
                item.ImageIndex = index;

                // Vẫn lưu nguyên object mon vào Tag để khi click lấy đúng ID truyền xuống giỏ hàng
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
        private void pBAVT_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, pBAVT.Width - 1, pBAVT.Height - 1);
                pBAVT.Region = new Region(gp);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(new Pen(Color.LightGray, 2), 0, 0, pBAVT.Width - 1, pBAVT.Height - 1);
            }
        }

        private void pBAVT_Click(object sender, EventArgs e)
        {
            if (ofdAVT.ShowDialog() == DialogResult.OK)
            {
                string userRole = SessionHelper.CurrentUser.VaiTro.ToString(); // "NhanVien"
                string userID = SessionHelper.CurrentUser.Id.ToString();
                string folderPath = Path.Combine(Application.StartupPath, "Avatars", userRole);
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                string extension = Path.GetExtension(ofdAVT.FileName);
                string fileName = userID + extension;
                string destPath = Path.Combine(folderPath, fileName);
                File.Copy(ofdAVT.FileName, destPath, true);
                using (FileStream fs = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                    pBAVT.Image = Image.FromStream(fs);
                SaveToDatabase(userID, userRole + "/" + fileName);
            }
        }

        private void SaveToDatabase(string userID, string relativePath)
        {
            try
            {
                string sql = "UPDATE NguoiDung SET HinhAnh = @hinh WHERE Id = @id";
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@hinh", relativePath);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userID));
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        SessionHelper.CurrentUser.HinhAnh = relativePath;
                        MessageBox.Show("Đã cập nhật ảnh đại diện!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Database: " + ex.Message); }
        }

        private void LoadAvatar(string userRole, string fileNameFromDb)
        {
            try
            {
                if (string.IsNullOrEmpty(fileNameFromDb)) { pBAVT.Image = Properties.Resources.default_user; return; }
                string fullPath = Path.Combine(Application.StartupPath, "Avatars", fileNameFromDb);
                if (!File.Exists(fullPath))
                    fullPath = Path.Combine(Application.StartupPath, "Avatars", userRole, fileNameFromDb);
                if (File.Exists(fullPath))
                    using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        pBAVT.Image = Image.FromStream(fs);
                else
                    pBAVT.Image = Properties.Resources.default_user;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. Lưu lại ID đơn hàng nhân viên đang xem (nếu có)
            int currentId = selectedDonHangId;

            // 2. Tạm thời ngắt sự kiện SelectionChanged để không bị giật/lag DataGridView chi tiết
            dgvDonHang.SelectionChanged -= dgvDonHang_SelectionChanged;

            // 3. Tải lại dữ liệu mới từ Database
            loadDonHangDangMo();

            // 4. Tìm và bôi đen lại đúng dòng đơn hàng lúc nãy
            if (currentId != -1)
            {
                bool found = false;
                foreach (DataGridViewRow row in dgvDonHang.Rows)
                {
                    if (Convert.ToInt32(row.Cells["colDHId"].Value) == currentId)
                    {
                        row.Selected = true;
                        selectedDonHangId = currentId;
                        loadChiTietDon(currentId); // Load lại danh sách món của đơn đó
                        found = true;
                        break;
                    }
                }

                // Nếu đơn hàng đã bị hoàn thành/hủy và biến mất khỏi danh sách
                if (!found)
                {
                    selectedDonHangId = -1;
                    dgvChiTiet.Rows.Clear();
                    lblTongTien.Text = "Tổng tiền: 0đ";
                }
            }

            // 5. Gắn lại sự kiện SelectionChanged
            dgvDonHang.SelectionChanged += dgvDonHang_SelectionChanged;
        }
    }
}