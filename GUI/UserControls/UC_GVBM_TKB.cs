using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_GVBM_TKB : UserControl
    {
        private GVBM_TKB_BUS bus;
        private SemesterBUS semesterBUS;

        public UC_GVBM_TKB()
        {
            InitializeComponent();
            bus = new GVBM_TKB_BUS();
            semesterBUS = new SemesterBUS();

            LoadSemesterCombo();
        }

        private void LoadSemesterCombo()
        {
            try
            {
                List<SemesterDTO> semesters = semesterBUS.GetAllSemesters();
                if (semesters.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu học kỳ!");
                    return;
                }

                cbSemester.DataSource = semesters;
                cbSemester.DisplayMember = "DisplayName";  // Hiển thị: Học kỳ 1 - Năm học 2024-2025
                cbSemester.ValueMember = "SemesterId";
                cbSemester.SelectedIndex = 0; // Mặc định chọn học kỳ đầu

                // Load TKB cho học kỳ đầu tiên
                LoadSelectedSemesterTimetable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ: " + ex.Message, "Lỗi");
            }
        }

        private void cbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedSemesterTimetable();
        }

        private void LoadSelectedSemesterTimetable()
        {
            try
            {
                var user = currentuser.CurrentUser;
                if (user == null)
                {
                    MessageBox.Show("Chưa đăng nhập hoặc currentuser null!");
                    return;
                }

                if (cbSemester.SelectedValue == null || !int.TryParse(cbSemester.SelectedValue.ToString(), out int semesterID))
                {
                    return;
                }

                int teacherID = user.UserId;
                dataGridView1.Rows.Clear();

                List<GVBM_TKB_DTO> list = bus.GetTimetableByTeacher(teacherID, semesterID);

                if (list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thời khóa biểu cho giáo viên này.", "Thông báo");
                    return;
                }

                foreach (var tkb in list)
                {
                    dataGridView1.Rows.Add(tkb.Day, tkb.Period, tkb.ClassName, tkb.Room);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thời khóa biểu: " + ex.Message, "Lỗi");
            }
        }
    }
}
