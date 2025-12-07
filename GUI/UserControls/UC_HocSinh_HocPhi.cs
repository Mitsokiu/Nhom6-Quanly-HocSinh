using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq; // Cần thiết để dùng Skip/Take
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_HocPhi : UserControl
    {
        // --- KHAI BÁO ---
        private TuitionBUS _tuitionBUS = new TuitionBUS();
        private SemesterBUS _semesterBUS = new SemesterBUS();

        private int _loggedInUserId;

        // Biến phân trang
        private List<TuitionDTO> _allList = new List<TuitionDTO>(); // Lưu toàn bộ dữ liệu
        private int _currentPage = 1;
        private int _pageSize = 5; // Số dòng mỗi trang
        private int _totalPages = 0;

        public UC_HocSinh_HocPhi(int userId)
        {
            InitializeComponent();
            this._loggedInUserId = userId;

            // 1. Setup giao diện
            SetupDataGridView();
            InitCustomUI();

            // 2. Gắn sự kiện cho nút phân trang (MỚI)
            InitPaginationEvents();

            // 3. Load dữ liệu
            LoadSemestersFromDB();

            // 4. Sự kiện vẽ
            dgvHocPhi.CellPainting += DgvHocPhi_CellPainting;

            this.Load += (s, e) => {
                RepositionPaginationButtons();
            };

            // Đăng ký thêm sự kiện Resize (để khi phóng to/thu nhỏ vẫn giữa)
            this.Resize += (s, e) => RepositionPaginationButtons();
        }

        public UC_HocSinh_HocPhi() : this(0) { }

        // --- SỰ KIỆN PHÂN TRANG (MỚI) ---
        private void InitPaginationEvents()
        {
            btnPrev.Click += (s, e) => ChangePage(_currentPage - 1);
            btnNext.Click += (s, e) => ChangePage(_currentPage + 1);

            btnPage1.Click += (s, e) => ChangePage(1);
            btnPage2.Click += (s, e) => ChangePage(2);
            btnPage3.Click += (s, e) => ChangePage(3);

            // Nút trang cuối (Lấy text của nút để biết trang mấy)
            btnPageLast.Click += (s, e) =>
            {
                if (int.TryParse(btnPageLast.Text, out int lastPage))
                    ChangePage(lastPage);
            };
        }

        private void ChangePage(int newPage)
        {
            if (newPage < 1 || newPage > _totalPages) return;

            _currentPage = newPage;
            ShowCurrentPage(); // Vẽ lại bảng
            UpdatePaginationButtons(); // Cập nhật trạng thái nút
        }

        // --- XỬ LÝ DỮ LIỆU ---
        private void LoadTuitionData(int semesterId)
        {
            if (_loggedInUserId <= 0) return;

            // 1. Lấy toàn bộ dữ liệu từ Server
            _allList = _tuitionBUS.GetTuitionByUser(_loggedInUserId, semesterId);

            // 2. Tính toán tổng số trang
            _totalPages = (int)Math.Ceiling((double)_allList.Count / _pageSize);
            if (_totalPages < 1) _totalPages = 1;

            // 3. Reset về trang 1
            _currentPage = 1;

            // 4. Hiển thị
            ShowCurrentPage();
            UpdatePaginationButtons();
        }

        private void ShowCurrentPage()
        {
            dgvHocPhi.Rows.Clear();

            // Logic cắt trang: Skip (Bỏ qua các trang trước) -> Take (Lấy số dòng trang này)
            var pageData = _allList.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            foreach (var item in pageData)
            {
                dgvHocPhi.Rows.Add(
                    item.FeeName,
                    item.AmountDisplay,
                    item.DueDate.ToString("dd/MM/yyyy"),
                    item.StatusDisplay
                );
            }

            dgvHocPhi.ClearSelection(); // Bỏ vạch đậm
        }

        // --- LOGIC ẨN/HIỆN NÚT PHÂN TRANG (MỚI) ---
        private void UpdatePaginationButtons()
        {
            // 1. Nút Prev/Next
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;

            // 2. Reset màu
            ResetButtonStyle(btnPage1);
            ResetButtonStyle(btnPage2);
            ResetButtonStyle(btnPage3);
            ResetButtonStyle(btnPageLast);

            // 3. Highlight trang hiện tại
            if (_currentPage == 1) HighlightButton(btnPage1);
            else if (_currentPage == 2) HighlightButton(btnPage2);
            else if (_currentPage == 3) HighlightButton(btnPage3);
            else if (_currentPage == _totalPages) HighlightButton(btnPageLast);

            // 4. Ẩn hiện thông minh
            btnPage1.Visible = true; // Luôn hiện trang 1

            // Chỉ hiện trang 2 nếu tổng trang >= 2
            btnPage2.Visible = _totalPages >= 2;

            // Chỉ hiện trang 3 nếu tổng trang >= 3
            btnPage3.Visible = _totalPages >= 3;

            // Logic nút Last và dấu ...
            if (_totalPages > 4)
            {
                lblDots.Visible = true;
                btnPageLast.Visible = true;
                btnPageLast.Text = _totalPages.ToString();
            }
            else if (_totalPages == 4)
            {
                lblDots.Visible = false;
                btnPageLast.Visible = true;
                btnPageLast.Text = "4";
            }
            else
            {
                // Nếu tổng trang <= 3 thì ẩn luôn nút Last và dấu ...
                lblDots.Visible = false;
                btnPageLast.Visible = false;
            }

            // Căn giữa lại sau khi ẩn/hiện
            RepositionPaginationButtons();
        }

        private void RepositionPaginationButtons()
        {
            // 1. Gom tất cả các control liên quan vào 1 danh sách theo thứ tự
            List<Control> controls = new List<Control>
            {
                btnPrev, btnPage1, btnPage2, btnPage3, lblDots, btnPageLast, btnNext
            };

            // 2. Lọc ra những control đang hiển thị (Visible = true)
            var visibleControls = controls.Where(c => c.Visible).ToList();

            if (visibleControls.Count == 0) return;

            // 3. Cấu hình khoảng cách
            int gap = 10; // Khoảng cách giữa các nút
            int totalWidth = 0;

            // Tính tổng chiều rộng của cụm nút
            foreach (var ctrl in visibleControls)
            {
                totalWidth += ctrl.Width;
            }
            totalWidth += (visibleControls.Count - 1) * gap;

            // 4. Tính điểm bắt đầu (StartX) để căn giữa Panel
            int startX = (panelPagination.Width - totalWidth) / 2;
            int currentX = startX;

            // 5. Duyệt và đặt lại vị trí cho từng nút
            foreach (var ctrl in visibleControls)
            {
                ctrl.Location = new Point(currentX, 10); // Y = 10 giữ nguyên
                currentX += ctrl.Width + gap;
            }
        }

        private void ResetButtonStyle(Button btn)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
        }

        private void HighlightButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(0, 123, 255);
            btn.ForeColor = Color.White;
        }

        // --- CÁC HÀM CŨ (SETUP GRID, LOAD SEMESTER...) GIỮ NGUYÊN ---

        private void SetupDataGridView()
        {
            dgvHocPhi.Columns.Clear();
            dgvHocPhi.Columns.Add("TenKhoanPhi", "TÊN KHOẢN PHÍ");
            dgvHocPhi.Columns.Add("SoTien", "SỐ TIỀN");
            dgvHocPhi.Columns.Add("HanNop", "HẠN NỘP");
            dgvHocPhi.Columns.Add("TrangThai", "TRẠNG THÁI");

            // Tinh chỉnh tỷ lệ
            dgvHocPhi.Columns[0].FillWeight = 45;
            dgvHocPhi.Columns[1].FillWeight = 15;
            dgvHocPhi.Columns[2].FillWeight = 15;
            dgvHocPhi.Columns[3].FillWeight = 25;

            // Canh lề
            dgvHocPhi.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHocPhi.Columns[1].DefaultCellStyle.Format = "N0";
            dgvHocPhi.Columns[1].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
            dgvHocPhi.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHocPhi.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHocPhi.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHocPhi.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHocPhi.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadSemestersFromDB()
        {
            List<SemesterDTO> semesters = _semesterBUS.GetAllSemesters();
            cboSemester.DataSource = null;
            cboSemester.Items.Clear();

            if (semesters.Count > 0)
            {
                cboSemester.DataSource = semesters;
                cboSemester.DisplayMember = "DisplayName";
                cboSemester.ValueMember = "SemesterId";

                // Đăng ký sự kiện
                cboSemester.SelectedIndexChanged -= CboSemester_SelectedIndexChanged;
                cboSemester.SelectedIndexChanged += CboSemester_SelectedIndexChanged;

                // --- Chọn cái đầu tiên và ÉP BUỘC TẢI DỮ LIỆU NGAY ---
                //cboSemester.SelectedIndex = 0;
                cboSemester.SelectedValue = 1;

                // Lấy ID của cái đầu tiên để load luôn
                int firstSemesterId = semesters[0].SemesterId;
                LoadTuitionData(firstSemesterId);
                // ----------------------------------------------------------
            }
        }

        private void CboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSemester.SelectedValue == null) return;
            if (int.TryParse(cboSemester.SelectedValue.ToString(), out int semesterId))
            {
                LoadTuitionData(semesterId);
            }
        }

        // --- UI HELPERS ---
        private void InitCustomUI()
        {
            SetupPaginationButton(btnPrev, "<", 350);
            SetupPaginationButton(btnPage1, "1", 400, true); // Trang 1 active
            SetupPaginationButton(btnPage2, "2", 450);
            SetupPaginationButton(btnPage3, "3", 500);
            SetupPaginationButton(btnPageLast, "5", 580);
            SetupPaginationButton(btnNext, ">", 630);

            // --- MỚI: Ẩn bớt các nút thừa ngay khi khởi tạo ---
            btnPage2.Visible = false;
            btnPage3.Visible = false;
            lblDots.Visible = false;
            btnPageLast.Visible = false;
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            // -------------------------------------------------
        }

        private void SetupPaginationButton(Button btn, string text, int x, bool isActive = false)
        {
            btn.Text = text;
            btn.Size = new Size(40, 40);
            btn.Location = new Point(x, 10);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            if (isActive) HighlightButton(btn);
            else ResetButtonStyle(btn);
        }

        private void DgvHocPhi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value?.ToString();
                Color backColor = (status == "Đã thanh toán") ? Color.FromArgb(232, 245, 233) : Color.FromArgb(255, 235, 238);
                Color foreColor = (status == "Đã thanh toán") ? Color.FromArgb(46, 125, 50) : Color.FromArgb(198, 40, 40);

                int btnWidth = 130;
                int btnHeight = 30;
                Rectangle r = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - btnWidth) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - btnHeight) / 2,
                    btnWidth, btnHeight
                );

                using (GraphicsPath path = RoundedRect(r, 15))
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }

                TextRenderer.DrawText(e.Graphics, status, new Font("Segoe UI", 9, FontStyle.Bold), r, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();
            if (radius == 0) { path.AddRectangle(bounds); return path; }
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}