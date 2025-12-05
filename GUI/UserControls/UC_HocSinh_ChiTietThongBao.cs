using DTO; // Sử dụng DTO
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_ChiTietThongBao : UserControl
    {
        // Sự kiện để báo cho MainForm quay lại trang trước
        public event EventHandler BackClicked;
        public event EventHandler<NotificationDTO> DetailClicked;
        public UC_HocSinh_ChiTietThongBao(NotificationDTO notification)
        {
            InitializeComponent();

            // 1. Gán dữ liệu từ DTO lên giao diện
            if (notification != null)
            {
                lblTitle.Text = notification.Title;
                lblSender.Text = notification.SenderName; // Ví dụ: Ban Giám Hiệu
                lblDate.Text = notification.CreatedAt.ToString("dd 'tháng' MM, yyyy");
                lblContent.Text = notification.Message;
            }

            // 2. Sự kiện vẽ bo góc cho khung trắng (Card)
            pnlCard.Paint += PnlCard_Paint;

            //picUser.Image = Properties.Resources.sender_20;
            //picCalendar.Image = Properties.Resources.calendar_20;
            //picUser.SizeMode = PictureBoxSizeMode.Zoom;
            //picCalendar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Constructor mặc định (để Designer không lỗi)
        public UC_HocSinh_ChiTietThongBao() : this(null) { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện quay lại
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        // Hàm vẽ khung bo tròn (Rounded Rectangle)
        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Bo góc 20px
            Rectangle r = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            using (GraphicsPath path = RoundedRect(r, 20))
            using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1)) // Viền mờ
            {
                e.Graphics.FillPath(Brushes.White, path);
                e.Graphics.DrawPath(pen, path);
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