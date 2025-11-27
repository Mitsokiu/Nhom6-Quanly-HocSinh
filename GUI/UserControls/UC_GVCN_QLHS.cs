// File: GUI/UserControls/UC_GVCN_QLHS.cs
using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVCN_QLHS : UserControl
    {
        private readonly int _teacherUserId;
        private readonly StudentBUS _studentBus = new StudentBUS();
        private readonly TeacherBUS _teacherBus = new TeacherBUS();

        private List<StudentDTO> _fullList = new List<StudentDTO>();    // Danh sách gốc của lớp
        private List<StudentDTO> _studentList = new List<StudentDTO>(); // Danh sách đang hiển thị (sau tìm kiếm)

        private int _currentPage = 1;
        private const int _pageSize = 6;
        private int _totalPages = 1;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh...";

        public UC_GVCN_QLHS(int teacherUserId)
        {
            _teacherUserId = teacherUserId;
            InitializeComponent();
            SetupDataGridView();

            this.Load += (s, e) => LoadDataFromDB();
            this.Resize += (s, e) => CenterPagination();

            // Search box
            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnAddStudent.Click += BtnAddStudent_Click;
            dgvStudents.CellPainting += DgvStudents_CellPainting;
            dgvStudents.CellContentClick += DgvStudents_CellContentClick;

            InitPaginationEvents();
            ShowHomeroomClassName();
        }

        private void ShowHomeroomClassName()
        {
            var dt = _teacherBus.GetHomeroomClass(_teacherUserId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string className = dt.Rows[0]["class_name"].ToString();
                lblTitle.Text = $"Lớp chủ nhiệm: {className}";
                lblSubTitle.Text = "Quản lý học sinh trong lớp bạn đang chủ nhiệm";
            }
            else
            {
                lblTitle.Text = "Chưa được phân công lớp chủ nhiệm";
                lblSubTitle.Text = "Vui lòng liên hệ quản trị viên để được phân công lớp.";
            }
        }

        private void LoadDataFromDB()
        {
            int classId = _teacherBus.GetCurrentHomeroomClassId(_teacherUserId);

            if (classId <= 0)
            {
                _fullList = new List<StudentDTO>();
                _studentList = new List<StudentDTO>();
                MessageBox.Show("Bạn chưa được phân công chủ nhiệm lớp nào trong năm học này!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var all = _studentBus.GetAllStudents();
                _fullList = all.Where(s => s.ClassID == classId).ToList();
                _studentList = new List<StudentDTO>(_fullList);
            }

            _currentPage = 1;
            UpdatePagination();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword) || keyword == PLACEHOLDER_TEXT)
            {
                _studentList = new List<StudentDTO>(_fullList);
            }
            else
            {
                string lower = keyword.ToLower();
                _studentList = _fullList.Where(s =>
                    (s.FullName?.ToLower().Contains(lower) == true) ||
                    (s.StudentCode?.ToLower().Contains(lower) == true)
                ).ToList();
            }

            _currentPage = 1;
            UpdatePagination();
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            using (var frm = new ThemHocSinh(_teacherUserId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataFromDB();
                }
            }
        }

        private void DgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvStudents.Columns["Action"].Index) return;

            int studentId = (int)dgvStudents.Rows[e.RowIndex].Tag;
            string studentName = dgvStudents.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();

            var cellRect = dgvStudents.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            int mouseX = dgvStudents.PointToClient(Cursor.Position).X - cellRect.Left;

            int iconSize = 20;
            int gap = 10;
            int totalWidth = iconSize * 3 + gap * 2;
            int startX = (cellRect.Width - totalWidth) / 2;

            if (mouseX >= startX && mouseX < startX + iconSize)
            {
                MessageBox.Show($"Xem chi tiết học sinh:\n{studentName}", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (mouseX >= startX + iconSize + gap && mouseX < startX + (iconSize + gap) * 2)
            {
                MessageBox.Show($"Chức năng sửa học sinh đang phát triển...", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (mouseX >= startX + (iconSize + gap) * 2)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa học sinh:\n{studentName}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_studentBus.DeleteStudent(studentId))
                    {
                        MessageBox.Show("Xóa học sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Học sinh có thể đang được sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdatePagination()
        {
            _totalPages = (int)Math.Ceiling((double)_studentList.Count / _pageSize);
            if (_totalPages == 0) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            dgvStudents.Rows.Clear();

            var pageData = _studentList.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();
            foreach (var s in pageData)
            {
                int idx = dgvStudents.Rows.Add(s.StudentCode, s.FullName, s.DobDisplay, s.GenderDisplay, s.Address);
                dgvStudents.Rows[idx].Tag = s.StudentID;
            }

            RenderPaginationButtons();
        }

        private void SetupDataGridView()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add("MaHS", "MÃ SỐ");
            dgvStudents.Columns.Add("HoTen", "HỌ VÀ TÊN");
            dgvStudents.Columns.Add("NgaySinh", "NGÀY SINH");
            dgvStudents.Columns.Add("GioiTinh", "GIỚI TÍNH");
            dgvStudents.Columns.Add("DiaChi", "ĐỊA CHỈ");
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "", Width = 120 });

            dgvStudents.Columns["MaHS"].Width = 100;
            dgvStudents.Columns["HoTen"].Width = 200;
            dgvStudents.Columns["NgaySinh"].Width = 120;
            dgvStudents.Columns["GioiTinh"].Width = 100;
            dgvStudents.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvStudents.Columns["Action"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                int iconSize = 20;
                int gap = 10;
                int startX = e.CellBounds.X + (e.CellBounds.Width - (iconSize * 3 + gap * 2)) / 2;
                int startY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                DrawIcon(e.Graphics, "View", Color.FromArgb(13, 110, 253), startX, startY, iconSize);
                DrawIcon(e.Graphics, "Edit", Color.FromArgb(255, 193, 7), startX + iconSize + gap, startY, iconSize);
                DrawIcon(e.Graphics, "Delete", Color.FromArgb(220, 53, 69), startX + (iconSize + gap) * 2, startY, iconSize);
            }
        }

        private void DrawIcon(Graphics g, string text, Color color, int x, int y, int size)
        {
            using (var brush = new SolidBrush(color))
            using (var font = new Font("Segoe UI Emoji", 12, FontStyle.Regular))
            {
                g.DrawString(text, font, brush, x, y - 2);
            }
        }

        // ==================== PHÂN TRANG (giữ nguyên đẹp như cũ) ====================
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

            HighlightBtn(btnPage1); HighlightBtn(btnPage2);
            HighlightBtn(btnPage3); HighlightBtn(btnPageLast);
            CenterPagination();
        }

        private void SetupBtn(Button b, int page)
        {
            b.Visible = true;
            b.Text = page.ToString();
            b.Tag = page;
        }

        private void HighlightBtn(Button b)
        {
            if (!b.Visible || b.Tag == null) return;
            bool active = (int)b.Tag == _currentPage;
            b.BackColor = active ? Color.FromArgb(13, 110, 253) : Color.White;
            b.ForeColor = active ? Color.White : Color.Black;
        }

        private void CenterPagination()
        {
            if (pnlPagination.Width == 0) return;

            int totalW = 0;
            int gap = 5;
            int btnW = 35;

            var controls = new Control[] { btnPrev, btnPage1, btnPage2, btnPage3, lblDots, btnPageLast, btnNext };
            foreach (var c in controls.Where(c => c.Visible))
                totalW += c == lblDots ? 20 : btnW + gap;

            int x = (pnlPagination.Width - totalW) / 2;
            int y = (pnlPagination.Height - 35) / 2;

            foreach (var c in controls.Where(c => c.Visible))
            {
                c.Location = new Point(x, c == lblDots ? y + 5 : y);
                x += c == lblDots ? 20 + gap : btnW + gap;
            }
        }

        private void InitPaginationEvents()
        {
            EventHandler click = (s, e) => { _currentPage = (int)((Button)s).Tag; UpdatePagination(); };
            btnPage1.Click += click; btnPage2.Click += click; btnPage3.Click += click; btnPageLast.Click += click;

            btnPrev.Click += (s, e) => { if (_currentPage > 1) { _currentPage--; UpdatePagination(); } };
            btnNext.Click += (s, e) => { if (_currentPage < _totalPages) { _currentPage++; UpdatePagination(); } };
        }
    }
}