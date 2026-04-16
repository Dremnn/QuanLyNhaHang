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
            this.picBanner.Click += new System.EventHandler(this.picBanner_Click);
            // 
            // lblTenQuan
            // 
            this.lblTenQuan.AutoSize = true;
            this.lblTenQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenQuan.Location = new System.Drawing.Point(399, 23);
            this.lblTenQuan.Name = "lblTenQuan";
            this.lblTenQuan.Size = new System.Drawing.Size(189, 32);
            this.lblTenQuan.TabIndex = 1;
            this.lblTenQuan.Text = "Sa Bi Chuong";
            this.lblTenQuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabThucDon);
            this.tabMain.Location = new System.Drawing.Point(12, 88);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(972, 438);
            this.tabMain.TabIndex = 2;
            // 
            // tabThucDon
            // 
            this.tabThucDon.Controls.Add(this.lvMonAn);
            this.tabThucDon.Controls.Add(this.pnlDanhMuc);
            this.tabThucDon.Location = new System.Drawing.Point(4, 25);
            this.tabThucDon.Name = "tabThucDon";
            this.tabThucDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabThucDon.Size = new System.Drawing.Size(964, 409);
            this.tabThucDon.TabIndex = 0;
            this.tabThucDon.Text = "Thuc Don";
            this.tabThucDon.UseVisualStyleBackColor = true;
            // 
            // lvMonAn
            // 
            this.lvMonAn.HideSelection = false;
            this.lvMonAn.Location = new System.Drawing.Point(6, 100);
            this.lvMonAn.Name = "lvMonAn";
            this.lvMonAn.Size = new System.Drawing.Size(952, 302);
            this.lvMonAn.TabIndex = 3;
            this.lvMonAn.UseCompatibleStateImageBehavior = false;
            // 
            // pnlDanhMuc
            // 
            this.pnlDanhMuc.Controls.Add(this.btnTatCa);
            this.pnlDanhMuc.Controls.Add(this.btnMonCom);
            this.pnlDanhMuc.Controls.Add(this.btnMonCanh);
            this.pnlDanhMuc.Controls.Add(this.btnMonThem);
            this.pnlDanhMuc.Controls.Add(this.btnGiaiKhat);
            this.pnlDanhMuc.Location = new System.Drawing.Point(7, 6);
            this.pnlDanhMuc.Name = "pnlDanhMuc";
            this.pnlDanhMuc.Size = new System.Drawing.Size(951, 88);
            this.pnlDanhMuc.TabIndex = 2;
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(3, 3);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(149, 67);
            this.btnTatCa.TabIndex = 0;
            this.btnTatCa.Text = "Tat Ca";
            this.btnTatCa.UseVisualStyleBackColor = true;
            // 
            // btnMonCom
            // 
            this.btnMonCom.Location = new System.Drawing.Point(158, 3);
            this.btnMonCom.Name = "btnMonCom";
            this.btnMonCom.Size = new System.Drawing.Size(149, 67);
            this.btnMonCom.TabIndex = 1;
            this.btnMonCom.Text = "Mon Com";
            this.btnMonCom.UseVisualStyleBackColor = true;
            // 
            // btnMonCanh
            // 
            this.btnMonCanh.Location = new System.Drawing.Point(313, 3);
            this.btnMonCanh.Name = "btnMonCanh";
            this.btnMonCanh.Size = new System.Drawing.Size(149, 67);
            this.btnMonCanh.TabIndex = 2;
            this.btnMonCanh.Text = "Mon Canh";
            this.btnMonCanh.UseVisualStyleBackColor = true;
            // 
            // btnMonThem
            // 
            this.btnMonThem.Location = new System.Drawing.Point(468, 3);
            this.btnMonThem.Name = "btnMonThem";
            this.btnMonThem.Size = new System.Drawing.Size(149, 67);
            this.btnMonThem.TabIndex = 3;
            this.btnMonThem.Text = "Mon Them";
            this.btnMonThem.UseVisualStyleBackColor = true;
            // 
            // btnGiaiKhat
            // 
            this.btnGiaiKhat.Location = new System.Drawing.Point(623, 3);
            this.btnGiaiKhat.Name = "btnGiaiKhat";
            this.btnGiaiKhat.Size = new System.Drawing.Size(149, 67);
            this.btnGiaiKhat.TabIndex = 4;
            this.btnGiaiKhat.Text = "Giai Khat";
            this.btnGiaiKhat.UseVisualStyleBackColor = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(753, 23);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(221, 32);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Dang nhap de dat ban";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 538);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblTenQuan);
            this.Controls.Add(this.picBanner);
            this.Name = "frmTrangChu";
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
    }
}