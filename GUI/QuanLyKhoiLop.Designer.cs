namespace GUI
{
    partial class QuanLyKhoiLop
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

            // --- Panel Left (Input) ---
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblInputHeader = new System.Windows.Forms.Label();
            this.lblMaKhoi = new System.Windows.Forms.Label();
            this.txtMaKhoi = new System.Windows.Forms.TextBox();
            this.lblTenKhoi = new System.Windows.Forms.Label();
            this.txtTenKhoi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();

            // --- Panel Right (List) ---
            this.panelList = new System.Windows.Forms.Panel();
            this.lblListHeader = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvKhoiLop = new System.Windows.Forms.DataGridView();
            this.colMaKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.panelInput.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoiLop)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Khối lớp";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(32, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(450, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Thêm mới hoặc chỉnh sửa thông tin các khối lớp trong hệ thống.";

            // 
            // panelInput (Left Side)
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.None; // Flat look like card
            this.panelInput.Controls.Add(this.lblInputHeader);
            this.panelInput.Controls.Add(this.lblMaKhoi);
            this.panelInput.Controls.Add(this.txtMaKhoi);
            this.panelInput.Controls.Add(this.lblTenKhoi);
            this.panelInput.Controls.Add(this.txtTenKhoi);
            this.panelInput.Controls.Add(this.btnThem);
            this.panelInput.Controls.Add(this.btnCapNhat);
            this.panelInput.Location = new System.Drawing.Point(30, 120);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(350, 350);
            this.panelInput.TabIndex = 2;

            // lblInputHeader
            this.lblInputHeader.AutoSize = true;
            this.lblInputHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblInputHeader.Location = new System.Drawing.Point(20, 20);
            this.lblInputHeader.Text = "Thông tin khối lớp";

            // lblMaKhoi
            this.lblMaKhoi.AutoSize = true;
            this.lblMaKhoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaKhoi.Location = new System.Drawing.Point(22, 70);
            this.lblMaKhoi.Text = "Mã khối";

            // txtMaKhoi
            this.txtMaKhoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaKhoi.ForeColor = System.Drawing.Color.Gray;
            this.txtMaKhoi.Location = new System.Drawing.Point(25, 95);
            this.txtMaKhoi.Name = "txtMaKhoi";
            this.txtMaKhoi.Size = new System.Drawing.Size(300, 27);
            this.txtMaKhoi.Text = "Ví dụ: K10";

            // lblTenKhoi
            this.lblTenKhoi.AutoSize = true;
            this.lblTenKhoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenKhoi.Location = new System.Drawing.Point(22, 145);
            this.lblTenKhoi.Text = "Tên khối";

            // txtTenKhoi
            this.txtTenKhoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenKhoi.Location = new System.Drawing.Point(25, 170);
            this.txtTenKhoi.Name = "txtTenKhoi";
            this.txtTenKhoi.Size = new System.Drawing.Size(300, 27);
            this.txtTenKhoi.Text = "Khối 11";

            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(13, 110, 253); // Blue
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 230);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(140, 40);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;

            // btnCapNhat
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(224, 224, 224); // Gray
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnCapNhat.Location = new System.Drawing.Point(185, 230);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(140, 40);
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;

            // 
            // panelList (Right Side)
            // 
            this.panelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelList.BackColor = System.Drawing.Color.White;
            this.panelList.Controls.Add(this.lblListHeader);
            this.panelList.Controls.Add(this.txtSearch);
            this.panelList.Controls.Add(this.dgvKhoiLop);
            this.panelList.Location = new System.Drawing.Point(410, 120);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(560, 400);
            this.panelList.TabIndex = 3;

            // lblListHeader
            this.lblListHeader.AutoSize = true;
            this.lblListHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblListHeader.Location = new System.Drawing.Point(20, 20);
            this.lblListHeader.Text = "Danh sách Khối lớp";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(25, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(510, 27);
            this.txtSearch.Text = "   Tìm kiếm theo mã hoặc tên khối...";
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            // dgvKhoiLop
            this.dgvKhoiLop.AllowUserToAddRows = false;
            this.dgvKhoiLop.AllowUserToDeleteRows = false;
            this.dgvKhoiLop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhoiLop.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoiLop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhoiLop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhoiLop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            this.dgvKhoiLop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhoiLop.ColumnHeadersHeight = 40;

            this.dgvKhoiLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaKhoi,
                this.colTenKhoi,
                this.colActions
            });

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(230, 242, 255); // Light blue highlight
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvKhoiLop.DefaultCellStyle = dataGridViewCellStyle2;

            this.dgvKhoiLop.EnableHeadersVisualStyles = false;
            this.dgvKhoiLop.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKhoiLop.Location = new System.Drawing.Point(0, 110);
            this.dgvKhoiLop.Name = "dgvKhoiLop";
            this.dgvKhoiLop.ReadOnly = true;
            this.dgvKhoiLop.RowHeadersVisible = false;
            this.dgvKhoiLop.RowTemplate.Height = 45;
            this.dgvKhoiLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoiLop.Size = new System.Drawing.Size(560, 290);
            this.dgvKhoiLop.TabIndex = 0;

            // colMaKhoi
            this.colMaKhoi.HeaderText = "MÃ KHỐI";
            this.colMaKhoi.Name = "colMaKhoi";
            this.colMaKhoi.ReadOnly = true;
            this.colMaKhoi.Width = 150;

            // colTenKhoi
            this.colTenKhoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenKhoi.HeaderText = "TÊN KHỐI";
            this.colTenKhoi.Name = "colTenKhoi";
            this.colTenKhoi.ReadOnly = true;

            // colActions
            this.colActions.HeaderText = "HÀNH ĐỘNG";
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Width = 120;

            // 
            // QuanLyKhoiLop (UserControl)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 252); // Light Gray Background
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "QuanLyKhoiLop";
            this.Size = new System.Drawing.Size(1000, 600);

            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoiLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblInputHeader;
        private System.Windows.Forms.Label lblMaKhoi;
        private System.Windows.Forms.TextBox txtMaKhoi;
        private System.Windows.Forms.Label lblTenKhoi;
        private System.Windows.Forms.TextBox txtTenKhoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Label lblListHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvKhoiLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActions;
    }
}