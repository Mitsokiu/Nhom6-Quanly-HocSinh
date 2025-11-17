namespace GUI
{
    partial class QuanLyMonHoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblInputHeader = new System.Windows.Forms.Label();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblSoTiet = new System.Windows.Forms.Label();
            this.txtSoTiet = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.panelList = new System.Windows.Forms.Panel();
            this.lblListHeader = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.colMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.lblPagingInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.panelInput.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(33, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(342, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Môn học";
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.lblInputHeader);
            this.panelInput.Controls.Add(this.lblMaMon);
            this.panelInput.Controls.Add(this.txtMaMon);
            this.panelInput.Controls.Add(this.lblTenMon);
            this.panelInput.Controls.Add(this.txtTenMon);
            this.panelInput.Controls.Add(this.lblSoTiet);
            this.panelInput.Controls.Add(this.txtSoTiet);
            this.panelInput.Controls.Add(this.btnThem);
            this.panelInput.Controls.Add(this.btnCapNhat);
            this.panelInput.Location = new System.Drawing.Point(40, 111);
            this.panelInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(467, 591);
            this.panelInput.TabIndex = 1;
            // 
            // lblInputHeader
            // 
            this.lblInputHeader.AutoSize = true;
            this.lblInputHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblInputHeader.Location = new System.Drawing.Point(27, 25);
            this.lblInputHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputHeader.Name = "lblInputHeader";
            this.lblInputHeader.Size = new System.Drawing.Size(233, 32);
            this.lblInputHeader.TabIndex = 0;
            this.lblInputHeader.Text = "Thông tin Môn học";
            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaMon.Location = new System.Drawing.Point(33, 86);
            this.lblMaMon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(107, 23);
            this.lblMaMon.TabIndex = 1;
            this.lblMaMon.Text = "Mã môn học";
            // 
            // txtMaMon
            // 
            this.txtMaMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaMon.ForeColor = System.Drawing.Color.Gray;
            this.txtMaMon.Location = new System.Drawing.Point(33, 117);
            this.txtMaMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(399, 30);
            this.txtMaMon.TabIndex = 2;
            this.txtMaMon.Text = "Ví dụ: TOAN10";
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenMon.Location = new System.Drawing.Point(33, 178);
            this.lblTenMon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(109, 23);
            this.lblTenMon.TabIndex = 3;
            this.lblTenMon.Text = "Tên môn học";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenMon.ForeColor = System.Drawing.Color.Gray;
            this.txtTenMon.Location = new System.Drawing.Point(33, 209);
            this.txtTenMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(399, 30);
            this.txtTenMon.TabIndex = 4;
            this.txtTenMon.Text = "Ví dụ: Toán lớp 10";
            // 
            // lblSoTiet
            // 
            this.lblSoTiet.AutoSize = true;
            this.lblSoTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoTiet.Location = new System.Drawing.Point(33, 271);
            this.lblSoTiet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoTiet.Name = "lblSoTiet";
            this.lblSoTiet.Size = new System.Drawing.Size(59, 23);
            this.lblSoTiet.TabIndex = 5;
            this.lblSoTiet.Text = "Số tiết";
            // 
            // txtSoTiet
            // 
            this.txtSoTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoTiet.ForeColor = System.Drawing.Color.Gray;
            this.txtSoTiet.Location = new System.Drawing.Point(33, 302);
            this.txtSoTiet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoTiet.Name = "txtSoTiet";
            this.txtSoTiet.Size = new System.Drawing.Size(399, 30);
            this.txtSoTiet.TabIndex = 6;
            this.txtSoTiet.Text = "Ví dụ: 90";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(33, 382);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(187, 55);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.White;
            this.btnCapNhat.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.Black;
            this.btnCapNhat.Location = new System.Drawing.Point(247, 382);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(187, 55);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            // 
            // panelList
            // 
            this.panelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelList.BackColor = System.Drawing.Color.White;
            this.panelList.Controls.Add(this.lblListHeader);
            this.panelList.Controls.Add(this.txtSearch);
            this.panelList.Controls.Add(this.dgvMonHoc);
            this.panelList.Controls.Add(this.panelPagination);
            this.panelList.Location = new System.Drawing.Point(547, 111);
            this.panelList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(987, 591);
            this.panelList.TabIndex = 2;
            // 
            // lblListHeader
            // 
            this.lblListHeader.AutoSize = true;
            this.lblListHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblListHeader.Location = new System.Drawing.Point(27, 25);
            this.lblListHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListHeader.Name = "lblListHeader";
            this.lblListHeader.Size = new System.Drawing.Size(239, 32);
            this.lblListHeader.TabIndex = 0;
            this.lblListHeader.Text = "Danh sách Môn học";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(480, 22);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(479, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "   Tìm kiếm môn học...";
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.AllowUserToAddRows = false;
            this.dgvMonHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMonHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMonHoc.ColumnHeadersHeight = 45;
            this.dgvMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMon,
            this.colTenMon,
            this.colSoTiet,
            this.colActions});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonHoc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMonHoc.EnableHeadersVisualStyles = false;
            this.dgvMonHoc.Location = new System.Drawing.Point(0, 86);
            this.dgvMonHoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersVisible = false;
            this.dgvMonHoc.RowHeadersWidth = 51;
            this.dgvMonHoc.RowTemplate.Height = 50;
            this.dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonHoc.Size = new System.Drawing.Size(987, 418);
            this.dgvMonHoc.TabIndex = 2;
            // 
            // colMaMon
            // 
            this.colMaMon.HeaderText = "MÃ MÔN HỌC";
            this.colMaMon.MinimumWidth = 6;
            this.colMaMon.Name = "colMaMon";
            this.colMaMon.ReadOnly = true;
            this.colMaMon.Width = 150;
            // 
            // colTenMon
            // 
            this.colTenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenMon.HeaderText = "TÊN MÔN HỌC";
            this.colTenMon.MinimumWidth = 6;
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            // 
            // colSoTiet
            // 
            this.colSoTiet.HeaderText = "SỐ TIẾT";
            this.colSoTiet.MinimumWidth = 6;
            this.colSoTiet.Name = "colSoTiet";
            this.colSoTiet.ReadOnly = true;
            // 
            // colActions
            // 
            this.colActions.HeaderText = "HÀNH ĐỘNG";
            this.colActions.MinimumWidth = 6;
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Width = 120;
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.lblPagingInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnPage2);
            this.panelPagination.Controls.Add(this.btnPage1);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(0, 517);
            this.panelPagination.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(987, 74);
            this.panelPagination.TabIndex = 3;
            // 
            // lblPagingInfo
            // 
            this.lblPagingInfo.AutoSize = true;
            this.lblPagingInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPagingInfo.Location = new System.Drawing.Point(27, 25);
            this.lblPagingInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPagingInfo.Name = "lblPagingInfo";
            this.lblPagingInfo.Size = new System.Drawing.Size(142, 20);
            this.lblPagingInfo.TabIndex = 0;
            this.lblPagingInfo.Text = "Hiển thị 1-4 của 10";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.Location = new System.Drawing.Point(1627, 15);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(47, 43);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            // 
            // btnPage2
            // 
            this.btnPage2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.btnPage2.Location = new System.Drawing.Point(1567, 15);
            this.btnPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(47, 43);
            this.btnPage2.TabIndex = 2;
            this.btnPage2.Text = "2";
            this.btnPage2.UseVisualStyleBackColor = false;
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPage1.Location = new System.Drawing.Point(1507, 15);
            this.btnPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(47, 43);
            this.btnPage1.TabIndex = 3;
            this.btnPage1.Text = "1";
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrev.Location = new System.Drawing.Point(1447, 15);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(47, 43);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "<";
            // 
            // QuanLyMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QuanLyMonHoc";
            this.Size = new System.Drawing.Size(1573, 800);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblInputHeader;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblSoTiet;
        private System.Windows.Forms.TextBox txtSoTiet;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Label lblListHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActions;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Label lblPagingInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
    }
}