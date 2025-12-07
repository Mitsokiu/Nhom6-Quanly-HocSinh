using BUS;
using DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls.Admin
{
    public partial class UC_Admin_QuanLyMonHoc : UserControl
    {
        private SubjectBUS bus;
        private ErrorProvider errorProvider;

        public UC_Admin_QuanLyMonHoc()
        {
            InitializeComponent();
            bus = new SubjectBUS();
            errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvData.DataSource = bus.GetAll();
                if (dgvData.Columns["SubjectId"] != null) dgvData.Columns["SubjectId"].HeaderText = "Mã môn";
                if (dgvData.Columns["SubjectName"] != null) dgvData.Columns["SubjectName"].HeaderText = "Tên môn học";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvData.Rows[e.RowIndex];
                txtID.Text = row.Cells["SubjectId"].Value.ToString();
                txtName.Text = row.Cells["SubjectName"].Value.ToString();
                errorProvider.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { errorProvider.SetError(txtName, "Nhập tên môn!"); return; }
            try
            {
                if (bus.Add(new SubjectDTO { SubjectName = txtName.Text.Trim() }))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Có thể tên môn học đã tồn tại)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            try
            {
                if (bus.Update(new SubjectDTO { SubjectId = int.Parse(txtID.Text), SubjectName = txtName.Text.Trim() }))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); ClearForm();
                }
                else
                {
                    MessageBox.Show("Lỗi cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;

            // Icon Question (Dấu hỏi chấm)
            if (MessageBox.Show("Bạn có chắc muốn xóa môn học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (bus.Delete(int.Parse(txtID.Text)))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa (Môn học đang được sử dụng hoặc có dữ liệu liên quan)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearForm(); LoadData(); }

        private void ClearForm()
        {
            txtID.Text = ""; txtName.Text = "";
            errorProvider.Clear();
            dgvData.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string k = txtSearch.Text.ToLower();
            var list = bus.GetAll();
            if (list != null) dgvData.DataSource = list.Where(x => x.SubjectName.ToLower().Contains(k)).ToList();
        }
    }
}