using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_ThongBao : UserControl
    {
        public event EventHandler<NotificationDTO> DetailClicked;

        private NotificationBUS _notificationBUS = new NotificationBUS();

        // Biến lưu trữ dữ liệu
        private List<NotificationDTO> _allNotifications = new List<NotificationDTO>(); // Dữ liệu gốc từ DB
        private List<NotificationDTO> _currentList = new List<NotificationDTO>();      // Dữ liệu đang hiển thị (sau khi lọc)

        // Biến phân trang
        private int _currentPage = 1;
        private int _pageSize = 4; // Số thông báo mỗi trang (4 cái là đẹp)
        private int _totalPages = 0;

        public UC_HocSinh_ThongBao()
        {
            InitializeComponent();

            // Cấu hình UI
            flowPanelNotifications.AutoScroll = true;
            flowPanelNotifications.FlowDirection = FlowDirection.LeftToRight;
            flowPanelNotifications.WrapContents = true;

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, flowPanelNotifications, new object[] { true });

            InitCustomUI();

            // Events
            this.Load += (s, e) => LoadDataFromDB();
            cboFilter.SelectedIndexChanged += (s, e) => FilterData();

            // Sự kiện phân trang
            InitPaginationEvents();

            this.Resize += (s, e) => {
                CenterPagination();
                ResizeNotificationItems();
            };
        }

        // --- SETUP UI ---
        private void InitCustomUI()
        {
            cboFilter.Items.Clear();
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Nhà trường", "Giáo viên" });
            cboFilter.SelectedIndex = 0;

            SetupBtn(btnPrev, "<", false);
            SetupBtn(btnPage1, "1", true);
            SetupBtn(btnPage2, "2", false);
            SetupBtn(btnNext, ">", false);
        }

        private void SetupBtn(Button btn, string text, bool active)
        {
            btn.Text = text;
            btn.Size = new Size(40, 40);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            if (active) { btn.BackColor = Color.FromArgb(13, 110, 253); btn.ForeColor = Color.White; }
            else { btn.BackColor = Color.White; btn.ForeColor = Color.Black; }
        }

        private void InitPaginationEvents()
        {
            btnPrev.Click += (s, e) => ChangePage(_currentPage - 1);
            btnNext.Click += (s, e) => ChangePage(_currentPage + 1);
            btnPage1.Click += (s, e) => ChangePage(1);
            btnPage2.Click += (s, e) => ChangePage(2);
        }

        // --- XỬ LÝ DỮ LIỆU ---
        private void LoadDataFromDB()
        {
            try
            {
                _allNotifications = _notificationBUS.GetNotificationsForStudent();
                // Mặc định hiển thị tất cả
                _currentList = _allNotifications;

                CalculatePagination();
                ShowCurrentPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FilterData()
        {
            string filter = cboFilter.SelectedItem?.ToString();

            // Lọc dữ liệu và lưu vào _currentList
            _currentList = _notificationBUS.FilterNotifications(_allNotifications, filter);

            // Tính toán lại phân trang cho danh sách mới lọc
            CalculatePagination();
            ShowCurrentPage();
        }

        // --- LOGIC PHÂN TRANG ---
        private void CalculatePagination()
        {
            _totalPages = (int)Math.Ceiling((double)_currentList.Count / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            _currentPage = 1; // Reset về trang 1 mỗi khi nạp lại data
        }

        private void ChangePage(int newPage)
        {
            if (newPage < 1 || newPage > _totalPages) return;
            _currentPage = newPage;
            ShowCurrentPage();
        }

        private void ShowCurrentPage()
        {
            flowPanelNotifications.SuspendLayout();
            flowPanelNotifications.Controls.Clear();

            // Cắt dữ liệu theo trang
            var pageData = _currentList.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            foreach (var item in pageData)
            {
                AddNotification(item);
            }

            flowPanelNotifications.ResumeLayout();
            ResizeNotificationItems();
            UpdatePaginationButtons(); // Cập nhật trạng thái nút
        }

        private void UpdatePaginationButtons()
        {
            // Ẩn hiện nút Prev/Next
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;

            // Reset style
            SetupBtn(btnPage1, "1", false);
            SetupBtn(btnPage2, "2", false);

            // Highlight trang hiện tại
            if (_currentPage == 1) SetupBtn(btnPage1, "1", true);
            else if (_currentPage == 2) SetupBtn(btnPage2, "2", true);

            // Logic ẩn hiện nút số (Demo đơn giản cho 2 trang, nếu nhiều hơn cần logic phức tạp hơn giống bên Học phí)
            btnPage1.Visible = true;
            btnPage2.Visible = _totalPages >= 2;
            lblDots.Visible = _totalPages > 2; // Hiện dấu ... nếu còn nhiều trang nữa

            CenterPagination();
        }

        // --- CÁC HÀM ADD/RESIZE ITEM (Giữ nguyên) ---
        private void AddNotification(NotificationDTO data)
        {
            NotificationItem item = new NotificationItem(data);

            int w = flowPanelNotifications.ClientSize.Width - 25;
            if (w < 500) w = 800;
            item.Width = w;
            item.Margin = new Padding(0, 0, 0, 15);

            item.Click += (s, e) => DetailClicked?.Invoke(this, data);

            flowPanelNotifications.Controls.Add(item);
        }

        private void ResizeNotificationItems()
        {
            int w = flowPanelNotifications.ClientSize.Width - 25;
            if (w < 100) return;
            foreach (Control c in flowPanelNotifications.Controls)
            {
                if (c is NotificationItem) c.Width = w;
            }
        }

        private void CenterPagination()
        {
            if (panelPagination.Width == 0) return;

            // Tính tổng chiều rộng các nút đang hiện
            int totalWidth = 0;
            int gap = 10;

            if (btnPrev.Visible) totalWidth += 40 + gap;
            if (btnPage1.Visible) totalWidth += 40 + gap;
            if (btnPage2.Visible) totalWidth += 40 + gap;
            if (lblDots.Visible) totalWidth += 30 + gap;
            if (btnNext.Visible) totalWidth += 40;

            int startX = (panelPagination.Width - totalWidth) / 2;
            int currentX = startX;

            // Sắp xếp vị trí
            btnPrev.Location = new Point(currentX, 10); currentX += 50;

            if (btnPage1.Visible) { btnPage1.Location = new Point(currentX, 10); currentX += 50; }
            if (btnPage2.Visible) { btnPage2.Location = new Point(currentX, 10); currentX += 50; }
            if (lblDots.Visible) { lblDots.Location = new Point(currentX, 15); currentX += 40; }

            btnNext.Location = new Point(currentX, 10);
        }
    }

    // --- CLASS CON (Giữ nguyên) ---
    public class NotificationItem : Panel
    {
        // ... (Copy lại class NotificationItem từ code cũ của bạn vào đây) ...
        // (Phần này không thay đổi gì nên mình lược bớt để code gọn)
        public NotificationDTO Data { get; private set; }

        public NotificationItem(NotificationDTO data)
        {
            this.Data = data;
            this.Height = 140;
            this.BackColor = Color.White;
            this.Padding = new Padding(20);
            this.Cursor = Cursors.Hand;

            Panel pnlBar = new Panel();
            pnlBar.BackColor = Color.FromArgb(13, 110, 253);
            pnlBar.Width = 5;
            pnlBar.Dock = DockStyle.Left;

            Label lblTitle = new Label();
            lblTitle.Text = data.Title;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 15);

            Label lblMeta = new Label();
            lblMeta.Text = $"{data.SenderName}  •  {data.DateDisplay}";
            lblMeta.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblMeta.ForeColor = Color.Gray;
            lblMeta.AutoSize = true;
            lblMeta.Location = new Point(30, 45);

            Label lblContent = new Label();
            lblContent.Text = data.Message;
            lblContent.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblContent.ForeColor = Color.FromArgb(64, 64, 64);
            lblContent.Location = new Point(30, 75);
            lblContent.Size = new Size(800, 50);
            lblContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblContent.AutoEllipsis = true;

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblMeta);
            this.Controls.Add(lblContent);
            this.Controls.Add(pnlBar);

            void TriggerClick(object sender, EventArgs e) => this.OnClick(e);

            foreach (Control c in this.Controls)
            {
                c.Click += TriggerClick;
                c.Cursor = Cursors.Hand;
                c.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(240, 248, 255);
                c.MouseLeave += (s, e) => this.BackColor = Color.White;
            }

            this.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(240, 248, 255);
            this.MouseLeave += (s, e) => this.BackColor = Color.White;
        }
    }
}