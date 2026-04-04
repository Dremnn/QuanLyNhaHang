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
            this.lvMonAn = new System.Windows.Forms.ListView();
            this.tabDatBan = new System.Windows.Forms.TabPage();
            this.btnDatBan = new System.Windows.Forms.Button();
            this.lblThongTinBan = new System.Windows.Forms.Label();
            this.lbDanhSachBan = new System.Windows.Forms.ListBox();
            this.lblChonBan = new System.Windows.Forms.Label();
            this.tabLichSu = new System.Windows.Forms.TabPage();
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
            this.btnHuyDatBan = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabThucDon.SuspendLayout();
            this.tabDatBan.SuspendLayout();
            this.tabLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.tabThongTin.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabThucDon);
            this.tabMain.Controls.Add(this.tabDatBan);
            this.tabMain.Controls.Add(this.tabLichSu);
            this.tabMain.Controls.Add(this.tabThongTin);
            this.tabMain.Location = new System.Drawing.Point(12, 88);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(972, 438);
            this.tabMain.TabIndex = 0;
            // 
            // tabThucDon
            // 
            this.tabThucDon.Controls.Add(this.pnlDanhMuc);
            this.tabThucDon.Controls.Add(this.lvMonAn);
            this.tabThucDon.Location = new System.Drawing.Point(4, 25);
            this.tabThucDon.Name = "tabThucDon";
            this.tabThucDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabThucDon.Size = new System.Drawing.Size(964, 409);
            this.tabThucDon.TabIndex = 0;
            this.tabThucDon.Text = "Thuc Don";
            this.tabThucDon.UseVisualStyleBackColor = true;
            // 
            // pnlDanhMuc
            // 
            this.pnlDanhMuc.Location = new System.Drawing.Point(6, 7);
            this.pnlDanhMuc.Name = "pnlDanhMuc";
            this.pnlDanhMuc.Size = new System.Drawing.Size(951, 88);
            this.pnlDanhMuc.TabIndex = 1;
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
            this.tabDatBan.Location = new System.Drawing.Point(4, 25);
            this.tabDatBan.Name = "tabDatBan";
            this.tabDatBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatBan.Size = new System.Drawing.Size(964, 409);
            this.tabDatBan.TabIndex = 3;
            this.tabDatBan.Text = "Dat Ban";
            this.tabDatBan.UseVisualStyleBackColor = true;
            // 
            // btnDatBan
            // 
            this.btnDatBan.Location = new System.Drawing.Point(741, 49);
            this.btnDatBan.Name = "btnDatBan";
            this.btnDatBan.Size = new System.Drawing.Size(181, 34);
            this.btnDatBan.TabIndex = 2;
            this.btnDatBan.Text = "Dat Ban";
            this.btnDatBan.UseVisualStyleBackColor = true;
            this.btnDatBan.Click += new System.EventHandler(this.btnDatBan_Click);
            // 
            // lblThongTinBan
            // 
            this.lblThongTinBan.AutoSize = true;
            this.lblThongTinBan.Location = new System.Drawing.Point(186, 99);
            this.lblThongTinBan.Name = "lblThongTinBan";
            this.lblThongTinBan.Size = new System.Drawing.Size(94, 16);
            this.lblThongTinBan.TabIndex = 2;
            this.lblThongTinBan.Text = "Thong tin ban :";
            // 
            // lbDanhSachBan
            // 
            this.lbDanhSachBan.FormattingEnabled = true;
            this.lbDanhSachBan.ItemHeight = 16;
            this.lbDanhSachBan.Location = new System.Drawing.Point(324, 49);
            this.lbDanhSachBan.Name = "lbDanhSachBan";
            this.lbDanhSachBan.Size = new System.Drawing.Size(281, 324);
            this.lbDanhSachBan.TabIndex = 1;
            this.lbDanhSachBan.SelectedIndexChanged += new System.EventHandler(this.lbDanhSachBan_SelectedIndexChanged);
            // 
            // lblChonBan
            // 
            this.lblChonBan.AutoSize = true;
            this.lblChonBan.Location = new System.Drawing.Point(186, 49);
            this.lblChonBan.Name = "lblChonBan";
            this.lblChonBan.Size = new System.Drawing.Size(100, 16);
            this.lblChonBan.TabIndex = 0;
            this.lblChonBan.Text = "Chọn bàn trống:";
            // 
            // tabLichSu
            // 
            this.tabLichSu.Controls.Add(this.btnHuyDatBan);
            this.tabLichSu.Controls.Add(this.dgvDonHang);
            this.tabLichSu.Location = new System.Drawing.Point(4, 25);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Padding = new System.Windows.Forms.Padding(3);
            this.tabLichSu.Size = new System.Drawing.Size(964, 409);
            this.tabLichSu.TabIndex = 1;
            this.tabLichSu.Text = "Lich Su Don";
            this.tabLichSu.UseVisualStyleBackColor = true;
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
            this.tabThongTin.Controls.Add(this.btnCapNhat);
            this.tabThongTin.Controls.Add(this.txtEmail);
            this.tabThongTin.Controls.Add(this.label5);
            this.tabThongTin.Controls.Add(this.txtDiaChi);
            this.tabThongTin.Controls.Add(this.label4);
            this.tabThongTin.Controls.Add(this.txtSoDienThoai);
            this.tabThongTin.Controls.Add(this.label3);
            this.tabThongTin.Controls.Add(this.txtHoTen);
            this.tabThongTin.Controls.Add(this.label2);
            this.tabThongTin.Location = new System.Drawing.Point(4, 25);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTin.Size = new System.Drawing.Size(964, 409);
            this.tabThongTin.TabIndex = 2;
            this.tabThongTin.Text = "Thong Tin";
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
            this.txtEmail.Size = new System.Drawing.Size(254, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(468, 140);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(254, 22);
            this.txtDiaChi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dia Chi";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(468, 96);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(254, 22);
            this.txtSoDienThoai.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "So Dien Thoai";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(468, 50);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(254, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ho Ten";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblChaoMung);
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
            this.btnDangXuat.Text = "Dang Xuat";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblChaoMung
            // 
            this.lblChaoMung.AutoSize = true;
            this.lblChaoMung.Location = new System.Drawing.Point(26, 31);
            this.lblChaoMung.Name = "lblChaoMung";
            this.lblChaoMung.Size = new System.Drawing.Size(116, 16);
            this.lblChaoMung.TabIndex = 0;
            this.lblChaoMung.Text = "Chao Mung , [Ten]";
            // 
            // btnHuyDatBan
            // 
            this.btnHuyDatBan.Location = new System.Drawing.Point(741, 355);
            this.btnHuyDatBan.Name = "btnHuyDatBan";
            this.btnHuyDatBan.Size = new System.Drawing.Size(181, 34);
            this.btnHuyDatBan.TabIndex = 2;
            this.btnHuyDatBan.Text = "Huy Dat Ban";
            this.btnHuyDatBan.UseVisualStyleBackColor = true;
            this.btnHuyDatBan.Click += new System.EventHandler(this.btnHuyDatBan_Click);
            // 
            // frmKhachHangMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 538);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tabMain);
            this.Name = "frmKhachHangMain";
            this.Text = "frmKhachHangMain";
            this.Load += new System.EventHandler(this.frmKhachHangMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabThucDon.ResumeLayout(false);
            this.tabDatBan.ResumeLayout(false);
            this.tabDatBan.PerformLayout();
            this.tabLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
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
    }
}