using BUS;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_DoiMatKhau : UserControl
    {
        private int loggedInUserId;
        private UserBUS userBUS = new UserBUS();
        private ErrorProvider errorProvider;
        // Màu viền nhẹ (Xám nhạt)
        private Color borderColor = Color.FromArgb(210, 210, 210);

        public UC_HocSinh_DoiMatKhau(int userId)
        {
            InitializeComponent();
            this.loggedInUserId = userId;

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;// Tắt nhấp nháy cho đỡ rối mắt

            this.Resize += UC_HocSinh_DoiMatKhau_Resize;

            // Gọi hàm làm đẹp
            StyleComponents();
            AddEvents();
        }

        private void UC_HocSinh_DoiMatKhau_Resize(object sender, EventArgs e)
        {
            // Căn giữa màn hình
            if (pnlCard != null)
            {
                pnlCard.Location = new Point(
                    (this.Width - pnlCard.Width) / 2,
                    (this.Height - pnlCard.Height) / 2
                );
            }
        }

        private void StyleComponents()
        {
            // 1. Bo tròn + Tô viền cho Card (SỬA Ở ĐÂY)
            StyleCardWithBorder(pnlCard, 20);

            // 2. Icon tròn
            MakeCircular(pnlIconWrapper);

            // 3. Nút bấm
            MakeRounded(btnLuu, 10);
            MakeRounded(btnHuy, 10);

            // 4. Textbox cao hơn cho đẹp
            StyleTextBox(txtMatKhauCu);
            StyleTextBox(txtMatKhauMoi);
            StyleTextBox(txtNhapLaiMoi);
        }

        private void StyleTextBox(TextBox tb)
        {
            tb.AutoSize = false;
            tb.Height = 35;
        }

        // --- HÀM MỚI: Vừa bo tròn, vừa vẽ viền ---
        private void StyleCardWithBorder(Control control, int radius)
        {
            control.Paint += (sender, e) =>
            {
                Control ctrl = sender as Control;
                if (ctrl == null) return;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // 1. Cắt bo tròn (Region)
                Rectangle rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
                using (GraphicsPath path = GetRoundedPath(rect, radius))
                {
                    ctrl.Region = new Region(path);
                }

                // 2. Vẽ viền màu (DrawPath)
                // Vẽ lùi vào 1px để không bị mất nét do Region cắt
                Rectangle rectBorder = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);
                using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, radius))
                using (Pen pen = new Pen(borderColor, 1)) // <-- Màu viền nhẹ ở đây
                {
                    e.Graphics.DrawPath(pen, pathBorder);
                }
            };
        }

        // Hàm cũ: Chỉ bo tròn (dùng cho nút bấm)
        private void MakeRounded(Control control, int radius)
        {
            control.Paint += (sender, e) =>
            {
                Control ctrl = sender as Control;
                if (ctrl == null) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
                using (GraphicsPath path = GetRoundedPath(rect, radius))
                {
                    ctrl.Region = new Region(path);
                }
            };
        }

        private void MakeCircular(Control control)
        {
            control.Paint += (sender, e) =>
            {
                Control ctrl = sender as Control;
                if (ctrl == null) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, ctrl.Width, ctrl.Height);
                    ctrl.Region = new Region(path);
                }
            };
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        public void AddEvents()
        {
            btnLuu.Click += (s, e) =>
            {
                errorProvider.Clear();
                if (!ValidateInput())
                    return;
                string oldPass = txtMatKhauCu.Text.Trim();
                string newPass = txtMatKhauMoi.Text.Trim();
                string confirmPass = txtNhapLaiMoi.Text.Trim();
                string result = userBUS.ChangePassword(loggedInUserId, oldPass, newPass);
                if (result == "Success")
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllFields();
                }
                else if (result == "Mật khẩu cũ không chính xác!")
                {
                    errorProvider.SetError(txtMatKhauCu, result);
                    txtMatKhauCu.Focus();
                }
                else
                {
                    // Các lỗi chung khác thì hiện MessageBox
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnHuy.Click += (s, e) =>
            {
                ClearAllFields();
            };
        }
        private bool ValidateInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtMatKhauCu.Text.Trim()))
            {
                errorProvider.SetError(txtMatKhauCu, "Vui lòng nhập mật khẩu hiện tại");
                isValid = false;
            }

            string newPass = txtMatKhauMoi.Text.Trim();
            if (string.IsNullOrEmpty(newPass))
            {
                errorProvider.SetError(txtMatKhauMoi, "Vui lòng nhập mật khẩu mới");
                isValid = false;
            }
            else if (newPass.Length < 6)
            {
                errorProvider.SetError(txtMatKhauMoi, "Mật khẩu phải có ít nhất 6 ký tự");
                isValid = false;
            }

            string confirmPass = txtNhapLaiMoi.Text.Trim();
            if (string.IsNullOrEmpty(confirmPass))
            {
                errorProvider.SetError(txtNhapLaiMoi, "Vui lòng nhập lại mật khẩu mới");
                isValid = false;
            }
            else if (newPass != confirmPass)
            {
                errorProvider.SetError(txtNhapLaiMoi, "Mật khẩu xác nhận không trùng khớp");
                isValid = false;
            }

            return isValid;
        }

        private void ClearAllFields()
        {
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLaiMoi.Clear();
            errorProvider.Clear();
        }
    }
}