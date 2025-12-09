using BUS;
using DAO;
using DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class UC_Admin_PhanCong_gvcn : UserControl
    {
        private int selectedAssignId = -1;
        private DataTable fullData;
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalPages = 1;
        private AcademicYearBUS yearBUS = new AcademicYearBUS();

        public UC_Admin_PhanCong_gvcn()
        {
            InitializeComponent();

            SetupDataGridView();
            LoadYears();
           

            comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChanged;
            dataGridView1.CellClick += DataGridView1_CellClick;

            btnback.Click += BtnPrev_Click;
            btnnext.Click += BtnNext_Click;

            //btnAdd.Click += BtnAdd_Click;
            //btnUpdate.Click += BtnUpdate_Click;
            //btnDelete.Click += BtnDelete_Click;
        }

        private void LoadYears()
        {
            DataTable dt = yearBUS.GetAllYear();
            if (dt == null) return;

            DataRow dr = dt.NewRow();
            dr["year_id"] = 0;
            dr["name"] = "-- Chọn năm --";
            dt.Rows.InsertAt(dr, 0);

            comboBoxYear.DisplayMember = "name";
            comboBoxYear.ValueMember = "year_id";
            comboBoxYear.DataSource = dt;
        }

        private void ComboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxYear.SelectedValue == null) return;

            int yearId = Convert.ToInt32(comboBoxYear.SelectedValue);

            if (yearId == 0)
            {
                dataGridView1.Rows.Clear();
                fullData = null;
                lbnumpage.Text = "Trang 0/0";
                return;
            }

            LoadDataByYear(yearId);
            LoadCombos();
        }

        private void LoadCombos()
        {
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


            dataGridView1.Columns.Add("assign_id", "assign_id");
            dataGridView1.Columns["assign_id"].Visible = false;

            dataGridView1.Columns.Add("year_id", "year_id");
            dataGridView1.Columns["year_id"].Visible = false;

            dataGridView1.Columns.Add("class_id", "class_id");
            dataGridView1.Columns["class_id"].Visible = false;

            dataGridView1.Columns.Add("teacher_id", "teacher_id");
            dataGridView1.Columns["teacher_id"].Visible = false;


        }

       
        private void LoadDataByYear(int yearId)
        {
            fullData = HomeroomAssignmentBUS.GetAssignmentsByYear(yearId);
            totalPages = (int)Math.Ceiling(fullData.Rows.Count / (double)pageSize);
            currentPage = 1;
            LoadPage();
        }

        private void LoadPage()
        {
            dataGridView1.Rows.Clear();
            if (fullData == null || fullData.Rows.Count == 0)
            {
                lbnumpage.Text = "Trang 0/0";
                return;
            }

            int start = (currentPage - 1) * pageSize;
            var pageRows = fullData.AsEnumerable().Skip(start).Take(pageSize);

            foreach (var row in pageRows)
            {
                dataGridView1.Rows.Add(
                     row["year_name"],
                     row["class_name"],
                     row["teacher_name"],
                     Convert.ToDateTime(row["assigned_date"]).ToString("yyyy-MM-dd"),
                     row["assign_id"],
                     row["year_id"],   // đúng chỗ
                     row["class_id"],  // đúng chỗ
                     row["teacher_id"] // đúng chỗ
                 );

            }

            lbnumpage.Text = $"Trang {currentPage}/{totalPages}";
        }

       
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
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

            try
            {
                HomeroomAssignmentBUS.AddAssignment(dto);
                MessageBox.Show("Thêm phân công thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataByYear(dto.YearId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            try
            {
                HomeroomAssignmentBUS.UpdateAssignment(dto);
                MessageBox.Show("Cập nhật phân công thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataByYear(dto.YearId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Nếu assign_id rỗng thì coi như dòng trống
            bool isEmptyRow =
                row.Cells["assign_id"].Value == null ||
                row.Cells["assign_id"].Value.ToString().Trim() == "";

            if (isEmptyRow)
            {
                // Reset tất cả combobox về rỗng
               
                comboBoxClass.SelectedIndex = -1;
                comboBoxTeacher.SelectedIndex = -1;
                selectedAssignId = -1;
                return;
            }


            try
            {
                selectedAssignId = Convert.ToInt32(row.Cells["assign_id"].Value);

                comboBoxYear.SelectedValue = Convert.ToInt32(row.Cells["year_id"].Value);
                comboBoxClass.SelectedValue = Convert.ToInt32(row.Cells["class_id"].Value);
                comboBoxTeacher.SelectedValue = Convert.ToInt32(row.Cells["teacher_id"].Value);

                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["assigned_date"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }



        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAssignId == -1) return;

            try
            {
                int yearId = Convert.ToInt32(comboBoxYear.SelectedValue);
                HomeroomAssignmentBUS.DeleteAssignment(selectedAssignId);
                MessageBox.Show("Xóa phân công thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataByYear(yearId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    
    private void ExportToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.FileName = "phan_cong_gvcn.xlsx";

            if (saveFile.ShowDialog() != DialogResult.OK) return;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("PhanCong");

                    // Tiêu đề cột
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        if (!dgv.Columns[col].Visible) continue;

                        ws.Cells[1, col + 1].Value = dgv.Columns[col].HeaderText;
                        ws.Cells[1, col + 1].Style.Font.Bold = true;
                        ws.Cells[1, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[1, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        ws.Cells[1, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    // Dữ liệu
                    for (int row = 0; row < dgv.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgv.Columns.Count; col++)
                        {
                            if (!dgv.Columns[col].Visible) continue;

                            ws.Cells[row + 2, col + 1].Value = dgv.Rows[row].Cells[col].Value;
                            ws.Cells[row + 2, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }
                    }

                    ws.Cells.AutoFitColumns();

                    File.WriteAllBytes(saveFile.FileName, package.GetAsByteArray());

                    MessageBox.Show("Xuất Excel thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        private void lbnumpage_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
