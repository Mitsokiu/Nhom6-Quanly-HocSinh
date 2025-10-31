namespace Studenapp.UserControls
{
    partial class UC_GVCN_HocPhi
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
            groupBox1 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            HocSinh = new DataGridViewTextBoxColumn();
            KhoanThu = new DataGridViewTextBoxColumn();
            SoTien = new DataGridViewTextBoxColumn();
            DaThu = new DataGridViewTextBoxColumn();
            NgayThu = new DataGridViewTextBoxColumn();
            ConNo = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(29, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 617);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tinh";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(129, 332);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(251, 31);
            dateTimePicker1.TabIndex = 13;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(129, 387);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(242, 31);
            textBox6.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(129, 284);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(251, 31);
            textBox4.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(129, 202);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(251, 31);
            textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(129, 140);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 31);
            textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(129, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 31);
            textBox1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(32, 519);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 6;
            button1.Text = "Cập Nhật";
            button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 387);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 5;
            label6.Text = "Còn Nợ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 332);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 4;
            label5.Text = "Ngày Thu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 284);
            label4.Name = "label4";
            label4.Size = new Size(68, 25);
            label4.TabIndex = 3;
            label4.Text = "Đã Thu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 205);
            label3.Name = "label3";
            label3.Size = new Size(70, 25);
            label3.TabIndex = 2;
            label3.Text = "Số Tiền";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 140);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 1;
            label2.Text = "Khoản Thu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 79);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 0;
            label1.Text = "Học Sinh";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(421, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(971, 617);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { HocSinh, KhoanThu, SoTien, DaThu, NgayThu, ConNo });
            dataGridView1.Location = new Point(0, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(955, 563);
            dataGridView1.TabIndex = 0;
            // 
            // HocSinh
            // 
            HocSinh.HeaderText = "Học Sinh";
            HocSinh.MinimumWidth = 8;
            HocSinh.Name = "HocSinh";
            HocSinh.Width = 150;
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
            // DaThu
            // 
            DaThu.HeaderText = "Đã Thu";
            DaThu.MinimumWidth = 8;
            DaThu.Name = "DaThu";
            DaThu.Width = 150;
            // 
            // NgayThu
            // 
            NgayThu.HeaderText = "Ngày Thu";
            NgayThu.MinimumWidth = 8;
            NgayThu.Name = "NgayThu";
            NgayThu.Width = 150;
            // 
            // ConNo
            // 
            ConNo.HeaderText = "Còn Nợ";
            ConNo.MinimumWidth = 8;
            ConNo.Name = "ConNo";
            ConNo.Width = 150;
            // 
            // UC_GVCN_HocPhi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UC_GVCN_HocPhi";
            Size = new Size(1424, 673);
            Load += UC_GVCN_HocPhi_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn HocSinh;
        private DataGridViewTextBoxColumn KhoanThu;
        private DataGridViewTextBoxColumn SoTien;
        private DataGridViewTextBoxColumn DaThu;
        private DataGridViewTextBoxColumn NgayThu;
        private DataGridViewTextBoxColumn ConNo;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
