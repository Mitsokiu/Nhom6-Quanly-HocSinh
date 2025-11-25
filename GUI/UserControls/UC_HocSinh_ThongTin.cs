using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_ThongTin : UserControl
    {
        // --- BẢNG MÀU ---
        private readonly Color clrBackground = Color.FromArgb(249, 250, 251);
        private readonly Color clrCard = Color.White;
        private readonly Color clrTextMain = Color.FromArgb(17, 24, 39);      // Màu chữ nội dung (Đậm)

        // [YÊU CẦU 1] Giữ màu xám ban đầu (không đổi sang đen)
        private readonly Color clrTextLabel = Color.FromArgb(75, 85, 99);

        private readonly Color clrInputBg = Color.FromArgb(243, 244, 246);
        private readonly Color clrBorder = Color.FromArgb(180, 180, 180);

        // [YÊU CẦU 2] Chiều cao ô text tăng lên một xíu (36px là vừa đẹp, mặc định chỉ tầm 22px)
        private const int INPUT_HEIGHT = 36;

        // --- FONT ---
        private readonly Font fontTitle = new Font("Segoe UI", 16, FontStyle.Bold);

        // [YÊU CẦU 1] Thêm FontStyle.Bold để in đậm label
        private readonly Font fontLabel = new Font("Segoe UI", 11, FontStyle.Bold);

        private readonly Font fontInput = new Font("Segoe UI", 12, FontStyle.Regular);

        public UC_HocSinh_ThongTin(int userId)
        {
            InitializeComponent();
            SetupModernUI();
            LoadStaticData(); // Load data mẫu

            // Tự động căn giữa khi resize form
            this.Resize += (s, e) => CenterAllPanels();
        }

        private void SetupModernUI()
        {
            this.BackColor = clrBackground;

            // 1. Style Card (Khung)
            StyleCard(pCaNhan);
            StyleCard(pLienHe);
            StyleCard(panel1);

            // 2. Avatar
            if (pictureBox1 != null)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            }

            // 3. [QUAN TRỌNG] Làm to Textbox
            // Phải dùng List gom lại rồi mới xử lý để tránh lỗi
            List<TextBox> listTextBox = new List<TextBox>();
            FindTextBoxesRecursive(this, listTextBox);
            foreach (var tb in listTextBox)
            {
                UpgradeTextBox(tb);
            }

            // 4. Style Label (Màu xám + In đậm)
            StyleAllLabels(this);

            // 5. Style Tiêu đề lớn
            StyleTitle(lbTitle);
            StyleTitle(lbTitle1);
            StyleTitle(lbTitle2);

            // 6. Thanh kẻ ngang
            if (panel2 != null) panel2.BackColor = Color.FromArgb(220, 220, 220);

            CenterAllPanels();
        }

        // --- LOGIC LÀM TO TEXTBOX ---
        private void FindTextBoxesRecursive(Control parent, List<TextBox> result)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb)
                {
                    // Chỉ lấy những cái chưa xử lý
                    if (c.Tag == null || c.Tag.ToString() != "Upgraded")
                    {
                        result.Add(tb);
                    }
                }
                else if (c is Panel)
                {
                    FindTextBoxesRecursive(c, result);
                }
            }
        }

        private void UpgradeTextBox(TextBox tb)
        {
            if (tb.Parent == null) return;

            // Tạo Panel bọc ngoài để tăng chiều cao
            Panel pnlWrapper = new Panel();
            pnlWrapper.Size = new Size(tb.Width, INPUT_HEIGHT); // Set chiều cao 36px
            pnlWrapper.Location = tb.Location;
            pnlWrapper.BackColor = clrInputBg;
            pnlWrapper.Tag = "Wrapper";

            // Setup TextBox bên trong
            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = clrInputBg;
            tb.ForeColor = clrTextMain;
            tb.Font = fontInput;
            tb.Tag = "Upgraded";

            // Căn giữa TextBox theo chiều dọc trong Panel wrapper
            int yPos = (pnlWrapper.Height - tb.Height) / 2;
            tb.Location = new Point(10, yPos); // Padding trái 10px
            tb.Width = pnlWrapper.Width - 15;

            // Đổi cha của TextBox sang Panel mới
            Control originalParent = tb.Parent;
            originalParent.Controls.Add(pnlWrapper);
            pnlWrapper.Controls.Add(tb);

            pnlWrapper.BringToFront();
        }
        // ---------------------------

        private void StyleAllLabels(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lb)
                {
                    // Trừ các tiêu đề lớn ra
                    if (lb.Name != "lbTitle" && lb.Name != "lbTitle1" && lb.Name != "lbTitle2")
                    {
                        lb.ForeColor = clrTextLabel; // Vẫn màu Xám
                        lb.Font = fontLabel;         // Nhưng là Bold
                    }
                }
                else if (c is Panel) StyleAllLabels(c);
            }
        }

        private void LoadStaticData()
        {
            tbMaHS.Text = "HS20248899";
            tbHoTen.Text = "Nguyễn Minh Khang";
            tbNgaySinh.Text = "15/08/2008";
            tbGioiTinh.Text = "Nam";
            tbLop.Text = "11A3";
            tbNienKhoa.Text = "2023 - 2026";
            tbGVCN.Text = "Cô Phan Thị Hồng Hạnh";
            tbSDTGVCN.Text = "0988.777.666";

            tbDiaChi.Text = "Số 12, Đường Nguyễn Văn Cừ, Phường 5, Quận 5, TP.HCM";
            tbSDTHS.Text = "0912.345.678";
            tbEmail.Text = "minhkhang.nguyen@student.school.edu.vn";

            tbHoTenCha.Text = "Nguyễn Văn Hùng";
            tbSDTCha.Text = "0909.111.222";
            tbNgheNghiepCha.Text = "Kỹ sư xây dựng";
            tbEmailCha.Text = "hung.nguyenvan@gmail.com";

            if (textBox6 != null) textBox6.Text = "Trần Thị Thu Thủy";
            if (textBox1 != null) textBox1.Text = "thuthuy.tran@gmail.com";
            tbSDTMe.Text = "0903.444.555";
            tbNgheNghiepMe.Text = "Giáo viên trung học";
        }

        private void CenterAllPanels()
        {
            Panel[] mainPanels = { pCaNhan, pLienHe, panel1, panelRong };
            foreach (var p in mainPanels)
            {
                if (p != null)
                {
                    int leftPos = Math.Max(0, (this.Width - p.Width) / 2);
                    p.Left = leftPos;
                }
            }
        }

        private void StyleCard(Panel p)
        {
            if (p == null) return;
            p.BackColor = clrCard;
            p.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            p.Paint += (s, e) => {
                Panel pnl = s as Panel;
                float penWidth = 1.0f; // Viền nét mảnh 1px
                float cornerRadius = 15.0f;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                RectangleF rect = new RectangleF(
                    penWidth / 2, penWidth / 2,
                    pnl.Width - penWidth - 1, pnl.Height - penWidth - 1
                );

                GraphicsPath path = new GraphicsPath();
                path.StartFigure();
                path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                using (Pen pen = new Pen(clrBorder, penWidth))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
            p.Resize += (s, e) => p.Invalidate();
        }

        private void StyleTitle(Label lb)
        {
            if (lb == null) return;
            lb.ForeColor = clrTextMain;
            lb.Font = fontTitle;
        }
    }
}