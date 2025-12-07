using DTO;
using System;
using System.Drawing; // Thêm thư viện này để dùng Color
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Sidebar : UserControl
    {
        // ============================
        // KHAI BÁO SỰ KIỆN
        // ============================
        public event EventHandler TaiKhoanClicked;
        public event EventHandler NhapDiemClicked;
        public event EventHandler XemDiemClicked;
        public event EventHandler HocPhiClicked;
        public event EventHandler XemTKBClicked;
        public event EventHandler XemLichDayClicked;
        public event EventHandler HocSinhClicked;
        public event EventHandler TinhHinhClicked;
        public event EventHandler QlyLopClicked;
        public event EventHandler CauHinhClicked;
        public event EventHandler HomeClicked;
        public event EventHandler QlyNamHocClicked;
        public event EventHandler XemThongBaoClicked;
        public event EventHandler XemThongTinHocSinhClicked;
        public event EventHandler DoiMatKhauHSClicked;
        public event EventHandler QuanLyThongBaoClicked;
        public event EventHandler XetHanhKiemClicked;
        public event EventHandler DiemDanhClicked;
        public event EventHandler QlyKhoiClicked;
        public event EventHandler QlyMonClicked;
        
        private UserDTO currentUser;

        // Màu sắc cho trạng thái Active và Normal
        private Color activeColor = Color.PowderBlue; // Màu khi được chọn
        private Color normalColor = Color.White;      // Màu mặc định
        private Color hoverColor = Color.WhiteSmoke;  // Màu khi di chuột (nếu cần)

        public Sidebar()
        {
            InitializeComponent();

            // Cấu hình layout
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;

            // Xử lý giao diện (Bỏ viền, chỉnh width để bỏ scroll ngang)
            SetupButtons();
        }

        // ============================
        // HÀM CẤU HÌNH GIAO DIỆN NÚT
        // ============================
        private void SetupButtons()
        {
            // Tính toán chiều rộng nút để không hiện Scrollbar ngang
            // Trừ đi khoảng 25px (độ rộng thanh cuộn dọc)
            int buttonWidth = flowLayoutPanel1.Width - SystemInformation.VerticalScrollBarWidth - 5;

            // Duyệt qua tất cả control trong FlowLayoutPanel
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Button btn)
                {
                    ConfigureButton(btn, buttonWidth);
                }
            }

            // Cấu hình riêng cho btnHome (vì nó nằm ngoài FlowLayoutPanel)
            ConfigureButton(btnHome, 0); // 0 nghĩa là giữ nguyên width cũ
        }

        private void ConfigureButton(Button btn, int width)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; // Bỏ viền
            btn.BackColor = normalColor;
            
            // Chỉnh lại kích thước để tránh thanh cuộn ngang
            if (width > 0)
            {
                btn.Width = width;
                btn.Margin = new Padding(0, 0, 0, 0); // Bỏ margin để sát lề
            }
        }

        // ============================
        // HÀM ĐỔI MÀU NÚT (HIGHLIGHT)
        // ============================
        private void HighlightButton(object sender)
        {
            if (sender is Button clickedBtn)
            {
                // 1. Reset màu tất cả các nút trong FlowPanel
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is Button btn) btn.BackColor = normalColor;
                }
                
                // 2. Reset màu btnHome
                btnHome.BackColor = normalColor;

                // 3. Đổi màu nút được click
                clickedBtn.BackColor = activeColor;
            }
        }

        // ============================
        // GÁN THÔNG TIN NGƯỜI DÙNG
        // ============================
        public void SetUserInfo(UserDTO user)
        {
            if (user == null) return;

            currentUser = user;

            lbInfo.Text = $"{user.Fullname} ({user.RoleName})";
            SetRole(user.RoleName);
        }

        // ============================
        // ẨN/HIỆN NÚT THEO VAI TRÒ
        // ============================
        public void SetRole(string role)
        {
            // Ẩn toàn bộ trước
            foreach (Button btn in flowLayoutPanel1.Controls.OfType<Button>())
                btn.Visible = false;

            // Hiển thị nút theo quyền
            switch (role?.ToLower())
            {
                case "admin":
                    ShowButtons(btnTaiKhoan, btnQlyLop, btnQlyMon, btnQlyKhoi, btnNamhoc, btnHome);
                    break;
                case "gvbm":
                    ShowButtons(btnNhapDiem, btnXemLichDay, btnHome);
                    break;
                case "gvcn":
                    ShowButtons(btnHocSinh, btnNhapDiem, btnXemLichDay, btnHome, btnQuanLyThongBao, btnXetHanhKiem, btnDiemDanh);
                    break;
                case "student":
                    ShowButtons(btnXemThongTinHocSinh, btnDoiMatKhauHS, btnXemDiem, btnXemTKB, btnHome, btnHocPhi, btnTinhHinh, btnXemThongBao);
                    break;
                default:
                    ShowButtons(btnHome);
                    break;
            }
        }

        private void ShowButtons(params Button[] buttons)
        {
            foreach (var btn in buttons)
                if (btn != null) btn.Visible = true;
        }

        // ============================
        // XỬ LÝ CLICK NÚT (ĐÃ THÊM HIGHLIGHT)
        // ============================
        private void btnTaiKhoan_Click(object sender, EventArgs e) { HighlightButton(sender); TaiKhoanClicked?.Invoke(this, EventArgs.Empty); }
        private void btnNhapDiem_Click(object sender, EventArgs e) { HighlightButton(sender); NhapDiemClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemDiem_Click(object sender, EventArgs e) { HighlightButton(sender); XemDiemClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemTKB_Click(object sender, EventArgs e) { HighlightButton(sender); XemTKBClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemThongBao_Click(object sender, EventArgs e) { HighlightButton(sender); XemThongBaoClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemLichDay_Click(object sender, EventArgs e) { HighlightButton(sender); XemLichDayClicked?.Invoke(this, EventArgs.Empty); }
        private void btnHocSinh_Click(object sender, EventArgs e) { HighlightButton(sender); HocSinhClicked?.Invoke(this, EventArgs.Empty); }
        private void btnTinhHinh_Click(object sender, EventArgs e) { HighlightButton(sender); TinhHinhClicked?.Invoke(this, EventArgs.Empty); }
        private void btnQlyLop_Click(object sender, EventArgs e) { HighlightButton(sender); QlyLopClicked?.Invoke(this, EventArgs.Empty); }
        private void btnQlyKhoi_Click(object sender, EventArgs e) { HighlightButton(sender); QlyKhoiClicked?.Invoke(this, EventArgs.Empty); }
        private void btnQlyMon_Click(object sender, EventArgs e) { HighlightButton(sender); QlyMonClicked?.Invoke(this, EventArgs.Empty); }
        private void btnCauHinh_Click(object sender, EventArgs e) { HighlightButton(sender); CauHinhClicked?.Invoke(this, EventArgs.Empty); }
        private void btnHome_Click(object sender, EventArgs e) { HighlightButton(sender); HomeClicked?.Invoke(this, EventArgs.Empty); }
        private void btnHocPhi_Click(object sender, EventArgs e) { HighlightButton(sender); HocPhiClicked?.Invoke(this, EventArgs.Empty); }
        private void btnNamhoc_Click(object sender, EventArgs e) { HighlightButton(sender); QlyNamHocClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemThongTinHocSinh_Click(object sender, EventArgs e) { HighlightButton(sender); XemThongTinHocSinhClicked?.Invoke(this, EventArgs.Empty); }
        private void btnDoiMatKhauHS_Click(object sender, EventArgs e) { HighlightButton(sender); DoiMatKhauHSClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXetHanhKiem_Click(object sender, EventArgs e) { HighlightButton(sender); XetHanhKiemClicked?.Invoke(this, EventArgs.Empty); }
        private void btnDiemDanh_Click(object sender, EventArgs e) { HighlightButton(sender); DiemDanhClicked?.Invoke(this, EventArgs.Empty); }
        private void btnQuanLyThongBao_Click(object sender, EventArgs e) { HighlightButton(sender); QuanLyThongBaoClicked?.Invoke(this, EventArgs.Empty); }

        // ============================
        // XỬ LÝ ĐĂNG XUẤT
        // ============================
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Ẩn form hiện tại và mở lại form đăng nhập
                Form mainForm = this.FindForm();
                mainForm?.Hide();

                Login loginForm = new Login();
                loginForm.FormClosed += (s, args) => mainForm?.Close();
                loginForm.Show();
            }
        }

        private void lbInfo_Click(object sender, EventArgs e)
        {
            // Có thể dùng để hiện popup thông tin tài khoản nếu cần
        }
    }
}