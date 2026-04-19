using Microsoft.Reporting.WinForms;
using QuanLyNhaHang.BL_layer;
using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer.FrmNhanVien
{
    public partial class frmHoaDon : Form
    {
        private int _donHangId;

        public frmHoaDon(int donHangId)
        {
            InitializeComponent();

            _donHangId = donHangId;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            ChiTietDonBLL chiTietDonBLL = new ChiTietDonBLL();
            List<ChiTietDon> list = chiTietDonBLL.getByDonHangId(_donHangId);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("DonHangId");
            dt.Columns.Add("MonAnId");
            dt.Columns.Add("TenMon");      // ← thêm cột này
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonGia");
            dt.Columns.Add("GhiChu");

            foreach (ChiTietDon ct in list)
            {
                dt.Rows.Add(
                    ct.Id,
                    ct.DonHangId,
                    ct.MonAnId,
                    ct.TenMon,
                    ct.SoLuong,
                    ct.DonGia,
                    ct.GhiChu
                );
            }

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "QuanLyNhaHang.rptHoaDon.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("dsReport_ChiTietDon", dt.DefaultView));
            reportViewer1.RefreshReport();
        }
    }
}