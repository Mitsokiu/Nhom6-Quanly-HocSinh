using BUS; // Gọi tầng BUS
using DTO; // Gọi tầng DTO
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        private UserBUS userBUS;

        public Login()
        {
            InitializeComponent();
            userBUS = new UserBUS(); // Khởi tạo BUS
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Gọi BUS kiểm tra đăng nhập
                if (userBUS.Login(username, password))
                {
                    // 3. Nếu đúng, lấy thông tin User để biết Role
                    UserDTO user = userBUS.GetUserInfo(username);

                    // 4. Chuyển đổi Role từ Database sang Role của UI
                    // DB: admin, gvcn, gvbm, student
                    // UI (Sidebar): Admin, GiaoVien, HocSinh
                    string uiRole = MapRoleDbToUi(user.RoleName);

                    // 5. Mở Form Main
                    this.Hide();
                    // Lưu ý: Bạn có thể truyền cả đối tượng UserDTO sang MainForm nếu muốn hiển thị tên "Xin chào..."
                    MainForm mainForm = new MainForm(uiRole);
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm chuyển đổi tên quyền cho khớp với switch/case trong Sidebar.cs
        private string MapRoleDbToUi(string dbRole)
        {
            // Database values: 'admin', 'gvcn', 'gvbm', 'student', 'parent'
            switch (dbRole.ToLower())
            {
                case "admin":
                    return "Admin";
                case "gvcn":
                case "gvbm":
                    return "GiaoVien";
                case "student":
                    return "HocSinh";
                case "parent":
                    return "PhuHuynh"; // Cần xử lý thêm trong Sidebar nếu muốn hỗ trợ PH
                default:
                    return "HocSinh"; // Mặc định
            }
        }
    }
}