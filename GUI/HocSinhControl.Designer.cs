namespace GUI
{
    partial class HocSinhControl
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.cboxLopHoc = new System.Windows.Forms.ComboBox();
            this.cboxGioiTinh = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinhColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinhColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LienHeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.btnTimKiem);
            this.panelTitle.Controls.Add(this.textBox1);
            this.panelTitle.Controls.Add(this.cboxGioiTinh);
            this.panelTitle.Controls.Add(this.cboxLopHoc);
            this.panelTitle.Controls.Add(this.lbTitle);
            this.panelTitle.Location = new System.Drawing.Point(14, 13);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(919, 100);
            this.panelTitle.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitle.Location = new System.Drawing.Point(22, 11);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(164, 19);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Danh sách học sinh";
            // 
            // cboxLopHoc
            // 
            this.cboxLopHoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxLopHoc.ForeColor = System.Drawing.Color.DimGray;
            this.cboxLopHoc.FormattingEnabled = true;
            this.cboxLopHoc.Location = new System.Drawing.Point(26, 52);
            this.cboxLopHoc.Name = "cboxLopHoc";
            this.cboxLopHoc.Size = new System.Drawing.Size(160, 26);
            this.cboxLopHoc.TabIndex = 1;
            this.cboxLopHoc.Text = "Lớp học";
            // 
            // cboxGioiTinh
            // 
            this.cboxGioiTinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxGioiTinh.ForeColor = System.Drawing.Color.DimGray;
            this.cboxGioiTinh.FormattingEnabled = true;
            this.cboxGioiTinh.Location = new System.Drawing.Point(204, 52);
            this.cboxGioiTinh.Name = "cboxGioiTinh";
            this.cboxGioiTinh.Size = new System.Drawing.Size(124, 26);
            this.cboxGioiTinh.TabIndex = 2;
            this.cboxGioiTinh.Text = "Giới tính";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(427, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(286, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Nhập nội dung tìm kiếm...";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTimKiem.Image = global::GUI.Properties.Resources.timkiem_24;
            this.btnTimKiem.Location = new System.Drawing.Point(662, 14);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(51, 25);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Location = new System.Drawing.Point(15, 137);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(918, 489);
            this.panelMain.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTColumn,
            this.HoTenColumn,
            this.GioiTinhColumn,
            this.NgaySinhColumn,
            this.DiaChiColumn,
            this.LienHeColumn});
            this.dataGridView1.Location = new System.Drawing.Point(25, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(884, 453);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // STTColumn
            // 
            this.STTColumn.Frozen = true;
            this.STTColumn.HeaderText = "STT";
            this.STTColumn.MinimumWidth = 6;
            this.STTColumn.Name = "STTColumn";
            this.STTColumn.Width = 125;
            // 
            // HoTenColumn
            // 
            this.HoTenColumn.HeaderText = "Họ tên";
            this.HoTenColumn.MinimumWidth = 6;
            this.HoTenColumn.Name = "HoTenColumn";
            this.HoTenColumn.Width = 125;
            // 
            // GioiTinhColumn
            // 
            this.GioiTinhColumn.HeaderText = "Giới tính";
            this.GioiTinhColumn.MinimumWidth = 6;
            this.GioiTinhColumn.Name = "GioiTinhColumn";
            this.GioiTinhColumn.Width = 125;
            // 
            // NgaySinhColumn
            // 
            this.NgaySinhColumn.HeaderText = "Ngày sinh";
            this.NgaySinhColumn.MinimumWidth = 6;
            this.NgaySinhColumn.Name = "NgaySinhColumn";
            this.NgaySinhColumn.Width = 125;
            // 
            // DiaChiColumn
            // 
            this.DiaChiColumn.HeaderText = "Địa chỉ";
            this.DiaChiColumn.MinimumWidth = 6;
            this.DiaChiColumn.Name = "DiaChiColumn";
            this.DiaChiColumn.Width = 125;
            // 
            // LienHeColumn
            // 
            this.LienHeColumn.HeaderText = "Liên hệ";
            this.LienHeColumn.MinimumWidth = 6;
            this.LienHeColumn.Name = "LienHeColumn";
            this.LienHeColumn.Width = 125;
            // 
            // HocSinhControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitle);
            this.Name = "HocSinhControl";
            this.Size = new System.Drawing.Size(949, 639);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboxGioiTinh;
        private System.Windows.Forms.ComboBox cboxLopHoc;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinhColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinhColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LienHeColumn;
    }
}
