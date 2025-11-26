using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemThongBao : Form
    {
        private NotificationBUS _bus = new NotificationBUS();
        private int _userId;
        private Color clrBorder = Color.FromArgb(222, 226, 230); // Màu viền

        public ThemThongBao(int userId)
        {
            InitializeComponent();
            this._userId = userId;
            this.Load += ThemThongBao_Load;
        }

        // Constructor mặc định
        public ThemThongBao() : this(0) { }

        private void ThemThongBao_Load(object sender, EventArgs e)
        {
            SetRoundedRegion(pnlCard, 15);
            SetRoundedRegion(pnlTitleInput, 8);
            SetRoundedRegion(pnlEditor, 8);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string msg = rtbContent.Text;
            string error;

            if (_bus.CreateNotification(_userId, title, msg, out error))
            {
                MessageBox.Show("Đã đăng thông báo mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- CÁC HÀM UI HELPERS (Đã bổ sung đầy đủ) ---

        // 1. Hàm vẽ viền (FIX LỖI CỦA BẠN Ở ĐÂY)
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

        // 2. Hàm bo tròn
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

        // 3. Placeholder Tiêu đề
        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Nhập tiêu đề...") { txtTitle.Text = ""; txtTitle.ForeColor = Color.Black; }
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) { txtTitle.Text = "Nhập tiêu đề..."; txtTitle.ForeColor = Color.Gray; }
        }
    }
}