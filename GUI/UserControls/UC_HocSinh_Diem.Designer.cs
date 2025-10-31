using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mieng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muoilamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mottiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuoiKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MonHoc,
            this.Mieng,
            this.muoilamp,
            this.mottiet,
            this.CuoiKi,
            this.Tb});
            this.dataGridView1.Location = new System.Drawing.Point(270, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 501);
            this.dataGridView1.TabIndex = 0;
            // 
            // MonHoc
            // 
            this.MonHoc.HeaderText = "Môn Học";
            this.MonHoc.MinimumWidth = 8;
            this.MonHoc.Name = "MonHoc";
            this.MonHoc.Width = 150;
            // 
            // Mieng
            // 
            this.Mieng.HeaderText = "Miệng";
            this.Mieng.MinimumWidth = 8;
            this.Mieng.Name = "Mieng";
            this.Mieng.Width = 150;
            // 
            // muoilamp
            // 
            this.muoilamp.HeaderText = "15p";
            this.muoilamp.MinimumWidth = 8;
            this.muoilamp.Name = "muoilamp";
            this.muoilamp.Width = 150;
            // 
            // mottiet
            // 
            this.mottiet.HeaderText = "1 Tiết";
            this.mottiet.MinimumWidth = 8;
            this.mottiet.Name = "mottiet";
            this.mottiet.Width = 150;
            // 
            // CuoiKi
            // 
            this.CuoiKi.HeaderText = "Cuối Kì";
            this.CuoiKi.MinimumWidth = 8;
            this.CuoiKi.Name = "CuoiKi";
            this.CuoiKi.Width = 150;
            // 
            // Tb
            // 
            this.Tb.HeaderText = "Trung Bình";
            this.Tb.MinimumWidth = 8;
            this.Tb.Name = "Tb";
            this.Tb.Width = 150;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2022-2023",
            "2024-2025",
            "2025-2026"});
            this.comboBox1.Location = new System.Drawing.Point(20, 33);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Năm Học";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "HK1",
            "HK2"});
            this.comboBox2.Location = new System.Drawing.Point(20, 85);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(164, 28);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.Text = "Học Kì";
            // 
            // UC_HocSinh_Diem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_HocSinh_Diem";
            this.Size = new System.Drawing.Size(1236, 542);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

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
