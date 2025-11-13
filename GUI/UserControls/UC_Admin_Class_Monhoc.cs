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
    public partial class UC_Admin_Class_Monhoc : UserControl
    {
       
            private SubjectDAO subjectDAO = new SubjectDAO();

            public UC_Admin_Class_Monhoc()
            {
                InitializeComponent();
                LoadSubjects();
                dataGridView1.CellClick += DataGridView1_CellClick;
                button4.Click += BtnAdd_Click;
                button5.Click += BtnEdit_Click;
                button6.Click += BtnDelete_Click;
            }

            private void LoadSubjects()
            {
                dataGridView1.Rows.Clear();
                List<SubjectDTO> subjects = subjectDAO.GetAllSubjects();

                foreach (var s in subjects)
                {
                    dataGridView1.Rows.Add(s.Id, s.Code, s.Name);
                }
            }

            private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    var row = dataGridView1.Rows[e.RowIndex];
                    textBox2.Text = row.Cells["mamon"].Value?.ToString(); // mã môn
                    textBox1.Text = row.Cells["NameMH"].Value?.ToString(); // tên môn
                }
            }

            private void BtnAdd_Click(object sender, EventArgs e)
            {
                SubjectDTO sub = new SubjectDTO
                {
                    Code = textBox2.Text,
                    Name = textBox1.Text
                };

                if (subjectDAO.AddSubject(sub))
                {
                    MessageBox.Show("Thêm môn học thành công!");
                    LoadSubjects();
                }
                else
                    MessageBox.Show("Thêm thất bại!");
            }

            private void BtnEdit_Click(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count > 0 && int.TryParse(dataGridView1.SelectedRows[0].Cells["mamon"].Value.ToString(), out int id))
                {
                    SubjectDTO sub = new SubjectDTO
                    {
                        Id = id,
                        Code = textBox2.Text,
                        Name = textBox1.Text
                    };

                    if (subjectDAO.UpdateSubject(sub))
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadSubjects();
                    }
                    else
                        MessageBox.Show("Cập nhật thất bại!");
                }
            }

            private void BtnDelete_Click(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count > 0 && int.TryParse(dataGridView1.SelectedRows[0].Cells["mamon"].Value.ToString(), out int id))
                {
                    if (subjectDAO.DeleteSubject(id))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadSubjects();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
                }
            }
        
    }
}
