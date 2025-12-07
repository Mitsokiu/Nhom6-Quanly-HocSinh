using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_PhuHuynh_Thongtin
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
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox6
            // 
            textBox6.Location = new Point(195, 314);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(335, 31);
            textBox6.TabIndex = 23;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(195, 254);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(335, 31);
            textBox5.TabIndex = 22;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(195, 198);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(335, 31);
            textBox4.TabIndex = 21;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(195, 128);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(335, 31);
            textBox3.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(195, 75);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(335, 31);
            textBox2.TabIndex = 19;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(195, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(335, 31);
            textBox1.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 320);
            label6.Name = "label6";
            label6.Size = new Size(115, 25);
            label6.TabIndex = 17;
            label6.Text = "Chuyên Cần :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 260);
            label5.Name = "label5";
            label5.Size = new Size(107, 25);
            label5.TabIndex = 16;
            label5.Text = "Hạnh Kiểm :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 198);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 15;
            label4.Text = "Học Lực :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 128);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 14;
            label3.Text = "Học Kì :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 75);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 13;
            label2.Text = "Lớp :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 17);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 12;
            label1.Text = "Họ và Tên :";
            // 
            // UC_PhuHuynh_Thongtin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UC_PhuHuynh_Thongtin";
            Size = new Size(799, 418);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
