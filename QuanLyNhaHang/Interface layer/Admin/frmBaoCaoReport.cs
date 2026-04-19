using Microsoft.Reporting.WinForms;
using QuanLyNhaHang.BL_layer;
using QuanLyNhaHang.dsReportTableAdapters;
using QuanLyNhaHang.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyNhaHang.Interface_layer.Admin
{
    public partial class frmBaoCaoReport : Form
    {
        private DateTime _tuNgay;
        private DateTime _denNgay;

        public frmBaoCaoReport(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            _tuNgay = tuNgay;
            _denNgay = denNgay;
        }

        private void frmBaoCaoReport_Load(object sender, EventArgs e)
        {
            // Dùng BLL thay vì TableAdapter
            BaoCaoBLL baoCaoBLL = new BaoCaoBLL();
            List<ThanhToan> list = baoCaoBLL.getBaoCaoDoanhThu(_tuNgay, _denNgay);

            // Chuyển List sang DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("DonHangId");
            dt.Columns.Add("TongTien");
            dt.Columns.Add("TienGiam");
            dt.Columns.Add("TienThanhToan");
            dt.Columns.Add("PhuongThuc");
            dt.Columns.Add("NgayThanhToan");

            foreach (ThanhToan tt in list)
            {
                dt.Rows.Add(
                    tt.Id,
                    tt.DonHangId,
                    tt.TongTien,
                    tt.TienGiam,
                    tt.TienThanhToan,
                    tt.PhuongThuc.ToString(),
                    tt.NgayThanhToan.ToString("dd/MM/yyyy HH:mm")
                );
            }

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "QuanLyNhaHang.rptDoanhThu.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("dsReport_ThanhToan", dt.DefaultView));

            reportViewer1.RefreshReport();
        }
    }
}
