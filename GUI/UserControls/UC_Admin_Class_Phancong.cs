using System;
using System.Data;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_Phancong : UserControl
    {
        private int selectedAssignId = -1;
        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();

        public UC_Admin_Class_Phancong()
        {
            InitializeComponent();
            LoadCombos();
            SetupDataGridView();
            LoadYears();

            cbBoxnamhoc.SelectedIndexChanged += CbBoxnamhoc_SelectedIndexChanged;
            comboBoxhk.SelectedIndexChanged += ComboBoxhk_SelectedIndexChanged;

            dataGridView1.CellClick += dataGridView1_CellClick;
            
        }

        //===========================
        // 1. Load danh sách năm học
        //===========================
        private void LoadYears()
        {
            DataTable dt = yearBUS.GetAllYear();
            if (dt == null) return;

            DataRow dr = dt.NewRow();
            dr["year_id"] = 0;
            dr["name"] = "-- Chọn năm --";
            dt.Rows.InsertAt(dr, 0);

            cbBoxnamhoc.DisplayMember = "name";
            cbBoxnamhoc.ValueMember = "year_id";
            cbBoxnamhoc.DataSource = dt;
        }

        //==================================================
        // 2. Khi chọn năm → load học kỳ của năm đó
        //==================================================
        private void CbBoxnamhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxnamhoc.SelectedValue == null) return;

            int yearId = Convert.ToInt32(cbBoxnamhoc.SelectedValue);

            if (yearId == 0)
            {
                LoadSemestersEmpty();
                dataGridView1.Rows.Clear();
                return;
            }

            LoadSemestersByYear(yearId);
        }

        private void LoadSemestersByYear(int yearId)
        {
            var list = semesterBUS.GetSemestersByYearId(yearId);

            comboBoxhk.SelectedIndexChanged -= ComboBoxhk_SelectedIndexChanged;

            comboBoxhk.DataSource = list;
            comboBoxhk.DisplayMember = "SemesterName";
            comboBoxhk.ValueMember = "SemesterId";

            comboBoxhk.SelectedIndexChanged += ComboBoxhk_SelectedIndexChanged;
        }

        private void LoadSemestersEmpty()
        {
            comboBoxhk.DataSource = null;
            comboBoxhk.Items.Clear();
        }

        //===========================================================
        // 3. Khi chọn học kỳ → chỉ lúc này mới load phân công
        //===========================================================
        private void ComboBoxhk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxhk.SelectedValue == null) return;

            int semesterId = Convert.ToInt32(comboBoxhk.SelectedValue);
            LoadAssignmentsBySemester(semesterId);
        }

        private void LoadAssignmentsBySemester(int semesterId)
        {
            DataTable dt = TeacherAssignmentBUS.GetAssignmentsBySemester(semesterId);
            LoadAssignmentsToGrid(dt);
        }

        //===========================================================
        // Hàm chung load vào DataGridView
        //===========================================================
        private void LoadAssignmentsToGrid(DataTable dt)
        {
            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row["class_name"],
                    row["subject_name"],
                    row["teacher_name"],
                    row["semester_name"],
                    row["periods"],
                    row["class_id"],
                    row["subject_id"],
                    row["teacher_id"],
                    row["semester_id"],
                    row["assign_id"]
                );
            }
        }

        //===========================================================
        // Combobox cố định: lớp - môn - gv
        //===========================================================
        private void LoadCombos()
        {
            comboBoxlop.DataSource = DbConnect.ExecuteQuery("SELECT class_id, class_name FROM classes");
            comboBoxlop.DisplayMember = "class_name";
            comboBoxlop.ValueMember = "class_id";

            comboBoxmon.DataSource = DbConnect.ExecuteQuery("SELECT subject_id, name FROM subjects");
            comboBoxmon.DisplayMember = "name";
            comboBoxmon.ValueMember = "subject_id";

            comboBoxgv.DataSource = DbConnect.ExecuteQuery("SELECT user_id, fullname FROM users WHERE role_id='gvbm'");
            comboBoxgv.DisplayMember = "fullname";
            comboBoxgv.ValueMember = "user_id";

            comboBoxtiet.Items.Clear();
            for (int i = 1; i <= 10; i++) comboBoxtiet.Items.Add(i);
            comboBoxtiet.SelectedIndex = 0;
        }

        //===========================================================
        // Setup grid
        //===========================================================
        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("class_name", "Lớp");
            dataGridView1.Columns.Add("subject", "Môn");
            dataGridView1.Columns.Add("teacher", "Giáo viên");
            dataGridView1.Columns.Add("semester", "Học Kì");
            dataGridView1.Columns.Add("periods", "Tiết");

            dataGridView1.Columns.Add("class_id", "class_id");
            dataGridView1.Columns["class_id"].Visible = false;

            dataGridView1.Columns.Add("subject_id", "subject_id");
            dataGridView1.Columns["subject_id"].Visible = false;

            dataGridView1.Columns.Add("teacher_id", "teacher_id");
            dataGridView1.Columns["teacher_id"].Visible = false;

            dataGridView1.Columns.Add("semester_id", "semester_id");
            dataGridView1.Columns["semester_id"].Visible = false;

            dataGridView1.Columns.Add("assign_id", "assign_id");
            dataGridView1.Columns["assign_id"].Visible = false;
        }

        //===========================================================
        // 4. Click chọn row
        //===========================================================
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0) return;

        //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

        //    comboBoxlop.SelectedValue = Convert.ToInt32(row.Cells["class_id"].Value);
        //    comboBoxmon.SelectedValue = Convert.ToInt32(row.Cells["subject_id"].Value);
        //    comboBoxgv.SelectedValue = Convert.ToInt32(row.Cells["teacher_id"].Value);
        //    comboBoxhk.SelectedValue = Convert.ToInt32(row.Cells["semester_id"].Value);
        //    comboBoxtiet.SelectedItem = row.Cells["periods"].Value;

        //    selectedAssignId = Convert.ToInt32(row.Cells["assign_id"].Value);
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            int GetIntOrMinus1(object value)
            {
                if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
                    return -1;
                return Convert.ToInt32(value);
            }

            // class
            int classVal = GetIntOrMinus1(row.Cells["class_id"].Value);
            comboBoxlop.SelectedValue = classVal == -1 ? -1 : classVal;

            // subject
            int subjectVal = GetIntOrMinus1(row.Cells["subject_id"].Value);
            comboBoxmon.SelectedValue = subjectVal == -1 ? -1 : subjectVal;

            // teacher
            int teacherVal = GetIntOrMinus1(row.Cells["teacher_id"].Value);
            comboBoxgv.SelectedValue = teacherVal == -1 ? -1 : teacherVal;

            // semester (KHÔNG reset, vẫn gán như bình thường)
            if (row.Cells["semester_id"].Value != null && row.Cells["semester_id"].Value != DBNull.Value)
                comboBoxhk.SelectedValue = Convert.ToInt32(row.Cells["semester_id"].Value);

            // periods
            var periodsValue = row.Cells["periods"].Value;
            comboBoxtiet.SelectedItem = (periodsValue == null || periodsValue == DBNull.Value)
                                        ? null
                                        : periodsValue.ToString();

            // assign_id
            selectedAssignId = GetIntOrMinus1(row.Cells["assign_id"].Value);
        }

        //===========================================================
        // 5. Add - Update - Delete
        //===========================================================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra các combobox không được bỏ trống
            if (comboBoxlop.SelectedValue == null || Convert.ToInt32(comboBoxlop.SelectedValue) == -1)
            {
                MessageBox.Show("Bạn phải chọn lớp.");
                return;
            }

            if (comboBoxmon.SelectedValue == null || Convert.ToInt32(comboBoxmon.SelectedValue) == -1)
            {
                MessageBox.Show("Bạn phải chọn môn.");
                return;
            }

            if (comboBoxgv.SelectedValue == null || Convert.ToInt32(comboBoxgv.SelectedValue) == -1)
            {
                MessageBox.Show("Bạn phải chọn giáo viên.");
                return;
            }

            if (comboBoxhk.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn học kỳ.");
                return;
            }

            if (comboBoxtiet.SelectedItem == null)
            {
                MessageBox.Show("Bạn phải chọn tiết.");
                return;
            }

            // Tạo DTO sau khi kiểm tra hợp lệ
            TeacherAssignmentDTO dto = new TeacherAssignmentDTO
            {
                TeacherId = Convert.ToInt32(comboBoxgv.SelectedValue),
                SubjectId = Convert.ToInt32(comboBoxmon.SelectedValue),
                ClassId = Convert.ToInt32(comboBoxlop.SelectedValue),
                SemesterId = Convert.ToInt32(comboBoxhk.SelectedValue),
                Periods = Convert.ToInt32(comboBoxtiet.SelectedItem)
            };

            if (TeacherAssignmentBUS.AddAssignment(dto))
            {
                LoadAssignmentsBySemester(dto.SemesterId);
            }
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAssignId == -1)
            {
                MessageBox.Show("Bạn phải chọn một phân công để cập nhật.");
                return;
            }

            // Kiểm tra combobox rỗng (trừ học kỳ)
            if (comboBoxlop.SelectedValue == null || Convert.ToInt32(comboBoxlop.SelectedValue) == -1)
            {
                MessageBox.Show("Bạn phải chọn lớp.");
                return;
            }

            if (comboBoxmon.SelectedValue == null || Convert.ToInt32(comboBoxmon.SelectedValue) == -1)
            {
                MessageBox.Show("Bạn phải chọn môn.");
                return;
            }

            if (comboBoxgv.SelectedValue == null || Convert.ToInt32(comboBoxgv.SelectedValue) == -1)
            {
                MessageBox.Show("Bạn phải chọn giáo viên.");
                return;
            }

            if (comboBoxhk.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn học kỳ.");
                return;
            }

            if (comboBoxtiet.SelectedItem == null)
            {
                MessageBox.Show("Bạn phải chọn tiết.");
                return;
            }

            TeacherAssignmentDTO dto = new TeacherAssignmentDTO
            {
                AssignId = selectedAssignId,
                TeacherId = Convert.ToInt32(comboBoxgv.SelectedValue),
                SubjectId = Convert.ToInt32(comboBoxmon.SelectedValue),
                ClassId = Convert.ToInt32(comboBoxlop.SelectedValue),
                SemesterId = Convert.ToInt32(comboBoxhk.SelectedValue),
                Periods = Convert.ToInt32(comboBoxtiet.SelectedItem)
            };

            if (TeacherAssignmentBUS.UpdateAssignment(dto))
            {
                LoadAssignmentsBySemester(dto.SemesterId);
                MessageBox.Show("Cập nhật thành công!");
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAssignId == -1)
            {
                MessageBox.Show("Bạn phải chọn phân công để xóa.");
                return;
            }

            if (comboBoxhk.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn học kỳ.");
                return;
            }

            // Xác nhận xóa
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa phân công này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            int semesterId = Convert.ToInt32(comboBoxhk.SelectedValue);

            if (TeacherAssignmentBUS.DeleteAssignment(selectedAssignId))
            {
                LoadAssignmentsBySemester(semesterId);
                MessageBox.Show("Xóa thành công!");
                selectedAssignId = -1;
            }
        }


        

        private void BtnCreateTimetable_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Việc tạo TKB mới sẽ xóa toàn bộ dữ liệu cũ. Bạn có muốn tiếp tục?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                TimetableBUS.CreateTimetableFromGrid(dataGridView1);
                MessageBox.Show("Tạo TKB mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo TKB: " + ex.Message);
            }
        }

    }
}
