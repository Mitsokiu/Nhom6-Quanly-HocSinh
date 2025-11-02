using System.Windows.Forms;

namespace GUI
{
    partial class Sidebar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lbWelcome = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnNhapDiem = new System.Windows.Forms.Button();
            this.btnXemDiem = new System.Windows.Forms.Button();
            this.btnHocPhi = new System.Windows.Forms.Button();
            this.btnXemTKB = new System.Windows.Forms.Button();
            this.btnXemLichDay = new System.Windows.Forms.Button();
            this.btnHocSinh = new System.Windows.Forms.Button();
            this.btnTinhHinh = new System.Windows.Forms.Button();
            this.btnQlyLop = new System.Windows.Forms.Button();
            this.btnCauHinh = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(87, 121);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(119, 29);
            this.lbWelcome.TabIndex = 1;
            this.lbWelcome.Text = "Xin chào !";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(64, 156);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(164, 29);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "Nguyễn Văn A";
            this.lbInfo.Click += new System.EventHandler(this.lbInfo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnTaiKhoan);
            this.flowLayoutPanel1.Controls.Add(this.btnNhapDiem);
            this.flowLayoutPanel1.Controls.Add(this.btnXemDiem);
            this.flowLayoutPanel1.Controls.Add(this.btnHocPhi);
            this.flowLayoutPanel1.Controls.Add(this.btnXemTKB);
            this.flowLayoutPanel1.Controls.Add(this.btnXemLichDay);
            this.flowLayoutPanel1.Controls.Add(this.btnHocSinh);
            this.flowLayoutPanel1.Controls.Add(this.btnTinhHinh);
            this.flowLayoutPanel1.Controls.Add(this.btnQlyLop);
            this.flowLayoutPanel1.Controls.Add(this.btnCauHinh);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 188);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 600);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Image = global::GUI.Properties.Resources.taikhoan_24;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(3, 3);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(282, 50);
            this.btnTaiKhoan.TabIndex = 0;
            this.btnTaiKhoan.Text = "Qly Tài khoản";
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Image = global::GUI.Properties.Resources.nhapdiem_32;
            this.btnNhapDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapDiem.Location = new System.Drawing.Point(3, 59);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Size = new System.Drawing.Size(282, 50);
            this.btnNhapDiem.TabIndex = 1;
            this.btnNhapDiem.Text = "Nhập điểm";
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.Image = global::GUI.Properties.Resources.nhapdiem_32;
            this.btnXemDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDiem.Location = new System.Drawing.Point(3, 115);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.Size = new System.Drawing.Size(282, 50);
            this.btnXemDiem.TabIndex = 2;
            this.btnXemDiem.Text = "Xem điểm";
            this.btnXemDiem.Click += new System.EventHandler(this.btnXemDiem_Click);
            // 
            // btnHocPhi
            // 
            this.btnHocPhi.Image = global::GUI.Properties.Resources.hocphi_24;
            this.btnHocPhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.Location = new System.Drawing.Point(3, 171);
            this.btnHocPhi.Name = "btnHocPhi";
            this.btnHocPhi.Size = new System.Drawing.Size(282, 50);
            this.btnHocPhi.TabIndex = 3;
            this.btnHocPhi.Text = "Học phí";
            this.btnHocPhi.Click += new System.EventHandler(this.btnHocPhi_Click);
            // 
            // btnXemTKB
            // 
            this.btnXemTKB.Image = global::GUI.Properties.Resources.xemtkb_24;
            this.btnXemTKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKB.Location = new System.Drawing.Point(3, 227);
            this.btnXemTKB.Name = "btnXemTKB";
            this.btnXemTKB.Size = new System.Drawing.Size(282, 50);
            this.btnXemTKB.TabIndex = 4;
            this.btnXemTKB.Text = "Thời khóa biểu";
            this.btnXemTKB.Click += new System.EventHandler(this.btnXemTKB_Click);
            // 
            // btnXemLichDay
            // 
            this.btnXemLichDay.Image = global::GUI.Properties.Resources.xemlichday_24;
            this.btnXemLichDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLichDay.Location = new System.Drawing.Point(3, 283);
            this.btnXemLichDay.Name = "btnXemLichDay";
            this.btnXemLichDay.Size = new System.Drawing.Size(282, 50);
            this.btnXemLichDay.TabIndex = 5;
            this.btnXemLichDay.Text = "Lịch dạy";
            this.btnXemLichDay.Click += new System.EventHandler(this.btnXemLichDay_Click);
            // 
            // btnHocSinh
            // 
            this.btnHocSinh.Image = global::GUI.Properties.Resources.hocsinh_24;
            this.btnHocSinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocSinh.Location = new System.Drawing.Point(3, 339);
            this.btnHocSinh.Name = "btnHocSinh";
            this.btnHocSinh.Size = new System.Drawing.Size(282, 50);
            this.btnHocSinh.TabIndex = 6;
            this.btnHocSinh.Text = "Học sinh";
            this.btnHocSinh.Click += new System.EventHandler(this.btnHocSinh_Click);
            // 
            // btnTinhHinh
            // 
            this.btnTinhHinh.Image = global::GUI.Properties.Resources.xinphepvang_24;
            this.btnTinhHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhHinh.Location = new System.Drawing.Point(3, 395);
            this.btnTinhHinh.Name = "btnTinhHinh";
            this.btnTinhHinh.Size = new System.Drawing.Size(282, 50);
            this.btnTinhHinh.TabIndex = 7;
            this.btnTinhHinh.Text = "Tình hình học tập";
            this.btnTinhHinh.Click += new System.EventHandler(this.btnTinhHinh_Click);
            // 
            // btnQlyLop
            // 
            this.btnQlyLop.Image = global::GUI.Properties.Resources.timkiem_24;
            this.btnQlyLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQlyLop.Location = new System.Drawing.Point(3, 451);
            this.btnQlyLop.Name = "btnQlyLop";
            this.btnQlyLop.Size = new System.Drawing.Size(282, 50);
            this.btnQlyLop.TabIndex = 8;
            this.btnQlyLop.Text = "Qly Lớp, Môn học";
            this.btnQlyLop.Click += new System.EventHandler(this.btnQlyLop_Click);
            // 
            // btnCauHinh
            // 
            this.btnCauHinh.Image = global::GUI.Properties.Resources.tinnhan_24;
            this.btnCauHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCauHinh.Location = new System.Drawing.Point(3, 507);
            this.btnCauHinh.Name = "btnCauHinh";
            this.btnCauHinh.Size = new System.Drawing.Size(282, 50);
            this.btnCauHinh.TabIndex = 9;
            this.btnCauHinh.Text = "Cấu hình hệ thống";
            this.btnCauHinh.Click += new System.EventHandler(this.btnCauHinh_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.Image = global::GUI.Properties.Resources.dangxuat_24;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 787);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(291, 86);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = global::GUI.Properties.Resources.icons8_person_96;
            this.btnHome.Location = new System.Drawing.Point(82, 13);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(130, 97);
            this.btnHome.TabIndex = 5;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // Sidebar
            // 
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnDangXuat);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(291, 873);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbWelcome;
        private Label lbInfo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnTaiKhoan;
        private Button btnNhapDiem;
        private Button btnXemDiem;
        private Button btnHocPhi;
        private Button btnXemTKB;
        private Button btnXemLichDay;
        private Button btnHocSinh;
        private Button btnTinhHinh;
        private Button btnQlyLop;
        private Button btnCauHinh;
        private Button btnDangXuat;
        private Button btnHome;
    }
}
