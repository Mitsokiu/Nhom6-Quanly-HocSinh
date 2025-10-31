using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if ((username == "admin" || username == "GVCN" || username == "GVBM" || username == "HS" || username == "PH")
                && password == "123")
            {
                MainForm mainForm = new MainForm(username);

                // Khi MainForm đóng, Login hiện lại
                mainForm.FormClosed += (s, args) => this.Show();

                mainForm.Show();
                this.Hide(); // chỉ ẩn Login, không đóng
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!",
                                "Đăng nhập thất bại",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }



    }
}
