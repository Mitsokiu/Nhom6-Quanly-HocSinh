using BUS;
using DTO;
using GUI; // Để gọi form ThemHocSinh
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

        private List<StudentDTO> _fullList = new List<StudentDTO>();
        private List<StudentDTO> _studentList = new List<StudentDTO>();

        private int _currentPage = 1;
        private const int _pageSize = 6;
        private int _totalPages = 1;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh...";

        // Màu icon (nếu muốn vẽ đè, nhưng ở đây dùng ảnh gốc)

        public UC_GVCN_QLHS(int teacherUserId)
        {
            _teacherUserId = teacherUserId;
            InitializeComponent();
            SetupDataGridView();

            this.Load += (s, e) => {
                LoadDataFromDB();
                // Bo tròn thanh tìm kiếm khi load xong
                SetRoundedRegion(pnlSearchBox, 20);
            };
            this.Resize += (s, e) => CenterPagination();

            // Search Box Logic
            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnAddStudent.Click += BtnAddStudent_Click;

            // Vẽ icon & Click
            dgvStudents.CellPainting += DgvStudents_CellPainting;
            dgvStudents.CellContentClick += DgvStudents_CellContentClick;

            // Load icon search từ resource
            if (Properties.Resources.search_32 != null)
                picSearchIcon.Image = Properties.Resources.search_32;

            InitPaginationEvents();
            ShowHomeroomClassName();
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
            }
        }

        private void LoadDataFromDB()
        {
            int classId = _teacherBus.GetCurrentHomeroomClassId(_teacherUserId);
            if (classId > 0)
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

        // --- VẼ ICON ---
        private void DgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvStudents.Columns["Action"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                // Config kích thước vẽ (nhỏ hơn 40px chút để đẹp)
                int iconW = 24;
                int iconH = 24;
                int gap = 15; // Khoảng cách

                // Tính toán vị trí X để căn giữa 3 icon
                int totalW = (iconW * 3) + (gap * 2);
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalW) / 2;
                int startY = e.CellBounds.Y + (e.CellBounds.Height - iconH) / 2;

                // Vẽ 3 icon từ Resource
                if (Properties.Resources.view_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.view_40, startX, startY, iconW, iconH);

                if (Properties.Resources.edit_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.edit_40, startX + iconW + gap, startY, iconW, iconH);

                if (Properties.Resources.delete_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.delete_40, startX + (iconW + gap) * 2, startY, iconW, iconH);
            }
        }

        // --- XỬ LÝ CLICK ---
        private void DgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvStudents.Columns["Action"].Index) return;

            // Lấy ID học sinh từ Tag (đã lưu lúc bind data)
            int studentId = (int)dgvStudents.Rows[e.RowIndex].Tag;
            // Tìm object DTO tương ứng trong list
            var student = _studentList.FirstOrDefault(s => s.StudentID == studentId);
            if (student == null) return;

            // Tính toán lại vị trí click
            var cellRect = dgvStudents.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            int mouseX = dgvStudents.PointToClient(Cursor.Position).X - cellRect.Left;

            int iconW = 24;
            int gap = 15;
            int totalW = iconW * 3 + gap * 2;
            int startX = (cellRect.Width - totalW) / 2;

            // Kiểm tra click vào icon nào
            if (mouseX >= startX && mouseX < startX + iconW) // VIEW
            {
                // Mở form Xem Chi Tiết (dùng chung ThemHocSinh nhưng khóa textbox)
                // ThemHocSinh frm = new ThemHocSinh(_teacherUserId, student, true); // true = ViewMode
                // frm.ShowDialog();
                MessageBox.Show($"Xem chi tiết: {student.FullName}", "Info");
            }
            else if (mouseX >= startX + iconW + gap && mouseX < startX + (iconW + gap) * 2) // EDIT
            {
                // Mở form Sửa
                // ThemHocSinh frm = new ThemHocSinh(_teacherUserId, student, false); // false = EditMode
                // if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB();
                MessageBox.Show($"Sửa: {student.FullName}", "Info");
            }
            else if (mouseX >= startX + (iconW + gap) * 2) // DELETE
            {
                if (MessageBox.Show($"Bạn chắc chắn muốn xóa học sinh {student.FullName}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_studentBus.DeleteStudent(studentId))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadDataFromDB();
                    }
                    else MessageBox.Show("Xóa thất bại!", "Lỗi");
                }
            }
        }

        // --- CÁC HÀM KHÁC ---
        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            using (var frm = new ThemHocSinh(_teacherUserId))
            {
                if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB();
            }
        }

        private void SetupDataGridView()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add("MaHS", "MÃ SỐ");
            dgvStudents.Columns.Add("HoTen", "HỌ VÀ TÊN");
            dgvStudents.Columns.Add("NgaySinh", "NGÀY SINH");
            dgvStudents.Columns.Add("GioiTinh", "GIỚI TÍNH");
            dgvStudents.Columns.Add("DiaChi", "ĐỊA CHỈ");
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "HÀNH ĐỘNG", Width = 150 });

            dgvStudents.Columns["MaHS"].Width = 100;
            dgvStudents.Columns["HoTen"].Width = 200;
            dgvStudents.Columns["NgaySinh"].Width = 120;
            dgvStudents.Columns["GioiTinh"].Width = 100;
            dgvStudents.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            Rectangle bounds = new Rectangle(0, 0, c.Width, c.Height);
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