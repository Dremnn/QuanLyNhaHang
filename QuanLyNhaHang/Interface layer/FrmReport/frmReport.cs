using Microsoft.Reporting.WinForms;
using QuanLyNhaHang.DB_layer;
using QuanLyNhaHang.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer
{
    public partial class frmReport : Form
    {
        public enum LoaiBaoCao { DoanhThu, MonBanChay, HoaDon, CaNhanVien }

        private LoaiBaoCao _loai;
        private DateTime _tuNgay;
        private DateTime _denNgay;
        private int _donHangId;
        private int _nguoiDungId;

        public frmReport(LoaiBaoCao loai, DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            _loai = loai; _tuNgay = tuNgay; _denNgay = denNgay;
        }

        public frmReport(int donHangId)
        {
            InitializeComponent();
            _loai = LoaiBaoCao.HoaDon; _donHangId = donHangId;
        }

        public frmReport(DateTime tuNgay, DateTime denNgay, int nguoiDungId)
        {
            InitializeComponent();
            _loai = LoaiBaoCao.CaNhanVien;
            _tuNgay = tuNgay; _denNgay = denNgay; _nguoiDungId = nguoiDungId;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            switch (_loai)
            {
                case LoaiBaoCao.DoanhThu:
                    this.Text = $"Bao Cao Doanh Thu ({_tuNgay:dd/MM/yyyy} - {_denNgay:dd/MM/yyyy})";
                    loadDoanhThu(); break;
                case LoaiBaoCao.MonBanChay:
                    this.Text = $"Top Mon Ban Chay ({_tuNgay:dd/MM/yyyy} - {_denNgay:dd/MM/yyyy})";
                    loadMonBanChay(); break;
                case LoaiBaoCao.HoaDon:
                    this.Text = $"Hoa Don - Don #{_donHangId}";
                    loadHoaDon(); break;
                case LoaiBaoCao.CaNhanVien:
                    this.Text = $"Bao Cao Ca ({_tuNgay:dd/MM/yyyy} - {_denNgay:dd/MM/yyyy})";
                    loadCaNhanVien(); break;
            }
        }

        // ── 1. Doanh thu dùng rptDoanhThu.rdlc (đang hoạt động sẵn) ──────
        private void loadDoanhThu()
        {
            DataTable dt = queryDB(@"
                SELECT Id, DonHangId, TongTien, TienGiam, TienThanhToan,
                       PhuongThuc, TrangThai, GhiChu, NgayThanhToan
                FROM ThanhToan
                WHERE TrangThai = 'ThanhCong'
                  AND CAST(NgayThanhToan AS DATE) BETWEEN @tu AND @den
                ORDER BY NgayThanhToan",
                new SqlParameter("@tu", _tuNgay.Date),
                new SqlParameter("@den", _denNgay.Date));

            // Dùng đúng tên dataset trong rptDoanhThu.rdlc là "rptDoanhThu"
            reportViewer1.LocalReport.ReportEmbeddedResource =
                "QuanLyNhaHang.Reports.rptDoanhThu.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("rptDoanhThu", dt));
            reportViewer1.RefreshReport();
        }

        // ── 2. Món bán chạy dùng ptMonBanChay.rdlc ───────────────────────
        private void loadMonBanChay()
        {
            // Field names phải khớp DataField trong rdlc: STT, TenMon, SoLuong, DoanhThu
            DataTable dt = queryDB(@"
                SELECT TOP 10
                    ROW_NUMBER() OVER (ORDER BY SUM(ct.SoLuong) DESC) AS STT,
                    m.TenMon,
                    SUM(ct.SoLuong)             AS SoLuong,
                    SUM(ct.SoLuong * ct.DonGia) AS DoanhThu
                FROM ChiTietDon ct
                JOIN MonAn   m  ON m.Id  = ct.MonAnId
                JOIN DonHang dh ON dh.Id = ct.DonHangId
                WHERE dh.TrangThai = 'DaThanhToan'
                  AND CAST(dh.NgayTao AS DATE) BETWEEN @tu AND @den
                GROUP BY m.TenMon
                ORDER BY SUM(ct.SoLuong) DESC",
                new SqlParameter("@tu", _tuNgay.Date),
                new SqlParameter("@den", _denNgay.Date));

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "QuanLyNhaHang.Reports.ptMonBanChay.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DsMonBanChay", dt));
            reportViewer1.LocalReport.SetParameters(new[] {
                new ReportParameter("TuNgay",  _tuNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("DenNgay", _denNgay.ToString("dd/MM/yyyy"))
            });
            reportViewer1.RefreshReport();
        }

        // ── 3. Hoá đơn dùng ptHoaDon.rdlc ────────────────────────────────
        private void loadHoaDon()
        {
            // Field names khớp DataField rdlc: MaDon, SoBan, TenKhach, TongTien, TienGiam, TienThanhToan, PhuongThuc, NgayThanhToan, NhanVienThu
            DataTable dtHeader = queryDB(@"
                SELECT dh.Id AS MaDon, b.SoBan,
                       ISNULL(kh.HoTen, N'Khach vang lai') AS TenKhach,
                       tt.TongTien, tt.TienGiam, tt.TienThanhToan,
                       tt.PhuongThuc, tt.NgayThanhToan,
                       ISNULL(nd.TenDangNhap, '') AS NhanVienThu
                FROM DonHang dh
                JOIN Ban b ON b.Id = dh.BanId
                JOIN ThanhToan tt ON tt.DonHangId = dh.Id
                LEFT JOIN KhachHang kh ON kh.Id = dh.KhachHangId
                LEFT JOIN NguoiDung nd ON nd.Id = dh.NguoiDungId
                WHERE dh.Id = @id",
                new SqlParameter("@id", _donHangId));

            // Field names: TenMon, SoLuong, DonGia, ThanhTien
            DataTable dtChiTiet = queryDB(@"
                SELECT m.TenMon, ct.SoLuong, ct.DonGia,
                       ct.SoLuong * ct.DonGia AS ThanhTien
                FROM ChiTietDon ct
                JOIN MonAn m ON m.Id = ct.MonAnId
                WHERE ct.DonHangId = @id ORDER BY m.TenMon",
                new SqlParameter("@id", _donHangId));

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "QuanLyNhaHang.Reports.ptHoaDon.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DsHoaDonHeader", dtHeader));
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DsHoaDonChiTiet", dtChiTiet));
            reportViewer1.RefreshReport();
        }

        // ── 4. Báo cáo ca dùng ptCaNhanVien.rdlc ─────────────────────────
        private void loadCaNhanVien()
        {
            // Field names khớp DataField rdlc: MaTT, MaDon, SoBan, TongTien, GiamGia, ThanhToan, PhuongThuc, NgayThanhToan
            DataTable dt = queryDB(@"
                SELECT tt.Id AS MaTT, tt.DonHangId AS MaDon, b.SoBan,
                       tt.TongTien, tt.TienGiam AS GiamGia,
                       tt.TienThanhToan AS ThanhToan,
                       tt.PhuongThuc, tt.NgayThanhToan
                FROM ThanhToan tt
                JOIN DonHang dh ON dh.Id = tt.DonHangId
                JOIN Ban b ON b.Id = dh.BanId
                WHERE tt.TrangThai = 'ThanhCong'
                  AND dh.NguoiDungId = @nv
                  AND CAST(tt.NgayThanhToan AS DATE) BETWEEN @tu AND @den
                ORDER BY tt.NgayThanhToan",
                new SqlParameter("@nv", _nguoiDungId),
                new SqlParameter("@tu", _tuNgay.Date),
                new SqlParameter("@den", _denNgay.Date));

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "QuanLyNhaHang.Reports.ptCaNhanVien.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("DsCaNhanVien", dt));
            reportViewer1.LocalReport.SetParameters(new[] {
                new ReportParameter("TenNhanVien", SessionHelper.CurrentUser.TenDangNhap),
                new ReportParameter("TuNgay",  _tuNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("DenNgay", _denNgay.ToString("dd/MM/yyyy"))
            });
            reportViewer1.RefreshReport();
        }

        private DataTable queryDB(string sql, params SqlParameter[] prms)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(prms);
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
            }
            return dt;
        }
    }
}