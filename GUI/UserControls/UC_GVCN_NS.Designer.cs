using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_GVCN_NS
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
            STT = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            HanhKiem = new DataGridViewTextBoxColumn();
            GhiChu = new DataGridViewTextBoxColumn();
            NgayCapNhat = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { STT, HoTen, HanhKiem, GhiChu, NgayCapNhat });
            dataGridView1.Location = new Point(427, 17);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(824, 645);
            dataGridView1.TabIndex = 0;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 8;
            STT.Name = "STT";
            STT.Width = 150;
            // 
            // HoTen
            // 
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.Width = 150;
            // 
            // HanhKiem
            // 
            HanhKiem.HeaderText = "Hạnh Kiểm";
            HanhKiem.MinimumWidth = 8;
            HanhKiem.Name = "HanhKiem";
            HanhKiem.Width = 150;
            // 
            // GhiChu
            // 
            GhiChu.HeaderText = "Ghi Chú";
            GhiChu.MinimumWidth = 8;
            GhiChu.Name = "GhiChu";
            GhiChu.Width = 150;
            // 
            // NgayCapNhat
            // 
            NgayCapNhat.HeaderText = "Ngày Cập Nhật";
            NgayCapNhat.MinimumWidth = 8;
            NgayCapNhat.Name = "NgayCapNhat";
            NgayCapNhat.Width = 150;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(170, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 31);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 76);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 2;
            label1.Text = "Họ Tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 161);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 3;
            label2.Text = "Hạnh Kiểm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 228);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 4;
            label3.Text = "Ghi Chú";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 309);
            label4.Name = "label4";
            label4.Size = new Size(133, 25);
            label4.TabIndex = 5;
            label4.Text = "Ngày Cập Nhật";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(170, 155);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(230, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(170, 228);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(230, 31);
            textBox3.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(170, 303);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(251, 31);
            dateTimePicker1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(14, 423);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 9;
            button1.Text = "Cập Nhật";
            button1.UseVisualStyleBackColor = true;
            // 
            // UC_GVCN_NS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "UC_GVCN_NS";
            Size = new Size(1254, 687);
            Load += UC_GVCN_NS_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn HanhKiem;
        private DataGridViewTextBoxColumn GhiChu;
        private DataGridViewTextBoxColumn NgayCapNhat;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private Button button1;
    }
}
