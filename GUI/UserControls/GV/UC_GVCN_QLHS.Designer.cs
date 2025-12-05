namespace GUI.UserControls
{
    partial class UC_GVCN_QLHS
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnAddStudent;

        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportPDF; 

        // Search
        private System.Windows.Forms.Panel pnlSearch; // Container chính
        private System.Windows.Forms.Panel pnlSearchBox; // Hộp trắng bên trong
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox picSearchIcon;

        // Data Grid
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvStudents;

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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button(); 
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picSearchIcon = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // UC_GVCN_QLHS
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
            this.pnlHeader.Controls.Add(this.btnAddStudent);
            this.pnlHeader.Controls.Add(this.btnExportPDF);
            this.pnlHeader.Controls.Add(this.btnExportExcel); // Add control
            this.pnlHeader.Controls.Add(this.btnImportExcel); // Add control
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100; // Tăng chiều cao để chứa đủ nội dung
            this.pnlHeader.Location = new System.Drawing.Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1040, 100);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(0, 0); // Đặt lại tọa độ 0,0
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Học sinh";

            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(5, 55); // Dời xuống dưới Title
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(350, 23);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Xem, tìm kiếm và quản lý thông tin học sinh.";

            // 
            // btnAddStudent (Nút Xanh Dương - Ngoài cùng bên phải)
            // 
            this.btnAddStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStudent.FlatAppearance.BorderSize = 0;
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddStudent.Location = new System.Drawing.Point(880, 10);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(160, 40);
            this.btnAddStudent.TabIndex = 2;
            this.btnAddStudent.Text = "+ Thêm Học sinh";
            this.btnAddStudent.UseVisualStyleBackColor = false;

            // 
            // btnExportExcel (Nút Xuất - Màu xanh nhẹ hơn, tăng chiều rộng)
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // Đổi màu sang xanh lá tươi hơn (Excel Green)
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = global::GUI.Properties.Resources.xuatexcel_32;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // Cập nhật vị trí: 880 (nút Thêm) - 10 (khoảng cách) - 150 (chiều rộng nút này) = 720
            this.btnExportExcel.Location = new System.Drawing.Point(720, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            // Tăng chiều rộng lên 150 để không mất chữ
            this.btnExportExcel.Size = new System.Drawing.Size(150, 40);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = " Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;

            // 
            // btnImportExcel (Nút Nhập - Màu xanh nhẹ hơn, tăng chiều rộng)
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // Đổi màu giống nút Xuất
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnImportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportExcel.FlatAppearance.BorderSize = 0;
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Image = global::GUI.Properties.Resources.nhapexcel_32;
            this.btnImportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // Cập nhật vị trí: 720 (nút Xuất) - 10 (khoảng cách) - 150 (chiều rộng nút này) = 560
            this.btnImportExcel.Location = new System.Drawing.Point(560, 10);
            this.btnImportExcel.Name = "btnImportExcel";
            // Tăng chiều rộng lên 150 để hiện đủ chữ "Nhập Excel"
            this.btnImportExcel.Size = new System.Drawing.Size(150, 40);
            this.btnImportExcel.TabIndex = 4;
            this.btnImportExcel.Text = " Nhập Excel";
            this.btnImportExcel.UseVisualStyleBackColor = false;

            // 
            // btnExportPDF (Nút Mới - Màu Đỏ)
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(220, 53, 69); // Màu đỏ đặc trưng PDF
            this.btnExportPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Image = global::GUI.Properties.Resources.pdf_32; // Icon bạn yêu cầu
            this.btnExportPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportPDF.Location = new System.Drawing.Point(400, 10);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(150, 40);
            this.btnExportPDF.TabIndex = 5;
            this.btnExportPDF.Text = " Xuất PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            // 
            // pnlSearch (Container)
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.pnlSearchBox);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(30, 130);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlSearch.Size = new System.Drawing.Size(1040, 60);
            this.pnlSearch.TabIndex = 1;

            // 
            // pnlSearchBox (Hộp trắng bo viền)
            // 
            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.Controls.Add(this.picSearchIcon);
            this.pnlSearchBox.Location = new System.Drawing.Point(0, 10);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(400, 40);
            this.pnlSearchBox.TabIndex = 0;
            // Lưu ý: Cần bo tròn pnlSearchBox trong code .cs

            // 
            // picSearchIcon
            // 
            this.picSearchIcon.BackColor = System.Drawing.Color.Transparent;
            // Sử dụng Resource search_32
            this.picSearchIcon.Image = global::GUI.Properties.Resources.search_32;
            this.picSearchIcon.Location = new System.Drawing.Point(10, 8);
            this.picSearchIcon.Name = "picSearchIcon";
            this.picSearchIcon.Size = new System.Drawing.Size(24, 24);
            this.picSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearchIcon.TabIndex = 1;
            this.picSearchIcon.TabStop = false;

            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(45, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(340, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Tìm kiếm học sinh...";

            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvStudents);
            this.pnlContent.Controls.Add(this.pnlPagination);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(30, 190); // Dời xuống dưới Search
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(1040, 480);
            this.pnlContent.TabIndex = 2;

            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(160, 174, 192);
            headerStyle.SelectionBackColor = System.Drawing.Color.White;
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(160, 174, 192);
            this.dgvStudents.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvStudents.ColumnHeadersHeight = 45;

            rowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            rowStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.dgvStudents.DefaultCellStyle = rowStyle;

            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.Location = new System.Drawing.Point(0, 10);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.RowTemplate.Height = 55;
            this.dgvStudents.Size = new System.Drawing.Size(1040, 410);
            this.dgvStudents.TabIndex = 0;

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
            this.pnlPagination.Location = new System.Drawing.Point(0, 420);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1040, 60);
            this.pnlPagination.TabIndex = 1;

            // Buttons
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}