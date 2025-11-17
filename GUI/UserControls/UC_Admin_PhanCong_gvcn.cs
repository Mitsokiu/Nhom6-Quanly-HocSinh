using System;
using System.Data;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;

namespace GUI
{
    public partial class UC_Admin_PhanCong_gvcn : UserControl
    {
        private int selectedAssignId = -1;

        public UC_Admin_PhanCong_gvcn()
        {
            InitializeComponent();
            LoadCombos();
            SetupDataGridView();
            LoadData();

            dataGridView1.CellClick += DataGridView1_CellClick;
            btnadd.Click += BtnAdd_Click;
            btnsua.Click += BtnUpdate_Click;
            btnxoa.Click += BtnDelete_Click;
        }

        private void LoadCombos()
        {
            comboBoxYear.DataSource = DbConnect.ExecuteQuery("SELECT year_id, name FROM academic_years ORDER BY name");
            comboBoxYear.DisplayMember = "name";
            comboBoxYear.ValueMember = "year_id";

            comboBoxClass.DataSource = DbConnect.ExecuteQuery("SELECT class_id, class_name FROM classes");
            comboBoxClass.DisplayMember = "class_name";
            comboBoxClass.ValueMember = "class_id";

            comboBoxTeacher.DataSource = DbConnect.ExecuteQuery("SELECT user_id, fullname FROM users WHERE role_id='gvcn'");
            comboBoxTeacher.DisplayMember = "fullname";
            comboBoxTeacher.ValueMember = "user_id";

            dateTimePicker1.Value = DateTime.Today;
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("year_name", "Năm");
            dataGridView1.Columns.Add("class_name", "Lớp");
            dataGridView1.Columns.Add("teacher_name", "GVCN");
            dataGridView1.Columns.Add("assigned_date", "Ngày Tạo");

            // Columns ẩn để lưu ID
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn { Name = "assign_id", Visible = false };
            dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn { Name = "year_id", Visible = false };
            dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn { Name = "class_id", Visible = false };
            dataGridView1.Columns.Add(col);

            col = new DataGridViewTextBoxColumn { Name = "teacher_id", Visible = false };
            dataGridView1.Columns.Add(col);
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = HomeroomAssignmentBUS.GetAllAssignments();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
            row["year_name"],
            row["class_name"],
            row["teacher_name"],
            row["assigned_date"],
            row["assign_id"],      // ẩn để lưu ID
            row["class_id"],       // ẩn
            row["teacher_id"],     // ẩn
            row["year_id"]
            );
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedAssignId = Convert.ToInt32(row.Cells["assign_id"].Value);
            comboBoxYear.SelectedValue = Convert.ToInt32(row.Cells["year_id"].Value);
            comboBoxClass.SelectedValue = Convert.ToInt32(row.Cells["class_id"].Value);
            comboBoxTeacher.SelectedValue = Convert.ToInt32(row.Cells["teacher_id"].Value);
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["assigned_date"].Value);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            HomeroomAssignmentDTO dto = new HomeroomAssignmentDTO
            {
                ClassId = Convert.ToInt32(comboBoxClass.SelectedValue),
                TeacherId = Convert.ToInt32(comboBoxTeacher.SelectedValue),
                YearId = Convert.ToInt32(comboBoxYear.SelectedValue),
                AssignedDate = dateTimePicker1.Value
            };
            if (HomeroomAssignmentBUS.AddAssignment(dto)) LoadData();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAssignId == -1) return;
            HomeroomAssignmentDTO dto = new HomeroomAssignmentDTO
            {
                AssignId = selectedAssignId,
                ClassId = Convert.ToInt32(comboBoxClass.SelectedValue),
                TeacherId = Convert.ToInt32(comboBoxTeacher.SelectedValue),
                YearId = Convert.ToInt32(comboBoxYear.SelectedValue),
                AssignedDate = dateTimePicker1.Value
            };
            if (HomeroomAssignmentBUS.UpdateAssignment(dto)) LoadData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAssignId == -1) return;
            if (HomeroomAssignmentBUS.DeleteAssignment(selectedAssignId)) LoadData();
        }
    }
}
