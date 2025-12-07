using BUS;
using DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls.Admin
{
    public partial class UC_Admin_QuanLyKhoi : UserControl
    {
        private GradeBUS bus;
        private ErrorProvider errorProvider;

        public UC_Admin_QuanLyKhoi()
        {
            InitializeComponent();
            bus = new GradeBUS();
            errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvData.DataSource = bus.GetListGrade();
                if (dgvData.Columns["Id"] != null) dgvData.Columns["Id"].HeaderText = "Mã khối";
                if (dgvData.Columns["Name"] != null) dgvData.Columns["Name"].HeaderText = "Tên khối";
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
                txtID.Text = row.Cells["Id"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                errorProvider.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { errorProvider.SetError(txtName, "Nhập tên khối!"); return; }
            try
            {
                if (bus.Add(new GradeDTO { Name = txtName.Text.Trim() }))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Tên khối có thể đã tồn tại)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (bus.Update(new GradeDTO { Id = int.Parse(txtID.Text), Name = txtName.Text.Trim() }))
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

            // Icon Question cho câu hỏi xác nhận
            if (MessageBox.Show("Bạn có chắc muốn xóa khối này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                        MessageBox.Show("Không thể xóa (Khối đang có lớp học)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var list = bus.GetListGrade();
            if (list != null) dgvData.DataSource = list.Where(x => x.Name.ToLower().Contains(k)).ToList();
        }
    }
}