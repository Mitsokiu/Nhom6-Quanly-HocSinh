using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class SuaHocSinh : Form
    {
        private readonly StudentBUS _studentBus = new StudentBUS();
        private readonly TeacherBUS _teacherBus = new TeacherBUS();
        private readonly UserBUS _userBus = new UserBUS();
        private readonly ErrorProvider _errorProvider = new ErrorProvider();

        private readonly int _currentTeacherUserId;
        private readonly StudentDTO _studentData;

        private string currentAvatarPath = null;
        private readonly Color clrActive = Color.FromArgb(13, 110, 253);
        private readonly Color clrInactive = Color.White;

        // Placeholders
        private const string PH_NAME = "Nhập họ và tên học sinh";
        private const string PH_ADDRESS = "Nhập địa chỉ";
        private const string PH_F_NAME = "Nhập họ tên";
        private const string PH_F_PHONE = "Nhập số điện thoại";
        private const string PH_F_JOB = "Nhập nghề nghiệp";
        private const string PH_M_NAME = "Nhập họ tên";
        private const string PH_M_PHONE = "Nhập số điện thoại";
        private const string PH_M_JOB = "Nhập nghề nghiệp";
        // Mới
        private const string PH_G_NAME = "Nhập họ tên";
        private const string PH_G_PHONE = "Nhập số điện thoại";
        private const string PH_G_JOB = "Nhập nghề nghiệp";
        private const string PH_G_RELATION = "Nhập quan hệ (VD: Bà)";

        public SuaHocSinh(int teacherUserId, StudentDTO student)
        {
            InitializeComponent();
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errorProvider.ContainerControl = this;

            LoadComboBoxData();
            SetupUIForEdit();
            SetupEventHandlers();

            this.Load += (s, e) =>
            {
                ApplyRoundedCorners();
                lblHeaderTitle.Focus();
            };
            pnlContent.MouseEnter += (s, e) => pnlContent.Focus();
        }

        private void SetupEventHandlers()
        {
            picAvatar.Click += PicAvatar_Click;
            lblUpload.Click += PicAvatar_Click;
            btnGenderMale.Click += (s, e) => ToggleGender(true);
            btnGenderFemale.Click += (s, e) => ToggleGender(false);
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
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
                    lblUpload.Visible = false;
                    MakeAvatarCircular();
                }
            }
        }

        private void MakeAvatarCircular()
        {
            if (picAvatar.Image == null) return;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(path);
        }

<<<<<<< HEAD
=======
        // Hàm helper để tìm thư mục Avatars (nằm cùng cấp với folder code)
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
        private string GetProjectAvatarPath()
        {
            string currentDir = Application.StartupPath;
            for (int i = 0; i < 5; i++)
            {
                string tryPath = Path.Combine(currentDir, "Avatars");
                if (Directory.Exists(tryPath)) return tryPath;
<<<<<<< HEAD
=======

>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
                DirectoryInfo parent = Directory.GetParent(currentDir);
                if (parent == null) break;
                currentDir = parent.FullName;
            }
<<<<<<< HEAD
=======
            // Fallback: Tạo tại bin/Debug nếu không tìm thấy
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
            string fallbackPath = Path.Combine(Application.StartupPath, "Avatars");
            if (!Directory.Exists(fallbackPath)) Directory.CreateDirectory(fallbackPath);
            return fallbackPath;
        }

<<<<<<< HEAD
        private string SaveAvatarToServer(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath)) return null;
            string folder = GetProjectAvatarPath();
            string fileName = "hs_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(sourcePath);
            string destPath = Path.Combine(folder, fileName);
            try
            {
                File.Copy(sourcePath, destPath, true);
                return fileName;
=======
        // Lưu ảnh và chỉ trả về TÊN FILE
        private string SaveAvatarToServer(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath)) return null;

            string folder = GetProjectAvatarPath();
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string fileName = "avatar_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(sourcePath);
            string destPath = Path.Combine(folder, fileName);

            try
            {
                File.Copy(sourcePath, destPath, true);
                return fileName; // Trả về tên file để lưu DB
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
            }
            catch { return null; }
        }

