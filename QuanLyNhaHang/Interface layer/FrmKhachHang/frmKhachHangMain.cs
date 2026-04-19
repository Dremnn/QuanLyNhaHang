using QuanLyNhaHang.BL_layer;
using DBConnection = QuanLyNhaHang.DB_layer.DBConnection;
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            currentKhachHang = khachHangBLL.getByNguoiDungId(SessionHelper.CurrentUser.Id);
            lblChaoMung.Text = $"Xin chào, {currentKhachHang.HoTen}!";

            LoadDynamicDanhMuc();

            LoadAvatar(
                SessionHelper.CurrentUser.VaiTro.ToString(),
                currentKhachHang.HinhAnh
            );
            loadMonAn(0);
            loadLichSuDonHang();
            loadDanhSachBanTrong();
            loadThongTinCaNhan();
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

            lblThongTinBan.Text = $"Thông tin bàn:\n" +
                $"Bàn {banDuocChon.SoBan} - {banDuocChon.SoCho} chỗ ngồi";
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
        private void pBAVT_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, pBAVT.Width - 1, pBAVT.Height - 1);
                pBAVT.Region = new Region(gp);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.LightGray, 2);
                e.Graphics.DrawEllipse(pen, 0, 0, pBAVT.Width - 1, pBAVT.Height - 1);
            }
        }
        private void pBAVT_Click(object sender, EventArgs e)
        {
            if (ofdKhachHang.ShowDialog() == DialogResult.OK)
            {
                string userRole = SessionHelper.CurrentUser.VaiTro.ToString();
                string userID = currentKhachHang.KhachHangId.ToString();
                string folderPath = Path.Combine(Application.StartupPath, "Avatars", userRole);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                string extension = Path.GetExtension(ofdKhachHang.FileName);
                string fileName = userID + extension;
                string destPath = Path.Combine(folderPath, fileName);
                File.Copy(ofdKhachHang.FileName, destPath, true);
                using (FileStream fs = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                {
                    pBAVT.Image = Image.FromStream(fs);
                }
                string relativePath = userRole + "/" + fileName;
                SaveToDatabase(userID, relativePath);
            }
        }
        private void SaveToDatabase(string userID, string relativePath)
        {
            try
            {
                string sql = $"UPDATE KhachHang SET HinhAnh = @hinh WHERE Id = @id";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@hinh", relativePath);
                    cmd.Parameters.AddWithValue("@id", userID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        currentKhachHang.HinhAnh = relativePath;
                        MessageBox.Show("Đã cập nhật ảnh đại diện!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: " + ex.Message);
            }
        }
        private void LoadAvatar(string userRole, string fileNameFromDb)
        {
            try
            {
                if (string.IsNullOrEmpty(fileNameFromDb))
                {
                    pBAVT.Image = Properties.Resources.default_user;
                    return;
                }
                string fullPath = Path.Combine(Application.StartupPath, "Avatars", fileNameFromDb);
                if (!File.Exists(fullPath))
                    fullPath = Path.Combine(Application.StartupPath, "Avatars", userRole, fileNameFromDb);

                if (File.Exists(fullPath))
                {
                    using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        pBAVT.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    pBAVT.Image = Properties.Resources.default_user;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
            }
        }


    }
}