using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_Admin_Namhoc
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(39, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Quản Lý Học Kì";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(391, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Quản Lý TKB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(741, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(299, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Quản Lý Học Phí";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(11, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1415, 487);
            this.panel1.TabIndex = 3;
            // 
            // UC_Admin_Namhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "UC_Admin_Namhoc";
            this.Size = new System.Drawing.Size(1429, 648);
            this.Load += new System.EventHandler(this.UC_Admin_Namhoc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
    }
}
