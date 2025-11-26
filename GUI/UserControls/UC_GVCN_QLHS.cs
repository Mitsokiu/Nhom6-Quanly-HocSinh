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
        private List<string[]> _fullData = new List<string[]>();
        private List<string[]> _displayData = new List<string[]>();

        // Pagination vars
        private int _currentPage = 1;
        private int _pageSize = 6;
        private int _totalPages = 0;

        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh...";

        public UC_GVCN_QLHS()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadFakeData();

            CalculatePagination();
            RenderPage();

            // --- SEARCH LOGIC (Like Notification) ---
            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Enter += (s, e) => {
                if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; }
            };

            txtSearch.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; }
            };
            // ----------------------------------------

            this.Resize += (s, e) => CenterPagination();

            // Events
            btnAddStudent.Click += BtnAddStudent_Click;

            InitPaginationEvents();
        }

        private void SetupDataGridView()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add("MaHS", "MÃ SỐ");
            dgvStudents.Columns.Add("HoTen", "HỌ VÀ TÊN");
            dgvStudents.Columns.Add("NgaySinh", "NGÀY SINH");
            dgvStudents.Columns.Add("GioiTinh", "GIỚI TÍNH");
            dgvStudents.Columns.Add("DiaChi", "ĐỊA CHỈ");

            DataGridViewTextBoxColumn actionCol = new DataGridViewTextBoxColumn();
            actionCol.Name = "Action";
            actionCol.HeaderText = ""; // Empty header for action
            actionCol.Width = 120;
            dgvStudents.Columns.Add(actionCol);

            // Widths
            dgvStudents.Columns["MaHS"].Width = 100;
            dgvStudents.Columns["HoTen"].Width = 200;
            dgvStudents.Columns["NgaySinh"].Width = 120;
            dgvStudents.Columns["GioiTinh"].Width = 100;
            dgvStudents.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvStudents.CellPainting += DgvStudents_CellPainting;
        }

        private void LoadFakeData()
        {
            _fullData.Clear();
            for (int i = 1; i <= 20; i++)
            {
                _fullData.Add(new string[] {
                    $"HS{i:000}", $"Học Sinh {i}", "15/05/2008", (i % 2 == 0) ? "Nữ" : "Nam", $"Quận {i}, TP.HCM"
                });
            }
            _displayData = new List<string[]>(_fullData);
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            ThemHocSinh frm = new ThemHocSinh();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Reload data here
            }
        }

        // --- CUSTOM PAINTING FOR ACTIONS (Eye, Pen, Trash) ---
        private void DgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvStudents.Columns["Action"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true); // White background

                int iconSize = 20;
                int gap = 10;
                int totalW = (iconSize * 3) + (gap * 2);
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalW) / 2;
                int startY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                // Eye (Blue)
                DrawIconBox(e.Graphics, "👁", Color.FromArgb(13, 110, 253), startX, startY, iconSize);

                // Pen (Yellow/Orange)
                DrawIconBox(e.Graphics, "✏", Color.FromArgb(255, 193, 7), startX + iconSize + gap, startY, iconSize);

                // Trash (Red)
                DrawIconBox(e.Graphics, "🗑", Color.FromArgb(220, 53, 69), startX + (iconSize + gap) * 2, startY, iconSize);
            }
        }

        private void DrawIconBox(Graphics g, string symbol, Color color, int x, int y, int size)
        {
            // Just draw text for now, can be replaced with icons
            using (Brush brush = new SolidBrush(color))
            using (Font font = new Font("Segoe UI Emoji", 12, FontStyle.Regular))
            {
                g.DrawString(symbol, font, brush, x, y - 2);
            }
        }

        // --- PAGINATION LOGIC (Identical to Notification) ---
        private void CalculatePagination()
        {
            _totalPages = (int)Math.Ceiling((double)_displayData.Count / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;
        }

        private void RenderPage()
        {
            dgvStudents.Rows.Clear();
            var pageData = _displayData.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();
            foreach (var item in pageData) dgvStudents.Rows.Add(item);
            RenderPaginationButtons();
        }

        private void RenderPaginationButtons()
        {
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
            btnPage1.Visible = btnPage2.Visible = btnPage3.Visible = btnPageLast.Visible = lblDots.Visible = false;

            if (_totalPages <= 4)
            {
                if (_totalPages >= 1) SetupBtn(btnPage1, 1);
                if (_totalPages >= 2) SetupBtn(btnPage2, 2);
                if (_totalPages >= 3) SetupBtn(btnPage3, 3);
                if (_totalPages >= 4) SetupBtn(btnPageLast, 4);
            }
            else
            {
                SetupBtn(btnPage1, 1);
                int mid = (_currentPage <= 2) ? 2 : (_currentPage >= _totalPages - 1 ? _totalPages - 1 : _currentPage);
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
            int w = 0, gap = 5, btnW = 35;

            if (btnPrev.Visible) w += btnW + gap;
            if (btnPage1.Visible) w += btnW + gap;
            if (btnPage2.Visible) w += btnW + gap;
            if (btnPage3.Visible) w += btnW + gap;
            if (lblDots.Visible) w += 20 + gap;
            if (btnPageLast.Visible) w += btnW + gap;
            if (btnNext.Visible) w += btnW;

            int x = (pnlPagination.Width - w) / 2;
            int y = (pnlPagination.Height - btnW) / 2; // Center Vertically

            if (btnPrev.Visible) { btnPrev.Location = new Point(x, y); x += btnW + gap; }
            if (btnPage1.Visible) { btnPage1.Location = new Point(x, y); x += btnW + gap; }
            if (btnPage2.Visible) { btnPage2.Location = new Point(x, y); x += btnW + gap; }
            if (btnPage3.Visible) { btnPage3.Location = new Point(x, y); x += btnW + gap; }
            if (lblDots.Visible) { lblDots.Location = new Point(x, y + 5); x += 20 + gap; }
            if (btnPageLast.Visible) { btnPageLast.Location = new Point(x, y); x += btnW + gap; }
            if (btnNext.Visible) btnNext.Location = new Point(x, y);
        }

        private void SetupBtn(Button b, int p) { b.Visible = true; b.Text = p.ToString(); b.Tag = p; }

        private void HighlightBtn(Button b)
        {
            if (!b.Visible || b.Tag == null) return;
            bool active = (int)b.Tag == _currentPage;
            b.BackColor = active ? Color.FromArgb(13, 110, 253) : Color.White;
            b.ForeColor = active ? Color.White : Color.Black;
        }

        private void InitPaginationEvents()
        {
            EventHandler click = (s, e) => { _currentPage = (int)((Button)s).Tag; RenderPage(); };
            btnPage1.Click += click; btnPage2.Click += click; btnPage3.Click += click; btnPageLast.Click += click;
            btnPrev.Click += (s, e) => { if (_currentPage > 1) { _currentPage--; RenderPage(); } };
            btnNext.Click += (s, e) => { if (_currentPage < _totalPages) { _currentPage++; RenderPage(); } };
        }
    }
}