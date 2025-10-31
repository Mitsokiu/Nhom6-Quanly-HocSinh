using System;
using System.Drawing;
using System.Windows.Forms;
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
            button4 = new Button();
            button3 = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            HoTen = new DataGridViewTextBoxColumn();
            Mieng = new DataGridViewTextBoxColumn();
            muoilamp = new DataGridViewTextBoxColumn();
            MotTiet = new DataGridViewTextBoxColumn();
            CuoiKi = new DataGridViewTextBoxColumn();
            Tb = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(202, 397);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 34;
            button4.Text = "Lưu";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(11, 397);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 33;
            button3.Text = "Tính TB";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(88, 289);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(52, 31);
            textBox5.TabIndex = 32;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(250, 239);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(52, 31);
            textBox4.TabIndex = 31;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(88, 233);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(52, 31);
            textBox3.TabIndex = 30;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(250, 177);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(52, 31);
            textBox2.TabIndex = 29;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(88, 180);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(52, 31);
            textBox1.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 289);
            label5.Name = "label5";
            label5.Size = new Size(31, 25);
            label5.TabIndex = 27;
            label5.Text = "TB";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(180, 239);
            label4.Name = "label4";
            label4.Size = new Size(67, 25);
            label4.TabIndex = 26;
            label4.Text = "Cuối Kì";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 239);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 25;
            label3.Text = "1 Tiết";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 177);
            label2.Name = "label2";
            label2.Size = new Size(43, 25);
            label2.TabIndex = 24;
            label2.Text = "15p";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 180);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 23;
            label1.Text = "Miệng";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(9, 104);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(114, 33);
            comboBox4.TabIndex = 22;
            comboBox4.Text = "Lớp";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(165, 104);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(83, 33);
            comboBox3.TabIndex = 21;
            comboBox3.Text = "Môn";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(165, 46);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(83, 33);
            comboBox2.TabIndex = 20;
            comboBox2.Text = "Học Kì";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(9, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(114, 33);
            comboBox1.TabIndex = 19;
            comboBox1.Text = "Năm học";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { HoTen, Mieng, muoilamp, MotTiet, CuoiKi, Tb });
            dataGridView1.Location = new Point(320, 18);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(765, 476);
            dataGridView1.TabIndex = 18;
            // 
            // HoTen
            // 
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.Width = 200;
            // 
            // Mieng
            // 
            Mieng.HeaderText = "Miệng";
            Mieng.MinimumWidth = 8;
            Mieng.Name = "Mieng";
            // 
            // muoilamp
            // 
            muoilamp.HeaderText = "15p";
            muoilamp.MinimumWidth = 8;
            muoilamp.Name = "muoilamp";
            // 
            // MotTiet
            // 
            MotTiet.HeaderText = "1 Tiết";
            MotTiet.MinimumWidth = 8;
            MotTiet.Name = "MotTiet";
            // 
            // CuoiKi
            // 
            CuoiKi.HeaderText = "Cuối Kì";
            CuoiKi.MinimumWidth = 8;
            CuoiKi.Name = "CuoiKi";
            // 
            // Tb
            // 
            Tb.HeaderText = "Trung Bình";
            Tb.MinimumWidth = 8;
            Tb.Name = "Tb";
            // 
            // UC_GVBM_Diem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "UC_GVBM_Diem";
            Size = new Size(1096, 507);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Button button3;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn Mieng;
        private DataGridViewTextBoxColumn muoilamp;
        private DataGridViewTextBoxColumn MotTiet;
        private DataGridViewTextBoxColumn CuoiKi;
        private DataGridViewTextBoxColumn Tb;
    }
}
