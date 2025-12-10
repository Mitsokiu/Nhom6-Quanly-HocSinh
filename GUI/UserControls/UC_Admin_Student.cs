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
using ClosedXML.Excel;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.UserControls
{

    public partial class UC_Admin_Student : UserControl
    {
        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private ClassBUS classBUS = new ClassBUS();
        private int selectedStudentId = 0;
        DataTable allStudents;
        int pageSize = 20;
        int currentPage = 1;
        int totalPage = 1;


        public UC_Admin_Student()
        {
            InitializeComponent();

            LoadYears();
            LoadAllClasses();



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

            // Load danh sách học sinh theo năm học (tất cả lớp)
            LoadStudentGridByYear(yearId);
        }


        private void LoadStudentGridByYear(int yearId)
        {
            if (yearId == 0) return; // Nếu chọn "-- Chọn năm --"

            // Lấy tất cả học sinh của năm học (tất cả lớp)
            DataTable dt = StudentBUS.GetStudents(yearId, 0);

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

        //private void LoadStudentGridByYear(int yearId)
        //{
        //    if (yearId == 0) return;

        //    allStudents = StudentBUS.GetStudents(yearId, 0);

        //    totalPage = (int)Math.Ceiling(allStudents.Rows.Count / (double)pageSize);
        //    if (totalPage == 0) totalPage = 1;

        //    currentPage = 1;

        //    LoadPage(currentPage);
        //}


        private void LoadPage(int page)
        {
            dataGridView1.AutoGenerateColumns = false;

            int start = (page - 1) * pageSize;

            DataTable pageTable = allStudents.Clone(); // Tạo bảng rỗng cùng schema

            var rows = allStudents.AsEnumerable()
                                  .Skip(start)
                                  .Take(pageSize)
                                  .ToList();

            foreach (var row in rows)
                pageTable.ImportRow(row);

            dataGridView1.DataSource = pageTable;

            lblpage.Text = $"{currentPage}/{totalPage}";
        }




        private void LoadAllClasses()
        {
            try
            {
                var list = ClassBUS.GetAllClasses() ?? new List<ClassDTO>();

                // Tạo DataTable để bind vào ComboBox
                DataTable dt = new DataTable();
                dt.Columns.Add("class_id", typeof(int));
                dt.Columns.Add("class_name", typeof(string));

                // Thêm lựa chọn "Tất cả"
                DataRow dr = dt.NewRow();
                dr["class_id"] = 0;
                dr["class_name"] = "-- Tất cả lớp --";
                dt.Rows.Add(dr);

                // Thêm danh sách lớp
                foreach (var c in list)
                {
                    dt.Rows.Add(c.Id, c.ClassName);
                }

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

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (selectedStudentId <= 0)
            {
                MessageBox.Show("Vui lòng chọn học sinh trước!");
                return;
            }

            StudentBUS studentBUS = new StudentBUS();
            StudentDTO student = studentBUS.GetStudentById(selectedStudentId);

            if (student != null)
            {
                // Mở form sửa
                int teacherUserId = 1; // hoặc lấy từ session/login hiện tại
                using (SuaHocSinh frm = new SuaHocSinh(teacherUserId, student))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Reload danh sách học sinh sau khi sửa
                        LoadStudentGridByYear(int.Parse(cbBoxYear.SelectedValue.ToString()));
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy học sinh.");
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0) return; // chưa chọn dòng
            int classId = cbBoxClass.SelectedValue != null ? Convert.ToInt32(cbBoxClass.SelectedValue) : 0;
            if (classId == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp hợp lệ!");
                return;
            }


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

        private void ExportToExcel(DataGridView dgv)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
            sfd.FileName = "DanhSachHocSinh.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Students");

                int colIndex = 1;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible) continue; // bỏ cột ẩn
                    ws.Cell(1, colIndex).Value = col.HeaderText;
                    ws.Cell(1, colIndex).Style.Font.Bold = true;
                    colIndex++;
                }

                int rowIndex = 2;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    colIndex = 1;

                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (!col.Visible) continue;
                        ws.Cell(rowIndex, colIndex).Value = row.Cells[col.Name].Value?.ToString();
                        colIndex++;
                    }

                    rowIndex++;
                }

                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);
            }

            MessageBox.Show("Xuất Excel thành công");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }


        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPage(currentPage);
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                LoadPage(currentPage);
            }
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPage;
            LoadPage(currentPage);
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