<<<<<<< HEAD
        private void LoadAvatarToUI(string avatarFileName)
        {
            string folderPath = GetProjectAvatarPath();
            string customPath = Path.Combine(folderPath, avatarFileName ?? "");
            string defaultPath = Path.Combine(folderPath, "avatar_macdinh.png");

            picAvatar.Image = null;
            lblUpload.Visible = true;

=======
        // Hàm load ảnh lên giao diện
        private void LoadAvatarToUI(string avatarFileName)
        {
            string folderPath = GetProjectAvatarPath();

            // 1. Reset
            picAvatar.Image = null;
            lblUpload.Visible = true;

            // 2. Đường dẫn ảnh riêng và ảnh mặc định
            string customPath = Path.Combine(folderPath, avatarFileName ?? "");
            string defaultPath = Path.Combine(folderPath, "avatar_macdinh.png");

            // 3. Ưu tiên load ảnh riêng
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
            if (!string.IsNullOrEmpty(avatarFileName) && File.Exists(customPath))
            {
                picAvatar.Image = Image.FromFile(customPath);
                lblUpload.Visible = false;
            }
<<<<<<< HEAD
=======
            // 4. Nếu không có, load ảnh mặc định
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
            else if (File.Exists(defaultPath))
            {
                picAvatar.Image = Image.FromFile(defaultPath);
                lblUpload.Visible = false;
            }
<<<<<<< HEAD
=======

            // 5. Bo tròn nếu có ảnh
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
            if (picAvatar.Image != null) MakeAvatarCircular();
        }

        private void SetupUIForEdit()
        {
            lblHeaderTitle.Text = "Cập nhật Hồ sơ";
            btnSave.Text = "Lưu thay đổi";

            if (_studentData != null)
            {
                txtName.Text = _studentData.FullName;
                dtpDob.Value = _studentData.DateOfBirth;
                txtAddress.Text = _studentData.Address;
<<<<<<< HEAD
=======
                txtID.Text = _studentData.StudentCode;
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
                ToggleGender(_studentData.Gender == "Male");

                if (cboClass.Items.Count > 0) cboClass.SelectedValue = _studentData.ClassID;
                if (cboYear.Items.Count > 0)
                {
                    if (_studentData.YearID > 0) cboYear.SelectedValue = _studentData.YearID;
                    else cboYear.Text = _studentData.AcademicYear;
                }

<<<<<<< HEAD
                // Load thông tin Cha Mẹ
=======
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
                txtFatherName.Text = _studentData.FatherName;
                txtFatherPhone.Text = _studentData.FatherPhone;
                txtFatherJob.Text = _studentData.FatherJob;
                txtMotherName.Text = _studentData.MotherName;
                txtMotherPhone.Text = _studentData.MotherPhone;
                txtMotherJob.Text = _studentData.MotherJob;

<<<<<<< HEAD
                // Load thông tin Giám hộ (Mới)
                txtGuardianName.Text = _studentData.GuardianName;
                txtGuardianPhone.Text = _studentData.GuardianPhone;
                txtGuardianJob.Text = _studentData.GuardianJob;
                txtGuardianRelation.Text = _studentData.GuardianRelation;

                LoadAvatarToUI(_studentData.Avatar);
                if (string.IsNullOrEmpty(_studentData.Avatar))
                {
                    lblUpload.Text = "Thay đổi ảnh";
                    lblUpload.Visible = true;
                    lblUpload.BackColor = Color.Transparent;
                }
            }
            SetupPlaceholders();
        }

        private void SetupPlaceholders()
        {
            var list = new (TextBox txt, string ph)[] {
                (txtName, PH_NAME), (txtAddress, PH_ADDRESS),
                (txtFatherName, PH_F_NAME), (txtFatherPhone, PH_F_PHONE), (txtFatherJob, PH_F_JOB),
                (txtMotherName, PH_M_NAME), (txtMotherPhone, PH_M_PHONE), (txtMotherJob, PH_M_JOB),
                (txtGuardianName, PH_G_NAME), (txtGuardianPhone, PH_G_PHONE), (txtGuardianJob, PH_G_JOB), (txtGuardianRelation, PH_G_RELATION)
            };
            foreach (var (txt, ph) in list)
            {
                // Logic edit: Nếu rỗng thì hiện placeholder
                if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = ph; txt.ForeColor = Color.Gray; }
                txt.Enter += (s, e) => { if (txt.Text == ph) { txt.Text = ""; txt.ForeColor = Color.Black; } };
                txt.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = ph; txt.ForeColor = Color.Gray; } };
            }
