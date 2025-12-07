using BUS;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVBM_TKB : UserControl
    {
        private int selectedAssignId = -1;
        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();
        private int teacherId;

        public UC_GVBM_TKB(int userid)
        {
            InitializeComponent();
            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            teacherId = userid;

            LoadYears();
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

            cbBoxnamhoc.SelectedIndexChanged += CbBoxnamhoc_SelectedIndexChanged;

            // Nếu có năm học hợp lệ, load học kỳ đầu tiên
            if (cbBoxnamhoc.Items.Count > 1)
            {
                cbBoxnamhoc.SelectedIndex = 1;
            }
        }

        //========================================
        // 2. Khi chọn năm → load học kỳ của năm đó
        //========================================
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
            comboBoxhk.DataSource = list;
            comboBoxhk.DisplayMember = "SemesterName";
            comboBoxhk.ValueMember = "SemesterId";

            comboBoxhk.SelectedIndexChanged -= ComboBoxhk_SelectedIndexChanged;
            comboBoxhk.SelectedIndex = 0; // Chọn học kỳ đầu tiên
            comboBoxhk.SelectedIndexChanged += ComboBoxhk_SelectedIndexChanged;

            // Load lịch ngay học kỳ đầu tiên
            if (comboBoxhk.SelectedValue != null && int.TryParse(comboBoxhk.SelectedValue.ToString(), out int semesterId))
            {
                LoadTimetableForTeacher(Session.TeacherId, semesterId);
            }
        }

        private void LoadSemestersEmpty()
        {
            comboBoxhk.DataSource = null;
            comboBoxhk.Items.Clear();
        }

        //========================================
        // 3. Khi chọn học kỳ → load lịch giáo viên
        //========================================
        private void ComboBoxhk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxhk.SelectedValue == null) return;
            if (!int.TryParse(comboBoxhk.SelectedValue.ToString(), out int semesterId)) return;

           
            if (teacherId <= 0) return;

            LoadTimetableForTeacher(teacherId, semesterId);
        }

        //==============================
        // 4. Load dữ liệu lịch vào DataGridView
        //==============================
        private void LoadTimetableForTeacher(int teacherId, int semesterId)
        {
            dataGridView1.Rows.Clear();
             TimetableBUS timetableBUS = new TimetableBUS();
            DataTable dt = timetableBUS.GetTimetableByTeacherAndSemester(teacherId, semesterId);
            if (dt == null) return;

            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row["day"].ToString(),
                    row["Class"].ToString(),
                    row["Subject"].ToString(),
                    row["period"].ToString(),
                    row["Room"].ToString()
                );
            }

            dataGridView1.Refresh();
        }
    }
}
