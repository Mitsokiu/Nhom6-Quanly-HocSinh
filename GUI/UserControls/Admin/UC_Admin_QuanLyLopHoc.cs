using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls.Admin
{
    public partial class UC_Admin_QuanLyLopHoc : UserControl
    {
        private readonly GradeBUS _gradeBUS;

        // Khai báo ErrorProvider
        private ErrorProvider errorProvider;

        public UC_Admin_QuanLyLopHoc()
        {
            InitializeComponent();

            // Khởi tạo các thành phần
            _gradeBUS = new GradeBUS();

            // Cấu hình ErrorProvider
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink; // Tắt nháy cho đỡ rối mắt

            LoadComboBoxGrade();
            LoadData();
        }

        // ... Các hàm LoadComboBoxGrade, LoadData, dgvClass_CellClick giữ nguyên ...

        private void LoadComboBoxGrade()
        {
            try
            {
                List<GradeDTO> grades = _gradeBUS.GetListGrade();
                cbGrade.DataSource = grades;
                cbGrade.DisplayMember = "Name";
                cbGrade.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khối: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                List<ClassDTO> list = ClassBUS.GetAllClasses();
                dgvClass.DataSource = list;

                // Format cột
                if (dgvClass.Columns["Id"] != null) dgvClass.Columns["Id"].HeaderText = "Mã lớp";
                if (dgvClass.Columns["ClassName"] != null) dgvClass.Columns["ClassName"].HeaderText = "Tên lớp";
                if (dgvClass.Columns["GradeId"] != null) dgvClass.Columns["GradeId"].HeaderText = "Mã Khối";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            if (cbGrade.Items.Count > 0) cbGrade.SelectedIndex = 0;

            // Xóa icon lỗi khi clear form
            errorProvider.Clear();
        }

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClass.Rows[e.RowIndex];
                txtID.Text = row.Cells["Id"].Value.ToString();
                txtName.Text = row.Cells["ClassName"].Value.ToString();

                if (row.Cells["GradeId"].Value != null)
                {
                    int gradeId = Convert.ToInt32(row.Cells["GradeId"].Value);
                    cbGrade.SelectedValue = gradeId;
                }

                // Khi chọn dòng mới thì xóa lỗi cũ đi
                errorProvider.Clear();
            }
        }

        // --- HÀM VALIDATE CHUNG CHO GUI ---
        private bool ValidateInput()
        {
            // Xóa hết lỗi cũ trước khi check
            errorProvider.Clear();
            bool isValid = true;

            // 1. Kiểm tra Tên lớp
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Vui lòng nhập tên lớp!");
                txtName.Focus(); // Focus vào ô lỗi
                isValid = false;
            }

            // 2. Kiểm tra Combobox (nếu cần thiết)
            // Nếu logic là bắt buộc chọn:
            if (isValid && cbGrade.SelectedValue == null)
            {
                errorProvider.SetError(cbGrade, "Vui lòng chọn khối!");
                cbGrade.Focus();
                isValid = false;
            }

            return isValid;
        }

        // --- SỰ KIỆN NÚT BẤM ---

        // 5. Thêm Lớp
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Bước 1: Validate tại GUI (Rỗng, chưa chọn...)
            if (!ValidateInput()) return;

            ClassDTO newClass = new ClassDTO
            {
                ClassName = txtName.Text.Trim(),
                GradeId = (int)cbGrade.SelectedValue
            };

            try
            {
                // Bước 2: Gọi BUS
                ClassBUS.AddClass(newClass);

                MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            }
            catch (ArgumentException argEx)
            {
                // Bước 3: Bắt lỗi nghiệp vụ từ BUS (Ví dụ: Trùng tên)
                // Hiển thị ErrorProvider ngay tại ô Tên lớp
                errorProvider.SetError(txtName, argEx.Message);
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. Cập nhật Lớp
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 1: Validate tại GUI
            if (!ValidateInput()) return;

            ClassDTO updateClass = new ClassDTO
            {
                Id = int.Parse(txtID.Text),
                ClassName = txtName.Text.Trim(),
                GradeId = (int)cbGrade.SelectedValue
            };

            try
            {
                ClassBUS.UpdateClass(updateClass);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            }
            catch (ArgumentException argEx)
            {
                // Bước 3: Bắt lỗi nghiệp vụ (Trùng tên khi sửa)
                errorProvider.SetError(txtName, argEx.Message);
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 7. Xóa Lớp
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lớp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtID.Text);
                    ClassBUS.DeleteClass(id);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            List<ClassDTO> list = ClassBUS.GetAllClasses();
            if (list != null)
            {
                var filteredList = list.Where(c => c.ClassName.ToLower().Contains(keyword)).ToList();
                dgvClass.DataSource = filteredList;
            }
        }
    }
}