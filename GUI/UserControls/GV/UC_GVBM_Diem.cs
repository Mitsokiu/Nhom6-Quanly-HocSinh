using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVBM_Diem : UserControl
    {
        private int currentTeacherId;
        private int currentAssignId = -1;
        private DataTable dtAssignments;

        public UC_GVBM_Diem(int userId)
        {
            InitializeComponent();
            this.currentTeacherId = userId;

            this.Load += UC_GVBM_Diem_Load;
            cbbHocKy.SelectedIndexChanged += CbbHocKy_SelectedIndexChanged;
            cbbLop.SelectedIndexChanged += CbbLop_SelectedIndexChanged;
            btnXem.Click += BtnXem_Click;
            btnLuu.Click += BtnLuu_Click;
            dgvBangDiem.CellEndEdit += DgvBangDiem_CellEndEdit;
        }

        public UC_GVBM_Diem() : this(0) { }

        private void UC_GVBM_Diem_Load(object sender, EventArgs e)
        {
            LoadHocKy();
            LoadPhanCongGiaoVien();
        }

        private void LoadHocKy()
        {
            SemesterBUS semBus = new SemesterBUS();
            cbbHocKy.DataSource = semBus.GetAllSemesters();
            cbbHocKy.DisplayMember = "DisplayName";
            cbbHocKy.ValueMember = "SemesterId";
        }

        private void LoadPhanCongGiaoVien()
        {
            DataTable all = TeacherAssignmentBUS.GetAllAssignments();
            if (all != null)
            {
                var rows = all.AsEnumerable().Where(r => r.Field<int>("teacher_id") == currentTeacherId);
                if (rows.Any())
                    dtAssignments = rows.CopyToDataTable();
                else
                    dtAssignments = new DataTable();
            }
        }


        private void CbbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtAssignments == null || cbbHocKy.SelectedItem == null) return;

            SemesterDTO selectedSem = cbbHocKy.SelectedItem as SemesterDTO;

            if (selectedSem != null)
            {
                DateTime today = DateTime.Now;

                if (today < selectedSem.StartDate)
                {
                    KhoaChucNangNhapDiem(true, $"Chưa mở (Bắt đầu: {selectedSem.StartDate:dd/MM/yyyy})");
                }
                else if (today > selectedSem.EndDate)
                {
                    KhoaChucNangNhapDiem(true, $"Đã khóa sổ (Kết thúc: {selectedSem.EndDate:dd/MM/yyyy})");
                }
                else
                {
                    KhoaChucNangNhapDiem(false, "Lưu điểm");
                }
            }

            if (int.TryParse(cbbHocKy.SelectedValue.ToString(), out int semesterId))
            {
                DataView view = new DataView(dtAssignments);
                view.RowFilter = $"semester_id = {semesterId}";
                DataTable distinctClasses = view.ToTable(true, "class_id", "class_name");

                cbbLop.DataSource = distinctClasses;
                cbbLop.DisplayMember = "class_name";
                cbbLop.ValueMember = "class_id";

                cbbMonHoc.DataSource = null; 
            }
        }

        private void KhoaChucNangNhapDiem(bool isLocked, string message)
        {
            if (isLocked)
            {
                btnLuu.Enabled = false;
                btnLuu.BackColor = System.Drawing.Color.Gray;
                btnLuu.Text = message; 

                dgvBangDiem.ReadOnly = true;
                dgvBangDiem.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            }
            else
            {
                btnLuu.Enabled = true;
                btnLuu.BackColor = System.Drawing.Color.SteelBlue;
                btnLuu.Text = message; 

                dgvBangDiem.ReadOnly = false;
                dgvBangDiem.DefaultCellStyle.BackColor = System.Drawing.Color.White;

                colSTT.ReadOnly = true;
                colMaHS.ReadOnly = true;
                colTenHS.ReadOnly = true;
                colDiemTB.ReadOnly = true;
            }
        }

        private void CbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtAssignments == null || cbbLop.SelectedValue == null || cbbHocKy.SelectedValue == null) return;

            int semId = Convert.ToInt32(cbbHocKy.SelectedValue);

            if (int.TryParse(cbbLop.SelectedValue.ToString(), out int classId))
            {
                DataView view = new DataView(dtAssignments);
                view.RowFilter = $"semester_id = {semId} AND class_id = {classId}";

                DataTable distinctSubjects = view.ToTable(true, "assign_id", "subject_name");

                cbbMonHoc.DataSource = distinctSubjects;
                cbbMonHoc.DisplayMember = "subject_name";
                cbbMonHoc.ValueMember = "assign_id";
            }
        }


        private void BtnXem_Click(object sender, EventArgs e)
        {
            if (cbbMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin.");
                return;
            }

            currentAssignId = Convert.ToInt32(cbbMonHoc.SelectedValue);
            int classId = Convert.ToInt32(cbbLop.SelectedValue);

            LoadBangDiem(classId, currentAssignId);
        }

        private void LoadBangDiem(int classId, int assignId)
        {
            dgvBangDiem.Rows.Clear();

            StudentBUS studentBUS = new StudentBUS();
            List<StudentDTO> listHS = studentBUS.GetStudentsByClassID(classId);

            ScoreBUS scoreBUS = new ScoreBUS();
            DataTable dtScores = scoreBUS.GetScoresByAssignId(assignId);

            int stt = 1;
            foreach (var hs in listHS)
            {
                int idx = dgvBangDiem.Rows.Add();
                DataGridViewRow row = dgvBangDiem.Rows[idx];

                row.Cells["colSTT"].Value = stt++;
                row.Cells["colMaHS"].Value = hs.StudentID;
                row.Cells["colTenHS"].Value = hs.FullName;

                if (dtScores != null)
                {
                    DataRow[] scores = dtScores.Select($"student_id = {hs.StudentID}");
                    foreach (DataRow s in scores)
                    {
                        string type = s["score_type"].ToString();
                        double val = Convert.ToDouble(s["score_value"]);

                        if (type == "oral") row.Cells["colDiemMieng"].Value = val;
                        else if (type == "quiz15") row.Cells["colDiem15p"].Value = val;
                        else if (type == "quiz45") row.Cells["colDiem1Tiet"].Value = val;
                        else if (type == "midterm") row.Cells["colDiemGiuaKy"].Value = val;
                        else if (type == "final") row.Cells["colDiemCuoiKy"].Value = val;
                    }
                }
                TinhDiemTB(row);
            }
        }


        private void DgvBangDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TinhDiemTB(dgvBangDiem.Rows[e.RowIndex]);
        }

        private void TinhDiemTB(DataGridViewRow row)
        {
            double sum = 0;
            int heso = 0;

            void AddScore(string col, int hs)
            {
                var val = row.Cells[col].Value;
                if (val != null && double.TryParse(val.ToString(), out double d))
                {
                    sum += d * hs;
                    heso += hs;
                }
            }

            AddScore("colDiemMieng", 1);
            AddScore("colDiem15p", 1);
            AddScore("colDiem1Tiet", 2);
            AddScore("colDiemGiuaKy", 2);
            AddScore("colDiemCuoiKy", 3);

            if (heso > 0)
                row.Cells["colDiemTB"].Value = Math.Round(sum / heso, 2);
            else
                row.Cells["colDiemTB"].Value = "";
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (currentAssignId == -1) return;

            try
            {
                ScoreBUS bus = new ScoreBUS();
                int count = 0;

                foreach (DataGridViewRow row in dgvBangDiem.Rows)
                {
                    int sId = Convert.ToInt32(row.Cells["colMaHS"].Value);

                    SaveOneScore(bus, sId, "oral", row.Cells["colDiemMieng"].Value);
                    SaveOneScore(bus, sId, "quiz15", row.Cells["colDiem15p"].Value);
                    SaveOneScore(bus, sId, "quiz45", row.Cells["colDiem1Tiet"].Value);
                    SaveOneScore(bus, sId, "midterm", row.Cells["colDiemGiuaKy"].Value);
                    SaveOneScore(bus, sId, "final", row.Cells["colDiemCuoiKy"].Value);
                    count++;
                }
                MessageBox.Show("Lưu điểm thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void SaveOneScore(ScoreBUS bus, int sId, string type, object valObj)
        {
            if (valObj == null || string.IsNullOrWhiteSpace(valObj.ToString())) return;

            if (float.TryParse(valObj.ToString(), out float val))
            {
                ScoreDTO dto = new ScoreDTO
                {
                    StudentId = sId,
                    AssignId = currentAssignId,
                    ScoreType = type,
                    ScoreValue = val
                };
                bus.AddOrUpdateScore(dto);
            }
        }
    }
}