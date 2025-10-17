using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentMan
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: xử lý đăng nhập ở đây
            string user = textBox1.Text;
            string pass = textBox2.Text;

            if (user == "admin" && pass == "123")
            {
                MessageBox.Show(this, "Đăng nhập thành công!");
                // Ví dụ: mở form Admin
                AdminForm main = new AdminForm();
                main.Show();
                this.Hide();
            }
            if (user == "GVBM" && pass == "123")
            {
                MessageBox.Show(this, "Đăng nhập thành công!");
                // Ví dụ: mở form Admin
                GiaoVienBoMon main = new GiaoVienBoMon();
                main.Show();
                this.Hide();
            }
            if (user == "HS" && pass == "123")
            {
                MessageBox.Show(this, "Đăng nhập thành công!");
                // Ví dụ: mở form Admin
                HocSinh main = new HocSinh();
                main.Show();
                this.Hide();
            }
            if (user == "PH" && pass == "123")
            {
                MessageBox.Show(this, "Đăng nhập thành công!");
                // Ví dụ: mở form Admin
                PhuHuynh main = new PhuHuynh();
                main.Show();
                this.Hide();
            }
            if (user == "GVCN" && pass == "123")
            {
                MessageBox.Show(this,"Đăng nhập thành công!");
                // Ví dụ: mở form Admin
                GiaoVienChuNhiem main = new GiaoVienChuNhiem();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
