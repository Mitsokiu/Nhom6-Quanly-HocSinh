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
        private TeacherBUS _teacherBus = new TeacherBUS(); // Thêm BUS giáo viên
        private int _currentUserId;
        private NotificationDTO _editData;
        private bool _isEditMode = false;
        private Color clrBorder = Color.FromArgb(222, 226, 230);

        public ThemThongBao(int userId, NotificationDTO editData = null)
        {
            InitializeComponent();
            this._currentUserId = userId;
            this._editData = editData;
            this._isEditMode = (editData != null);
            this.Load += ThemThongBao_Load;
        }

        private void ThemThongBao_Load(object sender, EventArgs e)
        {
            SetRoundedRegion(pnlCard, 15);
            SetRoundedRegion(pnlTitleInput, 8);
            SetRoundedRegion(pnlEditor, 8);

            if (_isEditMode)
            {
                lblPageTitle.Text = "Cập Nhật Thông Báo";
                btnSubmit.Text = "Lưu thay đổi";
                txtTitle.Text = _editData.Title; txtTitle.ForeColor = Color.Black;
                rtbContent.Text = _editData.Message;
            }
            else
            {
                // Kiểm tra và hiển thị lớp chủ nhiệm
                var dt = _teacherBus.GetHomeroomClass(_currentUserId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string className = dt.Rows[0]["class_name"].ToString();
                    lblPageTitle.Text = $"Thông Báo Mới (Gửi tới: {className})";
                }
                else
                {
                    lblPageTitle.Text = "Chưa được phân công lớp!";
                    lblPageTitle.ForeColor = Color.Red;
                    btnSubmit.Enabled = false;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string content = rtbContent.Text;
            string errorMsg;
            bool success;

            if (_isEditMode)
                success = _bus.UpdateNotification(_editData.Id, title, content, out errorMsg);
            else
                success = _bus.CreateNotification(_currentUserId, title, content, out errorMsg);

            if (success)
            {
                MessageBox.Show(_isEditMode ? "Cập nhật thành công!" : "Đã gửi thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMsg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        // UI Helpers
        private void SetRoundedRegion(Control c, int r)
        {
            Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
            using (GraphicsPath path = new GraphicsPath()) { int d = r * 2; path.AddArc(0, 0, d, d, 180, 90); path.AddArc(bounds.Width - d, 0, d, d, 270, 90); path.AddArc(bounds.Width - d, bounds.Height - d, d, d, 0, 90); path.AddArc(0, bounds.Height - d, d, d, 90, 90); c.Region = new Region(path); }
        }
        private void Control_Paint_Border(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel; if (pnl != null) { e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; using (Pen pen = new Pen(clrBorder, 1)) e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1); }
        }
        private void txtTitle_Enter(object sender, EventArgs e) { if (txtTitle.Text == "Nhập tiêu đề...") { txtTitle.Text = ""; txtTitle.ForeColor = Color.Black; } }
        private void txtTitle_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(txtTitle.Text)) { txtTitle.Text = "Nhập tiêu đề..."; txtTitle.ForeColor = Color.Gray; } }
    }
}