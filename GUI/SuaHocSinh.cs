using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
  

        // Hoặc nếu muốn tĩnh
        // private static ClassBUS classBUS = new ClassBUS();

        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private ClassBUS classBUS = new ClassBUS();



        // Biến lưu đường dẫn ảnh tạm thời khi chọn từ máy
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
            InitializeComponent();
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errorProvider.ContainerControl = this;

            // load dữ liệu trước
            LoadYears();
            LoadAllClasses();

            //LoadComboBoxData();
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
            // Gán sự kiện click cho cả Ảnh và Chữ
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

        // Hàm helper để tìm thư mục Avatars (nằm cùng cấp với folder code)
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
            // Fallback: Tạo tại bin/Debug nếu không tìm thấy
            string fallbackPath = Path.Combine(Application.StartupPath, "Avatars");
            if (!Directory.Exists(fallbackPath)) Directory.CreateDirectory(fallbackPath);
            return fallbackPath;
        }

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
            }
            catch { return null; }
        }

        // Hàm load ảnh lên giao diện
        private void LoadAvatarToUI(string avatarFileName)
        {
            string folderPath = GetProjectAvatarPath();

            // 1. Reset
            picAvatar.Image = Properties.Resources.icons8_person_96;
            lblUpload.Visible = true;

            // 2. Đường dẫn ảnh riêng và ảnh mặc định
            string customPath = Path.Combine(folderPath, avatarFileName ?? "");
            string defaultPath = Path.Combine(folderPath, "avatar_macdinh.png");

            // 3. Ưu tiên load ảnh riêng
            if (!string.IsNullOrEmpty(avatarFileName) && File.Exists(customPath))
            {
                picAvatar.Image = Image.FromFile(customPath);
                lblUpload.Visible = false;
            }
            // 4. Nếu không có, load ảnh mặc định
            else if (File.Exists(defaultPath))
            {
                picAvatar.Image = Image.FromFile(defaultPath);
                lblUpload.Visible = false;
            }

            // 5. Bo tròn nếu có ảnh
            if (picAvatar.Image != null) MakeAvatarCircular();
        }

        private void LoadYears()
        {
            try
            {
                DataTable dt = yearBUS.GetAllYear();
                if (dt == null) return;

                // Thêm lựa chọn "Tất cả" (value 0)
                DataRow dr = dt.NewRow();
                dr["year_id"] = 0;
                dr["name"] = "-- Chọn năm --";
                dt.Rows.InsertAt(dr, 0);

                cboYear.DisplayMember = "name";
                cboYear.ValueMember = "year_id";
                cboYear.DataSource = dt;
                cboYear.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load năm: " + ex.Message);
            }
        }


        private void LoadAllClasses()
        {
            try
            {
                var list = ClassBUS.GetAllClasses() ?? new List<ClassDTO>();

                // Tạo DataTable để bind vào ComboBox
                DataTable dt = new DataTable();
                dt.Columns.Add("class_id", typeof(int));
                dt.Columns.Add("class_name", typeof(string));

                // Thêm lựa chọn "Tất cả"
                DataRow dr = dt.NewRow();
                dr["class_id"] = 0;
                dr["class_name"] = "-- Tất cả lớp --";
                dt.Rows.Add(dr);

                // Thêm danh sách lớp
                foreach (var c in list)
                {
                    dt.Rows.Add(c.Id, c.ClassName);
                }

                cboClass.DisplayMember = "class_name";
                cboClass.ValueMember = "class_id";
                cboClass.DataSource = dt;

                cboClass.SelectedIndex = _studentData.ClassID;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lớp: " + ex.Message);
            }
        }

        private void SetupUIForEdit()
        {
            lblHeaderTitle.Text = "Cập nhật Hồ sơ";
            btnSave.Text = "Lưu thay đổi";

            if (_studentData != null)
            {
                txtName.Text = _studentData.FullName ?? "";
                txtAddress.Text = _studentData.Address ?? "";
                txtID.Text = _studentData.StudentCode ?? "";
                ToggleGender(_studentData.Gender == "Male");

                // Xử lý DateTimePicker tránh lỗi 0001-01-01
                if (_studentData.DateOfBirth == DateTime.MinValue)
                {
                    dtpDob.Checked = false;       // để trống
                    dtpDob.ShowCheckBox = true;   // bật chế độ hiển thị bỏ chọn
                }
                else
                {
                    dtpDob.ShowCheckBox = true;
                    dtpDob.Checked = true;
                    dtpDob.Value = _studentData.DateOfBirth;
                }

                txtFatherName.Text = _studentData.FatherName ?? "";
                txtFatherPhone.Text = _studentData.FatherPhone ?? "";
                txtFatherJob.Text = _studentData.FatherJob ?? "";

                txtMotherName.Text = _studentData.MotherName ?? "";
                txtMotherPhone.Text = _studentData.MotherPhone ?? "";
                txtMotherJob.Text = _studentData.MotherJob ?? "";

                LoadAvatarToUI(_studentData.Avatar);

                if (string.IsNullOrEmpty(_studentData.Avatar))
                {
                    lblUpload.Text = "Thay đổi ảnh";
                    lblUpload.Visible = true;
                    lblUpload.BackColor = Color.Transparent;
                }
            }
        }

        //private void LoadComboBoxData()
        //{
        //    try
        //    {
        //        var dtClass = _teacherBus.GetHomeroomClass(_currentTeacherUserId);
        //        cboClass.DataSource = dtClass;
        //        cboClass.DisplayMember = "class_name";
        //        cboClass.ValueMember = "class_id";

        //        var dtYear = _teacherBus.GetCurrentAcademicYear();
        //        cboYear.DataSource = dtYear;
        //        cboYear.DisplayMember = "name";
        //        cboYear.ValueMember = "year_id";

        //        cboClass.Enabled = false;
        //        cboYear.Enabled = false;
        //    }
        //    catch { }
        //}

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

            // Nếu người dùng chọn ảnh mới
            if (!string.IsNullOrEmpty(currentAvatarPath))
            {
                string fileName = SaveAvatarToServer(currentAvatarPath);
                if (fileName != null)
                {
                    // Update bảng Users
                    var user = _userBus.GetUserById(_studentData.UserID);
                    if (user != null)
                    {
                        user.Avatar = fileName; // Chỉ lưu tên file
                        _userBus.UpdateUser(user);
                    }
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

            // Nếu chưa chọn ảnh mới VÀ DB chưa có ảnh -> Load ảnh mặc định
            if (string.IsNullOrEmpty(currentAvatarPath) && string.IsNullOrEmpty(_studentData.Avatar))
            {
                string path = Path.Combine(GetProjectAvatarPath(), "avatar_macdinh.png");
                if (File.Exists(path))
                {
                    picAvatar.Image = Image.FromFile(path);
                    lblUpload.Visible = true; // Vẫn hiện chữ để biết có thể đổi
                }
            }
        }

        private void ApplyRoundedCorners()
        {
            Control[] controls = { btnSave, btnCancel, btnGenderMale, btnGenderFemale,
                pnlInputName, pnlInputDob, pnlInputAddress, pnlInputID, pnlInputClass, pnlInputYear,
                pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob,
                pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob };

            foreach (var c in controls)
            {
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
            using (GraphicsPath path = new GraphicsPath()) { path.AddEllipse(0, 0, pnlAvatar.Width, pnlAvatar.Height); pnlAvatar.Region = new Region(path); }
        }
    }
}