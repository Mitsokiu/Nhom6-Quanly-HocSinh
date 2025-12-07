using BUS;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_TKB : UserControl
    {
        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();
        private TimetableBUS timetableBUS = new TimetableBUS();

        public UC_Admin_NamHoc_TKB()
        {
            InitializeComponent();
            InitEvents();
            LoadYears();
        }

        // ========================================================
        // 1) GÁN SỰ KIỆN CHO COMBO
        // ========================================================
        private void InitEvents()
        {
            comboBoxYear.SelectedIndexChanged += comboBoxYear_SelectedIndexChanged;
            comboBoxHocKi.SelectedIndexChanged += comboBoxHocKi_SelectedIndexChanged;
            btnCreat.Click += btnCreat_Click;
        }

        // ========================================================
        // 2) LOAD NĂM HỌC
        // ========================================================
        private void LoadYears()
        {
            DataTable dt = yearBUS.GetAllYear();
            if (dt == null) return;

            // Thêm dòng "-- Chọn năm --"
            DataRow dr = dt.NewRow();
            dr["year_id"] = 0;
            dr["name"] = "-- Chọn năm --";
            dt.Rows.InsertAt(dr, 0);

            comboBoxYear.DataSource = dt;
            comboBoxYear.DisplayMember = "name";
            comboBoxYear.ValueMember = "year_id";
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drv = comboBoxYear.SelectedItem as DataRowView;
            if (drv == null) return;

            int yearId = Convert.ToInt32(drv["year_id"]);

            if (yearId == 0)
            {
                ClearSemesters();
                btnCreat.Enabled = false;
                return;
            }

            LoadSemesters(yearId);
        }

        // ========================================================
        // 3) LOAD HỌC KỲ THEO NĂM
        // ========================================================
        private void LoadSemesters(int yearId)
        {
            var list = semesterBUS.GetSemestersByYearId(yearId);

            comboBoxHocKi.DataSource = list;
            comboBoxHocKi.DisplayMember = "SemesterName";
            comboBoxHocKi.ValueMember = "SemesterId";
        }

        private void ClearSemesters()
        {
            comboBoxHocKi.DataSource = null;
            comboBoxHocKi.Items.Clear();
        }

        private void comboBoxHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // comboBoxHocKi chứa List<SemesterDTO> => SelectedItem là SemesterDTO
            var sem = comboBoxHocKi.SelectedItem as SemesterDTO;
            if (sem == null)
            {
                btnCreat.Enabled = false;
                return;
            }

            btnCreat.Enabled = true;
        }

        // ========================================================
        // 4) NÚT TẠO TKB
        // ========================================================
        private void btnCreat_Click(object sender, EventArgs e)
        {
            var drvYear = comboBoxYear.SelectedItem as DataRowView;
            var sem = comboBoxHocKi.SelectedItem as SemesterDTO;

            if (drvYear == null || sem == null)
            {
                MessageBox.Show("Vui lòng chọn năm học và học kỳ!");
                return;
            }

            int yearId = Convert.ToInt32(drvYear["year_id"]);
            int semesterId = sem.SemesterId;

            try
            {
                timetableBUS.CreateTimetable(yearId, semesterId);
                MessageBox.Show("Tạo thời khoá biểu hoàn tất!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo TKB: " + ex.Message);
            }

            LoadTimetableToGrid(yearId, semesterId);
        }


        // ========================================================
        // 5) LOAD TKB RA DATAGRIDVIEW
        // ========================================================
        private void LoadTimetableToGrid(int yearId, int semesterId)
        {
            DataTable dt = timetableBUS.GetTimetableForSemester(yearId, semesterId);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu TKB!");
                dataGridView1.Rows.Clear();
                return;
            }

            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                object teacherName =
                    dt.Columns.Contains("teacher_name") ? row["teacher_name"] :
                    dt.Columns.Contains("full_name") ? row["full_name"] :
                    DBNull.Value;

                dataGridView1.Rows.Add(
                    row["day"],
                    row["period"],
                    row["class_name"],
                    row["subject_name"],
                    teacherName,
                    row["room"]
                );
            }
        }
    }
}
