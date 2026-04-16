namespace QuanLyNhaHang.Interface_layer.FrmNhanVien
{
    partial class frmNhanVienMain
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
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.lblTienThanhToan = new System.Windows.Forms.Label();
            this.nudTienGiam = new System.Windows.Forms.NumericUpDown();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.tabDonHang = new System.Windows.Forms.TabPage();
            this.btnCapNhatTrangThai = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnTaoDonHang = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.tabBan = new System.Windows.Forms.TabPage();
            this.btnHuyDatBan = new System.Windows.Forms.Button();
            this.btnCapNhatBan = new System.Windows.Forms.Button();
            this.cboTrangThaiBan = new System.Windows.Forms.ComboBox();
            this.dgvBan = new System.Windows.Forms.DataGridView();
            this.lvMonAnNV = new System.Windows.Forms.ListView();
            this.pnlDanhMucNV = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnMonCom = new System.Windows.Forms.Button();
            this.btnMonCanh = new System.Windows.Forms.Button();
            this.btnMonThem = new System.Windows.Forms.Button();
            this.btnGiaiKhat = new System.Windows.Forms.Button();
            this.tabThucDon = new System.Windows.Forms.TabPage();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pnlHeader.SuspendLayout();
            this.tabThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTienGiam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.tabDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.tabBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
            this.pnlDanhMucNV.SuspendLayout();
            this.tabThucDon.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(741, 22);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(181, 34);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Dang Xuat";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Location = new System.Drawing.Point(16, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(963, 76);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(26, 31);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(107, 16);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Nhan Vien: [Ten]";
            // 
            // tabThanhToan
            // 
            this.tabThanhToan.Controls.Add(this.lblMaDon);
            this.tabThanhToan.Controls.Add(this.btnThanhToan);
            this.tabThanhToan.Controls.Add(this.txtGhiChu);
            this.tabThanhToan.Controls.Add(this.cboPhuongThuc);
            this.tabThanhToan.Controls.Add(this.lblTienThanhToan);
            this.tabThanhToan.Controls.Add(this.nudTienGiam);
            this.tabThanhToan.Controls.Add(this.lblTongTien);
            this.tabThanhToan.Location = new System.Drawing.Point(4, 25);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Padding = new System.Windows.Forms.Padding(3);
            this.tabThanhToan.Size = new System.Drawing.Size(964, 409);
            this.tabThanhToan.TabIndex = 2;
            this.tabThanhToan.Text = "Thanh Toan";
            this.tabThanhToan.UseVisualStyleBackColor = true;
            // 
            // lblMaDon
            // 
            this.lblMaDon.AutoSize = true;
            this.lblMaDon.Location = new System.Drawing.Point(452, 20);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(73, 16);
            this.lblMaDon.TabIndex = 5;
            this.lblMaDon.Text = "Mã đơn: [n]";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(507, 281);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(181, 34);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh Toan";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(269, 201);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(419, 22);
            this.txtGhiChu.TabIndex = 4;
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.FormattingEnabled = true;
            this.cboPhuongThuc.Location = new System.Drawing.Point(486, 124);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(202, 24);
            this.cboPhuongThuc.TabIndex = 3;
            // 
            // lblTienThanhToan
            // 
            this.lblTienThanhToan.AutoSize = true;
            this.lblTienThanhToan.Location = new System.Drawing.Point(266, 125);
            this.lblTienThanhToan.Name = "lblTienThanhToan";
            this.lblTienThanhToan.Size = new System.Drawing.Size(110, 16);
            this.lblTienThanhToan.TabIndex = 2;
            this.lblTienThanhToan.Text = "Tien Thanh Toan";
            // 
            // nudTienGiam
            // 
            this.nudTienGiam.Location = new System.Drawing.Point(486, 60);
            this.nudTienGiam.Name = "nudTienGiam";
            this.nudTienGiam.Size = new System.Drawing.Size(202, 22);
            this.nudTienGiam.TabIndex = 1;
            this.nudTienGiam.ValueChanged += new System.EventHandler(this.nudTienGiam_ValueChanged);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(266, 60);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(75, 16);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tong Tien :";
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHang.Location = new System.Drawing.Point(6, 6);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.RowHeadersWidth = 51;
            this.dgvDonHang.RowTemplate.Height = 24;
            this.dgvDonHang.Size = new System.Drawing.Size(576, 177);
            this.dgvDonHang.TabIndex = 0;
            // 
            // tabDonHang
            // 
            this.tabDonHang.Controls.Add(this.btnCapNhatTrangThai);
            this.tabDonHang.Controls.Add(this.btnXoaMon);
            this.tabDonHang.Controls.Add(this.btnThemMon);
            this.tabDonHang.Controls.Add(this.btnTaoDonHang);
            this.tabDonHang.Controls.Add(this.dgvChiTiet);
            this.tabDonHang.Controls.Add(this.dgvDonHang);
            this.tabDonHang.Location = new System.Drawing.Point(4, 25);
            this.tabDonHang.Name = "tabDonHang";
            this.tabDonHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabDonHang.Size = new System.Drawing.Size(964, 409);
            this.tabDonHang.TabIndex = 1;
            this.tabDonHang.Text = "DonHang";
            this.tabDonHang.UseVisualStyleBackColor = true;
            // 
            // btnCapNhatTrangThai
            // 
            this.btnCapNhatTrangThai.Location = new System.Drawing.Point(741, 126);
            this.btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
            this.btnCapNhatTrangThai.Size = new System.Drawing.Size(181, 34);
            this.btnCapNhatTrangThai.TabIndex = 5;
            this.btnCapNhatTrangThai.Text = "Cap Nhat Trang Thai";
            this.btnCapNhatTrangThai.UseVisualStyleBackColor = true;
            this.btnCapNhatTrangThai.Click += new System.EventHandler(this.btnCapNhatTrangThai_Click);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Location = new System.Drawing.Point(741, 86);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(181, 34);
            this.btnXoaMon.TabIndex = 4;
            this.btnXoaMon.Text = "Xoa Mon";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(741, 46);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(181, 34);
            this.btnThemMon.TabIndex = 3;
            this.btnThemMon.Text = "Them Mon";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // btnTaoDonHang
            // 
            this.btnTaoDonHang.Location = new System.Drawing.Point(741, 6);
            this.btnTaoDonHang.Name = "btnTaoDonHang";
            this.btnTaoDonHang.Size = new System.Drawing.Size(181, 34);
            this.btnTaoDonHang.TabIndex = 2;
            this.btnTaoDonHang.Text = "Tao Don Hang";
            this.btnTaoDonHang.UseVisualStyleBackColor = true;
            this.btnTaoDonHang.Click += new System.EventHandler(this.btnTaoDonHang_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(6, 226);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 24;
            this.dgvChiTiet.Size = new System.Drawing.Size(576, 177);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // tabBan
            // 
            this.tabBan.Controls.Add(this.btnHuyDatBan);
            this.tabBan.Controls.Add(this.btnCapNhatBan);
            this.tabBan.Controls.Add(this.cboTrangThaiBan);
            this.tabBan.Controls.Add(this.dgvBan);
            this.tabBan.Location = new System.Drawing.Point(4, 25);
            this.tabBan.Name = "tabBan";
            this.tabBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabBan.Size = new System.Drawing.Size(964, 409);
            this.tabBan.TabIndex = 3;
            this.tabBan.Text = "Quan Ly Ban";
            this.tabBan.UseVisualStyleBackColor = true;
            // 
            // btnHuyDatBan
            // 
            this.btnHuyDatBan.Location = new System.Drawing.Point(741, 144);
            this.btnHuyDatBan.Name = "btnHuyDatBan";
            this.btnHuyDatBan.Size = new System.Drawing.Size(181, 34);
            this.btnHuyDatBan.TabIndex = 3;
            this.btnHuyDatBan.Text = "Huy Dat Ban";
            this.btnHuyDatBan.UseVisualStyleBackColor = true;
            this.btnHuyDatBan.Click += new System.EventHandler(this.btnHuyDatBan_Click);
            // 
            // btnCapNhatBan
            // 
            this.btnCapNhatBan.Location = new System.Drawing.Point(741, 86);
            this.btnCapNhatBan.Name = "btnCapNhatBan";
            this.btnCapNhatBan.Size = new System.Drawing.Size(181, 34);
            this.btnCapNhatBan.TabIndex = 2;
            this.btnCapNhatBan.Text = "Cap Nhat Ban";
            this.btnCapNhatBan.UseVisualStyleBackColor = true;
            this.btnCapNhatBan.Click += new System.EventHandler(this.btnCapNhatBan_Click);
            // 
            // cboTrangThaiBan
            // 
            this.cboTrangThaiBan.FormattingEnabled = true;
            this.cboTrangThaiBan.Location = new System.Drawing.Point(741, 26);
            this.cboTrangThaiBan.Name = "cboTrangThaiBan";
            this.cboTrangThaiBan.Size = new System.Drawing.Size(181, 24);
            this.cboTrangThaiBan.TabIndex = 1;
            // 
            // dgvBan
            // 
            this.dgvBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBan.Location = new System.Drawing.Point(33, 26);
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.RowHeadersWidth = 51;
            this.dgvBan.RowTemplate.Height = 24;
            this.dgvBan.Size = new System.Drawing.Size(599, 364);
            this.dgvBan.TabIndex = 0;
            this.dgvBan.SelectionChanged += new System.EventHandler(this.dgvBan_SelectionChanged);
            // 
            // lvMonAnNV
            // 
            this.lvMonAnNV.HideSelection = false;
            this.lvMonAnNV.Location = new System.Drawing.Point(6, 101);
            this.lvMonAnNV.Name = "lvMonAnNV";
            this.lvMonAnNV.Size = new System.Drawing.Size(952, 302);
            this.lvMonAnNV.TabIndex = 0;
            this.lvMonAnNV.UseCompatibleStateImageBehavior = false;
            // 
            // pnlDanhMucNV
            // 
            this.pnlDanhMucNV.Controls.Add(this.btnTatCa);
            this.pnlDanhMucNV.Controls.Add(this.btnMonCom);
            this.pnlDanhMucNV.Controls.Add(this.btnMonCanh);
            this.pnlDanhMucNV.Controls.Add(this.btnMonThem);
            this.pnlDanhMucNV.Controls.Add(this.btnGiaiKhat);
            this.pnlDanhMucNV.Location = new System.Drawing.Point(6, 7);
            this.pnlDanhMucNV.Name = "pnlDanhMucNV";
            this.pnlDanhMucNV.Size = new System.Drawing.Size(951, 88);
            this.pnlDanhMucNV.TabIndex = 1;
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(3, 3);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(149, 67);
            this.btnTatCa.TabIndex = 5;
            this.btnTatCa.Text = "Tat Ca";
            this.btnTatCa.UseVisualStyleBackColor = true;
            // 
            // btnMonCom
            // 
            this.btnMonCom.Location = new System.Drawing.Point(158, 3);
            this.btnMonCom.Name = "btnMonCom";
            this.btnMonCom.Size = new System.Drawing.Size(149, 67);
            this.btnMonCom.TabIndex = 6;
            this.btnMonCom.Text = "Mon Com";
            this.btnMonCom.UseVisualStyleBackColor = true;
            // 
            // btnMonCanh
            // 
            this.btnMonCanh.Location = new System.Drawing.Point(313, 3);
            this.btnMonCanh.Name = "btnMonCanh";
            this.btnMonCanh.Size = new System.Drawing.Size(149, 67);
            this.btnMonCanh.TabIndex = 7;
            this.btnMonCanh.Text = "Mon Canh";
            this.btnMonCanh.UseVisualStyleBackColor = true;
            // 
            // btnMonThem
            // 
            this.btnMonThem.Location = new System.Drawing.Point(468, 3);
            this.btnMonThem.Name = "btnMonThem";
            this.btnMonThem.Size = new System.Drawing.Size(149, 67);
            this.btnMonThem.TabIndex = 8;
            this.btnMonThem.Text = "Mon Them";
            this.btnMonThem.UseVisualStyleBackColor = true;
            // 
            // btnGiaiKhat
            // 
            this.btnGiaiKhat.Location = new System.Drawing.Point(623, 3);
            this.btnGiaiKhat.Name = "btnGiaiKhat";
            this.btnGiaiKhat.Size = new System.Drawing.Size(149, 67);
            this.btnGiaiKhat.TabIndex = 9;
            this.btnGiaiKhat.Text = "Giai Khat";
            this.btnGiaiKhat.UseVisualStyleBackColor = true;
            // 
            // tabThucDon
            // 
            this.tabThucDon.Controls.Add(this.pnlDanhMucNV);
            this.tabThucDon.Controls.Add(this.lvMonAnNV);
            this.tabThucDon.Location = new System.Drawing.Point(4, 25);
            this.tabThucDon.Name = "tabThucDon";
            this.tabThucDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabThucDon.Size = new System.Drawing.Size(964, 409);
            this.tabThucDon.TabIndex = 0;
            this.tabThucDon.Text = "Thuc Don";
            this.tabThucDon.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabThucDon);
            this.tabMain.Controls.Add(this.tabBan);
            this.tabMain.Controls.Add(this.tabDonHang);
            this.tabMain.Controls.Add(this.tabThanhToan);
            this.tabMain.Location = new System.Drawing.Point(12, 88);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(972, 438);
            this.tabMain.TabIndex = 2;
            // 
            // frmNhanVienMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 538);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tabMain);
            this.Name = "frmNhanVienMain";
            this.Text = "frmNhanVienMain";
            this.Load += new System.EventHandler(this.frmNhanVienMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabThanhToan.ResumeLayout(false);
            this.tabThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTienGiam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.tabDonHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.tabBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
            this.pnlDanhMucNV.ResumeLayout(false);
            this.tabThucDon.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.TabPage tabThanhToan;
        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.TabPage tabDonHang;
        private System.Windows.Forms.TabPage tabBan;
        private System.Windows.Forms.Button btnHuyDatBan;
        private System.Windows.Forms.Button btnCapNhatBan;
        private System.Windows.Forms.ComboBox cboTrangThaiBan;
        private System.Windows.Forms.DataGridView dgvBan;
        private System.Windows.Forms.ListView lvMonAnNV;
        private System.Windows.Forms.FlowLayoutPanel pnlDanhMucNV;
        private System.Windows.Forms.TabPage tabThucDon;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button btnCapNhatTrangThai;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnTaoDonHang;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblTienThanhToan;
        private System.Windows.Forms.NumericUpDown nudTienGiam;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.Button btnMonCom;
        private System.Windows.Forms.Button btnMonCanh;
        private System.Windows.Forms.Button btnMonThem;
        private System.Windows.Forms.Button btnGiaiKhat;
    }
}