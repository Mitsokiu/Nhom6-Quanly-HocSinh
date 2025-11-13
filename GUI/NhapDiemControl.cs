using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class NhapDiemControl : UserControl
    {
        public NhapDiemControl()
        {
            InitializeComponent();

            // Thêm các sự kiện để tùy chỉnh giao diện DataGridView
            this.dgvDiem.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDiem_CellPainting);
            this.dgvDiem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDiem_CellFormatting);

            // Tải dữ liệu mẫu khi control được khởi tạo
            LoadSampleData();
        }

        /// <summary>
        /// Tải dữ liệu mẫu vào DataGridView
        /// </summary>
        private void LoadSampleData()
        {
            dgvDiem.Rows.Clear();

            // Thêm 5 hàng dữ liệu giống hệt trong thiết kế
            dgvDiem.Rows.Add("1", "HS001", "Trần Minh Anh", "8.5", "9.0", "7.5", "8.0", "8.2");
            dgvDiem.Rows.Add("2", "HS002", "Lê Thị Bích", "9.0", "8.0", "8.5", "9.5", "8.8");
            dgvDiem.Rows.Add("3", "HS003", "Phạm Văn Cường", "7.0", "6.5", "7.0", "8.0", "7.2");
            dgvDiem.Rows.Add("4", "HS004", "Nguyễn Thuỳ Dung", "11", "9.5", "9.0", "8.5", "Lỗi");
            dgvDiem.Rows.Add("5", "HS005", "Hoàng Minh Hải", "", "", "", "", "-");
        }

        /// <summary>
        /// Sự kiện này định dạng lại text (ví dụ: đổi màu chữ "Lỗi" sang đỏ)
        /// </summary>
        private void dgvDiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đây là cột "Điểm TB"
            if (dgvDiem.Columns[e.ColumnIndex].Name == "colDiemTB")
            {
                if (e.Value != null)
                {
                    string value = e.Value.ToString();
                    if (value == "Lỗi")
                    {
                        // Đổi màu chữ thành Đỏ và in đậm
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                    else if (value == "-")
                    {
                        // Đổi màu chữ thành Xám
                        e.CellStyle.ForeColor = Color.Gray;
                    }
                }
            }
        }

        /// <summary>
        /// Sự kiện này vẽ lại các ô điểm để trông giống TextBox
        /// </summary>
        private void dgvDiem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Bỏ qua header và các hàng không hợp lệ
            if (e.RowIndex < 0) return;

            // Lấy tên các cột cần vẽ lại
            string colName = dgvDiem.Columns[e.ColumnIndex].Name;
            bool isEditableScoreColumn = colName == "colDiemMieng" ||
                                         colName == "colDiem15p" ||
                                         colName == "colDiemGiuaKy" ||
                                         colName == "colDiemCuoiKy";

            // Chỉ vẽ lại các ô điểm có thể chỉnh sửa
            if (isEditableScoreColumn)
            {
                e.Handled = true; // Báo cho DataGridView là chúng ta sẽ tự vẽ ô này

                // 1. Vẽ nền (tô màu trắng hoặc màu khi được chọn)
                using (Brush backColorBrush = new SolidBrush(e.State.HasFlag(DataGridViewElementStates.Selected) ? e.CellStyle.SelectionBackColor : Color.White))
                {
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                }

                // 2. Chuẩn bị bút vẽ viền (border)
                Color borderColor = Color.Gainsboro; // Màu viền mặc định
                float borderWidth = 1;

                // Kiểm tra giá trị không hợp lệ (như "11") để vẽ viền đỏ
                if (e.Value != null && e.Value.ToString() == "11")
                {
                    borderColor = Color.Red;
                    borderWidth = 2; // Viền đậm hơn
                }

                // 3. Vẽ viền (hình chữ nhật)
                // Thu nhỏ hình chữ nhật lại để tạo padding
                Rectangle borderRect = e.CellBounds;
                borderRect.X += 5;
                borderRect.Y += 5;
                borderRect.Width -= 10;
                borderRect.Height -= 10;

                using (Pen borderPen = new Pen(borderColor, borderWidth))
                {
                    e.Graphics.DrawRectangle(borderPen, borderRect);
                }

                // 4. Vẽ giá trị (văn bản) vào trong ô
                string text = e.FormattedValue?.ToString();
                if (!string.IsNullOrEmpty(text))
                {
                    Color textColor = e.CellStyle.ForeColor;
                    if (e.State.HasFlag(DataGridViewElementStates.Selected))
                    {
                        textColor = e.CellStyle.SelectionForeColor;
                    }

                    // Nếu giá trị là "11", đổi màu chữ thành Đỏ
                    if (e.Value != null && e.Value.ToString() == "11")
                    {
                        textColor = Color.Red;
                    }

                    // Căn giữa nội dung trong ô
                    TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font,
                        borderRect, textColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }
    }
}