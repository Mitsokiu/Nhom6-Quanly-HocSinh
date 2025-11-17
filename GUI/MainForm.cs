using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private string currentRole;

        public MainForm(string role)
        {
            InitializeComponent();
            this.currentRole = role;

            // Gọi phân quyền ngay khi khởi tạo
            sidebar.PhanQuyen(role);

            // --- Đăng ký sự kiện ---

            // Các nút chung/Giáo viên/Học sinh
            sidebar.BtnNhapDiemClick += (s, e) => LoadContent(new NhapDiemControl()); // Thay bằng UserControl tương ứng
            sidebar.BtnXemDiemClick += (s, e) => LoadContent(new XemDiemControl());
            sidebar.BtnHocSinhClick += (s, e) => LoadContent(new HocSinhControl());
            sidebar.BtnLopHoc_Click += (s, e) => LoadContent(new LopHoc());
            sidebar.BtnLichDayClick += (s, e) => LoadContent(new LichDay());
            // --- Nút ADMIN ---
            sidebar.BtnQuanLyLopHoc_Click += (s, e) => LoadContent(new QuanLyLopHocControl());
            sidebar.BtnQuanLyMonHoc_Click += (s, e) => LoadContent(new QuanLyMonHoc());
            sidebar.BtnQuanLyKhoiLop_Click += (s, e) => LoadContent(new QuanLyKhoiLop());
            // sidebar.BtnTaiKhoan_Click += (s, e) => LoadContent(new TaiKhoanControl());

            LoadDefaultScreen();
        }

        private void LoadDefaultScreen()
        {
            if (currentRole == "Admin") LoadContent(new QuanLyLopHocControl());
            else if (currentRole == "GiaoVien") LoadContent(new HocSinhControl());
            else if (currentRole == "HocSinh") LoadContent(new XemDiemControl());
        }

        private void LoadContent(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
        }

        // Constructor mặc định (quan trọng để tránh lỗi Designer)
        public MainForm() : this("Admin") { }
    }
}