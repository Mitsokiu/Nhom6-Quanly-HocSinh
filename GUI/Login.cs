using BUS;
using DAO;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        private UserBUS bus = new UserBUS();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            bool result = DbConnect.TestConnection();
            if (result)
            {
                MessageBox.Show("Kết nối MySQL thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể kết nối đến MySQL.", "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            Console.WriteLine($"Attempting login with Username: {username}, Password: {password}");
            UserDTO user1 = bus.GetUserInfo(username);
            Console.WriteLine($"Retrieved User Info: {user1?.Username}, {user1?.Fullname}");

            if (bus.Login(username, password))
            {
                UserDTO user = bus.GetUserInfo(username);
               
                MainForm main = new MainForm(username);
                main.FormClosed += (s, args) => this.Show();
                main.Show();
                this.Hide();
            }
            else
            {
               
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
