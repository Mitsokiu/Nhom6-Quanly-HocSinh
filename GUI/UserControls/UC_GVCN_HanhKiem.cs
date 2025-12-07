using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace GUI.UserControls
{
    public partial class UC_GVCN_HanhKiem : UserControl
    {
        private int teacherId;
        private EvaluationBUS evalBus = new EvaluationBUS();
        private SemesterBUS semBus = new SemesterBUS();

        private List<StudentEvaluationDTO> fullList = new List<StudentEvaluationDTO>();
        private List<StudentEvaluationDTO> displayList = new List<StudentEvaluationDTO>();

        private int currentPage = 1;
        private const int pageSize = 6;
        private int totalPages = 1;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh theo tên hoặc mã số...";

        private const int ICON_W = 24;
        private const int ICON_H = 24;

        public UC_GVCN_HanhKiem(int teacherId)
        {
            InitializeComponent();
            this.teacherId = teacherId;

            SetupDataGridView();

            dgvHanhKiem.CellPainting += DgvHanhKiem_CellPainting;
            dgvHanhKiem.CellMouseClick += DgvHanhKiem_CellMouseClick;
            dgvHanhKiem.CellFormatting += DgvHanhKiem_CellFormatting;

            btnExportExcel.Click += BtnExportExcel_Click;
            btnImportExcel.Click += BtnImportExcel_Click;
            btnExportPDF.Click += BtnExportPDF_Click;

            this.Load += (s, e) => SetRoundedRegion(pnlSearchBox, 20);
            this.Resize += (s, e) => CenterPagination();

            LoadSemesters();
            cbbHocKy.SelectedIndexChanged += (s, e) => LoadDataFromDB();

            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            InitPaginationEvents();
        }

        private void DgvHanhKiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dto = dgvHanhKiem.Rows[e.RowIndex].DataBoundItem as StudentEvaluationDTO;
                if (dto == null) return;

                if (!dto.IsSaved)
                {
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.Font = new System.Drawing.Font(dgvHanhKiem.Font, FontStyle.Italic);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Font = new System.Drawing.Font(dgvHanhKiem.Font, FontStyle.Regular);
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvHanhKiem.Columns.Clear();
            dgvHanhKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvHanhKiem.AutoGenerateColumns = false;
            DataGridViewCellStyle centerStyle = new DataGridViewCellStyle();
            centerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHanhKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentCode",
                HeaderText = "MÃ SỐ",
                Width = 150,
                ReadOnly = true,
                DataPropertyName = "StudentCode"
            });

            dgvHanhKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "HỌ VÀ TÊN",
                Width = 330,
                ReadOnly = true,
                DataPropertyName = "FullName"
            });

            var colConduct = new DataGridViewTextBoxColumn
            {
                Name = "Conduct",
                HeaderText = "HẠNH KIỂM",
                Width = 200,
                ReadOnly = true,
                DataPropertyName = "Conduct"
            };
            dgvHanhKiem.Columns.Add(colConduct);

            var colComment = new DataGridViewTextBoxColumn
            {
                Name = "TeacherComment",
                HeaderText = "NHẬN XÉT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                HeaderCell = { Style = centerStyle },
                DataPropertyName = "TeacherComment"
            };
            dgvHanhKiem.Columns.Add(colComment);

            var colAction = new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "HÀNH ĐỘNG", Width = 200, ReadOnly = true };
            colAction.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHanhKiem.Columns.Add(colAction);

            dgvHanhKiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHanhKiem.MultiSelect = false;
            dgvHanhKiem.RowTemplate.Height = 50;
        }


        private void DgvHanhKiem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHanhKiem.Columns["Action"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                int x = e.CellBounds.X + (e.CellBounds.Width - ICON_W) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - ICON_H) / 2;

                if (Properties.Resources.edit_40 != null)
                {
                    e.Graphics.DrawImage(Properties.Resources.edit_40, x, y, ICON_W, ICON_H);
                }
            }
        }

        private void DgvHanhKiem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHanhKiem.Columns["Action"].Index)
            {
                var dto = dgvHanhKiem.Rows[e.RowIndex].DataBoundItem as StudentEvaluationDTO;

                if (dto != null)
                {
                    int semesterId = (int)cbbHocKy.SelectedValue;


                    using (var frm = new XetHanhKiem(dto, semesterId))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadDataFromDB();
                        }
                    }
                }
            }
        }


        private void LoadSemesters()
        {
            List<SemesterDTO> semesters = semBus.GetAllSemesters();
            cbbHocKy.DataSource = semesters;
            cbbHocKy.DisplayMember = "DisplayName";
            cbbHocKy.ValueMember = "SemesterId";
            if (semesters.Count > 0)
            {
                cbbHocKy.SelectedIndex = 1;
                LoadDataFromDB();
            }
        }

        private void LoadDataFromDB()
        {
            if (cbbHocKy.SelectedValue == null) return;
            int semesterId = (int)cbbHocKy.SelectedValue;

            fullList = evalBus.GetClassList(teacherId, semesterId);
            displayList = new List<StudentEvaluationDTO>(fullList);
            currentPage = 1;
            UpdatePagination();
        }

        private void UpdatePagination()
        {
            totalPages = (int)Math.Ceiling((double)displayList.Count / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            var pageData = displayList.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            dgvHanhKiem.DataSource = new System.ComponentModel.BindingList<StudentEvaluationDTO>(pageData);

            if (dgvHanhKiem.Columns["StudentId"] != null) dgvHanhKiem.Columns["StudentId"].Visible = false;
            if (dgvHanhKiem.Columns["ClassId"] != null) dgvHanhKiem.Columns["ClassId"].Visible = false;

            RenderPaginationButtons();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim().ToLower();
            if (kw == PLACEHOLDER_TEXT.ToLower() || string.IsNullOrWhiteSpace(kw))
            {
                displayList = new List<StudentEvaluationDTO>(fullList);
            }
            else
            {
                displayList = fullList.Where(s =>
                    s.FullName.ToLower().Contains(kw) ||
                    s.StudentCode.ToLower().Contains(kw)).ToList();
            }
            currentPage = 1;
            UpdatePagination();
        }

        private void RenderPaginationButtons()
        {
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnPage1.Visible = btnPage2.Visible = btnPage3.Visible = btnPageLast.Visible = lblDots.Visible = false;

            if (totalPages <= 4)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    Button btn = i == 1 ? btnPage1 : i == 2 ? btnPage2 : i == 3 ? btnPage3 : btnPageLast;
                    SetupBtn(btn, i);
                }
            }
            else
            {
                SetupBtn(btnPage1, 1);
                int mid = currentPage <= 2 ? 2 : (currentPage >= totalPages - 1 ? totalPages - 1 : currentPage);
                SetupBtn(btnPage2, mid);
                if (mid + 1 < totalPages) SetupBtn(btnPage3, mid + 1);
                lblDots.Visible = true;
                SetupBtn(btnPageLast, totalPages);
            }
            HighlightBtn(btnPage1); HighlightBtn(btnPage2); HighlightBtn(btnPage3); HighlightBtn(btnPageLast);
            CenterPagination();
        }

        private void CenterPagination()
        {
            if (pnlPagination.Width == 0) return;
            int totalW = 0, gap = 5, btnW = 35;
            var ctls = new Control[] { btnPrev, btnPage1, btnPage2, btnPage3, lblDots, btnPageLast, btnNext };
            foreach (var c in ctls.Where(c => c.Visible)) totalW += c == lblDots ? 20 : btnW + gap;

            int x = (pnlPagination.Width - totalW) / 2;
            int y = (pnlPagination.Height - 35) / 2;
            foreach (var c in ctls.Where(c => c.Visible))
            {
                c.Location = new Point(x, c == lblDots ? y + 5 : y);
                x += c == lblDots ? 20 + gap : btnW + gap;
            }
        }

        private void SetupBtn(Button b, int p) { b.Visible = true; b.Text = p.ToString(); b.Tag = p; }
        private void HighlightBtn(Button b)
        {
            if (!b.Visible) return;
            bool active = (int)b.Tag == currentPage;
            b.BackColor = active ? Color.FromArgb(13, 110, 253) : Color.White;
            b.ForeColor = active ? Color.White : Color.Black;
        }
        private void InitPaginationEvents()
        {
            EventHandler ck = (s, e) => { currentPage = (int)((Button)s).Tag; UpdatePagination(); };
            btnPage1.Click += ck; btnPage2.Click += ck; btnPage3.Click += ck; btnPageLast.Click += ck;
            btnPrev.Click += (s, e) => { if (currentPage > 1) { currentPage--; UpdatePagination(); } };
            btnNext.Click += (s, e) => { if (currentPage < totalPages) { currentPage++; UpdatePagination(); } };
        }

        private void SetRoundedRegion(Control c, int radius)
        {
            System.Drawing.Rectangle bounds = new System.Drawing.Rectangle(0, 0, c.Width, c.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(0, 0, d, d, 180, 90); path.AddArc(bounds.Width - d, 0, d, d, 270, 90);
                path.AddArc(bounds.Width - d, bounds.Height - d, d, d, 0, 90); path.AddArc(0, bounds.Height - d, d, d, 90, 90);
                c.Region = new Region(path);
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (fullList == null || fullList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Hanhkiem");

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    string hkName = cbbHocKy.Text.Replace(" ", "");
                    sfd.FileName = $"HanhKiem_{hkName}_{DateTime.Now:yyyyMMdd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("HanhKiem");

                            string[] headers = { "STT", "Mã Số", "Họ và Tên", "Hạnh Kiểm", "Nhận Xét" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                var cell = worksheet.Cells[1, i + 1];
                                cell.Value = headers[i];
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            for (int i = 0; i < fullList.Count; i++)
                            {
                                var item = fullList[i];
                                int r = i + 2;

                                worksheet.Cells[r, 1].Value = i + 1;
                                worksheet.Cells[r, 2].Value = item.StudentCode;
                                worksheet.Cells[r, 3].Value = item.FullName;
                                worksheet.Cells[r, 4].Value = item.Conduct;
                                worksheet.Cells[r, 5].Value = item.TeacherComment;
                            }

                            worksheet.Cells.AutoFitColumns();

                            package.SaveAs(new FileInfo(sfd.FileName));
                        }
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImportExcel_Click(object sender, EventArgs e)
        {
            int semesterId = (int)cbbHocKy.SelectedValue;
            if (evalBus.IsEvaluationLocked(semesterId))
            {
                MessageBox.Show("Học kỳ này đã khóa sổ hoặc chưa diễn ra. Không thể nhập dữ liệu!",
                                "Đã khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExcelPackage.License.SetNonCommercialPersonal("Loopy");

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var package = new ExcelPackage(new FileInfo(ofd.FileName)))
                        {
                            var worksheet = package.Workbook.Worksheets[0];
                            int rowCount = worksheet.Dimension.Rows;
                            int successCount = 0;
                            int failCount = 0;

                            for (int row = 2; row <= rowCount; row++)
                            {
                                try
                                {
                                    string code = worksheet.Cells[row, 2].Text.Trim();
                                    string conduct = worksheet.Cells[row, 4].Text.Trim();
                                    string comment = worksheet.Cells[row, 5].Text.Trim();

                                    if (string.IsNullOrEmpty(code)) continue;

                                    var student = fullList.FirstOrDefault(s => s.StudentCode.Equals(code, StringComparison.OrdinalIgnoreCase));

                                    if (student != null)
                                    {

                                        if (string.IsNullOrEmpty(conduct)) conduct = "Tốt";

                                        bool result = evalBus.SaveEvaluation(student.StudentId, student.ClassId, semesterId, conduct, comment);
                                        if (result) successCount++;
                                        else failCount++;
                                    }
                                    else
                                    {
                                        failCount++;
                                    }
                                }
                                catch
                                {
                                    failCount++;
                                }
                            }

                            MessageBox.Show($"Đã nhập xong!\n- Cập nhật thành công: {successCount}\n- Thất bại/Không tìm thấy HS: {failCount}",
                                "Kết quả Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDataFromDB();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file Excel: {ex.Message}\nVui lòng đảm bảo file đúng mẫu (Cột 2 là Mã Số).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (fullList == null || fullList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                string hkName = cbbHocKy.Text.Replace(" ", "");
                sfd.FileName = $"BaoCaoHanhKiem_{hkName}_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25f, 25f, 30f, 30f);
                        PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                        pdfDoc.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                        if (!File.Exists(fontPath)) fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);

                        PdfPTable headerTable = new PdfPTable(2);
                        headerTable.WidthPercentage = 100;
                        headerTable.SetWidths(new float[] { 40f, 60f });

                        Paragraph pLeft = new Paragraph("TRƯỜNG THPT ABC\nĐOÀN TNCS HỒ CHÍ MINH", fontBold);
                        pLeft.Alignment = Element.ALIGN_CENTER;

                        Paragraph pRight = new Paragraph("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM\nĐộc lập - Tự do - Hạnh phúc", fontBold);
                        pRight.Alignment = Element.ALIGN_CENTER;

                        PdfPCell cellLeft = new PdfPCell(pLeft) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };
                        PdfPCell cellRight = new PdfPCell(pRight) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };

                        headerTable.AddCell(cellLeft);
                        headerTable.AddCell(cellRight);
                        pdfDoc.Add(headerTable);
                        pdfDoc.Add(new Paragraph("\n"));

                        Paragraph title = new Paragraph($"BẢNG TỔNG HỢP HẠNH KIỂM - {cbbHocKy.Text.ToUpper()}", fontTitle);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 20f;
                        pdfDoc.Add(title);


                        PdfPTable table = new PdfPTable(5);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 8f, 15f, 30f, 15f, 32f });

                        string[] headers = { "STT", "Mã Số", "Họ và Tên", "Hạnh Kiểm", "Nhận Xét" };
                        foreach (string h in headers)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(h, fontBold));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell.Padding = 5;
                            table.AddCell(cell);
                        }

                        for (int i = 0; i < fullList.Count; i++)
                        {
                            var item = fullList[i];
                            AddCell(table, (i + 1).ToString(), fontNormal, Element.ALIGN_CENTER);
                            AddCell(table, item.StudentCode, fontNormal, Element.ALIGN_CENTER);
                            AddCell(table, item.FullName, fontNormal, Element.ALIGN_LEFT);
                            AddCell(table, item.Conduct, fontNormal, Element.ALIGN_CENTER);
                            AddCell(table, item.TeacherComment, fontNormal, Element.ALIGN_LEFT);
                        }

                        pdfDoc.Add(table);

                        Paragraph footer = new Paragraph($"\nTP.HCM, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}", fontNormal);
                        footer.Alignment = Element.ALIGN_RIGHT;
                        footer.IndentationRight = 20;
                        pdfDoc.Add(footer);

                        Paragraph kyTen = new Paragraph("Giáo viên chủ nhiệm\n\n\n\n", fontBold);
                        kyTen.Alignment = Element.ALIGN_RIGHT;
                        kyTen.IndentationRight = 40;
                        pdfDoc.Add(kyTen);

                        pdfDoc.Close();

                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất PDF: " + ex.Message);
                    }
                }
            }
        }

        private void AddCell(PdfPTable table, string text, iTextSharp.text.Font font, int align)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text ?? "", font));
            cell.HorizontalAlignment = align;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            table.AddCell(cell);
        }
    }
}