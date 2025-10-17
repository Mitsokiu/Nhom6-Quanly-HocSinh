using Studenapp.UserControls;
using System;
using System.Drawing;
using System.Runtime;
using System.Windows.Forms;

namespace StudentMan
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            // Mặc định load trang chủ
            LoadUserControl(new UC_Home());

        }

        // Hàm nạp UserControl vào panelMain
        private void LoadUserControl(UserControl uc)
        {
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
        }

        //// Trang chủ
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    LoadUserControl(new UC_Home());
        //}

        //// Quản lý người dùng
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_User());
        }

        // Quản lý lớp & môn học
        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_Class());
        }

        //// Năm học & TKB
        private void button4_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_Namhoc());
        }

        //// Cấu hình
        private void button5_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_CauHinh());
        }

        // Đăng xuất
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã đăng xuất!", "Thông báo");
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
