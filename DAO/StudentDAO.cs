using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class StudentDAO
    {
        private DbConnect db = new DbConnect();

        // Hàm lấy ClassID từ UserID
        public int GetClassIdByUserId(int userID)
        {
            string query = @"SELECT sc.class_id
                FROM student_class sc
                JOIN students s ON sc.student_id = s.student_id
                WHERE s.user_id = @param0
                ORDER BY sc.id DESC LIMIT 1";
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { userID });
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["class_id"]);
            }
            return -1; // Trả về -1 nếu không tìm thấy
        }

        // Hàm lấy StudentID từ UserID
        public int GetStudentIdByUserId(int userID)
        {
            String query = "SELECT student_id FROM students WHERE user_id = @param0";
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { userID });
            if (data.Rows.Count > 0)
                return (int)data.Rows[0]["student_id"];
            return -1;
        }

        // 1. Lấy toàn bộ danh sách học sinh (Kèm Lớp và Năm học)
        public List<StudentDTO> GetStudents()
        {
            List<StudentDTO> list = new List<StudentDTO>();

            // Query lấy thông tin học sinh và lớp học hiện tại
            // Sử dụng LEFT JOIN để vẫn lấy được HS chưa xếp lớp
            string query = @"
                SELECT s.student_id, s.user_id, u.fullname, s.dob, s.gender, s.address, 
                       c.class_id, c.class_name, ay.name AS year_name
                FROM students s
                JOIN users u ON s.user_id = u.user_id
                LEFT JOIN student_class sc ON s.student_id = sc.student_id
                LEFT JOIN classes c ON sc.class_id = c.class_id
                LEFT JOIN academic_years ay ON sc.school_year_id = ay.year_id
                WHERE u.role_id = 'student'
                ORDER BY s.student_id DESC";

            DataTable data = DbConnect.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                StudentDTO student = MapDataRowToStudent(row);
                // Gọi hàm lấy thêm thông tin phụ huynh
                GetParentInfo(student);
                list.Add(student);
            }
            return list;
        }

        // 2. Tìm kiếm học sinh
        public List<StudentDTO> SearchStudents(string keyword)
        {
            List<StudentDTO> list = new List<StudentDTO>();
            string query = @"
                SELECT s.student_id, s.user_id, u.fullname, s.dob, s.gender, s.address, 
                       c.class_id, c.class_name, ay.name AS year_name
                FROM students s
                JOIN users u ON s.user_id = u.user_id
                LEFT JOIN student_class sc ON s.student_id = sc.student_id
                LEFT JOIN classes c ON sc.class_id = c.class_id
                LEFT JOIN academic_years ay ON sc.school_year_id = ay.year_id
                WHERE u.role_id = 'student' 
                  AND (u.fullname LIKE @param0 OR s.student_id LIKE @param0)
                ORDER BY s.student_id DESC";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
            foreach (DataRow row in data.Rows)
            {
                StudentDTO student = MapDataRowToStudent(row);
                GetParentInfo(student);
                list.Add(student);
            }
            return list;
        }

        // 3. Thêm mới học sinh
        public bool AddStudent(StudentDTO s)
        {
            // Bước 1: Tạo User (Tài khoản) cho học sinh
            string username = "hs" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string queryUser = @"INSERT INTO users (username, password, fullname, role_id) 
                                 VALUES (@param0, '123456', @param1, 'student'); 
                                 SELECT LAST_INSERT_ID();";

            object userIdObj = DbConnect.ExecuteScalar(queryUser, new object[] { username, s.FullName });
            if (userIdObj == null) return false;
            int newUserId = Convert.ToInt32(userIdObj);

            // Bước 2: Tạo Student (Hồ sơ)
            string queryStudent = @"INSERT INTO students (user_id, dob, gender, address) 
                                    VALUES (@param0, @param1, @param2, @param3); 
                                    SELECT LAST_INSERT_ID();";

            object studentIdObj = DbConnect.ExecuteScalar(queryStudent, new object[] { newUserId, s.DateOfBirth.Date, s.Gender, s.Address });
            if (studentIdObj == null) return false;
            int newStudentId = Convert.ToInt32(studentIdObj);

            // Bước 3: Xếp lớp (Nếu có chọn lớp và năm học)
            if (s.ClassID > 0 && s.YearID > 0)
            {
                string queryClass = @"INSERT INTO student_class (student_id, class_id, school_year_id) 
                                      VALUES (@param0, @param1, @param2)";
                DbConnect.ExecuteNonQuery(queryClass, new object[] { newStudentId, s.ClassID, s.YearID });
            }

            // Bước 4: Thêm phụ huynh
            if (!string.IsNullOrWhiteSpace(s.FatherName))
            {
                string fatherUsername = "ph" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string queryParentUser = @"INSERT INTO users (username, password, fullname, phone, role_id) 
                                           VALUES (@param0, '123456', @param1, @param2, 'parent'); 
                                           SELECT LAST_INSERT_ID();";
                object fatherUserIdObj = DbConnect.ExecuteScalar(queryParentUser, new object[] { fatherUsername, s.FatherName, s.FatherPhone });
                if (fatherUserIdObj == null) return false;
                int fatherUserId = Convert.ToInt32(fatherUserIdObj);

                string queryParent = @"INSERT INTO parents (user_id, job) 
                                       VALUES (@param0, @param1); 
                                       SELECT LAST_INSERT_ID();";
                object parentIdObj = DbConnect.ExecuteScalar(queryParent, new object[] { fatherUserId, s.FatherJob });
                if (parentIdObj == null) return false;
                int fatherParentId = Convert.ToInt32(parentIdObj);

                string queryRelation = @"INSERT INTO student_parent (student_id, parent_id, relation) 
                                         VALUES (@param0, @param1, 'Cha')";
                DbConnect.ExecuteNonQuery(queryRelation, new object[] { newStudentId, fatherParentId });
            }

            if (!string.IsNullOrWhiteSpace(s.MotherName))
            {
                string motherUsername = "ph" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string queryParentUser = @"INSERT INTO users (username, password, fullname, phone, role_id) 
                                           VALUES (@param0, '123456', @param1, @param2, 'parent'); 
                                           SELECT LAST_INSERT_ID();";
                object motherUserIdObj = DbConnect.ExecuteScalar(queryParentUser, new object[] { motherUsername, s.MotherName, s.MotherPhone });
                if (motherUserIdObj == null) return false;
                int motherUserId = Convert.ToInt32(motherUserIdObj);

                string queryParent = @"INSERT INTO parents (user_id, job) 
                                       VALUES (@param0, @param1); 
                                       SELECT LAST_INSERT_ID();";
                object parentIdObj = DbConnect.ExecuteScalar(queryParent, new object[] { motherUserId, s.MotherJob });
                if (parentIdObj == null) return false;
                int motherParentId = Convert.ToInt32(parentIdObj);

                string queryRelation = @"INSERT INTO student_parent (student_id, parent_id, relation) 
                                         VALUES (@param0, @param1, 'Mẹ')";
                DbConnect.ExecuteNonQuery(queryRelation, new object[] { newStudentId, motherParentId });
            }

            return true;
        }

        // 4. Xóa học sinh
        public bool DeleteStudent(int studentID)
        {
            // Lấy UserID trước khi xóa
            string queryGet = "SELECT user_id FROM students WHERE student_id = @param0";
            DataTable dt = DbConnect.ExecuteQuery(queryGet, new object[] { studentID });
            if (dt.Rows.Count == 0) return false;
            int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);

            // Xóa các bảng phụ thuộc thủ công (Nếu DB chưa set ON DELETE CASCADE)
            DbConnect.ExecuteNonQuery("DELETE FROM student_class WHERE student_id = @param0", new object[] { studentID });
            DbConnect.ExecuteNonQuery("DELETE FROM scores WHERE student_id = @param0", new object[] { studentID });
            DbConnect.ExecuteNonQuery("DELETE FROM tuition WHERE student_id = @param0", new object[] { studentID });
            DbConnect.ExecuteNonQuery("DELETE FROM student_parent WHERE student_id = @param0", new object[] { studentID });

            // Xóa Student
            DbConnect.ExecuteNonQuery("DELETE FROM students WHERE student_id = @param0", new object[] { studentID });

            // Xóa User
            return DbConnect.ExecuteNonQuery("DELETE FROM users WHERE user_id = @param0", new object[] { userId }) > 0;
        }

        // 5. Lấy danh sách lớp cho ComboBox
        public DataTable GetAllClasses()
        {
            return DbConnect.ExecuteQuery("SELECT class_id, class_name FROM classes");
        }

        // 6. Lấy danh sách năm học cho ComboBox
        public DataTable GetAllYears()
        {
            return DbConnect.ExecuteQuery("SELECT year_id, name FROM academic_years");
        }

        // --- HELPER FUNCTIONS ---
        private StudentDTO MapDataRowToStudent(DataRow row)
        {
            return new StudentDTO
            {
                StudentID = Convert.ToInt32(row["student_id"]),
                UserID = Convert.ToInt32(row["user_id"]),
                FullName = row["fullname"].ToString(),
                DateOfBirth = row["dob"] != DBNull.Value ? Convert.ToDateTime(row["dob"]) : DateTime.MinValue,
                Gender = row["gender"].ToString(),
                Address = row["address"].ToString(),
                ClassID = row.Table.Columns.Contains("class_id") && row["class_id"] != DBNull.Value ? Convert.ToInt32(row["class_id"]) : 0,
                ClassName = row.Table.Columns.Contains("class_name") && row["class_name"] != DBNull.Value ? row["class_name"].ToString() : "Chưa xếp lớp",
                AcademicYear = row.Table.Columns.Contains("year_name") && row["year_name"] != DBNull.Value ? row["year_name"].ToString() : ""
            };
        }

        private void GetParentInfo(StudentDTO s)
        {
            string query = @"
                SELECT sp.relation, u.fullname, u.phone, p.job
                FROM student_parent sp
                JOIN parents p ON sp.parent_id = p.parent_id
                JOIN users u ON p.user_id = u.user_id
                WHERE sp.student_id = @param0";

            DataTable dt = DbConnect.ExecuteQuery(query, new object[] { s.StudentID });
            foreach (DataRow row in dt.Rows)
            {
                string relation = row["relation"].ToString();
                if (relation == "Cha")
                {
                    s.FatherName = row["fullname"].ToString();
                    s.FatherPhone = row["phone"].ToString();
                    s.FatherJob = row["job"].ToString();
                }
                else if (relation == "Mẹ")
                {
                    s.MotherName = row["fullname"].ToString();
                    s.MotherPhone = row["phone"].ToString();
                    s.MotherJob = row["job"].ToString();
                }
            }
        }

    }
}