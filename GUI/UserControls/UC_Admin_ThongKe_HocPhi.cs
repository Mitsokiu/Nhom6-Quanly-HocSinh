using BUS;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.UserControls
{
    public partial class UC_Admin_ThongKe_HocPhi : UserControl
    {
        private StatisticBUS statBUS = new StatisticBUS();

        public UC_Admin_ThongKe_HocPhi()
        {
            InitializeComponent();
        }

        private void UC_Admin_ThongKe_HocPhi_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                LoadComboBoxes();
                if (cboSemester.Items.Count > 0) cboSemester.SelectedIndex = 0;
                if (cboGrade.Items.Count > 0) cboGrade.SelectedIndex = 0;

                // Load lần đầu
                if (cboSemester.SelectedValue != null)
                {
                    btnFilter_Click(null, null);
                }
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load Học kỳ
                DataTable dtSem = statBUS.GetSemesters();
                cboSemester.DataSource = dtSem;
                cboSemester.DisplayMember = "semester_display";
                cboSemester.ValueMember = "semester_id";

                // Load Khối
                DataTable dtGrade = statBUS.GetGradeLevels();
                DataRow dr = dtGrade.NewRow();
                dr["grade_id"] = 0;
                dr["grade_name"] = "Tất cả các khối";
                dtGrade.Rows.InsertAt(dr, 0);

                cboGrade.DataSource = dtGrade;
                cboGrade.DisplayMember = "grade_name";
                cboGrade.ValueMember = "grade_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cboSemester.SelectedValue == null || cboGrade.SelectedValue == null) return;

            if (int.TryParse(cboSemester.SelectedValue.ToString(), out int semId) &&
                int.TryParse(cboGrade.SelectedValue.ToString(), out int gradeId))
            {
                // Truyền gradeId vào tất cả các hàm
                LoadFinancialSummary(semId, gradeId);
                LoadChart(semId, gradeId);
                LoadUnpaidList(semId, gradeId);
            }
        }

        // Cập nhật: Thêm tham số gradeId
        private void LoadFinancialSummary(int semId, int gradeId)
        {
            try
            {
                DataTable dt = statBUS.GetTuitionSummary(semId, gradeId);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    decimal total = row["TotalReceivable"] != DBNull.Value ? Convert.ToDecimal(row["TotalReceivable"]) : 0;
                    decimal paid = row["TotalPaid"] != DBNull.Value ? Convert.ToDecimal(row["TotalPaid"]) : 0;
                    decimal debt = row["TotalDebt"] != DBNull.Value ? Convert.ToDecimal(row["TotalDebt"]) : 0;

                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    lblTotal.Text = total.ToString("#,###", cul.NumberFormat) + " VNĐ";
                    lblPaid.Text = paid.ToString("#,###", cul.NumberFormat) + " VNĐ";
                    lblDebt.Text = debt.ToString("#,###", cul.NumberFormat) + " VNĐ";
                }
                else
                {
                    lblTotal.Text = "0 VNĐ";
                    lblPaid.Text = "0 VNĐ";
                    lblDebt.Text = "0 VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tổng quan tài chính: " + ex.Message);
            }
        }

        // Cập nhật: Thêm tham số gradeId
        private void LoadChart(int semId, int gradeId)
        {
            try
            {
                DataTable dt = statBUS.GetTuitionCountStatus(semId, gradeId);
                chartTuition.Series[0].Points.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    string statusRaw = r["Trạng Thái"].ToString();
                    double count = Convert.ToDouble(r["Số Lượng"]);

                    string label = statusRaw == "paid" ? "Đã Đóng" : "Chưa Đóng";
                    int idx = chartTuition.Series[0].Points.AddXY(label, count);

                    chartTuition.Series[0].Points[idx].Color = statusRaw == "paid" ? Color.FromArgb(46, 204, 113) : Color.FromArgb(231, 76, 60);
                }

                // Nếu không có dữ liệu thì hiện thông báo trống hoặc clear
                if (dt.Rows.Count == 0)
                {
                    chartTuition.Series[0].Points.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ: " + ex.Message);
            }
        }

        private void LoadUnpaidList(int semId, int gradeId)
        {
            try
            {
                DataTable dt = statBUS.GetUnpaidStudents(semId, gradeId);
                dgvUnpaid.DataSource = dt;

                if (dgvUnpaid.Columns["Số Tiền Nợ"] != null)
                {
                    dgvUnpaid.Columns["Số Tiền Nợ"].DefaultCellStyle.Format = "N0";
                    dgvUnpaid.Columns["Số Tiền Nợ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvUnpaid.Columns["Hạn Nộp"] != null)
                {
                    dgvUnpaid.Columns["Hạn Nộp"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nợ: " + ex.Message);
            }
        }

        // --- CHỨC NĂNG XUẤT EXCEL (EPPlus - .xlsx) ---
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (dgvUnpaid.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thiết lập License (Giống code mẫu bạn gửi)
            // Lưu ý: Nếu phiên bản EPPlus mới, dòng này rất quan trọng để tránh lỗi LicenseException
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            }
            catch
            {
                 ExcelPackage.License.SetNonCommercialPersonal("Loopy");
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.FileName = $"DanhSachNoHocPhi_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var package = new ExcelPackage())
                        {
                            // Tạo Sheet
                            var worksheet = package.Workbook.Worksheets.Add("DS_NoHocPhi");

                            // 1. Tạo Header từ DataGridView
                            for (int i = 0; i < dgvUnpaid.Columns.Count; i++)
                            {
                                // Gán giá trị tiêu đề
                                worksheet.Cells[1, i + 1].Value = dgvUnpaid.Columns[i].HeaderText;

                                // Style cho Header (Xanh lá nhạt, Chữ đậm, Viền) - Giống mẫu UC_GVCN_QLHS
                                var cell = worksheet.Cells[1, i + 1];
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            // 2. Đổ dữ liệu từ DataGridView vào Excel
                            for (int i = 0; i < dgvUnpaid.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvUnpaid.Columns.Count; j++)
                                {
                                    var cellValue = dgvUnpaid.Rows[i].Cells[j].Value;
                                    var excelCell = worksheet.Cells[i + 2, j + 1];

                                    // Xử lý định dạng ngày tháng và số tiền
                                    if (dgvUnpaid.Columns[j].Name == "Hạn Nộp" && cellValue != DBNull.Value)
                                    {
                                        excelCell.Value = Convert.ToDateTime(cellValue);
                                        excelCell.Style.Numberformat.Format = "dd/MM/yyyy";
                                    }
                                    else if (dgvUnpaid.Columns[j].Name == "Số Tiền Nợ" && cellValue != DBNull.Value)
                                    {
                                        excelCell.Value = Convert.ToDouble(cellValue);
                                        excelCell.Style.Numberformat.Format = "#,##0";
                                    }
                                    else
                                    {
                                        excelCell.Value = cellValue?.ToString();
                                    }

                                    // Thêm viền cho từng ô dữ liệu cho đẹp
                                    excelCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }
                            }

                            // 3. Tự động chỉnh độ rộng cột
                            worksheet.Cells.AutoFitColumns();

                            // 4. Lưu file
                            package.SaveAs(new FileInfo(sfd.FileName));
                        }

                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file sau khi xuất (Tùy chọn)
                        try { System.Diagnostics.Process.Start(sfd.FileName); } catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}