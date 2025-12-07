using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_Diem : UserControl
    {

        private ScoreBUS scoreBUS = new ScoreBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();
        private int loggedInUserId;

        private Label lbDiemTB;
        private Label lbXepLoai;

        private Color primaryBlue = Color.FromArgb(45, 108, 223);
        private Color textDark = Color.FromArgb(30, 30, 30);
        private Color textLight = Color.Gray;
        private Color bgGray = Color.FromArgb(245, 247, 250);

        public UC_HocSinh_Diem(int userId)
        {
            InitializeComponent();
            this.loggedInUserId = userId;
            CustomInit();
        }

        private void CustomInit()
        {
            SetupUI();

            LoadSemesters();
        }

        private void SetupUI()
        {
            this.BackColor = bgGray;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.Size = new Size(1100, 700);


            Label lblTitle = new Label();
            lblTitle.Text = "Bảng điểm chi tiết";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
            this.Controls.Add(lblTitle);


            TableLayoutPanel tlpCards = new TableLayoutPanel();
            tlpCards.Location = new Point(20, 80);
            tlpCards.Size = new Size(1060, 110);

            tlpCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            tlpCards.ColumnCount = 2;
            tlpCards.RowCount = 1;

            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            this.Controls.Add(tlpCards);

            lbDiemTB = new Label();
            lbXepLoai = new Label();


            Panel card1 = CreateSummaryCard("Điểm TB Học kỳ", lbDiemTB, true);
            card1.Margin = new Padding(0, 0, 10, 0);

            Panel card2 = CreateSummaryCard("Xếp loại Học kỳ", lbXepLoai, false);
            card2.Margin = new Padding(10, 0, 0, 0);

            tlpCards.Controls.Add(card1, 0, 0);
            tlpCards.Controls.Add(card2, 1, 0);


            Panel pnlMainContent = new Panel();
            pnlMainContent.BackColor = Color.White;
            pnlMainContent.Location = new Point(20, 210);
            pnlMainContent.Size = new Size(1060, 450);
            pnlMainContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(pnlMainContent);

            Label lblTableTitle = new Label();
            lblTableTitle.Text = "Điểm các môn học";
            lblTableTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTableTitle.Location = new Point(20, 20);
            lblTableTitle.AutoSize = true;
            pnlMainContent.Controls.Add(lblTableTitle);

            comboBox1.Parent = pnlMainContent;
            comboBox1.Location = new Point(pnlMainContent.Width - 300, 15);
            comboBox1.Width = 250;
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.TabStop = false;

            comboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;


            StyleDataGridView(dataGridView1);
            dataGridView1.Parent = pnlMainContent;
            dataGridView1.Location = new Point(20, 70);
            dataGridView1.Size = new Size(pnlMainContent.Width - 40, pnlMainContent.Height - 90);
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

        }

        private void LoadSemesters()
        {
            List<SemesterDTO> list = semesterBUS.GetAllSemesters();

            comboBox1.DataSource = null;

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "DisplayName";
            comboBox1.ValueMember = "SemesterId";


            if (list.Count > 0)
            {
                int firstSemesterId = list[0].SemesterId;

                LoadScoresData(firstSemesterId);
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int semesterId)
            {
                LoadScoresData(semesterId);
            }
            this.Focus();
        }

        private void LoadScoresData(int semesterId)
        {
            if (loggedInUserId <= 0) return;

            List<SubjectScoreDTO> listDiem = scoreBUS.GetScoresData(loggedInUserId, semesterId);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = listDiem;

            if (dataGridView1.Columns["MonHoc"] != null) dataGridView1.Columns["MonHoc"].DataPropertyName = "SubjectName";
            if (dataGridView1.Columns["Mieng"] != null) dataGridView1.Columns["Mieng"].DataPropertyName = "OralScore";
            if (dataGridView1.Columns["muoilamp"] != null) dataGridView1.Columns["muoilamp"].DataPropertyName = "FifteenMinScore";
            if (dataGridView1.Columns["mottiet"] != null) dataGridView1.Columns["mottiet"].DataPropertyName = "OnePeriodScore";
            if (dataGridView1.Columns["CuoiKi"] != null) dataGridView1.Columns["CuoiKi"].DataPropertyName = "FinalScore";
            if (dataGridView1.Columns["Tb"] != null) dataGridView1.Columns["Tb"].DataPropertyName = "AverageScore";

            UpdateSummaryCards(listDiem);
        }

        private Panel CreateSummaryCard(string title, Label lblValueToBind, bool isStarIcon)
        {
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.BackColor = Color.White;

            Label lblIcon = new Label();
            lblIcon.Size = new Size(50, 50);
            lblIcon.Location = new Point(20, 25);
            lblIcon.BackColor = isStarIcon ? Color.FromArgb(230, 240, 255) : Color.FromArgb(235, 250, 235);
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.Font = new Font("Segoe UI Emoji", 16);
            lblIcon.Text = isStarIcon ? "⭐" : "🏆";
            lblIcon.ForeColor = isStarIcon ? Color.Blue : Color.Green;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = textLight;
            lblTitle.Location = new Point(90, 25);
            lblTitle.AutoSize = true;

            lblValueToBind.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblValueToBind.ForeColor = Color.FromArgb(30, 30, 30);
            lblValueToBind.Location = new Point(100, 45);
            lblValueToBind.AutoSize = true;
            lblValueToBind.Text = "...";

            pnl.Controls.Add(lblIcon);
            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblValueToBind);

            return pnl;
        }

        private void UpdateSummaryCards(List<SubjectScoreDTO> list)
        {
            if (list == null || list.Count == 0)
            {
                lbDiemTB.Text = "...";
                lbXepLoai.Text = "...";
                return;
            }

            var validScores = list.Where(x => x.AverageScore.HasValue).Select(x => x.AverageScore.Value);
            float dtb = validScores.Any() ? validScores.Average() : 0;

            string xepLoai = "Yếu";
            if (dtb >= 8.0) xepLoai = "Giỏi";
            else if (dtb >= 6.5) xepLoai = "Khá";
            else if (dtb >= 5.0) xepLoai = "Trung Bình";


            lbDiemTB.Text = dtb.ToString("0.0");
            lbXepLoai.Text = xepLoai;

            if (xepLoai == "Giỏi") lbXepLoai.ForeColor = Color.Green;
            else if (xepLoai == "Yếu") lbXepLoai.ForeColor = Color.Red;
            else lbXepLoai.ForeColor = Color.FromArgb(30, 30, 30);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = textLight;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = textLight;
            dgv.ColumnHeadersHeight = 50;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = textDark;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);


            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dgv.DefaultCellStyle.SelectionForeColor = primaryBlue;

            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.RowTemplate.Height = 50;
            dgv.GridColor = Color.FromArgb(240, 240, 240);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;


            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgv.Columns["Tb"] != null)
            {
                dgv.Columns["Tb"].DefaultCellStyle.ForeColor = primaryBlue;
                dgv.Columns["Tb"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv.Columns["Tb"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
                dgv.Columns["Tb"].DefaultCellStyle.SelectionForeColor = primaryBlue;
            }
        }

    }
}