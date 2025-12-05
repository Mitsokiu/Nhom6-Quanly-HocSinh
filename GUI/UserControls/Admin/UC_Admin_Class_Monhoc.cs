using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_Monhoc : UserControl
    {
        private SubjectBUS bus = new SubjectBUS();

        public UC_Admin_Class_Monhoc()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dataGridView1.Rows.Clear();
            var list = bus.GetAll();

            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item.SubjectId, item.SubjectName);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMamon.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textTenmon.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SubjectDTO s = new SubjectDTO
            {
                SubjectId = txtMamon.Text,
                SubjectName = textTenmon.Text
            };

            if (bus.Add(s))
            {
                MessageBox.Show("Thêm môn học thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Kiểm tra dữ liệu nhập.");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SubjectDTO s = new SubjectDTO
            {
                SubjectId = txtMamon.Text,
                SubjectName = textTenmon.Text
            };

            if (bus.Update(s))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMamon.Text;

            if (bus.Delete(id))
            {
                MessageBox.Show("Xóa thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }
    }
}
