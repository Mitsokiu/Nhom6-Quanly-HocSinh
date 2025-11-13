namespace GUI
{
    partial class NhapDiemControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblChonLop = new System.Windows.Forms.Label();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.lblChonMonHoc = new System.Windows.Forms.Label();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMSHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemMieng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem15p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemGiuaKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemCuoiKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottomBar = new System.Windows.Forms.Panel();
            this.btnLuuThayDoi = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPage10 = new System.Windows.Forms.Button();
            this.lblPageDots = new System.Windows.Forms.Label();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.panelBottomBar.SuspendLayout();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(40, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Nhập điểm học sinh";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(45, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(325, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Chọn lớp và môn học để bắt đầu nhập điểm.";
            // 
            // lblChonLop
            // 
            this.lblChonLop.AutoSize = true;
            this.lblChonLop.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblChonLop.Location = new System.Drawing.Point(45, 120);
            this.lblChonLop.Name = "lblChonLop";
            this.lblChonLop.Size = new System.Drawing.Size(63, 17);
            this.lblChonLop.TabIndex = 2;
            this.lblChonLop.Text = "Chọn Lớp";
            // 
            // cmbLop
            // 
            this.cmbLop.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Items.AddRange(new object[] {
            "Lớp 10A1",
            "Lớp 10A2",
            "Lớp 11A1",
            "Lớp 12A1"});
            this.cmbLop.Location = new System.Drawing.Point(45, 145);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(300, 25);
            this.cmbLop.TabIndex = 3;
            this.cmbLop.Text = "Lớp 10A1";
            // 
            // lblChonMonHoc
            // 
            this.lblChonMonHoc.AutoSize = true;
            this.lblChonMonHoc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblChonMonHoc.Location = new System.Drawing.Point(375, 120);
            this.lblChonMonHoc.Name = "lblChonMonHoc";
            this.lblChonMonHoc.Size = new System.Drawing.Size(91, 17);
            this.lblChonMonHoc.TabIndex = 4;
            this.lblChonMonHoc.Text = "Chọn Môn học";
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Items.AddRange(new object[] {
            "Toán",
            "Vật Lý",
            "Hóa Học",
            "Ngữ Văn",
            "Anh Văn"});
            this.cmbMonHoc.Location = new System.Drawing.Point(375, 145);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(300, 25);
            this.cmbMonHoc.TabIndex = 5;
            this.cmbMonHoc.Text = "Toán";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Controls.Add(this.dgvDiem);
            this.panelContent.Controls.Add(this.panelBottomBar);
            this.panelContent.Location = new System.Drawing.Point(45, 190);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(910, 535);
            this.panelContent.TabIndex = 6;
            // 
            // dgvDiem
            // 
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiem.ColumnHeadersHeight = 40;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMSHS,
            this.colHoTen,
            this.colDiemMieng,
            this.colDiem15p,
            this.colDiemGiuaKy,
            this.colDiemCuoiKy,
            this.colDiemTB});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiem.EnableHeadersVisualStyles = false;
            this.dgvDiem.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDiem.Location = new System.Drawing.Point(0, 0);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dgvDiem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiem.RowTemplate.Height = 36;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDiem.Size = new System.Drawing.Size(908, 483);
            this.dgvDiem.TabIndex = 0;
            // 
            // colSTT
            // 
            this.colSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 69;
            // 
            // colMSHS
            // 
            this.colMSHS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMSHS.HeaderText = "Mã HS";
            this.colMSHS.Name = "colMSHS";
            this.colMSHS.ReadOnly = true;
            this.colMSHS.Width = 83;
            // 
            // colHoTen
            // 
            this.colHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHoTen.HeaderText = "Họ và tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colDiemMieng
            // 
            this.colDiemMieng.HeaderText = "Điểm miệng";
            this.colDiemMieng.Name = "colDiemMieng";
            // 
            // colDiem15p
            // 
            this.colDiem15p.HeaderText = "Điểm 15\'";
            this.colDiem15p.Name = "colDiem15p";
            // 
            // colDiemGiuaKy
            // 
            this.colDiemGiuaKy.HeaderText = "Điểm giữa kỳ";
            this.colDiemGiuaKy.Name = "colDiemGiuaKy";
            // 
            // colDiemCuoiKy
            // 
            this.colDiemCuoiKy.HeaderText = "Điểm cuối kỳ";
            this.colDiemCuoiKy.Name = "colDiemCuoiKy";
            // 
            // colDiemTB
            // 
            this.colDiemTB.HeaderText = "Điểm TB";
            this.colDiemTB.Name = "colDiemTB";
            this.colDiemTB.ReadOnly = true;
            // 
            // panelBottomBar
            // 
            this.panelBottomBar.Controls.Add(this.btnLuuThayDoi);
            this.panelBottomBar.Controls.Add(this.btnXuatExcel);
            this.panelBottomBar.Controls.Add(this.panelPagination);
            this.panelBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomBar.Location = new System.Drawing.Point(0, 483);
            this.panelBottomBar.Name = "panelBottomBar";
            this.panelBottomBar.Size = new System.Drawing.Size(908, 50);
            this.panelBottomBar.TabIndex = 4;
            // 
            // btnLuuThayDoi
            // 
            this.btnLuuThayDoi.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLuuThayDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLuuThayDoi.FlatAppearance.BorderSize = 0;
            this.btnLuuThayDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuThayDoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuThayDoi.ForeColor = System.Drawing.Color.White;
            this.btnLuuThayDoi.Location = new System.Drawing.Point(808, 0);
            this.btnLuuThayDoi.Margin = new System.Windows.Forms.Padding(10);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new System.Drawing.Size(100, 50);
            this.btnLuuThayDoi.TabIndex = 3;
            this.btnLuuThayDoi.Text = "Lưu thay đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnXuatExcel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(708, 0);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(10);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 50);
            this.btnXuatExcel.TabIndex = 2;
            this.btnXuatExcel.Text = "Xuất file Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnPage10);
            this.panelPagination.Controls.Add(this.lblPageDots);
            this.panelPagination.Controls.Add(this.btnPage3);
            this.panelPagination.Controls.Add(this.btnPage2);
            this.panelPagination.Controls.Add(this.btnPage1);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPagination.Location = new System.Drawing.Point(0, 0);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(400, 50);
            this.panelPagination.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(315, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPage10
            // 
            this.btnPage10.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage10.Location = new System.Drawing.Point(270, 10);
            this.btnPage10.Name = "btnPage10";
            this.btnPage10.Size = new System.Drawing.Size(30, 30);
            this.btnPage10.TabIndex = 15;
            this.btnPage10.Text = "10";
            this.btnPage10.UseVisualStyleBackColor = true;
            // 
            // lblPageDots
            // 
            this.lblPageDots.AutoSize = true;
            this.lblPageDots.Location = new System.Drawing.Point(249, 18);
            this.lblPageDots.Name = "lblPageDots";
            this.lblPageDots.Size = new System.Drawing.Size(16, 13);
            this.lblPageDots.TabIndex = 14;
            this.lblPageDots.Text = "...";
            // 
            // btnPage3
            // 
            this.btnPage3.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3.Location = new System.Drawing.Point(213, 10);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(30, 30);
            this.btnPage3.TabIndex = 13;
            this.btnPage3.Text = "3";
            this.btnPage3.UseVisualStyleBackColor = true;
            // 
            // btnPage2
            // 
            this.btnPage2.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2.Location = new System.Drawing.Point(177, 10);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(30, 30);
            this.btnPage2.TabIndex = 12;
            this.btnPage2.Text = "2";
            this.btnPage2.UseVisualStyleBackColor = true;
            // 
            // btnPage1
            // 
            this.btnPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnPage1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Location = new System.Drawing.Point(141, 10);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(30, 30);
            this.btnPage1.TabIndex = 11;
            this.btnPage1.Text = "1";
            this.btnPage1.UseVisualStyleBackColor = false;
            // 
            // btnPrev
            // 
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(105, 10);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(30, 30);
            this.btnPrev.TabIndex = 10;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // NhapDiemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.cmbMonHoc);
            this.Controls.Add(this.lblChonMonHoc);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(this.lblChonLop);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "NhapDiemControl";
            this.Size = new System.Drawing.Size(1000, 750);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.panelBottomBar.ResumeLayout(false);
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblChonLop;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.Label lblChonMonHoc;
        private System.Windows.Forms.ComboBox cmbMonHoc;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPage10;
        private System.Windows.Forms.Label lblPageDots;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnLuuThayDoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemMieng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem15p;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemGiuaKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemCuoiKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemTB;
        private System.Windows.Forms.Panel panelBottomBar;
    }
}