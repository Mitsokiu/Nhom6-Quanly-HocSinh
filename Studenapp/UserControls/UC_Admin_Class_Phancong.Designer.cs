namespace Studenapp.UserControls
{
    partial class UC_Admin_Class_Phancong
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
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            Lop = new DataGridViewTextBoxColumn();
            Mon = new DataGridViewTextBoxColumn();
            GiaoVien = new DataGridViewTextBoxColumn();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Lop, Mon, GiaoVien });
            dataGridView1.Location = new Point(349, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(525, 486);
            dataGridView1.TabIndex = 0;
            // 
            // button6
            // 
            button6.Location = new Point(235, 425);
            button6.Name = "button6";
            button6.Size = new Size(102, 34);
            button6.TabIndex = 12;
            button6.Text = "Xóa";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(115, 425);
            button5.Name = "button5";
            button5.Size = new Size(96, 34);
            button5.TabIndex = 11;
            button5.Text = "Sửa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(14, 425);
            button4.Name = "button4";
            button4.Size = new Size(86, 34);
            button4.TabIndex = 10;
            button4.Text = "Thêm";
            button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 51);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 13;
            label1.Text = "Lớp";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 125);
            label2.Name = "label2";
            label2.Size = new Size(49, 25);
            label2.TabIndex = 14;
            label2.Text = "Môn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 207);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 16;
            label4.Text = "Gíao Viên";
            // 
            // Lop
            // 
            Lop.HeaderText = "Lớp";
            Lop.MinimumWidth = 8;
            Lop.Name = "Lop";
            Lop.Width = 150;
            // 
            // Mon
            // 
            Mon.HeaderText = "Môn";
            Mon.MinimumWidth = 8;
            Mon.Name = "Mon";
            Mon.Width = 150;
            // 
            // GiaoVien
            // 
            GiaoVien.HeaderText = "Giáo Viên";
            GiaoVien.MinimumWidth = 8;
            GiaoVien.Name = "GiaoVien";
            GiaoVien.Width = 150;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(126, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 17;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(126, 125);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 18;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(126, 204);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(182, 33);
            comboBox3.TabIndex = 19;
            // 
            // UC_Admin_Class_Phancong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Name = "UC_Admin_Class_Phancong";
            Size = new Size(881, 512);
            Load += UC_Admin_Class_Phancong_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label4;
        private DataGridViewTextBoxColumn Lop;
        private DataGridViewTextBoxColumn Mon;
        private DataGridViewTextBoxColumn GiaoVien;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
    }
}
