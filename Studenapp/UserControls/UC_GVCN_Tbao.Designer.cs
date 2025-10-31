namespace Studenapp.UserControls
{
    partial class UC_GVCN_Tbao
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            comboBox2 = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(24, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(788, 529);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tạo Thông Báo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 78);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 0;
            label1.Text = "Tiêu Đề";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 146);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 1;
            label2.Text = "Loại Thông Báo";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 209);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 2;
            label3.Text = "Nội Dung";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 260);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 3;
            label4.Text = "Gửi Đến";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(207, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(207, 203);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Lịch Học", "Sự Kiện", "Học Phí" });
            comboBox1.Location = new Point(207, 146);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(64, 361);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 8;
            button1.Text = "Gửi";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Học Sinh", "Phụ Huynh" });
            comboBox2.Location = new Point(207, 260);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 9;
            // 
            // UC_GVCN_Tbao
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "UC_GVCN_Tbao";
            Size = new Size(857, 587);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox2;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private TextBox textBox1;
    }
}
