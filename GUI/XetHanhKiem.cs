using BUS;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class XetHanhKiem : Form
    {
        private StudentEvaluationDTO dto;
        private int semesterId;
        private EvaluationBUS evalBus = new EvaluationBUS();

        public XetHanhKiem(StudentEvaluationDTO dtoInput, int semesterIdInput)
        {
            InitializeComponent(); // QUAN TRỌNG: Hàm này gọi code bên Designer

            this.dto = dtoInput;
            this.semesterId = semesterIdInput;

            LoadData();

            // Gán sự kiện Click
            // (Nếu muốn gán trong Designer thì double click vào nút ở chế độ Design)
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void LoadData()
        {
            // Đổ dữ liệu từ DTO vào Form
            lblName.Text = dto.FullName;
            lblInfo.Text = $"Mã số: {dto.StudentCode}";

            if (!string.IsNullOrEmpty(dto.Conduct))
            {
                if (cbbConduct.Items.Contains(dto.Conduct))
                    cbbConduct.SelectedItem = dto.Conduct;
                else
                    cbbConduct.SelectedIndex = 0;
            }
            else
            {
                cbbConduct.SelectedIndex = 0; // Mặc định Tốt
            }

            txtComment.Text = dto.TeacherComment;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra khóa sổ (Gọi BUS)
            if (evalBus.IsEvaluationLocked(semesterId))
            {
                MessageBox.Show("Học kỳ này đã khóa sổ, không thể chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu mới
            string newConduct = cbbConduct.SelectedItem != null ? cbbConduct.SelectedItem.ToString() : "Tốt";
            string newComment = txtComment.Text.Trim();

            // Gọi BUS lưu
            if (evalBus.SaveEvaluation(dto.StudentId, dto.ClassId, semesterId, newConduct, newComment))
            {
                MessageBox.Show("Lưu đánh giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo OK để form cha load lại
                this.Close();
            }
            else
            {
                MessageBox.Show("Lưu thất bại, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}