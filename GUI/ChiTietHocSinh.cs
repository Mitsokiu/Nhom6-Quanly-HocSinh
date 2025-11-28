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
        private PictureBox picAvatar;

        private readonly Color clrActive = Color.FromArgb(13, 110, 253);
        private readonly Color clrInactive = Color.White;

        public ChiTietHocSinh(int teacherUserId, StudentDTO student)
        {
            InitializeComponent();
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            InitializeAvatarControl();
            LoadComboBoxData();
            SetupUIForView();

            btnCancel.Click += (s, e) => this.Close();
            this.Load += (s, e) => { ApplyRoundedCorners(); lblHeaderTitle.Focus(); };
            pnlContent.MouseEnter += (s, e) => pnlContent.Focus();
        }

        private void InitializeAvatarControl()
        {
            picAvatar = new PictureBox
            {
                Size = new Size(130, 130),
                Location = new Point(40, 20),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None
            };
            MakeAvatarCircular();
            this.Controls.Add(picAvatar);
            picAvatar.BringToFront();
        }

        private void MakeAvatarCircular()
        {
            if (picAvatar.Image == null) return;
            using (var bmp = new Bitmap(picAvatar.Width, picAvatar.Height))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var path = new GraphicsPath())
                    {
                        path.AddEllipse(0, 0, picAvatar.Width - 1, picAvatar.Height - 1);
                        picAvatar.Region = new Region(path);
                        g.Clear(Color.Transparent);
                        g.DrawImage(picAvatar.Image, 0, 0, picAvatar.Width, picAvatar.Height);
                    }
                }
            }
        }

        private void SetupUIForView()
        {
            lblHeaderTitle.Text = "Chi tiết Hồ sơ";
            btnSave.Visible = false;
            btnCancel.Text = "Đóng";

            if (_studentData != null)
            {
                txtName.Text = _studentData.FullName;
                txtName.ForeColor = Color.Black;
                dtpDob.Value = _studentData.DateOfBirth;
                txtAddress.Text = _studentData.Address;
                txtAddress.ForeColor = Color.Black;
                txtID.Text = _studentData.StudentCode;
                ToggleGender(_studentData.Gender == "Male");

                if (cboClass.Items.Count > 0) cboClass.SelectedValue = _studentData.ClassID;
                if (cboYear.Items.Count > 0)
                {
                    if (_studentData.YearID > 0) cboYear.SelectedValue = _studentData.YearID;
                    else cboYear.Text = _studentData.AcademicYear;
                }

                txtFatherName.Text = _studentData.FatherName; txtFatherName.ForeColor = Color.Black;
                txtFatherPhone.Text = _studentData.FatherPhone; txtFatherPhone.ForeColor = Color.Black;
                txtFatherJob.Text = _studentData.FatherJob; txtFatherJob.ForeColor = Color.Black;
                txtMotherName.Text = _studentData.MotherName; txtMotherName.ForeColor = Color.Black;
                txtMotherPhone.Text = _studentData.MotherPhone; txtMotherPhone.ForeColor = Color.Black;
                txtMotherJob.Text = _studentData.MotherJob; txtMotherJob.ForeColor = Color.Black;

                // Hiển thị avatar
                string avatar = _studentData.Avatar;
                if (!string.IsNullOrEmpty(avatar) && File.Exists(avatar))
                {
                    picAvatar.Image = Image.FromFile(avatar);
                }
                else
                {
                    string defaultImg = _studentData.Gender == "Male" ? "default_boy.png" : "default_girl.png";
                    string path = Path.Combine(Application.StartupPath, "Avatars", defaultImg);
                    if (File.Exists(path)) picAvatar.Image = Image.FromFile(path);
                }
                MakeAvatarCircular();
            }

            DisableControls(pnlContent);
            pnlContent.Enabled = true;
        }

        private void DisableControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox) ((TextBox)c).ReadOnly = true;
                else if (c is DateTimePicker) ((DateTimePicker)c).Enabled = false;
                else if (c is ComboBox) ((ComboBox)c).Enabled = false;
                else if (c is Button) ((Button)c).Enabled = false;
                if (c.HasChildren) DisableControls(c);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                var dtClass = _teacherBus.GetHomeroomClass(_currentTeacherUserId);
                cboClass.DataSource = dtClass;
                cboClass.DisplayMember = "class_name";
                cboClass.ValueMember = "class_id";

                var dtYear = _teacherBus.GetCurrentAcademicYear();
                cboYear.DataSource = dtYear;
                cboYear.DisplayMember = "name";
                cboYear.ValueMember = "year_id";

                cboClass.Enabled = false;
                cboYear.Enabled = false;
            }
            catch { }
        }

        private void ToggleGender(bool isMale)
        {
            btnGenderMale.BackColor = isMale ? clrActive : clrInactive;
            btnGenderMale.ForeColor = isMale ? Color.White : Color.Black;
            btnGenderFemale.BackColor = isMale ? clrInactive : clrActive;
            btnGenderFemale.ForeColor = isMale ? Color.Black : Color.White;
        }

        private void ApplyRoundedCorners()
        {
            Control[] controls = { btnSave, btnCancel, btnGenderMale, btnGenderFemale,
                pnlInputName, pnlInputDob, pnlInputAddress, pnlInputID, pnlInputClass, pnlInputYear,
                pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob,
                pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob };
            foreach (var c in controls) SetRoundedRegion(c, 8);
        }

        private void SetRoundedRegion(Control c, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(0, 0, d, d, 180, 90); path.AddArc(bounds.Width - d, 0, d, d, 270, 90);
                path.AddArc(bounds.Width - d, bounds.Height - d, d, d, 0, 90); path.AddArc(0, bounds.Height - d, d, d, 90, 90);
                c.Region = new Region(path);
            }
        }
    }
}