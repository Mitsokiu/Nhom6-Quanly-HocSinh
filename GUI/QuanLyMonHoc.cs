using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using GUI.Properties; // Bỏ comment nếu đã thêm Resources

namespace GUI
{
    public partial class QuanLyMonHoc : UserControl
    {
        public QuanLyMonHoc()
        {
            InitializeComponent();

            // Setup placeholders
            SetupPlaceholder(txtMaMon, "Ví dụ: TOAN10");
            SetupPlaceholder(txtTenMon, "Ví dụ: Toán lớp 10");
            SetupPlaceholder(txtSoTiet, "Ví dụ: 90");
            SetupPlaceholder(txtSearch, "   Tìm kiếm môn học...");

            // Custom painting for Action column
            dgvMonHoc.CellPainting += DgvMonHoc_CellPainting;

            LoadSampleData();
        }

        private void SetupPlaceholder(TextBox txt, string placeholder)
        {
            txt.Enter += (s, e) => {
                if (txt.Text == placeholder || txt.Text.Trim() == placeholder.Trim())
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };
            txt.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void LoadSampleData()
        {
            // Dữ liệu mẫu giống thiết kế
            dgvMonHoc.Rows.Add("TOAN10", "Toán lớp 10", "90", "");
            dgvMonHoc.Rows.Add("VATLY11", "Vật lý lớp 11", "60", "");
            dgvMonHoc.Rows.Add("HOAHOC12", "Hóa học lớp 12", "60", "");
            dgvMonHoc.Rows.Add("SINHHOC10", "Sinh học lớp 10", "45", "");
        }

        private void DgvMonHoc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Chỉ vẽ cho cột Hành động (index 3) và không phải header
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Handled = true;

                // Giả lập vẽ icon. Hãy thêm icon vào Resources để bỏ comment
                try
                {
                    // Image editIcon = Resources.edit_icon; // Bút chì màu vàng cam
                    // Image deleteIcon = Resources.delete_icon; // Thùng rác màu đỏ

                    // int iconSize = 16;
                    // int space = 25; // Khoảng cách giữa 2 icon

                    // // Tính vị trí để căn giữa
                    // int totalWidth = (iconSize * 2) + space;
                    // int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
                    // int startY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                    // e.Graphics.DrawImage(editIcon, startX, startY, iconSize, iconSize);
                    // e.Graphics.DrawImage(deleteIcon, startX + iconSize + space, startY, iconSize, iconSize);
                }
                catch { }
            }
        }
    }
}