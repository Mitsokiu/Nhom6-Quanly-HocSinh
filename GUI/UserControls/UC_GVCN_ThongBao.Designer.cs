namespace GUI.UserControls
{
    partial class UC_GVCN_ThongBao
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnCreate;

        // Search
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSearchInner; // Khung trắng bo góc
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox picSearchIcon;

        // Data Grid
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvThongBao;

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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlSearchInner = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picSearchIcon = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvThongBao = new System.Windows.Forms.DataGridView();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPageLast = new System.Windows.Forms.Button();
            this.lblDots = new System.Windows.Forms.Label();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // UC_GVCN_ThongBao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Size = new System.Drawing.Size(1100, 700);

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnCreate);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1040, 80);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(-5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Thông báo";

            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(0, 45);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(384, 23);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Xem, tạo, sửa và xóa thông báo cho lớp của bạn.";

            // 
            // btnCreate (ĐÃ CHỈNH LẠI VỊ TRÍ)
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            // Đặt vị trí X = Width - ButtonWidth (khoảng 860), Y = 10
            this.btnCreate.Location = new System.Drawing.Point(860, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(180, 45);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "+ Tạo thông báo mới";
            this.btnCreate.UseVisualStyleBackColor = false;

            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.pnlSearchInner);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(30, 110);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.pnlSearch.Size = new System.Drawing.Size(1040, 60);
            this.pnlSearch.TabIndex = 1;

            // 
            // pnlSearchInner (ĐÃ THU NGẮN LẠI)
            // 
            this.pnlSearchInner.BackColor = System.Drawing.Color.White;
            this.pnlSearchInner.Controls.Add(this.txtSearch);
            this.pnlSearchInner.Controls.Add(this.picSearchIcon);
            this.pnlSearchInner.Location = new System.Drawing.Point(0, 10);
            this.pnlSearchInner.Name = "pnlSearchInner";
            this.pnlSearchInner.Size = new System.Drawing.Size(400, 40); // Fix cứng width = 400px
            this.pnlSearchInner.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(45, 9); // Căn giữa theo chiều dọc
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(340, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Tìm kiếm thông báo...";

            // 
            // picSearchIcon
            // 
            this.picSearchIcon.BackColor = System.Drawing.Color.Transparent;
            this.picSearchIcon.Location = new System.Drawing.Point(10, 10);
            this.picSearchIcon.Name = "picSearchIcon";
            this.picSearchIcon.Size = new System.Drawing.Size(20, 20);
            this.picSearchIcon.TabIndex = 1;
            this.picSearchIcon.TabStop = false;
            // Bạn nhớ gán ảnh vào đây nếu có: 
            // this.picSearchIcon.Image = global::GUI.Properties.Resources.search_icon;

            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvThongBao);
            this.pnlContent.Controls.Add(this.pnlPagination);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(30, 170);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(1040, 500);
            this.pnlContent.TabIndex = 2;

            // 
            // dgvThongBao
            // 
            this.dgvThongBao.AllowUserToAddRows = false;
            this.dgvThongBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongBao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongBao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            // Style Header
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(160, 174, 192);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(160, 174, 192);
            this.dgvThongBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThongBao.ColumnHeadersHeight = 40;

            // Style Row
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.dgvThongBao.DefaultCellStyle = dataGridViewCellStyle2;

            this.dgvThongBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongBao.EnableHeadersVisualStyles = false;
            this.dgvThongBao.Location = new System.Drawing.Point(0, 10);
            this.dgvThongBao.Name = "dgvThongBao";
            this.dgvThongBao.RowHeadersVisible = false;
            this.dgvThongBao.RowTemplate.Height = 50;
            this.dgvThongBao.Size = new System.Drawing.Size(1040, 430);
            this.dgvThongBao.TabIndex = 0;

            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.Controls.Add(this.btnPageLast);
            this.pnlPagination.Controls.Add(this.lblDots);
            this.pnlPagination.Controls.Add(this.btnPage3);
            this.pnlPagination.Controls.Add(this.btnPage2);
            this.pnlPagination.Controls.Add(this.btnPage1);
            this.pnlPagination.Controls.Add(this.btnPrev);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(0, 440);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1040, 60);
            this.pnlPagination.TabIndex = 1;

            // Init buttons (Vị trí sẽ được chỉnh lại bằng code C#)
            this.btnNext.Location = new System.Drawing.Point(0, 0);
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnNext.TabIndex = 0;
            this.btnPageLast.Location = new System.Drawing.Point(0, 0);
            this.btnPageLast.Size = new System.Drawing.Size(35, 35);
            this.btnPageLast.TabIndex = 1;
            this.lblDots.AutoSize = true;
            this.lblDots.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDots.Location = new System.Drawing.Point(0, 0);
            this.lblDots.TabIndex = 2;
            this.lblDots.Text = "...";
            this.btnPage3.Location = new System.Drawing.Point(0, 0);
            this.btnPage3.Size = new System.Drawing.Size(35, 35);
            this.btnPage3.TabIndex = 3;
            this.btnPage2.Location = new System.Drawing.Point(0, 0);
            this.btnPage2.Size = new System.Drawing.Size(35, 35);
            this.btnPage2.TabIndex = 4;
            this.btnPage1.Location = new System.Drawing.Point(0, 0);
            this.btnPage1.Size = new System.Drawing.Size(35, 35);
            this.btnPage1.TabIndex = 5;
            this.btnPrev.Location = new System.Drawing.Point(0, 0);
            this.btnPrev.Size = new System.Drawing.Size(35, 35);
            this.btnPrev.TabIndex = 6;

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearchInner.ResumeLayout(false);
            this.pnlSearchInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}