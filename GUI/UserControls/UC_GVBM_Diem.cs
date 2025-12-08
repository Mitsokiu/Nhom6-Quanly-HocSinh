using BUS;
using DAO;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.UserControls
{
    public partial class UC_GVBM_Diem : UserControl
    {
        private ScoreBUS scoreBUS = new ScoreBUS();

        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();
        private int currentAssignId = 1; // hoặc giá trị mặc định bạn muốn




        public UC_GVBM_Diem()
        {
            InitializeComponent();
            LoadScoresToGrid(1); // Load điểm cho AssignmentID = 1

          
            LoadYears();
            LoadCombos();

            cbBoxnamhoc.SelectedIndexChanged += CbBoxnamhoc_SelectedIndexChanged;
           
        }

        private void LoadCombos()
        {
            comboBoxlop.DataSource = DbConnect.ExecuteQuery("SELECT class_id, class_name FROM classes");
            comboBoxlop.DisplayMember = "class_name";
            comboBoxlop.ValueMember = "class_id";

           
        }


        //===========================
        // 1. Load danh sách năm học
        //===========================
        private void LoadYears()
        {
            DataTable dt = yearBUS.GetAllYear();
            if (dt == null) return;

            DataRow dr = dt.NewRow();
            dr["year_id"] = 0;
            dr["name"] = "-- Chọn năm --";
            dt.Rows.InsertAt(dr, 0);

            cbBoxnamhoc.DisplayMember = "name";
            cbBoxnamhoc.ValueMember = "year_id";
            cbBoxnamhoc.DataSource = dt;
            cbBoxnamhoc.SelectedValue = 1;
            LoadSemestersByYear(1);

        }

        //==================================================
        // 2. Khi chọn năm → load học kỳ của năm đó
        //==================================================
        private void CbBoxnamhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxnamhoc.SelectedValue == null) return;

            int yearId = Convert.ToInt32(cbBoxnamhoc.SelectedValue);

            if (yearId == 0)
            {
                LoadSemestersEmpty();
                dataGridView1.Rows.Clear();
                return;
            }

            LoadSemestersByYear(yearId);
        }

        private void LoadSemestersByYear(int yearId)
        {
            var list = semesterBUS.GetSemestersByYearId(yearId);

            

            comboBoxhk.DataSource = list;
            comboBoxhk.DisplayMember = "SemesterName";
            comboBoxhk.ValueMember = "SemesterId";

            
        }

        private void LoadSemestersEmpty()
        {
            comboBoxhk.DataSource = null;
            comboBoxhk.Items.Clear();
            comboBoxhk.SelectedValue = 1;
        }

        private void LoadScoresToGrid(int assignId)
        {
            List<ScoreDTO> scores = scoreBUS.GetScoresByAssignment(assignId);

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Cột ẩn score_id tổng hợp (để tham chiếu nếu muốn)
            DataGridViewColumn colScoreId = new DataGridViewTextBoxColumn();
            colScoreId.Name = "ScoreID";
            colScoreId.Visible = false;
            dataGridView1.Columns.Add(colScoreId);

            // Các cột hiển thị
            dataGridView1.Columns.Add("StudentID", "Student ID");
            dataGridView1.Columns.Add("StudentName", "Học Sinh");
            dataGridView1.Columns.Add("ClassName", "Lớp");

            string[] scoreTypes = { "oral", "quiz15", "quiz45", "midterm", "final" ,"ave"};
            foreach (var type in scoreTypes)
                dataGridView1.Columns.Add(type, type.ToUpper());

            // Nhóm theo học sinh
            var students = scores.GroupBy(s => new { s.StudentId, s.StudentName, s.ClassName });

            foreach (var student in students)
            {
                int rowIndex = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowIndex];

                row.Cells["StudentID"].Value = student.Key.StudentId;
                row.Cells["StudentName"].Value = student.Key.StudentName;
                row.Cells["ClassName"].Value = student.Key.ClassName;

                foreach (var score in student)
                {
                    if (!string.IsNullOrEmpty(score.ScoreType))
                    {
                        row.Cells[score.ScoreType].Value = score.ScoreValue?.ToString("0.0");

                        // Lưu score_id đầu tiên (hoặc bạn có thể tạo 1 cột ẩn riêng cho mỗi loại điểm)
                        if (row.Cells["ScoreID"].Value == null && score.ScoreId.HasValue)
                            row.Cells["ScoreID"].Value = score.ScoreId.Value;
                    }
                }
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

            
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


            // Chọn item trong ComboBox dựa trên tên lớp
            string className = row.Cells["ClassName"].Value?.ToString() ?? "";
            for (int i = 0; i < comboBoxlop.Items.Count; i++)
            {
                var item = comboBoxlop.Items[i];
                var prop = item.GetType().GetProperty("class_name"); // nếu là object có property class_name
                if (prop != null && prop.GetValue(item)?.ToString() == className)
                {
                    comboBoxlop.SelectedIndex = i;
                    break;
                }
            }
            txtStudentID.Text = row.Cells["StudentID"].Value?.ToString() ?? "";
            txtOral.Text = row.Cells["oral"].Value?.ToString() ?? "";
            txtQuiz15.Text = row.Cells["quiz15"].Value?.ToString() ?? "";
            txt45.Text = row.Cells["quiz45"].Value?.ToString() ?? "";
            txtMid.Text = row.Cells["midterm"].Value?.ToString() ?? "";
            txtFinal.Text = row.Cells["final"].Value?.ToString() ?? "";
            txtave.Text = row.Cells["ave"].Value?.ToString() ?? "";

        }

        private void UpdateScoresFromTextBoxes()
        {
            if (string.IsNullOrEmpty(txtStudentID.Text) || comboBoxlop.SelectedValue == null)
                return;

            int studentId = Convert.ToInt32(txtStudentID.Text);
            int assignId = currentAssignId; // hoặc lấy giá trị gán từ ComboBox/Học kỳ nếu cần

            var scoreValues = new Dictionary<string, float?>()
    {
        { "oral", ParseNullableFloat(txtOral.Text) },
        { "quiz15", ParseNullableFloat(txtQuiz15.Text) },
        { "quiz45", ParseNullableFloat(txt45.Text) },
        { "midterm", ParseNullableFloat(txtMid.Text) },
        { "final", ParseNullableFloat(txtFinal.Text) },
         { "ave", ParseNullableFloat(txtave.Text) }
    };

            foreach (var kvp in scoreValues)
            {
                if (kvp.Value.HasValue)
                {
                    scoreBUS.UpdateScore(studentId, assignId, kvp.Key, kvp.Value.Value);
                }
            }

            // Cập nhật lại DataGridView
            LoadScoresToGrid(assignId);
        }

        // Hàm phụ để chuyển đổi string sang float? (nullable)
        private float? ParseNullableFloat(string text)
        {
            if (float.TryParse(text, out float result))
                return result;
            return null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateScoresFromTextBoxes(); // Cập nhật dữ liệu

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại dữ liệu cho bảng
                LoadScoresToGrid(currentAssignId);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Loopy");

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"BangDiem_{DateTime.Now:yyyyMMdd}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        var ws = package.Workbook.Worksheets.Add("BangDiem");

                        // Thêm header
                        for (int c = 0; c < dataGridView1.Columns.Count; c++)
                        {
                            ws.Cells[1, c + 1].Value = dataGridView1.Columns[c].HeaderText;
                            ws.Cells[1, c + 1].Style.Font.Bold = true;
                            ws.Cells[1, c + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[1, c + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        }

                        // Thêm dữ liệu
                        for (int r = 0; r < dataGridView1.Rows.Count; r++)
                        {
                            for (int c = 0; c < dataGridView1.Columns.Count; c++)
                            {
                                ws.Cells[r + 2, c + 1].Value = dataGridView1.Rows[r].Cells[c].Value;
                            }
                        }

                        ws.Cells.AutoFitColumns();
                        package.SaveAs(new FileInfo(sfd.FileName));
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"BangDiem_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                        Paragraph title = new Paragraph("BẢNG ĐIỂM", new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD));
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 15f;
                        doc.Add(title);

                        PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                        table.WidthPercentage = 100;

                        // Header
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fontHeader));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            table.AddCell(cell);
                        }

                        // Dữ liệu
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", fontNormal));
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(pdfCell);
                            }
                        }

                        doc.Add(table);
                        doc.Close();

                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var fileInfo = new FileInfo(ofd.FileName);
                    using (var package = new OfficeOpenXml.ExcelPackage(fileInfo))
                    {
                        var ws = package.Workbook.Worksheets[0]; // lấy sheet đầu tiên
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        int colCount = ws.Dimension.End.Column;
                        int rowCount = ws.Dimension.End.Row;

                        // Tạo header
                        for (int c = 1; c <= colCount; c++)
                        {
                            dataGridView1.Columns.Add("col" + c, ws.Cells[1, c].Text);
                        }

                        // Thêm dữ liệu
                        for (int r = 2; r <= rowCount; r++)
                        {
                            int rowIndex = dataGridView1.Rows.Add();
                            for (int c = 1; c <= colCount; c++)
                            {
                                dataGridView1.Rows[rowIndex].Cells[c - 1].Value = ws.Cells[r, c].Text;
                            }
                        }
                    }

                    MessageBox.Show("Import Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi import Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void txtQuiz15_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void UC_GVBM_Diem_Load(object sender, EventArgs e)
        {

        }
    }
}
