using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChiTietHocSinh : Form
    {
        private readonly TeacherBUS _teacherBus = new TeacherBUS();
        private readonly int _currentTeacherUserId;
        private readonly StudentDTO _studentData;

        // Màu sắc giao diện
        private readonly Color clrActive = Color.FromArgb(13, 110, 253); // Xanh dương
        private readonly Color clrInputBg = Color.FromArgb(248, 249, 250); // Xám nhạt nền input

        public ChiTietHocSinh(int teacherUserId, StudentDTO student)
        {
            InitializeComponent();
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            LoadComboBoxData();
            SetupEventHandlers();

            this.Load += (s, e) =>
            {
                ApplyRoundedCorners();
                BindDataToUI();
                LockControlsForView();
                lblHeaderTitle.Focus();
            };

            pnlContent.MouseEnter += (s, e) => pnlContent.Focus();
        }

        private void SetupEventHandlers()
        {
            btnCancel.Click += (s, e) => this.Close();
        }

        private void BindDataToUI()
        {
            if (_studentData == null) return;

            // 1. Cá nhân
            txtName.Text = _studentData.FullName;
            dtpDob.Value = _studentData.DateOfBirth;
            txtAddress.Text = _studentData.Address;
            SetGenderDisplay(_studentData.Gender == "Male");

            // 2. Học tập
            if (cboClass.Items.Count > 0) cboClass.SelectedValue = _studentData.ClassID;
            if (cboYear.Items.Count > 0)
            {
                if (_studentData.YearID > 0) cboYear.SelectedValue = _studentData.YearID;
                else cboYear.Text = _studentData.AcademicYear;
            }

            // 3. Cha
            txtFatherName.Text = _studentData.FatherName;
            txtFatherPhone.Text = _studentData.FatherPhone;
            txtFatherJob.Text = _studentData.FatherJob;

            // 4. Mẹ
            txtMotherName.Text = _studentData.MotherName;
            txtMotherPhone.Text = _studentData.MotherPhone;
            txtMotherJob.Text = _studentData.MotherJob;

            // 5. Giám hộ
            txtGuardianName.Text = _studentData.GuardianName;
            txtGuardianPhone.Text = _studentData.GuardianPhone;
            txtGuardianJob.Text = _studentData.GuardianJob;
            txtGuardianRelation.Text = _studentData.GuardianRelation;

            // 6. Avatar
            LoadAvatarToUI(_studentData.Avatar);
        }

        private void LockControlsForView()
        {
            DisableControlsRecursive(pnlContent);
        }

        private void DisableControlsRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox t)
                {
                    t.ReadOnly = true;
                    t.BackColor = clrInputBg;
                    t.ForeColor = Color.Black;
                }
                else if (c is DateTimePicker dt)
                {
                    dt.Enabled = false;
                }
                else if (c is ComboBox cb)
                {
                    cb.Enabled = false;
                    cb.BackColor = clrInputBg;
                }
                else if (c is Button b && (b.Name.Contains("Gender")))
                {
                    b.Enabled = false;
                    b.FlatAppearance.BorderSize = 0;
                }

                if (c.HasChildren) DisableControlsRecursive(c);
            }
        }

        private void SetGenderDisplay(bool isMale)
        {
            btnGenderMale.BackColor = isMale ? clrActive : Color.White;
            btnGenderMale.ForeColor = isMale ? Color.White : Color.Black;
            btnGenderFemale.BackColor = isMale ? Color.White : clrActive;
            btnGenderFemale.ForeColor = isMale ? Color.Black : Color.White;
        }

        private void LoadComboBoxData()
        {
            try
            {
                var dtClass = _teacherBus.GetHomeroomClass(_currentTeacherUserId);
                cboClass.DataSource = dtClass; cboClass.DisplayMember = "class_name"; cboClass.ValueMember = "class_id";
                var dtYear = _teacherBus.GetCurrentAcademicYear();
                cboYear.DataSource = dtYear; cboYear.DisplayMember = "name"; cboYear.ValueMember = "year_id";
            }
            catch { }
        }

        private void LoadAvatarToUI(string avatarFileName)
        {
            string folderPath = GetProjectAvatarPath();
            string customPath = Path.Combine(folderPath, avatarFileName ?? "");
            string defaultPath = Path.Combine(folderPath, "avatar_macdinh.png");

            if (!string.IsNullOrEmpty(avatarFileName) && File.Exists(customPath))
                picAvatar.Image = Image.FromFile(customPath);
            else if (File.Exists(defaultPath))
                picAvatar.Image = Image.FromFile(defaultPath);

            if (picAvatar.Image != null) MakeAvatarCircular();
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
            string fallbackPath = Path.Combine(Application.StartupPath, "Avatars");
            if (!Directory.Exists(fallbackPath)) Directory.CreateDirectory(fallbackPath);
            return fallbackPath;
        }

        private void MakeAvatarCircular()
        {
            if (picAvatar.Image == null) return;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(path);
        }

        private void ApplyRoundedCorners()
        {
            Control[] controls = {
                pnlInputName, pnlInputDob, pnlInputAddress, pnlInputClass, pnlInputYear,
                pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob,
                pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob,
                pnlInputGuardianName, pnlInputGuardianPhone, pnlInputGuardianJob, pnlInputGuardianRelation,
                btnCancel, btnGenderMale, btnGenderFemale
            };

            foreach (var c in controls)
            {
                if (c == null) continue;
                Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = 10;
                    path.AddArc(0, 0, r, r, 180, 90);
                    path.AddArc(bounds.Width - r, 0, r, r, 270, 90);
                    path.AddArc(bounds.Width - r, bounds.Height - r, r, r, 0, 90);
                    path.AddArc(0, bounds.Height - r, r, r, 90, 90);
                    c.Region = new Region(path);
                }
            }
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pnlAvatar.Width, pnlAvatar.Height);
                pnlAvatar.Region = new Region(path);
            }
        }
    }
}