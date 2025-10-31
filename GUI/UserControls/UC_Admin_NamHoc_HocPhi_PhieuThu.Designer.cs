using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_Admin_NamHoc_HocPhi_PhieuThu
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
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            MaThu = new DataGridViewTextBoxColumn();
            TenKhoanThu = new DataGridViewTextBoxColumn();
            SoTien = new DataGridViewTextBoxColumn();
            NamHoc = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(15, 21);
            panel2.Name = "panel2";
            panel2.Size = new Size(405, 65);
            panel2.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(181, 15);
            button2.Name = "button2";
            button2.Size = new Size(207, 38);
            button2.TabIndex = 1;
            button2.Text = "Thiết Lập Khoảng Thu";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(3, 19);
            button1.Name = "button1";
            button1.Size = new Size(172, 34);
            button1.TabIndex = 0;
            button1.Text = "Quản Lý Học Phí";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(15, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(405, 526);
            panel1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 234);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 7;
            label4.Text = "Năm Học";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 166);
            label3.Name = "label3";
            label3.Size = new Size(70, 25);
            label3.TabIndex = 5;
            label3.Text = "Số Tiền";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(149, 160);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 31);
            textBox3.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 108);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 3;
            label2.Text = "Tên Khoản Thu";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(149, 102);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(193, 31);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 47);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 1;
            label1.Text = "Mã Khoản Thu";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { MaThu, TenKhoanThu, SoTien, NamHoc });
            dataGridView1.Location = new Point(440, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(669, 597);
            dataGridView1.TabIndex = 6;
            // 
            // MaThu
            // 
            MaThu.HeaderText = "Mã Khoản Thu";
            MaThu.MinimumWidth = 8;
            MaThu.Name = "MaThu";
            MaThu.Width = 150;
            // 
            // TenKhoanThu
            // 
            TenKhoanThu.HeaderText = "Tên Khoản Thu";
            TenKhoanThu.MinimumWidth = 8;
            TenKhoanThu.Name = "TenKhoanThu";
            TenKhoanThu.Width = 150;
            // 
            // SoTien
            // 
            SoTien.HeaderText = "Số Tiền";
            SoTien.MinimumWidth = 8;
            SoTien.Name = "SoTien";
            SoTien.Width = 150;
            // 
            // NamHoc
            // 
            NamHoc.HeaderText = "Năm Học";
            NamHoc.MinimumWidth = 8;
            NamHoc.Name = "NamHoc";
            NamHoc.Width = 150;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 31);
            textBox1.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(149, 228);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(196, 31);
            textBox4.TabIndex = 12;
            // 
            // button6
            // 
            button6.Location = new Point(277, 403);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 15;
            button6.Text = "Xóa";
            button6.TextAlign = ContentAlignment.TopCenter;
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(149, 402);
            button5.Name = "button5";
            button5.Size = new Size(97, 34);
            button5.TabIndex = 14;
            button5.Text = "Sửa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(4, 403);
            button4.Name = "button4";
            button4.Size = new Size(86, 34);
            button4.TabIndex = 13;
            button4.Text = "Thêm";
            button4.UseVisualStyleBackColor = true;
            // 
            // UC_Admin_NamHoc_HocPhi_PhieuThu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_Admin_NamHoc_HocPhi_PhieuThu";
            Size = new Size(1126, 633);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button button2;
        private Button button1;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn MaThu;
        private DataGridViewTextBoxColumn TenKhoanThu;
        private DataGridViewTextBoxColumn SoTien;
        private DataGridViewTextBoxColumn NamHoc;
        private TextBox textBox4;
        private TextBox textBox1;
        private Button button6;
        private Button button5;
        private Button button4;
    }
}
