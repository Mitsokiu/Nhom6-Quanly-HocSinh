using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_KhoiLop : UserControl
    {
        private int pageSize = 10;          // số dòng mỗi trang
        private int currentPage = 1;        // trang hiện tại
        private int totalPage = 1;
        List<ClassDTO> allClasses;   // tổng số trang

        public UC_Admin_Class_KhoiLop()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadGrade();
            LoadData();

            btn_them.Click += Btn_them_Click;
            btn_sua.Click += Btn_sua_Click;
            btn_xoa.Click += Btn_xoa_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        // Chỉ thêm cột một lần
        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("class_id", "ID");
            dataGridView1.Columns.Add("grade_name", "Khối");
            dataGridView1.Columns.Add("class_name", "Lớp");
            dataGridView1.Columns.Add("grade_id", "Grade ID");
            dataGridView1.Columns["grade_id"].Visible = false;
        }

        //private void LoadData()
        //{
        //    dataGridView1.Rows.Clear();
        //    var list = ClassBUS.GetAllClasses();
        //    foreach (var c in list)
        //    {
        //        // Thứ tự: ID lớp, tên khối, tên lớp, ID khối (ẩn)
        //        dataGridView1.Rows.Add(c.Id, c.GradeName, c.ClassName, c.GradeId);
        //    }
        //    ResetForm();
        //}

        private void LoadData()
        {
            allClasses = ClassBUS.GetAllClasses();

            totalPage = (int)Math.Ceiling(allClasses.Count / (double)pageSize);
            if (totalPage == 0) totalPage = 1;

            currentPage = 1;

            LoadPage(currentPage);
            ResetForm();
        }

        private void LoadPage(int page)
        {
            dataGridView1.Rows.Clear();

            int start = (page - 1) * pageSize;

            var pageData = allClasses
                .Skip(start)
                .Take(pageSize)
                .ToList();

            foreach (var c in pageData)
            {
                dataGridView1.Rows.Add(
                    c.Id,
                    c.GradeName,
                    c.ClassName,
                    c.GradeId
                );
            }

            lblpage.Text = $"{currentPage}/{totalPage}";
        }

        private void LoadGrade()
        {
            var dt = GradeBUS.GetAll();
            cbBoxGrade.DataSource = dt;
            cbBoxGrade.DisplayMember = "grade_name";
            cbBoxGrade.ValueMember = "grade_id";
            cbBoxGrade.SelectedIndex = -1; // mặc định không chọn gì
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

            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("Nhập tên lớp.");
                return;
            }

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

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["class_id"].Value);
            int gradeId = Convert.ToInt32(cbBoxGrade.SelectedValue);
            string className = textLop.Text.Trim();

            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("Nhập tên lớp.");
                return;
            }

            var c = new ClassDTO
            {
                Id = id,
                ClassName = className,
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

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["class_id"].Value);
            ClassBUS.DeleteClass(id);
            LoadData();
            MessageBox.Show("Xóa thành công!");
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            textMa.Text = row.Cells["class_id"].Value?.ToString() ?? "";
            textLop.Text = row.Cells["class_name"].Value?.ToString() ?? "";

            // Gán ID khối cho ComboBox
            string gradeIdValue = row.Cells["grade_id"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(gradeIdValue) && int.TryParse(gradeIdValue, out int gradeId))
            {
                cbBoxGrade.SelectedValue = gradeId;
            }
            else
            {
                cbBoxGrade.SelectedIndex = -1;
            }
        }

        private void ResetForm()
        {
            textMa.Clear();
            textLop.Clear();
            cbBoxGrade.SelectedIndex = -1;
        }
    }
}
