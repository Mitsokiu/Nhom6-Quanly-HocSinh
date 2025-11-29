namespace GUI.UserControls
{
    partial class UC_GVCN_HanhKiem
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;

        // --- 1. KHAI BÁO 2 NÚT MỚI ---
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnCancel;

        // Filter & Search
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox picSearchIcon;
        private System.Windows.Forms.ComboBox cbbHocKy;
        private System.Windows.Forms.Label lblHocKy;

        // Data Grid
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvHanhKiem;

        // Pagination
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Label lblDots;
        private System.Windows.Forms.Button btnPageLast;
        private System.Windows.Forms.Button btnNext;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();

            // --- 2. KHỞI TẠO NÚT ---
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cbbHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picSearchIcon = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvHanhKiem = new System.Windows.Forms.DataGridView();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPageLast = new System.Windows.Forms.Button();
            this.lblDots = new System.Windows.Forms.Label();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKiem)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;

            // --- 3. THÊM NÚT VÀO PANEL ---
            this.pnlHeader.Controls.Add(this.btnSaveAll);
            this.pnlHeader.Controls.Add(this.btnCancel);

            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1040, 100);
            this.pnlHeader.TabIndex = 0;

            // 
            // btnSaveAll (Cấu hình Nút Lưu)
            // 
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253))))); // Xanh dương
            this.btnSaveAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAll.FlatAppearance.BorderSize = 0;
            this.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveAll.ForeColor = System.Drawing.Color.White;
            this.btnSaveAll.Location = new System.Drawing.Point(920, 10); // Đặt sát góc phải
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(120, 40);
            this.btnSaveAll.TabIndex = 2; // Index cao để tab tới sau cùng
            this.btnSaveAll.Text = "Lưu tất cả";
            this.btnSaveAll.UseVisualStyleBackColor = false;

            // 
            // btnCancel (Cấu hình Nút Hủy)
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))); // Xám
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(810, 10); // Đặt bên trái nút Lưu
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;

            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(5, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(374, 20);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Cập nhật hạnh kiểm và nhận xét cho học sinh trong lớp.";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 45);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Phê Hạnh kiểm Lớp...";

            // ... (Phần code bên dưới của Filter, Search, Grid, Pagination giữ nguyên không đổi) ...

            // pnlFilter
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.Controls.Add(this.cbbHocKy);
            this.pnlFilter.Controls.Add(this.lblHocKy);
            this.pnlFilter.Controls.Add(this.pnlSearchBox);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(30, 130);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1040, 60);
            this.pnlFilter.TabIndex = 1;
            // cbbHocKy
            this.cbbHocKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbHocKy.BackColor = System.Drawing.Color.White;
            this.cbbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHocKy.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbbHocKy.FormattingEnabled = true;
            this.cbbHocKy.Location = new System.Drawing.Point(805, 14);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(232, 28);
            this.cbbHocKy.TabIndex = 0;
            // lblHocKy
            this.lblHocKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHocKy.Location = new System.Drawing.Point(735, 19);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(60, 19);
            this.lblHocKy.TabIndex = 1;
            this.lblHocKy.Text = "Học kỳ:";
            // pnlSearchBox
            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.Controls.Add(this.picSearchIcon);
            this.pnlSearchBox.Location = new System.Drawing.Point(0, 10);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(400, 40);
            this.pnlSearchBox.TabIndex = 0;
            // txtSearch
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(45, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(340, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Tìm kiếm học sinh...";
            // picSearchIcon
            this.picSearchIcon.Image = global::GUI.Properties.Resources.search_32;
            this.picSearchIcon.Location = new System.Drawing.Point(10, 8);
            this.picSearchIcon.Name = "picSearchIcon";
            this.picSearchIcon.Size = new System.Drawing.Size(24, 24);
            this.picSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearchIcon.TabIndex = 1;
            this.picSearchIcon.TabStop = false;
            // pnlContent
            this.pnlContent.Controls.Add(this.dgvHanhKiem);
            this.pnlContent.Controls.Add(this.pnlPagination);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(30, 190);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(1040, 480);
            this.pnlContent.TabIndex = 2;
            // dgvHanhKiem
            this.dgvHanhKiem.AllowUserToAddRows = false;
            this.dgvHanhKiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHanhKiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvHanhKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHanhKiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHanhKiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(174)))), ((int)(((byte)(192)))));
            this.dgvHanhKiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHanhKiem.ColumnHeadersHeight = 45;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHanhKiem.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHanhKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHanhKiem.EnableHeadersVisualStyles = false;
            this.dgvHanhKiem.Location = new System.Drawing.Point(0, 10);
            this.dgvHanhKiem.Name = "dgvHanhKiem";
            this.dgvHanhKiem.RowHeadersVisible = false;
            this.dgvHanhKiem.RowTemplate.Height = 55;
            this.dgvHanhKiem.Size = new System.Drawing.Size(1040, 410);
            this.dgvHanhKiem.TabIndex = 0;
            // pnlPagination
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.Controls.Add(this.btnPageLast);
            this.pnlPagination.Controls.Add(this.lblDots);
            this.pnlPagination.Controls.Add(this.btnPage3);
            this.pnlPagination.Controls.Add(this.btnPage2);
            this.pnlPagination.Controls.Add(this.btnPage1);
            this.pnlPagination.Controls.Add(this.btnPrev);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(0, 420);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1040, 60);
            this.pnlPagination.TabIndex = 1;
            // btnNext
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(0, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            // btnPageLast
            this.btnPageLast.FlatAppearance.BorderSize = 0;
            this.btnPageLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPageLast.Location = new System.Drawing.Point(0, 0);
            this.btnPageLast.Name = "btnPageLast";
            this.btnPageLast.Size = new System.Drawing.Size(35, 35);
            this.btnPageLast.TabIndex = 1;
            // lblDots
            this.lblDots.AutoSize = true;
            this.lblDots.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDots.Location = new System.Drawing.Point(0, 0);
            this.lblDots.Name = "lblDots";
            this.lblDots.Size = new System.Drawing.Size(19, 21);
            this.lblDots.TabIndex = 2;
            this.lblDots.Text = "...";
            // btnPage3
            this.btnPage3.FlatAppearance.BorderSize = 0;
            this.btnPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3.Location = new System.Drawing.Point(0, 0);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(35, 35);
            this.btnPage3.TabIndex = 3;
            // btnPage2
            this.btnPage2.FlatAppearance.BorderSize = 0;
            this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2.Location = new System.Drawing.Point(0, 0);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(35, 35);
            this.btnPage2.TabIndex = 4;
            // btnPage1
            this.btnPage1.FlatAppearance.BorderSize = 0;
            this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1.Location = new System.Drawing.Point(0, 0);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(35, 35);
            this.btnPage1.TabIndex = 5;
            // btnPrev
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(0, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 35);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Text = "<";
            // 
            // UC_GVCN_HanhKiem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_GVCN_HanhKiem";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Size = new System.Drawing.Size(1100, 700);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKiem)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}