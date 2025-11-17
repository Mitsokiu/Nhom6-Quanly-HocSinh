using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TaiKhoanControl : UserControl
    {
        public TaiKhoanControl()
        {
            InitializeComponent();
            LoadSampleData();

            // Đăng ký sự kiện vẽ ô để tùy chỉnh giao diện (badge trạng thái & icon)
            dgvTaiKhoan.CellPainting += DgvTaiKhoan_CellPainting;
        }

        private void LoadSampleData()
        {
            // Thêm dữ liệu mẫu khớp với thiết kế, thay Email bằng Tên người dùng
            dgvTaiKhoan.Rows.Add("admin01", "Nguyễn Văn Admin", "Quản trị viên", "Hoạt động", "");
            dgvTaiKhoan.Rows.Add("teacher.jane", "Trần Thị Jane", "Giáo viên", "Hoạt động", "");
            dgvTaiKhoan.Rows.Add("student.john", "Lê Văn John", "Học sinh", "Hoạt động", "");
            dgvTaiKhoan.Rows.Add("teacher.mike", "Phạm Văn Mike", "Giáo viên", "Bị khóa", "");
            dgvTaiKhoan.Rows.Add("student.lily", "Nguyễn Thị Lily", "Học sinh", "Hoạt động", "");
        }

        private void DgvTaiKhoan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua header

            // 1. Vẽ cột TRẠNG THÁI (Cột index 3)
            if (e.ColumnIndex == 3)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Handled = true;

                string status = (string)e.Value;
                Color backColor = (status == "Hoạt động") ? Color.FromArgb(220, 252, 231) : Color.FromArgb(243, 244, 246); // Xanh nhạt hoặc Xám nhạt
                Color foreColor = (status == "Hoạt động") ? Color.FromArgb(22, 163, 74) : Color.FromArgb(75, 85, 99);     // Xanh đậm hoặc Xám đậm

                // Tính toán hình chữ nhật cho "viên thuốc" (badge)
                var textSize = e.Graphics.MeasureString(status, e.CellStyle.Font);
                int badgeWidth = (int)textSize.Width + 20;
                int badgeHeight = 24;
                Rectangle badgeRect = new Rectangle(
                    e.CellBounds.X + 10, // Padding left
                    e.CellBounds.Y + (e.CellBounds.Height - badgeHeight) / 2,
                    badgeWidth,
                    badgeHeight
                );

                // Vẽ nền bo tròn
                using (GraphicsPath path = GetRoundedPath(badgeRect, 12))
                using (Brush brush = new SolidBrush(backColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }

                // Vẽ chấm tròn nhỏ (dot)
                int dotSize = 6;
                Rectangle dotRect = new Rectangle(badgeRect.X + 8, badgeRect.Y + (badgeRect.Height - dotSize) / 2, dotSize, dotSize);
                using (Brush dotBrush = new SolidBrush(foreColor))
                {
                    e.Graphics.FillEllipse(dotBrush, dotRect);
                }

                // Vẽ chữ
                Rectangle textRect = new Rectangle(badgeRect.X + 18, badgeRect.Y, badgeWidth - 18, badgeHeight);
                TextRenderer.DrawText(e.Graphics, status, e.CellStyle.Font, textRect, foreColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }

            // 2. Vẽ cột HÀNH ĐỘNG (Cột index 4)
            else if (e.ColumnIndex == 4)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Handled = true;

                // Giả lập vẽ các icon (Sửa, Khóa, Menu)
                // Bạn cần thêm icon vào Resources để bỏ comment phần dưới
                try
                {
                    // Image editIcon = Resources.edit_icon; 
                    // Image lockIcon = Resources.lock_icon;
                    // Image menuIcon = Resources.menu_icon;

                    // int iconSize = 16;
                    // int spacing = 15;
                    // int startX = e.CellBounds.Right - (3 * iconSize) - (2 * spacing) - 10;
                    // int centerY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                    // e.Graphics.DrawImage(editIcon, startX, centerY, iconSize, iconSize);
                    // e.Graphics.DrawImage(lockIcon, startX + iconSize + spacing, centerY, iconSize, iconSize);
                    // e.Graphics.DrawImage(menuIcon, startX + 2 * (iconSize + spacing), centerY, iconSize, iconSize);
                }
                catch { } // Bỏ qua nếu chưa có icon
            }
        }

        // Hàm hỗ trợ vẽ bo góc
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2F;
            SizeF size = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rect.Location, size);

            path.AddArc(arc, 180, 90); // Top-Left
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90); // Top-Right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);   // Bottom-Right
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);  // Bottom-Left
            path.CloseFigure();
            return path;
        }
    }
}
