namespace StudentMan
{
    public partial class GiaoVienChuNhiem : Form
    {
        public GiaoVienChuNhiem()
        {
            InitializeComponent();
            LoadUserControl(new Studenapp.UserControls.UC_Home());
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
            LoadUserControl(new Studenapp.UserControls.UC_Home());
        }

        // Sự kiện khi bấm nút Quản lý người dùng
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Studenapp.UserControls.UC_GVCN_QLHS());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Studenapp.UserControls.UC_GVCN_NS());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Studenapp.UserControls.UC_GVCN_Tbao());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Studenapp.UserControls.UC_GVBM_TKB());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Studenapp.UserControls.UC_GVBM_Diem());
        }



        // Sự kiện khi bấm nút Đăng xuất
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất!");
            this.Close();
        }

        
    }
}
