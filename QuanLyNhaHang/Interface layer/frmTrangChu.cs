using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyNhaHang.BL_layer;
using QuanLyNhaHang.Model;
using QuanLyNhaHang.Interface_layer.Auth;
using QuanLyNhaHang.Helpers;
using QuanLyNhaHang.Interface_layer.Admin;
using QuanLyNhaHang.Interface_layer.FrmNhanVien;
using QuanLyNhaHang.Interface_layer.FrmKhachHang;

namespace QuanLyNhaHang.Interface_layer
{
    public partial class frmTrangChu : Form
    {
        private MonAnBLL monAnBLL = new MonAnBLL();
        private DanhMucBLL danhMucBLL = new DanhMucBLL();

        public frmTrangChu()
        {
            InitializeComponent();
        }

        // ==========================================
        // LOAD FORM
        // ==========================================
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            // 1. Load ảnh banner (nếu có file)
            string bannerPath = Path.Combine(Application.StartupPath, "Images", "banner.jpg");
            if (File.Exists(bannerPath))
            {
                picBanner.Image = Image.FromFile(bannerPath);
            }

            LoadDynamicDanhMuc();

            loadMonAn(0);
        }

        // ==========================================
        // XỬ LÝ HIỂN THỊ THỰC ĐƠN
        // ==========================================
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

        private void LoadDynamicDanhMuc()
        {
            flpDanhMuc.Controls.Clear();

            // === KÍCH THƯỚC ĐÃ ĐƯỢC ÉP CHUẨN VỚI FLP CỦA BẠN (955 x 106) ===
            int chieuRongNut = 100;
            int chieuCaoNut = 50; // Form bạn cao 106, nút cao 65 là cân đối

            // Font chữ
            Font fontChu = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Lề: Trái 5, Trên 15 (để nút tụt xuống giữa panel), Phải 5, Dưới 0
            Padding khoangCach = new Padding(5, 15, 5, 0);

            // 1. NÚT "TẤT CẢ"
            Button btnAll = new Button();
            btnAll.Text = "Tất cả";
            btnAll.Size = new Size(chieuRongNut, chieuCaoNut);
            btnAll.Font = fontChu;
            btnAll.Margin = khoangCach;

            // KIỂU DÁNG TRẮNG ĐƠN GIẢN
            btnAll.BackColor = Color.White;
            btnAll.ForeColor = Color.Black;
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.FlatAppearance.BorderColor = Color.Silver; // Viền màu bạc
            btnAll.FlatAppearance.BorderSize = 1;
            btnAll.Cursor = Cursors.Hand;

            btnAll.Click += (s, ev) => loadMonAn(0);
            flpDanhMuc.Controls.Add(btnAll);

            // 2. CÁC NÚT TỪ DATABASE
            List<DanhMuc> listDM = danhMucBLL.getAll();
            foreach (DanhMuc dm in listDM)
            {
                Button btn = new Button();
                btn.Text = dm.TenDanhMuc;
                btn.Size = new Size(chieuRongNut, chieuCaoNut);
                btn.Font = fontChu;
                btn.Margin = khoangCach;
                btn.Tag = dm.Id;

                // KIỂU DÁNG TRẮNG ĐƠN GIẢN
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Silver;
                btn.FlatAppearance.BorderSize = 1;
                btn.Cursor = Cursors.Hand;

                btn.Click += (s, ev) => {
                    loadMonAn(dm.Id);
                };

                flpDanhMuc.Controls.Add(btn);
            }
        }

        // ==========================================
        // CÁC SỰ KIỆN NÚT BẤM (EVENTS)
        // ==========================================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmLogin = new frmDangNhap();

            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                // Kiểm tra SessionHelper xem user có quyền gì
                if (SessionHelper.isLoggedIn())
                {
                    this.Hide(); // Ẩn trang chủ đi

                    Form mainForm = null;

                    // Sử dụng các hàm bạn đã viết sẵn trong SessionHelper
                    if (SessionHelper.isAdmin())
                    {
                        mainForm = new frmAdminMain();
                    }
                    else if (SessionHelper.isNhanVien())
                    {
                        mainForm = new frmNhanVienMain();
                    }
                    else if (SessionHelper.isKhachHang())
                    {
                        mainForm = new frmKhachHangMain();
                    }

                    // Mở form phân quyền lên và BẮT BUỘC CHỜ nó đóng lại
                    if (mainForm != null)
                    {
                        mainForm.ShowDialog();
                    }

                    // --- Code bên dưới chỉ chạy khi mainForm bị tắt đi ---

                    SessionHelper.logout(); // Xoá tài khoản khỏi bộ nhớ
                    this.Show(); // Hiện lại form Trang Chủ ban đầu
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}