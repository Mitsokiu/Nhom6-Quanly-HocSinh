using Studenapp.UserControls;

namespace StudentMan
{
    public partial class PhuHuynh : Form
    {
        public PhuHuynh()
        {
            InitializeComponent();

            // Mặc định load trang chủ
            LoadUserControl(new UC_Home());
        }

        private void LoadUserControl(UserControl uc)
        {
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
        }



        // Sự kiện khi bấm nút Trang chủ
        private void button1_Click(object sender, EventArgs e)
        {
           LoadUserControl(new UC_Home());
        }

        // Sự kiện khi bấm nút Quản lý người dùng
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_PhuHuynh());

        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_PhuHuynh_HocPhi());

        }

        // Sự kiện khi bấm nút Đăng xuất
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất!");
            this.Close();
        }
    }
}
