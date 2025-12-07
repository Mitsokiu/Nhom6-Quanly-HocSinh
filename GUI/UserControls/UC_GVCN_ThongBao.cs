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
    public partial class UC_GVCN_ThongBao : UserControl
    {
        private NotificationBUS _bus = new NotificationBUS();
        private int _loggedInUserId;

        private List<NotificationDTO> _fullList = new List<NotificationDTO>();
        private List<NotificationDTO> _displayList = new List<NotificationDTO>();

        private int _currentPage = 1;
        private const int _pageSize = 6;
        private int _totalPages = 0;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm thông báo...";

        // Cấu hình Icon
        private const int ICON_W = 24;
        private const int ICON_H = 24;
        private const int ICON_GAP = 20;

        public UC_GVCN_ThongBao(int userId)
        {
            InitializeComponent();
            this._loggedInUserId = userId;

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

            btnCreate.Click += BtnCreate_Click;

            dgvThongBao.CellPainting += DgvThongBao_CellPainting;
            dgvThongBao.CellMouseClick += DgvThongBao_CellMouseClick;

            if (Properties.Resources.search_32 != null)
                picSearchIcon.Image = Properties.Resources.search_32;

            InitPaginationEvents();
        }

        private void LoadDataFromDB()
        {
            if (_loggedInUserId <= 0) return;
            _fullList = _bus.GetMyNotifications(_loggedInUserId);

            if (txtSearch.Text == PLACEHOLDER_TEXT || string.IsNullOrWhiteSpace(txtSearch.Text))
                _displayList = new List<NotificationDTO>(_fullList);
            else
                _displayList = _bus.FilterNotifications(_fullList, txtSearch.Text);

            _currentPage = 1;
            UpdatePagination();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (kw == PLACEHOLDER_TEXT) return;

            _displayList = _bus.FilterNotifications(_fullList, kw);
            _currentPage = 1;
            UpdatePagination();
        }

        // --- CẤU HÌNH BẢNG (Đã sửa căn giữa Header Action) ---
        private void SetupDataGridView()
        {
            dgvThongBao.Columns.Clear();
            dgvThongBao.Columns.Add("Title", "TIÊU ĐỀ");
            dgvThongBao.Columns.Add("Creator", "NGƯỜI TẠO");
            dgvThongBao.Columns.Add("Date", "NGÀY ĐĂNG");

            // Cột Action
            var actionCol = new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "HÀNH ĐỘNG", Width = 150 };
            dgvThongBao.Columns.Add(actionCol);

            // Căn giữa tiêu đề cột Hành động
            dgvThongBao.Columns["Action"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvThongBao.Columns[0].FillWeight = 45;
            dgvThongBao.Columns[1].FillWeight = 20;
            dgvThongBao.Columns[2].FillWeight = 20;
            dgvThongBao.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Cố định chiều rộng để không bị giãn

            dgvThongBao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongBao.MultiSelect = false;
            dgvThongBao.ReadOnly = true;
        }

        // --- VẼ ICON (Đã sửa tọa độ chuẩn xác) ---
        private void DgvThongBao_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvThongBao.Columns["Action"].Index)
            {
                e.Handled = true;

                // 1. Vẽ nền (Xử lý màu khi Selected)
                bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
                Color backColor = isSelected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor;

                using (Brush backBrush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                }

                // 2. Vẽ đường kẻ dưới
                using (Pen gridPen = new Pen(dgvThongBao.GridColor))
                {
                    e.Graphics.DrawLine(gridPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                // 3. Tính toán vị trí căn giữa (Dynamic theo chiều rộng ô thực tế)
                int totalIconWidth = (ICON_W * 2) + ICON_GAP; // Tổng chiều rộng 2 icon + khoảng cách

                // Tọa độ X bắt đầu = (Chiều rộng ô - Tổng chiều rộng icon) / 2 + Tọa độ X của ô
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalIconWidth) / 2;

                // Tọa độ Y bắt đầu = (Chiều cao ô - Chiều cao icon) / 2 + Tọa độ Y của ô
                int startY = e.CellBounds.Y + (e.CellBounds.Height - ICON_H) / 2;

                // 4. Vẽ Icon
                // Icon Edit
                if (Properties.Resources.edit_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.edit_40, startX, startY, ICON_W, ICON_H);

                // Icon Delete (cách Edit một khoảng Gap)
                if (Properties.Resources.delete_40 != null)
                    e.Graphics.DrawImage(Properties.Resources.delete_40, startX + ICON_W + ICON_GAP, startY, ICON_W, ICON_H);
            }
        }

        // --- XỬ LÝ CLICK (Đã đồng bộ tọa độ với hàm vẽ) ---
        private void DgvThongBao_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvThongBao.Columns["Action"].Index) return;

            var data = dgvThongBao.Rows[e.RowIndex].Tag as NotificationDTO;
            if (data == null) return;

            // Lấy tọa độ click trong ô
            int clickX = e.X; // Tọa độ X tương đối trong ô

            // Tính lại vị trí các vùng icon (giống hệt hàm vẽ)
            int cellWidth = dgvThongBao.Columns[e.ColumnIndex].Width;
            int totalIconWidth = (ICON_W * 2) + ICON_GAP;
            int startX = (cellWidth - totalIconWidth) / 2;

            // Kiểm tra click vào vùng EDIT
            if (clickX >= startX && clickX <= startX + ICON_W)
            {
                ThemThongBao frm = new ThemThongBao(_loggedInUserId, data);
                if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB();
            }
            // Kiểm tra click vào vùng DELETE
            else if (clickX >= startX + ICON_W + ICON_GAP && clickX <= startX + (ICON_W * 2) + ICON_GAP)
            {
                if (MessageBox.Show($"Bạn chắc chắn muốn xóa thông báo: {data.Title}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_bus.DeleteNotification(data.Id))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadDataFromDB();
                    }
                }
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            ThemThongBao frm = new ThemThongBao(_loggedInUserId);
            if (frm.ShowDialog() == DialogResult.OK) LoadDataFromDB();
        }

        private void UpdatePagination()
        {
            _totalPages = (int)Math.Ceiling((double)_displayList.Count / _pageSize);
            if (_totalPages == 0) _totalPages = 1;
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