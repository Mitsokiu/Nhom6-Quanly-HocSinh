using System.Windows.Forms;

namespace GUI
{
    partial class Sidebar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sidebar));
            this.lbWelcome = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnQuanLyLopHoc = new System.Windows.Forms.Button();
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnHocSinh = new System.Windows.Forms.Button();
            this.btnLichDay = new System.Windows.Forms.Button();
            this.btnXemTKB = new System.Windows.Forms.Button();
            this.btnTinNhan = new System.Windows.Forms.Button();
            this.btnHocPhi = new System.Windows.Forms.Button();
            this.btnXemDiem = new System.Windows.Forms.Button();
            this.btnNhapDiem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQuanLyKhoiLop = new System.Windows.Forms.Button();
            this.btnQuanLyMonHoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.Location = new System.Drawing.Point(86, 104);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(73, 18);
            this.lbWelcome.TabIndex = 1;
            this.lbWelcome.Text = "Xin chào !";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(79, 122);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(100, 18);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "Nguyễn Văn A";
            this.lbInfo.Click += new System.EventHandler(this.lbInfo_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.Image = global::GUI.Properties.Resources.dangxuat_24;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(3, 750);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(244, 43);
            this.btnDangXuat.TabIndex = 21;
            this.btnDangXuat.Text = "  Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.Image = global::GUI.Properties.Resources.taikhoan_24;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(5, 701);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(244, 43);
            this.btnTaiKhoan.TabIndex = 21;
            this.btnTaiKhoan.Text = "  Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnQuanLyLopHoc
            // 
            this.btnQuanLyLopHoc.FlatAppearance.BorderSize = 0;
            this.btnQuanLyLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyLopHoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyLopHoc.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyLopHoc.Image")));
            this.btnQuanLyLopHoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyLopHoc.Location = new System.Drawing.Point(5, 561);
            this.btnQuanLyLopHoc.Name = "btnQuanLyLopHoc";
            this.btnQuanLyLopHoc.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnQuanLyLopHoc.Size = new System.Drawing.Size(244, 43);
            this.btnQuanLyLopHoc.TabIndex = 21;
            this.btnQuanLyLopHoc.Text = "  Quản lý lớp học";
            this.btnQuanLyLopHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyLopHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.FlatAppearance.BorderSize = 0;
            this.btnLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopHoc.Image = global::GUI.Properties.Resources.lophoc_24;
            this.btnLopHoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHoc.Location = new System.Drawing.Point(5, 511);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnLopHoc.Size = new System.Drawing.Size(244, 43);
            this.btnLopHoc.TabIndex = 20;
            this.btnLopHoc.Text = "  Lớp học";
            this.btnLopHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLopHoc.Click += new System.EventHandler(this.btnLopHoc_Click);
            // 
            // btnHocSinh
            // 
            this.btnHocSinh.FlatAppearance.BorderSize = 0;
            this.btnHocSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocSinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocSinh.Image = global::GUI.Properties.Resources.hocsinh_24;
            this.btnHocSinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocSinh.Location = new System.Drawing.Point(5, 461);
            this.btnHocSinh.Name = "btnHocSinh";
            this.btnHocSinh.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnHocSinh.Size = new System.Drawing.Size(244, 43);
            this.btnHocSinh.TabIndex = 19;
            this.btnHocSinh.Text = "  Học sinh";
            this.btnHocSinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocSinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocSinh.Click += new System.EventHandler(this.btnHocSinh_Click);
            // 
            // btnLichDay
            // 
            this.btnLichDay.FlatAppearance.BorderSize = 0;
            this.btnLichDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichDay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichDay.Image = ((System.Drawing.Image)(resources.GetObject("btnLichDay.Image")));
            this.btnLichDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichDay.Location = new System.Drawing.Point(5, 411);
            this.btnLichDay.Name = "btnLichDay";
            this.btnLichDay.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnLichDay.Size = new System.Drawing.Size(244, 43);
            this.btnLichDay.TabIndex = 18;
            this.btnLichDay.Text = "  Lịch dạy";
            this.btnLichDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichDay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLichDay.Click += new System.EventHandler(this.btnLichDay_Click);
            // 
            // btnXemTKB
            // 
            this.btnXemTKB.FlatAppearance.BorderSize = 0;
            this.btnXemTKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTKB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemTKB.Image = ((System.Drawing.Image)(resources.GetObject("btnXemTKB.Image")));
            this.btnXemTKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKB.Location = new System.Drawing.Point(5, 361);
            this.btnXemTKB.Name = "btnXemTKB";
            this.btnXemTKB.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnXemTKB.Size = new System.Drawing.Size(244, 43);
            this.btnXemTKB.TabIndex = 17;
            this.btnXemTKB.Text = "  Thời khóa biểu";
            this.btnXemTKB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnTinNhan
            // 
            this.btnTinNhan.FlatAppearance.BorderSize = 0;
            this.btnTinNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinNhan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnTinNhan.Image")));
            this.btnTinNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinNhan.Location = new System.Drawing.Point(5, 311);
            this.btnTinNhan.Name = "btnTinNhan";
            this.btnTinNhan.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnTinNhan.Size = new System.Drawing.Size(244, 43);
            this.btnTinNhan.TabIndex = 16;
            this.btnTinNhan.Text = "  Tin nhắn";
            this.btnTinNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnHocPhi
            // 
            this.btnHocPhi.FlatAppearance.BorderSize = 0;
            this.btnHocPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocPhi.Image = ((System.Drawing.Image)(resources.GetObject("btnHocPhi.Image")));
            this.btnHocPhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.Location = new System.Drawing.Point(5, 261);
            this.btnHocPhi.Name = "btnHocPhi";
            this.btnHocPhi.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnHocPhi.Size = new System.Drawing.Size(244, 43);
            this.btnHocPhi.TabIndex = 15;
            this.btnHocPhi.Text = "  Học phí";
            this.btnHocPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocPhi.Click += new System.EventHandler(this.btnHocPhi_Click_1);
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.FlatAppearance.BorderSize = 0;
            this.btnXemDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDiem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDiem.Image = ((System.Drawing.Image)(resources.GetObject("btnXemDiem.Image")));
            this.btnXemDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDiem.Location = new System.Drawing.Point(5, 211);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnXemDiem.Size = new System.Drawing.Size(244, 43);
            this.btnXemDiem.TabIndex = 14;
            this.btnXemDiem.Text = "  Xem điểm";
            this.btnXemDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemDiem.Click += new System.EventHandler(this.btnXemDiem_Click_1);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.FlatAppearance.BorderSize = 0;
            this.btnNhapDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapDiem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapDiem.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapDiem.Image")));
            this.btnNhapDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapDiem.Location = new System.Drawing.Point(3, 161);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnNhapDiem.Size = new System.Drawing.Size(244, 43);
            this.btnNhapDiem.TabIndex = 13;
            this.btnNhapDiem.Text = "  Nhập điểm";
            this.btnNhapDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GUI.Properties.Resources.icons8_person_96;
            this.pictureBox1.Location = new System.Drawing.Point(69, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnQuanLyKhoiLop
            // 
            this.btnQuanLyKhoiLop.FlatAppearance.BorderSize = 0;
            this.btnQuanLyKhoiLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyKhoiLop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyKhoiLop.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyKhoiLop.Image")));
            this.btnQuanLyKhoiLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhoiLop.Location = new System.Drawing.Point(5, 610);
            this.btnQuanLyKhoiLop.Name = "btnQuanLyKhoiLop";
            this.btnQuanLyKhoiLop.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnQuanLyKhoiLop.Size = new System.Drawing.Size(244, 43);
            this.btnQuanLyKhoiLop.TabIndex = 22;
            this.btnQuanLyKhoiLop.Text = "  Quản lý khối lớp";
            this.btnQuanLyKhoiLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhoiLop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnQuanLyMonHoc
            // 
            this.btnQuanLyMonHoc.FlatAppearance.BorderSize = 0;
            this.btnQuanLyMonHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyMonHoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyMonHoc.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyMonHoc.Image")));
            this.btnQuanLyMonHoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyMonHoc.Location = new System.Drawing.Point(3, 652);
            this.btnQuanLyMonHoc.Name = "btnQuanLyMonHoc";
            this.btnQuanLyMonHoc.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnQuanLyMonHoc.Size = new System.Drawing.Size(244, 43);
            this.btnQuanLyMonHoc.TabIndex = 23;
            this.btnQuanLyMonHoc.Text = "  Quản lý môn học";
            this.btnQuanLyMonHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyMonHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.btnQuanLyMonHoc);
            this.Controls.Add(this.btnQuanLyKhoiLop);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnTaiKhoan);
            this.Controls.Add(this.btnQuanLyLopHoc);
            this.Controls.Add(this.btnLopHoc);
            this.Controls.Add(this.btnHocSinh);
            this.Controls.Add(this.btnLichDay);
            this.Controls.Add(this.btnXemTKB);
            this.Controls.Add(this.btnTinNhan);
            this.Controls.Add(this.btnHocPhi);
            this.Controls.Add(this.btnXemDiem);
            this.Controls.Add(this.btnNhapDiem);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(258, 796);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Label lbInfo;
        private Button btnQuanLyLopHoc;
        private Button btnLopHoc;
        private Button btnHocSinh;
        private Button btnLichDay;
        private Button btnXemTKB;
        private Button btnTinNhan;
        private Button btnHocPhi;
        private Button btnXemDiem;
        private Button btnNhapDiem;
        private Button btnTaiKhoan;
        private Button btnDangXuat;
        private Button btnQuanLyKhoiLop;
        private Button btnQuanLyMonHoc;
    }
}
