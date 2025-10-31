using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_Admin_Namhoc_HocKi
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
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            NamHoc = new DataGridViewTextBoxColumn();
            HocKi = new DataGridViewTextBoxColumn();
            NgayBatDau = new DataGridViewTextBoxColumn();
            NgayKetThuc = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(144, 251);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(300, 31);
            dateTimePicker2.TabIndex = 27;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(144, 194);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(301, 31);
            dateTimePicker1.TabIndex = 26;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(134, 309);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 25;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(124, 124);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(160, 31);
            textBox2.TabIndex = 24;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(124, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 23;
            // 
            // button6
            // 
            button6.Location = new Point(283, 407);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 22;
            button6.Text = "Xóa";
            button6.TextAlign = ContentAlignment.TopCenter;
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(155, 406);
            button5.Name = "button5";
            button5.Size = new Size(97, 34);
            button5.TabIndex = 21;
            button5.Text = "Sửa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(10, 407);
            button4.Name = "button4";
            button4.Size = new Size(86, 34);
            button4.TabIndex = 20;
            button4.Text = "Thêm";
            button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 315);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 19;
            label5.Text = "Trạng Thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 257);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 18;
            label4.Text = "Ngày Kết Thúc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 199);
            label3.Name = "label3";
            label3.Size = new Size(120, 25);
            label3.TabIndex = 17;
            label3.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 124);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 16;
            label2.Text = "Học Kì";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 54);
            label1.Name = "label1";
            label1.Size = new Size(87, 25);
            label1.TabIndex = 15;
            label1.Text = "Năm Học";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { NamHoc, HocKi, NgayBatDau, NgayKetThuc, TrangThai });
            dataGridView1.Location = new Point(460, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(829, 463);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // NamHoc
            // 
            NamHoc.HeaderText = "Năm Học";
            NamHoc.MinimumWidth = 8;
            NamHoc.Name = "NamHoc";
            NamHoc.Width = 150;
            // 
            // HocKi
            // 
            HocKi.HeaderText = "Học Kì";
            HocKi.MinimumWidth = 8;
            HocKi.Name = "HocKi";
            HocKi.Width = 150;
            // 
            // NgayBatDau
            // 
            NgayBatDau.HeaderText = "Ngày Bắt Đầu";
            NgayBatDau.MinimumWidth = 8;
            NgayBatDau.Name = "NgayBatDau";
            NgayBatDau.Width = 150;
            // 
            // NgayKetThuc
            // 
            NgayKetThuc.HeaderText = "Ngày Kết Thúc";
            NgayKetThuc.MinimumWidth = 8;
            NgayKetThuc.Name = "NgayKetThuc";
            NgayKetThuc.Width = 150;
            // 
            // TrangThai
            // 
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 8;
            TrangThai.Name = "TrangThai";
            TrangThai.Width = 150;
            // 
            // UC_Admin_Namhoc_HocKi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "UC_Admin_Namhoc_HocKi";
            Size = new Size(1280, 506);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn NamHoc;
        private DataGridViewTextBoxColumn HocKi;
        private DataGridViewTextBoxColumn NgayBatDau;
        private DataGridViewTextBoxColumn NgayKetThuc;
        private DataGridViewTextBoxColumn TrangThai;
    }
}
