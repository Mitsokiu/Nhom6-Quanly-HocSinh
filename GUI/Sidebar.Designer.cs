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
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnHocSinh = new System.Windows.Forms.Button();
            this.btnXemLichDay = new System.Windows.Forms.Button();
            this.btnXemTKB = new System.Windows.Forms.Button();
            this.btnTinNhan = new System.Windows.Forms.Button();
            this.btnHocPhi = new System.Windows.Forms.Button();
            this.btnXemDiem = new System.Windows.Forms.Button();
            this.btnNhapDiem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.btnTaiKhoan.Location = new System.Drawing.Point(3, 610);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(244, 43);
            this.btnTaiKhoan.TabIndex = 21;
            this.btnTaiKhoan.Text = "  Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.FlatAppearance.BorderSize = 0;
            this.btnDiemDanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiemDanh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiemDanh.Image = ((System.Drawing.Image)(resources.GetObject("btnDiemDanh.Image")));
            this.btnDiemDanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.Location = new System.Drawing.Point(5, 561);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnDiemDanh.Size = new System.Drawing.Size(244, 43);
            this.btnDiemDanh.TabIndex = 21;
            this.btnDiemDanh.Text = "  Điểm danh";
            this.btnDiemDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiemDanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            // btnXemLichDay
            // 
            this.btnXemLichDay.FlatAppearance.BorderSize = 0;
            this.btnXemLichDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemLichDay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemLichDay.Image = ((System.Drawing.Image)(resources.GetObject("btnXemLichDay.Image")));
            this.btnXemLichDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLichDay.Location = new System.Drawing.Point(5, 411);
            this.btnXemLichDay.Name = "btnXemLichDay";
            this.btnXemLichDay.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnXemLichDay.Size = new System.Drawing.Size(244, 43);
            this.btnXemLichDay.TabIndex = 18;
            this.btnXemLichDay.Text = "  Lịch dạy";
            this.btnXemLichDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLichDay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnTaiKhoan);
            this.Controls.Add(this.btnDiemDanh);
            this.Controls.Add(this.btnLopHoc);
            this.Controls.Add(this.btnHocSinh);
            this.Controls.Add(this.btnXemLichDay);
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
        private Button btnDiemDanh;
        private Button btnLopHoc;
        private Button btnHocSinh;
        private Button btnXemLichDay;
        private Button btnXemTKB;
        private Button btnTinNhan;
        private Button btnHocPhi;
        private Button btnXemDiem;
        private Button btnNhapDiem;
        private Button btnTaiKhoan;
        private Button btnDangXuat;
    }
}
