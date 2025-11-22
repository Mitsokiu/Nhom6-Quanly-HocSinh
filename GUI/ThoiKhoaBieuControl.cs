using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThoiKhoaBieuControl : UserControl
    {
        public ThoiKhoaBieuControl()
        {
            // 1. Khởi tạo giao diện cơ bản (từ Designer)
            InitializeComponent();

            // 2. Tối ưu hiệu suất (Double Buffering)
            ConfigureDoubleBuffering();

            // 3. Tự động vẽ Header (Thứ, Tiết) bằng code
            // Việc này giúp tránh lỗi "Method not found" trong Designer
            InitTableHeaders();

            // 4. Nạp dữ liệu môn học
            LoadSampleData();
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

        // --- PHẦN QUAN TRỌNG: TẠO HEADER BẰNG CODE ---
        private void InitTableHeaders()
        {
            this.tblTimetable.SuspendLayout();

            // Thêm Header Hàng ngang (Thứ)
            AddHeaderLabel("Tiết", 0, 0);
            AddHeaderLabel("Thứ Hai", 1, 0);
            AddHeaderLabel("Thứ Ba", 2, 0);
            AddHeaderLabel("Thứ Tư", 3, 0);
            AddHeaderLabel("Thứ Năm", 4, 0);
            AddHeaderLabel("Thứ Sáu", 5, 0);
            AddHeaderLabel("Thứ Bảy", 6, 0);

            // Thêm Header Cột dọc (Tiết)
            AddPeriodLabel("Tiết 1\n7:00 - 7:45", 0, 1);
            AddPeriodLabel("Tiết 2\n8:00 - 8:45", 0, 2);
            AddPeriodLabel("Tiết 3\n9:00 - 9:45", 0, 3);
            AddPeriodLabel("Tiết 4\n10:00 - 10:45", 0, 4);
            AddPeriodLabel("Tiết 5\n11:00 - 11:45", 0, 5);

            this.tblTimetable.ResumeLayout();
        }

        private void AddHeaderLabel(string text, int col, int row)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(73, 80, 87);
            lbl.BackColor = Color.White;
            lbl.Margin = new Padding(0);
            this.tblTimetable.Controls.Add(lbl, col, row);
        }

        private void AddPeriodLabel(string text, int col, int row)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.BackColor = Color.White;
            lbl.Margin = new Padding(0);
            this.tblTimetable.Controls.Add(lbl, col, row);
        }
        // --------------------------------------------------

        private void LoadSampleData()
        {
            // Load ComboBox Tuần
            cboWeek.Items.Clear();
            cboWeek.Items.Add("Tuần 3 - 18/09/2023 - 24/09/2023");
            cboWeek.Items.Add("Tuần 4 - 25/09/2023 - 01/10/2023");
            if (cboWeek.Items.Count > 0) cboWeek.SelectedIndex = 0;

            // Load Môn học
            this.tblTimetable.SuspendLayout();
            try
            {
                // Thứ 2
                AddSubject(1, 1, "Toán", "GV: Cô Mai", "Phòng: A101", SubjectColor.Red);
                AddSubject(1, 2, "Toán", "GV: Cô Mai", "Phòng: A101", SubjectColor.Red);
                AddSubject(1, 3, "Ngữ Văn", "GV: Cô Lan", "Phòng: C305", SubjectColor.Orange);
                AddSubject(1, 4, "Thể dục", "GV: Thầy Phong", "Sân vận động", SubjectColor.Cyan);
                AddSubject(1, 5, "Chào cờ", "", "", SubjectColor.Gray);

                // Thứ 3
                AddSubject(2, 1, "Vật Lý", "GV: Thầy Hùng", "Phòng: B203", SubjectColor.Blue);
                AddSubject(2, 2, "Vật Lý", "GV: Thầy Hùng", "Phòng: B203", SubjectColor.Blue);
                AddSubject(2, 3, "Hóa Học", "GV: Thầy Bình", "Phòng: D102", SubjectColor.Green);

                // Thứ 4
                AddSubject(3, 1, "Toán", "GV: Cô Mai", "Phòng: A101", SubjectColor.Red);
                AddSubject(3, 2, "Toán", "GV: Cô Mai", "Phòng: A101", SubjectColor.Red);
                AddSubject(3, 3, "Tiếng Anh", "GV: Cô Dung", "Phòng: E109", SubjectColor.Purple);
                AddSubject(3, 4, "Tiếng Anh", "GV: Cô Dung", "Phòng: E109", SubjectColor.Purple);

                // Thứ 5
                AddSubject(4, 1, "Vật Lý", "GV: Thầy Hùng", "Phòng: B203", SubjectColor.Blue);
                AddSubject(4, 2, "Vật Lý", "GV: Thầy Hùng", "Phòng: B203", SubjectColor.Blue);
                AddSubject(4, 3, "Hóa Học", "GV: Thầy Bình", "Phòng: D102", SubjectColor.Green);
                AddSubject(4, 5, "Thể dục", "GV: Thầy Phong", "Sân vận động", SubjectColor.Cyan);

                // Thứ 6
                AddSubject(5, 1, "Ngữ Văn", "GV: Cô Lan", "Phòng: C305", SubjectColor.Orange);
                AddSubject(5, 2, "Ngữ Văn", "GV: Cô Lan", "Phòng: C305", SubjectColor.Orange);
                AddSubject(5, 3, "Lịch Sử", "GV: Thầy Nam", "Phòng: F201", SubjectColor.Yellow);
                AddSubject(5, 4, "Lịch Sử", "GV: Thầy Nam", "Phòng: F201", SubjectColor.Yellow);
                AddSubject(5, 5, "Sinh hoạt lớp", "", "", SubjectColor.Gray);
            }
            finally
            {
                this.tblTimetable.ResumeLayout();
            }
        }

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
            if (string.IsNullOrEmpty(teacherName))
            {
                lblSubject.Dock = DockStyle.Fill;
                lblSubject.TextAlign = ContentAlignment.MiddleCenter;
            }

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

        public enum SubjectColor { Red, Blue, Orange, Green, Purple, Yellow, Cyan, Gray }
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
                case SubjectColor.Gray: bg = Color.FromArgb(241, 243, 245); text = Color.FromArgb(73, 80, 87); break;
                default: bg = Color.White; text = Color.Black; break;
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