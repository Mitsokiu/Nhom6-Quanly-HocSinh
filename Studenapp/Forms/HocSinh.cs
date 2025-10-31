using Studenapp.UserControls;

namespace StudentMan
{
    public partial class HocSinh : Form
    {
        public HocSinh()
        {
            InitializeComponent();
           
            LoadUserControl(new UC_Home());

        }

        // Sự kiện khi bấm nút Trang chủ


        private void LoadUserControl(UserControl uc)
        {
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Home());
        }

        // Sự kiện khi bấm nút Quản lý Diểm
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_HocSinh_Diem());
        }
        // Sự kiện khi bấm nút TKB
        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_HocSinh_TKB());
        }

        // Sự kiện khi bấm nút Đăng xuất
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất!");
            this.Close();
        }
    }
}
