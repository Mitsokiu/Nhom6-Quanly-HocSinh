using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Gắn sự kiện chuyển tab
            sidebar.BtnNhapDiemClick += Sidebar_BtnNhapDiemClick;
            sidebar.BtnXemDiemClick += Sidebar_BtnXemDiemClick;
            sidebar.BtnHocSinhClick += Sidebar_BtnHocSinhClick;
            sidebar.BtnHocPhiClick += Sidebar_BtnHocPhiClick;
        }


        private void Sidebar_BtnHocPhiClick(object sender, EventArgs e)
        {
            LoadContent(new HocPhiControl());
        }   
        // Xử lý khi bấm nút "Nhập điểm"
        private void Sidebar_BtnNhapDiemClick(object sender, EventArgs e)
        {
            LoadContent(new NhapDiemControl());
        }

        // Xử lý khi bấm nút "Xem điểm"
        private void Sidebar_BtnXemDiemClick(object sender, EventArgs e)
        {
            LoadContent(new XemDiemControl());
        }

        private void Sidebar_BtnHocSinhClick(object sender, EventArgs e)
        {
            LoadContent(new HocSinhControl());
        }

        // Hàm load user control vào panelContent
        private void LoadContent(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
        }

        private void sidebar_Load(object sender, EventArgs e)
        {

        }
    }
}