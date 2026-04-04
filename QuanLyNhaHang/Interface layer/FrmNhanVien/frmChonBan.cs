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
    public partial class frmChonBan : Form
    {
        public int BanIdDuocChon { get; private set; } = -1;
        private List<Ban> _danhSachBan;

        public frmChonBan(List<Ban> danhSachBan)
        {
            InitializeComponent();
            _danhSachBan = danhSachBan;
        }

        private void frmChonBan_Load(object sender, EventArgs e)
        {
            _danhSachBan.ForEach(b =>
                lbBan.Items.Add($"Bàn {b.SoBan} - {b.SoCho} chỗ"));
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (lbBan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!");
                return;
            }
            BanIdDuocChon = _danhSachBan[lbBan.SelectedIndex].Id;
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
