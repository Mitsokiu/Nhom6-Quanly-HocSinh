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
        // Khai báo sự kiện
        public event EventHandler<NotificationDTO> DetailClicked;

        private NotificationBUS _notificationBUS = new NotificationBUS();
        private List<NotificationDTO> _allNotifications = new List<NotificationDTO>();

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

            this.Load += (s, e) => LoadDataFromDB();
            cboFilter.SelectedIndexChanged += (s, e) => FilterData();
            this.Resize += (s, e) => {
                CenterPagination();
                ResizeNotificationItems();
            };
        }

        // --- CÁC HÀM SETUP UI ---
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

        // --- LOGIC NẠP DỮ LIỆU ---
        private void LoadDataFromDB()
        {
            try
            {
                _allNotifications = _notificationBUS.GetNotificationsForStudent();
                DisplayList(_allNotifications);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FilterData()
        {
            string filter = cboFilter.SelectedItem?.ToString();
            var filteredList = _notificationBUS.FilterNotifications(_allNotifications, filter);
            DisplayList(filteredList);
        }

        private void DisplayList(List<NotificationDTO> list)
        {
            flowPanelNotifications.SuspendLayout();
            flowPanelNotifications.Controls.Clear();

            foreach (var item in list)
            {
                // QUAN TRỌNG: Truyền cả đối tượng DTO vào đây
                AddNotification(item);
            }

            flowPanelNotifications.ResumeLayout();
            ResizeNotificationItems();
        }

        // --- SỬA LẠI HÀM NÀY ĐỂ HẾT LỖI BIẾN 'DATA' ---
        private void AddNotification(NotificationDTO data)
        {
            // Tạo item từ DTO
            NotificationItem item = new NotificationItem(data);

            int w = flowPanelNotifications.ClientSize.Width - 25;
            if (w < 500) w = 800;
            item.Width = w;
            item.Margin = new Padding(0, 0, 0, 15);

            // Gắn sự kiện Click: Khi bấm vào item -> Bắn sự kiện ra ngoài kèm theo 'data'
            item.Click += (s, e) =>
            {
                DetailClicked?.Invoke(this, data); // Giờ biến 'data' đã hợp lệ
            };

            flowPanelNotifications.Controls.Add(item);
        }

        // --- CÁC HÀM CĂN CHỈNH KHÁC ---
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
            int totalWidth = 250;
            int startX = (panelPagination.Width - totalWidth) / 2;

            btnPrev.Location = new Point(startX, 10);
            btnPage1.Location = new Point(startX + 50, 10);
            btnPage2.Location = new Point(startX + 100, 10);
            lblDots.Location = new Point(startX + 150, 15);
            btnNext.Location = new Point(startX + 190, 10);
        }
    }

    // --- CLASS CON: NOTIFICATION ITEM ---
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

            // Lan truyền sự kiện Click cho tất cả control con
            // Để khi click vào chữ cũng tính là click vào thẻ
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