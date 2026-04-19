namespace QuanLyNhaHang.Interface_layer.Admin
{
    partial class frmAdminMain
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
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.dgvMonBanChay = new System.Windows.Forms.DataGridView();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTaiKhoan = new System.Windows.Forms.TabPage();
            this.btnKhoaMo = new System.Windows.Forms.Button();
            this.btnDoiVaiTro = new System.Windows.Forms.Button();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.tabMonAn = new System.Windows.Forms.TabPage();
            this.btnBatTatConHang = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnSuaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.tabDanhMuc = new System.Windows.Forms.TabPage();
            this.btnThemDanhMuc = new System.Windows.Forms.Button();
            this.btnXoaDanhMuc = new System.Windows.Forms.Button();
            this.btnSuaDanhMuc = new System.Windows.Forms.Button();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.tabBan = new System.Windows.Forms.TabPage();
            this.btnXoaBan = new System.Windows.Forms.Button();
            this.btnSuaBan = new System.Windows.Forms.Button();
            this.btnThemBan = new System.Windows.Forms.Button();
            this.dgvBanAdmin = new System.Windows.Forms.DataGridView();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pBAVT = new System.Windows.Forms.PictureBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.ofdAvatar = new System.Windows.Forms.OpenFileDialog();
            this.tabMain.SuspendLayout();
            this.tabBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonBanChay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.tabTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.tabMonAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.tabDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.tabBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanAdmin)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBAVT)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabBaoCao);
            this.tabMain.Controls.Add(this.tabTaiKhoan);
            this.tabMain.Controls.Add(this.tabMonAn);
            this.tabMain.Controls.Add(this.tabDanhMuc);
            this.tabMain.Controls.Add(this.tabBan);
            this.tabMain.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabMain.Location = new System.Drawing.Point(16, 107);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(968, 484);
            this.tabMain.TabIndex = 4;
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.lblTongDoanhThu);
            this.tabBaoCao.Controls.Add(this.dgvMonBanChay);
            this.tabBaoCao.Controls.Add(this.dgvBaoCao);
            this.tabBaoCao.Controls.Add(this.btnXemBaoCao);
            this.tabBaoCao.Controls.Add(this.dtpDenNgay);
            this.tabBaoCao.Controls.Add(this.dtpTuNgay);
            this.tabBaoCao.Controls.Add(this.label2);
            this.tabBaoCao.Controls.Add(this.label1);
            this.tabBaoCao.Location = new System.Drawing.Point(4, 28);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao.Size = new System.Drawing.Size(960, 452);
            this.tabBaoCao.TabIndex = 0;
            this.tabBaoCao.Text = "Báo Cáo";
            this.tabBaoCao.UseVisualStyleBackColor = true;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(690, 284);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(139, 19);
            this.lblTongDoanhThu.TabIndex = 6;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0đ";
            // 
            // dgvMonBanChay
            // 
            this.dgvMonBanChay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonBanChay.Location = new System.Drawing.Point(20, 284);
            this.dgvMonBanChay.Name = "dgvMonBanChay";
            this.dgvMonBanChay.ReadOnly = true;
            this.dgvMonBanChay.RowHeadersWidth = 51;
            this.dgvMonBanChay.RowTemplate.Height = 24;
            this.dgvMonBanChay.Size = new System.Drawing.Size(591, 132);
            this.dgvMonBanChay.TabIndex = 5;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(20, 77);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 24;
            this.dgvBaoCao.Size = new System.Drawing.Size(898, 186);
            this.dgvBaoCao.TabIndex = 4;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(741, 25);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(181, 34);
            this.btnXemBaoCao.TabIndex = 2;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(346, 29);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(125, 27);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(101, 29);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(125, 27);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.btnKhoaMo);
            this.tabTaiKhoan.Controls.Add(this.btnDoiVaiTro);
            this.tabTaiKhoan.Controls.Add(this.cboVaiTro);
            this.tabTaiKhoan.Controls.Add(this.label3);
            this.tabTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.tabTaiKhoan.Location = new System.Drawing.Point(4, 28);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaiKhoan.Size = new System.Drawing.Size(960, 452);
            this.tabTaiKhoan.TabIndex = 3;
            this.tabTaiKhoan.Text = "Tài Khoản";
            this.tabTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // btnKhoaMo
            // 
            this.btnKhoaMo.Location = new System.Drawing.Point(746, 152);
            this.btnKhoaMo.Name = "btnKhoaMo";
            this.btnKhoaMo.Size = new System.Drawing.Size(175, 34);
            this.btnKhoaMo.TabIndex = 3;
            this.btnKhoaMo.Text = "Khoá / Mở";
            this.btnKhoaMo.UseVisualStyleBackColor = true;
            this.btnKhoaMo.Click += new System.EventHandler(this.btnKhoaMo_Click);
            // 
            // btnDoiVaiTro
            // 
            this.btnDoiVaiTro.Location = new System.Drawing.Point(746, 84);
            this.btnDoiVaiTro.Name = "btnDoiVaiTro";
            this.btnDoiVaiTro.Size = new System.Drawing.Size(175, 34);
            this.btnDoiVaiTro.TabIndex = 2;
            this.btnDoiVaiTro.Text = "Đổi vai trò";
            this.btnDoiVaiTro.UseVisualStyleBackColor = true;
            this.btnDoiVaiTro.Click += new System.EventHandler(this.btnDoiVaiTro_Click);
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(746, 23);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(175, 27);
            this.cboVaiTro.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vai trò:";
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(34, 25);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(545, 359);
            this.dgvTaiKhoan.TabIndex = 0;
            this.dgvTaiKhoan.SelectionChanged += new System.EventHandler(this.dgvTaiKhoan_SelectionChanged);
            // 
            // tabMonAn
            // 
            this.tabMonAn.Controls.Add(this.btnBatTatConHang);
            this.tabMonAn.Controls.Add(this.btnXoaMon);
            this.tabMonAn.Controls.Add(this.btnSuaMon);
            this.tabMonAn.Controls.Add(this.btnThemMon);
            this.tabMonAn.Controls.Add(this.dgvMonAn);
            this.tabMonAn.Location = new System.Drawing.Point(4, 28);
            this.tabMonAn.Name = "tabMonAn";
            this.tabMonAn.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonAn.Size = new System.Drawing.Size(960, 452);
            this.tabMonAn.TabIndex = 1;
            this.tabMonAn.Text = "Món Ăn";
            this.tabMonAn.UseVisualStyleBackColor = true;
            // 
            // btnBatTatConHang
            // 
            this.btnBatTatConHang.Location = new System.Drawing.Point(741, 232);
            this.btnBatTatConHang.Name = "btnBatTatConHang";
            this.btnBatTatConHang.Size = new System.Drawing.Size(181, 34);
            this.btnBatTatConHang.TabIndex = 5;
            this.btnBatTatConHang.Text = "Bật/Tắt còn hàng";
            this.btnBatTatConHang.UseVisualStyleBackColor = true;
            this.btnBatTatConHang.Click += new System.EventHandler(this.btnBatTatConHang_Click);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Location = new System.Drawing.Point(741, 165);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(181, 34);
            this.btnXoaMon.TabIndex = 4;
            this.btnXoaMon.Text = "Xóa";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnSuaMon
            // 
            this.btnSuaMon.Location = new System.Drawing.Point(741, 96);
            this.btnSuaMon.Name = "btnSuaMon";
            this.btnSuaMon.Size = new System.Drawing.Size(181, 34);
            this.btnSuaMon.TabIndex = 3;
            this.btnSuaMon.Text = "Sửa";
            this.btnSuaMon.UseVisualStyleBackColor = true;
            this.btnSuaMon.Click += new System.EventHandler(this.btnSuaMon_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(741, 26);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(181, 34);
            this.btnThemMon.TabIndex = 2;
            this.btnThemMon.Text = "Thêm";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Location = new System.Drawing.Point(29, 26);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.RowTemplate.Height = 24;
            this.dgvMonAn.Size = new System.Drawing.Size(545, 359);
            this.dgvMonAn.TabIndex = 1;
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.btnThemDanhMuc);
            this.tabDanhMuc.Controls.Add(this.btnXoaDanhMuc);
            this.tabDanhMuc.Controls.Add(this.btnSuaDanhMuc);
            this.tabDanhMuc.Controls.Add(this.dgvDanhMuc);
            this.tabDanhMuc.Location = new System.Drawing.Point(4, 28);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDanhMuc.Size = new System.Drawing.Size(960, 452);
            this.tabDanhMuc.TabIndex = 2;
            this.tabDanhMuc.Text = "Danh Mục";
            this.tabDanhMuc.UseVisualStyleBackColor = true;
            // 
            // btnThemDanhMuc
            // 
            this.btnThemDanhMuc.Location = new System.Drawing.Point(741, 26);
            this.btnThemDanhMuc.Name = "btnThemDanhMuc";
            this.btnThemDanhMuc.Size = new System.Drawing.Size(181, 34);
            this.btnThemDanhMuc.TabIndex = 5;
            this.btnThemDanhMuc.Text = "Thêm danh mục";
            this.btnThemDanhMuc.UseVisualStyleBackColor = true;
            this.btnThemDanhMuc.Click += new System.EventHandler(this.btnThemDanhMuc_Click);
            // 
            // btnXoaDanhMuc
            // 
            this.btnXoaDanhMuc.Location = new System.Drawing.Point(741, 170);
            this.btnXoaDanhMuc.Name = "btnXoaDanhMuc";
            this.btnXoaDanhMuc.Size = new System.Drawing.Size(181, 34);
            this.btnXoaDanhMuc.TabIndex = 4;
            this.btnXoaDanhMuc.Text = "Xóa";
            this.btnXoaDanhMuc.UseVisualStyleBackColor = true;
            this.btnXoaDanhMuc.Click += new System.EventHandler(this.btnXoaDanhMuc_Click);
            // 
            // btnSuaDanhMuc
            // 
            this.btnSuaDanhMuc.Location = new System.Drawing.Point(741, 100);
            this.btnSuaDanhMuc.Name = "btnSuaDanhMuc";
            this.btnSuaDanhMuc.Size = new System.Drawing.Size(181, 34);
            this.btnSuaDanhMuc.TabIndex = 3;
            this.btnSuaDanhMuc.Text = "Sửa";
            this.btnSuaDanhMuc.UseVisualStyleBackColor = true;
            this.btnSuaDanhMuc.Click += new System.EventHandler(this.btnSuaDanhMuc_Click);
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhMuc.Location = new System.Drawing.Point(29, 26);
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersWidth = 51;
            this.dgvDanhMuc.RowTemplate.Height = 24;
            this.dgvDanhMuc.Size = new System.Drawing.Size(545, 359);
            this.dgvDanhMuc.TabIndex = 2;
            // 
            // tabBan
            // 
            this.tabBan.Controls.Add(this.btnXoaBan);
            this.tabBan.Controls.Add(this.btnSuaBan);
            this.tabBan.Controls.Add(this.btnThemBan);
            this.tabBan.Controls.Add(this.dgvBanAdmin);
            this.tabBan.Location = new System.Drawing.Point(4, 28);
            this.tabBan.Name = "tabBan";
            this.tabBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabBan.Size = new System.Drawing.Size(960, 452);
            this.tabBan.TabIndex = 4;
            this.tabBan.Text = "Bàn";
            this.tabBan.UseVisualStyleBackColor = true;
            // 
            // btnXoaBan
            // 
            this.btnXoaBan.Location = new System.Drawing.Point(741, 169);
            this.btnXoaBan.Name = "btnXoaBan";
            this.btnXoaBan.Size = new System.Drawing.Size(181, 34);
            this.btnXoaBan.TabIndex = 7;
            this.btnXoaBan.Text = "Xóa";
            this.btnXoaBan.UseVisualStyleBackColor = true;
            this.btnXoaBan.Click += new System.EventHandler(this.btnXoaBan_Click);
            // 
            // btnSuaBan
            // 
            this.btnSuaBan.Location = new System.Drawing.Point(741, 99);
            this.btnSuaBan.Name = "btnSuaBan";
            this.btnSuaBan.Size = new System.Drawing.Size(181, 34);
            this.btnSuaBan.TabIndex = 6;
            this.btnSuaBan.Text = "Sửa";
            this.btnSuaBan.UseVisualStyleBackColor = true;
            this.btnSuaBan.Click += new System.EventHandler(this.btnSuaBan_Click);
            // 
            // btnThemBan
            // 
            this.btnThemBan.Location = new System.Drawing.Point(741, 25);
            this.btnThemBan.Name = "btnThemBan";
            this.btnThemBan.Size = new System.Drawing.Size(181, 34);
            this.btnThemBan.TabIndex = 5;
            this.btnThemBan.Text = "Thêm";
            this.btnThemBan.UseVisualStyleBackColor = true;
            this.btnThemBan.Click += new System.EventHandler(this.btnThemBan_Click);
            // 
            // dgvBanAdmin
            // 
            this.dgvBanAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanAdmin.Location = new System.Drawing.Point(29, 25);
            this.dgvBanAdmin.Name = "dgvBanAdmin";
            this.dgvBanAdmin.ReadOnly = true;
            this.dgvBanAdmin.RowHeadersWidth = 51;
            this.dgvBanAdmin.RowTemplate.Height = 24;
            this.dgvBanAdmin.Size = new System.Drawing.Size(545, 359);
            this.dgvBanAdmin.TabIndex = 3;
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(120, 7);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(105, 19);
            this.lblAdmin.TabIndex = 0;
            this.lblAdmin.Text = "Tên       : [Ten]";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pBAVT);
            this.pnlHeader.Controls.Add(this.lblID);
            this.pnlHeader.Controls.Add(this.lblVaiTro);
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblAdmin);
            this.pnlHeader.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlHeader.Location = new System.Drawing.Point(16, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(964, 89);
            this.pnlHeader.TabIndex = 5;
            // 
            // pBAVT
            // 
            this.pBAVT.Location = new System.Drawing.Point(21, 4);
            this.pBAVT.Name = "pBAVT";
            this.pBAVT.Size = new System.Drawing.Size(80, 80);
            this.pBAVT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBAVT.TabIndex = 4;
            this.pBAVT.TabStop = false;
            this.pBAVT.Click += new System.EventHandler(this.pBAVT_Click);
            this.pBAVT.Paint += new System.Windows.Forms.PaintEventHandler(this.pBAVT_Paint);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(120, 66);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(98, 19);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID         : [ID]";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(120, 36);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(125, 19);
            this.lblVaiTro.TabIndex = 2;
            this.lblVaiTro.Text = "Vai trò  : [VaiTro]";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(741, 22);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(181, 34);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // ofdAvatar
            // 
            this.ofdAvatar.FileName = "openFileDialog1";
            // 
            // frmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 603);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminMain";
            this.Load += new System.EventHandler(this.frmAdminMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabBaoCao.ResumeLayout(false);
            this.tabBaoCao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonBanChay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.tabTaiKhoan.ResumeLayout(false);
            this.tabTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.tabMonAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.tabDanhMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.tabBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanAdmin)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBAVT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabBaoCao;
        private System.Windows.Forms.TabPage tabTaiKhoan;
        private System.Windows.Forms.TabPage tabMonAn;
        private System.Windows.Forms.TabPage tabDanhMuc;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.TabPage tabBan;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.DataGridView dgvMonBanChay;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Button btnKhoaMo;
        private System.Windows.Forms.Button btnDoiVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.Button btnBatTatConHang;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnSuaMon;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnXoaDanhMuc;
        private System.Windows.Forms.Button btnSuaDanhMuc;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.Button btnXoaBan;
        private System.Windows.Forms.Button btnSuaBan;
        private System.Windows.Forms.Button btnThemBan;
        private System.Windows.Forms.DataGridView dgvBanAdmin;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Button btnThemDanhMuc;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox pBAVT;
        private System.Windows.Forms.OpenFileDialog ofdAvatar;
    }
}