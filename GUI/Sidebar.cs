using DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Sidebar : UserControl
    {
        // Khai báo sự kiện
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
        public event EventHandler QlyHocSinhAdminClicked;
        public event EventHandler ThongKeClicked;
        public event EventHandler HSinforClicked;
        public event EventHandler DoiMk;
        public event EventHandler XetHanhKiemClicked;
        public event EventHandler qlyThongBaoClicked;
        public event EventHandler XemThongBaoClicked;
        public event EventHandler DiemDanhClicked;

        private UserDTO currentUser;

        // Biến lưu nút đang được chọn
        private Button currentBtn;

        public Sidebar()
        {
            InitializeComponent();
        }

        // ============================
        // HÀM XỬ LÝ ACTIVE BUTTON (Highlight)
        // ============================
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                // 1. Reset màu tất cả các nút về trắng
                DisableButton();

                // 2. Tô màu nút được chọn
                currentBtn = (Button)btnSender;
                // Màu nền khi Active (Ví dụ: Xanh nhạt hiện đại)
                currentBtn.BackColor = Color.FromArgb(230, 242, 255);
                currentBtn.ForeColor = Color.FromArgb(0, 102, 204); // Chữ xanh đậm
                currentBtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold); // Chữ đậm lên
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in flowLayoutPanel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.White;
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                }
            }
        }

        // ============================
        // GÁN THÔNG TIN USER
        // ============================
        public void SetUserInfo(UserDTO user)
        {
            if (user == null) return;
            currentUser = user;
            lbInfo.Text = $"{user.Fullname}\n({user.RoleName})"; // Xuống dòng cho gọn
            SetRole(user.RoleName);
        }

        public void SetRole(string role)
        {
            foreach (Button btn in flowLayoutPanel1.Controls.OfType<Button>())
                btn.Visible = false;

            switch (role?.ToLower())
            {
                case "admin":
                    ShowButtons(btnTaiKhoan, btnQlyLop, btnNamhoc, btnhocsinhadmin, btnThongKe);
                    break;
                case "gvbm":
                    ShowButtons(btnNhapDiem, btnXemLichDay);
                    break;
                case "gvcn":
                    ShowButtons(btnHocSinh, btnXetHanhKiem, btnQuanLyThongBao, btnDiemDanh);
                    break;
                case "student":
                    ShowButtons(btnXemDiem, btnXemTKB, btnHocPhi, btninfor, btnDoiMatKhauHS, btnXemThongBao);
                    break;
                default:
                    // ShowButtons(btnHome); // Home để ở trên Avatar rồi
                    break;
            }
        }

        private void ShowButtons(params Button[] buttons)
        {
            foreach (var btn in buttons)
                if (btn != null) btn.Visible = true;
        }

        // ============================
        // SỬA LẠI CÁC SỰ KIỆN CLICK ĐỂ GỌI ActivateButton
        // ============================
        private void btnHome_Click(object sender, EventArgs e)
        {
            DisableButton(); // Click avatar thì bỏ chọn các nút menu
            HomeClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e) { ActivateButton(sender); TaiKhoanClicked?.Invoke(this, EventArgs.Empty); }
        private void btnNhapDiem_Click(object sender, EventArgs e) { ActivateButton(sender); NhapDiemClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemDiem_Click(object sender, EventArgs e) { ActivateButton(sender); XemDiemClicked?.Invoke(this, EventArgs.Empty); }
        private void btnHocPhi_Click(object sender, EventArgs e) { ActivateButton(sender); HocPhiClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemTKB_Click(object sender, EventArgs e) { ActivateButton(sender); XemTKBClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemLichDay_Click(object sender, EventArgs e) { ActivateButton(sender); XemLichDayClicked?.Invoke(this, EventArgs.Empty); }
        private void btnHocSinh_Click(object sender, EventArgs e) { ActivateButton(sender); HocSinhClicked?.Invoke(this, EventArgs.Empty); }
        private void btnhocsinhadmin_Click(object sender, EventArgs e) { ActivateButton(sender); QlyHocSinhAdminClicked?.Invoke(this, EventArgs.Empty); }
        private void btnTinhHinh_Click(object sender, EventArgs e) { ActivateButton(sender); TinhHinhClicked?.Invoke(this, EventArgs.Empty); }
        private void btnQlyLop_Click(object sender, EventArgs e) { ActivateButton(sender); QlyLopClicked?.Invoke(this, EventArgs.Empty); }
        private void btnNamhoc_Click(object sender, EventArgs e) { ActivateButton(sender); QlyNamHocClicked?.Invoke(this, EventArgs.Empty); }
        private void btnThongKe_Click(object sender, EventArgs e) { ActivateButton(sender); ThongKeClicked?.Invoke(this, EventArgs.Empty); }
        private void btnHSinfor_Click(object sender, EventArgs e) { ActivateButton(sender); HSinforClicked?.Invoke(this, EventArgs.Empty); }
        private void btnDoiMatKhauHS_Click(object sender, EventArgs e) { ActivateButton(sender); DoiMk?.Invoke(this, EventArgs.Empty); }
        private void btnXetHanhKiem_Click(object sender, EventArgs e) { ActivateButton(sender); XetHanhKiemClicked?.Invoke(this, EventArgs.Empty); }
        private void btnQuanLyThongBao_Click(object sender, EventArgs e) { ActivateButton(sender); qlyThongBaoClicked?.Invoke(this, EventArgs.Empty); }
        private void btnXemThongBao_Click(object sender, EventArgs e) { ActivateButton(sender); XemThongBaoClicked?.Invoke(this, EventArgs.Empty); }
        private void btnDiemDanh_Click(object sender, EventArgs e) { ActivateButton(sender); DiemDanhClicked?.Invoke(this, EventArgs.Empty); }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form mainForm = this.FindForm();
                mainForm?.Hide();
                Login loginForm = new Login();
                loginForm.FormClosed += (s, args) => mainForm?.Close();
                loginForm.Show();
            }
        }

        private void lbInfo_Click(object sender, EventArgs e) { }
    }
}