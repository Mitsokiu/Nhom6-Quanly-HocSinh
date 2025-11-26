using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVCN_ThongBao : UserControl
    {
        private NotificationBUS _bus = new NotificationBUS();
        private int _loggedInUserId;

        public UC_GVCN_ThongBao(int userId)
        {
            InitializeComponent();
            this._loggedInUserId = userId;

            SetupDataGridView();
            InitPaginationUI();
            LoadDataFromDB();

            btnCreate.Click += BtnCreate_Click;
            btnCreate.Paint += BtnCreate_Paint;
            dgvThongBao.CellPainting += DgvThongBao_CellPainting;
            this.Resize += (s, e) => CenterPagination();
            this.Load += (s, e) => CenterPagination();
        }

        public UC_GVCN_ThongBao() : this(0) { }

        private void LoadDataFromDB()
        {
            dgvThongBao.Rows.Clear();
            if (_loggedInUserId <= 0) return;

            List<NotificationDTO> list = _bus.GetMyNotifications(_loggedInUserId);

            foreach (var item in list)
            {
                dgvThongBao.Rows.Add(item.Title, item.SenderName, item.DateDisplay, "");
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            ThemThongBao frm = new ThemThongBao(_loggedInUserId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromDB();
            }
        }

        private void SetupDataGridView()
        {
            dgvThongBao.Columns.Clear();
            dgvThongBao.Columns.Add("Title", "TIÊU ĐỀ");
            dgvThongBao.Columns.Add("Creator", "NGƯỜI TẠO");
            dgvThongBao.Columns.Add("Date", "NGÀY ĐĂNG");
            dgvThongBao.Columns.Add("Action", "HÀNH ĐỘNG");

            dgvThongBao.Columns[0].FillWeight = 45;
            dgvThongBao.Columns[1].FillWeight = 20;
            dgvThongBao.Columns[2].FillWeight = 20;
            dgvThongBao.Columns[3].FillWeight = 15;

            foreach (DataGridViewColumn col in dgvThongBao.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (col.Name == "Action") col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void DgvThongBao_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                int iconSize = 16;
                int spacing = 20;
                int centerX = e.CellBounds.X + e.CellBounds.Width / 2;
                int centerY = e.CellBounds.Y + e.CellBounds.Height / 2 - iconSize / 2;

                Rectangle rectEdit = new Rectangle(centerX - iconSize - spacing / 2, centerY, iconSize, iconSize);
                Rectangle rectDelete = new Rectangle(centerX + spacing / 2, centerY, iconSize, iconSize);

                using (Pen pen = new Pen(Color.FromArgb(13, 110, 253), 2))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawRectangle(pen, rectEdit.X, rectEdit.Y, 10, 10);
                    e.Graphics.DrawLine(pen, rectEdit.X + 10, rectEdit.Y + 10, rectEdit.X + 14, rectEdit.Y + 14);
                }

                using (Pen pen = new Pen(Color.FromArgb(220, 53, 69), 2))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawLine(pen, rectDelete.X, rectDelete.Y, rectDelete.X + 12, rectDelete.Y);
                    e.Graphics.DrawRectangle(pen, rectDelete.X + 2, rectDelete.Y + 2, 8, 10);
                }
            }
        }

        private void BtnCreate_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle r = new Rectangle(0, 0, btn.Width, btn.Height);
            using (GraphicsPath path = RoundedRect(r, 8))
            using (Brush brush = new SolidBrush(btn.BackColor))
            {
                e.Graphics.FillPath(brush, path);
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, r, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void PnlSearch_Paint(object sender, PaintEventArgs e)
        {
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

        private void InitPaginationUI()
        {
            SetupBtn(btnPrev, "<", false);
            SetupBtn(btnPage1, "1", true);
            SetupBtn(btnPage2, "2", false);
            SetupBtn(btnPage3, "3", false);
            SetupBtn(btnPageLast, "10", false);
            SetupBtn(btnNext, ">", false);
        }

        private void SetupBtn(Button btn, string text, bool active)
        {
            btn.Text = text;
            btn.Size = new Size(35, 35);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            if (active) { btn.BackColor = Color.FromArgb(13, 110, 253); btn.ForeColor = Color.White; }
            else { btn.BackColor = Color.White; btn.ForeColor = Color.Black; }
        }

        private void CenterPagination()
        {
            if (pnlPagination.Width == 0) return;
            int totalWidth = 300;
            int startX = (pnlPagination.Width - totalWidth) / 2;

            btnPrev.Location = new Point(startX, 10);
            btnPage1.Location = new Point(startX + 45, 10);
            btnPage2.Location = new Point(startX + 90, 10);
            btnPage3.Location = new Point(startX + 135, 10);
            lblDots.Location = new Point(startX + 180, 15);
            btnPageLast.Location = new Point(startX + 210, 10);
            btnNext.Location = new Point(startX + 255, 10);
        }
    }
}