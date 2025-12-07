using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_PhuHuynh_NhanXet
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
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            TieuDe = new DataGridViewTextBoxColumn();
            NguoiGui = new DataGridViewTextBoxColumn();
            Ngaygui = new DataGridViewTextBoxColumn();
            NoiDung = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "2022-2023", "2024-2025", "2025-2026" });
            comboBox1.Location = new Point(66, 45);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Năm học";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TieuDe, NguoiGui, Ngaygui, NoiDung });
            dataGridView1.Location = new Point(71, 97);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(869, 470);
            dataGridView1.TabIndex = 1;
            // 
            // TieuDe
            // 
            TieuDe.HeaderText = "Tiêu Đề";
            TieuDe.MinimumWidth = 8;
            TieuDe.Name = "TieuDe";
            TieuDe.Width = 150;
            // 
            // NguoiGui
            // 
            NguoiGui.HeaderText = "Người Gửi";
            NguoiGui.MinimumWidth = 8;
            NguoiGui.Name = "NguoiGui";
            NguoiGui.Width = 150;
            // 
            // Ngaygui
            // 
            Ngaygui.HeaderText = "Ngày Gửi";
            Ngaygui.MinimumWidth = 8;
            Ngaygui.Name = "Ngaygui";
            Ngaygui.Width = 150;
            // 
            // NoiDung
            // 
            NoiDung.HeaderText = "Nội Dung";
            NoiDung.MinimumWidth = 8;
            NoiDung.Name = "NoiDung";
            NoiDung.Width = 300;
            // 
            // UC_PhuHuynh_NhanXet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Name = "UC_PhuHuynh_NhanXet";
            Size = new Size(983, 599);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn TieuDe;
        private DataGridViewTextBoxColumn NguoiGui;
        private DataGridViewTextBoxColumn Ngaygui;
        private DataGridViewTextBoxColumn NoiDung;
    }
}
