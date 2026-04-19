namespace QuanLyNhaHang.Interface_layer.FrmNhanVien
{
    partial class frmChonMon
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
            this.lbMon = new System.Windows.Forms.ListBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnHuy = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnXacNhan = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMon
            // 
            this.lbMon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMon.FormattingEnabled = true;
            this.lbMon.ItemHeight = 26;
            this.lbMon.Location = new System.Drawing.Point(25, 82);
            this.lbMon.Name = "lbMon";
            this.lbMon.Size = new System.Drawing.Size(419, 316);
            this.lbMon.TabIndex = 8;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuong.Location = new System.Drawing.Point(22, 431);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(84, 19);
            this.lblSoLuong.TabIndex = 11;
            this.lblSoLuong.Text = "Số lượng :";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nudSoLuong.Location = new System.Drawing.Point(124, 429);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(68, 27);
            this.nudSoLuong.TabIndex = 12;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 20;
            this.btnHuy.BorderThickness = 1;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.White;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Location = new System.Drawing.Point(25, 474);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 50);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 20;
            this.btnXacNhan.BorderThickness = 1;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.White;
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.Black;
            this.btnXacNhan.Location = new System.Drawing.Point(335, 474);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(110, 50);
            this.btnXacNhan.TabIndex = 14;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 58);
            this.label1.TabIndex = 15;
            this.label1.Text = "MENU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChonMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lbMon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChonMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChonMon";
            this.Load += new System.EventHandler(this.frmChonMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbMon;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnHuy;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnXacNhan;
        private System.Windows.Forms.Label label1;
    }
}