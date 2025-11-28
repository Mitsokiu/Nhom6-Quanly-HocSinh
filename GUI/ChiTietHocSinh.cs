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

        private readonly Color clrActive = Color.FromArgb(13, 110, 253);
        private readonly Color clrInactive = Color.White;

        public ChiTietHocSinh(int teacherUserId, StudentDTO student)
        {
            InitializeComponent(); // Designer sẽ khởi tạo picAvatar (không có lblUpload cho form xem)
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            // Load dữ liệu
            LoadComboBoxData();
            SetupUIForView();
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
            btnCancel.Click += (s, e) => this.Close();
        }

        private void SetupUIForView()
        {
            lblHeaderTitle.Text = "Chi tiết Hồ sơ";
            btnSave.Visible = false;
            btnCancel.Text = "Đóng";

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

                // --- SỬA ĐOẠN NÀY ĐỂ LOAD ẢNH ĐÚNG FOLDER ---
                string avatarFileName = _studentData.Avatar;
                string folderPath = GetProjectAvatarPath(); // Gọi hàm tìm thư mục gốc
                string fullPath = Path.Combine(folderPath, avatarFileName ?? "");

                if (!string.IsNullOrEmpty(avatarFileName) && File.Exists(fullPath))
                {
                    picAvatar.Image = Image.FromFile(fullPath);
                }
                else
                {
                    // Load ảnh mặc định nếu không thấy ảnh riêng
                    string defaultImg = _studentData.Gender == "Male" ? "default_boy.png" : "default_girl.png";
                    string defaultPath = Path.Combine(folderPath, defaultImg);
                    if (File.Exists(defaultPath))
                    {
                        picAvatar.Image = Image.FromFile(defaultPath);
                    }
                }
                // ---------------------------------------------
            }

            DisableControls(pnlContent);
            pnlContent.Enabled = true;
        }

        private void DisableControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox t) { t.ReadOnly = true; t.BackColor = Color.White; t.ForeColor = Color.Black; }
                else if (c is DateTimePicker dt) dt.Enabled = false;
                else if (c is ComboBox cb) cb.Enabled = false;
                else if (c is Button b && b.Name.Contains("Gender")) b.Enabled = false;

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