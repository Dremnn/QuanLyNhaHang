using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.Interface_layer.FrmNhanVien
{
    public partial class frmChonMon : Form
    {
        public int MonAnId { get; private set; } = -1;
        public int SoLuong { get; private set; } = 1;
        private List<MonAn> _danhSachMon;

        public frmChonMon(List<MonAn> danhSachMon)
        {
            InitializeComponent();
            _danhSachMon = danhSachMon;
        }

        private void frmChonMon_Load(object sender, EventArgs e)
        {
            nudSoLuong.Minimum = 1;
            nudSoLuong.Maximum = 99;
            nudSoLuong.Value = 1;

            _danhSachMon.ForEach(m =>
                lbMon.Items.Add($"{m.TenMon} - {m.GiaBan:N0}đ"));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lbMon.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn món!");
                return;
            }
            MonAnId = _danhSachMon[lbMon.SelectedIndex].Id;
            SoLuong = (int)nudSoLuong.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
