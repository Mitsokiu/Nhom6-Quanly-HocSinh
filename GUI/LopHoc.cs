using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // Cần thêm namespace này
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Properties; // Cần thêm namespace này để dùng Resources

namespace GUI
{
    public partial class LopHoc : UserControl
    {
        public LopHoc()
        {
            InitializeComponent();

            // Gắn sự kiện CellPainting để vẽ các icon
            this.dgvHocSinh.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHocSinh_CellPainting);

            // Tải dữ liệu mẫu
            LoadSampleData();
        }

        /// <summary>
        /// Tải dữ liệu mẫu vào DataGridView
        /// </summary>
        private void LoadSampleData()
        {
            dgvHocSinh.Rows.Clear();

            // Thêm 5 hàng dữ liệu mẫu
            // Các cột icon (View, Edit, Delete) để là null, chúng ta sẽ vẽ chúng sau
            dgvHocSinh.Rows.Add(false, "HS001", "Nguyễn Văn A", "15/05/2008", "Nam", null, null, null);
            dgvHocSinh.Rows.Add(false, "HS002", "Trần Thị B", "20/08/2008", "Nữ", null, null, null);
            dgvHocSinh.Rows.Add(false, "HS003", "Lê Minh C", "10/01/2008", "Nam", null, null, null);
            dgvHocSinh.Rows.Add(false, "HS004", "Phạm Thuý D", "30/11/2008", "Nữ", null, null, null);
            dgvHocSinh.Rows.Add(false, "HS005", "Hoàng Quốc E", "02/03/2008", "Nam", null, null, null);
        }

        /// <summary>
        /// Sự kiện này vẽ thủ công các icon vào các ô hành động
        /// </summary>
        private void dgvHocSinh_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Bỏ qua header và các hàng không hợp lệ
            if (e.RowIndex < 0) return;

            // Vẽ nền mặc định của ô
            e.PaintBackground(e.ClipBounds, true);

            // Xác định icon cần vẽ dựa trên tên cột
            Image icon = null;
            string colName = dgvHocSinh.Columns[e.ColumnIndex].Name;

            try {
                //{
                //    switch (colName)
                //    {
                //        case "colView":
                //            icon = Resources.; // Lấy icon từ Resources
                //            break;
                //        case "colEdit":
                //            icon = Resources.edit_icon; // Lấy icon từ Resources
                //            break;
                //        case "colDelete":
                //            icon = Resources.delete_icon; // Lấy icon từ Resources
                //            break;
                //    }

                // Nếu cột này có icon, chúng ta sẽ vẽ nó vào giữa ô
                if (icon != null)
                {
                    e.Handled = true; // Báo cho DataGridView là chúng ta đã tự xử lý việc vẽ

                    // Tính toán vị trí để căn giữa icon (giả sử icon 16x16)
                    int iconWidth = 16;
                    int iconHeight = 16;
                    int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                    // Vẽ icon
                    e.Graphics.DrawImage(icon, x, y, iconWidth, iconHeight);
                }
            }
            catch (Exception)
            {
                // Nếu icon chưa được thêm vào Resources, bỏ qua lỗi để chương trình không crash
            }
        }


        // ----- Các sự kiện cũ của bạn -----

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnThemHocSinh_Click(object sender, EventArgs e)
        {
            ThemHocSinh themHocSinhForm = new ThemHocSinh();
            themHocSinhForm.ShowDialog();

            // Optional: Sau khi form thêm đóng, bạn có thể gọi LoadSampleData() 
            // hoặc hàm tải dữ liệu thật để làm mới danh sách
            // LoadSampleData(); 
        }
    }
}