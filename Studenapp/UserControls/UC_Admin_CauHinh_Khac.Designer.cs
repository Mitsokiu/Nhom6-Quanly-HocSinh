namespace Studenapp.UserControls
{
    partial class UC_Admin_CauHinh_Khac
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
            groupBox2 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(374, 400);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Trường Học";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(390, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(412, 388);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Báo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 52);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên Trường";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 106);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 1;
            label2.Text = "Địa Chỉ";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 162);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 2;
            label3.Text = "Gmail";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 232);
            label4.Name = "label4";
            label4.Size = new Size(136, 25);
            label4.TabIndex = 3;
            label4.Text = "Năm Thành Lập";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 294);
            label5.Name = "label5";
            label5.Size = new Size(53, 25);
            label5.TabIndex = 4;
            label5.Text = "Logo";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(142, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 31);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(142, 100);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(142, 159);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(214, 31);
            textBox3.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(164, 285);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(121, 49);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(244, 350);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 9;
            button1.Text = "Lưu";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(28, 104);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 10;
            button2.Text = "Tạo";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(164, 229);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(192, 31);
            textBox4.TabIndex = 10;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(28, 41);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(361, 31);
            textBox5.TabIndex = 11;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // UC_Admin_CauHinh_Khac
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UC_Admin_CauHinh_Khac";
            Size = new Size(812, 437);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox4;
        private Button button1;
        private PictureBox pictureBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox5;
        private Button button2;
    }
}
