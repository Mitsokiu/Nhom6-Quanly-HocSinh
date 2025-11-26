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
    public partial class UC_GVCN_ThongBao : UserControl
    {
        private NotificationBUS _bus = new NotificationBUS();
        private int _loggedInUserId;
        private List<NotificationDTO> _originalList = new List<NotificationDTO>();
        private List<NotificationDTO> _displayList = new List<NotificationDTO>();

        // Biến phân trang
        private int _currentPage = 1;
        private int _pageSize = 6;
        private int _totalPages = 0;

        // Chuỗi placeholder mặc định
        private const string PLACEHOLDER_TEXT = "Tìm kiếm thông báo...";

        public UC_GVCN_ThongBao(int userId)
        {
            InitializeComponent();
            this._loggedInUserId = userId;
            SetupDataGridView();
            InitPaginationEvents();

            // --- FIX LỖI TÌM KIẾM ---
            // 1. Đặt text mặc định ngay khi khởi tạo để đảm bảo khớp
            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;

            // 2. Sự kiện khi click vào ô tìm kiếm (Enter)
            txtSearch.Enter += (s, e) => {
                if (txtSearch.Text == PLACEHOLDER_TEXT)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            // 3. Sự kiện khi click ra ngoài ô tìm kiếm (Leave)
            txtSearch.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = PLACEHOLDER_TEXT;
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            // 4. Sự kiện gõ phím tìm kiếm
            txtSearch.TextChanged += (s, e) => {
                // Nếu đang là chữ placeholder thì không tìm
                if (txtSearch.Text == PLACEHOLDER_TEXT) return;

                _displayList = _bus.FilterNotifications(_originalList, txtSearch.Text);
                _currentPage = 1;
                UpdatePagination();
            };
            // ------------------------

            this.Load += (s, e) => LoadData();
            this.Resize += (s, e) => CenterPagination();

            // Sự kiện nút Tạo mới
            btnCreate.Click += BtnCreate_Click;

            // Vẽ nút bo tròn
            btnCreate.Paint += (s, e) => {
                Button btn = (Button)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle r = new Rectangle(0, 0, btn.Width, btn.Height);
                using (GraphicsPath path = new GraphicsPath())
                {
                    int rad = 10;
                    path.AddArc(0, 0, rad, rad, 180, 90);
                    path.AddArc(r.Width - rad, 0, rad, rad, 270, 90);
                    path.AddArc(r.Width - rad, r.Height - rad, rad, rad, 0, 90);
                    path.AddArc(0, r.Height - rad, rad, rad, 90, 90);
                    btn.Region = new Region(path);
                }
            };

            // Sự kiện GridView
            dgvThongBao.MouseClick += DgvThongBao_MouseClick;
            dgvThongBao.CellPainting += DgvThongBao_CellPainting;
        }

        public UC_GVCN_ThongBao() : this(0) { }

        private void LoadData()
        {
            if (_loggedInUserId <= 0) return;
            _originalList = _bus.GetMyNotifications(_loggedInUserId);

            // Nếu ô tìm kiếm đang trống hoặc là placeholder thì hiển thị hết
            if (txtSearch.Text == PLACEHOLDER_TEXT || string.IsNullOrWhiteSpace(txtSearch.Text))
                _displayList = new List<NotificationDTO>(_originalList);
            else
                _displayList = _bus.FilterNotifications(_originalList, txtSearch.Text);

            _currentPage = 1;
            UpdatePagination();
        }

        private void UpdatePagination()
        {
            _totalPages = (int)Math.Ceiling((double)_displayList.Count / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = _totalPages;

            dgvThongBao.Rows.Clear();
            var pageData = _displayList.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            foreach (var item in pageData)
            {
                int idx = dgvThongBao.Rows.Add(item.Title, item.SenderName, item.DateDisplay, "");
                dgvThongBao.Rows[idx].Tag = item;
            }
            RenderPaginationButtons();
        }

        // --- XỬ LÝ SỰ KIỆN CLICK ---
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            ThemThongBao frm = new ThemThongBao(_loggedInUserId);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void DgvThongBao_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dgvThongBao.HitTest(e.X, e.Y);
            if (hit.RowIndex >= 0 && hit.ColumnIndex == 3)
            {
                var row = dgvThongBao.Rows[hit.RowIndex];
                var noti = row.Tag as NotificationDTO;
                if (noti == null) return;

                Rectangle cellRect = dgvThongBao.GetCellDisplayRectangle(3, hit.RowIndex, false);
                // Xác định click nửa trái (Sửa) hay phải (Xóa)
                if (e.X - cellRect.X < cellRect.Width / 2)
                {
                    // >>> GỌI FORM SỬA <<<
                    SuaThongBao frm = new SuaThongBao(_loggedInUserId, noti);
                    if (frm.ShowDialog() == DialogResult.OK) LoadData();
                }
                else
                {
                    // >>> GỌI HÀM XÓA <<<
                    if (MessageBox.Show($"Xóa thông báo: {noti.Title}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (_bus.DeleteNotification(noti.Id)) { MessageBox.Show("Đã xóa!"); LoadData(); }
                    }
                }
            }
        }

        // --- UI HELPERS ---
        private void SetupDataGridView()
        {
            dgvThongBao.Columns.Clear();
            dgvThongBao.Columns.Add("Title", "TIÊU ĐỀ");
            dgvThongBao.Columns.Add("Creator", "NGƯỜI TẠO");
            dgvThongBao.Columns.Add("Date", "NGÀY ĐĂNG");
            dgvThongBao.Columns.Add("Action", "");
            dgvThongBao.Columns[0].FillWeight = 45;
            dgvThongBao.Columns[1].FillWeight = 20;
            dgvThongBao.Columns[2].FillWeight = 20;
            dgvThongBao.Columns[3].FillWeight = 15;
            dgvThongBao.RowTemplate.Height = 50;
        }

        private void DgvThongBao_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                int size = 20;
                int y = e.CellBounds.Y + (e.CellBounds.Height - size) / 2;
                int center = e.CellBounds.X + e.CellBounds.Width / 2;

                // Nút Sửa (Xanh)
                using (Brush b = new SolidBrush(Color.FromArgb(13, 110, 253)))
                    e.Graphics.FillRectangle(b, center - 25, y, size, size);
                // Nút Xóa (Đỏ)
                using (Brush b = new SolidBrush(Color.FromArgb(220, 53, 69)))
                    e.Graphics.FillRectangle(b, center + 5, y, size, size);
            }
        }

        // --- PHÂN TRANG ---
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
            int y = 12;

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
            EventHandler click = (s, e) => { _currentPage = (int)((Button)s).Tag; UpdatePagination(); };
            btnPage1.Click += click; btnPage2.Click += click; btnPage3.Click += click; btnPageLast.Click += click;
            btnPrev.Click += (s, e) => { if (_currentPage > 1) { _currentPage--; UpdatePagination(); } };
            btnNext.Click += (s, e) => { if (_currentPage < _totalPages) { _currentPage++; UpdatePagination(); } };
        }
    }
}