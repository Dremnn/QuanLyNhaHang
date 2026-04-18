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

            // 2. Gán sự kiện click cho các nút danh mục bằng Lambda Expression
            btnTatCa.Click += (s, ev) => loadMonAn(0);
            btnMonCom.Click += (s, ev) => loadMonAn(1);
            btnMonCanh.Click += (s, ev) => loadMonAn(2);
            btnMonThem.Click += (s, ev) => loadMonAn(3);
            btnGiaiKhat.Click += (s, ev) => loadMonAn(4);

            // 3. Hiển thị tất cả món ăn khi vừa mở form lên
            loadMonAn(0);
        }

        // ==========================================
        // XỬ LÝ HIỂN THỊ THỰC ĐƠN
        // ==========================================
        private void loadMonAn(int danhMucId)
        {
            if (lvMonAn == null) return;

            lvMonAn.Items.Clear();

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(120, 120);
            imgList.ColorDepth = ColorDepth.Depth32Bit;

            List<MonAn> list = danhMucId == 0
                ? monAnBLL.getAll()
                : monAnBLL.getByDanhMuc(danhMucId);

            int index = 0;
            foreach (MonAn mon in list)
            {
                string fullPath = Path.Combine(Application.StartupPath, mon.AnhUrl ?? "");

                // Nếu không tìm thấy ảnh theo đường dẫn, lấy ảnh mặc định trong Resources
                Image img = File.Exists(fullPath)
                    ? Image.FromFile(fullPath)
                    : Properties.Resources.default_image;

                imgList.Images.Add(img);

                ListViewItem item = new ListViewItem();
                item.Text = $"{mon.TenMon}\n{mon.GiaBan:N0}đ";
                item.ImageIndex = index;
                item.Tag = mon;

                // Làm mờ món đã hết hàng
                if (!mon.ConHang)
                    item.ForeColor = Color.Gray;

                lvMonAn.Items.Add(item);
                index++;
            }

            lvMonAn.LargeImageList = imgList;
            lvMonAn.View = View.LargeIcon;
        }

        // ==========================================
        // CÁC SỰ KIỆN NÚT BẤM (EVENTS)
        // ==========================================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmLogin = new frmDangNhap();

            // Nếu form Đăng Nhập trả về kết quả OK (đăng nhập thành công)
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