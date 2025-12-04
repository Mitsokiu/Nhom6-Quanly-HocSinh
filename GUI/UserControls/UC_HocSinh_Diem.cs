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

        // Màu sắc giao diện
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
            // 1. Cấu hình nền
            this.BackColor = bgGray;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.Size = new Size(1100, 700);

            // ---------------------------------------------------------
            // PHẦN 1: HEADER
            // ---------------------------------------------------------
            Label lblTitle = new Label();
            lblTitle.Text = "Bảng điểm chi tiết";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
            this.Controls.Add(lblTitle);

            // ---------------------------------------------------------
            // PHẦN 2: TABLE LAYOUT CHO CARDS (TỰ ĐỘNG CHIA)
            // ---------------------------------------------------------
            // Thay vì dùng Panel thường, ta dùng TableLayoutPanel để tự chia cột
            TableLayoutPanel tlpCards = new TableLayoutPanel();
            tlpCards.Location = new Point(20, 80); // Căn lề trái 20 (bằng Grid bên dưới)
            tlpCards.Size = new Size(1060, 110);   // Chiều cao 110

            // QUAN TRỌNG: Neo trái phải để nó luôn bằng chiều rộng Grid
            tlpCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Cấu hình 1 dòng, 2 cột
            tlpCards.ColumnCount = 2;
            tlpCards.RowCount = 1;

            // Cột 1: 50%, Cột 2: 50% -> Máy tự chia đều
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            this.Controls.Add(tlpCards);

            lbDiemTB = new Label();
            lbXepLoai = new Label();

            // 2. Truyền biến vào hàm tạo Card
            // Card 1: Gắn với lblGiaTriDiemTB
            Panel card1 = CreateSummaryCard("Điểm TB Học kỳ", lbDiemTB, true);
            card1.Margin = new Padding(0, 0, 10, 0);

            // Card 2: Gắn với lblGiaTriXepLoai
            Panel card2 = CreateSummaryCard("Xếp loại Học kỳ", lbXepLoai, false);
            card2.Margin = new Padding(10, 0, 0, 0);

            tlpCards.Controls.Add(card1, 0, 0);
            tlpCards.Controls.Add(card2, 1, 0);

            // ---------------------------------------------------------
            // PHẦN 3: BODY (Bảng điểm)
            // ---------------------------------------------------------
            Panel pnlMainContent = new Panel();
            pnlMainContent.BackColor = Color.White;
            pnlMainContent.Location = new Point(20, 210); // Cách bên trên chút
            pnlMainContent.Size = new Size(1060, 450);
            pnlMainContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(pnlMainContent);

            Label lblTableTitle = new Label();
            lblTableTitle.Text = "Điểm các môn học";
            lblTableTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTableTitle.Location = new Point(20, 20);
            lblTableTitle.AutoSize = true;
            pnlMainContent.Controls.Add(lblTableTitle);

            // --- XỬ LÝ COMBOBOX ---
            comboBox1.Parent = pnlMainContent;
            comboBox1.Location = new Point(pnlMainContent.Width - 300, 15);
            comboBox1.Width = 250;
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.TabStop = false;

            comboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;


            // Styling DataGridView
            StyleDataGridView(dataGridView1);
            dataGridView1.Parent = pnlMainContent;
            dataGridView1.Location = new Point(20, 70);
            dataGridView1.Size = new Size(pnlMainContent.Width - 40, pnlMainContent.Height - 90);
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

        }

        private void LoadSemesters()
        {
            List<SemesterDTO> list = semesterBUS.GetAllSemesters();

            // Reset trước khi gán để tránh lỗi sự kiện chồng chéo
            comboBox1.DataSource = null;

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "DisplayName";
            comboBox1.ValueMember = "SemesterId";

            // --- ĐOẠN FIX LỖI ---
            // Sau khi gán xong xuôi, nếu danh sách có dữ liệu -> Ta gọi hàm load luôn
            if (list.Count > 0)
            {
                // Lấy ID của học kỳ đầu tiên trong danh sách
                int firstSemesterId = list[0].SemesterId;

                // Gọi hàm tải bảng điểm ngay lập tức
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

            // Gọi BUS lấy dữ liệu
            List<SubjectScoreDTO> listDiem = scoreBUS.GetScoresData(loggedInUserId, semesterId);

            // Đổ vào Grid
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = listDiem;

            // Map cột (Tên cột trong Grid = Tên property trong DTO)
            if (dataGridView1.Columns["MonHoc"] != null) dataGridView1.Columns["MonHoc"].DataPropertyName = "SubjectName";
            if (dataGridView1.Columns["Mieng"] != null) dataGridView1.Columns["Mieng"].DataPropertyName = "OralScore";
            if (dataGridView1.Columns["muoilamp"] != null) dataGridView1.Columns["muoilamp"].DataPropertyName = "FifteenMinScore";
            if (dataGridView1.Columns["mottiet"] != null) dataGridView1.Columns["mottiet"].DataPropertyName = "OnePeriodScore";
            if (dataGridView1.Columns["CuoiKi"] != null) dataGridView1.Columns["CuoiKi"].DataPropertyName = "FinalScore";
            if (dataGridView1.Columns["Tb"] != null) dataGridView1.Columns["Tb"].DataPropertyName = "AverageScore";

            UpdateSummaryCards(listDiem);
        }

        // Hàm tạo Card (Đã bỏ tham số xPos, width vì TableLayout tự lo)
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

            // 1. Tính toán (Logic cũ)
            var validScores = list.Where(x => x.AverageScore.HasValue).Select(x => x.AverageScore.Value);
            float dtb = validScores.Any() ? validScores.Average() : 0;

            string xepLoai = "Yếu";
            if (dtb >= 8.0) xepLoai = "Giỏi";
            else if (dtb >= 6.5) xepLoai = "Khá";
            else if (dtb >= 5.0) xepLoai = "Trung Bình";

            // 2. CẬP NHẬT GIAO DIỆN (DỄ ỢT)
            // Vì ta đã nắm đầu biến rồi, chỉ việc gán text
            lbDiemTB.Text = dtb.ToString("0.0"); // Làm tròn 1 số lẻ
            lbXepLoai.Text = xepLoai;

            // Thậm chí đổi màu cực dễ
            if (xepLoai == "Giỏi") lbXepLoai.ForeColor = Color.Green;
            else if (xepLoai == "Yếu") lbXepLoai.ForeColor = Color.Red;
            else lbXepLoai.ForeColor = Color.FromArgb(30, 30, 30);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            // --- 1. CẤU HÌNH CHẶN SỬA ---
            dgv.ReadOnly = true;                 // Chặn sửa chữ
            dgv.AllowUserToAddRows = false;      // Chặn thêm dòng
            dgv.AllowUserToDeleteRows = false;   // Chặn xóa dòng

            // --- 2. CẤU HÌNH GIAO DIỆN ---
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            // Header Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = textLight;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White; // Header thì không cần bôi xanh
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = textLight;
            dgv.ColumnHeadersHeight = 50;

            // Row Style
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = textDark;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            // --- [QUAN TRỌNG] CHỈNH MÀU BÔI XANH (SELECTION) ---
            // Thay vì để màu Trắng (tàng hình), ta để màu Xanh nhạt dịu mắt
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255); // Màu nền khi chọn (Xanh rất nhạt)
            dgv.DefaultCellStyle.SelectionForeColor = primaryBlue;                 // Màu chữ khi chọn (Xanh đậm chủ đạo)

            // Padding và chiều cao
            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.RowTemplate.Height = 50;
            dgv.GridColor = Color.FromArgb(240, 240, 240);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;

            // --- [QUAN TRỌNG] CHẾ ĐỘ CHỌN ---
            // CellSelect: Cho phép chọn từng ô (để dễ copy điểm 1 môn).
            // FullRowSelect cho chon 1 dong
            // Nếu thích chọn cả dòng thì để FullRowSelect
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Chỉnh cột Trung Bình
            if (dgv.Columns["Tb"] != null)
            {
                dgv.Columns["Tb"].DefaultCellStyle.ForeColor = primaryBlue;
                dgv.Columns["Tb"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                // Khi chọn vào cột này, vẫn giữ màu đẹp
                dgv.Columns["Tb"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
                dgv.Columns["Tb"].DefaultCellStyle.SelectionForeColor = primaryBlue;
            }
        }

    }
}