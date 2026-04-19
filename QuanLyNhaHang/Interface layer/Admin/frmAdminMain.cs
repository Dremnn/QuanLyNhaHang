using QuanLyNhaHang.BL_layer;
using DBConnection = QuanLyNhaHang.DB_layer.DBConnection;
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer.Admin
{
    public partial class frmAdminMain : Form
    {
        private NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
        private MonAnBLL monAnBLL = new MonAnBLL();
        private DanhMucBLL danhMucBLL = new DanhMucBLL();
        private BanBLL banBLL = new BanBLL();
        private BaoCaoBLL baoCaoBLL = new BaoCaoBLL();

        public frmAdminMain()
        {
            InitializeComponent();
        }

        // ==========================================
        // LOAD FORM
        // ==========================================
        private void frmAdminMain_Load(object sender, EventArgs e)
        {
            lblAdmin.Text   = $"Tên    : {SessionHelper.CurrentUser.TenDangNhap}";
            lblVaiTro.Text  = $"Vai trò: {SessionHelper.CurrentUser.VaiTro}";
            lblID.Text      = $"ID     : {SessionHelper.CurrentUser.Id}";

            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("NhanVien");
            cboVaiTro.Items.Add("KhachHang");
            if (cboVaiTro.Items.Count > 0)  cboVaiTro.SelectedIndex = 0;

            LoadAvatar(
                SessionHelper.CurrentUser.VaiTro.ToString(),
                SessionHelper.CurrentUser.HinhAnh
            );

            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;

            loadTaiKhoan();
            loadMonAn();
            loadDanhMuc();
            loadBan();
        }

        // ==========================================
        // TAB TÀI KHOẢN
        // ==========================================
        private void loadTaiKhoan()
        {
            dgvTaiKhoan.DataSource = null;
            dgvTaiKhoan.Rows.Clear();
            dgvTaiKhoan.Columns.Clear();

            dgvTaiKhoan.Columns.Add("colTKId", "ID");
            dgvTaiKhoan.Columns.Add("colTKTen", "Tên đăng nhập");
            dgvTaiKhoan.Columns.Add("colTKVaiTro", "Vai trò");
            dgvTaiKhoan.Columns.Add("colTKHoatDong", "Hoạt động");
            dgvTaiKhoan.Columns.Add("colTKNgayTao", "Ngày tạo");

            List<NguoiDung> list = nguoiDungBLL.getAll();
            foreach (NguoiDung nd in list)
            {
                dgvTaiKhoan.Rows.Add(
                    nd.Id,
                    nd.TenDangNhap,
                    nd.VaiTro.ToString(),
                    nd.HoatDong ? "Đang hoạt động" : "Đã khoá",
                    nd.NgayTao.ToString("dd/MM/yyyy")
                );
            }

            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count == 0) return;

            string vaiTro = dgvTaiKhoan.SelectedRows[0].Cells["colTKVaiTro"].Value.ToString();
            string hoatDong = dgvTaiKhoan.SelectedRows[0].Cells["colTKHoatDong"].Value.ToString();

            cboVaiTro.SelectedItem = vaiTro;
            btnKhoaMo.Text = hoatDong == "Đang hoạt động" ? "Khoá" : "Mở khoá";
        }

        private void btnKhoaMo_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvTaiKhoan.SelectedRows[0].Cells["colTKId"].Value);
            string hoatDong = dgvTaiKhoan.SelectedRows[0].Cells["colTKHoatDong"].Value.ToString();

            // Không cho khoá chính mình
            if (id == SessionHelper.CurrentUser.Id)
            {
                MessageBox.Show("Không thể khoá tài khoản của chính mình!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool trangThaiMoi = hoatDong == "Đã khoá";

            bool ketQua = nguoiDungBLL.updateHoatDong(id, trangThaiMoi);
            if (ketQua)
            {
                MessageBox.Show(trangThaiMoi ? "Mở khoá thành công!" : "Khoá thành công!");
                loadTaiKhoan();
            }
        }

        private void btnDoiVaiTro_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvTaiKhoan.SelectedRows[0].Cells["colTKId"].Value);
            string vaiTro = cboVaiTro.SelectedItem.ToString();

            bool ketQua = nguoiDungBLL.updateVaiTro(id, vaiTro);
            if (ketQua)
            {
                MessageBox.Show("Đổi vai trò thành công!");
                loadTaiKhoan();
            }
            else
            {
                MessageBox.Show("Không thể đổi vai trò của chính mình!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // TAB MÓN ĂN
        // ==========================================
        private void loadMonAn()
        {
            dgvMonAn.DataSource = null;
            dgvMonAn.Rows.Clear();
            dgvMonAn.Columns.Clear();

            dgvMonAn.Columns.Add("colMAId", "ID");
            dgvMonAn.Columns.Add("colMADanhMuc", "Danh mục");
            dgvMonAn.Columns.Add("colMATenMon", "Tên món");
            dgvMonAn.Columns.Add("colMAGiaBan", "Giá bán");
            dgvMonAn.Columns.Add("colMAConHang", "Còn hàng");

            List<MonAn> list = monAnBLL.getAll();
            foreach (MonAn ma in list)
            {
                dgvMonAn.Rows.Add(
                    ma.Id,
                    ma.TenDanhMuc,
                    ma.TenMon,
                    ma.GiaBan.ToString("N0"),
                    ma.ConHang ? "Còn" : "Hết"
                );
            }

            dgvMonAn.ReadOnly = true;
            dgvMonAn.AllowUserToAddRows = false;
            dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            frmMonAn frm = new frmMonAn(danhMucBLL.getAll(), null);
            if (frm.ShowDialog() != DialogResult.OK) return;

            bool ketQua = monAnBLL.insert(frm.MonAnResult);
            if (ketQua)
            {
                MessageBox.Show("Thêm món thành công!");
                loadMonAn();
            }
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvMonAn.SelectedRows[0].Cells["colMAId"].Value);
            MonAn monAn = monAnBLL.getAll().Find(m => m.Id == id);

            frmMonAn frm = new frmMonAn(danhMucBLL.getAll(), monAn);
            if (frm.ShowDialog() != DialogResult.OK) return;

            bool ketQua = monAnBLL.update(frm.MonAnResult);
            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!");
                loadMonAn();
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvMonAn.SelectedRows[0].Cells["colMAId"].Value);

            DialogResult confirm = MessageBox.Show(
                "Xác nhận xoá món này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = monAnBLL.delete(id);
            if (ketQua)
            {
                MessageBox.Show("Xoá thành công!");
                loadMonAn();
            }
            else
            {
                MessageBox.Show("Xoá thất bại! Món có thể đang được dùng trong đơn hàng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatTatConHang_Click(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvMonAn.SelectedRows[0].Cells["colMAId"].Value);
            string conHang = dgvMonAn.SelectedRows[0].Cells["colMAConHang"].Value.ToString();

            bool trangThaiMoi = conHang == "Hết";

            bool ketQua = monAnBLL.updateConHang(id, trangThaiMoi);
            if (ketQua)
            {
                MessageBox.Show(trangThaiMoi ? "Bật còn hàng thành công!" : "Tắt còn hàng thành công!");
                loadMonAn();
            }
        }

        private void loadDanhMuc()
        {
            dgvDanhMuc.DataSource = null;
            dgvDanhMuc.Rows.Clear();
            dgvDanhMuc.Columns.Clear();

            dgvDanhMuc.Columns.Add("colDMId", "ID");
            dgvDanhMuc.Columns.Add("colDMTen", "Tên danh mục");
            dgvDanhMuc.Columns.Add("colDMThuTu", "Thứ tự");

            List<DanhMuc> list = danhMucBLL.getAll();
            foreach (DanhMuc dm in list)
                dgvDanhMuc.Rows.Add(dm.Id, dm.TenDanhMuc, dm.ThuTu);

            dgvDanhMuc.ReadOnly = true;
            dgvDanhMuc.AllowUserToAddRows = false;
            dgvDanhMuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhMuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMuc frm = new frmDanhMuc(null);
            if (frm.ShowDialog() != DialogResult.OK) return;

            bool ketQua = danhMucBLL.insert(frm.DanhMucResult);
            if (ketQua)
            {
                MessageBox.Show("Thêm danh mục thành công!");
                loadDanhMuc();
            }
        }

        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvDanhMuc.SelectedRows[0].Cells["colDMId"].Value);
            DanhMuc danhMuc = danhMucBLL.getAll().Find(d => d.Id == id);

            frmDanhMuc frm = new frmDanhMuc(danhMuc);
            if (frm.ShowDialog() != DialogResult.OK) return;

            bool ketQua = danhMucBLL.update(frm.DanhMucResult);
            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!");
                loadDanhMuc();
            }
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvDanhMuc.SelectedRows[0].Cells["colDMId"].Value);

            DialogResult confirm = MessageBox.Show(
                "Xác nhận xoá danh mục này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = danhMucBLL.delete(id);
            if (ketQua)
            {
                MessageBox.Show("Xoá thành công!");
                loadDanhMuc();
            }
            else
            {
                MessageBox.Show("Xoá thất bại! Danh mục có thể đang có món ăn.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadBan()
        {
            dgvBanAdmin.DataSource = null;
            dgvBanAdmin.Rows.Clear();
            dgvBanAdmin.Columns.Clear();

            dgvBanAdmin.Columns.Add("colBAId", "ID");
            dgvBanAdmin.Columns.Add("colBASoBan", "Số bàn");
            dgvBanAdmin.Columns.Add("colBASoCho", "Số chỗ");
            dgvBanAdmin.Columns.Add("colBATrangThai", "Trạng thái");

            List<Ban> list = banBLL.getAll();
            foreach (Ban ban in list)
                dgvBanAdmin.Rows.Add(ban.Id, ban.SoBan, ban.SoCho, ban.TrangThai.ToString());

            dgvBanAdmin.ReadOnly = true;
            dgvBanAdmin.AllowUserToAddRows = false;
            dgvBanAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBanAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan(null);
            if (frm.ShowDialog() != DialogResult.OK) return;

            bool ketQua = banBLL.insert(frm.BanResult);
            if (ketQua)
            {
                MessageBox.Show("Thêm bàn thành công!");
                loadBan();
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            if (dgvBanAdmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvBanAdmin.SelectedRows[0].Cells["colBAId"].Value);
            Ban ban = banBLL.getAll().Find(b => b.Id == id);

            frmBan frm = new frmBan(ban);
            if (frm.ShowDialog() != DialogResult.OK) return;

            bool ketQua = banBLL.update(frm.BanResult);
            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!");
                loadBan();
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            if (dgvBanAdmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvBanAdmin.SelectedRows[0].Cells["colBAId"].Value);

            DialogResult confirm = MessageBox.Show(
                "Xác nhận xoá bàn này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ketQua = banBLL.delete(id);
            if (ketQua)
            {
                MessageBox.Show("Xoá thành công!");
                loadBan();
            }
            else
            {
                MessageBox.Show("Xoá thất bại! Bàn có thể đang có đơn hàng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
                return;
            }

            // Vẫn load DataGridView như cũ
            loadBaoCaoDoanhThu(tuNgay, denNgay);
            loadMonBanChay(tuNgay, denNgay);

            // Thêm: mở form report
            frmBaoCaoReport frmReport = new frmBaoCaoReport(tuNgay, denNgay);
            frmReport.ShowDialog();
        }

        private void loadBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            dgvBaoCao.DataSource = null;
            dgvBaoCao.Rows.Clear();
            dgvBaoCao.Columns.Clear();

            dgvBaoCao.Columns.Add("colBCId", "Mã TT");
            dgvBaoCao.Columns.Add("colBCDonHang", "Mã đơn");
            dgvBaoCao.Columns.Add("colBCTongTien", "Tổng tiền");
            dgvBaoCao.Columns.Add("colBCGiam", "Giảm giá");
            dgvBaoCao.Columns.Add("colBCThanhToan", "Thanh toán");
            dgvBaoCao.Columns.Add("colBCPhuongThuc", "Phương thức");
            dgvBaoCao.Columns.Add("colBCNgay", "Ngày");

            List<ThanhToan> list = baoCaoBLL.getBaoCaoDoanhThu(tuNgay, denNgay);
            decimal tongDoanhThu = 0;

            foreach (ThanhToan tt in list)
            {
                dgvBaoCao.Rows.Add(
                    tt.Id,
                    tt.DonHangId,
                    tt.TongTien.ToString("N0"),
                    tt.TienGiam.ToString("N0"),
                    tt.TienThanhToan.ToString("N0"),
                    tt.PhuongThuc.ToString(),
                    tt.NgayThanhToan.ToString("dd/MM/yyyy HH:mm")
                );
                tongDoanhThu += tt.TienThanhToan;
            }

            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0}đ";
        }

        private void loadMonBanChay(DateTime tuNgay, DateTime denNgay)
        {
            dgvMonBanChay.DataSource = null;
            dgvMonBanChay.Rows.Clear();
            dgvMonBanChay.Columns.Clear();

            dgvMonBanChay.Columns.Add("colMBCTen", "Tên món");
            dgvMonBanChay.Columns.Add("colMBCSoLuong", "Số lượng bán");
            dgvMonBanChay.Columns.Add("colMBCDoanhThu", "Doanh thu");

            List<MonAnBanChay> list = baoCaoBLL.getMonBanChay(tuNgay, denNgay);
            foreach (MonAnBanChay m in list)
            {
                dgvMonBanChay.Rows.Add(
                    m.TenMon,
                    m.TongSoLuong,
                    m.TongDoanhThu.ToString("N0")
                );
            }

            dgvMonBanChay.ReadOnly = true;
            dgvMonBanChay.AllowUserToAddRows = false;
            dgvMonBanChay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

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
            if (ofdAvatar.ShowDialog() == DialogResult.OK)
            {
                string userRole = SessionHelper.CurrentUser.VaiTro.ToString();
                string userID = SessionHelper.CurrentUser.Id.ToString();
                string folderPath = Path.Combine(Application.StartupPath, "Avatars", userRole);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                string extension = Path.GetExtension(ofdAvatar.FileName);
                string fileName = userID + extension;
                string destPath = Path.Combine(folderPath, fileName);
                File.Copy(ofdAvatar.FileName, destPath, true);
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
                string role = SessionHelper.CurrentUser.VaiTro.ToString();
                string tableName = (role == "KhachHang") ? "KhachHang" : "NguoiDung";

                string sql = $"UPDATE {tableName} SET HinhAnh = @hinh WHERE Id = @id";

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@hinh", relativePath);
                    cmd.Parameters.AddWithValue("@id", userID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        SessionHelper.CurrentUser.HinhAnh = relativePath;
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

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản muốn xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID và tên của tài khoản đang chọn
            int id = Convert.ToInt32(dgvTaiKhoan.SelectedRows[0].Cells["colTKId"].Value);
            string tenTK = dgvTaiKhoan.SelectedRows[0].Cells["colTKTen"].Value.ToString();

            // Xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vĩnh viễn tài khoản [{tenTK}] không?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // Gọi BLL thực hiện xóa
            bool ketQua = nguoiDungBLL.delete(id);
            if (ketQua)
            {
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo");
                loadTaiKhoan(); // Tải lại danh sách sau khi xóa
            }
            else
            {
                MessageBox.Show("Xóa thất bại! Bạn không thể xóa chính mình hoặc tài khoản này đang có dữ liệu liên quan (như đơn hàng).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}