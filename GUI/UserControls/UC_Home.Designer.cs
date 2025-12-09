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

        // Khai báo các Controls (Đã hoàn tác về tên cũ)
        private Label label2; // Tiêu đề chính "Thông Báo"
        private Label labeltitle; // Tiêu đề thông báo
        private Label labelmes; // Nội dung thông báo
        private Label labeldate; // Ngày gửi thông báo
        private Panel panelNotificationCard; // Card chứa thông báo

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
            this.panelNotificationCard = new System.Windows.Forms.Panel();
            this.panelNotificationCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(30, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(490, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "📣 THÔNG BÁO MỚI NHẤT";
            // 
            // labeltitle
            // 
            this.labeltitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.labeltitle.Location = new System.Drawing.Point(30, 30);
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(921, 38);
            this.labeltitle.TabIndex = 3;
            this.labeltitle.Text = "Tiêu Đề Thông Báo Tải Lên Ở Đây";
            this.labeltitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelmes
            // 
            this.labelmes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelmes.Location = new System.Drawing.Point(30, 80);
            this.labelmes.Name = "labelmes";
            this.labelmes.Size = new System.Drawing.Size(1309, 100);
            this.labelmes.TabIndex = 4;
            this.labelmes.Text = "Nội dung chi tiết của thông báo sẽ xuất hiện ở đây. Nội dung có thể dài và sẽ xuố" +
    "ng dòng tự động.";
            // 
            // labeldate
            // 
            this.labeldate.AutoSize = true;
            this.labeldate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldate.ForeColor = System.Drawing.Color.Gray;
            this.labeldate.Location = new System.Drawing.Point(30, 200);
            this.labeldate.Name = "labeldate";
            this.labeldate.Size = new System.Drawing.Size(196, 25);
            this.labeldate.TabIndex = 5;
            this.labeldate.Text = "Ngày Gửi: dd/MM/yyyy";
            // 
            // panelNotificationCard
            // 
            this.panelNotificationCard.BackColor = System.Drawing.Color.White;
            this.panelNotificationCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNotificationCard.Controls.Add(this.labelmes);
            this.panelNotificationCard.Controls.Add(this.labeltitle);
            this.panelNotificationCard.Controls.Add(this.labeldate);
            this.panelNotificationCard.Location = new System.Drawing.Point(30, 90);
            this.panelNotificationCard.Name = "panelNotificationCard";
            this.panelNotificationCard.Size = new System.Drawing.Size(1363, 250);
            this.panelNotificationCard.TabIndex = 2;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.panelNotificationCard);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1396, 653);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            this.panelNotificationCard.ResumeLayout(false);
            this.panelNotificationCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}