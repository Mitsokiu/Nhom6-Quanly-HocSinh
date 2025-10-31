namespace Studenapp.UserControls
{
    partial class UC_HocSinh_Diem
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
            dataGridView1 = new DataGridView();
            MonHoc = new DataGridViewTextBoxColumn();
            Mieng = new DataGridViewTextBoxColumn();
            muoilamp = new DataGridViewTextBoxColumn();
            mottiet = new DataGridViewTextBoxColumn();
            CuoiKi = new DataGridViewTextBoxColumn();
            Tb = new DataGridViewTextBoxColumn();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { MonHoc, Mieng, muoilamp, mottiet, CuoiKi, Tb });
            dataGridView1.Location = new Point(300, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(964, 626);
            dataGridView1.TabIndex = 0;
            // 
            // MonHoc
            // 
            MonHoc.HeaderText = "Môn Học";
            MonHoc.MinimumWidth = 8;
            MonHoc.Name = "MonHoc";
            MonHoc.Width = 150;
            // 
            // Mieng
            // 
            Mieng.HeaderText = "Miệng";
            Mieng.MinimumWidth = 8;
            Mieng.Name = "Mieng";
            Mieng.Width = 150;
            // 
            // muoilamp
            // 
            muoilamp.HeaderText = "15p";
            muoilamp.MinimumWidth = 8;
            muoilamp.Name = "muoilamp";
            muoilamp.Width = 150;
            // 
            // mottiet
            // 
            mottiet.HeaderText = "1 Tiết";
            mottiet.MinimumWidth = 8;
            mottiet.Name = "mottiet";
            mottiet.Width = 150;
            // 
            // CuoiKi
            // 
            CuoiKi.HeaderText = "Cuối Kì";
            CuoiKi.MinimumWidth = 8;
            CuoiKi.Name = "CuoiKi";
            CuoiKi.Width = 150;
            // 
            // Tb
            // 
            Tb.HeaderText = "Trung Bình";
            Tb.MinimumWidth = 8;
            Tb.Name = "Tb";
            Tb.Width = 150;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "2022-2023", "2024-2025", "2025-2026" });
            comboBox1.Location = new Point(22, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "Năm Học";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "HK1", "HK2" });
            comboBox2.Location = new Point(22, 106);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 2;
            comboBox2.Text = "Học Kì";
            // 
            // UC_HocSinh_Diem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "UC_HocSinh_Diem";
            Size = new Size(1288, 678);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn MonHoc;
        private DataGridViewTextBoxColumn Mieng;
        private DataGridViewTextBoxColumn muoilamp;
        private DataGridViewTextBoxColumn mottiet;
        private DataGridViewTextBoxColumn CuoiKi;
        private DataGridViewTextBoxColumn Tb;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}
