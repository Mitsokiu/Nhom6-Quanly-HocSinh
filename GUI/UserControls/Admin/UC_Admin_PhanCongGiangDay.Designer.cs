namespace GUI.UserControls.Admin
{
    partial class UC_Admin_PhanCongGiangDay
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGiaoVien = new System.Windows.Forms.DataGridView();
            this.colMaGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimKiemGV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbLopHoc = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cbbMonHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbHocKy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPhanCong = new System.Windows.Forms.DataGridView();
            this.colPCMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPCLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPCHocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPCXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoVien)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 600);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGiaoVien);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 590);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Giáo viên";
            // 
            // dgvGiaoVien
            // 
            this.dgvGiaoVien.AllowUserToAddRows = false;
            this.dgvGiaoVien.AllowUserToDeleteRows = false;
            this.dgvGiaoVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaGV,
            this.colTenGV});
            this.dgvGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGiaoVien.Location = new System.Drawing.Point(3, 63);
            this.dgvGiaoVien.MultiSelect = false;
            this.dgvGiaoVien.Name = "dgvGiaoVien";
            this.dgvGiaoVien.ReadOnly = true;
            this.dgvGiaoVien.RowHeadersVisible = false;
            this.dgvGiaoVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGiaoVien.Size = new System.Drawing.Size(334, 524);
            this.dgvGiaoVien.TabIndex = 1;
            // 
            // colMaGV
            // 
            this.colMaGV.HeaderText = "Mã GV";
            this.colMaGV.Name = "colMaGV";
            this.colMaGV.ReadOnly = true;
            this.colMaGV.Width = 80;
            // 
            // colTenGV
            // 
            this.colTenGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenGV.HeaderText = "Họ tên";
            this.colTenGV.Name = "colTenGV";
            this.colTenGV.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTimKiemGV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 42);
            this.panel1.TabIndex = 0;
            // 
            // txtTimKiemGV
            // 
            this.txtTimKiemGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiemGV.Location = new System.Drawing.Point(75, 8);
            this.txtTimKiemGV.Name = "txtTimKiemGV";
            this.txtTimKiemGV.Size = new System.Drawing.Size(248, 25);
            this.txtTimKiemGV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(5, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(636, 590);
            this.splitContainer2.SplitterDistance = 330;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbLopHoc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Controls.Add(this.cbbMonHoc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbbHocKy);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 330);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Phân công";
            // 
            // clbLopHoc
            // 
            this.clbLopHoc.CheckOnClick = true;
            this.clbLopHoc.FormattingEnabled = true;
            this.clbLopHoc.Location = new System.Drawing.Point(120, 105);
            this.clbLopHoc.Name = "clbLopHoc";
            this.clbLopHoc.Size = new System.Drawing.Size(510, 164);
            this.clbLopHoc.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Chọn lớp dạy:";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(120, 280);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 40);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu Phân Công";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonHoc.FormattingEnabled = true;
            this.cbbMonHoc.Location = new System.Drawing.Point(120, 65);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(300, 25);
            this.cbbMonHoc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Môn học:";
            // 
            // cbbHocKy
            // 
            this.cbbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHocKy.FormattingEnabled = true;
            this.cbbHocKy.Location = new System.Drawing.Point(120, 30);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(300, 25);
            this.cbbHocKy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Năm/Học kỳ:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPhanCong);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(636, 256);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách Đã phân công (Của giáo viên đang chọn)";
            // 
            // dgvPhanCong
            // 
            this.dgvPhanCong.AllowUserToAddRows = false;
            this.dgvPhanCong.AllowUserToDeleteRows = false;
            this.dgvPhanCong.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPCMon,
            this.colPCLop,
            this.colPCHocKy,
            this.colPCXoa});
            this.dgvPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanCong.Location = new System.Drawing.Point(3, 21);
            this.dgvPhanCong.Name = "dgvPhanCong";
            this.dgvPhanCong.ReadOnly = true;
            this.dgvPhanCong.RowHeadersVisible = false;
            this.dgvPhanCong.Size = new System.Drawing.Size(630, 232);
            this.dgvPhanCong.TabIndex = 0;
            // 
            // colPCMon
            // 
            this.colPCMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPCMon.HeaderText = "Môn học";
            this.colPCMon.Name = "colPCMon";
            this.colPCMon.ReadOnly = true;
            // 
            // colPCLop
            // 
            this.colPCLop.HeaderText = "Lớp";
            this.colPCLop.Name = "colPCLop";
            this.colPCLop.ReadOnly = true;
            this.colPCLop.Width = 80;
            // 
            // colPCHocKy
            // 
            this.colPCHocKy.HeaderText = "Học kỳ";
            this.colPCHocKy.Name = "colPCHocKy";
            this.colPCHocKy.ReadOnly = true;
            this.colPCHocKy.Width = 150;
            // 
            // colPCXoa
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            this.colPCXoa.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPCXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPCXoa.HeaderText = "Thao tác";
            this.colPCXoa.Name = "colPCXoa";
            this.colPCXoa.ReadOnly = true;
            this.colPCXoa.Text = "Xóa";
            this.colPCXoa.UseColumnTextForButtonValue = true;
            this.colPCXoa.Width = 80;
            // 
            // UC_Admin_PhanCongGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UC_Admin_PhanCongGiangDay";
            this.Size = new System.Drawing.Size(1000, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoVien)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGiaoVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimKiemGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenGV;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbLopHoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cbbMonHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbHocKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPhanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCHocKy;
        private System.Windows.Forms.DataGridViewButtonColumn colPCXoa;
    }
}