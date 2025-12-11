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
            this.panelInfo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
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
            this.btnNamhoc = new System.Windows.Forms.Button();
            this.btnhocsinhadmin = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btninfor = new System.Windows.Forms.Button();
            this.btnDoiMatKhauHS = new System.Windows.Forms.Button();
            this.btnXetHanhKiem = new System.Windows.Forms.Button();
            this.btnQuanLyThongBao = new System.Windows.Forms.Button();
            this.btnXemThongBao = new System.Windows.Forms.Button();
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();

            this.panelInfo.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.btnHome);
            this.panelInfo.Controls.Add(this.lbWelcome);
            this.panelInfo.Controls.Add(this.lbInfo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(291, 220);
            this.panelInfo.TabIndex = 0;

            // 
            // btnHome (Avatar)
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Image = global::GUI.Properties.Resources.icons8_person_96;
            this.btnHome.Location = new System.Drawing.Point(80, 20);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(130, 97);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            // 
            // lbWelcome
            // 
            this.lbWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbWelcome.ForeColor = System.Drawing.Color.Gray;
            this.lbWelcome.Location = new System.Drawing.Point(0, 125);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(291, 23);
            this.lbWelcome.TabIndex = 1;
            this.lbWelcome.Text = "Xin chào !";
            this.lbWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbInfo.Location = new System.Drawing.Point(0, 150);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(291, 60);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "User Name\n(Role)";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbInfo.Click += new System.EventHandler(this.lbInfo_Click);

            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnTaiKhoan);
            this.flowLayoutPanel1.Controls.Add(this.btnNhapDiem);
            this.flowLayoutPanel1.Controls.Add(this.btnXemDiem);
            this.flowLayoutPanel1.Controls.Add(this.btnHocPhi);
            this.flowLayoutPanel1.Controls.Add(this.btnXemTKB);
            this.flowLayoutPanel1.Controls.Add(this.btnXemLichDay);
            this.flowLayoutPanel1.Controls.Add(this.btnHocSinh);
            this.flowLayoutPanel1.Controls.Add(this.btnTinhHinh);
            this.flowLayoutPanel1.Controls.Add(this.btnQlyLop);
            this.flowLayoutPanel1.Controls.Add(this.btnNamhoc);
            this.flowLayoutPanel1.Controls.Add(this.btnhocsinhadmin);
            this.flowLayoutPanel1.Controls.Add(this.btnThongKe);
            this.flowLayoutPanel1.Controls.Add(this.btninfor);
            this.flowLayoutPanel1.Controls.Add(this.btnDoiMatKhauHS);
            this.flowLayoutPanel1.Controls.Add(this.btnXetHanhKiem);
            this.flowLayoutPanel1.Controls.Add(this.btnQuanLyThongBao);
            this.flowLayoutPanel1.Controls.Add(this.btnXemThongBao);
            this.flowLayoutPanel1.Controls.Add(this.btnDiemDanh);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 220);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(291, 581);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;

            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnTaiKhoan.Image = global::GUI.Properties.Resources.taikhoan_24;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(0);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(270, 50);
            this.btnTaiKhoan.TabIndex = 0;
            this.btnTaiKhoan.Text = "  Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);

            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.FlatAppearance.BorderSize = 0;
            this.btnNhapDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapDiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnNhapDiem.Image = global::GUI.Properties.Resources.nhapdiem_32;
            this.btnNhapDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapDiem.Location = new System.Drawing.Point(0, 50);
            this.btnNhapDiem.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNhapDiem.Size = new System.Drawing.Size(270, 50);
            this.btnNhapDiem.TabIndex = 1;
            this.btnNhapDiem.Text = "  Nhập điểm";
            this.btnNhapDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhapDiem.UseVisualStyleBackColor = true;
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);

            // 
            // btnXemDiem
            // 
            this.btnXemDiem.FlatAppearance.BorderSize = 0;
            this.btnXemDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnXemDiem.Image = global::GUI.Properties.Resources.nhapdiem_32;
            this.btnXemDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDiem.Location = new System.Drawing.Point(0, 100);
            this.btnXemDiem.Margin = new System.Windows.Forms.Padding(0);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnXemDiem.Size = new System.Drawing.Size(270, 50);
            this.btnXemDiem.TabIndex = 2;
            this.btnXemDiem.Text = "  Xem điểm";
            this.btnXemDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemDiem.UseVisualStyleBackColor = true;
            this.btnXemDiem.Click += new System.EventHandler(this.btnXemDiem_Click);

            // 
            // btnHocPhi
            // 
            this.btnHocPhi.FlatAppearance.BorderSize = 0;
            this.btnHocPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhi.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnHocPhi.Image = global::GUI.Properties.Resources.hocphi_24;
            this.btnHocPhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.Location = new System.Drawing.Point(0, 150);
            this.btnHocPhi.Margin = new System.Windows.Forms.Padding(0);
            this.btnHocPhi.Name = "btnHocPhi";
            this.btnHocPhi.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHocPhi.Size = new System.Drawing.Size(270, 50);
            this.btnHocPhi.TabIndex = 3;
            this.btnHocPhi.Text = "  Học phí";
            this.btnHocPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocPhi.UseVisualStyleBackColor = true;
            this.btnHocPhi.Click += new System.EventHandler(this.btnHocPhi_Click);

            // 
            // btnXemTKB
            // 
            this.btnXemTKB.FlatAppearance.BorderSize = 0;
            this.btnXemTKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTKB.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnXemTKB.Image = global::GUI.Properties.Resources.xemtkb_24;
            this.btnXemTKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKB.Location = new System.Drawing.Point(0, 200);
            this.btnXemTKB.Margin = new System.Windows.Forms.Padding(0);
            this.btnXemTKB.Name = "btnXemTKB";
            this.btnXemTKB.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnXemTKB.Size = new System.Drawing.Size(270, 50);
            this.btnXemTKB.TabIndex = 4;
            this.btnXemTKB.Text = "  Thời khóa biểu";
            this.btnXemTKB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemTKB.UseVisualStyleBackColor = true;
            this.btnXemTKB.Click += new System.EventHandler(this.btnXemTKB_Click);

            // 
            // btnXemLichDay
            // 
            this.btnXemLichDay.FlatAppearance.BorderSize = 0;
            this.btnXemLichDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemLichDay.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnXemLichDay.Image = global::GUI.Properties.Resources.xemlichday_24;
            this.btnXemLichDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLichDay.Location = new System.Drawing.Point(0, 250);
            this.btnXemLichDay.Margin = new System.Windows.Forms.Padding(0);
            this.btnXemLichDay.Name = "btnXemLichDay";
            this.btnXemLichDay.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnXemLichDay.Size = new System.Drawing.Size(270, 50);
            this.btnXemLichDay.TabIndex = 5;
            this.btnXemLichDay.Text = "  Lịch dạy";
            this.btnXemLichDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLichDay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemLichDay.UseVisualStyleBackColor = true;
            this.btnXemLichDay.Click += new System.EventHandler(this.btnXemLichDay_Click);

            // 
            // btnHocSinh
            // 
            this.btnHocSinh.FlatAppearance.BorderSize = 0;
            this.btnHocSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocSinh.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnHocSinh.Image = global::GUI.Properties.Resources.hocsinh_24;
            this.btnHocSinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocSinh.Location = new System.Drawing.Point(0, 300);
            this.btnHocSinh.Margin = new System.Windows.Forms.Padding(0);
            this.btnHocSinh.Name = "btnHocSinh";
            this.btnHocSinh.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHocSinh.Size = new System.Drawing.Size(270, 50);
            this.btnHocSinh.TabIndex = 6;
            this.btnHocSinh.Text = "  Học sinh";
            this.btnHocSinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocSinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocSinh.UseVisualStyleBackColor = true;
            this.btnHocSinh.Click += new System.EventHandler(this.btnHocSinh_Click);

            // 
            // btnTinhHinh
            // 
            this.btnTinhHinh.FlatAppearance.BorderSize = 0;
            this.btnTinhHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhHinh.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnTinhHinh.Image = global::GUI.Properties.Resources.xinphepvang_24;
            this.btnTinhHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhHinh.Location = new System.Drawing.Point(0, 350);
            this.btnTinhHinh.Margin = new System.Windows.Forms.Padding(0);
            this.btnTinhHinh.Name = "btnTinhHinh";
            this.btnTinhHinh.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTinhHinh.Size = new System.Drawing.Size(270, 50);
            this.btnTinhHinh.TabIndex = 7;
            this.btnTinhHinh.Text = "  Tình hình học tập";
            this.btnTinhHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhHinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTinhHinh.UseVisualStyleBackColor = true;
            this.btnTinhHinh.Click += new System.EventHandler(this.btnTinhHinh_Click);

            // 
            // btnQlyLop
            // 
            this.btnQlyLop.FlatAppearance.BorderSize = 0;
            this.btnQlyLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQlyLop.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnQlyLop.Image = global::GUI.Properties.Resources.board_24;
            this.btnQlyLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQlyLop.Location = new System.Drawing.Point(0, 400);
            this.btnQlyLop.Margin = new System.Windows.Forms.Padding(0);
            this.btnQlyLop.Name = "btnQlyLop";
            this.btnQlyLop.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQlyLop.Size = new System.Drawing.Size(270, 50);
            this.btnQlyLop.TabIndex = 8;
            this.btnQlyLop.Text = "  Phân công";
            this.btnQlyLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQlyLop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQlyLop.UseVisualStyleBackColor = true;
            this.btnQlyLop.Click += new System.EventHandler(this.btnQlyLop_Click);

            // 
            // btnNamhoc
            // 
            this.btnNamhoc.FlatAppearance.BorderSize = 0;
            this.btnNamhoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNamhoc.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnNamhoc.Image = global::GUI.Properties.Resources.tinnhan_24;
            this.btnNamhoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNamhoc.Location = new System.Drawing.Point(0, 450);
            this.btnNamhoc.Margin = new System.Windows.Forms.Padding(0);
            this.btnNamhoc.Name = "btnNamhoc";
            this.btnNamhoc.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNamhoc.Size = new System.Drawing.Size(270, 50);
            this.btnNamhoc.TabIndex = 9;
            this.btnNamhoc.Text = "  Năm Học";
            this.btnNamhoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNamhoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNamhoc.UseVisualStyleBackColor = true;
            this.btnNamhoc.Click += new System.EventHandler(this.btnNamhoc_Click);

            // 
            // btnhocsinhadmin
            // 
            this.btnhocsinhadmin.FlatAppearance.BorderSize = 0;
            this.btnhocsinhadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhocsinhadmin.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnhocsinhadmin.Image = global::GUI.Properties.Resources.hocsinh_24;
            this.btnhocsinhadmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhocsinhadmin.Location = new System.Drawing.Point(0, 500);
            this.btnhocsinhadmin.Margin = new System.Windows.Forms.Padding(0);
            this.btnhocsinhadmin.Name = "btnhocsinhadmin";
            this.btnhocsinhadmin.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnhocsinhadmin.Size = new System.Drawing.Size(270, 50);
            this.btnhocsinhadmin.TabIndex = 10;
            this.btnhocsinhadmin.Text = "  Học sinh";
            this.btnhocsinhadmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhocsinhadmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnhocsinhadmin.UseVisualStyleBackColor = true;
            this.btnhocsinhadmin.Click += new System.EventHandler(this.btnhocsinhadmin_Click);

            // 
            // btnThongKe
            // 
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnThongKe.Image = global::GUI.Properties.Resources.xinphepvang_24;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(0, 550);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThongKe.Size = new System.Drawing.Size(270, 50);
            this.btnThongKe.TabIndex = 11;
            this.btnThongKe.Text = "  Thống Kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);

            // 
            // btninfor
            // 
            this.btninfor.FlatAppearance.BorderSize = 0;
            this.btninfor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btninfor.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btninfor.Image = global::GUI.Properties.Resources.hocsinh_24;
            this.btninfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninfor.Location = new System.Drawing.Point(0, 600);
            this.btninfor.Margin = new System.Windows.Forms.Padding(0);
            this.btninfor.Name = "btninfor";
            this.btninfor.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btninfor.Size = new System.Drawing.Size(270, 50);
            this.btninfor.TabIndex = 12;
            this.btninfor.Text = "  Thông Tin";
            this.btninfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninfor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btninfor.UseVisualStyleBackColor = true;
            this.btninfor.Click += new System.EventHandler(this.btnHSinfor_Click);

            // 
            // btnDoiMatKhauHS
            // 
            this.btnDoiMatKhauHS.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhauHS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhauHS.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnDoiMatKhauHS.Image = global::GUI.Properties.Resources.taikhoan_24;
            this.btnDoiMatKhauHS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhauHS.Location = new System.Drawing.Point(0, 650);
            this.btnDoiMatKhauHS.Margin = new System.Windows.Forms.Padding(0);
            this.btnDoiMatKhauHS.Name = "btnDoiMatKhauHS";
            this.btnDoiMatKhauHS.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDoiMatKhauHS.Size = new System.Drawing.Size(270, 50);
            this.btnDoiMatKhauHS.TabIndex = 13;
            this.btnDoiMatKhauHS.Text = "  Đổi mật khẩu";
            this.btnDoiMatKhauHS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhauHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoiMatKhauHS.UseVisualStyleBackColor = true;
            this.btnDoiMatKhauHS.Click += new System.EventHandler(this.btnDoiMatKhauHS_Click);

            // 
            // btnXetHanhKiem
            // 
            this.btnXetHanhKiem.FlatAppearance.BorderSize = 0;
            this.btnXetHanhKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXetHanhKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnXetHanhKiem.Image = global::GUI.Properties.Resources.xemdiem_24;
            this.btnXetHanhKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXetHanhKiem.Location = new System.Drawing.Point(0, 700);
            this.btnXetHanhKiem.Margin = new System.Windows.Forms.Padding(0);
            this.btnXetHanhKiem.Name = "btnXetHanhKiem";
            this.btnXetHanhKiem.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnXetHanhKiem.Size = new System.Drawing.Size(270, 50);
            this.btnXetHanhKiem.TabIndex = 14;
            this.btnXetHanhKiem.Text = "  Xét Hạnh kiểm";
            this.btnXetHanhKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXetHanhKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXetHanhKiem.UseVisualStyleBackColor = true;
            this.btnXetHanhKiem.Click += new System.EventHandler(this.btnXetHanhKiem_Click);

            // 
            // btnQuanLyThongBao
            // 
            this.btnQuanLyThongBao.FlatAppearance.BorderSize = 0;
            this.btnQuanLyThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyThongBao.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnQuanLyThongBao.Image = global::GUI.Properties.Resources.tinnhan_24;
            this.btnQuanLyThongBao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyThongBao.Location = new System.Drawing.Point(0, 750);
            this.btnQuanLyThongBao.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuanLyThongBao.Name = "btnQuanLyThongBao";
            this.btnQuanLyThongBao.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQuanLyThongBao.Size = new System.Drawing.Size(270, 50);
            this.btnQuanLyThongBao.TabIndex = 15;
            this.btnQuanLyThongBao.Text = "  Quản lý Thông báo";
            this.btnQuanLyThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyThongBao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyThongBao.UseVisualStyleBackColor = true;
            this.btnQuanLyThongBao.Click += new System.EventHandler(this.btnQuanLyThongBao_Click);

            // 
            // btnXemThongBao
            // 
            this.btnXemThongBao.FlatAppearance.BorderSize = 0;
            this.btnXemThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemThongBao.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnXemThongBao.Image = global::GUI.Properties.Resources.tinnhan_24;
            this.btnXemThongBao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemThongBao.Location = new System.Drawing.Point(0, 800);
            this.btnXemThongBao.Margin = new System.Windows.Forms.Padding(0);
            this.btnXemThongBao.Name = "btnXemThongBao";
            this.btnXemThongBao.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnXemThongBao.Size = new System.Drawing.Size(270, 50);
            this.btnXemThongBao.TabIndex = 16;
            this.btnXemThongBao.Text = "  Thông báo";
            this.btnXemThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemThongBao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemThongBao.UseVisualStyleBackColor = true;
            this.btnXemThongBao.Click += new System.EventHandler(this.btnXemThongBao_Click);

            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.FlatAppearance.BorderSize = 0;
            this.btnDiemDanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemDanh.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnDiemDanh.Image = global::GUI.Properties.Resources.xinphepvang_24;
            this.btnDiemDanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.Location = new System.Drawing.Point(0, 850);
            this.btnDiemDanh.Margin = new System.Windows.Forms.Padding(0);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDiemDanh.Size = new System.Drawing.Size(270, 50);
            this.btnDiemDanh.TabIndex = 17;
            this.btnDiemDanh.Text = "  Điểm danh";
            this.btnDiemDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiemDanh.UseVisualStyleBackColor = true;
            this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);

            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDangXuat.Image = global::GUI.Properties.Resources.dangxuat_24;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 801);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(291, 86);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "  Đăng xuất";
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            // 
            // Sidebar
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.btnDangXuat);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(291, 887);
            this.panelInfo.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        // Khai báo các nút
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnNhapDiem;
        private System.Windows.Forms.Button btnXemDiem;
        private System.Windows.Forms.Button btnHocPhi;
        private System.Windows.Forms.Button btnXemTKB;
        private System.Windows.Forms.Button btnXemLichDay;
        private System.Windows.Forms.Button btnHocSinh;
        private System.Windows.Forms.Button btnTinhHinh;
        private System.Windows.Forms.Button btnQlyLop;
        private System.Windows.Forms.Button btnNamhoc;
        private System.Windows.Forms.Button btnhocsinhadmin;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btninfor;
        private System.Windows.Forms.Button btnDoiMatKhauHS;
        private System.Windows.Forms.Button btnXetHanhKiem;
        private System.Windows.Forms.Button btnQuanLyThongBao;
        private System.Windows.Forms.Button btnXemThongBao;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnDiemDanh;
    }
}