namespace StudentMan
{
    public partial class GiaoVienBoMon: Form
    {
        public GiaoVienBoMon()
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


        // Sự kiện khi bấm nút Quản lý  Diem
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Studenapp.UserControls.UC_GVBM_Diem());
        
        
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Studenapp.UserControls.UC_GVBM_TKB());



        }


        // Sự kiện khi bấm nút Đăng xuất
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất!");
            this.Close();
        }
    }
}
