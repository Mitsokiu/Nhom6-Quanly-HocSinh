namespace GUI
{
    partial class QuanLyLopHocControl
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
            this.lblHeader = new System.Windows.Forms.Label();

            // --- Panel Input ---
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblInputTitle = new System.Windows.Forms.Label();

            this.lblMaLop = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();

            this.lblTenLop = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();

            this.lblKhoi = new System.Windows.Forms.Label();
            this.cmbKhoi = new System.Windows.Forms.ComboBox();

            this.lblNamHoc = new System.Windows.Forms.Label();
            this.cmbNamHoc = new System.Windows.Forms.ComboBox();

            this.lblSiSo = new System.Windows.Forms.Label();
            this.txtSiSo = new System.Windows.Forms.TextBox();

            this.lblGVCN = new System.Windows.Forms.Label();
            this.cmbGVCN = new System.Windows.Forms.ComboBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();

            // --- Panel Data ---
            this.panelData = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFilterKhoi = new System.Windows.Forms.Button();
            this.btnFilterNamHoc = new System.Windows.Forms.Button();
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();

            // --- Pagination ---
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.lblPagingInfo = new System.Windows.Forms.Label();

            // --- Columns ---
            this.colMaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGVCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.panelInput.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(25, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(236, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Quản Lý Lớp Học";

            // 
            // panelInput
            // 
            this.panelInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // Viền nhẹ
            this.panelInput.Controls.Add(this.lblInputTitle);
            this.panelInput.Controls.Add(this.lblMaLop); this.panelInput.Controls.Add(this.txtMaLop);
            this.panelInput.Controls.Add(this.lblTenLop); this.panelInput.Controls.Add(this.txtTenLop);
            this.panelInput.Controls.Add(this.lblKhoi); this.panelInput.Controls.Add(this.cmbKhoi);
            this.panelInput.Controls.Add(this.lblNamHoc); this.panelInput.Controls.Add(this.cmbNamHoc);
            this.panelInput.Controls.Add(this.lblSiSo); this.panelInput.Controls.Add(this.txtSiSo);
            this.panelInput.Controls.Add(this.lblGVCN); this.panelInput.Controls.Add(this.cmbGVCN);
            this.panelInput.Controls.Add(this.btnThem);
            this.panelInput.Controls.Add(this.btnCapNhat);
            this.panelInput.Location = new System.Drawing.Point(30, 70);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(940, 200);
            this.panelInput.TabIndex = 1;

            // lblInputTitle
            this.lblInputTitle.AutoSize = true;
            this.lblInputTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInputTitle.Location = new System.Drawing.Point(20, 15);
            this.lblInputTitle.Text = "Thêm/Chỉnh Sửa Thông Tin Lớp Học";

            // Row 1 Inputs
            // Ma Lop
            this.lblMaLop.Location = new System.Drawing.Point(20, 50);
            this.lblMaLop.Text = "Mã lớp";
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.txtMaLop.Location = new System.Drawing.Point(20, 75);
            this.txtMaLop.Size = new System.Drawing.Size(120, 25);
            this.txtMaLop.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Ten Lop
            this.lblTenLop.Location = new System.Drawing.Point(160, 50);
            this.lblTenLop.Text = "Tên lớp";
            this.lblTenLop.AutoSize = true;

            this.txtTenLop.Location = new System.Drawing.Point(160, 75);
            this.txtTenLop.Size = new System.Drawing.Size(300, 25);
            this.txtTenLop.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Khoi
            this.lblKhoi.Location = new System.Drawing.Point(480, 50);
            this.lblKhoi.Text = "Khối lớp";
            this.lblKhoi.AutoSize = true;

            this.cmbKhoi.Location = new System.Drawing.Point(480, 75);
            this.cmbKhoi.Size = new System.Drawing.Size(120, 25);
            this.cmbKhoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKhoi.Items.AddRange(new object[] { "Khối 10", "Khối 11", "Khối 12" });

            // Nam Hoc
            this.lblNamHoc.Location = new System.Drawing.Point(620, 50);
            this.lblNamHoc.Text = "Năm học";
            this.lblNamHoc.AutoSize = true;

            this.cmbNamHoc.Location = new System.Drawing.Point(620, 75);
            this.cmbNamHoc.Size = new System.Drawing.Size(120, 25);
            this.cmbNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNamHoc.Items.AddRange(new object[] { "2023-2024", "2024-2025" });

            // Si So
            this.lblSiSo.Location = new System.Drawing.Point(760, 50);
            this.lblSiSo.Text = "Sĩ số";
            this.lblSiSo.AutoSize = true;

            this.txtSiSo.Location = new System.Drawing.Point(760, 75);
            this.txtSiSo.Size = new System.Drawing.Size(120, 25);
            this.txtSiSo.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Row 2 Inputs
            // GVCN
            this.lblGVCN.Location = new System.Drawing.Point(20, 115);
            this.lblGVCN.Text = "Giáo viên chủ nhiệm";
            this.lblGVCN.AutoSize = true;

            this.cmbGVCN.Location = new System.Drawing.Point(20, 140);
            this.cmbGVCN.Size = new System.Drawing.Size(440, 25);
            this.cmbGVCN.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Buttons
            this.btnThem.Location = new System.Drawing.Point(480, 135);
            this.btnThem.Size = new System.Drawing.Size(200, 35);
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(230, 234, 238); // Grayish
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThem.Text = "+ Thêm";

            this.btnCapNhat.Location = new System.Drawing.Point(700, 135);
            this.btnCapNhat.Size = new System.Drawing.Size(200, 35);
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(13, 110, 253); // Blue
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Text = "Cập nhật";

            // 
            // panelData
            // 
            this.panelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelData.BackColor = System.Drawing.Color.White;
            this.panelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelData.Controls.Add(this.txtSearch);
            this.panelData.Controls.Add(this.btnFilterKhoi);
            this.panelData.Controls.Add(this.btnFilterNamHoc);
            this.panelData.Controls.Add(this.dgvLopHoc);
            this.panelData.Controls.Add(this.panelPagination);
            this.panelData.Location = new System.Drawing.Point(30, 290);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(940, 440);
            this.panelData.TabIndex = 2;

            // Search
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Size = new System.Drawing.Size(350, 25);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Text = "Tìm theo tên hoặc mã lớp...";

            // Filters
            this.btnFilterKhoi.Location = new System.Drawing.Point(650, 18);
            this.btnFilterKhoi.Size = new System.Drawing.Size(120, 30);
            this.btnFilterKhoi.Text = "Lọc theo khối";
            this.btnFilterKhoi.BackColor = System.Drawing.Color.White;
            this.btnFilterKhoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterKhoi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            this.btnFilterNamHoc.Location = new System.Drawing.Point(780, 18);
            this.btnFilterNamHoc.Size = new System.Drawing.Size(140, 30);
            this.btnFilterNamHoc.Text = "Lọc theo năm học";
            this.btnFilterNamHoc.BackColor = System.Drawing.Color.White;
            this.btnFilterNamHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterNamHoc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // DataGridView
            this.dgvLopHoc.Location = new System.Drawing.Point(0, 65);
            this.dgvLopHoc.Size = new System.Drawing.Size(938, 320);
            this.dgvLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLopHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLopHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvLopHoc.AllowUserToAddRows = false;
            this.dgvLopHoc.RowHeadersVisible = false;
            this.dgvLopHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Grid Styles
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(247, 248, 250);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.dgvLopHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLopHoc.ColumnHeadersHeight = 40;
            this.dgvLopHoc.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(230, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvLopHoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLopHoc.RowTemplate.Height = 40;

            // Add Columns
            this.dgvLopHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaLop, this.colTenLop, this.colKhoi, this.colSiSo, this.colNamHoc, this.colGVCN, this.colActions
            });

            this.colMaLop.HeaderText = "MÃ LỚP"; this.colMaLop.Width = 100;
            this.colTenLop.HeaderText = "TÊN LỚP"; this.colTenLop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKhoi.HeaderText = "KHỐI"; this.colKhoi.Width = 80;
            this.colSiSo.HeaderText = "SĨ SỐ"; this.colSiSo.Width = 80;
            this.colNamHoc.HeaderText = "NĂM HỌC"; this.colNamHoc.Width = 120;
            this.colGVCN.HeaderText = "GVCN"; this.colGVCN.Width = 180;
            this.colActions.HeaderText = "HÀNH ĐỘNG"; this.colActions.Width = 100;

            // Pagination Panel
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Height = 50;
            this.panelPagination.Controls.Add(this.lblPagingInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnPage2);
            this.panelPagination.Controls.Add(this.btnPage1);
            this.panelPagination.Controls.Add(this.btnPrev);

            this.lblPagingInfo.Text = "Showing 1-3 of 100";
            this.lblPagingInfo.Location = new System.Drawing.Point(20, 15);
            this.lblPagingInfo.AutoSize = true;
            this.lblPagingInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // Pagination Buttons Setup (simplified locations)
            this.btnPrev.Text = "<"; this.btnPrev.Size = new System.Drawing.Size(35, 30); this.btnPrev.Location = new System.Drawing.Point(740, 10); this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPage1.Text = "1"; this.btnPage1.Size = new System.Drawing.Size(35, 30); this.btnPage1.Location = new System.Drawing.Point(780, 10); this.btnPage1.Anchor = System.Windows.Forms.AnchorStyles.Right; this.btnPage1.BackColor = System.Drawing.Color.FromArgb(230, 245, 255);
            this.btnPage2.Text = "2"; this.btnPage2.Size = new System.Drawing.Size(35, 30); this.btnPage2.Location = new System.Drawing.Point(820, 10); this.btnPage2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.Text = ">"; this.btnNext.Size = new System.Drawing.Size(35, 30); this.btnNext.Location = new System.Drawing.Point(860, 10); this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;

            // Main Control
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelData);
            this.Size = new System.Drawing.Size(1000, 750);
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 252); // Light Gray Background

            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;

        // Input Panel Elements
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblInputTitle;
        private System.Windows.Forms.Label lblMaLop, lblTenLop, lblKhoi, lblNamHoc, lblSiSo, lblGVCN;
        private System.Windows.Forms.TextBox txtMaLop, txtTenLop, txtSiSo;
        private System.Windows.Forms.ComboBox cmbKhoi, cmbNamHoc, cmbGVCN;
        private System.Windows.Forms.Button btnThem, btnCapNhat;

        // Data Panel Elements
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFilterKhoi, btnFilterNamHoc;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLop, colTenLop, colKhoi, colSiSo, colNamHoc, colGVCN, colActions;

        // Pagination Elements
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Label lblPagingInfo;
        private System.Windows.Forms.Button btnNext, btnPrev, btnPage1, btnPage2;
    }
}