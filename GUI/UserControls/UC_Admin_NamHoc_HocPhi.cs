using System;
using System.Data;
using System.Windows.Forms;
using BUS;
using ClosedXML.Excel;
using System.IO;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_HocPhi : UserControl
    {
        private AcademicYearBUS yearBUS = new AcademicYearBUS();
        private ClassBUS classBUS = new ClassBUS();
        private TuitionBUS tuitionBUS = new TuitionBUS();

        private int selectedTuitionId = 0;

        public UC_Admin_NamHoc_HocPhi()
        {
            InitializeComponent();

            // Thiết lập event
            this.Load += UC_Admin_NamHoc_HocPhi_Load;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;
            button3.Click += button3_Click;

            // Các setup DataGridView: bind tên cột với DataPropertyName
            SetupDataGridViewColumns();
        }

        private void UC_Admin_NamHoc_HocPhi_Load(object sender, EventArgs e)
        {
            LoadYears();
        }

        private void SetupDataGridViewColumns()
        {
            // Không sinh cột tự động, dùng cột đã tạo trong designer
            dataGridView1.AutoGenerateColumns = false;

            // Gán DataPropertyName để map với DataTable column names
            Hoten.DataPropertyName = "Hoten";
            NgaySinh.DataPropertyName = "NgaySinh";
            Lop.DataPropertyName = "Lop";
            KhoanThu.DataPropertyName = "KhoanThu";
            SoTien.DataPropertyName = "SoTien";
            TrangThai.DataPropertyName = "TrangThai";

            // Tạo cột hidden cho tuition_id
            if (!dataGridView1.Columns.Contains("tuition_id"))
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = "tuition_id";
                col.HeaderText = "tuition_id";
                col.DataPropertyName = "tuition_id";
                col.Visible = false;
                dataGridView1.Columns.Add(col);
            }
        }

        private void LoadYears()
        {
            try
            {
                DataTable dt = yearBUS.GetAllYear();
                if (dt == null) return;

                // Thêm lựa chọn "Tất cả" (value 0)
                DataRow dr = dt.NewRow();
                dr["year_id"] = 0;
                dr["name"] = "-- Chọn năm --";
                dt.Rows.InsertAt(dr, 0);

                comboBox3.DisplayMember = "name";
                comboBox3.ValueMember = "year_id";
                comboBox3.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load năm: " + ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue == null) return;
            int yearId;
            if (!int.TryParse(comboBox3.SelectedValue.ToString(), out yearId)) return;
            LoadClassesByYear(yearId);
        }

        private void LoadClassesByYear(int yearId)
        {
            try
            {
                DataTable dt = ClassBUS.GetClassesByYear(yearId) ?? new DataTable();

                // Thêm lựa chọn "Tất cả"
                DataRow dr = dt.NewRow();
                dr["class_id"] = 0;
                dr["class_name"] = "-- Tất cả lớp --";
                dt.Rows.InsertAt(dr, 0);

                comboBox1.DisplayMember = "class_name";
                comboBox1.ValueMember = "class_id";
                comboBox1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lớp: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTuitionData();
        }

        private void LoadTuitionData()
        {
            try
            {
                int yearId = 0;
                int classId = 0;
                if (comboBox3.SelectedValue != null)
                    int.TryParse(comboBox3.SelectedValue.ToString(), out yearId);
                if (comboBox1.SelectedValue != null)
                    int.TryParse(comboBox1.SelectedValue.ToString(), out classId);

                DataTable dt = tuitionBUS.GetTuitionByYearAndClass(yearId, classId);
                if (dt == null) dt = new DataTable();

                // Gán DataSource
                dataGridView1.DataSource = dt;

                // Nếu muốn định dạng Số Tiền:
                if (dataGridView1.Columns["SoTien"] != null)
                {
                    // chuyển kiểu hiển thị, đảm bảo cột là DataGridViewTextBoxColumn
                    dataGridView1.Columns["SoTien"].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load học phí: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                var row = dataGridView1.Rows[e.RowIndex];

                // Một số cột có thể null => kiểm tra an toàn
                textBox2.Text = row.Cells["Hoten"].Value?.ToString() ?? string.Empty;
                var ngay = row.Cells["NgaySinh"].Value;
                textBox2.Text = textBox2.Text; // họ tên ở textBox2 theo designer

                // Nếu bạn có các textbox khác (ở ví dụ dùng textBox3 = KhoảnThu, textBox1 = SoTien)
                textBox3.Text = row.Cells["KhoanThu"].Value?.ToString() ?? string.Empty;
                textBox1.Text = row.Cells["SoTien"].Value?.ToString() ?? string.Empty;
                comboBox2.Text = row.Cells["TrangThai"].Value?.ToString() ?? string.Empty;

                // lấy tuition_id ẩn
                var idCell = row.Cells["tuition_id"].Value;
                selectedTuitionId = idCell == null ? 0 : Convert.ToInt32(idCell);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTuitionId == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khoản thu để cập nhật.");
                    return;
                }

                string newStatus = comboBox2.Text.Trim().ToLower();
                if (newStatus != "paid" && newStatus != "unpaid")
                {
                    MessageBox.Show("Trạng thái không hợp lệ. Chọn 'paid' hoặc 'unpaid'.");
                    return;
                }

                bool ok = tuitionBUS.UpdateStatus(selectedTuitionId, newStatus);
                if (ok)
                {
                    MessageBox.Show("Cập nhật trạng thái thành công.");
                    LoadTuitionData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }
        private void ExportToExcel(DataGridView dgv)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
            sfd.FileName = "HocPhi.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("HocPhi");

                // Ghi header
                int colIndex = 1;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible) continue;
                    ws.Cell(1, colIndex).Value = col.HeaderText;
                    colIndex++;
                }

                // Ghi data
                int rowIndex = 2;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    colIndex = 1;

                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (!col.Visible) continue;
                        ws.Cell(rowIndex, colIndex).Value = row.Cells[col.Name].Value?.ToString();
                        colIndex++;
                    }

                    rowIndex++;
                }

                wb.SaveAs(sfd.FileName);
            }

            MessageBox.Show("Xuất Excel thành công");
        }
        private void buttonExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

    }
}
