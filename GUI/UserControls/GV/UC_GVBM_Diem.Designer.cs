namespace GUI.UserControls
{
    partial class UC_GVBM_Diem
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.cbbMonHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbLop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbHocKy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemMieng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem15p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem1Tiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemGiuaKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemCuoiKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnLuu);
            this.panelTop.Controls.Add(this.btnXem);
            this.panelTop.Controls.Add(this.cbbMonHoc);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.cbbLop);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.cbbHocKy);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Image = global::GUI.Properties.Resources.nhapdiem_32;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(857, 19);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu điểm";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(680, 24);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 30);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Tải danh sách";
            this.btnXem.UseVisualStyleBackColor = false;
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMonHoc.FormattingEnabled = true;
            this.cbbMonHoc.Location = new System.Drawing.Point(490, 27);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(160, 25);
            this.cbbMonHoc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(445, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Môn:";
            // 
            // cbbLop
            // 
            this.cbbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLop.FormattingEnabled = true;
            this.cbbLop.Location = new System.Drawing.Point(300, 27);
            this.cbbLop.Name = "cbbLop";
            this.cbbLop.Size = new System.Drawing.Size(120, 25);
            this.cbbLop.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lớp:";
            // 
            // cbbHocKy
            // 
            this.cbbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHocKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHocKy.FormattingEnabled = true;
            this.cbbHocKy.Location = new System.Drawing.Point(80, 27);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(160, 25);
            this.cbbHocKy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Học kỳ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBangDiem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 520);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng điểm chi tiết";
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.AllowUserToAddRows = false;
            this.dgvBangDiem.AllowUserToDeleteRows = false;
            this.dgvBangDiem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBangDiem.ColumnHeadersHeight = 35;
            this.dgvBangDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaHS,
            this.colTenHS,
            this.colDiemMieng,
            this.colDiem15p,
            this.colDiem1Tiet,
            this.colDiemGiuaKy,
            this.colDiemCuoiKy,
            this.colDiemTB});
            this.dgvBangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangDiem.Location = new System.Drawing.Point(3, 21);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.RowHeadersVisible = false;
            this.dgvBangDiem.RowTemplate.Height = 30;
            this.dgvBangDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBangDiem.Size = new System.Drawing.Size(994, 496);
            this.dgvBangDiem.TabIndex = 0;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 50;
            // 
            // colMaHS
            // 
            this.colMaHS.HeaderText = "Mã HS";
            this.colMaHS.Name = "colMaHS";
            this.colMaHS.ReadOnly = true;
            this.colMaHS.Width = 100;
            // 
            // colTenHS
            // 
            this.colTenHS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenHS.HeaderText = "Họ và Tên";
            this.colTenHS.Name = "colTenHS";
            this.colTenHS.ReadOnly = true;
            // 
            // colDiemMieng
            // 
            this.colDiemMieng.HeaderText = "Miệng";
            this.colDiemMieng.Name = "colDiemMieng";
            this.colDiemMieng.Width = 80;
            // 
            // colDiem15p
            // 
            this.colDiem15p.HeaderText = "15 Phút";
            this.colDiem15p.Name = "colDiem15p";
            this.colDiem15p.Width = 80;
            // 
            // colDiem1Tiet
            // 
            this.colDiem1Tiet.HeaderText = "1 Tiết";
            this.colDiem1Tiet.Name = "colDiem1Tiet";
            this.colDiem1Tiet.Width = 80;
            // 
            // colDiemGiuaKy
            // 
            this.colDiemGiuaKy.HeaderText = "Giữa Kỳ";
            this.colDiemGiuaKy.Name = "colDiemGiuaKy";
            this.colDiemGiuaKy.Width = 80;
            // 
            // colDiemCuoiKy
            // 
            this.colDiemCuoiKy.HeaderText = "Cuối Kỳ";
            this.colDiemCuoiKy.Name = "colDiemCuoiKy";
            this.colDiemCuoiKy.Width = 80;
            // 
            // colDiemTB
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.colDiemTB.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDiemTB.HeaderText = "TBM";
            this.colDiemTB.Name = "colDiemTB";
            this.colDiemTB.ReadOnly = true;
            this.colDiemTB.Width = 80;
            // 
            // UC_GVBM_Diem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelTop);
            this.Name = "UC_GVBM_Diem";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbHocKy;
        private System.Windows.Forms.ComboBox cbbMonHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBangDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemMieng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem15p;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem1Tiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemGiuaKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemCuoiKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemTB;
    }
}