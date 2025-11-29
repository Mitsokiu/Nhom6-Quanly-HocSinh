using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_HocPhi_PhieuThu : UserControl
    {
        private TuitionBUS tuitionBUS = new TuitionBUS();
        private List<TuitionDTO> currentTuitionList = new List<TuitionDTO>();

        private int pageSize = 10;           // số dòng mỗi trang
        private int currentPage = 1;         // trang hiện tại
        private int totalPage = 1;           // tổng số trang
        private List<TuitionDTO> allTuition; // toàn bộ dữ liệu đã lọc trùng


        public UC_Admin_NamHoc_HocPhi_PhieuThu()
        {
            InitializeComponent();
            LoadTuitionData();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

      
        //private void LoadTuitionData()
        //{
        //    dataGridView1.Rows.Clear();
        //    var list = tuitionBUS.GetAllTuition(); // lấy tất cả học phí

        //    // Lọc trùng theo name + Amount + DueDate
        //    var uniqueList = new List<TuitionDTO>();
        //    var seen = new HashSet<string>();

        //    foreach (var t in list)
        //    {
        //        string key = $"{t.name}_{t.Amount}_{t.DueDate:yyyyMMdd}";
        //        if (!seen.Contains(key))
        //        {
        //            seen.Add(key);
        //            uniqueList.Add(t);
        //        }
        //    }

        //    currentTuitionList = uniqueList; // lưu danh sách đã lọc

        //    foreach (var t in uniqueList)
        //    {
        //        dataGridView1.Rows.Add(t.name ?? "", t.Amount, t.DueDate.ToString("dd/MM/yyyy"));
        //    }
        //}
        private void LoadTuitionData()
        {
            var list = tuitionBUS.GetAllTuition();

            // Lọc trùng theo name + Amount + DueDate
            var uniqueList = new List<TuitionDTO>();
            var seen = new HashSet<string>();
            foreach (var t in list)
            {
                string key = $"{t.name}_{t.Amount}_{t.DueDate:yyyyMMdd}";
                if (!seen.Contains(key))
                {
                    seen.Add(key);
                    uniqueList.Add(t);
                }
            }

            allTuition = uniqueList;

            totalPage = Math.Max(1, (int)Math.Ceiling(allTuition.Count / (double)pageSize));
            currentPage = 1;

            LoadPage(currentPage);
        }
        private void LoadPage(int page)
        {
            dataGridView1.Rows.Clear();

            currentPage = Math.Min(Math.Max(1, page), totalPage);

            int start = (currentPage - 1) * pageSize;
            var pageData = allTuition.Skip(start).Take(pageSize).ToList();

            foreach (var t in pageData)
            {
                dataGridView1.Rows.Add(t.name ?? "", t.Amount, t.DueDate.ToString("dd/MM/yyyy"));
            }

            // hiển thị số trang
           lblpage.Text = $"{currentPage}/{totalPage}";

            // Enable/disable nút
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPage;
            btnLast.Enabled = currentPage < totalPage;
        }


        // Khi chọn hàng trên DataGridView, hiển thị dữ liệu lên TextBox và DateTimePicker
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var row = dataGridView1.CurrentRow;
            textBox2.Text = row.Cells[0].Value?.ToString() ?? "";
            textBox3.Text = row.Cells[1].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells[2].Value?.ToString(), out DateTime dueDate))
                dateTimePicker1.Value = dueDate;
        }

        // Thêm học phí cho tất cả học sinh
        private void Button4_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            if (!decimal.TryParse(textBox3.Text, out decimal amount))
            {
                MessageBox.Show("Số tiền không hợp lệ");
                return;
            }
            DateTime dueDate = dateTimePicker1.Value;

            bool success = tuitionBUS.AddTuitionForAllStudents(name, amount, dueDate);

            if (success)
            {
                MessageBox.Show("Thêm học phí thành công");
                LoadTuitionData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        // Sửa học phí
        //private void button5_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.CurrentRow == null) return;

        //    int index = dataGridView1.CurrentRow.Index;
        //    var tuition = currentTuitionList[index]; // lấy DTO từ danh sách

        //    string name = textBox2.Text;
        //    if (!decimal.TryParse(textBox3.Text, out decimal amount))
        //    {
        //        MessageBox.Show("Số tiền không hợp lệ");
        //        return;
        //    }
        //    DateTime dueDate = dateTimePicker1.Value;

        //    bool success = tuitionBUS.UpdateTuition(tuition.TuitionId, name, amount, dueDate);

        //    if (success)
        //    {
        //        MessageBox.Show("Cập nhật thành công");
        //        LoadTuitionData();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cập nhật thất bại");
        //    }
        //}
        // Sửa hàm Sửa học phí
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int index = dataGridView1.CurrentRow.Index;
            var tuition = currentTuitionList[index]; // DTO từ danh sách

            string name = textBox2.Text;
            if (!decimal.TryParse(textBox3.Text, out decimal amount))
            {
                MessageBox.Show("Số tiền không hợp lệ");
                return;
            }
            DateTime dueDate = dateTimePicker1.Value;

            // Truyền thông tin cũ + mới cho BUS
            bool success = tuitionBUS.UpdateTuition(
                tuition.name, tuition.Amount, tuition.DueDate, // thông tin cũ
                name, amount, dueDate                           // thông tin mới
            );

            if (success)
            {
                MessageBox.Show("Cập nhật thành công");
                LoadTuitionData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

   


        // Xóa học phí
        //private void button6_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.CurrentRow == null) return;

        //    int index = dataGridView1.CurrentRow.Index;
        //    var tuition = currentTuitionList[index]; // lấy DTO từ danh sách

        //    var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
        //    if (confirm == DialogResult.Yes)
        //    {
        //        bool success = tuitionBUS.DeleteTuition(tuition.TuitionId);
        //        if (success)
        //        {
        //            MessageBox.Show("Xóa thành công");
        //            LoadTuitionData();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa thất bại");
        //        }
        //    }
        //}
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int index = dataGridView1.CurrentRow.Index;
            var tuition = currentTuitionList[index]; // DTO từ danh sách

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool success = tuitionBUS.DeleteTuition(
                    tuition.name, tuition.Amount, tuition.DueDate // dùng thông tin cũ để xóa tất cả bản ghi trùng
                );

                if (success)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadTuitionData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            LoadPage(1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
                LoadPage(currentPage - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
                LoadPage(currentPage + 1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            LoadPage(totalPage);
        }

        // Các nút khác (tạm để trống hoặc gọi sự kiện riêng)
        private void button1_Click(object sender, EventArgs e)
        {
            // Quản lý học phí
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thiết lập khoảng thu
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_Admin_NamHoc_HocPhi_PhieuThu_Load(object sender, EventArgs e)
        {

        }
    }
}
