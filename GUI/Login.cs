using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            string role = "";

            // Giả lập Database
            if (username == "admin" && password == "123") role = "Admin";
            else if (username == "giaovien" && password == "123") role = "GiaoVien";
            else if (username == "hocsinh" && password == "123") role = "HocSinh";
            else if (username == "phuhuynh" && password == "123") role = "PhuHuynh";

            if (role != "")
            {
                this.Hide();
                MainForm mainForm = new MainForm(role); // Truyền Role vào MainForm
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}