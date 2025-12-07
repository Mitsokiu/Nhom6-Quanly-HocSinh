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
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            var list = ClassBUS.GetAllClasses();
            foreach (var c in list)
            {
                dataGridView1.Rows.Add(c.Id, c.GradeId, c.ClassName);
            }
        }

        private void Btn_them_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textKhoi.Text, out int gradeId))
            {
                MessageBox.Show("Khối phải là số hợp lệ.");
                return;
            }

            string className = textLop.Text.Trim();

            // kiểm tra tồn tại
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

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            if (!int.TryParse(textKhoi.Text, out int gradeId))
            {
                MessageBox.Show("Khối phải là số hợp lệ.");
                return;
            }

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
            if (e.RowIndex >= 0)
            {
                textMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textKhoi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textLop.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bạn có thể gọi luôn CellClick
            DataGridView1_CellClick(sender, e);
        }

    }
}
