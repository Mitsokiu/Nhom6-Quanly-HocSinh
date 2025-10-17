namespace Studenapp.UserControls
{
    partial class UC_Admin_NamHoc_TKB
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
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            Tiet = new DataGridViewTextBoxColumn();
            Thu2 = new DataGridViewTextBoxColumn();
            Thu3 = new DataGridViewTextBoxColumn();
            Thu4 = new DataGridViewTextBoxColumn();
            Thu5 = new DataGridViewTextBoxColumn();
            Thu6 = new DataGridViewTextBoxColumn();
            Thu7 = new DataGridViewTextBoxColumn();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox6 = new ComboBox();
            comboBox7 = new ComboBox();
            label8 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(comboBox7);
            panel1.Controls.Add(comboBox6);
            panel1.Controls.Add(comboBox5);
            panel1.Controls.Add(comboBox4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(comboBox1);
            panel1.Location = new Point(3, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(389, 558);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Tiet, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7 });
            dataGridView1.Location = new Point(398, 17);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1115, 558);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Tiet
            // 
            Tiet.HeaderText = "Tiết";
            Tiet.MinimumWidth = 8;
            Tiet.Name = "Tiet";
            Tiet.Width = 150;
            // 
            // Thu2
            // 
            Thu2.HeaderText = "Thứ 2";
            Thu2.MinimumWidth = 8;
            Thu2.Name = "Thu2";
            Thu2.Width = 150;
            // 
            // Thu3
            // 
            Thu3.HeaderText = "Thứ 3";
            Thu3.MinimumWidth = 8;
            Thu3.Name = "Thu3";
            Thu3.Width = 150;
            // 
            // Thu4
            // 
            Thu4.HeaderText = "Thứ 4";
            Thu4.MinimumWidth = 8;
            Thu4.Name = "Thu4";
            Thu4.Width = 150;
            // 
            // Thu5
            // 
            Thu5.HeaderText = "Thứ 5";
            Thu5.MinimumWidth = 8;
            Thu5.Name = "Thu5";
            Thu5.Width = 150;
            // 
            // Thu6
            // 
            Thu6.HeaderText = "Thứ 6";
            Thu6.MinimumWidth = 8;
            Thu6.Name = "Thu6";
            Thu6.Width = 150;
            // 
            // Thu7
            // 
            Thu7.HeaderText = "Thứ 7";
            Thu7.MinimumWidth = 8;
            Thu7.Name = "Thu7";
            Thu7.Width = 150;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(92, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(92, 33);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(92, 67);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(287, 19);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(88, 33);
            comboBox3.TabIndex = 2;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 22);
            label1.Name = "label1";
            label1.Size = new Size(87, 25);
            label1.TabIndex = 3;
            label1.Text = "Năm Học";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 22);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 4;
            label2.Text = "Học Kì";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 70);
            label3.Name = "label3";
            label3.Size = new Size(42, 25);
            label3.TabIndex = 5;
            label3.Text = "Lớp";
            // 
            // button6
            // 
            button6.Location = new Point(300, 512);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 11;
            button6.Text = "Xóa";
            button6.TextAlign = ContentAlignment.TopCenter;
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(172, 511);
            button5.Name = "button5";
            button5.Size = new Size(97, 34);
            button5.TabIndex = 10;
            button5.Text = "Sửa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(27, 512);
            button4.Name = "button4";
            button4.Size = new Size(86, 34);
            button4.TabIndex = 9;
            button4.Text = "Thêm";
            button4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 157);
            label4.Name = "label4";
            label4.Size = new Size(42, 25);
            label4.TabIndex = 12;
            label4.Text = "Thứ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 230);
            label5.Name = "label5";
            label5.Size = new Size(40, 25);
            label5.TabIndex = 13;
            label5.Text = "Tiết";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 283);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 14;
            label6.Text = "Giáo Viên";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 344);
            label7.Name = "label7";
            label7.Size = new Size(49, 25);
            label7.TabIndex = 15;
            label7.Text = "Môn";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(96, 154);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(182, 33);
            comboBox4.TabIndex = 16;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(96, 222);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(182, 33);
            comboBox5.TabIndex = 17;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(96, 283);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(182, 33);
            comboBox6.TabIndex = 18;
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(96, 336);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(182, 33);
            comboBox7.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 394);
            label8.Name = "label8";
            label8.Size = new Size(64, 25);
            label8.TabIndex = 20;
            label8.Text = "Phòng";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(96, 391);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 21;
            // 
            // UC_Admin_NamHoc_TKB
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "UC_Admin_NamHoc_TKB";
            Size = new Size(1517, 602);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn Tiet;
        private DataGridViewTextBoxColumn Thu2;
        private DataGridViewTextBoxColumn Thu3;
        private DataGridViewTextBoxColumn Thu4;
        private DataGridViewTextBoxColumn Thu5;
        private DataGridViewTextBoxColumn Thu6;
        private DataGridViewTextBoxColumn Thu7;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button button6;
        private Button button5;
        private Button button4;
        private ComboBox comboBox7;
        private ComboBox comboBox6;
        private ComboBox comboBox5;
        private ComboBox comboBox4;
        private TextBox textBox1;
        private Label label8;
    }
}
