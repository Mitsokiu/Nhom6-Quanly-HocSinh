namespace Studenapp.UserControls
{
    partial class UC_Admin_NamHoc_HocPhi
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
            button3 = new Button();
            dataGridView1 = new DataGridView();
            Hoten = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            Lop = new DataGridViewTextBoxColumn();
            KhoanThu = new DataGridViewTextBoxColumn();
            SoTien = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            NgayDong = new DataGridViewTextBoxColumn();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(23, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(1518, 526);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button3
            // 
            button3.Location = new Point(17, 342);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 10;
            button3.Text = "Cập Nhật";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Hoten, NgaySinh, Lop, KhoanThu, SoTien, TrangThai, NgayDong });
            dataGridView1.Location = new Point(422, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1093, 524);
            dataGridView1.TabIndex = 1;
            // 
            // Hoten
            // 
            Hoten.HeaderText = "Họ Tên";
            Hoten.MinimumWidth = 8;
            Hoten.Name = "Hoten";
            Hoten.Width = 150;
            // 
            // NgaySinh
            // 
            NgaySinh.HeaderText = "Ngày/Tháng/Năm Sinh";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.Width = 150;
            // 
            // Lop
            // 
            Lop.HeaderText = "Lớp";
            Lop.MinimumWidth = 8;
            Lop.Name = "Lop";
            Lop.Width = 150;
            // 
            // KhoanThu
            // 
            KhoanThu.HeaderText = "Khoản Thu";
            KhoanThu.MinimumWidth = 8;
            KhoanThu.Name = "KhoanThu";
            KhoanThu.Width = 150;
            // 
            // SoTien
            // 
            SoTien.HeaderText = "Số Tiền";
            SoTien.MinimumWidth = 8;
            SoTien.Name = "SoTien";
            SoTien.Width = 150;
            // 
            // TrangThai
            // 
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 8;
            TrangThai.Name = "TrangThai";
            TrangThai.Width = 150;
            // 
            // NgayDong
            // 
            NgayDong.HeaderText = "Ngày Đóng";
            NgayDong.MinimumWidth = 8;
            NgayDong.Name = "NgayDong";
            NgayDong.Width = 150;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(105, 229);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(115, 44);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 234);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 7;
            label4.Text = "Ngày Thu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 166);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 5;
            label3.Text = "Trạng Thái";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(115, 160);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 31);
            textBox3.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 108);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 3;
            label2.Text = "Họ Tên";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(118, 102);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(193, 31);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 47);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 1;
            label1.Text = "Lớp";
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(23, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(405, 65);
            panel2.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(181, 15);
            button2.Name = "button2";
            button2.Size = new Size(207, 38);
            button2.TabIndex = 1;
            button2.Text = "Thiết Lập Khoảng Thu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(3, 19);
            button1.Name = "button1";
            button1.Size = new Size(172, 34);
            button1.TabIndex = 0;
            button1.Text = "Quản Lý Học Phí";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UC_Admin_NamHoc_HocPhi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_Admin_NamHoc_HocPhi";
            Size = new Size(1541, 674);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private DataGridViewTextBoxColumn Hoten;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn Lop;
        private DataGridViewTextBoxColumn KhoanThu;
        private DataGridViewTextBoxColumn SoTien;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn NgayDong;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private Button button3;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
    }
}
