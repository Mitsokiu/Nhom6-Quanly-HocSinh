using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    public partial class Sidebar : UserControl
    {
        // Events để MainForm bắt được
        public event EventHandler BtnNhapDiemClick;
        public event EventHandler BtnXemDiemClick;
        public event EventHandler BtnHocSinhClick;
        public event EventHandler BtnHocPhiClick;
        public event EventHandler BtnLopHoc_Click; // Của giáo viên/học sinh
        public event EventHandler BtnDangXuat_Click_Event;
        public event EventHandler BtnLichDayClick;
        public event EventHandler BtnXemTKBClick;

        // Event riêng cho Admin
        public event EventHandler BtnQuanLyMonHoc_Click;
        public event EventHandler BtnQuanLyKhoiLop_Click;
        public event EventHandler BtnQuanLyLopHoc_Click; 
        public event EventHandler BtnTaiKhoan_Click;

        public Sidebar()
        {
            InitializeComponent();
            // Gán sự kiện Click thủ công vì trong Designer.cs chưa có
            DangKySuKien();
        }

        private void DangKySuKien()
        {
            // Admin Buttons
            this.btnQuanLyLopHoc.Click += (s, e) => BtnQuanLyLopHoc_Click?.Invoke(this, EventArgs.Empty);
            this.btnQuanLyKhoiLop.Click += (s, e) => BtnQuanLyKhoiLop_Click?.Invoke(this, EventArgs.Empty);
            this.btnQuanLyMonHoc.Click += (s, e) => BtnQuanLyMonHoc_Click?.Invoke(this, EventArgs.Empty);
        }

        public void PhanQuyen(string role)
        {
            // 1. Danh sách TẤT CẢ các nút cần quản lý ẩn/hiện
            // Phải liệt kê đủ thì mới ẩn sạch được
            List<Button> allBtns = new List<Button>() {
                btnNhapDiem, btnXemDiem, btnHocPhi, btnTinNhan, btnXemTKB,
                btnLichDay, btnHocSinh, btnLopHoc,
                btnQuanLyLopHoc, btnQuanLyKhoiLop, btnQuanLyMonHoc,
                btnTaiKhoan, btnDangXuat
            };

            // Ẩn tất cả trước
            foreach (var btn in allBtns) btn.Visible = false;

            // Cập nhật thông tin user
            lbInfo.Text = role;

            // Danh sách các nút sẽ hiện
            List<Button> activeButtons = new List<Button>();

            if (role == "Admin")
            {
                activeButtons.Add(btnQuanLyLopHoc); // Nút riêng của Admin
                activeButtons.Add(btnQuanLyKhoiLop);
                activeButtons.Add(btnQuanLyMonHoc);
                activeButtons.Add(btnTaiKhoan);
                activeButtons.Add(btnDangXuat); // Admin cũng cần đăng xuất
            }
            else if (role == "GiaoVien")
            {
                activeButtons.Add(btnNhapDiem);
                activeButtons.Add(btnLopHoc);
                activeButtons.Add(btnLichDay);
                activeButtons.Add(btnHocSinh);
                activeButtons.Add(btnTinNhan);
                activeButtons.Add(btnDangXuat);
            }
            else if (role == "HocSinh" || role == "PhuHuynh")
            {
                activeButtons.Add(btnXemDiem);
                activeButtons.Add(btnXemTKB);
                activeButtons.Add(btnHocPhi);
                activeButtons.Add(btnTinNhan);
                activeButtons.Add(btnDangXuat);
            }

            // Hiển thị và sắp xếp lại vị trí
            SapXepViTri(activeButtons);
        }

        private void SapXepViTri(List<Button> buttons)
        {
            int startY = 160;
            int gap = 50;

            foreach (var btn in buttons)
            {
                btn.Visible = true; // Hiện nút
                btn.Location = new Point(3, startY);
                startY += gap;
            }
        }

        // --- Các Event Handlers có sẵn trong Designer ---
        private void btnNhapDiem_Click(object sender, EventArgs e) => BtnNhapDiemClick?.Invoke(this, EventArgs.Empty);
        private void btnXemDiem_Click_1(object sender, EventArgs e) => BtnXemDiemClick?.Invoke(this, EventArgs.Empty);
        private void btnHocSinh_Click(object sender, EventArgs e) => BtnHocSinhClick?.Invoke(this, EventArgs.Empty);
        private void btnHocPhi_Click_1(object sender, EventArgs e) => BtnHocPhiClick?.Invoke(this, EventArgs.Empty);
        private void btnLopHoc_Click(object sender, EventArgs e) => BtnLopHoc_Click?.Invoke(this, EventArgs.Empty);
        private void btnTaiKhoan_Click(object sender, EventArgs e) => BtnTaiKhoan_Click?.Invoke(this, EventArgs.Empty);
        private void btnLichDay_Click(object sender, EventArgs e) => BtnLichDayClick?.Invoke(this, EventArgs.Empty);
        private void btnXemTKB_Click(object sender, EventArgs e) => BtnXemTKBClick?.Invoke(this, EventArgs.Empty);
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            BtnDangXuat_Click_Event?.Invoke(this, EventArgs.Empty);
            Form parentForm = this.FindForm();
            if (parentForm != null) parentForm.Close();
        }

        // Các event click dư thừa (do designer sinh ra) có thể để trống
        private void lbInfo_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}