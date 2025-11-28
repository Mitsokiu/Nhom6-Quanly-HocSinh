using BUS;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;

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
            InitializeComponent();
            _currentTeacherUserId = teacherUserId;
            _studentData = student;

            LoadComboBoxData(); // Load danh sách trước khi gán dữ liệu
            SetupUIForView();

            // Events
            btnCancel.Click += (s, e) => this.Close();
            this.Load += (s, e) => {
                ApplyRoundedCorners();
                // FIX LỖI SCROLLBAR: Đảm bảo focus vào label đầu để không bị nhảy scroll
                lblHeaderTitle.Focus();
            };

            // FIX LỖI SCROLLBAR: Kích hoạt cuộn chuột trên Panel
            pnlContent.MouseEnter += (s, e) => pnlContent.Focus();
        }

        private void SetupUIForView()
        {
            lblHeaderTitle.Text = "Chi tiết Hồ sơ";
            btnSave.Visible = false;
            btnCancel.Text = "Đóng";

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

            // Disable toàn bộ Controls trong pnlContent
            DisableControls(pnlContent);

            // Riêng pnlContent phải Enabled=true để còn Scroll được
            pnlContent.Enabled = true;
        }

        // Hàm đệ quy Disable control nhưng trừ Panel (để giữ Scroll)
        private void DisableControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // Không disable Panel chính và Scrollbar
                if (c is Panel && c != pnlContent)
                {
                    // Vẫn disable các panel input con để không vẽ viền focus
                    // Nhưng trong trường hợp này, ta disable TextBox bên trong là đủ
                }

                if (c is TextBox) ((TextBox)c).ReadOnly = true; // ReadOnly tốt hơn Enabled=false (vẫn copy được text)
                else if (c is DateTimePicker) ((DateTimePicker)c).Enabled = false;
                else if (c is ComboBox) ((ComboBox)c).Enabled = false;
                else if (c is Button) ((Button)c).Enabled = false;

                // Đệ quy
                if (c.HasChildren) DisableControls(c);
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

                // Khóa ComboBox
                cboClass.Enabled = false;
                cboYear.Enabled = false;
            }
            catch { }
        }

        // Các hàm Helper (copy từ gốc, loại bỏ không cần)
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