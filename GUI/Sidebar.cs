using DTO;
using System;
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

        private UserDTO currentUser;

        public Sidebar()
        {
            InitializeComponent();

            // Cấu hình layout
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
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
                    ShowButtons(btnTaiKhoan, btnQlyLop, btnNamhoc,btnHome);
                    break;
                case "gvbm":
                    ShowButtons(btnNhapDiem, btnXemLichDay, btnHome);
                    break;
                case "gvcn":
                    ShowButtons(btnHocSinh, btnNhapDiem, btnXemLichDay, btnHome);
                    break;
                
                  
                case "student":
                    ShowButtons(btnXemDiem, btnXemTKB, btnHome, btnHocPhi, btnTinhHinh);
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
        // XỬ LÝ CLICK NÚT
        // ============================
        private void btnTaiKhoan_Click(object sender, EventArgs e) => TaiKhoanClicked?.Invoke(this, EventArgs.Empty);
        private void btnNhapDiem_Click(object sender, EventArgs e) => NhapDiemClicked?.Invoke(this, EventArgs.Empty);
        private void btnXemDiem_Click(object sender, EventArgs e) => XemDiemClicked?.Invoke(this, EventArgs.Empty);
        private void btnHocPhi_Click(object sender, EventArgs e) => HocPhiClicked?.Invoke(this, EventArgs.Empty);
        private void btnXemTKB_Click(object sender, EventArgs e) => XemTKBClicked?.Invoke(this, EventArgs.Empty);
        private void btnXemLichDay_Click(object sender, EventArgs e) => XemLichDayClicked?.Invoke(this, EventArgs.Empty);
        private void btnHocSinh_Click(object sender, EventArgs e) => HocSinhClicked?.Invoke(this, EventArgs.Empty);
        private void btnTinhHinh_Click(object sender, EventArgs e) => TinhHinhClicked?.Invoke(this, EventArgs.Empty);
        private void btnQlyLop_Click(object sender, EventArgs e) => QlyLopClicked?.Invoke(this, EventArgs.Empty);
        private void btnCauHinh_Click(object sender, EventArgs e) => CauHinhClicked?.Invoke(this, EventArgs.Empty);
        private void btnHome_Click(object sender, EventArgs e) => HomeClicked?.Invoke(this, EventArgs.Empty);

        private void btnNamhoc_Click(object sender, EventArgs e) => QlyNamHocClicked?.Invoke(this, EventArgs.Empty);
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
