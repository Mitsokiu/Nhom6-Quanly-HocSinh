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

        // Hàm load user control vào panelContent
        private void LoadContent(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
        }
    }
}