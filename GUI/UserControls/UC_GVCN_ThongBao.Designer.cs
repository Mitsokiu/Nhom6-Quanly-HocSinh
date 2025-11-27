namespace GUI.UserControls
{
    partial class UC_GVCN_ThongBao
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnCreate;

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox picSearchIcon;

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvThongBao;

        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Button btnPageLast;
        private System.Windows.Forms.Label lblDots;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
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
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // Main Control
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Size = new System.Drawing.Size(1100, 700);

            // 
            // Header
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnCreate);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100;
            this.pnlHeader.Location = new System.Drawing.Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1040, 100);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Text = "Quản lý Thông báo";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(5, 55);
            this.lblSubTitle.Text = "Gửi thông báo cho học sinh lớp chủ nhiệm.";

            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(880, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(160, 40);
            this.btnCreate.Text = "+ Tạo Thông báo";
            this.btnCreate.UseVisualStyleBackColor = false;

            // 
            // Search
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.pnlSearchBox);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(30, 130);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlSearch.Size = new System.Drawing.Size(1040, 60);

            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.Controls.Add(this.picSearchIcon);
            this.pnlSearchBox.Location = new System.Drawing.Point(0, 10);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(400, 40);

            this.picSearchIcon.BackColor = System.Drawing.Color.Transparent;
            this.picSearchIcon.Image = global::GUI.Properties.Resources.search_32; // ICON SEARCH_32
            this.picSearchIcon.Location = new System.Drawing.Point(10, 8);
            this.picSearchIcon.Name = "picSearchIcon";
            this.picSearchIcon.Size = new System.Drawing.Size(24, 24);
            this.picSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(45, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(340, 25);
            this.txtSearch.Text = "Tìm kiếm thông báo...";

            // 
            // Grid Content
            // 
            this.pnlContent.Controls.Add(this.dgvThongBao);
            this.pnlContent.Controls.Add(this.pnlPagination);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(30, 190);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(1040, 480);

            this.dgvThongBao.AllowUserToAddRows = false;
            this.dgvThongBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongBao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongBao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(160, 174, 192);
            headerStyle.SelectionBackColor = System.Drawing.Color.White;
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(160, 174, 192);
            this.dgvThongBao.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvThongBao.ColumnHeadersHeight = 45;

            rowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            rowStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.dgvThongBao.DefaultCellStyle = rowStyle;

            this.dgvThongBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongBao.EnableHeadersVisualStyles = false;
            this.dgvThongBao.Location = new System.Drawing.Point(0, 10);
            this.dgvThongBao.Name = "dgvThongBao";
            this.dgvThongBao.RowHeadersVisible = false;
            this.dgvThongBao.RowTemplate.Height = 55;
            this.dgvThongBao.Size = new System.Drawing.Size(1040, 410);

            // 
            // Pagination
            // 
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

            // Button Styles
            this.btnNext.Size = new System.Drawing.Size(35, 35); this.btnNext.Text = ">"; this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnPrev.Size = new System.Drawing.Size(35, 35); this.btnPrev.Text = "<"; this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPageLast.Size = new System.Drawing.Size(35, 35); this.btnPageLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPageLast.FlatAppearance.BorderSize = 0;
            this.btnPage3.Size = new System.Drawing.Size(35, 35); this.btnPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPage3.FlatAppearance.BorderSize = 0;
            this.btnPage2.Size = new System.Drawing.Size(35, 35); this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPage2.FlatAppearance.BorderSize = 0;
            this.btnPage1.Size = new System.Drawing.Size(35, 35); this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPage1.FlatAppearance.BorderSize = 0;
            this.lblDots.AutoSize = true; this.lblDots.Font = new System.Drawing.Font("Segoe UI", 12F); this.lblDots.Text = "...";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}