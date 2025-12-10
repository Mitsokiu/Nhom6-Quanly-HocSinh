using BUS;
using ClosedXML.Excel;
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

        private List<TuitionDTO> allTuition = new List<TuitionDTO>(); // Data đã lọc trùng
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalPage = 1;

        public UC_Admin_NamHoc_HocPhi_PhieuThu()
        {
            InitializeComponent();
            LoadTuitionData();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        // ============================================================
        // Tải dữ liệu + lọc trùng + phân trang
        // ============================================================
        private void LoadTuitionData()
        {
            var list = tuitionBUS.GetAllTuition();

            // Lọc trùng theo name + amount + dueDate
            var unique = new List<TuitionDTO>();
            var seen = new HashSet<string>();

            foreach (var t in list)
            {
                string key = $"{t.name}_{t.Amount}_{t.DueDate:yyyyMMdd}";
                if (!seen.Contains(key))
                {
                    seen.Add(key);
                    unique.Add(t);
                }
            }

            allTuition = unique;

            totalPage = Math.Max(1, (int)Math.Ceiling(allTuition.Count / (double)pageSize));
            currentPage = 1;

            LoadPage(1);
        }

        private void LoadPage(int page)
        {
            dataGridView1.Rows.Clear();

            currentPage = Math.Max(1, Math.Min(page, totalPage));

            int start = (currentPage - 1) * pageSize;
            var pageData = allTuition.Skip(start).Take(pageSize).ToList();

            foreach (var t in pageData)
            {
                dataGridView1.Rows.Add(t.name, t.Amount, t.DueDate.ToString("dd/MM/yyyy"));
            }

            lblpage.Text = $"{currentPage}/{totalPage}";

            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPage;
            btnLast.Enabled = currentPage < totalPage;
        }

        // ============================================================
        // Khi chọn dòng → hiển thị lên textbox
        // ============================================================
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value?.ToString() ?? "";
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? "";

            if (DateTime.TryParse(dataGridView1.CurrentRow.Cells[2].Value?.ToString(), out DateTime dt))
                dateTimePicker1.Value = dt;
        }

        // ============================================================
        // Thêm học phí cho toàn bộ học sinh
        // ============================================================
        private void Btnadd_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;

            if (!decimal.TryParse(textBox3.Text, out decimal amount))
            {
                MessageBox.Show("Số tiền không hợp lệ");
                return;
            }

            DateTime dueDate = dateTimePicker1.Value;

            bool ok = tuitionBUS.AddTuitionForAllStudents(name, amount, dueDate);

            if (ok)
            {
                MessageBox.Show("Thêm thành công");
                LoadTuitionData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        // ============================================================
        // Sửa học phí
        // ============================================================
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int index = (currentPage - 1) * pageSize + dataGridView1.CurrentRow.Index;
            if (index < 0 || index >= allTuition.Count) return;

            var old = allTuition[index];

            string newName = textBox2.Text;
            if (!decimal.TryParse(textBox3.Text, out decimal newAmount))
            {
                MessageBox.Show("Số tiền không hợp lệ");
                return;
            }
            DateTime newDueDate = dateTimePicker1.Value;

            bool ok = tuitionBUS.UpdateTuition(
                old.name, old.Amount, old.DueDate,
                newName, newAmount, newDueDate
            );

            if (ok)
            {
                MessageBox.Show("Cập nhật thành công");
                LoadTuitionData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        // ============================================================
        // Xóa học phí
        // ============================================================
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int index = (currentPage - 1) * pageSize + dataGridView1.CurrentRow.Index;
            if (index < 0 || index >= allTuition.Count) return;

            var old = allTuition[index];

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes) return;

            bool ok = tuitionBUS.DeleteTuition(old.name, old.Amount, old.DueDate);

            if (ok)
            {
                MessageBox.Show("Xóa thành công");
                LoadTuitionData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }


        private void ExportToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel File (*.xlsx)|*.xlsx",
                FileName = "DanhSachHocPhi.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("HocPhi");

                    int col = 1;

                    // Xuất tiêu đề cột
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (!column.Visible)
                            continue;

                        var cell = ws.Cell(1, col);
                        cell.Value = column.HeaderText;

                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        col++;
                    }

                    // Xuất dữ liệu
                    int row = 2;
                    foreach (DataGridViewRow dgvRow in dgv.Rows)
                    {
                        if (dgvRow.IsNewRow)
                            continue;

                        col = 1;
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            if (!column.Visible)
                                continue;

                            var cell = ws.Cell(row, col);
                            var value = dgvRow.Cells[column.Index].Value;

                            if (value is DateTime dt)
                            {
                                cell.Value = dt;
                                cell.Style.DateFormat.Format = "dd/MM/yyyy";
                            }
                            else
                            {
                                cell.Value = value?.ToString();
                            }

                            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                            col++;
                        }

                        row++;
                    }

                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Xuất Excel thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }




        // ============================================================
        // Điều hướng phân trang
        // ============================================================
        private void btnFirst_Click(object sender, EventArgs e) => LoadPage(1);
        private void btnPrev_Click(object sender, EventArgs e) => LoadPage(currentPage - 1);
        private void btnNext_Click(object sender, EventArgs e) => LoadPage(currentPage + 1);
        private void btnLast_Click(object sender, EventArgs e) => LoadPage(totalPage);
    }
}
