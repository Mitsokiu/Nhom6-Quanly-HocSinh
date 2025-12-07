using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_ThongTin : UserControl
    {

        private StudentBUS studentBUS = new StudentBUS();
        private int loggedInUserId;


        private readonly Color clrBackground = Color.FromArgb(245, 247, 250);
        private readonly Color clrCard = Color.White;
        private readonly Color clrTextMain = Color.FromArgb(17, 24, 39);

        private readonly Color clrTextLabel = Color.FromArgb(75, 85, 99);

        private readonly Color clrInputBg = Color.FromArgb(243, 244, 246);
        private readonly Color clrBorder = Color.FromArgb(180, 180, 180);

        private const int INPUT_HEIGHT = 36;

        private readonly Font fontTitle = new Font("Segoe UI", 16, FontStyle.Bold);

        private readonly Font fontLabel = new Font("Segoe UI", 11, FontStyle.Bold);

        private readonly Font fontInput = new Font("Segoe UI", 12, FontStyle.Regular);

        public UC_HocSinh_ThongTin(int userId)
        {
            InitializeComponent();
            this.loggedInUserId = userId;
            SetupModernUI();
            LoadData();

            this.Resize += (s, e) => CenterAllPanels();
        }

        private void LoadData()
        {
            StudentProfileDTO profile = studentBUS.GetStudentProfile(loggedInUserId);
            LoadStudentAvatar(profile.Avatar, profile.Gender);
            if (profile == null) return;

            tbMaHS.Text = profile.StudentCode;
            tbHoTen.Text = profile.FullName;

            tbNgaySinh.Text = profile.DateOfBirth.HasValue
                              ? profile.DateOfBirth.Value.ToString("dd/MM/yyyy")
                              : "";

            tbGioiTinh.Text = profile.Gender;
            tbLop.Text = profile.ClassName;
            tbNienKhoa.Text = profile.SchoolYear;

            tbGVCN.Text = profile.TeacherName;
            tbSDTGVCN.Text = profile.TeacherPhone;

            tbDiaChi.Text = profile.Address;
            tbSDTHS.Text = profile.Phone;
            tbEmail.Text = profile.Email;

            tbHoTenCha.Text = profile.FatherName;
            tbSDTCha.Text = profile.FatherPhone;
            tbNgheNghiepCha.Text = profile.FatherJob;
            tbEmailCha.Text = profile.FatherEmail;

            if (tbHoTenMe != null) tbHoTenMe.Text = profile.MotherName;
            tbNgheNghiepMe.Text = profile.MotherJob;
            tbSDTMe.Text = profile.MotherPhone;
            if (tbEmailMe != null) tbEmailMe.Text = profile.MotherEmail;
        }

        private void LoadStudentAvatar(string avatarFileName, string genderText)
        {
            try
            {
                string folderPath = GetProjectAvatarPath();
                string defaultImg = (genderText == "Nam" || genderText == "Male") ? "student_boy.png" : "student_girl.png";

                string targetFile = defaultImg;
                if (!string.IsNullOrEmpty(avatarFileName))
                {
                    targetFile = avatarFileName;
                }

                string fullPath = Path.Combine(folderPath, targetFile);

                if (!File.Exists(fullPath))
                {
                    fullPath = Path.Combine(folderPath, defaultImg);
                }

                if (File.Exists(fullPath))
                {
                    if (pictureBox1.Image != null) pictureBox1.Image.Dispose();

                    pictureBox1.Image = Image.FromFile(fullPath);
                    MakeAvatarCircular();
                }
            }
            catch (Exception)
            {
                // Nếu lỗi quá thì bỏ qua
            }
        }

        private string GetProjectAvatarPath()
        {
            string currentDir = Application.StartupPath;
            for (int i = 0; i < 5; i++)
            {
                string tryPath = Path.Combine(currentDir, "Avatars");
                if (Directory.Exists(tryPath)) return tryPath;

                DirectoryInfo parent = Directory.GetParent(currentDir);
                if (parent == null) break;
                currentDir = parent.FullName;
            }
            return Path.Combine(Application.StartupPath, "Avatars");
        }

        private void MakeAvatarCircular()
        {
            if (pictureBox1.Image == null) return;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(path);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            MakeAvatarCircular();
        }

        private void SetupModernUI()
        {
            this.BackColor = clrBackground;

            StyleCard(pCaNhan);
            StyleCard(pLienHe);
            StyleCard(panel1);

            if (pictureBox1 != null)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BorderStyle = BorderStyle.None;
            }


            List<TextBox> listTextBox = new List<TextBox>();
            FindTextBoxesRecursive(this, listTextBox);
            foreach (var tb in listTextBox)
            {
                UpgradeTextBox(tb);
            }

            StyleAllLabels(this);

            StyleTitle(lbTitle);
            StyleTitle(lbTitle1);
            StyleTitle(lbTitle2);

            if (panel2 != null) panel2.BackColor = Color.FromArgb(220, 220, 220);

            CenterAllPanels();
        }

        private void FindTextBoxesRecursive(Control parent, List<TextBox> result)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb)
                {
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

            Panel pnlWrapper = new Panel();
            pnlWrapper.Size = new Size(tb.Width, INPUT_HEIGHT);
            pnlWrapper.Location = tb.Location;
            pnlWrapper.BackColor = clrInputBg;
            pnlWrapper.Tag = "Wrapper";

            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = clrInputBg;
            tb.ForeColor = clrTextMain;
            tb.Font = fontInput;
            tb.Tag = "Upgraded";

            int yPos = (pnlWrapper.Height - tb.Height) / 2;
            tb.Location = new Point(10, yPos);
            tb.Width = pnlWrapper.Width - 15;

            Control originalParent = tb.Parent;
            originalParent.Controls.Add(pnlWrapper);
            pnlWrapper.Controls.Add(tb);

            pnlWrapper.BringToFront();
        }

        private void StyleAllLabels(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lb)
                {
                    if (lb.Name != "lbTitle" && lb.Name != "lbTitle1" && lb.Name != "lbTitle2")
                    {
                        lb.ForeColor = clrTextLabel;
                        lb.Font = fontLabel;
                    }
                }
                else if (c is Panel) StyleAllLabels(c);
            }
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
                float penWidth = 1.0f;
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