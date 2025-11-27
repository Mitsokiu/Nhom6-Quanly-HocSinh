// File: GUI/ThemHocSinh.cs
using BUS;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemHocSinh : Form
    {
        private readonly StudentBUS _studentBus = new StudentBUS();
        private readonly TeacherBUS _teacherBus = new TeacherBUS();
        private readonly ErrorProvider _errorProvider = new ErrorProvider();

        private readonly int _currentTeacherUserId;

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
            _currentTeacherUserId = teacherUserId;
            InitializeComponent();

            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errorProvider.ContainerControl = this;

            SetupPlaceholders();
            LoadComboBoxData();

            btnGenderMale.Click += (s, e) => ToggleGender(true);
            btnGenderFemale.Click += (s, e) => ToggleGender(false);
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => this.Close();

            this.Load += (s, e) => ApplyRoundedCorners();
            ToggleGender(true);
        }

        private void LoadComboBoxData()
        {
            try
            {
                var dtClass = _teacherBus.GetHomeroomClass(_currentTeacherUserId);
                if (dtClass != null && dtClass.Rows.Count > 0)
                {
                    cboClass.DataSource = dtClass;
                    cboClass.DisplayMember = "class_name";
                    cboClass.ValueMember = "class_id";
                    cboClass.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Bạn chưa được phân công chủ nhiệm lớp nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboClass.Enabled = false;
                }

                var dtYear = _teacherBus.GetCurrentAcademicYear();
                if (dtYear != null && dtYear.Rows.Count > 0)
                {
                    cboYear.DataSource = dtYear;
                    cboYear.DisplayMember = "name";
                    cboYear.ValueMember = "year_id";
                    cboYear.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();

            string fullName = txtName.Text.Trim() == PH_NAME ? "" : txtName.Text.Trim();
            string address = txtAddress.Text.Trim() == PH_ADDRESS ? "" : txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName)) { _errorProvider.SetError(pnlInputName, "Vui lòng nhập họ tên"); return; }
            if (string.IsNullOrWhiteSpace(address)) { _errorProvider.SetError(pnlInputAddress, "Vui lòng nhập địa chỉ"); return; }
            if (dtpDob.Value.Date > DateTime.Today) { _errorProvider.SetError(pnlInputDob, "Ngày sinh không hợp lệ"); return; }

            var student = new StudentDTO
            {
                FullName = fullName,
                DateOfBirth = dtpDob.Value,
                Gender = btnGenderMale.BackColor == clrActive ? "Male" : "Female",
                Address = address,
                ClassID = Convert.ToInt32(cboClass.SelectedValue),
                YearID = Convert.ToInt32(cboYear.SelectedValue),
                FatherName = GetText(txtFatherName, PH_F_NAME),
                FatherPhone = GetText(txtFatherPhone, PH_F_PHONE),
                FatherJob = GetText(txtFatherJob, PH_F_JOB),
                MotherName = GetText(txtMotherName, PH_M_NAME),
                MotherPhone = GetText(txtMotherPhone, PH_M_PHONE),
                MotherJob = GetText(txtMotherJob, PH_M_JOB)
            };

            string error;
            if (_studentBus.AddStudent(student, out error))
            {
                MessageBox.Show("Thêm học sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetText(TextBox txt, string placeholder) => txt.Text.Trim() == placeholder ? "" : txt.Text.Trim();

        private void SetupPlaceholders()
        {
            var list = new (TextBox txt, string ph)[]
            {
                (txtName, PH_NAME), (txtAddress, PH_ADDRESS),
                (txtFatherName, PH_F_NAME), (txtFatherPhone, PH_F_PHONE), (txtFatherJob, PH_F_JOB),
                (txtMotherName, PH_M_NAME), (txtMotherPhone, PH_M_PHONE), (txtMotherJob, PH_M_JOB)
            };

            foreach (var (txt, ph) in list)
            {
                txt.Text = ph;
                txt.ForeColor = Color.Gray;
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
            foreach (Control c in new Control[] { btnSave, btnCancel, btnGenderMale, btnGenderFemale,
                pnlInputName, pnlInputDob, pnlInputAddress, pnlInputClass, pnlInputYear,
                pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob,
                pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob })
            {
                SetRoundedRegion(c, 8);
            }
        }

        private void SetRoundedRegion(Control c, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(c.Width - d, 0, d, d, 270, 90);
                path.AddArc(c.Width - d, c.Height - d, d, d, 0, 90);
                path.AddArc(0, c.Height - d, d, d, 90, 90);
                c.Region = new Region(path);
            }
        }
    }
}