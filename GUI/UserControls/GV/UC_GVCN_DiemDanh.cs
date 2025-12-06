using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVCN_DiemDanh : UserControl
    {
        private int teacherId;
        private AttendanceBUS attBus = new AttendanceBUS();
        private SemesterBUS semBus = new SemesterBUS();

        private List<AttendanceDTO> fullList = new List<AttendanceDTO>();
        private List<AttendanceDTO> displayList = new List<AttendanceDTO>();

        private AttendanceDTO currentStudent = null;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh...";

        public UC_GVCN_DiemDanh(int teacherIdInput)
        {
            InitializeComponent();
            this.teacherId = teacherIdInput;

            SetupStudentGrid(); 
            SetupHistoryGrid(); 


            cbbYear.SelectedIndexChanged += (s, e) => LoadData();
            dtpDate.ValueChanged += (s, e) => LoadData();
            LoadSemesters();

            radPresent.CheckedChanged += (s, e) =>
            {
                if (radPresent.Checked)
                {
                    txtNote.Clear();
                    txtNote.Enabled = false; 
                }
                else
                {
                    txtNote.Enabled = true;
                }
            };

            TxtSearch.Text = PLACEHOLDER_TEXT;
            TxtSearch.ForeColor = Color.Gray;
            TxtSearch.Enter += (s, e) => { if (TxtSearch.Text == PLACEHOLDER_TEXT) { TxtSearch.Text = ""; TxtSearch.ForeColor = Color.Black; } };
            TxtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(TxtSearch.Text)) { TxtSearch.Text = PLACEHOLDER_TEXT; TxtSearch.ForeColor = Color.Gray; } };
            TxtSearch.TextChanged += TxtSearch_TextChanged;

            dgvStudentList.CellClick += DgvStudentList_CellClick;
            dgvStudentList.CellFormatting += DgvStudentList_CellFormatting;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => ClearDetailPanel();

            this.Load += (s, e) =>
            {
                SetRoundedRegion(pnlSearchBox, 20);
                SetRoundedRegion(pnlDetailCard, 10);
                SetRoundedRegion(btnSave, 5);
                SetRoundedRegion(btnCancel, 5);
            };
        }

        private void SetupStudentGrid()
        {
            dgvStudentList.ReadOnly = true;
            dgvStudentList.Columns.Clear();
            dgvStudentList.AutoGenerateColumns = false;

            dgvStudentList.BackgroundColor = Color.White;
            dgvStudentList.BorderStyle = BorderStyle.None;
            dgvStudentList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStudentList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStudentList.EnableHeadersVisualStyles = false;
            dgvStudentList.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;         
            dgvStudentList.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvStudentList.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 174, 192);
            dgvStudentList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvStudentList.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0); 
            dgvStudentList.ColumnHeadersHeight = 45;
            dgvStudentList.ColumnHeadersVisible = true;

            dgvStudentList.DefaultCellStyle.BackColor = Color.White;
            dgvStudentList.DefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvStudentList.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvStudentList.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgvStudentList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dgvStudentList.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvStudentList.RowTemplate.Height = 55;

            dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentList.MultiSelect = false;
            dgvStudentList.RowHeadersVisible = false;
            dgvStudentList.AllowUserToAddRows = false;


            dgvStudentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "MÃ SỐ",
                DataPropertyName = "StudentCode",
                Width = 80
            });

            dgvStudentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "HỌ VÀ TÊN",
                DataPropertyName = "StudentName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            var colStatus = new DataGridViewTextBoxColumn
            {
                HeaderText = "TRẠNG THÁI",
                DataPropertyName = "Status",
                Width = 150
            };
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStudentList.Columns.Add(colStatus);
        }

        private void SetupHistoryGrid()
        {
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.ReadOnly = true; 

            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.EnableHeadersVisualStyles = false;

            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvHistory.ColumnHeadersDefaultCellStyle.BackColor;

            dgvHistory.ColumnHeadersHeight = 40;

            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvHistory.RowTemplate.Height = 40;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.AllowUserToAddRows = false;

            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.Black; 
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgvHistory.MultiSelect = false;


            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "HỌC SINH",
                DataPropertyName = "StudentName",
                Width = 200
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TRẠNG THÁI",
                DataPropertyName = "StatusVietnamese",
                Width = 200
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "LÝ DO",
                DataPropertyName = "note",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void LoadSemesters()
        {
            List<SemesterDTO> list = semBus.GetAllSemesters();
            cbbYear.DataSource = list;
            cbbYear.DisplayMember = "DisplayName";
            cbbYear.ValueMember = "SemesterId";

            if (list.Count > 0)
            {           
                cbbYear.SelectedIndex = 0;
                LoadData();
            }
        }

        private void LoadData()
        {
            if (cbbYear.SelectedValue == null) return;

            // 2. KHẮC PHỤC LỖI: Kiểm tra xem SelectedValue có phải là DTO không
            // (Xảy ra khi ValueMember chưa kịp map trong quá trình khởi tạo)
            if (cbbYear.SelectedValue is SemesterDTO) return;

            int semesterId;
            try
            {
                semesterId = Convert.ToInt32(cbbYear.SelectedValue);
            }
            catch
            {
                // Nếu không convert được thì thoát để tránh crash app
                return;
            }

            DateTime date = dtpDate.Value;

            bool isLocked = attBus.IsAttendanceLocked(date);
            LockControls(isLocked);

            string className = attBus.GetClassName(teacherId, semesterId);
            lblClassName.Text = className;

            fullList = attBus.GetAttendanceList(teacherId, date, semesterId);
            displayList = new List<AttendanceDTO>(fullList);

            BindGrid();
            ClearDetailPanel();

            LoadDailyHistory();
        }

        private void BindGrid()
        {
            dgvStudentList.DataSource = null;
            dgvStudentList.DataSource = displayList;

           
        }

        private void DgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            currentStudent = dgvStudentList.Rows[e.RowIndex].DataBoundItem as AttendanceDTO;

            if (currentStudent != null)
            {
                FillDetailPanel();
            }
        }

        private void FillDetailPanel()
        {
            if (currentStudent == null) return;

            lblDetailName.Text = $"Điểm danh: {currentStudent.StudentName} ({currentStudent.StudentCode})";
            txtNote.Text = currentStudent.Note;

            radAbsentPermit.Checked = false;
            radAbsentNoPermit.Checked = false;
            radLate.Checked = false;
            radPresent.Checked = false;

            switch (currentStudent.Status)
            {
                case "absent_permit":
                    radAbsentPermit.Checked = true;
                    break;
                case "absent_no_permit":
                    radAbsentNoPermit.Checked = true;
                    break;
                case "late":
                    radLate.Checked = true;
                    break;
                default:
                    radPresent.Checked = true;
                    break;
            }
        }

        private void LoadDailyHistory()
        {
            if (cbbYear.SelectedValue == null) return;

            int semesterId = (int)cbbYear.SelectedValue;
            DateTime date = dtpDate.Value;

            DataTable dtAbsence = attBus.GetDailyAbsenceList(teacherId, semesterId, date);

            dgvHistory.DataSource = dtAbsence;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("Vui lòng chọn học sinh cần điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime date = dtpDate.Value;
            bool success = false;
            string message = ""; 

            if (radPresent.Checked)
            {
                success = attBus.DeleteAttendance(currentStudent.StudentId, date);
                if (success)
                {
                    currentStudent.Status = "present";
                    currentStudent.Note = "";
                    message = $"Đã cập nhật trạng thái: {currentStudent.StudentName} - CÓ MẶT";
                }
            }
            else
            {
                string status = "";
                string statusText = ""; 

                if (radAbsentPermit.Checked)
                {
                    status = "absent_permit";
                    statusText = "Nghỉ có phép";
                }
                else if (radAbsentNoPermit.Checked)
                {
                    status = "absent_no_permit";
                    statusText = "Nghỉ không phép";
                }
                else if (radLate.Checked)
                {
                    status = "late";
                    statusText = "Đi trễ";
                }

                if (string.IsNullOrEmpty(status)) return;

                string note = txtNote.Text.Trim();

                success = attBus.SaveAttendance(currentStudent.StudentId, currentStudent.ClassId, date, status, note);
                if (success)
                {
                    currentStudent.Status = status;
                    currentStudent.Note = note;
                    message = $"Đã lưu: {currentStudent.StudentName} - {statusText}";
                }
            }

            if (success)
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BindGrid(); 
                LoadDailyHistory(); 
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDetailPanel()
        {
            currentStudent = null;
            lblDetailName.Text = "Chọn học sinh để điểm danh...";
            txtNote.Clear();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = TxtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kw) || kw == PLACEHOLDER_TEXT.ToLower())
            {
                displayList = new List<AttendanceDTO>(fullList);
            }
            else
            {
                displayList = fullList.Where(s =>
                    s.StudentName.ToLower().Contains(kw) ||
                    s.StudentCode.ToLower().Contains(kw)
                ).ToList();
            }

            BindGrid();
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

        private void DgvStudentList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                string rawStatus = e.Value.ToString();
                string statusText = "Có mặt";
                Color statusColor = Color.Green; 

                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                switch (rawStatus)
                {
                    case "absent_permit":
                        statusText = "Có phép";
                        statusColor = Color.Red;
                        break;
                    case "absent_no_permit":
                        statusText = "Không Phép";
                        statusColor = Color.Red;
                        break;
                    case "late":
                        statusText = "Đi trễ";
                        statusColor = Color.Orange;
                        break;
                    default:
                        statusText = "Có mặt";
                        statusColor = Color.Green;
                        break;
                }

                e.Value = statusText; 
                e.CellStyle.ForeColor = statusColor;
                e.FormattingApplied = true; 
            }
        }


        private void LockControls(bool isLocked)
        {
            btnSave.Enabled = !isLocked;
            btnSave.BackColor = isLocked ? Color.Gray : Color.FromArgb(13, 110, 253);

            pnlStatusGroup.Enabled = !isLocked;
 
            if (isLocked)
            {
                txtNote.Enabled = false;
            }
            else
            {
                txtNote.Enabled = !radPresent.Checked;
            }
        }
    }
}