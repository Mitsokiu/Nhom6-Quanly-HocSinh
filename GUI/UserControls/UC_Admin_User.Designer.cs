using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_Admin_User
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
            Add = new Button();
            label1 = new Label();
            panel2 = new Panel();
            button10 = new Button();
            comboBox2 = new ComboBox();
            button9 = new Button();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            Taikhoan = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            button8 = new Button();
            textBox1 = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Add
            // 
            Add.BackColor = Color.Silver;
            Add.Location = new Point(1112, 49);
            Add.Name = "Add";
            Add.Size = new Size(112, 34);
            Add.TabIndex = 10;
            Add.Text = "Them";
            Add.UseVisualStyleBackColor = false;
            Add.Click += Add_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 61);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 15;
            label1.Text = "Thong Tin";
            // 
            // panel2
            // 
            panel2.Controls.Add(button10);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(33, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(376, 581);
            panel2.TabIndex = 14;
            // 
            // button10
            // 
            button10.BackColor = Color.Silver;
            button10.Location = new Point(234, 528);
            button10.Name = "button10";
            button10.Size = new Size(112, 34);
            button10.TabIndex = 5;
            button10.Text = "Xoa";
            button10.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Hoat Dong", "Khoa" });
            comboBox2.Location = new Point(24, 378);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 12;
            comboBox2.Text = "Trang Thai";
            // 
            // button9
            // 
            button9.BackColor = Color.Silver;
            button9.Location = new Point(13, 528);
            button9.Name = "button9";
            button9.Size = new Size(112, 34);
            button9.TabIndex = 4;
            button9.Text = "Sua";
            button9.UseVisualStyleBackColor = false;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(135, 184);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(230, 31);
            textBox6.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(135, 223);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(230, 31);
            textBox5.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(135, 266);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(230, 31);
            textBox4.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(24, 325);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(275, 31);
            dateTimePicker1.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 266);
            label6.Name = "label6";
            label6.Size = new Size(67, 25);
            label6.TabIndex = 7;
            label6.Text = "Ho Ten";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 223);
            label5.Name = "label5";
            label5.Size = new Size(43, 25);
            label5.TabIndex = 6;
            label5.Text = "SDT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 184);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 5;
            label4.Text = "Email";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(135, 137);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(230, 31);
            textBox3.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 100);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(230, 31);
            textBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Hoc Sinh", "Phu Huynh", "Giao Vien Chu Nhiem", "Giao Vien Bo on" });
            comboBox1.Location = new Point(24, 39);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Loai Tai Khoan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 137);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 1;
            label3.Text = "Mat Khau";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 97);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 0;
            label2.Text = "Tai Khoan";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Taikhoan, Email, SDT, HoTen });
            dataGridView1.Location = new Point(415, 89);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(809, 581);
            dataGridView1.TabIndex = 13;
            // 
            // Taikhoan
            // 
            Taikhoan.HeaderText = "Tai Khoan";
            Taikhoan.MinimumWidth = 8;
            Taikhoan.Name = "Taikhoan";
            Taikhoan.Width = 150;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 8;
            Email.Name = "Email";
            Email.Width = 150;
            // 
            // SDT
            // 
            SDT.HeaderText = "SDT";
            SDT.MinimumWidth = 8;
            SDT.Name = "SDT";
            SDT.Width = 150;
            // 
            // HoTen
            // 
            HoTen.HeaderText = "Ho Ten";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.Width = 150;
            // 
            // button8
            // 
            button8.Location = new Point(603, 18);
            button8.Name = "button8";
            button8.Size = new Size(112, 34);
            button8.TabIndex = 12;
            button8.Text = "Seach";
            button8.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(224, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(373, 31);
            textBox1.TabIndex = 11;
            textBox1.Text = "Search";
            // 
            // UC_Admin_User
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Add);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(dataGridView1);
            Controls.Add(button8);
            Controls.Add(textBox1);
            Name = "UC_Admin_User";
            Size = new Size(1236, 754);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Add;
        private Label label1;
        private Panel panel2;
        private Button button10;
        private ComboBox comboBox2;
        private Button button9;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Label label3;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Taikhoan;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn HoTen;
        private Button button8;
        private TextBox textBox1;
    }
}
