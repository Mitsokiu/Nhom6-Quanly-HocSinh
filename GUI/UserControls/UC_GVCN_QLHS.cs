using BUS;
using DTO;
using GUI;
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

        // CẤU HÌNH ICON
        private const int ICON_W = 24;
        private const int ICON_H = 24;
        private const int ICON_GAP = 20; // Khoảng cách rộng hơn cho dễ bấm

        public UC_GVCN_QLHS(int teacherUserId)
        {
            _teacherUserId = teacherUserId;
            InitializeComponent();

            // 1. Cấu hình bảng
            SetupDataGridView();

            this.Load += (s, e) => {
                LoadDataFromDB();
                SetRoundedRegion(pnlSearchBox, 20);
            };
            this.Resize += (s, e) => CenterPagination();

            // Search Logic
            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnAddStudent.Click += BtnAddStudent_Click;

            // 2. Gán sự kiện vẽ và click cho Grid
            dgvStudents.CellPainting += DgvStudents_CellPainting;
            dgvStudents.CellMouseClick += DgvStudents_CellMouseClick;

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

        // =========================================================
        // PHẦN QUAN TRỌNG: VẼ ICON VÀ XỬ LÝ CLICK
        // =========================================================

        // 1. Cấu hình bảng (FullRowSelect, Fixed Column Width)
        private void SetupDataGridView()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add("MaHS", "MÃ SỐ");
            dgvStudents.Columns.Add("HoTen", "HỌ VÀ TÊN");
            dgvStudents.Columns.Add("NgaySinh", "NGÀY SINH");
            dgvStudents.Columns.Add("GioiTinh", "GIỚI TÍNH");
            dgvStudents.Columns.Add("DiaChi", "ĐỊA CHỈ");

            // Cột Action cố định 160px, không AutoSize
            var actionCol = new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "HÀNH ĐỘNG", Width = 160 };
            dgvStudents.Columns.Add(actionCol);

            // Căn giữa tiêu đề cột Action
            dgvStudents.Columns["Action"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvStudents.Columns["MaHS"].Width = 100;
            dgvStudents.Columns["HoTen"].Width = 200;
            dgvStudents.Columns["NgaySinh"].Width = 120;
            dgvStudents.Columns["GioiTinh"].Width = 100;
            dgvStudents.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStudents.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // QUAN TRỌNG

            // Chọn cả dòng
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.ReadOnly = true;
        }

        // 2. Vẽ Icon (Fix lỗi mất icon khi click)
        private void DgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvStudents.Columns["Action"].Index)
            {
                e.Handled = true; // Ngăn Grid vẽ mặc định

                // Xác định màu nền: Nếu đang chọn -> Màu Xanh nhạt, Không -> Trắng
                bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
                Color backColor = isSelected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor;

                // Vẽ nền
                using (Brush backBrush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                }

                // Vẽ đường kẻ dưới (để bảng liền mạch)
                using (Pen gridPen = new Pen(dgvStudents.GridColor))
                {
                    e.Graphics.DrawLine(gridPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                // Tính toán vị trí Dynamic (để luôn căn giữa ô)
                int totalWidth = (ICON_W * 3) + (ICON_GAP * 2);
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
                int startY = e.CellBounds.Y + (e.CellBounds.Height - ICON_H) / 2;

                // Vẽ 3 icon
                if (Properties.Resources.view_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.view_40, startX, startY, ICON_W, ICON_H);

                if (Properties.Resources.edit_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.edit_40, startX + ICON_W + ICON_GAP, startY, ICON_W, ICON_H);

                if (Properties.Resources.delete_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.delete_40, startX + (ICON_W + ICON_GAP) * 2, startY, ICON_W, ICON_H);
            }
        }

        // 3. Xử lý Click (Logic tọa độ khớp 100% với hàm Vẽ)
        private void DgvStudents_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvStudents.Columns["Action"].Index) return;

            var studentIdObj = dgvStudents.Rows[e.RowIndex].Tag;
            if (studentIdObj == null) return;
            int studentId = (int)studentIdObj;

            var student = _studentList.FirstOrDefault(s => s.StudentID == studentId);
            if (student == null) return;

            // Tính toán vị trí click
            int clickX = e.X; // Tọa độ X trong ô
            int cellWidth = dgvStudents.Columns[e.ColumnIndex].Width;

            int totalWidth = (ICON_W * 3) + (ICON_GAP * 2);
            int startX = (cellWidth - totalWidth) / 2;

            // Logic Check Click
            if (clickX >= startX && clickX <= startX + ICON_W) // VIEW
            {
                using (var frm = new ChiTietHocSinh(_teacherUserId, student))
                {
                    frm.ShowDialog();
                }
            }
            else if (clickX >= startX + ICON_W + ICON_GAP && clickX <= startX + ICON_W + ICON_GAP + ICON_W) // EDIT
            {
                using (var frm = new SuaHocSinh(_teacherUserId, student))
                {
                    if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB();
                }
            }
            else if (clickX >= startX + (ICON_W + ICON_GAP) * 2 && clickX <= startX + (ICON_W + ICON_GAP) * 2 + ICON_W) // DELETE
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa học sinh: {student.FullName}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_studentBus.DeleteStudent(studentId))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Dữ liệu đang được sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            using (var frm = new ThemHocSinh(_teacherUserId))
            {
                if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB();
            }
        }

        // =========================================================
        // PHÂN TRANG & UI HELPER (GIỮ NGUYÊN)
        // =========================================================
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