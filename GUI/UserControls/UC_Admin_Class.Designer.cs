using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.UserControls
{
    partial class UC_Admin_Class
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
            // Định nghĩa các mã màu RGB hiện đại
            System.Drawing.Color ColorPrimary = System.Drawing.Color.FromArgb(33, 70, 102);         // Xanh Chủ Đạo (Dùng cho Panel điều hướng)
            System.Drawing.Color ColorBackground = System.Drawing.Color.White;                     // Nền chính

            // Đổi tên các controls để dễ theo dõi
            this.panel_Content = new System.Windows.Forms.Panel();
            this.panel_Nav = new System.Windows.Forms.Panel();
            this.btn_QuanLyKhoiLop = new System.Windows.Forms.Button();
            this.btn_PhanCongGVCN = new System.Windows.Forms.Button();
            this.btn_QuanLyMonHoc = new System.Windows.Forms.Button();
            this.btn_PhanCongGVBM = new System.Windows.Forms.Button();

            // Giữ nguyên logic cũ của bạn để tránh lỗi:
            this.panel_Nav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Content
            // 
            this.panel_Content.Location = new System.Drawing.Point(6, 68);
            this.panel_Content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Content.Name = "panel_Content"; // Đổi tên từ panel1
            this.panel_Content.Size = new System.Drawing.Size(1441, 613);
            this.panel_Content.TabIndex = 3;
            // 
            // panel_Nav
            // 
            this.panel_Nav.BackColor = ColorPrimary; // Áp dụng màu Xanh Chủ Đạo
            this.panel_Nav.Controls.Add(this.btn_QuanLyKhoiLop);
            this.panel_Nav.Controls.Add(this.btn_PhanCongGVCN);
            this.panel_Nav.Controls.Add(this.btn_QuanLyMonHoc);
            this.panel_Nav.Controls.Add(this.btn_PhanCongGVBM);
            this.panel_Nav.Location = new System.Drawing.Point(3, 3);
            this.panel_Nav.Name = "panel_Nav"; // Đổi tên từ panel2
            this.panel_Nav.Size = new System.Drawing.Size(1444, 60);
            this.panel_Nav.TabIndex = 5;
            // 
            // btn_QuanLyKhoiLop
            // 
            // Đổi tên từ button1
            this.btn_QuanLyKhoiLop.BackColor = ColorPrimary;
            this.btn_QuanLyKhoiLop.FlatAppearance.BorderSize = 0; // Thiết kế phẳng
            this.btn_QuanLyKhoiLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QuanLyKhoiLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanLyKhoiLop.ForeColor = System.Drawing.Color.White; // Chữ trắng nổi bật
            // Giữ nguyên Icon (nếu tồn tại)
            this.btn_QuanLyKhoiLop.Image = global::GUI.Properties.Resources.khoilop;
            this.btn_QuanLyKhoiLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QuanLyKhoiLop.Location = new System.Drawing.Point(3, 2);
            this.btn_QuanLyKhoiLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_QuanLyKhoiLop.Name = "btn_QuanLyKhoiLop";
            this.btn_QuanLyKhoiLop.Size = new System.Drawing.Size(352, 56);
            this.btn_QuanLyKhoiLop.TabIndex = 0;
            this.btn_QuanLyKhoiLop.Text = "Quản Lý Khối, Lớp";
            this.btn_QuanLyKhoiLop.UseVisualStyleBackColor = false; // Phải là false để BackColor có tác dụng
            this.btn_QuanLyKhoiLop.Click += new System.EventHandler(this.button1_Click); // Giữ nguyên sự kiện cũ
            // 
            // btn_PhanCongGVCN
            // 
            // Đổi tên từ button4
            this.btn_PhanCongGVCN.BackColor = ColorPrimary;
            this.btn_PhanCongGVCN.FlatAppearance.BorderSize = 0;
            this.btn_PhanCongGVCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PhanCongGVCN.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhanCongGVCN.ForeColor = System.Drawing.Color.White;
            // Giữ nguyên Icon (nếu tồn tại)
            this.btn_PhanCongGVCN.Image = global::GUI.Properties.Resources.teacher1;
            this.btn_PhanCongGVCN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PhanCongGVCN.Location = new System.Drawing.Point(1103, 2);
            this.btn_PhanCongGVCN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_PhanCongGVCN.Name = "btn_PhanCongGVCN";
            this.btn_PhanCongGVCN.Size = new System.Drawing.Size(338, 56);
            this.btn_PhanCongGVCN.TabIndex = 4;
            this.btn_PhanCongGVCN.Text = "Phân Công GVCN";
            this.btn_PhanCongGVCN.UseVisualStyleBackColor = false;
            this.btn_PhanCongGVCN.Click += new System.EventHandler(this.button4_Click); // Giữ nguyên sự kiện cũ
            // 
            // btn_QuanLyMonHoc
            // 
            // Đổi tên từ button2
            this.btn_QuanLyMonHoc.BackColor = ColorPrimary;
            this.btn_QuanLyMonHoc.FlatAppearance.BorderSize = 0;
            this.btn_QuanLyMonHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QuanLyMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanLyMonHoc.ForeColor = System.Drawing.Color.White;
            // Giữ nguyên Icon (nếu tồn tại)
            this.btn_QuanLyMonHoc.Image = global::GUI.Properties.Resources.HocKi;
            this.btn_QuanLyMonHoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QuanLyMonHoc.Location = new System.Drawing.Point(361, 2);
            this.btn_QuanLyMonHoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_QuanLyMonHoc.Name = "btn_QuanLyMonHoc";
            this.btn_QuanLyMonHoc.Size = new System.Drawing.Size(363, 56);
            this.btn_QuanLyMonHoc.TabIndex = 1;
            this.btn_QuanLyMonHoc.Text = "Quản Lý Môn Học";
            this.btn_QuanLyMonHoc.UseVisualStyleBackColor = false;
            this.btn_QuanLyMonHoc.Click += new System.EventHandler(this.button2_Click); // Giữ nguyên sự kiện cũ
            // 
            // btn_PhanCongGVBM
            // 
            // Đổi tên từ button3 (Phân Công => Phân Công GV Bộ Môn)
            this.btn_PhanCongGVBM.BackColor = ColorPrimary;
            this.btn_PhanCongGVBM.FlatAppearance.BorderSize = 0;
            this.btn_PhanCongGVBM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PhanCongGVBM.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhanCongGVBM.ForeColor = System.Drawing.Color.White;
            // Giữ nguyên Icon (nếu tồn tại)
            this.btn_PhanCongGVBM.Image = global::GUI.Properties.Resources.teacher;
            this.btn_PhanCongGVBM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PhanCongGVBM.Location = new System.Drawing.Point(730, 2);
            this.btn_PhanCongGVBM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_PhanCongGVBM.Name = "btn_PhanCongGVBM";
            this.btn_PhanCongGVBM.Size = new System.Drawing.Size(367, 56);
            this.btn_PhanCongGVBM.TabIndex = 2;
            this.btn_PhanCongGVBM.Text = "Phân Công GV Bộ Môn";
            this.btn_PhanCongGVBM.UseVisualStyleBackColor = false;
            this.btn_PhanCongGVBM.Click += new System.EventHandler(this.button3_Click); // Giữ nguyên sự kiện cũ
            // 
            // UC_Admin_Class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ColorBackground; // Nền chính là màu trắng
            this.Controls.Add(this.panel_Nav);
            this.Controls.Add(this.panel_Content);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Admin_Class";
            this.Size = new System.Drawing.Size(1450, 694);
            this.panel_Nav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Cập nhật tên biến ở đây
        private System.Windows.Forms.Button btn_QuanLyKhoiLop;
        private System.Windows.Forms.Button btn_QuanLyMonHoc;
        private System.Windows.Forms.Button btn_PhanCongGVBM;
        private System.Windows.Forms.Panel panel_Content;
        private System.Windows.Forms.Button btn_PhanCongGVCN;
        private System.Windows.Forms.Panel panel_Nav;
    }
}