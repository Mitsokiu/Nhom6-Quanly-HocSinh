using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVCN_HanhKiem : UserControl
    {
        // Đã bỏ dấu gạch dưới
        private int teacherId;
        private EvaluationBUS evalBus = new EvaluationBUS();
        private SemesterBUS semBus = new SemesterBUS();

        private List<StudentEvaluationDTO> fullList = new List<StudentEvaluationDTO>();
        private List<StudentEvaluationDTO> displayList = new List<StudentEvaluationDTO>();

        // Biến phân trang (đã bỏ gạch dưới)
        private int currentPage = 1;
        private const int pageSize = 6;
        private int totalPages = 1;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh theo tên hoặc mã số...";

        public UC_GVCN_HanhKiem(int teacherIdInput)
        {
            InitializeComponent();
            this.teacherId = teacherIdInput; // Gán ID

            // UI Init
            SetupDataGridView();
            this.Load += (s, e) => {
                SetRoundedRegion(pnlSearchBox, 20);
                SetRoundedRegion(btnSaveAll, 10);
                SetRoundedRegion(btnCancel, 10);
            };
            this.Resize += (s, e) => CenterPagination();

            LoadSemesters();

            // Events
            cbbHocKy.SelectedIndexChanged += (s, e) => LoadDataFromDB();

            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnSaveAll.Click += BtnSaveAll_Click;
            btnCancel.Click += (s, e) => LoadDataFromDB();

            InitPaginationEvents();
        }

        private void SetupDataGridView()
        {
            dgvHanhKiem.Columns.Clear();
            dgvHanhKiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewCellStyle centerStyle = new DataGridViewCellStyle();
            centerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // [FIX 2] Tắt chế độ tự chia đều toàn bộ
            dgvHanhKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 1. Cột STT (Nhỏ)
            dgvHanhKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "STT",
                HeaderText = "STT",
                Width = 150,  // Cố định 50px
                ReadOnly = true
            });

            // 2. Cột Mã HS (Vừa)
            dgvHanhKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentCode",
                HeaderText = "MÃ HS",
                Width = 150, // Cố định 100px
                ReadOnly = true,
                DataPropertyName = "StudentCode"
            });

            // 3. Cột Họ Tên (Rộng hơn chút)
            dgvHanhKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "HỌ VÀ TÊN",
                Width = 200, // Cố định 200px
                ReadOnly = true,
                DataPropertyName = "FullName"
            });

            // 4. Cột Hạnh Kiểm (Vừa)
            var colConduct = new DataGridViewComboBoxColumn();
            colConduct.Name = "Conduct";
            colConduct.HeaderText = "HẠNH KIỂM";
            colConduct.Width = 170; // Cố định 150px
            colConduct.DataPropertyName = "Conduct";
            colConduct.Items.AddRange("Tốt", "Khá", "Trung Bình", "Yếu");
            colConduct.FlatStyle = FlatStyle.Flat;
            colConduct.DefaultCellStyle = centerStyle; // Căn giữa chữ trong ComboBox
            colConduct.HeaderCell.Style = centerStyle;
            dgvHanhKiem.Columns.Add(colConduct);

            // 5. Cột Nhận Xét (QUAN TRỌNG: Fill hết phần còn lại)
            var colComment = new DataGridViewTextBoxColumn();
            colComment.Name = "TeacherComment";
            colComment.HeaderText = "NHẬN XÉT CỦA GIÁO VIÊN";
            colComment.DataPropertyName = "TeacherComment";

            colComment.HeaderCell.Style = centerStyle;
            // Chỉ cột này được Fill
            colComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvHanhKiem.Columns.Add(colComment);

            dgvHanhKiem.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void LoadSemesters()
        {
            List<SemesterDTO> semesters = semBus.GetAllSemesters();
            cbbHocKy.DataSource = semesters;
            cbbHocKy.DisplayMember = "DisplayName";
            cbbHocKy.ValueMember = "SemesterId";
            if (semesters.Count > 0)
            {
                cbbHocKy.SelectedIndex = 0;
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

            for (int i = 0; i < dgvHanhKiem.Rows.Count; i++)
            {
                dgvHanhKiem.Rows[i].Cells["STT"].Value = ((currentPage - 1) * pageSize + i + 1).ToString();
            }

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

        private void BtnSaveAll_Click(object sender, EventArgs e)
        {
            int semesterId = (int)cbbHocKy.SelectedValue;
            if (evalBus.IsEvaluationLocked(semesterId))
            {
                MessageBox.Show("Học kỳ này đã kết thúc. Không thể chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = 0;
            foreach (DataGridViewRow row in dgvHanhKiem.Rows)
            {
                var dto = row.DataBoundItem as StudentEvaluationDTO;
                if (dto != null)
                {
                    dto.Conduct = row.Cells["Conduct"].Value?.ToString();
                    dto.TeacherComment = row.Cells["TeacherComment"].Value?.ToString();

                    if (evalBus.SaveEvaluation(dto, semesterId)) count++;
                }
            }
            MessageBox.Show($"Đã lưu thành công cho {count} học sinh (Trang {currentPage})!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ============================
        // LOGIC PHÂN TRANG 
        // ============================
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