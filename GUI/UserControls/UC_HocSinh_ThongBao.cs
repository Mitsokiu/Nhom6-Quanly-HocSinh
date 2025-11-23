using BUS; // Thêm
using DTO; // Thêm
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_ThongBao : UserControl
    {
        // Khai báo BUS và List lưu trữ
        private NotificationBUS _notificationBUS = new NotificationBUS();
        private List<NotificationDTO> _allNotifications = new List<NotificationDTO>(); // Lưu gốc để lọc

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

            // --- SỰ KIỆN LOAD DỮ LIỆU THẬT ---
            this.Load += (s, e) => LoadDataFromDB();

            // Sự kiện lọc ComboBox
            cboFilter.SelectedIndexChanged += (s, e) => FilterData();

            this.Resize += (s, e) => {
                CenterPagination();
                ResizeNotificationItems();
            };
        }

        // --- SETUP GIAO DIỆN (Giữ nguyên) ---
        private void InitCustomUI()
        {
            cboFilter.Items.Clear();
            // Sửa lại item cho khớp với Logic BUS
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Nhà trường", "Giáo viên" });
            cboFilter.SelectedIndex = 0;

            SetupBtn(btnPrev, "<", false);
            SetupBtn(btnPage1, "1", true);
            SetupBtn(btnPage2, "2", false);
            SetupBtn(btnNext, ">", false);
        }

        private void SetupBtn(Button btn, string text, bool active)
        {
            // (Giữ nguyên code cũ của bạn)
            btn.Text = text;
            btn.Size = new Size(40, 40);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            if (active) { btn.BackColor = Color.FromArgb(13, 110, 253); btn.ForeColor = Color.White; }
            else { btn.BackColor = Color.White; btn.ForeColor = Color.Black; }
        }

        // --- NẠP DỮ LIỆU TỪ DB ---
        private void LoadDataFromDB()
        {
            try
            {
                // 1. Lấy toàn bộ thông báo từ Server
                _allNotifications = _notificationBUS.GetNotificationsForStudent();

                // 2. Hiển thị ra màn hình
                DisplayList(_allNotifications);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông báo: " + ex.Message);
            }
        }

        private void FilterData()
        {
            string filter = cboFilter.SelectedItem.ToString();

            // Gọi BUS để lọc list đã tải về
            var filteredList = _notificationBUS.FilterNotifications(_allNotifications, filter);

            // Hiển thị list đã lọc
            DisplayList(filteredList);
        }

        private void DisplayList(List<NotificationDTO> list)
        {
            flowPanelNotifications.SuspendLayout();
            flowPanelNotifications.Controls.Clear();

            foreach (var item in list)
            {
                AddNotification(item.Title, item.SenderName, item.DateDisplay, item.Message);
            }

            flowPanelNotifications.ResumeLayout();
            ResizeNotificationItems(); // Chỉnh lại kích thước ngay sau khi add
        }

        private void AddNotification(string title, string sender, string date, string content)
        {
            NotificationItem item = new NotificationItem(title, sender, date, content);
            int w = flowPanelNotifications.ClientSize.Width - 25;
            if (w < 500) w = 800;
            item.Width = w;
            item.Margin = new Padding(0, 0, 0, 15);
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
            // (Giữ nguyên logic căn giữa cũ của bạn)
            if (panelPagination.Width == 0) return;
            int totalWidth = 250;
            int startX = (panelPagination.Width - totalWidth) / 2;
            btnPrev.Location = new Point(startX, 10);
            btnPage1.Location = new Point(startX + 50, 10);
            btnPage2.Location = new Point(startX + 100, 10);
            lblDots.Location = new Point(startX + 150, 15);
            btnNext.Location = new Point(startX + 190, 10);
        }
    }

    // Class NotificationItem (Giữ nguyên như cũ)
    public class NotificationItem : Panel
    {
        // ... (Giữ nguyên code class con cũ của bạn) ...
        // Copy lại Constructor và các thành phần bên trong từ code cũ
        public NotificationItem(string title, string sender, string date, string content)
        {
            this.Height = 140;
            this.BackColor = Color.White;
            this.Padding = new Padding(20);

            Panel pnlBar = new Panel();
            pnlBar.BackColor = Color.FromArgb(13, 110, 253);
            pnlBar.Width = 5;
            pnlBar.Dock = DockStyle.Left;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 15);

            Label lblMeta = new Label();
            lblMeta.Text = $"{sender}  •  {date}";
            lblMeta.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblMeta.ForeColor = Color.Gray;
            lblMeta.AutoSize = true;
            lblMeta.Location = new Point(30, 45);

            Label lblContent = new Label();
            lblContent.Text = content;
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

            this.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(240, 248, 255);
            this.MouseLeave += (s, e) => this.BackColor = Color.White;
            foreach (Control c in this.Controls)
            {
                c.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(240, 248, 255);
                c.MouseLeave += (s, e) => this.BackColor = Color.White;
            }
        }
    }
}