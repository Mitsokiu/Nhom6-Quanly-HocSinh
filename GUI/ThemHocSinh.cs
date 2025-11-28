using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemHocSinh : Form
    {
        private readonly StudentBUS _studentBus = new StudentBUS();
        private readonly TeacherBUS _teacherBus = new TeacherBUS();
        private readonly ErrorProvider _errorProvider = new ErrorProvider();
        private readonly int _currentTeacherUserId;
        private string currentAvatarPath = null;
        private PictureBox picAvatar;

        private readonly Color clrActive = Color.FromArgb(13, 110, 253);
        private readonly Color clrInactive = Color.White;

        private const string PH_NAME = "Nhập họ và tên học sinh";
        private const string PH_ADDRESS = "Nhập địa chỉ";
        private const string PH_F_NAME = "Nhập họ tên";
        private const string PH_F_PHONE = "Nhập số điện thoại";
        private const string PH_F_JOB = "Nhập nghề nghiệp";
        private const string PH_M_NAME = "Nhập họ tên";
        private const string PH_M_PHONE = "Nhập số điện thoại";
        private const string PH_M_JOB = "Nhập nghề nghiệp";

        public ThemHocSinh(int teacherUserId)
        {
            InitializeComponent();
            _currentTeacherUserId = teacherUserId;

            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errorProvider.ContainerControl = this;

            InitializeAvatarControl();
            LoadComboBoxData();
            SetupUIForAdd();

            btnGenderMale.Click += (s, e) => ToggleGender(true);
            btnGenderFemale.Click += (s, e) => ToggleGender(false);
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
            this.Load += (s, e) =>
            {
                ApplyRoundedCorners();
                lblHeaderTitle.Focus();
            };
            pnlContent.MouseEnter += (s, e) => pnlContent.Focus();
        }

        private void InitializeAvatarControl()
        {
            picAvatar = new PictureBox
            {
                Size = new Size(130, 130),
                Location = new Point(40, 20),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.None
            };
            picAvatar.Click += PicAvatar_Click;
            MakeAvatarCircular();

            // Ảnh mặc định nam
            string defaultPath = Path.Combine(Application.StartupPath, "Avatars", "default_boy.png");
            if (File.Exists(defaultPath))
                picAvatar.Image = Image.FromFile(defaultPath);

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

        private void PicAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh đại diện";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentAvatarPath = ofd.FileName;
                    picAvatar.Image = Image.FromFile(currentAvatarPath);
                    MakeAvatarCircular();
                }
            }
        }

        private string SaveAvatarToServer(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath)) return null;

            string folder = Path.Combine(Application.StartupPath, "Avatars");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string fileName = "avatar_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(sourcePath);
            string destPath = Path.Combine(folder, fileName);
            File.Copy(sourcePath, destPath, true);
            return "Avatars/" + fileName;
        }

        private void SetupUIForAdd()
        {
            lblHeaderTitle.Text = "Hồ sơ Học sinh";
            SetupPlaceholders();
            ToggleGender(true);
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

                if (dtClass.Rows.Count > 0) cboClass.SelectedIndex = 0;
                if (dtYear.Rows.Count > 0) cboYear.SelectedIndex = 0;

                cboClass.Enabled = false;
                cboYear.Enabled = false;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            string fullName = GetText(txtName, PH_NAME);
            string address = GetText(txtAddress, PH_ADDRESS);

            if (string.IsNullOrWhiteSpace(fullName)) { _errorProvider.SetError(pnlInputName, "Vui lòng nhập họ tên"); return; }
            if (string.IsNullOrWhiteSpace(address)) { _errorProvider.SetError(pnlInputAddress, "Vui lòng nhập địa chỉ"); return; }

            var student = new StudentDTO
            {
                FullName = fullName,
                DateOfBirth = dtpDob.Value,
                Gender = btnGenderMale.BackColor == clrActive ? "Male" : "Female",
                Address = address,
                ClassID = cboClass.SelectedValue != null ? Convert.ToInt32(cboClass.SelectedValue) : 0,
                YearID = cboYear.SelectedValue != null ? Convert.ToInt32(cboYear.SelectedValue) : 0,
                FatherName = GetText(txtFatherName, PH_F_NAME),
                FatherPhone = GetText(txtFatherPhone, PH_F_PHONE),
                FatherJob = GetText(txtFatherJob, PH_F_JOB),
                MotherName = GetText(txtMotherName, PH_M_NAME),
                MotherPhone = GetText(txtMotherPhone, PH_M_PHONE),
                MotherJob = GetText(txtMotherJob, PH_M_JOB)
            };

            string error;
            bool success = _studentBus.AddStudent(student, out error);

            if (success)
            {
                string avatarPath = SaveAvatarToServer(currentAvatarPath);
                if (string.IsNullOrEmpty(avatarPath))
                {
                    avatarPath = student.Gender == "Male" ? "Avatars/default_boy.png" : "Avatars/default_girl.png";
                }

                var user = new UserDTO
                {
                    Username = "hs" + DateTime.Now.ToString("yyMMddHHmmss"),
                    Password = "123456",
                    Fullname = fullName,
                    RoleName = "student",
                    Avatar = avatarPath
                };

                new UserBUS().AddUser(user);

                MessageBox.Show("Thêm học sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetText(TextBox txt, string placeholder)
        {
            return txt.Text == placeholder ? "" : txt.Text.Trim();
        }

        private void SetupPlaceholders()
        {
            var list = new (TextBox txt, string ph)[] {
                (txtName, PH_NAME), (txtAddress, PH_ADDRESS),
                (txtFatherName, PH_F_NAME), (txtFatherPhone, PH_F_PHONE), (txtFatherJob, PH_F_JOB),
                (txtMotherName, PH_M_NAME), (txtMotherPhone, PH_M_PHONE), (txtMotherJob, PH_M_JOB)
            };
            foreach (var (txt, ph) in list)
            {
                txt.Text = ph; txt.ForeColor = Color.Gray;
                txt.Enter += (s, e) => { if (txt.Text == ph) { txt.Text = ""; txt.ForeColor = Color.Black; } };
                txt.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = ph; txt.ForeColor = Color.Gray; } };
            }
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