using GUI.UserControls;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        public MainForm(string role) // Truyền vai trò từ form đăng nhập
        {
            InitializeComponent();
            LoadContent(new UC_Home()); // Mặc định load trang Home

            // Ẩn/hiện nút theo vai trò
            sidebar.SetRole(role);

            // Gắn sự kiện từ Sidebar (đúng tên event mới)
            sidebar.TaiKhoanClicked += Sidebar_TaiKhoanClicked;
            sidebar.NhapDiemClicked += Sidebar_NhapDiemClicked;
            sidebar.XemDiemClicked += Sidebar_XemDiemClicked;
            sidebar.HocPhiClicked += Sidebar_HocPhiClicked;
            sidebar.XemTKBClicked += Sidebar_XemTKBClicked;
            sidebar.XemLichDayClicked += Sidebar_XemLichDayClicked;
            sidebar.HocSinhClicked += Sidebar_HocSinhClicked;
            sidebar.TinhHinhClicked += Sidebar_TinhHinhClicked;
            sidebar.QlyLopClicked += Sidebar_QlyLopClicked;
            sidebar.CauHinhClicked += Sidebar_CauHinhClicked;
            sidebar.HomeClicked += Sidebar_HomeClicked;
        }

        // =====================
        // Hàm load UserControl vào panelContent
        // =====================
        private void LoadContent(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
        }

        // =====================
        // Xử lý sự kiện Sidebar
        // =====================

        private void Sidebar_TaiKhoanClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_Admin_User());
        }

        private void Sidebar_NhapDiemClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_GVBM_Diem());
        }

        private void Sidebar_XemDiemClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_HocSinh_Diem());
        }

        private void Sidebar_HocPhiClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_PhuHuynh_HocPhi());
        }

        private void Sidebar_XemTKBClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_HocSinh_TKB());
        }

        private void Sidebar_XemLichDayClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_GVBM_TKB());
        }

        private void Sidebar_HocSinhClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_GVCN_QLHS());
        }

        private void Sidebar_TinhHinhClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_PhuHuynh_Thongtin());
        }

        private void Sidebar_QlyLopClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_Admin_Class());
        }

        private void Sidebar_CauHinhClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_Admin_CauHinh());
        }

        private void Sidebar_HomeClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_Home());
        }

        // =====================
        // Form load
        // =====================
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void sidebar_Load(object sender, EventArgs e)
        {
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
