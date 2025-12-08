using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Cần dùng Skip/Take
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_ThongBao : UserControl
    {
        // Khai báo sự kiện
        public event EventHandler<NotificationDTO> DetailClicked;

        private NotificationBUS _notificationBUS = new NotificationBUS();

        // --- BIẾN DỮ LIỆU ---
        private List<NotificationDTO> _allNotifications = new List<NotificationDTO>(); // Dữ liệu gốc từ DB
        private List<NotificationDTO> _filteredList = new List<NotificationDTO>();     // Dữ liệu sau khi lọc (dùng để phân trang)

        // --- BIẾN PHÂN TRANG ---
        private int _currentPage = 1;
        private int _pageSize = 5; // Số thông báo mỗi trang
        private int _totalPages = 0;

        public UC_HocSinh_ThongBao()
        {
            InitializeComponent();

            // Hack cuộn mượt
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, flowPanelNotifications, new object[] { true });

            // Setup FlowLayout
            flowPanelNotifications.AutoScroll = true;
            flowPanelNotifications.FlowDirection = FlowDirection.LeftToRight;
            flowPanelNotifications.WrapContents = true;

            InitCustomUI();
            InitPaginationEvents(); // <-- Gắn sự kiện nút phân trang

            this.Load += (s, e) => LoadDataFromDB();
            cboFilter.SelectedIndexChanged += (s, e) => FilterData();

            // Resize logic
            this.Resize += (s, e) => {
                RepositionPaginationButtons();
                ResizeNotificationItems();
            };
        }

        // --- 1. SETUP UI ---
        private void InitCustomUI()
        {
            // ComboBox
            cboFilter.Items.Clear();
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Nhà trường", "Giáo viên" });
            cboFilter.SelectedIndex = 0;

            // Setup giao diện nút (giống trang Học Phí)
            SetupBtnStyle(btnPrev, "<", false);
            SetupBtnStyle(btnPage1, "1", true); // Trang 1 mặc định active
            SetupBtnStyle(btnPage2, "2", false);
            SetupBtnStyle(btnPage3, "3", false);
            SetupBtnStyle(btnPageLast, "Last", false);
            SetupBtnStyle(btnNext, ">", false);

            // Ẩn bớt nút thừa ban đầu
            btnPage2.Visible = false;
            btnPage3.Visible = false;
            lblDots.Visible = false;
            btnPageLast.Visible = false;
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
        }

        private void SetupBtnStyle(Button btn, string text, bool active)
        {
            btn.Text = text;
            btn.Size = new Size(40, 40);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            if (active) HighlightButton(btn);
            else ResetButtonStyle(btn);
        }

        // --- 2. LOGIC PHÂN TRANG & SỰ KIỆN ---
        private void InitPaginationEvents()
        {
            btnPrev.Click += (s, e) => ChangePage(_currentPage - 1);
            btnNext.Click += (s, e) => ChangePage(_currentPage + 1);

            btnPage1.Click += (s, e) => ChangePage(1);
            btnPage2.Click += (s, e) => ChangePage(2);
            btnPage3.Click += (s, e) => ChangePage(3);

            // Nút trang cuối
            btnPageLast.Click += (s, e) =>
            {
                if (int.TryParse(btnPageLast.Text, out int lastPage))
                    ChangePage(lastPage);
            };
        }

        private void ChangePage(int newPage)
        {
            if (newPage < 1 || newPage > _totalPages) return;

            _currentPage = newPage;
            ShowCurrentPage();          // Hiển thị dữ liệu trang mới
            UpdatePaginationButtons();  // Cập nhật trạng thái nút
        }

        // --- 3. NẠP DỮ LIỆU & LỌC ---
        private void LoadDataFromDB()
        {
            try
            {
                // Lấy tất cả dữ liệu một lần
                _allNotifications = _notificationBUS.GetNotificationsForStudent();

                // Gọi hàm lọc (hàm này sẽ kích hoạt tính toán phân trang)
                FilterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông báo: " + ex.Message);
            }
        }

        private void FilterData()
        {
            string filter = cboFilter.SelectedItem?.ToString();

            // Lọc dữ liệu vào biến _filteredList
            _filteredList = _notificationBUS.FilterNotifications(_allNotifications, filter);

            // --- TÍNH TOÁN SỐ TRANG ---
            _totalPages = (int)Math.Ceiling((double)_filteredList.Count / _pageSize);
            if (_totalPages < 1) _totalPages = 1;

            // Reset về trang 1
            _currentPage = 1;

            // Hiển thị
            ShowCurrentPage();
            UpdatePaginationButtons();
        }

        private void ShowCurrentPage()
        {
            flowPanelNotifications.SuspendLayout();
            flowPanelNotifications.Controls.Clear();

            // Cắt dữ liệu cho trang hiện tại
            var pageData = _filteredList.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            foreach (var item in pageData)
            {
                AddNotification(item);
            }

            flowPanelNotifications.ResumeLayout();
            ResizeNotificationItems();

            // Cuộn lên đầu
            flowPanelNotifications.VerticalScroll.Value = 0;
        }

        private void AddNotification(NotificationDTO data)
        {
            NotificationItem item = new NotificationItem(data);
            int w = flowPanelNotifications.ClientSize.Width - 25;
            if (w < 500) w = 800; // Min width fallback
            item.Width = w;
            item.Margin = new Padding(0, 0, 0, 15);

            item.Click += (s, e) => DetailClicked?.Invoke(this, data);
            flowPanelNotifications.Controls.Add(item);
        }

        // --- 4. LOGIC ẨN/HIỆN NÚT PHÂN TRANG (CORE LOGIC) ---
        private void UpdatePaginationButtons()
        {
            // 1. Nút Prev/Next
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;

            // 2. Reset màu
            ResetButtonStyle(btnPage1);
            ResetButtonStyle(btnPage2);
            ResetButtonStyle(btnPage3);
            ResetButtonStyle(btnPageLast);

            // 3. Highlight trang hiện tại
            if (_currentPage == 1) HighlightButton(btnPage1);
            else if (_currentPage == 2) HighlightButton(btnPage2);
            else if (_currentPage == 3) HighlightButton(btnPage3);
            else if (_currentPage == _totalPages) HighlightButton(btnPageLast);

            // 4. Ẩn hiện thông minh
            btnPage1.Visible = true; // Luôn hiện trang 1

            // Chỉ hiện trang 2 nếu tổng trang >= 2
            btnPage2.Visible = _totalPages >= 2;

            // Chỉ hiện trang 3 nếu tổng trang >= 3
            btnPage3.Visible = _totalPages >= 3;

            // Logic nút Last và dấu ...
            if (_totalPages > 4)
            {
                lblDots.Visible = true;
                btnPageLast.Visible = true;
                btnPageLast.Text = _totalPages.ToString();
            }
            else if (_totalPages == 4)
            {
                lblDots.Visible = false;
                btnPageLast.Visible = true;
                btnPageLast.Text = "4";
            }
            else
            {
                // Nếu tổng trang <= 3 thì ẩn luôn nút Last và dấu ...
                lblDots.Visible = false;
                btnPageLast.Visible = false;
            }

            // Căn giữa lại sau khi ẩn/hiện
            RepositionPaginationButtons();
        }

        private void RepositionPaginationButtons()
        {
            // Gom control visible
            List<Control> controls = new List<Control>
            {
                btnPrev, btnPage1, btnPage2, btnPage3, lblDots, btnPageLast, btnNext
            };

            var visibleControls = controls.Where(c => c.Visible).ToList();
            if (visibleControls.Count == 0) return;

            int gap = 10;
            int totalWidth = 0;

            foreach (var ctrl in visibleControls) totalWidth += ctrl.Width;
            totalWidth += (visibleControls.Count - 1) * gap;

            int startX = (panelPagination.Width - totalWidth) / 2;
            int currentX = startX;

            foreach (var ctrl in visibleControls)
            {
                ctrl.Location = new Point(currentX, 10); // Y = 10 cố định
                currentX += ctrl.Width + gap;
            }
        }

        private void ResetButtonStyle(Button btn)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
        }

        private void HighlightButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(13, 110, 253);
            btn.ForeColor = Color.White;
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
    }

    public class NotificationItem : Panel
    {
        public NotificationItem(NotificationDTO data)
        {
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