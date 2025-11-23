using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_HocPhi : UserControl
    {
        private TuitionBUS _tuitionBUS = new TuitionBUS();
        private SemesterBUS _semesterBUS = new SemesterBUS();
        private int _loggedInUserId;

        public UC_HocSinh_HocPhi(int userId)
        {
            InitializeComponent();
            this._loggedInUserId = userId;

            // 1. Cấu hình giao diện
            InitCustomUI();
            SetupDataGridView();

            // 2. Load dữ liệu
            LoadSemestersFromDB();

            // 3. Đăng ký sự kiện vẽ
            dgvHocPhi.CellPainting += DgvHocPhi_CellPainting;
        }

        // Constructor mặc định cho Designer
        public UC_HocSinh_HocPhi() : this(0) { }

        private void SetupDataGridView()
        {
            dgvHocPhi.Columns.Clear();
            dgvHocPhi.Columns.Add("TenKhoanPhi", "TÊN KHOẢN PHÍ");
            dgvHocPhi.Columns.Add("SoTien", "SỐ TIỀN");
            dgvHocPhi.Columns.Add("HanNop", "HẠN NỘP");
            dgvHocPhi.Columns.Add("TrangThai", "TRẠNG THÁI");
            dgvHocPhi.GridColor = Color.FromArgb(240, 240, 240);
            // --- 1. TINH CHỈNH TỶ LỆ CỘT (QUAN TRỌNG) ---
            dgvHocPhi.Columns[0].FillWeight = 30; 
            dgvHocPhi.Columns[1].FillWeight = 15; 
            dgvHocPhi.Columns[2].FillWeight = 15;
            dgvHocPhi.Columns[3].FillWeight = 25; 

            // --- 2. CẤU HÌNH CỘT SỐ TIỀN (SỬA LỖI LỆCH) ---
            // Canh phải cho dữ liệu
            dgvHocPhi.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHocPhi.Columns[1].DefaultCellStyle.Format = "N0";

            // Giảm Padding xuống 10 (thay vì 50) để số nằm sát lề phải tự nhiên hơn
            dgvHocPhi.Columns[1].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);

            // Canh phải cho cả TIÊU ĐỀ (Header) để thẳng hàng với số
            dgvHocPhi.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            // --- 3. CÁC CỘT CÒN LẠI ---
            // Hạn nộp: Canh giữa
            dgvHocPhi.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHocPhi.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Trạng thái: Canh giữa
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

                // Đăng ký sự kiện sau khi gán DataSource để tránh lỗi trigger sớm
                cboSemester.SelectedIndexChanged -= CboSemester_SelectedIndexChanged;
                cboSemester.SelectedIndexChanged += CboSemester_SelectedIndexChanged;

                cboSemester.SelectedIndex = 0;
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

        private void LoadTuitionData(int semesterId)
        {
            dgvHocPhi.Rows.Clear();

            if (_loggedInUserId <= 0) return;

            List<TuitionDTO> list = _tuitionBUS.GetTuitionByUser(_loggedInUserId, semesterId);

            foreach (var item in list)
            {
                dgvHocPhi.Rows.Add(
                    item.FeeName,
                    item.AmountDisplay,
                    item.DueDate.ToString("dd/MM/yyyy"),
                    item.StatusDisplay
                );
            }

            dgvHocPhi.ClearSelection();
        }

        // --- PHẦN VẼ UI ---
        private void InitCustomUI()
        {
            SetupPaginationButton(btnPrev, "<", 350);
            SetupPaginationButton(btnPage1, "1", 400, true);
            SetupPaginationButton(btnPage2, "2", 450);
            SetupPaginationButton(btnPage3, "3", 500);
            SetupPaginationButton(btnPageLast, "5", 580);
            SetupPaginationButton(btnNext, ">", 630);
        }

        private void SetupPaginationButton(Button btn, string text, int x, bool isActive = false)
        {
            btn.Text = text;
            btn.Size = new Size(40, 40);
            btn.Location = new Point(x, 10);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            if (isActive)
            {
                btn.BackColor = Color.FromArgb(0, 123, 255);
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
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