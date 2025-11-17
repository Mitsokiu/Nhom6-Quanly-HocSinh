using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using GUI.Properties; // Bỏ comment dòng này nếu bạn đã thêm Resources

namespace GUI
{
    public partial class QuanLyKhoiLop : UserControl
    {
        public QuanLyKhoiLop()
        {
            InitializeComponent();

            // Xử lý placeholder cho ô tìm kiếm
            txtSearch.Enter += (s, e) => { if (txtSearch.Text.Contains("Tìm kiếm")) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "   Tìm kiếm theo mã hoặc tên khối..."; txtSearch.ForeColor = Color.Gray; } };

            // Xử lý placeholder cho ô mã khối (nếu cần)
            txtMaKhoi.Enter += (s, e) => { if (txtMaKhoi.Text == "Ví dụ: K10") { txtMaKhoi.Text = ""; txtMaKhoi.ForeColor = Color.Black; } };
            txtMaKhoi.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtMaKhoi.Text)) { txtMaKhoi.Text = "Ví dụ: K10"; txtMaKhoi.ForeColor = Color.Gray; } };

            // Đăng ký sự kiện vẽ ô cho cột Hành động
            dgvKhoiLop.CellPainting += DgvKhoiLop_CellPainting;

            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Dữ liệu mẫu như thiết kế
            dgvKhoiLop.Rows.Add("K12", "Khối 12", "");
            dgvKhoiLop.Rows.Add("K11", "Khối 11", ""); // Dòng này sẽ được chọn mặc định để khớp thiết kế
            dgvKhoiLop.Rows.Add("K10", "Khối 10", "");

            // Chọn dòng K11 để demo hiệu ứng highlight xanh
            if (dgvKhoiLop.Rows.Count > 1)
            {
                dgvKhoiLop.Rows[1].Selected = true;
            }
        }

        private void DgvKhoiLop_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Chỉ vẽ cho cột Hành động (index 2) và không phải header
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Handled = true;

                // Giả lập vẽ icon. Bỏ comment và đảm bảo Resources có ảnh
                try
                {
                    // Image editIcon = Resources.edit_icon; // Cần icon bút chì xanh
                    // Image deleteIcon = Resources.delete_icon; // Cần icon thùng rác đỏ

                    // int iconSize = 16;
                    // int space = 20;

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