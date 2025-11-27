using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class SuaHocSinh : Form
    {
        private readonly StudentBUS _studentBus = new StudentBUS();
        private readonly TeacherBUS _teacherBus = new TeacherBUS();
        private readonly ErrorProvider _errorProvider = new ErrorProvider();

        private readonly int _currentTeacherUserId;
        private readonly StudentDTO _studentData;

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

        public SuaHocSinh(int teacherUserId, StudentDTO student)
        {
            InitializeComponent();
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errorProvider.ContainerControl = this;

            LoadComboBoxData(); // Load danh sách trước khi gán dữ liệu
            SetupUIForEdit();

            // Events
            btnGenderMale.Click += (s, e) => ToggleGender(true);
            btnGenderFemale.Click += (s, e) => ToggleGender(false);
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
            this.Load += (s, e) => {
                ApplyRoundedCorners();
                // FIX LỖI SCROLLBAR: Đảm bảo focus vào label đầu để không bị nhảy scroll
                lblHeaderTitle.Focus();
            };

            // FIX LỖI SCROLLBAR: Kích hoạt cuộn chuột trên Panel
            pnlContent.MouseEnter += (s, e) => pnlContent.Focus();
        }

        private void SetupUIForEdit()
        {
            lblHeaderTitle.Text = "Cập nhật Hồ sơ";
            btnSave.Text = "Lưu thay đổi";

            // Đổ dữ liệu
            if (_studentData != null)
            {
                txtName.Text = _studentData.FullName;
                txtName.ForeColor = Color.Black; // Reset màu chữ placeholder

                dtpDob.Value = _studentData.DateOfBirth;

                txtAddress.Text = _studentData.Address;
                txtAddress.ForeColor = Color.Black;

                txtID.Text = _studentData.StudentCode;

                ToggleGender(_studentData.Gender == "Male");

                // Gán ComboBox
                if (cboClass.Items.Count > 0) cboClass.SelectedValue = _studentData.ClassID;

                // FIX LỖI NĂM HỌC: Đảm bảo _studentData.YearID có giá trị
                // Nếu YearID = 0 (do logic cũ chưa lấy), ta fallback lấy theo AcademicYear (Text)
                if (cboYear.Items.Count > 0)
                {
                    // Ưu tiên theo ID
                    if (_studentData.YearID > 0)
                        cboYear.SelectedValue = _studentData.YearID;
                    else
                        // Fallback theo tên hiển thị
                        cboYear.Text = _studentData.AcademicYear;
                }

                txtFatherName.Text = _studentData.FatherName; txtFatherName.ForeColor = Color.Black;
                txtFatherPhone.Text = _studentData.FatherPhone; txtFatherPhone.ForeColor = Color.Black;
                txtFatherJob.Text = _studentData.FatherJob; txtFatherJob.ForeColor = Color.Black;

                txtMotherName.Text = _studentData.MotherName; txtMotherName.ForeColor = Color.Black;
                txtMotherPhone.Text = _studentData.MotherPhone; txtMotherPhone.ForeColor = Color.Black;
                txtMotherJob.Text = _studentData.MotherJob; txtMotherJob.ForeColor = Color.Black;
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Class
                var dtClass = _teacherBus.GetHomeroomClass(_currentTeacherUserId);
                cboClass.DataSource = dtClass;
                cboClass.DisplayMember = "class_name";
                cboClass.ValueMember = "class_id";

                // Year
                var dtYear = _teacherBus.GetCurrentAcademicYear();
                cboYear.DataSource = dtYear;
                cboYear.DisplayMember = "name";
                cboYear.ValueMember = "year_id";

                // Khóa ComboBox nếu là GVCN (chỉ thêm vào lớp mình)
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

                // Lấy ID an toàn
                ClassID = (cboClass.SelectedValue != null) ? Convert.ToInt32(cboClass.SelectedValue) : 0,
                YearID = (cboYear.SelectedValue != null) ? Convert.ToInt32(cboYear.SelectedValue) : 0,

                FatherName = GetText(txtFatherName, PH_F_NAME),
                FatherPhone = GetText(txtFatherPhone, PH_F_PHONE),
                FatherJob = GetText(txtFatherJob, PH_F_JOB),
                MotherName = GetText(txtMotherName, PH_M_NAME),
                MotherPhone = GetText(txtMotherPhone, PH_M_PHONE),
                MotherJob = GetText(txtMotherJob, PH_M_JOB)
            };

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

        // Các hàm Helper (copy từ gốc)
        private string GetText(TextBox txt, string placeholder)
        {
            if (txt.Text == placeholder) return "";
            return txt.Text.Trim();
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