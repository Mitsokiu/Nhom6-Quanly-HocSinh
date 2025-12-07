using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class ThemHocSinh : Form
    {
        private readonly StudentBUS _studentBus = new StudentBUS();
        private readonly TeacherBUS _teacherBus = new TeacherBUS();
        private readonly ErrorProvider _errorProvider = new ErrorProvider();
        private readonly int _currentTeacherUserId;

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

        public ThemHocSinh(int teacherUserId)
        {
            InitializeComponent(); // Designer sẽ khởi tạo picAvatar và lblUpload ở đây
            _currentTeacherUserId = teacherUserId;

            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errorProvider.ContainerControl = this;

            // Load dữ liệu
            LoadComboBoxData();
            SetupUIForAdd();
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
            // Gán sự kiện click cho cả Ảnh và Chữ "Tải ảnh lên"
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
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh đại diện";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        currentAvatarPath = ofd.FileName;
                        picAvatar.Image = Image.FromFile(currentAvatarPath);
                        lblUpload.Visible = false; // Ẩn chữ sau khi chọn ảnh
                        MakeAvatarCircular();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh này: " + ex.Message);
                    }
                }
            }
        }

        private void MakeAvatarCircular()
        {
            if (picAvatar.Image == null) return;
            // Chỉ bo tròn hiển thị trên PictureBox
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(path);
        }

        private string SaveAvatarToServer(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath)) return null;

            string folder = Path.Combine(Application.StartupPath, "Avatars");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            // Tạo tên file duy nhất
            string fileName = "hs_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(sourcePath);
            string destPath = Path.Combine(folder, fileName);

            try
            {
                File.Copy(sourcePath, destPath, true);
                return fileName; // Trả về tên file để lưu DB
            }
            catch { return null; }
        }

        private void SetupUIForAdd()
        {
            lblHeaderTitle.Text = "Hồ sơ Học sinh Mới";
            SetupPlaceholders();
            ToggleGender(true); // Mặc định là Nam

            // Load ảnh mặc định ban đầu nếu có
            string defaultPath = Path.Combine(Application.StartupPath, "Avatars", "default_boy.png");
            if (File.Exists(defaultPath))
            {
                picAvatar.Image = Image.FromFile(defaultPath);
                lblUpload.Visible = false;
                MakeAvatarCircular();
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

                cboClass.Enabled = false; // Tự động chọn lớp chủ nhiệm
                cboYear.Enabled = false;  // Tự động chọn năm hiện tại
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

            // 1. Xử lý ảnh trước
            string savedAvatarName = SaveAvatarToServer(currentAvatarPath);
            // Nếu không chọn ảnh mới -> Dùng ảnh mặc định
            if (string.IsNullOrEmpty(savedAvatarName))
            {
                savedAvatarName = (btnGenderMale.BackColor == clrActive) ? "default_boy.png" : "default_girl.png";
            }

            var student = new StudentDTO
            {
                FullName = fullName,
                DateOfBirth = dtpDob.Value,
                Gender = btnGenderMale.BackColor == clrActive ? "Male" : "Female",
                Address = address,
                Avatar = savedAvatarName, // Lưu tên file vào DTO
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
                MessageBox.Show("Thêm học sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi: " + error, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Helper Methods ---
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

            // Nếu chưa chọn ảnh custom -> Đổi avatar mặc định theo giới tính
            if (string.IsNullOrEmpty(currentAvatarPath))
            {
                string imgName = isMale ? "default_boy.png" : "default_girl.png";
                string path = Path.Combine(Application.StartupPath, "Avatars", imgName);
                if (File.Exists(path))
                {
                    picAvatar.Image = Image.FromFile(path);
                    lblUpload.Visible = false; // Có ảnh thì ẩn chữ
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