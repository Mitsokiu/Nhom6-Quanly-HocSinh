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

            // 1. Cấu hình giao diện (Custom Style)
            SetupStudentGrid(); // Grid danh sách trái
            SetupHistoryGrid(); // Grid lịch sử phải


            // 2. Gán sự kiện
            cbbYear.SelectedIndexChanged += (s, e) => LoadData();
            dtpDate.ValueChanged += (s, e) => LoadData();
            LoadSemesters();

            // Khi chọn "Có mặt" -> Tự động xóa trắng ô Ghi chú
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

            // Search
            TxtSearch.Text = PLACEHOLDER_TEXT;
            TxtSearch.ForeColor = Color.Gray;
            TxtSearch.Enter += (s, e) => { if (TxtSearch.Text == PLACEHOLDER_TEXT) { TxtSearch.Text = ""; TxtSearch.ForeColor = Color.Black; } };
            TxtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(TxtSearch.Text)) { TxtSearch.Text = PLACEHOLDER_TEXT; TxtSearch.ForeColor = Color.Gray; } };
            TxtSearch.TextChanged += TxtSearch_TextChanged;

            dgvStudentList.CellClick += DgvStudentList_CellClick;
            dgvStudentList.CellFormatting += DgvStudentList_CellFormatting;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => ClearDetailPanel();

            // Bo tròn UI
            this.Load += (s, e) =>
            {
                SetRoundedRegion(pnlSearchBox, 20);
                SetRoundedRegion(pnlDetailCard, 10);
                SetRoundedRegion(btnSave, 5);
                SetRoundedRegion(btnCancel, 5);
            };
        }

        // ==========================================
        // 1. SETUP GRIDVIEW (STYLE GIỐNG HẠNH KIỂM)
        // ==========================================
        private void SetupStudentGrid()
        {
            dgvStudentList.ReadOnly = true;
            dgvStudentList.Columns.Clear();
            dgvStudentList.AutoGenerateColumns = false;

            // --- STYLE CHUNG (Giữ nguyên) ---
            dgvStudentList.BackgroundColor = Color.White;
            dgvStudentList.BorderStyle = BorderStyle.None;
            dgvStudentList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStudentList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStudentList.EnableHeadersVisualStyles = false;
            dgvStudentList.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;         
            dgvStudentList.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvStudentList.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(160, 174, 192);
            dgvStudentList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvStudentList.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0); // Giảm padding chút
            dgvStudentList.ColumnHeadersHeight = 45;
            dgvStudentList.ColumnHeadersVisible = true;

            // Row Style
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

            // --- CÁC CỘT HIỂN THỊ ---

            // Cột 1: Mã HS (Nhỏ gọn)
            dgvStudentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "MÃ SỐ",
                DataPropertyName = "StudentCode",
                Width = 80
            });

            // Cột 2: Họ Tên (Tự giãn)
            dgvStudentList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "HỌ VÀ TÊN",
                DataPropertyName = "StudentName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Cột 3: Trạng thái (Căn giữa, để hiện Có mặt/Vắng)
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
            dgvHistory.ReadOnly = true; // Chặn sửa

            // --- STYLE CHUNG ---
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.EnableHeadersVisualStyles = false;

            // Header Style
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // [QUAN TRỌNG] Chặn bôi đen Header (Gán màu select trùng màu nền)
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvHistory.ColumnHeadersDefaultCellStyle.BackColor;

            dgvHistory.ColumnHeadersHeight = 40;

            // Row Style
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvHistory.RowTemplate.Height = 40;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.AllowUserToAddRows = false;

            // --- [MỚI] CẤU HÌNH SELECT DÒNG (GIỐNG STUDENT LIST) ---
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246); // Màu xám nhạt khi chọn
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.Black; // Chữ màu đen
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả dòng
            dgvHistory.MultiSelect = false; // Chỉ chọn 1 dòng tại 1 thời điểm

            // --- CẤU HÌNH CỘT ---

            // Cột 1: Tên học sinh
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "HỌC SINH",
                DataPropertyName = "StudentName",
                Width = 200
            });

            // Cột 2: Trạng thái
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TRẠNG THÁI",
                DataPropertyName = "StatusVietnamese",
                Width = 200
            });

            // Cột 3: Lý do
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
            int semesterId = (int)cbbYear.SelectedValue;
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

            // Reset hết trước
            radAbsentPermit.Checked = false;
            radAbsentNoPermit.Checked = false;
            radLate.Checked = false;
            radPresent.Checked = false;

            // Logic tích chọn
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
                    // "present", null, rỗng -> Mặc định tích CÓ MẶT
                    radPresent.Checked = true;
                    break;
            }
        }

        private void LoadDailyHistory()
        {
            if (cbbYear.SelectedValue == null) return;

            int semesterId = (int)cbbYear.SelectedValue;
            DateTime date = dtpDate.Value;

            // Gọi hàm mới bên BUS để lấy danh sách vắng trong ngày
            DataTable dtAbsence = attBus.GetDailyAbsenceList(teacherId, semesterId, date);

            dgvHistory.DataSource = dtAbsence;

            //lblHistoryTitle.Text = $"Danh sách vắng ngày {date:dd/MM/yyyy} ({dtAbsence.Rows.Count} em)";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn học sinh chưa
            if (currentStudent == null)
            {
                MessageBox.Show("Vui lòng chọn học sinh cần điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime date = dtpDate.Value;
            bool success = false;
            string message = ""; // Biến chứa nội dung thông báo

            // TRƯỜNG HỢP 1: Chọn CÓ MẶT -> Xóa khỏi DB (Quy về trạng thái gốc)
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
            // TRƯỜNG HỢP 2: Chọn VẮNG/TRỄ -> Lưu vào DB
            else
            {
                string status = "";
                string statusText = ""; // Để hiện trong thông báo cho đẹp

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

                // Nếu chưa chọn trạng thái nào (dù logic mặc định đã cover, nhưng cứ check cho chắc)
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

            // XỬ LÝ KẾT QUẢ CUỐI CÙNG
            if (success)
            {
                // 1. Hiện thông báo thành công (Theo yêu cầu của bạn)
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 2. Refresh lại giao diện
                BindGrid(); // Cập nhật màu sắc bên trái
                LoadDailyHistory(); // Cập nhật danh sách vắng bên phải
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
                // Thêm điều kiện tìm theo StudentCode
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
            // Kiểm tra nếu là cột Trạng thái (Index = 2) và giá trị không null
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                string rawStatus = e.Value.ToString();
                string statusText = "Có mặt";
                Color statusColor = Color.Green; // Mặc định xanh lá

                // Font chữ mặc định
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
                        // present, null hoặc chuỗi lạ -> Mặc định là Có mặt
                        statusText = "Có mặt";
                        statusColor = Color.Green;
                        break;
                }

                e.Value = statusText; // Chỉ thay đổi hiển thị, không đổi data gốc
                e.CellStyle.ForeColor = statusColor;
                e.FormattingApplied = true; // Báo cho Grid biết đã xử lý xong
            }
        }


        private void LockControls(bool isLocked)
        {
            // 1. Khóa/Mở nút Lưu
            btnSave.Enabled = !isLocked;
            btnSave.BackColor = isLocked ? Color.Gray : Color.FromArgb(13, 110, 253);

            // 2. Khóa/Mở vùng chọn trạng thái (Radio buttons)
            pnlStatusGroup.Enabled = !isLocked;

            // 3. Khóa/Mở ô ghi chú
            // (Lưu ý: Nếu đang chọn 'Có mặt' thì nó đã disabled rồi, nên chỉ enable lại nếu không bị khóa)
            if (isLocked)
            {
                txtNote.Enabled = false;
            }
            else
            {
                // Nếu mở khóa, chỉ cho nhập ghi chú nếu KHÔNG phải là có mặt (theo logic cũ của bạn)
                txtNote.Enabled = !radPresent.Checked;
            }

            // 4. Thông báo visual cho người dùng biết
          /*  if (isLocked)
            {
                lblTitle.Text = "Điểm danh học sinh";
                lblTitle.ForeColor = Color.Red;
            }
            else
            {
                lblTitle.Text = "Điểm danh học sinh";
                lblTitle.ForeColor = Color.Black;
            }*/
        }
    }
}