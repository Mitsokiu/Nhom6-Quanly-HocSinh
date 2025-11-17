namespace GUI
{
    partial class HocPhiControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnThemKhoanPhi = new System.Windows.Forms.Button();
            this.panelTongDaThanhToan = new System.Windows.Forms.Panel();
            this.lblValueDaThanhToan = new System.Windows.Forms.Label();
            this.lblTitleDaThanhToan = new System.Windows.Forms.Label();
            this.panelTongChuaThanhToan = new System.Windows.Forms.Panel();
            this.lblValueChuaThanhToan = new System.Windows.Forms.Label();
            this.lblTitleChuaThanhToan = new System.Windows.Forms.Label();
            this.panelHoaDonQuaHan = new System.Windows.Forms.Panel();
            this.lblValueQuaHan = new System.Windows.Forms.Label();
            this.lblTitleQuaHan = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.linkXoaBoLoc = new System.Windows.Forms.LinkLabel();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.cmbHocKy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvHocPhi = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMaHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHanNop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPage100 = new System.Windows.Forms.Button();
            this.lblPageDots = new System.Windows.Forms.Label();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPagingInfo = new System.Windows.Forms.Label();
            this.panelTongDaThanhToan.SuspendLayout();
            this.panelTongChuaThanhToan.SuspendLayout();
            this.panelHoaDonQuaHan.SuspendLayout();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(44, 31);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Học phí";
            // 
            // btnThemKhoanPhi
            // 
            this.btnThemKhoanPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemKhoanPhi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnThemKhoanPhi.FlatAppearance.BorderSize = 0;
            this.btnThemKhoanPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKhoanPhi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKhoanPhi.ForeColor = System.Drawing.Color.White;
            this.btnThemKhoanPhi.Location = new System.Drawing.Point(1063, 31);
            this.btnThemKhoanPhi.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemKhoanPhi.Name = "btnThemKhoanPhi";
            this.btnThemKhoanPhi.Size = new System.Drawing.Size(227, 49);
            this.btnThemKhoanPhi.TabIndex = 1;
            this.btnThemKhoanPhi.Text = "+ Thêm khoản phí mới";
            this.btnThemKhoanPhi.UseVisualStyleBackColor = false;
            this.btnThemKhoanPhi.Click += new System.EventHandler(this.btnThemKhoanPhi_Click);
            // 
            // panelTongDaThanhToan
            // 
            this.panelTongDaThanhToan.BackColor = System.Drawing.Color.White;
            this.panelTongDaThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTongDaThanhToan.Controls.Add(this.lblValueDaThanhToan);
            this.panelTongDaThanhToan.Controls.Add(this.lblTitleDaThanhToan);
            this.panelTongDaThanhToan.Location = new System.Drawing.Point(53, 105);
            this.panelTongDaThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.panelTongDaThanhToan.Name = "panelTongDaThanhToan";
            this.panelTongDaThanhToan.Size = new System.Drawing.Size(393, 123);
            this.panelTongDaThanhToan.TabIndex = 2;
            // 
            // lblValueDaThanhToan
            // 
            this.lblValueDaThanhToan.AutoSize = true;
            this.lblValueDaThanhToan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueDaThanhToan.Location = new System.Drawing.Point(24, 55);
            this.lblValueDaThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValueDaThanhToan.Name = "lblValueDaThanhToan";
            this.lblValueDaThanhToan.Size = new System.Drawing.Size(215, 37);
            this.lblValueDaThanhToan.TabIndex = 1;
            this.lblValueDaThanhToan.Text = "1.250.000.000đ";
            // 
            // lblTitleDaThanhToan
            // 
            this.lblTitleDaThanhToan.AutoSize = true;
            this.lblTitleDaThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDaThanhToan.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleDaThanhToan.Location = new System.Drawing.Point(27, 25);
            this.lblTitleDaThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleDaThanhToan.Name = "lblTitleDaThanhToan";
            this.lblTitleDaThanhToan.Size = new System.Drawing.Size(219, 23);
            this.lblTitleDaThanhToan.TabIndex = 0;
            this.lblTitleDaThanhToan.Text = "Tổng số tiền đã thanh toán";
            // 
            // panelTongChuaThanhToan
            // 
            this.panelTongChuaThanhToan.BackColor = System.Drawing.Color.White;
            this.panelTongChuaThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTongChuaThanhToan.Controls.Add(this.lblValueChuaThanhToan);
            this.panelTongChuaThanhToan.Controls.Add(this.lblTitleChuaThanhToan);
            this.panelTongChuaThanhToan.Location = new System.Drawing.Point(473, 105);
            this.panelTongChuaThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.panelTongChuaThanhToan.Name = "panelTongChuaThanhToan";
            this.panelTongChuaThanhToan.Size = new System.Drawing.Size(393, 123);
            this.panelTongChuaThanhToan.TabIndex = 3;
            // 
            // lblValueChuaThanhToan
            // 
            this.lblValueChuaThanhToan.AutoSize = true;
            this.lblValueChuaThanhToan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueChuaThanhToan.Location = new System.Drawing.Point(24, 55);
            this.lblValueChuaThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValueChuaThanhToan.Name = "lblValueChuaThanhToan";
            this.lblValueChuaThanhToan.Size = new System.Drawing.Size(192, 37);
            this.lblValueChuaThanhToan.TabIndex = 1;
            this.lblValueChuaThanhToan.Text = "150.000.000đ";
            // 
            // lblTitleChuaThanhToan
            // 
            this.lblTitleChuaThanhToan.AutoSize = true;
            this.lblTitleChuaThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChuaThanhToan.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleChuaThanhToan.Location = new System.Drawing.Point(27, 25);
            this.lblTitleChuaThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleChuaThanhToan.Name = "lblTitleChuaThanhToan";
            this.lblTitleChuaThanhToan.Size = new System.Drawing.Size(237, 23);
            this.lblTitleChuaThanhToan.TabIndex = 0;
            this.lblTitleChuaThanhToan.Text = "Tổng số tiền chưa thanh toán";
            // 
            // panelHoaDonQuaHan
            // 
            this.panelHoaDonQuaHan.BackColor = System.Drawing.Color.White;
            this.panelHoaDonQuaHan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHoaDonQuaHan.Controls.Add(this.lblValueQuaHan);
            this.panelHoaDonQuaHan.Controls.Add(this.lblTitleQuaHan);
            this.panelHoaDonQuaHan.Location = new System.Drawing.Point(893, 105);
            this.panelHoaDonQuaHan.Margin = new System.Windows.Forms.Padding(4);
            this.panelHoaDonQuaHan.Name = "panelHoaDonQuaHan";
            this.panelHoaDonQuaHan.Size = new System.Drawing.Size(393, 123);
            this.panelHoaDonQuaHan.TabIndex = 4;
            // 
            // lblValueQuaHan
            // 
            this.lblValueQuaHan.AutoSize = true;
            this.lblValueQuaHan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueQuaHan.ForeColor = System.Drawing.Color.Red;
            this.lblValueQuaHan.Location = new System.Drawing.Point(24, 55);
            this.lblValueQuaHan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValueQuaHan.Name = "lblValueQuaHan";
            this.lblValueQuaHan.Size = new System.Drawing.Size(49, 37);
            this.lblValueQuaHan.TabIndex = 1;
            this.lblValueQuaHan.Text = "12";
            this.lblValueQuaHan.Click += new System.EventHandler(this.lblValueQuaHan_Click);
            // 
            // lblTitleQuaHan
            // 
            this.lblTitleQuaHan.AutoSize = true;
            this.lblTitleQuaHan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleQuaHan.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleQuaHan.Location = new System.Drawing.Point(27, 25);
            this.lblTitleQuaHan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleQuaHan.Name = "lblTitleQuaHan";
            this.lblTitleQuaHan.Size = new System.Drawing.Size(215, 23);
            this.lblTitleQuaHan.TabIndex = 0;
            this.lblTitleQuaHan.Text = "Số lượng hóa đơn quá hạn";
            // 
            // panelFilters
            // 
            this.panelFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilters.Controls.Add(this.linkXoaBoLoc);
            this.panelFilters.Controls.Add(this.dtpNgayHetHan);
            this.panelFilters.Controls.Add(this.cmbTrangThai);
            this.panelFilters.Controls.Add(this.cmbHocKy);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Location = new System.Drawing.Point(53, 252);
            this.panelFilters.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1235, 86);
            this.panelFilters.TabIndex = 5;
            // 
            // linkXoaBoLoc
            // 
            this.linkXoaBoLoc.AutoSize = true;
            this.linkXoaBoLoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkXoaBoLoc.Location = new System.Drawing.Point(1115, 32);
            this.linkXoaBoLoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkXoaBoLoc.Name = "linkXoaBoLoc";
            this.linkXoaBoLoc.Size = new System.Drawing.Size(91, 23);
            this.linkXoaBoLoc.TabIndex = 4;
            this.linkXoaBoLoc.TabStop = true;
            this.linkXoaBoLoc.Text = "Xóa bộ lọc";
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayHetHan.Location = new System.Drawing.Point(827, 27);
            this.dtpNgayHetHan.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(252, 29);
            this.dtpNgayHetHan.TabIndex = 3;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Đã thanh toán",
            "Chưa thanh toán",
            "Quá hạn"});
            this.cmbTrangThai.Location = new System.Drawing.Point(627, 27);
            this.cmbTrangThai.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(172, 29);
            this.cmbTrangThai.TabIndex = 2;
            this.cmbTrangThai.Text = "Trạng thái";
            // 
            // cmbHocKy
            // 
            this.cmbHocKy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHocKy.FormattingEnabled = true;
            this.cmbHocKy.Items.AddRange(new object[] {
            "Học kỳ 1 (2023-2024)",
            "Học kỳ 2 (2023-2024)"});
            this.cmbHocKy.Location = new System.Drawing.Point(427, 27);
            this.cmbHocKy.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHocKy.Name = "cmbHocKy";
            this.cmbHocKy.Size = new System.Drawing.Size(172, 29);
            this.cmbHocKy.TabIndex = 1;
            this.cmbHocKy.Text = "Học kỳ 1 (2023-2024)";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(27, 27);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(372, 29);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "  Tìm kiếm theo tên, mã học sinh...";
            // 
            // dgvHocPhi
            // 
            this.dgvHocPhi.AllowUserToAddRows = false;
            this.dgvHocPhi.AllowUserToDeleteRows = false;
            this.dgvHocPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHocPhi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHocPhi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHocPhi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHocPhi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHocPhi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHocPhi.ColumnHeadersHeight = 40;
            this.dgvHocPhi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colMaHS,
            this.colHoTen,
            this.colHocKy,
            this.colSoTien,
            this.colHanNop,
            this.colTrangThai,
            this.colView,
            this.colEdit,
            this.colPrint});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHocPhi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHocPhi.EnableHeadersVisualStyles = false;
            this.dgvHocPhi.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvHocPhi.Location = new System.Drawing.Point(50, 357);
            this.dgvHocPhi.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHocPhi.Name = "dgvHocPhi";
            this.dgvHocPhi.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHocPhi.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHocPhi.RowHeadersVisible = false;
            this.dgvHocPhi.RowHeadersWidth = 51;
            this.dgvHocPhi.RowTemplate.Height = 36;
            this.dgvHocPhi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocPhi.Size = new System.Drawing.Size(1236, 443);
            this.dgvHocPhi.TabIndex = 6;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.MinimumWidth = 6;
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Width = 50;
            // 
            // colMaHS
            // 
            this.colMaHS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMaHS.HeaderText = "MÃ HS";
            this.colMaHS.MinimumWidth = 6;
            this.colMaHS.Name = "colMaHS";
            this.colMaHS.ReadOnly = true;
            this.colMaHS.Width = 103;
            // 
            // colHoTen
            // 
            this.colHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHoTen.FillWeight = 150F;
            this.colHoTen.HeaderText = "HỌ VÀ TÊN";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colHocKy
            // 
            this.colHocKy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHocKy.HeaderText = "HỌC KỲ";
            this.colHocKy.MinimumWidth = 6;
            this.colHocKy.Name = "colHocKy";
            this.colHocKy.ReadOnly = true;
            // 
            // colSoTien
            // 
            this.colSoTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colSoTien.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSoTien.HeaderText = "SỐ TIỀN";
            this.colSoTien.MinimumWidth = 6;
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.ReadOnly = true;
            // 
            // colHanNop
            // 
            this.colHanNop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHanNop.HeaderText = "HẠN NỘP";
            this.colHanNop.MinimumWidth = 6;
            this.colHanNop.Name = "colHanNop";
            this.colHanNop.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTrangThai.HeaderText = "TRẠNG THÁI";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 150;
            // 
            // colView
            // 
            this.colView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colView.HeaderText = "HÀNH ĐỘNG";
            this.colView.MinimumWidth = 6;
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Text = "Xem";
            this.colView.UseColumnTextForButtonValue = true;
            this.colView.Width = 131;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Sửa";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 60;
            // 
            // colPrint
            // 
            this.colPrint.HeaderText = "";
            this.colPrint.MinimumWidth = 6;
            this.colPrint.Name = "colPrint";
            this.colPrint.ReadOnly = true;
            this.colPrint.Text = "In";
            this.colPrint.UseColumnTextForButtonValue = true;
            this.colPrint.Width = 60;
            // 
            // panelPagination
            // 
            this.panelPagination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPagination.BackColor = System.Drawing.Color.White;
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnPage100);
            this.panelPagination.Controls.Add(this.lblPageDots);
            this.panelPagination.Controls.Add(this.btnPage3);
            this.panelPagination.Controls.Add(this.btnPage2);
            this.panelPagination.Controls.Add(this.btnPage1);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPagingInfo);
            this.panelPagination.Location = new System.Drawing.Point(53, 825);
            this.panelPagination.Margin = new System.Windows.Forms.Padding(4);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1236, 62);
            this.panelPagination.TabIndex = 7;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(1176, 12);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 37);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPage100
            // 
            this.btnPage100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage100.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage100.Location = new System.Drawing.Point(1115, 12);
            this.btnPage100.Margin = new System.Windows.Forms.Padding(4);
            this.btnPage100.Name = "btnPage100";
            this.btnPage100.Size = new System.Drawing.Size(53, 37);
            this.btnPage100.TabIndex = 6;
            this.btnPage100.Text = "100";
            this.btnPage100.UseVisualStyleBackColor = true;
            // 
            // lblPageDots
            // 
            this.lblPageDots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageDots.AutoSize = true;
            this.lblPageDots.Location = new System.Drawing.Point(1087, 22);
            this.lblPageDots.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageDots.Name = "lblPageDots";
            this.lblPageDots.Size = new System.Drawing.Size(16, 16);
            this.lblPageDots.TabIndex = 5;
            this.lblPageDots.Text = "...";
            // 
            // btnPage3
            // 
            this.btnPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage3.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3.Location = new System.Drawing.Point(1039, 12);
            this.btnPage3.Margin = new System.Windows.Forms.Padding(4);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(40, 37);
            this.btnPage3.TabIndex = 4;
            this.btnPage3.Text = "3";
            this.btnPage3.UseVisualStyleBackColor = true;
            // 
            // btnPage2
            // 
            this.btnPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnPage2.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2.ForeColor = System.Drawing.Color.White;
            this.btnPage2.Location = new System.Drawing.Point(991, 12);
            this.btnPage2.Margin = new System.Windows.Forms.Padding(4);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(40, 37);
            this.btnPage2.TabIndex = 3;
            this.btnPage2.Text = "2";
            this.btnPage2.UseVisualStyleBackColor = false;
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1.Location = new System.Drawing.Point(943, 12);
            this.btnPage1.Margin = new System.Windows.Forms.Padding(4);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(40, 37);
            this.btnPage1.TabIndex = 2;
            this.btnPage1.Text = "1";
            this.btnPage1.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(895, 12);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 37);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblPagingInfo
            // 
            this.lblPagingInfo.AutoSize = true;
            this.lblPagingInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagingInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblPagingInfo.Location = new System.Drawing.Point(23, 20);
            this.lblPagingInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPagingInfo.Name = "lblPagingInfo";
            this.lblPagingInfo.Size = new System.Drawing.Size(175, 23);
            this.lblPagingInfo.TabIndex = 0;
            this.lblPagingInfo.Text = "Showing 1-10 of 1000";
            // 
            // HocPhiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.dgvHocPhi);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelHoaDonQuaHan);
            this.Controls.Add(this.panelTongChuaThanhToan);
            this.Controls.Add(this.panelTongDaThanhToan);
            this.Controls.Add(this.btnThemKhoanPhi);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HocPhiControl";
            this.Size = new System.Drawing.Size(1333, 923);
            this.panelTongDaThanhToan.ResumeLayout(false);
            this.panelTongDaThanhToan.PerformLayout();
            this.panelTongChuaThanhToan.ResumeLayout(false);
            this.panelTongChuaThanhToan.PerformLayout();
            this.panelHoaDonQuaHan.ResumeLayout(false);
            this.panelHoaDonQuaHan.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnThemKhoanPhi;
        private System.Windows.Forms.Panel panelTongDaThanhToan;
        private System.Windows.Forms.Label lblValueDaThanhToan;
        private System.Windows.Forms.Label lblTitleDaThanhToan;
        private System.Windows.Forms.Panel panelTongChuaThanhToan;
        private System.Windows.Forms.Label lblValueChuaThanhToan;
        private System.Windows.Forms.Label lblTitleChuaThanhToan;
        private System.Windows.Forms.Panel panelHoaDonQuaHan;
        private System.Windows.Forms.Label lblValueQuaHan;
        private System.Windows.Forms.Label lblTitleQuaHan;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.LinkLabel linkXoaBoLoc;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.ComboBox cmbHocKy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvHocPhi;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Label lblPagingInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPage100;
        private System.Windows.Forms.Label lblPageDots;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage1D;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHanNop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewButtonColumn colView;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colPrint;
        private System.Windows.Forms.Button btnPage1;
    }
}