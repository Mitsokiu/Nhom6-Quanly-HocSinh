using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public partial class SuaThongBao : Form
    {
        // Màu viền cho các Panel
        private Color clrBorder = Color.FromArgb(222, 226, 230);

        // Khai báo BUS và biến lưu trữ dữ liệu
        private NotificationBUS _bus = new NotificationBUS();
        private NotificationDTO _data;
        private int _userId;

        // Constructor chính: Nhận UserId và Dữ liệu cần sửa
        public SuaThongBao(int userId, NotificationDTO data)
        {
            InitializeComponent();
            this._userId = userId;
            this._data = data;

            // Gán sự kiện Load
            this.Load += SuaThongBao_Load;
        }

        // Constructor mặc định (để tránh lỗi Designer khi mở giao diện)
        public SuaThongBao() : this(0, null) { }

        private void SuaThongBao_Load(object sender, EventArgs e)
        {
            // 1. Làm đẹp giao diện (Bo tròn các khung)
            SetRoundedRegion(pnlCard, 15);
            SetRoundedRegion(pnlTitleInput, 8);
            SetRoundedRegion(pnlEditor, 8);

            // 2. Đổ dữ liệu cũ vào các ô nhập liệu
            if (_data != null)
            {
                txtTitle.Text = _data.Title;
                txtTitle.ForeColor = Color.Black; // Đặt màu chữ đen (tránh màu xám placeholder)
                rtbContent.Text = _data.Message;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string newTitle = txtTitle.Text.Trim();
            string newContent = rtbContent.Text.Trim();
            string errorMsg;

            // Gọi BUS để cập nhật xuống Database
            // Hàm UpdateNotification trả về true nếu thành công
            bool success = _bus.UpdateNotification(_data.Id, newTitle, newContent, out errorMsg);

            if (success)
            {
                MessageBox.Show("Cập nhật thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo cho Form cha biết đã xong
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMsg, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form nếu bấm Hủy
        }

        // --- CÁC HÀM HỖ TRỢ GIAO DIỆN (UI HELPERS) ---

        // Hàm bo tròn góc cho Panel
        private void SetRoundedRegion(Control c, int r)
        {
            Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = r * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(bounds.Width - d, 0, d, d, 270, 90);
                path.AddArc(bounds.Width - d, bounds.Height - d, d, d, 0, 90);
                path.AddArc(0, bounds.Height - d, d, d, 90, 90);
                c.Region = new Region(path);
            }
        }

        // Sự kiện vẽ viền (Border) cho Panel input
        private void Control_Paint_Border(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(clrBorder, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
                }
            }
        }

        // Xử lý hiệu ứng Placeholder cho ô Tiêu đề (Khi click vào)
        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Nhập tiêu đề...")
            {
                txtTitle.Text = "";
                txtTitle.ForeColor = Color.Black;
            }
        }

        // Xử lý hiệu ứng Placeholder cho ô Tiêu đề (Khi click ra ngoài)
        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                txtTitle.Text = "Nhập tiêu đề...";
                txtTitle.ForeColor = Color.Gray;
            }
        }
    }
}