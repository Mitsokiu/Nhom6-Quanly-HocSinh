using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class LichDay : UserControl
    {
        // Danh sách các FlowLayoutPanel đại diện cho cột từng ngày
        private FlowLayoutPanel[] dayPanels;

        public LichDay()
        {
            InitializeComponent();
            InitializeScheduleGrid();
            LoadSampleData();
        }

        // 1. Khởi tạo lưới lịch (Header và Cột chứa content)
        private void InitializeScheduleGrid()
        {
            string[] days = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu" };
            string[] dates = { "18/11", "19/11", "20/11", "21/11", "22/11" };
            dayPanels = new FlowLayoutPanel[5];

            // Xóa các control cũ nếu có
            tlpSchedule.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                // --- Tạo Header (VD: Thứ Hai - 18/11) ---
                Panel pnlHeader = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0) };

                Label lblDay = new Label
                {
                    Text = days[i],
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = false,
                    TextAlign = ContentAlignment.BottomCenter,
                    Dock = DockStyle.Top,
                    Height = 40
                };

                Label lblDate = new Label
                {
                    Text = dates[i],
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Gray,
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopCenter,
                    Dock = DockStyle.Bottom,
                    Height = 30
                };

                pnlHeader.Controls.Add(lblDate);
                pnlHeader.Controls.Add(lblDay);

                // Hiệu ứng highlight cho ngày hiện tại (VD: Thứ Tư)
                if (i == 2) // Giả lập Thứ Tư là hôm nay
                {
                    pnlHeader.BackColor = Color.FromArgb(230, 242, 255); // Nền xanh nhạt
                    lblDay.ForeColor = Color.FromArgb(13, 110, 253);     // Chữ xanh dương
                }

                tlpSchedule.Controls.Add(pnlHeader, i, 0);

                // --- Tạo Panel chứa nội dung (FlowLayoutPanel) ---
                FlowLayoutPanel flpContent = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoScroll = true,
                    Padding = new Padding(5),
                    BackColor = Color.White // Nền trắng cho cột
                };

                dayPanels[i] = flpContent;
                tlpSchedule.Controls.Add(flpContent, i, 1);
            }
        }

        // 2. Tạo Card Lịch Dạy
        private void AddClassCard(int dayIndex, string subject, string className, string time, string room, int colorType)
        {
            // Định nghĩa màu sắc
            Color backColor, borderColor, textColor;

            switch (colorType)
            {
                case 1: // Blue (Toán)
                    backColor = Color.FromArgb(225, 240, 255);
                    borderColor = Color.FromArgb(13, 110, 253);
                    textColor = Color.FromArgb(13, 70, 180);
                    break;
                case 2: // Green (Tiếng Anh)
                    backColor = Color.FromArgb(225, 255, 235);
                    borderColor = Color.FromArgb(34, 197, 94);
                    textColor = Color.FromArgb(10, 120, 50);
                    break;
                case 3: // Red/Pink (Ngữ Văn)
                    backColor = Color.FromArgb(255, 235, 235);
                    borderColor = Color.FromArgb(239, 68, 68);
                    textColor = Color.FromArgb(180, 30, 30);
                    break;
                default:
                    backColor = Color.White; borderColor = Color.Gray; textColor = Color.Black;
                    break;
            }

            // Panel chính của Card
            Panel pnlCard = new Panel
            {
                Size = new Size(170, 100), // Kích thước thẻ
                BackColor = backColor,
                Margin = new Padding(0, 0, 0, 10) // Khoảng cách dưới
            };

            // Dải màu bên trái
            Panel pnlBorder = new Panel
            {
                
                Dock = DockStyle.Left,
                BackColor = borderColor
            };

            // Nội dung text
            Label lblSubject = new Label { Text = subject, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = textColor, Location = new Point(10, 10), AutoSize = true };
            Label lblClass = new Label { Text = className, Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = textColor, Location = new Point(10, 32), AutoSize = true };
            Label lblTime = new Label { Text = time, Font = new Font("Segoe UI", 8, FontStyle.Regular), ForeColor = textColor, Location = new Point(10, 54), AutoSize = true };
            Label lblRoom = new Label { Text = room, Font = new Font("Segoe UI", 8, FontStyle.Regular), ForeColor = textColor, Location = new Point(10, 72), AutoSize = true };

            pnlCard.Controls.Add(lblSubject);
            pnlCard.Controls.Add(lblClass);
            pnlCard.Controls.Add(lblTime);
            pnlCard.Controls.Add(lblRoom);
            pnlCard.Controls.Add(pnlBorder);

            // Thêm vào cột tương ứng
            if (dayIndex >= 0 && dayIndex < 5)
            {
                dayPanels[dayIndex].Controls.Add(pnlCard);
            }
        }

        // 3. Đổ dữ liệu mẫu (Giống hệt ảnh)
        private void LoadSampleData()
        {
            // Thứ 2 (Index 0)
            AddClassCard(0, "Toán", "Lớp 10A1", "7:30 - 8:15", "Phòng A101", 1);
            AddClassCard(0, "Ngữ Văn", "Lớp 11B2", "9:25 - 10:10", "Phòng B203", 3);

            // Thứ 3 (Index 1)
            AddClassCard(1, "Tiếng Anh", "Lớp 12C3", "8:20 - 9:05", "Phòng C301", 2);

            // Thứ 4 (Index 2)
            AddClassCard(2, "Toán", "Lớp 10A1", "7:30 - 8:15", "Phòng A101", 1);

            // Thứ 5 (Index 3)
            AddClassCard(3, "Ngữ Văn", "Lớp 11B2", "9:25 - 10:10", "Phòng B203", 3);

            // Thứ 6 (Index 4)
            AddClassCard(4, "Tiếng Anh", "Lớp 12C3", "8:20 - 9:05", "Phòng C301", 2);
            AddClassCard(4, "Toán", "Lớp 10A1", "10:15 - 11:00", "Phòng A101", 1);
        }
    }
}