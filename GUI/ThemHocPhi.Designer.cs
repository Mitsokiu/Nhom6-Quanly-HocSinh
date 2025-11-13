namespace GUI
{
    partial class ThemHocPhi
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Panel();
            this.lblTenKhoanPhi = new System.Windows.Forms.Label();
            this.txtTenKhoanPhi = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblKyHoc = new System.Windows.Forms.Label();
            this.cmbHocKy = new System.Windows.Forms.ComboBox();
            this.lblNgayDenHan = new System.Windows.Forms.Label();
            this.dtpNgayDenHan = new System.Windows.Forms.DateTimePicker();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(40, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(302, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm Khoản Phí Mới";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(45, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(425, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Điền thông tin dưới đây để tạo một khoản phí mới cho học sinh.";
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.BackColor = System.Drawing.Color.Gainsboro;
            this.separator.Location = new System.Drawing.Point(45, 110);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(710, 1);
            this.separator.TabIndex = 2;
            // 
            // lblTenKhoanPhi
            // 
            this.lblTenKhoanPhi.AutoSize = true;
            this.lblTenKhoanPhi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKhoanPhi.Location = new System.Drawing.Point(45, 140);
            this.lblTenKhoanPhi.Name = "lblTenKhoanPhi";
            this.lblTenKhoanPhi.Size = new System.Drawing.Size(102, 17);
            this.lblTenKhoanPhi.TabIndex = 3;
            this.lblTenKhoanPhi.Text = "Tên khoản phí *";
            // 
            // txtTenKhoanPhi
            // 
            this.txtTenKhoanPhi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhoanPhi.ForeColor = System.Drawing.Color.Gray;
            this.txtTenKhoanPhi.Location = new System.Drawing.Point(45, 165);
            this.txtTenKhoanPhi.Name = "txtTenKhoanPhi";
            this.txtTenKhoanPhi.Size = new System.Drawing.Size(340, 25);
            this.txtTenKhoanPhi.TabIndex = 0;
            this.txtTenKhoanPhi.Text = "Ví dụ: Học phí học kỳ 1";
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTien.Location = new System.Drawing.Point(415, 140);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(100, 17);
            this.lblSoTien.TabIndex = 5;
            this.lblSoTien.Text = "Số tiền (VND) *";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.ForeColor = System.Drawing.Color.Gray;
            this.txtSoTien.Location = new System.Drawing.Point(415, 165);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(340, 25);
            this.txtSoTien.TabIndex = 1;
            this.txtSoTien.Text = "Nhập số tiền";
            // 
            // lblKyHoc
            // 
            this.lblKyHoc.AutoSize = true;
            this.lblKyHoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKyHoc.Location = new System.Drawing.Point(45, 220);
            this.lblKyHoc.Name = "lblKyHoc";
            this.lblKyHoc.Size = new System.Drawing.Size(111, 17);
            this.lblKyHoc.TabIndex = 7;
            this.lblKyHoc.Text = "Kỳ học áp dụng *";
            // 
            // cmbHocKy
            // 
            this.cmbHocKy.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbHocKy.FormattingEnabled = true;
            this.cmbHocKy.Items.AddRange(new object[] {
            "Học kỳ 1 (2023-2024)",
            "Học kỳ 2 (2023-2024)"});
            this.cmbHocKy.Location = new System.Drawing.Point(45, 245);
            this.cmbHocKy.Name = "cmbHocKy";
            this.cmbHocKy.Size = new System.Drawing.Size(340, 25);
            this.cmbHocKy.TabIndex = 2;
            this.cmbHocKy.Text = "Chọn kỳ học";
            // 
            // lblNgayDenHan
            // 
            this.lblNgayDenHan.AutoSize = true;
            this.lblNgayDenHan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDenHan.Location = new System.Drawing.Point(415, 220);
            this.lblNgayDenHan.Name = "lblNgayDenHan";
            this.lblNgayDenHan.Size = new System.Drawing.Size(102, 17);
            this.lblNgayDenHan.TabIndex = 9;
            this.lblNgayDenHan.Text = "Ngày đến hạn *";
            // 
            // dtpNgayDenHan
            // 
            this.dtpNgayDenHan.CustomFormat = "MM/dd/yyyy";
            this.dtpNgayDenHan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpNgayDenHan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDenHan.Location = new System.Drawing.Point(415, 245);
            this.dtpNgayDenHan.Name = "dtpNgayDenHan";
            this.dtpNgayDenHan.Size = new System.Drawing.Size(340, 25);
            this.dtpNgayDenHan.TabIndex = 3;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(45, 300);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(144, 17);
            this.lblMoTa.TabIndex = 11;
            this.lblMoTa.Text = "Mô tả (Không bắt buộc)";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.ForeColor = System.Drawing.Color.Gray;
            this.txtMoTa.Location = new System.Drawing.Point(45, 325);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(710, 150);
            this.txtMoTa.TabIndex = 4;
            this.txtMoTa.Text = "Nhập mô tả chi tiết về khoản phí...";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Location = new System.Drawing.Point(575, 500);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 35);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(670, 500);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(85, 35);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // ThemHocPhi
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.dtpNgayDenHan);
            this.Controls.Add(this.lblNgayDenHan);
            this.Controls.Add(this.cmbHocKy);
            this.Controls.Add(this.lblKyHoc);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.txtTenKhoanPhi);
            this.Controls.Add(this.lblTenKhoanPhi);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemHocPhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Khoản Phí Mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Label lblTenKhoanPhi;
        private System.Windows.Forms.TextBox txtTenKhoanPhi;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblKyHoc;
        private System.Windows.Forms.ComboBox cmbHocKy;
        private System.Windows.Forms.Label lblNgayDenHan;
        private System.Windows.Forms.DateTimePicker dtpNgayDenHan;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}