using BUS;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemThongBao : Form
    {
        private Color clrBorder = Color.FromArgb(222, 226, 230);
        private Color clrText = Color.FromArgb(33, 37, 41);
        private Color clrPlaceholder = Color.FromArgb(108, 117, 125);

        private int _currentUserId;
        private NotificationBUS _bus = new NotificationBUS();

        public ThemThongBao(int userId)
        {
            InitializeComponent();
            this._currentUserId = userId;
            this.Load += ThemThongBao_Load;
        }

        public ThemThongBao() : this(0) { }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string content = rtbContent.Text.Trim();

            // LOGIC MỚI: Mặc định gửi cho học sinh (student)
            string target = "student";

            string errorMsg;
            bool isSuccess = _bus.CreateNotification(_currentUserId, target, title, content, out errorMsg);

            if (isSuccess)
            {
                MessageBox.Show("Đăng thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMsg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemThongBao_Load(object sender, EventArgs e)
        {
            SetRoundedRegion(pnlCard, 15);
            SetRoundedRegion(pnlTitleInput, 8);
            SetRoundedRegion(pnlEditor, 8);
        }

        private void SetRoundedRegion(Control c, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(bounds.Width - d, 0, d, d, 270, 90);
            path.AddArc(bounds.Width - d, bounds.Height - d, d, d, 0, 90);
            path.AddArc(0, bounds.Height - d, d, d, 90, 90);
            c.Region = new Region(path);
        }

        private void Control_Paint_Border(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(clrBorder, 1))
                {
                    Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Nhập tiêu đề...")
            {
                txtTitle.Text = "";
                txtTitle.ForeColor = clrText;
            }
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                txtTitle.Text = "Nhập tiêu đề...";
                txtTitle.ForeColor = clrPlaceholder;
            }
        }

        // --- Logic Editor (Giữ nguyên) ---
        private void btnBold_Click(object sender, EventArgs e) => SetFontStyle(FontStyle.Bold);
        private void btnItalic_Click(object sender, EventArgs e) => SetFontStyle(FontStyle.Italic);
        private void btnUnderline_Click(object sender, EventArgs e) => SetFontStyle(FontStyle.Underline);

        private void SetFontStyle(FontStyle style)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                FontStyle newStyle = rtbContent.SelectionFont.Style.HasFlag(style)
                    ? currentFont.Style & ~style
                    : currentFont.Style | style;

                rtbContent.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }
    }
}