=======
                // Load ảnh sử dụng hàm Helper
                LoadAvatarToUI(_studentData.Avatar);

                // Nếu chưa có ảnh riêng thì hiện chữ "Thay đổi ảnh" đè lên ảnh mặc định
                if (string.IsNullOrEmpty(_studentData.Avatar))
                {
                    lblUpload.Text = "Thay đổi ảnh";
                    lblUpload.Visible = true; // Hiện chữ để người dùng biết có thể đổi
                    lblUpload.BackColor = Color.Transparent; // Trong suốt để thấy avatar_macdinh ở dưới
                }
            }
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
        }

        private void LoadComboBoxData()
        {
            try
            {
                var dtClass = _teacherBus.GetHomeroomClass(_currentTeacherUserId);
<<<<<<< HEAD
                cboClass.DataSource = dtClass; cboClass.DisplayMember = "class_name"; cboClass.ValueMember = "class_id";
                var dtYear = _teacherBus.GetCurrentAcademicYear();
                cboYear.DataSource = dtYear; cboYear.DisplayMember = "name"; cboYear.ValueMember = "year_id";
                cboClass.Enabled = false; cboYear.Enabled = false;
=======
                cboClass.DataSource = dtClass;
                cboClass.DisplayMember = "class_name";
                cboClass.ValueMember = "class_id";

                var dtYear = _teacherBus.GetCurrentAcademicYear();
                cboYear.DataSource = dtYear;
                cboYear.DisplayMember = "name";
                cboYear.ValueMember = "year_id";

                cboClass.Enabled = false;
                cboYear.Enabled = false;
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
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
                StudentID = _studentData.StudentID,
                UserID = _studentData.UserID,
                FullName = fullName,
                DateOfBirth = dtpDob.Value,
                Gender = btnGenderMale.BackColor == clrActive ? "Male" : "Female",
                Address = address,
                ClassID = cboClass.SelectedValue != null ? Convert.ToInt32(cboClass.SelectedValue) : 0,
                YearID = cboYear.SelectedValue != null ? Convert.ToInt32(cboYear.SelectedValue) : 0,
                FatherName = GetText(txtFatherName, PH_F_NAME),
                FatherPhone = GetText(txtFatherPhone, PH_F_PHONE),
                FatherJob = GetText(txtFatherJob, PH_F_JOB),
<<<<<<< HEAD
                // Mẹ
                MotherName = GetText(txtMotherName, PH_M_NAME),
                MotherPhone = GetText(txtMotherPhone, PH_M_PHONE),
                MotherJob = GetText(txtMotherJob, PH_M_JOB),
                // Ng giám hộ
                GuardianName = GetText(txtGuardianName, PH_G_NAME),
                GuardianPhone = GetText(txtGuardianPhone, PH_G_PHONE),
                GuardianJob = GetText(txtGuardianJob, PH_G_JOB),
                GuardianRelation = GetText(txtGuardianRelation, PH_G_RELATION),

                Avatar = _studentData.Avatar // Giữ avatar cũ nếu ko đổi
            };

=======
                MotherName = GetText(txtMotherName, PH_M_NAME),
                MotherPhone = GetText(txtMotherPhone, PH_M_PHONE),
                MotherJob = GetText(txtMotherJob, PH_M_JOB)
            };

            // Nếu người dùng chọn ảnh mới
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
            if (!string.IsNullOrEmpty(currentAvatarPath))
            {
                string fileName = SaveAvatarToServer(currentAvatarPath);
                if (fileName != null)
                {
<<<<<<< HEAD
                    var user = _userBus.GetUserById(_studentData.UserID);
                    if (user != null) { user.Avatar = fileName; _userBus.UpdateUser(user); }
=======
                    // Update bảng Users
                    var user = _userBus.GetUserById(_studentData.UserID);
                    if (user != null)
                    {
                        user.Avatar = fileName; // Chỉ lưu tên file
                        _userBus.UpdateUser(user);
                    }
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
                    student.Avatar = fileName;
                }
            }

            string error;
            bool success = _studentBus.UpdateStudent(student, out error);

            if (success)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetText(TextBox txt, string placeholder) => txt.Text == placeholder ? "" : txt.Text.Trim();

        private void ToggleGender(bool isMale)
        {
            btnGenderMale.BackColor = isMale ? clrActive : clrInactive;
            btnGenderMale.ForeColor = isMale ? Color.White : Color.Black;
            btnGenderFemale.BackColor = isMale ? clrInactive : clrActive;
            btnGenderFemale.ForeColor = isMale ? Color.Black : Color.White;

<<<<<<< HEAD
            if (string.IsNullOrEmpty(currentAvatarPath) && string.IsNullOrEmpty(_studentData.Avatar))
            {
                string path = Path.Combine(GetProjectAvatarPath(), "avatar_macdinh.png");
                if (File.Exists(path)) { picAvatar.Image = Image.FromFile(path); lblUpload.Visible = true; }
=======
            // Nếu chưa chọn ảnh mới VÀ DB chưa có ảnh -> Load ảnh mặc định
            if (string.IsNullOrEmpty(currentAvatarPath) && string.IsNullOrEmpty(_studentData.Avatar))
            {
                string path = Path.Combine(GetProjectAvatarPath(), "avatar_macdinh.png");
                if (File.Exists(path))
                {
                    picAvatar.Image = Image.FromFile(path);
                    lblUpload.Visible = true; // Vẫn hiện chữ để biết có thể đổi
                }
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
            }
        }

        private void ApplyRoundedCorners()
        {
            Control[] controls = { btnSave, btnCancel, btnGenderMale, btnGenderFemale,
<<<<<<< HEAD
                pnlInputName, pnlInputDob, pnlInputAddress, pnlInputClass, pnlInputYear,
                pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob,
                pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob,
                pnlInputGuardianName, pnlInputGuardianPhone, pnlInputGuardianJob, pnlInputGuardianRelation // Thêm mới
            };
=======
                pnlInputName, pnlInputDob, pnlInputAddress, pnlInputID, pnlInputClass, pnlInputYear,
                pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob,
                pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob };
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c

            foreach (var c in controls)
            {
                Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = 10;
<<<<<<< HEAD
                    path.AddArc(0, 0, r, r, 180, 90); path.AddArc(bounds.Width - r, 0, r, r, 270, 90);
                    path.AddArc(bounds.Width - r, bounds.Height - r, r, r, 0, 90); path.AddArc(0, bounds.Height - r, r, r, 90, 90);
=======
                    path.AddArc(0, 0, r, r, 180, 90);
                    path.AddArc(bounds.Width - r, 0, r, r, 270, 90);
                    path.AddArc(bounds.Width - r, bounds.Height - r, r, r, 0, 90);
                    path.AddArc(0, bounds.Height - r, r, r, 90, 90);
>>>>>>> e8a5a59be4f82ec19209538edbb5956a0924c27c
                    c.Region = new Region(path);
                }
            }
            using (GraphicsPath path = new GraphicsPath()) { path.AddEllipse(0, 0, pnlAvatar.Width, pnlAvatar.Height); pnlAvatar.Region = new Region(path); }
        }
    }
}