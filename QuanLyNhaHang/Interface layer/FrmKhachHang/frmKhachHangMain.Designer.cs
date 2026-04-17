namespace QuanLyNhaHang.Interface_layer.FrmKhachHang
{
    partial class frmKhachHangMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabThucDon = new System.Windows.Forms.TabPage();
            this.pnlDanhMuc = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnMonCom = new System.Windows.Forms.Button();
            this.btnMonCanh = new System.Windows.Forms.Button();
            this.btnMonThem = new System.Windows.Forms.Button();
            this.btnGiaiKhat = new System.Windows.Forms.Button();
            this.lvMonAn = new System.Windows.Forms.ListView();
            this.tabDatBan = new System.Windows.Forms.TabPage();
            this.btnDatBan = new System.Windows.Forms.Button();
            this.lblThongTinBan = new System.Windows.Forms.Label();
            this.lbDanhSachBan = new System.Windows.Forms.ListBox();
            this.lblChonBan = new System.Windows.Forms.Label();
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.btnHuyDatBan = new System.Windows.Forms.Button();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.lblChaoMung = new System.Windows.Forms.Label();
            this.ofdKhachHang = new System.Windows.Forms.OpenFileDialog();
            this.pBAVT = new System.Windows.Forms.PictureBox();
            this.tabMain.SuspendLayout();
            this.tabThucDon.SuspendLayout();
            this.pnlDanhMuc.SuspendLayout();
            this.tabDatBan.SuspendLayout();
            this.tabLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.tabThongTin.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBAVT)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabThucDon);
            this.tabMain.Controls.Add(this.tabDatBan);
            this.tabMain.Controls.Add(this.tabLichSu);
            this.tabMain.Controls.Add(this.tabThongTin);
            this.tabMain.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabMain.Location = new System.Drawing.Point(12, 94);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(972, 432);
            this.tabMain.TabIndex = 0;
            // 
            // tabThucDon
            // 
            this.tabThucDon.Controls.Add(this.pnlDanhMuc);
            this.tabThucDon.Controls.Add(this.lvMonAn);
            this.tabThucDon.Location = new System.Drawing.Point(4, 28);
            this.tabThucDon.Name = "tabThucDon";
            this.tabThucDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabThucDon.Size = new System.Drawing.Size(964, 400);
            this.tabThucDon.TabIndex = 0;
            this.tabThucDon.Text = "Thực Đơn";
            this.tabThucDon.UseVisualStyleBackColor = true;
            // 
            // pnlDanhMuc
            // 
            this.pnlDanhMuc.Controls.Add(this.btnTatCa);
            this.pnlDanhMuc.Controls.Add(this.btnMonCom);
            this.pnlDanhMuc.Controls.Add(this.btnMonCanh);
            this.pnlDanhMuc.Controls.Add(this.btnMonThem);
            this.pnlDanhMuc.Controls.Add(this.btnGiaiKhat);
            this.pnlDanhMuc.Location = new System.Drawing.Point(6, 7);
            this.pnlDanhMuc.Name = "pnlDanhMuc";
            this.pnlDanhMuc.Size = new System.Drawing.Size(951, 88);
            this.pnlDanhMuc.TabIndex = 1;
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(3, 3);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(149, 67);
            this.btnTatCa.TabIndex = 0;
            this.btnTatCa.Text = "Tất Cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            // 
            // btnMonCom
            // 
            this.btnMonCom.Location = new System.Drawing.Point(158, 3);
            this.btnMonCom.Name = "btnMonCom";
            this.btnMonCom.Size = new System.Drawing.Size(149, 67);
            this.btnMonCom.TabIndex = 1;
            this.btnMonCom.Text = "Món Cơm";
            this.btnMonCom.UseVisualStyleBackColor = true;
            // 
            // btnMonCanh
            // 
            this.btnMonCanh.Location = new System.Drawing.Point(313, 3);
            this.btnMonCanh.Name = "btnMonCanh";
            this.btnMonCanh.Size = new System.Drawing.Size(149, 67);
            this.btnMonCanh.TabIndex = 2;
            this.btnMonCanh.Text = "Món Canh";
            this.btnMonCanh.UseVisualStyleBackColor = true;
            // 
            // btnMonThem
            // 
            this.btnMonThem.Location = new System.Drawing.Point(468, 3);
            this.btnMonThem.Name = "btnMonThem";
            this.btnMonThem.Size = new System.Drawing.Size(149, 67);
            this.btnMonThem.TabIndex = 3;
            this.btnMonThem.Text = "Món Thêm";
            this.btnMonThem.UseVisualStyleBackColor = true;
            // 
            // btnGiaiKhat
            // 
            this.btnGiaiKhat.Location = new System.Drawing.Point(623, 3);
            this.btnGiaiKhat.Name = "btnGiaiKhat";
            this.btnGiaiKhat.Size = new System.Drawing.Size(149, 67);
            this.btnGiaiKhat.TabIndex = 4;
            this.btnGiaiKhat.Text = "Giải Khát";
            this.btnGiaiKhat.UseVisualStyleBackColor = true;
            // 
            // lvMonAn
            // 
            this.lvMonAn.HideSelection = false;
            this.lvMonAn.Location = new System.Drawing.Point(6, 101);
            this.lvMonAn.Name = "lvMonAn";
            this.lvMonAn.Size = new System.Drawing.Size(952, 302);
            this.lvMonAn.TabIndex = 0;
            this.lvMonAn.UseCompatibleStateImageBehavior = false;
            // 
            // tabDatBan
            // 
            this.tabDatBan.Controls.Add(this.btnDatBan);
            this.tabDatBan.Controls.Add(this.lblThongTinBan);
            this.tabDatBan.Controls.Add(this.lbDanhSachBan);
            this.tabDatBan.Controls.Add(this.lblChonBan);
            this.tabDatBan.Location = new System.Drawing.Point(4, 28);
            this.tabDatBan.Name = "tabDatBan";
            this.tabDatBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatBan.Size = new System.Drawing.Size(964, 400);
            this.tabDatBan.TabIndex = 3;
            this.tabDatBan.Text = "Đặt Bàn";
            this.tabDatBan.UseVisualStyleBackColor = true;
            // 
            // btnDatBan
            // 
            this.btnDatBan.Location = new System.Drawing.Point(741, 49);
            this.btnDatBan.Name = "btnDatBan";
            this.btnDatBan.Size = new System.Drawing.Size(181, 34);
            this.btnDatBan.TabIndex = 2;
            this.btnDatBan.Text = "Đặt Bàn";
            this.btnDatBan.UseVisualStyleBackColor = true;
            this.btnDatBan.Click += new System.EventHandler(this.btnDatBan_Click);
            // 
            // lblThongTinBan
            // 
            this.lblThongTinBan.AutoSize = true;
            this.lblThongTinBan.Location = new System.Drawing.Point(186, 99);
            this.lblThongTinBan.Name = "lblThongTinBan";
            this.lblThongTinBan.Size = new System.Drawing.Size(109, 19);
            this.lblThongTinBan.TabIndex = 2;
            this.lblThongTinBan.Text = "Thông tin bàn :";
            // 
            // lbDanhSachBan
            // 
            this.lbDanhSachBan.FormattingEnabled = true;
            this.lbDanhSachBan.ItemHeight = 19;
            this.lbDanhSachBan.Location = new System.Drawing.Point(324, 49);
            this.lbDanhSachBan.Name = "lbDanhSachBan";
            this.lbDanhSachBan.Size = new System.Drawing.Size(281, 308);
            this.lbDanhSachBan.TabIndex = 1;
            this.lbDanhSachBan.SelectedIndexChanged += new System.EventHandler(this.lbDanhSachBan_SelectedIndexChanged);
            // 
            // lblChonBan
            // 
            this.lblChonBan.AutoSize = true;
            this.lblChonBan.Location = new System.Drawing.Point(186, 49);
            this.lblChonBan.Name = "lblChonBan";
            this.lblChonBan.Size = new System.Drawing.Size(117, 19);
            this.lblChonBan.TabIndex = 0;
            this.lblChonBan.Text = "Chọn bàn trống:";
            // 
            // tabLichSu
            // 
            this.tabLichSu.Controls.Add(this.btnHuyDatBan);
            this.tabLichSu.Controls.Add(this.dgvDonHang);
            this.tabLichSu.Location = new System.Drawing.Point(4, 28);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Padding = new System.Windows.Forms.Padding(3);
            this.tabLichSu.Size = new System.Drawing.Size(964, 400);
            this.tabLichSu.TabIndex = 1;
            this.tabLichSu.Text = "Lịch Sử Đơn";
            this.tabLichSu.UseVisualStyleBackColor = true;
            // 
            // btnHuyDatBan
            // 
            this.btnHuyDatBan.Location = new System.Drawing.Point(741, 355);
            this.btnHuyDatBan.Name = "btnHuyDatBan";
            this.btnHuyDatBan.Size = new System.Drawing.Size(181, 34);
            this.btnHuyDatBan.TabIndex = 2;
            this.btnHuyDatBan.Text = "Hủy Đặt Bàn";
            this.btnHuyDatBan.UseVisualStyleBackColor = true;
            this.btnHuyDatBan.Click += new System.EventHandler(this.btnHuyDatBan_Click);
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHang.Location = new System.Drawing.Point(6, 6);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.RowHeadersWidth = 51;
            this.dgvDonHang.RowTemplate.Height = 24;
            this.dgvDonHang.Size = new System.Drawing.Size(952, 330);
            this.dgvDonHang.TabIndex = 0;
            // 
            // tabThongTin
            // 
            this.tabThongTin.Controls.Add(this.pBAVT);
            this.tabThongTin.Controls.Add(this.btnCapNhat);
            this.tabThongTin.Controls.Add(this.txtEmail);
            this.tabThongTin.Controls.Add(this.label5);
            this.tabThongTin.Controls.Add(this.txtDiaChi);
            this.tabThongTin.Controls.Add(this.label4);
            this.tabThongTin.Controls.Add(this.txtSoDienThoai);
            this.tabThongTin.Controls.Add(this.label3);
            this.tabThongTin.Controls.Add(this.txtHoTen);
            this.tabThongTin.Controls.Add(this.label2);
            this.tabThongTin.Location = new System.Drawing.Point(4, 28);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTin.Size = new System.Drawing.Size(964, 400);
            this.tabThongTin.TabIndex = 2;
            this.tabThongTin.Text = "Thông Tin";
            this.tabThongTin.UseVisualStyleBackColor = true;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(601, 286);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(120, 42);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cap Nhat";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(468, 184);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(254, 27);
            this.txtEmail.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(468, 140);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(254, 27);
            this.txtDiaChi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(468, 96);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(254, 27);
            this.txtSoDienThoai.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Điện Thoại";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(468, 50);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(254, 27);
            this.txtHoTen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ Tên";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblChaoMung);
            this.pnlHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlHeader.Location = new System.Drawing.Point(16, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(963, 76);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(741, 22);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(181, 34);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblChaoMung
            // 
            this.lblChaoMung.AutoSize = true;
            this.lblChaoMung.Location = new System.Drawing.Point(3, 22);
            this.lblChaoMung.Name = "lblChaoMung";
            this.lblChaoMung.Size = new System.Drawing.Size(133, 19);
            this.lblChaoMung.TabIndex = 0;
            this.lblChaoMung.Text = "Chao Mung , [Ten]";
            // 
            // ofdKhachHang
            // 
            this.ofdKhachHang.FileName = "openFileDialog1";
            // 
            // pBAVT
            // 
            this.pBAVT.Location = new System.Drawing.Point(30, 31);
            this.pBAVT.Name = "pBAVT";
            this.pBAVT.Size = new System.Drawing.Size(180, 180);
            this.pBAVT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBAVT.TabIndex = 9;
            this.pBAVT.TabStop = false;
            this.pBAVT.Click += new System.EventHandler(this.pBAVT_Click);
            this.pBAVT.Paint += new System.Windows.Forms.PaintEventHandler(this.pBAVT_Paint);
            // 
            // frmKhachHangMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 538);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKhachHangMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKhachHangMain";
            this.Load += new System.EventHandler(this.frmKhachHangMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabThucDon.ResumeLayout(false);
            this.pnlDanhMuc.ResumeLayout(false);
            this.tabDatBan.ResumeLayout(false);
            this.tabDatBan.PerformLayout();
            this.tabLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBAVT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabThucDon;
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lblChaoMung;
        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ListView lvMonAn;
        private System.Windows.Forms.FlowLayoutPanel pnlDanhMuc;
        private System.Windows.Forms.TabPage tabDatBan;
        private System.Windows.Forms.ListBox lbDanhSachBan;
        private System.Windows.Forms.Label lblChonBan;
        private System.Windows.Forms.Label lblThongTinBan;
        private System.Windows.Forms.Button btnDatBan;
        private System.Windows.Forms.Button btnHuyDatBan;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.Button btnMonCom;
        private System.Windows.Forms.Button btnMonCanh;
        private System.Windows.Forms.Button btnMonThem;
        private System.Windows.Forms.Button btnGiaiKhat;
        private System.Windows.Forms.OpenFileDialog ofdKhachHang;
        private System.Windows.Forms.PictureBox pBAVT;
    }
}