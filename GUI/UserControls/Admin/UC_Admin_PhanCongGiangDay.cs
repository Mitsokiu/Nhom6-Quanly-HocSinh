using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI.UserControls.Admin
{
    public partial class UC_Admin_PhanCongGiangDay : UserControl
    {
        private SubjectBUS subjectBUS = new SubjectBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();

        private int currentTeacherId = -1;

        public UC_Admin_PhanCongGiangDay()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                SetupDataGridView();
                LoadDanhSachGiaoVien();
                LoadComboBoxData();
                cbbHocKy.SelectedIndexChanged += cbbHocKy_SelectedIndexChanged;
                cbbHocKy_SelectedIndexChanged(cbbHocKy, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void SetupDataGridView()
        {
            dgvGiaoVien.AutoGenerateColumns = false;
            colMaGV.DataPropertyName = "UserId"; 
            colTenGV.DataPropertyName = "Fullname"; 

            dgvPhanCong.AutoGenerateColumns = false;
            colPCMon.DataPropertyName = "subject_name";    
            colPCLop.DataPropertyName = "class_name";      
            colPCHocKy.DataPropertyName = "semester_name";

            dgvGiaoVien.CellClick += DgvGiaoVien_CellClick;
            btnLuu.Click += BtnLuu_Click;
            dgvPhanCong.CellContentClick += DgvPhanCong_CellContentClick;
            txtTimKiemGV.TextChanged += TxtTimKiemGV_TextChanged;
        }

        private void LoadDanhSachGiaoVien()
        {
            List<UserDTO> listGV = UserBUS.GetAllTeachers();
            dgvGiaoVien.DataSource = listGV;
        }
/*
        private void LoadDanhSachGiaoVien()
        {
            List<UserDTO> listGV = UserBUS.GetAllTeachers();

            foreach (var gv in listGV)
            {
                if (!string.IsNullOrEmpty(gv.Fullname) && gv.Fullname.Contains("("))
                {
                    gv.Fullname = gv.Fullname.Split('(')[0].Trim();
                }
            }

            dgvGiaoVien.DataSource = listGV;
        }*/

        private void LoadComboBoxData()
        {
            try
            {
                cbbHocKy.DataSource = semesterBUS.GetAllSemesters();
                cbbHocKy.DisplayMember = "DisplayName";
                cbbHocKy.ValueMember = "SemesterId";

                cbbMonHoc.DataSource = subjectBUS.GetAll();
                cbbMonHoc.DisplayMember = "SubjectName";
                cbbMonHoc.ValueMember = "SubjectId";

                List<ClassDTO> listLop = ClassBUS.GetAllClasses();
                ((ListBox)clbLopHoc).DataSource = listLop;
                ((ListBox)clbLopHoc).DisplayMember = "ClassName";

                ((ListBox)clbLopHoc).ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu combobox: " + ex.Message);
            }
        }

        private void DgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedRow = dgvGiaoVien.Rows[e.RowIndex];

            if (selectedRow.Cells["colMaGV"].Value != null)
            {
                currentTeacherId = Convert.ToInt32(selectedRow.Cells["colMaGV"].Value);
                string teacherName = selectedRow.Cells["colTenGV"].Value.ToString();

                groupBox2.Text = $"Phân công cho: {teacherName}"; 

                LoadPhanCongCuaGiaoVien(currentTeacherId);
            }
        }

        private void LoadPhanCongCuaGiaoVien(int teacherId)
        {
            DataTable dt = TeacherAssignmentBUS.GetAllAssignments();

            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = $"teacher_id = {teacherId}";
                dgvPhanCong.DataSource = dv;
            }
        }


        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (currentTeacherId == -1)
            {
                MessageBox.Show("Vui lòng chọn một giáo viên trước!", "Cảnh báo");
                return;
            }
            if (cbbHocKy.SelectedValue == null || cbbMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Học kỳ và Môn học!", "Cảnh báo");
                return;
            }
            if (clbLopHoc.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một lớp!", "Cảnh báo");
                return;
            }

            SemesterDTO sem = (SemesterDTO)cbbHocKy.SelectedItem;
            if (sem.EndDate < DateTime.Now)
            {
                MessageBox.Show($"Học kỳ '{sem.SemesterName}' của năm học '{sem.YearName}' đã kết thúc vào ngày {sem.EndDate:dd/MM/yyyy}.\nKhông thể phân công thêm!", "Đã khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int successCount = 0;
                int duplicateCount = 0; 
                int semesterId = Convert.ToInt32(cbbHocKy.SelectedValue);
                int subjectId = Convert.ToInt32(cbbMonHoc.SelectedValue);

                DataTable dtAll = TeacherAssignmentBUS.GetAllAssignments();

                foreach (ClassDTO lop in clbLopHoc.CheckedItems)
                {

                    string filter = $"teacher_id = {currentTeacherId} AND subject_id = {subjectId} AND class_id = {lop.Id} AND semester_id = {semesterId}";

                    DataRow[] existingRows = dtAll.Select(filter);

                    if (existingRows.Length > 0)
                    {
                        duplicateCount++;
                        continue;
                    }

                    TeacherAssignmentDTO dto = new TeacherAssignmentDTO
                    {
                        TeacherId = currentTeacherId,
                        SubjectId = subjectId,
                        ClassId = lop.Id,
                        SemesterId = semesterId,
                        Periods = 0
                    };

                    if (TeacherAssignmentBUS.AddAssignment(dto))
                    {
                        successCount++;
                    }
                }

                if (successCount > 0)
                {
                    string msg = $"Đã thêm thành công {successCount} phân công mới!";
                    if (duplicateCount > 0)
                    {
                        msg += $"\n(Đã tự động bỏ qua {duplicateCount} phân công bị trùng lặp)";
                    }

                    MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadPhanCongCuaGiaoVien(currentTeacherId);

                    for (int i = 0; i < clbLopHoc.Items.Count; i++)
                        clbLopHoc.SetItemChecked(i, false);
                }
                else if (duplicateCount > 0)
                {
                    MessageBox.Show("Các lớp bạn chọn ĐÃ ĐƯỢC PHÂN CÔNG cho giáo viên này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }


        private void DgvPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPhanCong.Columns[e.ColumnIndex].Name == "colPCXoa")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var row = dgvPhanCong.Rows[e.RowIndex];

                    if (row.DataBoundItem is DataRowView drv)
                    {
                       
                        int assignId = Convert.ToInt32(drv["assign_id"]);

                        if (TeacherAssignmentBUS.DeleteAssignment(assignId))
                        {
                           
                            LoadPhanCongCuaGiaoVien(currentTeacherId);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại.");
                        }
                    }
                }
            }
        }

 
        private void TxtTimKiemGV_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemGV.Text.Trim();

            List<UserDTO> allTeachers = UserBUS.GetAllTeachers();
            var filteredList = allTeachers.FindAll(x => x.Fullname.ToLower().Contains(keyword.ToLower())
                                                     || x.Username.ToLower().Contains(keyword.ToLower()));
            dgvGiaoVien.DataSource = filteredList;
        }

        private void cbbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbHocKy.SelectedItem is SemesterDTO selectedSem)
            {
                if (selectedSem.EndDate < DateTime.Now)
                {
                    btnLuu.Enabled = false;
                    btnLuu.BackColor = System.Drawing.Color.Gray; 
                    btnLuu.Text = "Đã kết thúc";

                    for (int i = 0; i < clbLopHoc.Items.Count; i++)
                        clbLopHoc.SetItemChecked(i, false);
                    clbLopHoc.Enabled = false; 
                }
                else
                {
                    btnLuu.Enabled = true;
                    btnLuu.BackColor = System.Drawing.Color.SteelBlue;
                    btnLuu.Text = "Lưu Phân Công";
                    clbLopHoc.Enabled = true; 
                }
            }
        }
    }
}