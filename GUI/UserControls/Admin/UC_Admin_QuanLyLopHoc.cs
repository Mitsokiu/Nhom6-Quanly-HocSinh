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
        private ErrorProvider errorProvider;

        public UC_Admin_QuanLyLopHoc()
        {
            InitializeComponent();
            _gradeBUS = new GradeBUS(); // Dùng GradeBUS Instance như đã sửa đầu tiên
            errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };

            LoadComboBoxes();
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Grade
                cbGrade.DataSource = _gradeBUS.GetListGrade();
                cbGrade.DisplayMember = "Name"; cbGrade.ValueMember = "Id";

                // Teacher
                cbTeacher.DataSource = ClassBUS.GetListTeachers();
                cbTeacher.DisplayMember = "Name"; cbTeacher.ValueMember = "Id";
                cbTeacher.SelectedIndex = -1;

                // Year
                cbYear.DataSource = ClassBUS.GetListYears();
                cbYear.DisplayMember = "Name"; cbYear.ValueMember = "Id";
                if (cbYear.Items.Count > 0) cbYear.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load combobox: " + ex.Message); }
        }

        private void LoadData()
        {
            try
            {
                dgvClass.DataSource = ClassBUS.GetAllClasses();

                // Ẩn cột ID
                string[] hidden = { "GradeId", "TeacherId", "YearId", "AssignId" };
                foreach (var c in hidden) if (dgvClass.Columns[c] != null) dgvClass.Columns[c].Visible = false;

                // Header Text
                if (dgvClass.Columns["Id"] != null) dgvClass.Columns["Id"].HeaderText = "Mã lớp";
                if (dgvClass.Columns["ClassName"] != null) dgvClass.Columns["ClassName"].HeaderText = "Tên lớp";
                if (dgvClass.Columns["TeacherName"] != null) dgvClass.Columns["TeacherName"].HeaderText = "GVCN";
                if (dgvClass.Columns["YearName"] != null) dgvClass.Columns["YearName"].HeaderText = "Năm học";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvClass.Rows[e.RowIndex];
                txtID.Text = row.Cells["Id"].Value.ToString();
                txtName.Text = row.Cells["ClassName"].Value.ToString();

                if (row.Cells["GradeId"].Value != null) cbGrade.SelectedValue = row.Cells["GradeId"].Value;

                // Binding Teacher/Year
                if (row.Cells["TeacherId"].Value != null && (int)row.Cells["TeacherId"].Value > 0)
                    cbTeacher.SelectedValue = row.Cells["TeacherId"].Value;
                else cbTeacher.SelectedIndex = -1;

                if (row.Cells["YearId"].Value != null && (int)row.Cells["YearId"].Value > 0)
                    cbYear.SelectedValue = row.Cells["YearId"].Value;

                errorProvider.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { errorProvider.SetError(txtName, "Nhập tên lớp!"); return; }

            try
            {
                ClassDTO c = new ClassDTO { ClassName = txtName.Text.Trim(), GradeId = (int)cbGrade.SelectedValue };
                int tId = cbTeacher.SelectedValue != null ? (int)cbTeacher.SelectedValue : 0;
                int yId = cbYear.SelectedValue != null ? (int)cbYear.SelectedValue : 0;

                ClassBUS.AddClass(c, tId, yId);
                MessageBox.Show("Thêm thành công!");
                LoadData(); ClearForm();
            }
            catch (Exception ex) { HandleError(ex); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            try
            {
                int assignId = 0;
                if (dgvClass.CurrentRow != null && dgvClass.CurrentRow.Cells["AssignId"].Value != null)
                    assignId = Convert.ToInt32(dgvClass.CurrentRow.Cells["AssignId"].Value);

                ClassDTO c = new ClassDTO { Id = int.Parse(txtID.Text), ClassName = txtName.Text.Trim(), GradeId = (int)cbGrade.SelectedValue };
                int tId = cbTeacher.SelectedValue != null ? (int)cbTeacher.SelectedValue : 0;
                int yId = cbYear.SelectedValue != null ? (int)cbYear.SelectedValue : 0;

                ClassBUS.UpdateClass(c, tId, yId, assignId);
                MessageBox.Show("Cập nhật thành công!");
                LoadData(); ClearForm();
            }
            catch (Exception ex) { HandleError(ex); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("Xóa lớp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ClassBUS.DeleteClass(int.Parse(txtID.Text));
                    LoadData(); ClearForm();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void HandleError(Exception ex)
        {
            if (ex is ArgumentException)
            {
                if (ex.Message.Contains("Tên lớp")) { errorProvider.SetError(txtName, ex.Message); txtName.Focus(); }
                else if (ex.Message.Contains("Giáo viên") || ex.Message.Contains("Năm học")) { errorProvider.SetError(cbTeacher, ex.Message); }
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtID.Text = ""; txtName.Text = "";
            if (cbGrade.Items.Count > 0) cbGrade.SelectedIndex = 0;
            cbTeacher.SelectedIndex = -1;
            errorProvider.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string k = txtSearch.Text.ToLower();
            var list = ClassBUS.GetAllClasses();
            if (list != null) dgvClass.DataSource = list.Where(x => x.ClassName.ToLower().Contains(k)).ToList();
        }

        private void lblTeacher_Click(object sender, EventArgs e)
        {

        }
    }
}