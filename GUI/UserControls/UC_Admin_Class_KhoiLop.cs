using BUS;
using DAO;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_KhoiLop : UserControl
    {
        public UC_Admin_Class_KhoiLop()
        {
            InitializeComponent();
            LoadData();
            btn_them.Click += Btn_them_Click;
            btn_sua.Click += Btn_sua_Click;
            btn_xoa.Click += Btn_xoa_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            LoadGrade();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("grade_id", "Grade ID");
            dataGridView1.Columns["grade_id"].Visible = false; // ẩn cột

            var list = ClassBUS.GetAllClasses();
            foreach (var c in list)
            {
                dataGridView1.Rows.Add(c.Id, c.GradeName, c.ClassName,c.GradeId);
            }
        }

        private void LoadGrade()
        {
            var dt = GradeBUS.GetAll();

            cbBoxGrade.DataSource = dt;
            cbBoxGrade.DisplayMember = "grade_name"; // Hiển thị tên khối
            cbBoxGrade.ValueMember = "grade_id";     // Giá trị là ID
        }

        private void Btn_them_Click(object sender, EventArgs e)
        {
            if (cbBoxGrade.SelectedValue == null)
            {
                MessageBox.Show("Chọn khối.");
                return;
            }

            int gradeId = Convert.ToInt32(cbBoxGrade.SelectedValue);
            string className = textLop.Text.Trim();

            if (ClassDAO.ExistsClass(className, gradeId))
            {
                MessageBox.Show("Lớp này đã tồn tại!");
                return;
            }

            var c = new ClassDTO
            {
                ClassName = className,
                GradeId = gradeId
            };

            ClassDAO.AddClass(c);
            LoadData();
            MessageBox.Show("Thêm thành công!");
        }


        private void Btn_sua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Chọn lớp để sửa.");
                return;
            }

            if (cbBoxGrade.SelectedValue == null)
            {
                MessageBox.Show("Chọn khối.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            int gradeId = Convert.ToInt32(cbBoxGrade.SelectedValue);

            var c = new ClassDTO
            {
                Id = id,
                ClassName = textLop.Text.Trim(),
                GradeId = gradeId
            };

            ClassBUS.UpdateClass(c);
            LoadData();
            MessageBox.Show("Sửa thành công!");
        }


        private void Btn_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Chọn lớp để xóa.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ClassBUS.DeleteClass(id);
            LoadData();
            MessageBox.Show("Xóa thành công!");
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = dataGridView1.Rows[e.RowIndex];

            // Lấy an toàn từng ô, nếu null → trả ""
            string id = row.Cells[0].Value?.ToString() ?? "";
            string gradeValue = row.Cells[1].Value?.ToString() ?? "";
            string className = row.Cells[2].Value?.ToString() ?? "";

            textMa.Text = id;
            textLop.Text = className;

            // Xử lý combobox grade an toàn
            if (string.IsNullOrEmpty(gradeValue) || !int.TryParse(gradeValue, out int gradeId))
            {
                cbBoxGrade.SelectedIndex = -1; // Không chọn gì
            }
            else
            {
                cbBoxGrade.SelectedValue = gradeId;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bạn có thể gọi luôn CellClick
            DataGridView1_CellClick(sender, e);
        }

    }
}
