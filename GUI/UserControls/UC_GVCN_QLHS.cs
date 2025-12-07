using BUS;
using DTO;
using GUI;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVCN_QLHS : UserControl
    {
        private readonly int _teacherUserId;
        private readonly StudentBUS _studentBus = new StudentBUS();
        private readonly TeacherBUS _teacherBus = new TeacherBUS();

        private List<StudentDTO> _fullList = new List<StudentDTO>();
        private List<StudentDTO> _studentList = new List<StudentDTO>();

        private int _currentPage = 1;
        private const int _pageSize = 6;
        private int _totalPages = 1;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh...";

        // CẤU HÌNH ICON
        private const int ICON_W = 24;
        private const int ICON_H = 24;
        private const int ICON_GAP = 20;

        public UC_GVCN_QLHS(int teacherUserId)
        {
            _teacherUserId = teacherUserId;
            InitializeComponent();

            SetupDataGridView();

            this.Load += (s, e) => {
                LoadDataFromDB();
                SetRoundedRegion(pnlSearchBox, 20);
            };
            this.Resize += (s, e) => CenterPagination();

            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnAddStudent.Click += BtnAddStudent_Click;
            btnImportExcel.Click += BtnImportExcel_Click;
            btnExportExcel.Click += BtnExportExcel_Click;
            btnExportPDF.Click += BtnExportPDF_Click;

            dgvStudents.CellPainting += DgvStudents_CellPainting;
            dgvStudents.CellMouseClick += DgvStudents_CellMouseClick;

            if (Properties.Resources.search_32 != null)
                picSearchIcon.Image = Properties.Resources.search_32;

            InitPaginationEvents();
            ShowHomeroomClassName();
            btnAddStudent.Visible = false;

        }

        // --- 1. CHỨC NĂNG XUẤT EXCEL (CẬP NHẬT ĐẦY ĐỦ THÔNG TIN CHA/MẸ/GH) ---
        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Loopy");
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.FileName = $"DanhSachHocSinh_{DateTime.Now:yyyyMMdd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("HocSinh");

                            // Header: Thêm cột Nghề nghiệp Cha và Mẹ
                            string[] headers = {
                                "STT", "Họ và Tên", "Ngày sinh", "Giới tính", "Địa chỉ",
                                "Họ tên Cha", "SĐT Cha", "Nghề nghiệp Cha",
                                "Họ tên Mẹ", "SĐT Mẹ", "Nghề nghiệp Mẹ",
                                "Họ tên GH", "SĐT GH", "Nghề GH", "Quan hệ"
                            };

                            for (int i = 0; i < headers.Length; i++)
                            {
                                worksheet.Cells[1, i + 1].Value = headers[i];
                                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                                worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                                worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            for (int i = 0; i < _studentList.Count; i++)
                            {
                                var s = _studentList[i];
                                int r = i + 2;
                                worksheet.Cells[r, 1].Value = i + 1;
                                worksheet.Cells[r, 2].Value = s.FullName;
                                worksheet.Cells[r, 3].Value = s.DateOfBirth.ToString("dd/MM/yyyy");
                                worksheet.Cells[r, 4].Value = s.GenderDisplay;
                                worksheet.Cells[r, 5].Value = s.Address;

                                // Cha
                                worksheet.Cells[r, 6].Value = s.FatherName;
                                worksheet.Cells[r, 7].Value = s.FatherPhone;
                                worksheet.Cells[r, 8].Value = s.FatherJob; // Mới

                                // Mẹ
                                worksheet.Cells[r, 9].Value = s.MotherName;
                                worksheet.Cells[r, 10].Value = s.MotherPhone;
                                worksheet.Cells[r, 11].Value = s.MotherJob; // Mới

                                // Giám hộ (Dời sang cột 12-15)
                                worksheet.Cells[r, 12].Value = s.GuardianName;
                                worksheet.Cells[r, 13].Value = s.GuardianPhone;
                                worksheet.Cells[r, 14].Value = s.GuardianJob;
                                worksheet.Cells[r, 15].Value = s.GuardianRelation;
                            }
                            worksheet.Cells.AutoFitColumns();
                            package.SaveAs(new FileInfo(sfd.FileName));
                        }
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- 2. CHỨC NĂNG NHẬP EXCEL (CẬP NHẬT ĐỌC ĐẦY ĐỦ CỘT) ---
        private void BtnImportExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Loopy");

            int classId = _teacherBus.GetCurrentHomeroomClassId(_teacherUserId);
            if (classId <= 0)
            {
                MessageBox.Show("Bạn chưa được phân công chủ nhiệm lớp nào để thêm học sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int yearId = 0;
            var dtYear = _teacherBus.GetCurrentAcademicYear();
            if (dtYear != null && dtYear.Rows.Count > 0)
                yearId = Convert.ToInt32(dtYear.Rows[0]["year_id"]);

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
                                    string fullName = worksheet.Cells[row, 2].Text.Trim();
                                    if (string.IsNullOrEmpty(fullName)) continue;

                                    string dobStr = worksheet.Cells[row, 3].Text.Trim();
                                    DateTime dob;
                                    if (!DateTime.TryParseExact(dobStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob))
                                    {
                                        var val = worksheet.Cells[row, 3].Value;
                                        if (val is double d) dob = DateTime.FromOADate(d);
                                        else dob = DateTime.Now;
                                    }

                                    string genderStr = worksheet.Cells[row, 4].Text.Trim();
                                    string genderDB = (genderStr.Equals("Nam", StringComparison.OrdinalIgnoreCase)) ? "Male" : "Female";
                                    string address = worksheet.Cells[row, 5].Text.Trim();

                                    StudentDTO student = new StudentDTO
                                    {
                                        FullName = fullName,
                                        DateOfBirth = dob,
                                        Gender = genderDB,
                                        Address = address,
                                        ClassID = classId,
                                        YearID = yearId,
                                        Avatar = "avatar_macdinh.png",

                                        // Cha (Cột 6, 7, 8)
                                        FatherName = worksheet.Cells[row, 6].Text.Trim(),
                                        FatherPhone = worksheet.Cells[row, 7].Text.Trim(),
                                        FatherJob = worksheet.Cells[row, 8].Text.Trim(),

                                        // Mẹ (Cột 9, 10, 11)
                                        MotherName = worksheet.Cells[row, 9].Text.Trim(),
                                        MotherPhone = worksheet.Cells[row, 10].Text.Trim(),
                                        MotherJob = worksheet.Cells[row, 11].Text.Trim(),

                                        // Giám hộ (Cột 12, 13, 14, 15)
                                        GuardianName = worksheet.Cells[row, 12].Text.Trim(),
                                        GuardianPhone = worksheet.Cells[row, 13].Text.Trim(),
                                        GuardianJob = worksheet.Cells[row, 14].Text.Trim(),
                                        GuardianRelation = worksheet.Cells[row, 15].Text.Trim()
                                    };

                                    string error;
                                    if (_studentBus.AddStudent(student, out error))
                                    {
                                        successCount++;
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

                            MessageBox.Show($"Đã nhập xong!\n- Thành công: {successCount}\n- Thất bại: {failCount}",
                                "Kết quả Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDataFromDB();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file Excel: {ex.Message}\nHãy đảm bảo file nhập đúng mẫu (Xuất file ra để xem mẫu).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 3. CHỨC NĂNG XUẤT PDF (GIỮ NGUYÊN NHƯ BẠN YÊU CẦU TRƯỚC ĐÓ) ---
        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (_studentList == null || _studentList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên lớp
            string className = "..........";
            var dtClass = _teacherBus.GetHomeroomClass(_teacherUserId);
            if (dtClass != null && dtClass.Rows.Count > 0)
            {
                className = dtClass.Rows[0]["class_name"].ToString().ToUpper();
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"DanhSachHocSinh_Lop{className}_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // KHỔ DỌC (PageSize.A4)
                        Document pdfDoc = new Document(PageSize.A4, 25f, 25f, 30f, 30f);
                        PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                        pdfDoc.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                        if (!File.Exists(fontPath)) fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);

                        // HEADER
                        PdfPTable headerTable = new PdfPTable(2);
                        headerTable.WidthPercentage = 100;
                        headerTable.SetWidths(new float[] { 50f, 50f });
                        headerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        Paragraph pLeft = new Paragraph("SỞ GD&ĐT THÀNH PHỐ HỒ CHÍ MINH\nTRƯỜNG THPT ABC", fontBold);
                        pLeft.Alignment = Element.ALIGN_CENTER;
                        headerTable.AddCell(new PdfPCell(pLeft) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

                        Paragraph pRight = new Paragraph("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM\nĐộc lập - Tự do - Hạnh phúc\n-----------------", fontBold);
                        pRight.Alignment = Element.ALIGN_CENTER;
                        headerTable.AddCell(new PdfPCell(pRight) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

                        pdfDoc.Add(headerTable);
                        pdfDoc.Add(new Paragraph("\n"));

                        // TIÊU ĐỀ
                        Paragraph title = new Paragraph($"DANH SÁCH HỌC SINH LỚP {className}", fontTitle);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 15f;
                        pdfDoc.Add(title);

                        // BẢNG DỮ LIỆU
                        PdfPTable table = new PdfPTable(5);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 8f, 35f, 15f, 12f, 30f }); // STT, Tên, NS, GT, Ghi chú

                        string[] headers = { "STT", "Họ và tên", "Ngày sinh", "Giới tính", "Ghi chú" };
                        foreach (string h in headers)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(h, fontBold));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell.Padding = 6;
                            table.AddCell(cell);
                        }

                        int stt = 1;
                        foreach (var s in _studentList)
                        {
                            AddCell(table, stt.ToString(), fontNormal, Element.ALIGN_CENTER);
                            AddCell(table, s.FullName, fontNormal, Element.ALIGN_LEFT);
                            AddCell(table, s.DobDisplay, fontNormal, Element.ALIGN_CENTER);
                            AddCell(table, s.GenderDisplay, fontNormal, Element.ALIGN_CENTER);
                            AddCell(table, "", fontNormal, Element.ALIGN_CENTER);
                            stt++;
                        }

                        pdfDoc.Add(table);

                        // FOOTER
                        Paragraph footer = new Paragraph($"\nTP.HCM, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}", fontNormal);
                        footer.Alignment = Element.ALIGN_RIGHT;
                        footer.IndentationRight = 20;
                        pdfDoc.Add(footer);

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

        private void ShowHomeroomClassName()
        {
            var dt = _teacherBus.GetHomeroomClass(_teacherUserId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string className = dt.Rows[0]["class_name"].ToString();
                lblTitle.Text = $"Quản lý Học sinh - Lớp {className}";
            }
            else
            {
                lblTitle.Text = "Chưa được phân công chủ nhiệm";
                lblSubTitle.Text = "Vui lòng liên hệ Admin.";
                btnAddStudent.Enabled = false;
                btnImportExcel.Enabled = false;
            }
        }

        private void LoadDataFromDB()
        {
            int classId = _teacherBus.GetCurrentHomeroomClassId(_teacherUserId);
            if (classId > 0)
            {
                var all = _studentBus.GetAllStudentss();
                _fullList = all.Where(s => s.ClassID == classId).ToList();
                _studentList = new List<StudentDTO>(_fullList);
            }
            _currentPage = 1;
            UpdatePagination();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (kw == PLACEHOLDER_TEXT || string.IsNullOrWhiteSpace(kw))
            {
                _studentList = new List<StudentDTO>(_fullList);
            }
            else
            {
                string lower = kw.ToLower();
                _studentList = _fullList.Where(s =>
                    s.FullName.ToLower().Contains(lower) || s.StudentCode.ToLower().Contains(lower)
                ).ToList();
            }
            _currentPage = 1;
            UpdatePagination();
        }

        private void SetupDataGridView()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add("STT", "STT");
            dgvStudents.Columns.Add("HoTen", "HỌ VÀ TÊN");
            dgvStudents.Columns.Add("NgaySinh", "NGÀY SINH");
            dgvStudents.Columns.Add("GioiTinh", "GIỚI TÍNH");
            dgvStudents.Columns.Add("DiaChi", "ĐỊA CHỈ");

            var actionCol = new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "HÀNH ĐỘNG", Width = 160 };
            dgvStudents.Columns.Add(actionCol);
            dgvStudents.Columns["Action"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvStudents.Columns["STT"].Width = 100;
            dgvStudents.Columns["HoTen"].Width = 200;
            dgvStudents.Columns["NgaySinh"].Width = 120;
            dgvStudents.Columns["GioiTinh"].Width = 100;
            dgvStudents.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStudents.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.ReadOnly = true;
        }

        private void DgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvStudents.Columns["Action"].Index)
            {
                e.Handled = true;
                bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
                Color backColor = isSelected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor;

                using (Brush backBrush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                }
                using (Pen gridPen = new Pen(dgvStudents.GridColor))
                {
                    e.Graphics.DrawLine(gridPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                int totalWidth = (ICON_W * 3) + (ICON_GAP * 2);
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
                int startY = e.CellBounds.Y + (e.CellBounds.Height - ICON_H) / 2;

                if (Properties.Resources.view_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.view_40, startX, startY, ICON_W, ICON_H);

            //    if (Properties.Resources.edit_40 != null)
            //        e.Graphics.DrawImage(Properties.Resources.edit_40, startX + ICON_W + ICON_GAP, startY, ICON_W, ICON_H);

            //    if (Properties.Resources.delete_40 != null)
            //        e.Graphics.DrawImage(Properties.Resources.delete_40, startX + (ICON_W + ICON_GAP) * 2, startY, ICON_W, ICON_H);
            }
        }

        private void DgvStudents_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvStudents.Columns["Action"].Index) return;

            var studentIdObj = dgvStudents.Rows[e.RowIndex].Tag;
            if (studentIdObj == null) return;
            int studentId = (int)studentIdObj;

            var student = _studentList.FirstOrDefault(s => s.StudentID == studentId);
            if (student == null) return;

            int clickX = e.X;
            int cellWidth = dgvStudents.Columns[e.ColumnIndex].Width;
            int totalWidth = (ICON_W * 3) + (ICON_GAP * 2);
            int startX = (cellWidth - totalWidth) / 2;

            if (clickX >= startX && clickX <= startX + ICON_W)
            {
                using (var frm = new ChiTietHocSinh(_teacherUserId, student)) { frm.ShowDialog(); }
            }
            //else if (clickX >= startX + ICON_W + ICON_GAP && clickX <= startX + ICON_W + ICON_GAP + ICON_W)
            //{
            //    using (var frm = new SuaHocSinh(_teacherUserId, student)) { if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB(); }
            //}
            //else if (clickX >= startX + (ICON_W + ICON_GAP) * 2 && clickX <= startX + (ICON_W + ICON_GAP) * 2 + ICON_W)
            //{
            //    if (MessageBox.Show($"Bạn có chắc chắn muốn xóa học sinh: {student.FullName}?",
            //        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        if (_studentBus.DeleteStudent(studentId))
            //        {
            //            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            LoadDataFromDB();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Xóa thất bại! Dữ liệu đang được sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //   }
           // }
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            using (var frm = new ThemHocSinh(_teacherUserId))
            {
                if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB();
            }
        }

        private void UpdatePagination()
        {
            _totalPages = (int)Math.Ceiling((double)_studentList.Count / _pageSize);
            if (_totalPages == 0) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            dgvStudents.Rows.Clear();
            var pageData = _studentList.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            int startStt = (_currentPage - 1) * _pageSize + 1;

            for (int i = 0; i < pageData.Count; i++)
            {
                var s = pageData[i];
                int currentStt = startStt + i;

                int idx = dgvStudents.Rows.Add(
                    currentStt.ToString(),
                    s.FullName,
                    s.DobDisplay,
                    s.GenderDisplay,
                    s.Address
                );
                dgvStudents.Rows[idx].Tag = s.StudentID;
            }
            RenderPaginationButtons();
        }

        private void RenderPaginationButtons()
        {
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
            btnPage1.Visible = btnPage2.Visible = btnPage3.Visible = btnPageLast.Visible = lblDots.Visible = false;

            if (_totalPages <= 4)
            {
                for (int i = 1; i <= _totalPages; i++)
                {
                    Button btn = i == 1 ? btnPage1 : i == 2 ? btnPage2 : i == 3 ? btnPage3 : btnPageLast;
                    SetupBtn(btn, i);
                }
            }
            else
            {
                SetupBtn(btnPage1, 1);
                int mid = _currentPage <= 2 ? 2 : (_currentPage >= _totalPages - 1 ? _totalPages - 1 : _currentPage);
                SetupBtn(btnPage2, mid);
                if (mid + 1 < _totalPages) SetupBtn(btnPage3, mid + 1);
                lblDots.Visible = true;
                SetupBtn(btnPageLast, _totalPages);
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
            bool active = (int)b.Tag == _currentPage;
            b.BackColor = active ? Color.FromArgb(13, 110, 253) : Color.White;
            b.ForeColor = active ? Color.White : Color.Black;
        }
        private void InitPaginationEvents()
        {
            EventHandler ck = (s, e) => { _currentPage = (int)((Button)s).Tag; UpdatePagination(); };
            btnPage1.Click += ck; btnPage2.Click += ck; btnPage3.Click += ck; btnPageLast.Click += ck;
            btnPrev.Click += (s, e) => { if (_currentPage > 1) { _currentPage--; UpdatePagination(); } };
            btnNext.Click += (s, e) => { if (_currentPage < _totalPages) { _currentPage++; UpdatePagination(); } };
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
    }
}