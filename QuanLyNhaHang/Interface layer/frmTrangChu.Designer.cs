namespace QuanLyNhaHang.Interface_layer
{
    partial class frmTrangChu
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
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.lblTenQuan = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabThucDon = new System.Windows.Forms.TabPage();
            this.lvMonAn = new System.Windows.Forms.ListView();
            this.pnlDanhMuc = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnMonCom = new System.Windows.Forms.Button();
            this.btnMonCanh = new System.Windows.Forms.Button();
            this.btnMonThem = new System.Windows.Forms.Button();
            this.btnGiaiKhat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabThucDon.SuspendLayout();
            this.pnlDanhMuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBanner
            // 
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(996, 538);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBanner.TabIndex = 0;
            this.picBanner.TabStop = false;
            // 
            // lblTenQuan
            // 
            this.lblTenQuan.AutoSize = true;
            this.lblTenQuan.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenQuan.Location = new System.Drawing.Point(324, 23);
            this.lblTenQuan.Name = "lblTenQuan";
            this.lblTenQuan.Size = new System.Drawing.Size(383, 67);
            this.lblTenQuan.TabIndex = 1;
            this.lblTenQuan.Text = "Sà Bì Chưởng";
            this.lblTenQuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabThucDon);
            this.tabMain.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabMain.Location = new System.Drawing.Point(12, 88);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(972, 438);
            this.tabMain.TabIndex = 2;
            // 
            // tabThucDon
            // 
            this.tabThucDon.Controls.Add(this.pnlDanhMuc);
            this.tabThucDon.Location = new System.Drawing.Point(4, 28);
            this.tabThucDon.Name = "tabThucDon";
            this.tabThucDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabThucDon.Size = new System.Drawing.Size(964, 406);
            this.tabThucDon.TabIndex = 0;
            this.tabThucDon.Text = "Thực Đơn";
            this.tabThucDon.UseVisualStyleBackColor = true;
            // 
            // lvMonAn
            // 
            this.lvMonAn.HideSelection = false;
            this.lvMonAn.Location = new System.Drawing.Point(3, 76);
            this.lvMonAn.Name = "lvMonAn";
            this.lvMonAn.Size = new System.Drawing.Size(952, 320);
            this.lvMonAn.TabIndex = 3;
            this.lvMonAn.UseCompatibleStateImageBehavior = false;
            // 
            // pnlDanhMuc
            // 
            this.pnlDanhMuc.Controls.Add(this.btnTatCa);
            this.pnlDanhMuc.Controls.Add(this.btnMonCom);
            this.pnlDanhMuc.Controls.Add(this.btnMonCanh);
            this.pnlDanhMuc.Controls.Add(this.lvMonAn);
            this.pnlDanhMuc.Controls.Add(this.btnMonThem);
            this.pnlDanhMuc.Controls.Add(this.btnGiaiKhat);
            this.pnlDanhMuc.Location = new System.Drawing.Point(7, 6);
            this.pnlDanhMuc.Name = "pnlDanhMuc";
            this.pnlDanhMuc.Size = new System.Drawing.Size(951, 73);
            this.pnlDanhMuc.TabIndex = 2;
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
            this.btnMonThem.Location = new System.Drawing.Point(3, 402);
            this.btnMonThem.Name = "btnMonThem";
            this.btnMonThem.Size = new System.Drawing.Size(149, 67);
            this.btnMonThem.TabIndex = 3;
            this.btnMonThem.Text = "Món Thêm";
            this.btnMonThem.UseVisualStyleBackColor = true;
            // 
            // btnGiaiKhat
            // 
            this.btnGiaiKhat.Location = new System.Drawing.Point(158, 402);
            this.btnGiaiKhat.Name = "btnGiaiKhat";
            this.btnGiaiKhat.Size = new System.Drawing.Size(149, 67);
            this.btnGiaiKhat.TabIndex = 4;
            this.btnGiaiKhat.Text = "Giải Khát";
            this.btnGiaiKhat.UseVisualStyleBackColor = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangNhap.Location = new System.Drawing.Point(838, 23);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(136, 32);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Location = new System.Drawing.Point(838, 66);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(136, 32);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 538);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblTenQuan);
            this.Controls.Add(this.picBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrangChu";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabThucDon.ResumeLayout(false);
            this.pnlDanhMuc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.Label lblTenQuan;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabThucDon;
        private System.Windows.Forms.FlowLayoutPanel pnlDanhMuc;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.Button btnMonCom;
        private System.Windows.Forms.Button btnMonCanh;
        private System.Windows.Forms.Button btnMonThem;
        private System.Windows.Forms.Button btnGiaiKhat;
        private System.Windows.Forms.ListView lvMonAn;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
    }
}