using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_KhoiLop : UserControl
    {
        private ClassBUS classBUS = new ClassBUS();

        public UC_Admin_Class_KhoiLop()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            List<ClassDTO> list = classBUS.GetAllClasses();

            foreach (var c in list)
            {
                dataGridView1.Rows.Add(c.Id, c.Khoi, c.Lop, c.GVCN);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClassDTO c = new ClassDTO()
            {
                Id = textBox4.Text,
                Khoi = textBox1.Text,
                Lop = textBox3.Text,
                GVCN = textBox2.Text
            };
            if (classBUS.AddClass(c))
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ClassDTO c = new ClassDTO()
            {
                Id = textBox4.Text,
                Khoi = textBox1.Text,
                Lop = textBox3.Text,
                GVCN = textBox2.Text
            };
            if (classBUS.UpdateClass(c))
            {
                MessageBox.Show("Sửa thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            if (classBUS.DeleteClass(id))
            {
                MessageBox.Show("Xóa thành công!");
                LoadData();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox4.Text = row.Cells["ID"].Value.ToString();
            textBox1.Text = row.Cells["Khoi"].Value.ToString();
            textBox3.Text = row.Cells["Lop"].Value.ToString();
            textBox2.Text = row.Cells["GVCN"].Value.ToString();
        }
    }
}
