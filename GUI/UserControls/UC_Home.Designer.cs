using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_Home
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
            this.label2 = new System.Windows.Forms.Label();
            this.labeltitle = new System.Windows.Forms.Label();
            this.labelmes = new System.Windows.Forms.Label();
            this.labeldate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(25, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "🏫 Thông Báo";
            // 
            // labeltitle
            // 
            this.labeltitle.AutoSize = true;
            this.labeltitle.Location = new System.Drawing.Point(187, 70);
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(64, 20);
            this.labeltitle.TabIndex = 2;
            this.labeltitle.Text = "Tiêu Đề";
            // 
            // labelmes
            // 
            this.labelmes.AutoSize = true;
            this.labelmes.Location = new System.Drawing.Point(384, 70);
            this.labelmes.Name = "labelmes";
            this.labelmes.Size = new System.Drawing.Size(75, 20);
            this.labelmes.TabIndex = 3;
            this.labelmes.Text = "Nội Dung";
            // 
            // labeldate
            // 
            this.labeldate.AutoSize = true;
            this.labeldate.Location = new System.Drawing.Point(38, 70);
            this.labeldate.Name = "labeldate";
            this.labeldate.Size = new System.Drawing.Size(74, 20);
            this.labeldate.TabIndex = 4;
            this.labeldate.Text = "Ngày Gửi";
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labeldate);
            this.Controls.Add(this.labelmes);
            this.Controls.Add(this.labeltitle);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1041, 457);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
        private Label labeltitle;
        private Label labelmes;
        private Label labeldate;
    }
}
