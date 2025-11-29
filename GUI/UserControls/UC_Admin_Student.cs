using BUS;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.UserControls
{
    public partial class UC_Admin_Student : UserControl
    {
        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private ClassBUS classBUS = new ClassBUS();
        private int selectedStudentId = 0;

        public UC_Admin_Student()
        {
            InitializeComponent();
           
            LoadYears();
            
            LoadGrade();

        }

      

        private void LoadGrade()
        {
            var dt = GradeBUS.GetAll();

            cbBoxGrade.DataSource = dt;
            cbBoxGrade.DisplayMember = "grade_name"; // Hiển thị tên khối
            cbBoxGrade.ValueMember = "grade_id";     // Giá trị là ID
        }

        private void LoadYears()
        {
            try
            {
                DataTable dt = yearBUS.GetAllYear();
                if (dt == null) return;

                // Thêm lựa chọn "Tất cả" (value 0)
                DataRow dr = dt.NewRow();
                dr["year_id"] = 0;
                dr["name"] = "-- Chọn năm --";
                dt.Rows.InsertAt(dr, 0);

                cbBoxYear.DisplayMember = "name";
                cbBoxYear.ValueMember = "year_id";
                cbBoxYear.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load năm: " + ex.Message);
            }
        }

        private void cbBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxYear.SelectedValue == null) return;

            int yearId;
            if (!int.TryParse(cbBoxYear.SelectedValue.ToString(), out yearId)) return;

            if (yearId == 0) return; // Nếu chọn "-- Chọn năm --"

            // Load danh sách lớp của năm học vào ComboBox lớp
            LoadClassesByYear(yearId);

            // Load danh sách học sinh theo năm học (tất cả lớp)
            LoadStudentGridByYear(yearId);
        }


        private void LoadStudentGridByYear(int yearId)
        {
            if (yearId == 0) return; // Nếu chọn "-- Chọn năm --"

            // Lấy tất cả học sinh của năm học (tất cả lớp)
            DataTable dt = StudentBUS.GetStudents(yearId,0);

            // Tắt tự động tạo cột
            dataGridView1.AutoGenerateColumns = false;

            // Gán DataPropertyName cho các cột đã thiết kế sẵn
            dataGridView1.Columns["ID"].DataPropertyName = "Id";           // Cột ID
            dataGridView1.Columns["Hoten"].DataPropertyName = "Ten";        // Cột Tên
            dataGridView1.Columns["DOB"].DataPropertyName = "Ngay Sinh";   // Cột Ngày Sinh
            dataGridView1.Columns["Gender"].DataPropertyName = "Gioi Tinh";// Cột Giới Tính
            dataGridView1.Columns["DiaChi"].DataPropertyName = "DiaChi";
            dataGridView1.Columns["Class"].DataPropertyName = "Lop";       // Cột Lớp

            // Gán dữ liệu vào Grid
            dataGridView1.DataSource = dt;

            // Tự động co cột vừa khít
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



       


        private void LoadClassesByYear(int yearId)
        {
            try
            {
                DataTable dt = ClassBUS.GetClassesByYear(yearId) ?? new DataTable();

                // Thêm lựa chọn "Tất cả"
                DataRow dr = dt.NewRow();
                dr["class_id"] = 0;
                dr["class_name"] = "-- Tất cả lớp --";
                dt.Rows.InsertAt(dr, 0);

                cbBoxClass.DisplayMember = "class_name";
                cbBoxClass.ValueMember = "class_id";
                cbBoxClass.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lớp: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào header hoặc ngoài vùng dữ liệu
            if (e.RowIndex < 0) return;

            // Lấy dòng hiện tại
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedStudentId = Convert.ToInt32(row.Cells["ID"].Value);
            // Gán dữ liệu vào TextBox/ComboBox/DateTimePicker



            txtName.Text = row.Cells["Hoten"].Value?.ToString() ?? "";
            txtAddr.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
            if (row.Cells["DOB"].Value != null && row.Cells["DOB"].Value != DBNull.Value)
            {
                dateTimePickerDOB.Value = Convert.ToDateTime(row.Cells["DOB"].Value);
            }
            else
            {
                dateTimePickerDOB.Value = DateTime.Now; // hoặc giá trị mặc định khác
            }


            cbBoxGender.SelectedItem = row.Cells["Gender"].Value?.ToString() ?? "";

            // ComboBox lớp
            string className = row.Cells["Class"].Value?.ToString() ?? "";
            cbBoxClass.SelectedIndex = cbBoxClass.FindStringExact(className);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0) return; // chưa chọn dòng

            StudentDTO student = new StudentDTO
            {
                Id = selectedStudentId,
                Ten = txtName.Text.Trim(),
                DiaChi = txtAddr.Text.Trim(),
                NgaySinh = dateTimePickerDOB.Value,
                GioiTinh = cbBoxGender.SelectedItem?.ToString() ?? "",
                Lop = cbBoxClass.SelectedItem?.ToString() ?? "",
                ClassId = cbBoxClass.SelectedValue != null ? Convert.ToInt32(cbBoxClass.SelectedValue) : 0,
                YearId = cbBoxClass.SelectedValue != null ? Convert.ToInt32(cbBoxYear.SelectedValue) : 0,


            };

            if (StudentBUS.UpdateStudent(student))
            {
                MessageBox.Show("Cập nhật thành công!");
                int yearId;
                if (int.TryParse(cbBoxYear.SelectedValue?.ToString(), out yearId))
                    LoadStudentGridByYear(yearId);
            }
        }



        private void LoadStudentGrid()
        {
           
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
