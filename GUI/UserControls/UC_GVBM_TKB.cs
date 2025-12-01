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

        private readonly string[] DayColumns = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public UC_GVBM_TKB()
        {
            InitializeComponent();
            bus = new GVBM_TKB_BUS();
            semesterBUS = new SemesterBUS();

            InitGrid();         // Tạo lưới 10 tiết, 6 cột
            LoadSemesterCombo();
        }

        private void InitGrid()
        {
            dataGridView1.Columns.Clear();

            // TẮT autosize để tất cả dòng có height như nhau
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // === Tạo các cột như cũ ===
            var colTiet = new DataGridViewTextBoxColumn();
            colTiet.HeaderText = "Tiết";
            colTiet.Name = "Tiet";
            colTiet.ReadOnly = true;
            colTiet.FillWeight = 8;
            dataGridView1.Columns.Add(colTiet);

            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            foreach (string d in days)
            {
                var col = new DataGridViewTextBoxColumn();
                col.HeaderText = d;
                col.Name = d;
                col.ReadOnly = true;
                col.FillWeight = 15;
                dataGridView1.Columns.Add(col);
            }

            // === Tạo dòng ===
            dataGridView1.Rows.Clear();
            for (int i = 1; i <= 10; i++)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["Tiet"].Value = i;
            }

            // Căn giữa chữ
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 🔥 Quan trọng: đặt chiều cao dòng cố định để tất cả bằng nhau
            int rowHeight = dataGridView1.ClientSize.Height / 11;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = rowHeight;
            }

            // AutoFill cho cột
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                cbSemester.DisplayMember = "DisplayName";
                cbSemester.ValueMember = "SemesterId";
                cbSemester.SelectedIndex = 0;

                LoadSelectedSemesterTimetable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ: " + ex.Message);
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

                if (cbSemester.SelectedValue == null
                    || !int.TryParse(cbSemester.SelectedValue.ToString(), out int semesterID))
                    return;

                int teacherID = user.UserId;

                InitGrid(); // reset lưới trước khi đổ mới

                List<GVBM_TKB_DTO> list = bus.GetTimetableByTeacher(teacherID, semesterID);

                foreach (var tkb in list)
                {
                    string day = tkb.Day;
                    int period = tkb.Period; // 1 → 10
                    string info = $"Lớp: {tkb.ClassName}\nPhòng: {tkb.Room}";

                    if (period >= 1 && period <= dataGridView1.Rows.Count)
                    {
                        if (dataGridView1.Columns.Contains(day))
                        {
                            dataGridView1.Rows[period - 1].Cells[day].Value = info;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thời khóa biểu: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
