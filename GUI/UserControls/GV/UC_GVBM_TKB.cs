using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVBM_TKB : UserControl
    {
        private int selectedAssignId = -1;
        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();


        public UC_GVBM_TKB()
        {
            InitializeComponent();
            LoadYears();
           
            LoadTimetableForTeacher(Session.UserId, 1); // Load lịch trống ban đầu
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            



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

            
            comboBoxhk.DataSource = list;
            comboBoxhk.DisplayMember = "SemesterName";
            comboBoxhk.ValueMember = "SemesterId";
           
            // Chọn học kỳ mặc định đầu tiên
            if (comboBoxhk.Items.Count > 0)
                comboBoxhk.SelectedIndex = 0;

           
            
        }


        private void LoadSemestersEmpty()
        {
            comboBoxhk.DataSource = null;
            comboBoxhk.Items.Clear();
        }

        private void ComboBoxhk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxhk.SelectedValue == null) return;

            if (!int.TryParse(comboBoxhk.SelectedValue.ToString(), out int semesterId))
                return;

            // Lấy teacherId từ user đang đăng nhập
            int teacherId = Session.TeacherId;
            if (teacherId <= 0) return;
             MessageBox.Show("click");
            LoadTimetableForTeacher(teacherId, semesterId);

        }
       

        private void ComboBoxhk_SelectedValueChanged(object sender, EventArgs e)
                {
                    if (comboBoxhk.SelectedValue == null) return;
                    if (!int.TryParse(comboBoxhk.SelectedValue.ToString(), out int semesterId)) return;

                    int teacherId = Session.TeacherId;
                    if (teacherId <= 0) return;

                    LoadTimetableForTeacher(teacherId, semesterId);
                     MessageBox.Show("click");

        }


        private void LoadTimetableForTeacher(int teacherId, int semesterId)
        {
            dataGridView1.Rows.Clear();

            TimetableBUS timetableBUS = new TimetableBUS();
            DataTable dt = timetableBUS.GetTimetableByTeacherAndSemester(teacherId, semesterId);
            MessageBox.Show($"TeacherId = {Session.UserId}");


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
        }


    }
}

