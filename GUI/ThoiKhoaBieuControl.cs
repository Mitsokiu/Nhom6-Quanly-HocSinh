using BUS; // Gọi tầng BUS
using DTO; // Gọi tầng DTO
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThoiKhoaBieuControl : UserControl
    {
        // GIẢ LẬP: ID lớp học hiện tại.
        // Trong thực tế, khi đăng nhập xong bạn sẽ lấy ClassID của học sinh đó lưu vào biến toàn cục.
        // Theo file db.sql của bạn, học sinh id=1 đang học lớp id=1.
        private int currentClassId = 1;

        public ThoiKhoaBieuControl()
        {
            InitializeComponent();

            // 1. Tối ưu hiệu suất
            ConfigureDoubleBuffering();

            // 2. Vẽ khung Header (Thứ/Tiết)
            InitTableHeaders();

            // 3. Nạp danh sách Học kỳ vào ComboBox và tải dữ liệu
            LoadSemesters();
        }

        private void ConfigureDoubleBuffering()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            if (this.tblTimetable != null)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, this.tblTimetable, new object[] { true });
            }
        }

        // --- HEADER GIAO DIỆN ---
        private void InitTableHeaders()
        {
            this.tblTimetable.SuspendLayout();
            // Header Hàng ngang
            AddHeaderLabel("Tiết", 0, 0);
            AddHeaderLabel("Thứ Hai", 1, 0);
            AddHeaderLabel("Thứ Ba", 2, 0);
            AddHeaderLabel("Thứ Tư", 3, 0);
            AddHeaderLabel("Thứ Năm", 4, 0);
            AddHeaderLabel("Thứ Sáu", 5, 0);
            AddHeaderLabel("Thứ Bảy", 6, 0);

            // Header Cột dọc
            AddPeriodLabel("Tiết 1\n7:00 - 7:45", 0, 1);
            AddPeriodLabel("Tiết 2\n8:00 - 8:45", 0, 2);
            AddPeriodLabel("Tiết 3\n9:00 - 9:45", 0, 3);
            AddPeriodLabel("Tiết 4\n10:00 - 10:45", 0, 4);
            AddPeriodLabel("Tiết 5\n11:00 - 11:45", 0, 5);
            this.tblTimetable.ResumeLayout();
        }

        // --- TẢI DỮ LIỆU TỪ DB ---

        private void LoadSemesters()
        {
            // Nạp danh sách học kỳ vào ComboBox
            // (Lẽ ra nên load từ bảng `semesters`, nhưng ở đây mình tạo cứng cho khớp với data mẫu của bạn)
            cboWeek.Items.Clear();

            // Dùng class vô danh để lưu Text và Value
            cboWeek.DisplayMember = "Text";
            cboWeek.ValueMember = "Value";

            cboWeek.Items.Add(new { Text = "Học kỳ 1 (2024-2025)", Value = 1 });
            cboWeek.Items.Add(new { Text = "Học kỳ 2 (2024-2025)", Value = 2 });

            // Sự kiện khi chọn học kỳ -> Load lại TKB
            cboWeek.SelectedIndexChanged += (s, e) => LoadTimetableFromDB();

            // Mặc định chọn cái đầu tiên
            if (cboWeek.Items.Count > 0) cboWeek.SelectedIndex = 0;
        }

        private void LoadTimetableFromDB()
        {
            if (cboWeek.SelectedItem == null) return;

            // Lấy SemesterID từ ComboBox
            dynamic selectedItem = cboWeek.SelectedItem;
            int semesterId = selectedItem.Value;

            this.tblTimetable.SuspendLayout();
            try
            {
                // 1. Xóa các môn học cũ trên bảng (Giữ lại Header)
                // Duyệt ngược để xóa an toàn. Chỉ xóa Panel (là thẻ môn học), không xóa Label (là Header)
                for (int i = tblTimetable.Controls.Count - 1; i >= 0; i--)
                {
                    Control c = tblTimetable.Controls[i];
                    if (c is Panel)
                    {
                        tblTimetable.Controls.RemoveAt(i);
                    }
                }

                // 2. GỌI BUS ĐỂ LẤY LIST DỮ LIỆU
                List<TimetableDTO> listTKB = TimetableBUS.Instance.GetTimetable(currentClassId, semesterId);

                // 3. Vẽ dữ liệu lên bảng
                foreach (var item in listTKB)
                {
                    // Database lưu: "Mon", "Tue"... -> Cần đổi sang cột 1, 2...
                    int col = ConvertDayToColumn(item.Day);
                    int row = item.Period; // Tiết 1 -> Hàng 1

                    if (col != -1 && row >= 1 && row <= 5)
                    {
                        // Tự động chọn màu theo tên môn
                        SubjectColor color = GetColorBySubjectName(item.SubjectName);

                        AddSubject(col, row, item.SubjectName, "GV: " + item.TeacherName, "Phòng: " + item.Room, color);
                    }
                }
            }
            finally
            {
                this.tblTimetable.ResumeLayout();
            }
        }

        // Hàm chuyển đổi "Mon" -> Cột 1
        private int ConvertDayToColumn(string day)
        {
            switch (day.Trim()) // Trim để xóa khoảng trắng thừa nếu có trong DB
            {
                case "Mon": return 1;
                case "Tue": return 2;
                case "Wed": return 3;
                case "Thu": return 4;
                case "Fri": return 5;
                case "Sat": return 6;
                default: return -1;
            }
        }

        // --- VẼ GIAO DIỆN ---

        private void AddSubject(int col, int row, string subjectName, string teacherName, string roomName, SubjectColor colorType)
        {
            Panel cardPanel = new Panel { Dock = DockStyle.Fill, Margin = new Padding(4), BackColor = Color.Transparent };
            Color bgColor, textColor;
            GetColorSchema(colorType, out bgColor, out textColor);

            Label lblSubject = new Label { Text = subjectName, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = textColor, AutoSize = true, Location = new Point(10, 8), BackColor = Color.Transparent };
            cardPanel.Controls.Add(lblSubject);

            if (!string.IsNullOrEmpty(teacherName))
            {
                Label lblTeacher = new Label { Text = teacherName, Font = new Font("Segoe UI", 8.5F, FontStyle.Regular), ForeColor = textColor, AutoSize = true, Location = new Point(10, 30), BackColor = Color.Transparent };
                cardPanel.Controls.Add(lblTeacher);
            }
            if (!string.IsNullOrEmpty(roomName))
            {
                Label lblRoom = new Label { Text = roomName, Font = new Font("Segoe UI", 8.5F, FontStyle.Regular), ForeColor = textColor, AutoSize = true, Location = new Point(10, 48), BackColor = Color.Transparent };
                cardPanel.Controls.Add(lblRoom);
            }

            // Vẽ bo góc
            cardPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (cardPanel.Width > 1 && cardPanel.Height > 1)
                {
                    using (GraphicsPath path = RoundedRect(new Rectangle(0, 0, cardPanel.Width - 1, cardPanel.Height - 1), 12))
                    using (SolidBrush brush = new SolidBrush(bgColor)) e.Graphics.FillPath(brush, path);
                }
            };
            this.tblTimetable.Controls.Add(cardPanel, col, row);
        }

        // Helper tạo Label Header
        private void AddHeaderLabel(string text, int col, int row)
        {
            Label lbl = new Label { Text = text, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(73, 80, 87), BackColor = Color.White, Margin = new Padding(0) };
            this.tblTimetable.Controls.Add(lbl, col, row);
        }

        private void AddPeriodLabel(string text, int col, int row)
        {
            Label lbl = new Label { Text = text, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.Black, BackColor = Color.White, Margin = new Padding(0) };
            this.tblTimetable.Controls.Add(lbl, col, row);
        }

        // --- MÀU SẮC ---
        public enum SubjectColor { Red, Blue, Orange, Green, Purple, Yellow, Cyan, Gray }

        // Chọn màu dựa trên tên môn học
        private SubjectColor GetColorBySubjectName(string name)
        {
            name = name.ToLower();
            if (name.Contains("toán")) return SubjectColor.Red;
            if (name.Contains("lý") || name.Contains("vật lý")) return SubjectColor.Blue;
            if (name.Contains("hóa")) return SubjectColor.Green;
            if (name.Contains("văn") || name.Contains("ngữ văn")) return SubjectColor.Orange;
            if (name.Contains("anh") || name.Contains("tiếng anh")) return SubjectColor.Purple;
            if (name.Contains("sử") || name.Contains("địa")) return SubjectColor.Yellow;
            if (name.Contains("thể") || name.Contains("giáo dục")) return SubjectColor.Cyan;
            return SubjectColor.Gray;
        }

        private void GetColorSchema(SubjectColor type, out Color bg, out Color text)
        {
            switch (type)
            {
                case SubjectColor.Red: bg = Color.FromArgb(255, 235, 238); text = Color.FromArgb(183, 28, 28); break;
                case SubjectColor.Blue: bg = Color.FromArgb(227, 242, 253); text = Color.FromArgb(13, 71, 161); break;
                case SubjectColor.Orange: bg = Color.FromArgb(255, 243, 224); text = Color.FromArgb(230, 81, 0); break;
                case SubjectColor.Green: bg = Color.FromArgb(232, 245, 233); text = Color.FromArgb(27, 94, 32); break;
                case SubjectColor.Purple: bg = Color.FromArgb(243, 229, 245); text = Color.FromArgb(74, 20, 140); break;
                case SubjectColor.Yellow: bg = Color.FromArgb(255, 253, 231); text = Color.FromArgb(245, 127, 23); break;
                case SubjectColor.Cyan: bg = Color.FromArgb(224, 247, 250); text = Color.FromArgb(0, 96, 100); break;
                default: bg = Color.FromArgb(241, 243, 245); text = Color.FromArgb(73, 80, 87); break;
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();
            if (radius == 0) { path.AddRectangle(bounds); return path; }
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}