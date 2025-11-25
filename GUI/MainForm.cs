using BUS;
using DTO;
using GUI.UserControls;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace GUI
{
    public partial class MainForm : Form
    {
        private UserDTO user;
        private UC_HocSinh_ThongBao ucThongBaoList;
        public MainForm(string username) // Truyền vai trò từ form đăng nhập
        {
            InitializeComponent();
            LoadContent(new UC_Home()); // Mặc định load trang Home
            user = new UserBUS().GetUserInfo(username);
            if (user != null)
            {
                // Truyền role vào sidebar
                sidebar.SetRole(user.RoleName);

                // Nếu muốn hiển thị thông tin user
                sidebar.SetUserInfo(user);
            }


          
            // Gắn sự kiện từ Sidebar (đúng tên event mới)
            sidebar.TaiKhoanClicked += Sidebar_TaiKhoanClicked;
            sidebar.NhapDiemClicked += Sidebar_NhapDiemClicked;
            sidebar.XemDiemClicked += Sidebar_XemDiemClicked;
            sidebar.XemTKBClicked += Sidebar_XemTKBClicked;
            sidebar.XemThongBaoClicked += Sidebar_XemThongBaoClicked;
            sidebar.XemLichDayClicked += Sidebar_XemLichDayClicked;
            sidebar.HocSinhClicked += Sidebar_HocSinhClicked;
            sidebar.TinhHinhClicked += Sidebar_TinhHinhClicked;
            sidebar.QlyLopClicked += Sidebar_QlyLopClicked;
            sidebar.HocPhiClicked += Sidebar_HocPhiClicked;
            sidebar.HomeClicked += Sidebar_HomeClicked;
            sidebar.QlyNamHocClicked += Sidebar_QlyNamHocClicked;
            sidebar.XemThongTinHocSinhClicked += Sidebar_XemThongTinHocSinhClicked;
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
            LoadContent(new UC_HocSinh_Diem(user.UserId));
        }

        private void Sidebar_XemTKBClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_HocSinh_TKB(user.UserId));
        }

        private void Sidebar_XemThongBaoClicked(object sender, EventArgs e)
        {
            OpenNotificationList();
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

       
        private void Sidebar_HomeClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_Home());
        }

        private void Sidebar_QlyNamHocClicked(object sender, EventArgs e)
        {
            LoadContent(new UC_Admin_Namhoc());
        }

        private void Sidebar_HocPhiClicked(object sender, EventArgs e)
        {
            if (user != null)
            {
                LoadContent(new UC_HocSinh_HocPhi(user.UserId));
            }
        }

        private void Sidebar_XemThongTinHocSinhClicked(object sender, EventArgs e)
        {
            if (user != null)
            {
                LoadContent(new UC_HocSinh_ThongTin(user.UserId));
            }
        }

        private void OpenNotificationList()
        {
            // Nếu chưa có thì tạo mới
            if (ucThongBaoList == null)
            {
                ucThongBaoList = new UC_HocSinh_ThongBao();

                // QUAN TRỌNG: Đăng ký sự kiện "Khi bấm vào 1 dòng -> Mở trang chi tiết"
                ucThongBaoList.DetailClicked += (s, dto) =>
                {
                    OpenNotificationDetail(dto);
                };
            }

            // Hiển thị lên Panel chính
            LoadContent(ucThongBaoList);
        }

        // Hàm mở trang chi tiết
        private void OpenNotificationDetail(NotificationDTO dto)
        {
            // Tạo trang chi tiết và truyền dữ liệu vào
            var ucDetail = new UC_HocSinh_ChiTietThongBao(dto);

            // Đăng ký sự kiện "Khi bấm nút Back -> Quay lại danh sách"
            ucDetail.BackClicked += (s, e) =>
            {
                OpenNotificationList(); // Quay lại list cũ
            };

            LoadContent(ucDetail);
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
    }
}
