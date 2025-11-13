using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_KhoiLop : UserControl
    {
        public UC_Admin_Class_KhoiLop()
        {
            InitializeComponent();
            LoadGrades();
        }

        private GradeDAO gradeDAO = new GradeDAO();

        private void LoadGrades()
        {
            dataGridView1.Rows.Clear();
            List<GradeDTO> grades = gradeDAO.GetAllGrades();

            foreach (var grade in grades)
            {
                dataGridView1.Rows.Add(
                    grade.Id,
                    grade.Level,
                    grade.Name,
                    grade.gvcn
                );
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // tránh header
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán dữ liệu lên TextBox
                textBox4.Text = row.Cells["ID"].Value?.ToString();
                textBox1.Text = row.Cells["Khoi"].Value?.ToString();
                textBox2.Text = row.Cells["Lop"].Value?.ToString();
                textBox3.Text = row.Cells["GVCN"].Value?.ToString();
            }
        }

        //private void btnadd_Click(object sender, EventArgs e) // nút Thêm
        //{
        //    GradeDTO grade = new GradeDTO
        //    {   Id=textBox4.Text==""?0:Convert.ToInt32( textBox4.Text),
        //        Level = textBox1.Text,
        //        Name = textBox2.Text,
        //        gvcn = textBox3.Text
        //    };

        //    if (gradeDAO.AddGrade(grade)) // cần viết AddGrade trong DAO
        //    {
        //        MessageBox.Show("Thêm lớp thành công!");
        //        LoadGrades();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Thêm lớp thất bại!");
        //    }
        //}




        //private void btnsua_Click(object sender, EventArgs e) // nút Sửa
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
        //        GradeDTO grade = new GradeDTO
        //        {
        //            Id = id,
        //            Level = textBox1.Text,
        //            Name = textBox2.Text,
        //            gvcn = textBox3.Text
        //        };

        //        if (gradeDAO.UpdateGrade(grade)) // cần viết UpdateGrade trong DAO
        //        {
        //            MessageBox.Show("Cập nhật thành công!");
        //            LoadGrades();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Cập nhật thất bại!");
        //        }
        //    }
        //}

        //private void btnxoa_Click(object sender, EventArgs e) // nút Xóa
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

        //        if (gradeDAO.DeleteGrade(id)) // cần viết DeleteGrade trong DAO
        //        {
        //            MessageBox.Show("Xóa thành công!");
        //            LoadGrades();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa thất bại!");
        //        }
        //    }
        //}


        private void btnadd_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(textBox4.Text) && !int.TryParse(textBox4.Text, out id))
            {
                MessageBox.Show("Mã lớp không hợp lệ!");
                return;
            }

            GradeDTO grade = new GradeDTO
            {
                Id = id,
                Level = textBox1.Text,
                Name = textBox2.Text,
                gvcn = textBox3.Text
            };

            if (gradeDAO.AddGrade(grade))
            {
                MessageBox.Show("Thêm lớp thành công!");
                LoadGrades();
            }
            else
            {
                MessageBox.Show("Thêm lớp thất bại!");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            if (!int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value?.ToString(), out int id))
            {
                MessageBox.Show("Mã lớp không hợp lệ!");
                return;
            }

            GradeDTO grade = new GradeDTO
            {
                Id = id,
                Level = textBox1.Text,
                Name = textBox2.Text,
                gvcn = textBox3.Text
            };

            if (gradeDAO.UpdateGrade(grade))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadGrades();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            if (!int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value?.ToString(), out int id))
            {
                MessageBox.Show("Mã lớp không hợp lệ!");
                return;
            }

            if (gradeDAO.DeleteGrade(id))
            {
                MessageBox.Show("Xóa thành công!");
                LoadGrades();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
