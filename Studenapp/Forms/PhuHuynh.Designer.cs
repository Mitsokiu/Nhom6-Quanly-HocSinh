namespace StudentMan
{
    partial class PhuHuynh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button6 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 55, 72);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 700);
            panel1.TabIndex = 0;
            // 
            // button6
            // 
            button6.BackColor = Color.Firebrick;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(60, 600);
            button6.Name = "button6";
            button6.Size = new Size(184, 40);
            button6.TabIndex = 0;
            button6.Text = "\u23fb Đăng xuất";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(30, 278);
            button3.Name = "button3";
            button3.Size = new Size(280, 45);
            button3.TabIndex = 3;
            button3.Text = "Quản lý học phí ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(30, 207);
            button2.Name = "button2";
            button2.Size = new Size(280, 45);
            button2.TabIndex = 4;
            button2.Text = "Theo dõi tình hình học tập";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(30, 140);
            button1.Name = "button1";
            button1.Size = new Size(280, 45);
            button1.TabIndex = 5;
            button1.Text = "🏠 Trang chủ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(80, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Location = new Point(345, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(1325, 670);
            panel2.TabIndex = 1;
            // 
            // PhuHuynh
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1689, 700);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PhuHuynh";
            Text = "PhuHuynh";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button6;
        private Panel panel2;
    }
}
