using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_GVCN_QLHS
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
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(18, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(1239, 73);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(563, 19);
            button2.Name = "button2";
            button2.Size = new Size(342, 34);
            button2.TabIndex = 1;
            button2.Text = "Quản Lý Học Phí";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(117, 19);
            button1.Name = "button1";
            button1.Size = new Size(314, 34);
            button1.TabIndex = 0;
            button1.Text = "Xem Danh Sách Học Sinh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(18, 94);
            panel2.Name = "panel2";
            panel2.Size = new Size(1239, 576);
            panel2.TabIndex = 1;
            // 
            // UC_GVCN_QLHS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_GVCN_QLHS";
            Size = new Size(1279, 704);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Panel panel2;
    }
}
