using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_ThongBao : UserControl
    {
        public UC_Admin_ThongBao()
        {
            InitializeComponent();
            LoadRoleCombo();
            LoadData();
        }
        private void LoadRoleCombo()
        {
            comboBoxrole.Items.Clear();
            comboBoxrole.Items.Add("gvcn");
            comboBoxrole.Items.Add("gvbm");
            comboBoxrole.Items.Add("student");
            comboBoxrole.Items.Add("parent");
            comboBoxrole.Items.Add("all");
            comboBoxrole.SelectedIndex = 0;
        }

        private void LoadData()
        {
            var dt = NotificationBUS.GetAll();

            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row["id"],           // tương ứng với cột ID
                    row["target_role"],  // tương ứng với cột Target
                    row["title"],        // title
                    row["message"],      // tương ứng với cột mes
                    row["created_at"]    // tương ứng với cột Date
                );
            }
        }


        // Làm sạch form
        private void ClearForm()
        {
            
            textBoxtitle.Clear();
            textBoxmes.Clear();
            comboBoxrole.SelectedIndex = 0;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(comboBoxrole.SelectedItem?.ToString()))
            {
                MessageBox.Show("Vui lòng chọn người nhận!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxtitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxmes.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung!");
                return false;
            }

            return true;
        }


        // Thêm thông báo
        private void btnadd_Click(object sender, EventArgs e)
        {

            if (!ValidateForm()) return;
            NotificationDTO n = new NotificationDTO()
            {
                TargetRole = comboBoxrole.SelectedItem?.ToString(),
                Title = textBoxtitle.Text,
                Message = textBoxmes.Text,
                CreatedAt = dateTimePicker1.Value
            };

            if (NotificationBUS.Add(n))
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }


      
        // Sửa thông báo
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            if (!ValidateForm()) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            NotificationDTO n = new NotificationDTO()
            {
                Id = id,
                TargetRole = comboBoxrole.SelectedItem?.ToString(),
                Title = textBoxtitle.Text,
                Message = textBoxmes.Text,
                CreatedAt = dateTimePicker1.Value
            };

            if (NotificationBUS.Edit(n))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }


        // Xóa thông báo
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa thông báo này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            if (NotificationBUS.Remove(id))
            {
                MessageBox.Show("Xóa thành công");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

       

        //Khi click lên bảng → đổ dữ liệu vào form
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            comboBoxrole.SelectedItem = row.Cells["Target"].Value?.ToString() ?? "";
            textBoxtitle.Text = row.Cells["title"].Value?.ToString() ?? "";
            textBoxmes.Text = row.Cells["mes"].Value?.ToString() ?? "";

            if (row.Cells["Date"].Value != null && DateTime.TryParse(row.Cells["Date"].Value.ToString(), out DateTime dt))
                dateTimePicker1.Value = dt;
            else
                dateTimePicker1.Value = DateTime.Now; 
        }


        private void BtnExportPDF_Selected_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"ThongBao_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        var bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        var font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                        var fontBold = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

                        Paragraph title = new Paragraph("THÔNG BÁO", fontBold);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 10f;
                        doc.Add(title);

                        PdfPTable table = new PdfPTable(2);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 25f, 75f });

                        // Lấy dữ liệu từ DataGridView và TextBox
                        string target = dataGridView1.CurrentRow.Cells["Target"].Value?.ToString() ?? "";
                        string header = textBoxtitle.Text.Trim();
                        string message = textBoxmes.Text.Trim();
                        string createdAt = dateTimePicker1.Value.ToString("dd/MM/yyyy");

                        // Thêm các dòng
                        table.AddCell(new PdfPCell(new Phrase("Người nhận", fontBold)) { Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(target, font)) { Padding = 5 });

                        table.AddCell(new PdfPCell(new Phrase("Tiêu đề", fontBold)) { Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(header, font)) { Padding = 5 });

                        table.AddCell(new PdfPCell(new Phrase("Nội dung", fontBold)) { Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(message, font)) { Padding = 5 });

                        table.AddCell(new PdfPCell(new Phrase("Ngày tạo", fontBold)) { Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(createdAt, font)) { Padding = 5 });

                        doc.Add(table);

                        doc.Close();
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
