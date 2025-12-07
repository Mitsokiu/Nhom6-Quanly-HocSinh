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
        // Khai báo các BUS cần thiết (đối với các class không phải static)
        private SubjectBUS subjectBUS = new SubjectBUS();
        private SemesterBUS semesterBUS = new SemesterBUS(); // Giả định bạn đã có SemesterBUS

        // Biến lưu trạng thái
        private int currentTeacherId = -1;

        public UC_Admin_PhanCongGiangDay()
        {
            InitializeComponent();
        }

        // ==========================================================
        // 1. SỰ KIỆN LOAD FORM
        // ==========================================================
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
            // Map dữ liệu từ List<UserDTO> vào Grid Giáo viên
            dgvGiaoVien.AutoGenerateColumns = false;
            colMaGV.DataPropertyName = "UserId"; // Dựa vào UserDTO
            colTenGV.DataPropertyName = "Fullname"; // Dựa vào UserDTO

            // Map dữ liệu từ DataTable vào Grid Phân công
            dgvPhanCong.AutoGenerateColumns = false;
            // Ví dụ: SELECT s.SubjectName, c.ClassName ...
            colPCMon.DataPropertyName = "subject_name";    
            colPCLop.DataPropertyName = "class_name";      
            colPCHocKy.DataPropertyName = "semester_name";

            // Đăng ký các sự kiện
            dgvGiaoVien.CellClick += DgvGiaoVien_CellClick;
            btnLuu.Click += BtnLuu_Click;
            dgvPhanCong.CellContentClick += DgvPhanCong_CellContentClick;
            txtTimKiemGV.TextChanged += TxtTimKiemGV_TextChanged;
        }

        /* private void LoadDanhSachGiaoVien()
         {
             // Gọi hàm static từ UserBUS
             List<UserDTO> listGV = UserBUS.GetAllTeachers();
             dgvGiaoVien.DataSource = listGV;
         }*/

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
        }

        private void LoadComboBoxData()
        {
            try
            {
                // 1. Load Học kỳ (Giữ nguyên nếu SemesterDTO của bạn là SemesterId và SemesterName)
                cbbHocKy.DataSource = semesterBUS.GetAllSemesters();
                cbbHocKy.DisplayMember = "DisplayName";
                cbbHocKy.ValueMember = "SemesterId";

                // 2. Load Môn học (SubjectDTO: SubjectId, SubjectName) -> ĐÚNG
                cbbMonHoc.DataSource = subjectBUS.GetAll();
                cbbMonHoc.DisplayMember = "SubjectName";
                cbbMonHoc.ValueMember = "SubjectId";

                // 3. Load Danh sách Lớp [SỬA LẠI CHỖ NÀY]
                // ClassDTO của bạn có thuộc tính: Id, ClassName
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

        // ==========================================================
        // 2. XỬ LÝ CHỌN GIÁO VIÊN
        // ==========================================================
        private void DgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy dòng đang chọn
            var selectedRow = dgvGiaoVien.Rows[e.RowIndex];

            // Lấy ID giáo viên (ép kiểu về int vì UserDTO.UserId là int)
            if (selectedRow.Cells["colMaGV"].Value != null)
            {
                currentTeacherId = Convert.ToInt32(selectedRow.Cells["colMaGV"].Value);
                string teacherName = selectedRow.Cells["colTenGV"].Value.ToString();

                groupBox2.Text = $"Phân công cho: {teacherName}"; // Đổi tên GroupBox cho đẹp

                // Load lại bảng phân công của giáo viên này
                LoadPhanCongCuaGiaoVien(currentTeacherId);
            }
        }

        private void LoadPhanCongCuaGiaoVien(int teacherId)
        {
            // Lấy DataTable từ BUS
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
            // --- 1. Validation (Giữ nguyên) ---
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
                    // Bước kiểm tra quan trọng:
                    // "Tìm xem trong bảng dtAll đã có dòng nào trùng khớp cả 4 yếu tố chưa?"
                    // Lưu ý: Tên cột phải khớp với SQL (teacher_id, subject_id, class_id, semester_id)
                    string filter = $"teacher_id = {currentTeacherId} AND subject_id = {subjectId} AND class_id = {lop.Id} AND semester_id = {semesterId}";

                    DataRow[] existingRows = dtAll.Select(filter);

                    if (existingRows.Length > 0)
                    {
                        // Nếu tìm thấy => Đã tồn tại => Bỏ qua, tăng biến đếm trùng
                        duplicateCount++;
                        continue;
                    }

                    // Nếu chưa có => Tạo mới và Thêm
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

                // --- 4. THÔNG BÁO KẾT QUẢ ---
                if (successCount > 0)
                {
                    string msg = $"Đã thêm thành công {successCount} phân công mới!";
                    if (duplicateCount > 0)
                    {
                        msg += $"\n(Đã tự động bỏ qua {duplicateCount} phân công bị trùng lặp)";
                    }

                    MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadPhanCongCuaGiaoVien(currentTeacherId); // Refresh lại lưới

                    // Bỏ tích các ô chọn
                    for (int i = 0; i < clbLopHoc.Items.Count; i++)
                        clbLopHoc.SetItemChecked(i, false);
                }
                else if (duplicateCount > 0)
                {
                    // Trường hợp người dùng chọn lại y chang cái cũ
                    MessageBox.Show("Các lớp bạn chọn ĐÃ ĐƯỢC PHÂN CÔNG cho giáo viên này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        // ==========================================================
        // 4. XỬ LÝ XÓA PHÂN CÔNG (DELETE)
        // ==========================================================
        private void DgvPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột nút "Xóa"
            if (e.RowIndex >= 0 && dgvPhanCong.Columns[e.ColumnIndex].Name == "colPCXoa")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var row = dgvPhanCong.Rows[e.RowIndex];

                    // Lấy DataRowView từ dòng hiện tại
                    if (row.DataBoundItem is DataRowView drv)
                    {
                       
                        int assignId = Convert.ToInt32(drv["assign_id"]);

                        // Gọi BUS để xóa
                        if (TeacherAssignmentBUS.DeleteAssignment(assignId))
                        {
                           
                            LoadPhanCongCuaGiaoVien(currentTeacherId); // Tải lại danh sách
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại.");
                        }
                    }
                }
            }
        }

        // ==========================================================
        // 5. TÌM KIẾM GIÁO VIÊN
        // ==========================================================
        private void TxtTimKiemGV_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiemGV.Text.Trim();
            // Gọi UserBUS tìm kiếm
            // Lưu ý: UserBUS của bạn có hàm SearchUsers nhưng trả về tất cả User.
            // Bạn nên lọc lại chỉ lấy Giáo viên ở đây hoặc viết thêm hàm SearchTeachers trong DAO.

            // Cách xử lý tạm thời tại UI (Lấy list GV rồi lọc)
            List<UserDTO> allTeachers = UserBUS.GetAllTeachers();
            var filteredList = allTeachers.FindAll(x => x.Fullname.ToLower().Contains(keyword.ToLower())
                                                     || x.Username.ToLower().Contains(keyword.ToLower()));
            dgvGiaoVien.DataSource = filteredList;
        }

        // Sự kiện khi chọn thay đổi Học kỳ
        private void cbbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem item được chọn có phải là SemesterDTO không
            if (cbbHocKy.SelectedItem is SemesterDTO selectedSem)
            {
                // Logic: Nếu ngày kết thúc nhỏ hơn ngày hiện tại => Đã qua
                if (selectedSem.EndDate < DateTime.Now)
                {
                    // KHÓA CHỨC NĂNG
                    btnLuu.Enabled = false;
                    btnLuu.BackColor = System.Drawing.Color.Gray; // Đổi màu xám cho dễ nhận biết
                    btnLuu.Text = "Đã kết thúc";

                    // (Tùy chọn) Bỏ tích các lớp đang chọn để tránh hiểu nhầm
                    for (int i = 0; i < clbLopHoc.Items.Count; i++)
                        clbLopHoc.SetItemChecked(i, false);
                    clbLopHoc.Enabled = false; // Khóa luôn danh sách lớp
                }
                else
                {
                    // MỞ LẠI CHỨC NĂNG
                    btnLuu.Enabled = true;
                    btnLuu.BackColor = System.Drawing.Color.SteelBlue; // Trả lại màu gốc (xanh)
                    btnLuu.Text = "Lưu Phân Công";
                    clbLopHoc.Enabled = true; // Mở lại danh sách lớp
                }
            }
        }
    }
}