namespace QuanLyNhaHang.Interface_layer.Admin
{
    partial class frmMonAn
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
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtAnhUrl = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.chkConHang = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(78, 46);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(287, 24);
            this.cboDanhMuc.TabIndex = 0;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(78, 110);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(287, 22);
            this.txtTenMon.TabIndex = 1;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(78, 173);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(287, 22);
            this.txtGiaBan.TabIndex = 2;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(78, 238);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(287, 22);
            this.txtMoTa.TabIndex = 3;
            // 
            // txtAnhUrl
            // 
            this.txtAnhUrl.Location = new System.Drawing.Point(78, 306);
            this.txtAnhUrl.Name = "txtAnhUrl";
            this.txtAnhUrl.Size = new System.Drawing.Size(287, 22);
            this.txtAnhUrl.TabIndex = 4;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(262, 419);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(164, 45);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Huy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(31, 419);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(164, 45);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Luu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // chkConHang
            // 
            this.chkConHang.AutoSize = true;
            this.chkConHang.Location = new System.Drawing.Point(195, 364);
            this.chkConHang.Name = "chkConHang";
            this.chkConHang.Size = new System.Drawing.Size(65, 20);
            this.chkConHang.TabIndex = 10;
            this.chkConHang.Text = "check";
            this.chkConHang.UseVisualStyleBackColor = true;
            // 
            // frmMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 504);
            this.Controls.Add(this.chkConHang);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.txtAnhUrl);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtTenMon);
            this.Controls.Add(this.cboDanhMuc);
            this.Name = "frmMonAn";
            this.Text = "frmMonAn";
            this.Load += new System.EventHandler(this.frmMonAn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtAnhUrl;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.CheckBox chkConHang;
    }
}