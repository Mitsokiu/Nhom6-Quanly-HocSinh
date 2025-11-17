using System;
using System.Drawing;
using System.Windows.Forms;
// using GUI.Properties; // Bỏ comment nếu đã có Resources

namespace GUI
{
    public partial class QuanLyLopHocControl : UserControl
    {
        public QuanLyLopHocControl()
        {
            InitializeComponent();

            // Xử lý placeholder cho ô tìm kiếm
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == "Tìm theo tên hoặc mã lớp...") { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Tìm theo tên hoặc mã lớp..."; txtSearch.ForeColor = Color.Gray; } };

            // Đăng ký sự kiện vẽ ô cho cột Hành động
            dgvLopHoc.CellPainting += DgvLopHoc_CellPainting;

            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Dữ liệu mẫu giống thiết kế
            dgvLopHoc.Rows.Add("12A4", "Lớp 12 Chuyên Anh", "12", "35", "2023-2024", "Trần Thị B", "");
            dgvLopHoc.Rows.Add("11B2", "Lớp 11 Cơ bản 2", "11", "42", "2023-2024", "Nguyễn Văn A", "");
            dgvLopHoc.Rows.Add("10C1", "Lớp 10 Nâng cao 1", "10", "38", "2023-2024", "Lê Văn C", "");

            // Chọn mặc định cho ComboBox
            cmbKhoi.SelectedIndex = 2; // Khối 12
            cmbNamHoc.SelectedIndex = 0; // 2023-2024

            // Textbox mẫu
            txtMaLop.Text = "12A4";
            txtTenLop.Text = "Lớp 12 Chuyên Anh";
            txtSiSo.Text = "35";
            cmbGVCN.Text = "Trần Thị B";
        }

        private void DgvLopHoc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Chỉ vẽ cho cột Hành động (index 6) và không phải header
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
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