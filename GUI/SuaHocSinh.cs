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

        // Biến lưu đường dẫn ảnh tạm thời
        private string currentAvatarPath = null;

        private readonly Color clrActive = Color.FromArgb(13, 110, 253);
        private readonly Color clrInactive = Color.White;

        // Placeholder constants
        private const string PH_NAME = "Nhập họ và tên học sinh";
        private const string PH_ADDRESS = "Nhập địa chỉ";
        private const string PH_F_NAME = "Nhập họ tên";
        private const string PH_F_PHONE = "Nhập số điện thoại";
        private const string PH_F_JOB = "Nhập nghề nghiệp";
        private const string PH_M_NAME = "Nhập họ tên";
        private const string PH_M_PHONE = "Nhập số điện thoại";
        private const string PH_M_JOB = "Nhập nghề nghiệp";

        public SuaHocSinh(int teacherUserId, StudentDTO student)
        {
            InitializeComponent(); // Designer sẽ khởi tạo picAvatar và lblUpload ở đây
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errorProvider.ContainerControl = this;

            // Load dữ liệu
            LoadComboBoxData();
            SetupUIForEdit();
            SetupEventHandlers(); // Gán sự kiện gọn gàng

            this.Load += (s, e) =>
            {
                ApplyRoundedCorners();
                lblHeaderTitle.Focus(); // Bỏ focus khỏi textbox đầu tiên
            };
            pnlContent.MouseEnter += (s, e) => pnlContent.Focus();
        }

        private void SetupEventHandlers()
        {
            // Gán sự kiện click cho cả Ảnh và Chữ "Thay đổi ảnh"
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
                    lblUpload.Visible = false; // Có ảnh thì ẩn chữ
                }
            }
        }

        private string SaveAvatarToServer(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath)) return null;

            string folder = GetProjectAvatarPath();
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string fileName = "avatar_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(sourcePath);
            string destPath = Path.Combine(folder, fileName);
            File.Copy(sourcePath, destPath, true);
            return destPath; // Lưu full path hoặc relative tùy DB
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
                txtID.Text = _studentData.StudentCode;
                ToggleGender(_studentData.Gender == "Male");

                if (cboClass.Items.Count > 0) cboClass.SelectedValue = _studentData.ClassID;
                if (cboYear.Items.Count > 0)
                {
                    if (_studentData.YearID > 0) cboYear.SelectedValue = _studentData.YearID;
                    else cboYear.Text = _studentData.AcademicYear;
                }

                txtFatherName.Text = _studentData.FatherName;
                txtFatherPhone.Text = _studentData.FatherPhone;
                txtFatherJob.Text = _studentData.FatherJob;
                txtMotherName.Text = _studentData.MotherName;
                txtMotherPhone.Text = _studentData.MotherPhone;
                txtMotherJob.Text = _studentData.MotherJob;

                // --- SỬA ĐOẠN LOGIC LOAD ẢNH Ở ĐÂY ---
                string avatarFileName = _studentData.Avatar;
                string folderPath = GetProjectAvatarPath(); // Dùng hàm tìm thư mục gốc
                string fullPath = Path.Combine(folderPath, avatarFileName ?? "");

                // 1. Reset ảnh trước
                picAvatar.Image = null;
                lblUpload.Visible = true;

                // 2. Thử load ảnh riêng
                if (!string.IsNullOrEmpty(avatarFileName) && File.Exists(fullPath))
                {
                    picAvatar.Image = Image.FromFile(fullPath);
                    lblUpload.Visible = false;
                }
                else
                {
                    // 3. Nếu không có, load ảnh mặc định
                    string defaultImg = _studentData.Gender == "Male" ? "default_boy.png" : "default_girl.png";
                    string defaultPath = Path.Combine(folderPath, defaultImg);
                    if (File.Exists(defaultPath))
                    {
                        picAvatar.Image = Image.FromFile(defaultPath);
                        lblUpload.Visible = false;
                    }
                }
                lblUpload.Text = "Thay đổi ảnh";
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
                MotherName = GetText(txtMotherName, PH_M_NAME),
                MotherPhone = GetText(txtMotherPhone, PH_M_PHONE),
                MotherJob = GetText(txtMotherJob, PH_M_JOB)
            };

            // Logic Avatar: Nếu có chọn ảnh mới -> Upload & Update User
            if (!string.IsNullOrEmpty(currentAvatarPath))
            {
                string newPath = SaveAvatarToServer(currentAvatarPath);
                var user = _userBus.GetUserById(_studentData.UserID);
                if (user != null)
                {
                    user.Avatar = newPath;
                    _userBus.UpdateUser(user);
                }
                student.Avatar = newPath; // Update local DTO
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

        private void SetupPlaceholders()
        {
            var list = new (TextBox txt, string ph)[] {
                (txtName, PH_NAME), (txtAddress, PH_ADDRESS),
                (txtFatherName, PH_F_NAME), (txtFatherPhone, PH_F_PHONE), (txtFatherJob, PH_F_JOB),
                (txtMotherName, PH_M_NAME), (txtMotherPhone, PH_M_PHONE), (txtMotherJob, PH_M_JOB)
            };
            foreach (var (txt, ph) in list)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = ph; txt.ForeColor = Color.Gray;
                }
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

            // Nếu chưa chọn ảnh mới và database cũng không có ảnh -> Load ảnh mặc định
            if (string.IsNullOrEmpty(currentAvatarPath) && string.IsNullOrEmpty(_studentData.Avatar))
            {
                string imgName = isMale ? "avatar_macdinh.png" : "avatar_macdinh.png";

                // SỬA: Dùng GetProjectAvatarPath thay vì Application.StartupPath
                string path = Path.Combine(GetProjectAvatarPath(), imgName);

                if (File.Exists(path))
                {
                    picAvatar.Image = Image.FromFile(path);
                    lblUpload.Visible = false;
                }
            }
        }

        private void ApplyRoundedCorners()
        {
            // Bo tròn các panel input
            Control[] controls = { btnSave, btnCancel, btnGenderMale, btnGenderFemale,
                pnlInputName, pnlInputDob, pnlInputAddress, pnlInputID, pnlInputClass, pnlInputYear,
                pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob,
                pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob };

            foreach (var c in controls)
            {
                Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = 10; // Bán kính bo
                    path.AddArc(0, 0, r, r, 180, 90);
                    path.AddArc(bounds.Width - r, 0, r, r, 270, 90);
                    path.AddArc(bounds.Width - r, bounds.Height - r, r, r, 0, 90);
                    path.AddArc(0, bounds.Height - r, r, r, 90, 90);
                    c.Region = new Region(path);
                }
            }
            // Bo tròn panel Avatar
            Rectangle avtBounds = new Rectangle(0, 0, pnlAvatar.Width, pnlAvatar.Height);
            using (GraphicsPath path = new GraphicsPath()) { path.AddEllipse(avtBounds); pnlAvatar.Region = new Region(path); }
        }

        private string GetProjectAvatarPath()
        {
            // Bắt đầu từ nơi file .exe đang chạy (bin/Debug/...)
            string currentDir = Application.StartupPath;

            // Đi ngược lên tối đa 5 cấp cha để tìm thư mục "Avatars"
            // (Vì cấu trúc thường là: Project/bin/Debug/net6.0/...)
            for (int i = 0; i < 5; i++)
            {
                // Kiểm tra xem tại cấp này có folder Avatars không
                string tryPath = Path.Combine(currentDir, "Avatars");
                if (Directory.Exists(tryPath))
                {
                    return tryPath; // Tìm thấy! Trả về đường dẫn này
                }

                // Nếu không thấy, đi lên 1 cấp cha
                DirectoryInfo parent = Directory.GetParent(currentDir);
                if (parent == null) break; // Hết đường lui
                currentDir = parent.FullName;
            }

            // [DỰ PHÒNG] Nếu tìm mãi không thấy (do bạn chưa tạo folder), 
            // thì dùng lại đường dẫn cũ và tự tạo folder để không bị lỗi.
            string fallbackPath = Path.Combine(Application.StartupPath, "Avatars");
            if (!Directory.Exists(fallbackPath)) Directory.CreateDirectory(fallbackPath);
            return fallbackPath;
        }
    }
}