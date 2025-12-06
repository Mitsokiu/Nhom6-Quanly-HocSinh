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
        private int teacherId;
        private EvaluationBUS evalBus = new EvaluationBUS();
        private SemesterBUS semBus = new SemesterBUS();

        private List<StudentEvaluationDTO> fullList = new List<StudentEvaluationDTO>();
        private List<StudentEvaluationDTO> displayList = new List<StudentEvaluationDTO>();

        private int currentPage = 1;
        private const int pageSize = 6;
        private int totalPages = 1;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm học sinh theo tên hoặc mã số...";

        private const int ICON_W = 24;
        private const int ICON_H = 24;

        public UC_GVCN_HanhKiem(int teacherId)
        {
            InitializeComponent();
            this.teacherId = teacherId;

            SetupDataGridView();

            dgvHanhKiem.CellPainting += DgvHanhKiem_CellPainting;
            dgvHanhKiem.CellMouseClick += DgvHanhKiem_CellMouseClick;
            dgvHanhKiem.CellFormatting += DgvHanhKiem_CellFormatting;

            this.Load += (s, e) => SetRoundedRegion(pnlSearchBox, 20);
            this.Resize += (s, e) => CenterPagination();

            LoadSemesters();
            cbbHocKy.SelectedIndexChanged += (s, e) => LoadDataFromDB();

            txtSearch.Text = PLACEHOLDER_TEXT;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == PLACEHOLDER_TEXT) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = PLACEHOLDER_TEXT; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            InitPaginationEvents();
        }

        private void DgvHanhKiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dto = dgvHanhKiem.Rows[e.RowIndex].DataBoundItem as StudentEvaluationDTO;
                if (dto == null) return;

                if (!dto.IsSaved)
                {
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.Font = new Font(dgvHanhKiem.Font, FontStyle.Italic);    
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Font = new Font(dgvHanhKiem.Font, FontStyle.Regular);
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvHanhKiem.Columns.Clear();
            dgvHanhKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvHanhKiem.AutoGenerateColumns = false;
            DataGridViewCellStyle centerStyle = new DataGridViewCellStyle();
            centerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHanhKiem.Columns.Add(new DataGridViewTextBoxColumn { 
                Name = "StudentCode", 
                HeaderText = "MÃ SỐ", 
                Width = 150, 
                ReadOnly = true, 
                DataPropertyName = "StudentCode" 
            });

            dgvHanhKiem.Columns.Add(new DataGridViewTextBoxColumn { 
                Name = "FullName", 
                HeaderText = "HỌ VÀ TÊN", 
                Width = 330, 
                ReadOnly = true, 
                DataPropertyName = "FullName" 
            });

            var colConduct = new DataGridViewTextBoxColumn { 
                Name = "Conduct", HeaderText = "HẠNH KIỂM", 
                Width = 200, 
                ReadOnly = true, 
                DataPropertyName = "Conduct"
            };
            dgvHanhKiem.Columns.Add(colConduct);

            var colComment = new DataGridViewTextBoxColumn { 
                Name = "TeacherComment", 
                HeaderText = "NHẬN XÉT", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, 
                ReadOnly = true, 
                HeaderCell = { Style = centerStyle }, 
                DataPropertyName = "TeacherComment" 
            };
            dgvHanhKiem.Columns.Add(colComment);

            var colAction = new DataGridViewTextBoxColumn { Name = "Action", HeaderText = "HÀNH ĐỘNG", Width = 200, ReadOnly = true };
            colAction.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHanhKiem.Columns.Add(colAction);

            dgvHanhKiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHanhKiem.MultiSelect = false;
            dgvHanhKiem.RowTemplate.Height = 50;
        }

 
        private void DgvHanhKiem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHanhKiem.Columns["Action"].Index)
            {
                e.Handled = true; 
                e.PaintBackground(e.CellBounds, true); 

                int x = e.CellBounds.X + (e.CellBounds.Width - ICON_W) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - ICON_H) / 2;

                if (Properties.Resources.edit_40 != null)
                {
                    e.Graphics.DrawImage(Properties.Resources.edit_40, x, y, ICON_W, ICON_H);
                }
            }
        }

        private void DgvHanhKiem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHanhKiem.Columns["Action"].Index)
            {
                var dto = dgvHanhKiem.Rows[e.RowIndex].DataBoundItem as StudentEvaluationDTO;

                if (dto != null)
                {
                    int semesterId = (int)cbbHocKy.SelectedValue;

                   
                    using (var frm = new XetHanhKiem(dto, semesterId))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadDataFromDB();
                        }
                    }
                }
            }
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