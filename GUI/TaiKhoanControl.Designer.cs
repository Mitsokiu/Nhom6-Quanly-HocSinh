namespace GUI
{
    partial class TaiKhoanControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnThemTaiKhoan = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.cmbVaiTro = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPagingInfo = new System.Windows.Forms.Label();
            this.colTenTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(258, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Tài Khoản";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(35, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Xem, tìm kiếm, lọc và quản lý tài khoản người dùng trong hệ thống.";
            // 
            // btnThemTaiKhoan
            // 
            this.btnThemTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnThemTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnThemTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnThemTaiKhoan.Location = new System.Drawing.Point(800, 25);
            this.btnThemTaiKhoan.Name = "btnThemTaiKhoan";
            this.btnThemTaiKhoan.Size = new System.Drawing.Size(170, 40);
            this.btnThemTaiKhoan.TabIndex = 2;
            this.btnThemTaiKhoan.Text = "+ Thêm Tài Khoản Mới";
            this.btnThemTaiKhoan.UseVisualStyleBackColor = false;
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.cmbTrangThai);
            this.panelFilter.Controls.Add(this.cmbVaiTro);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Location = new System.Drawing.Point(35, 110);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(935, 60);
            this.panelFilter.TabIndex = 3;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Trạng thái: Tất cả",
            "Hoạt động",
            "Bị khóa"});
            this.cmbTrangThai.Location = new System.Drawing.Point(780, 16);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(140, 25);
            this.cmbTrangThai.TabIndex = 2;
            this.cmbTrangThai.Text = "Trạng thái: Tất cả";
            // 
            // cmbVaiTro
            // 
            this.cmbVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVaiTro.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbVaiTro.FormattingEnabled = true;
            this.cmbVaiTro.Items.AddRange(new object[] {
            "Vai trò: Tất cả",
            "Quản trị viên",
            "Giáo viên",
            "Học sinh"});
            this.cmbVaiTro.Location = new System.Drawing.Point(630, 16);
            this.cmbVaiTro.Name = "cmbVaiTro";
            this.cmbVaiTro.Size = new System.Drawing.Size(140, 25);
            this.cmbVaiTro.TabIndex = 1;
            this.cmbVaiTro.Text = "Vai trò: Tất cả";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(15, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "  Tìm theo tên, email...";
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaiKhoan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaiKhoan.ColumnHeadersHeight = 45;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenTaiKhoan,
            this.colTenNguoiDung,
            this.colVaiTro,
            this.colTrangThai,
            this.colActions});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaiKhoan.EnableHeadersVisualStyles = false;
            this.dgvTaiKhoan.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(35, 180);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowTemplate.Height = 50;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(935, 480);
            this.dgvTaiKhoan.TabIndex = 4;
            // 
            // panelPagination
            // 
            this.panelPagination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPagination.BackColor = System.Drawing.Color.White;
            this.panelPagination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPagingInfo);
            this.panelPagination.Location = new System.Drawing.Point(35, 660);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(935, 50);
            this.panelPagination.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(890, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(850, 10);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(30, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblPagingInfo
            // 
            this.lblPagingInfo.AutoSize = true;
            this.lblPagingInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPagingInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblPagingInfo.Location = new System.Drawing.Point(15, 17);
            this.lblPagingInfo.Name = "lblPagingInfo";
            this.lblPagingInfo.Size = new System.Drawing.Size(145, 17);
            this.lblPagingInfo.TabIndex = 0;
            this.lblPagingInfo.Text = "Hiển thị 1-5 của 100";
            // 
            // colTenTaiKhoan
            // 
            this.colTenTaiKhoan.HeaderText = "TÊN TÀI KHOẢN";
            this.colTenTaiKhoan.Name = "colTenTaiKhoan";
            this.colTenTaiKhoan.ReadOnly = true;
            this.colTenTaiKhoan.Width = 180;
            // 
            // colTenNguoiDung
            // 
            this.colTenNguoiDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenNguoiDung.HeaderText = "TÊN NGƯỜI DÙNG";
            this.colTenNguoiDung.Name = "colTenNguoiDung";
            this.colTenNguoiDung.ReadOnly = true;
            // 
            // colVaiTro
            // 
            this.colVaiTro.HeaderText = "VAI TRÒ";
            this.colVaiTro.Name = "colVaiTro";
            this.colVaiTro.ReadOnly = true;
            this.colVaiTro.Width = 150;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "TRẠNG THÁI";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 150;
            // 
            // colActions
            // 
            this.colActions.HeaderText = "HÀNH ĐỘNG";
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Width = 120;
            // 
            // TaiKhoanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.btnThemTaiKhoan);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "TaiKhoanControl";
            this.Size = new System.Drawing.Size(1000, 750);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnThemTaiKhoan;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbVaiTro;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Label lblPagingInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActions;
    }
}