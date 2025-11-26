using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemHocSinh : Form
    {
        private Color clrActive = Color.FromArgb(13, 110, 253);
        private Color clrInactive = Color.White;
        private Color clrBorder = Color.FromArgb(222, 226, 230);

        public ThemHocSinh()
        {
            InitializeComponent();

            // Mặc định chọn Nam
            ToggleGender(true);

            // 1. Thiết lập Placeholder cho các ô nhập liệu (Vì Designer đã xóa)
            SetupPlaceholder(txtName, "Nhập họ và tên học sinh");
            SetupPlaceholder(txtAddress, "Nhập địa chỉ");
            SetupPlaceholder(txtID, "Nhập mã số");
            SetupPlaceholder(txtFatherName, "Nhập họ tên");
            SetupPlaceholder(txtFatherPhone, "Nhập số điện thoại");
            SetupPlaceholder(txtFatherJob, "Nhập nghề nghiệp");
            SetupPlaceholder(txtMotherName, "Nhập họ tên");
            SetupPlaceholder(txtMotherPhone, "Nhập số điện thoại");
            SetupPlaceholder(txtMotherJob, "Nhập nghề nghiệp");

            // 2. Gán sự kiện Click cho giới tính
            btnGenderMale.Click += (s, e) => ToggleGender(true);
            btnGenderFemale.Click += (s, e) => ToggleGender(false);

            // 3. Gán sự kiện Paint vẽ viền và avatar
            pnlAvatar.Paint += PnlAvatar_Paint;

            pnlInputName.Paint += Control_Paint_Border;
            pnlInputDob.Paint += Control_Paint_Border;
            pnlInputAddress.Paint += Control_Paint_Border;
            pnlInputID.Paint += Control_Paint_Border;
            pnlInputClass.Paint += Control_Paint_Border;
            pnlInputYear.Paint += Control_Paint_Border;
            pnlInputFatherName.Paint += Control_Paint_Border;
            pnlInputFatherPhone.Paint += Control_Paint_Border;
            pnlInputFatherJob.Paint += Control_Paint_Border;
            pnlInputMotherName.Paint += Control_Paint_Border;
            pnlInputMotherPhone.Paint += Control_Paint_Border;
            pnlInputMotherJob.Paint += Control_Paint_Border;

            // 4. Sự kiện Load để bo tròn
            this.Load += ThemHocSinh_Load;
        }

        private void ThemHocSinh_Load(object sender, EventArgs e)
        {
            SetRoundedRegion(btnSave, 5);
            SetRoundedRegion(btnCancel, 5);
            SetRoundedRegion(btnGenderMale, 5);
            SetRoundedRegion(btnGenderFemale, 5);

            SetRoundedRegion(pnlInputName, 5);
            SetRoundedRegion(pnlInputDob, 5);
            SetRoundedRegion(pnlInputAddress, 5);
            SetRoundedRegion(pnlInputID, 5);
            SetRoundedRegion(pnlInputClass, 5);
            SetRoundedRegion(pnlInputYear, 5);

            SetRoundedRegion(pnlInputFatherName, 5);
            SetRoundedRegion(pnlInputFatherPhone, 5);
            SetRoundedRegion(pnlInputFatherJob, 5);
            SetRoundedRegion(pnlInputMotherName, 5);
            SetRoundedRegion(pnlInputMotherPhone, 5);
            SetRoundedRegion(pnlInputMotherJob, 5);
        }

        // --- LOGIC PLACEHOLDER (THAY THẾ PlaceholderText) ---
        private void SetupPlaceholder(TextBox txt, string placeholder)
        {
            // Set giá trị ban đầu
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            // Sự kiện Enter (Click vào)
            txt.Enter += (s, e) => {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            // Sự kiện Leave (Click ra ngoài)
            txt.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void ToggleGender(bool isMale)
        {
            if (isMale)
            {
                btnGenderMale.BackColor = clrActive;
                btnGenderMale.ForeColor = Color.White;
                btnGenderFemale.BackColor = clrInactive;
                btnGenderFemale.ForeColor = Color.Black;
            }
            else
            {
                btnGenderFemale.BackColor = clrActive;
                btnGenderFemale.ForeColor = Color.White;
                btnGenderMale.BackColor = clrInactive;
                btnGenderMale.ForeColor = Color.Black;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- LOGIC VẼ ---
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

        private void PnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.LightGray, 2) { DashStyle = DashStyle.Dash })
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(pen, 5, 5, 140, 140);
            }
            // Vẽ biểu tượng upload đơn giản
            e.Graphics.FillRectangle(Brushes.Gray, 70, 60, 10, 20);
            Point[] arrowHead = { new Point(60, 60), new Point(90, 60), new Point(75, 40) };
            e.Graphics.FillPolygon(Brushes.Gray, arrowHead);
        }

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
    }
}