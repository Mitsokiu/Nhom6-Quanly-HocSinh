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

        public UC_Admin_Class_Phancong()
        {
            InitializeComponent();
            LoadCombos();
            SetupDataGridView();
            LoadData();

            dataGridView1.CellClick += dataGridView1_CellClick;
            btnadd.Click += BtnAdd_Click;
            btnsua.Click += BtnUpdate_Click;
            btnxoa.Click += BtnDelete_Click;
        }

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

            comboBoxhk.DataSource = DbConnect.ExecuteQuery("SELECT semester_id, name FROM semesters ORDER BY start_date");
            comboBoxhk.DisplayMember = "name";
            comboBoxhk.ValueMember = "semester_id";

            comboBoxtiet.Items.Clear();
            for (int i = 1; i <= 10; i++) comboBoxtiet.Items.Add(i);
            comboBoxtiet.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("class_name", "Lớp");
            dataGridView1.Columns.Add("subject", "Môn");
            dataGridView1.Columns.Add("teacher", "Giáo viên");
            dataGridView1.Columns.Add("semester", "Học Kì");
            dataGridView1.Columns.Add("periods", "Tiết");

            // Cột ẩn lưu ID
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

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = TeacherAssignmentBUS.GetAllAssignments();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            comboBoxlop.SelectedValue = Convert.ToInt32(row.Cells["class_id"].Value);
            comboBoxmon.SelectedValue = Convert.ToInt32(row.Cells["subject_id"].Value);
            comboBoxgv.SelectedValue = Convert.ToInt32(row.Cells["teacher_id"].Value);
            comboBoxhk.SelectedValue = Convert.ToInt32(row.Cells["semester_id"].Value);
            comboBoxtiet.SelectedItem = row.Cells["periods"].Value;
            selectedAssignId = Convert.ToInt32(row.Cells["assign_id"].Value);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TeacherAssignmentDTO dto = new TeacherAssignmentDTO
            {
                TeacherId = Convert.ToInt32(comboBoxgv.SelectedValue),
                SubjectId = Convert.ToInt32(comboBoxmon.SelectedValue),
                ClassId = Convert.ToInt32(comboBoxlop.SelectedValue),
                SemesterId = Convert.ToInt32(comboBoxhk.SelectedValue),
                Periods = Convert.ToInt32(comboBoxtiet.SelectedItem)
            };
            if (TeacherAssignmentBUS.AddAssignment(dto)) LoadData();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAssignId == -1) return;
            TeacherAssignmentDTO dto = new TeacherAssignmentDTO
            {
                AssignId = selectedAssignId,
                TeacherId = Convert.ToInt32(comboBoxgv.SelectedValue),
                SubjectId = Convert.ToInt32(comboBoxmon.SelectedValue),
                ClassId = Convert.ToInt32(comboBoxlop.SelectedValue),
                SemesterId = Convert.ToInt32(comboBoxhk.SelectedValue),
                Periods = Convert.ToInt32(comboBoxtiet.SelectedItem)
            };
            if (TeacherAssignmentBUS.UpdateAssignment(dto)) LoadData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAssignId == -1) return;
            if (TeacherAssignmentBUS.DeleteAssignment(selectedAssignId)) LoadData();
        }
    }
}
