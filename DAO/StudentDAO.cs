using DTO;
using MySql.Data.MySqlClient;
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
        private static readonly Random _random = new Random();

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

        public DataTable GetStudentMainInfo(int userId)
        {
            string query = @"
                SELECT 
                    s.student_id, u.fullname, u.email, u.phone, u.avatar,
                    s.dob, s.gender, s.address, 
                    c.class_name, ay.name AS school_year,
                    teacher.fullname AS gvcn_name, teacher.phone AS gvcn_phone
                FROM users u
                JOIN students s ON u.user_id = s.user_id
                LEFT JOIN student_class sc ON s.student_id = sc.student_id
                LEFT JOIN classes c ON sc.class_id = c.class_id
                LEFT JOIN academic_years ay ON sc.school_year_id = ay.year_id
                LEFT JOIN homeroom_assignments ha ON c.class_id = ha.class_id AND ha.year_id = ay.year_id
                LEFT JOIN users teacher ON ha.teacher_id = teacher.user_id
                WHERE u.user_id = @param0
                ORDER BY ay.start_date DESC 
                LIMIT 1";

            return DbConnect.ExecuteQuery(query, new object[] { userId });
        }

        public DataTable GetStudentParents(int studentId)
        {
            string query = @"
                SELECT 
                    p_user.fullname, p_user.phone, p_user.email, 
                    p.job, sp.relation
                FROM student_parent sp
                JOIN parents p ON sp.parent_id = p.parent_id
                JOIN users p_user ON p.user_id = p_user.user_id
                WHERE sp.student_id = @param0";

            return DbConnect.ExecuteQuery(query, new object[] { studentId });
        }
        // 1. Lấy toàn bộ danh sách học sinh (Kèm Lớp và Năm học)
        public List<StudentDTO> GetStudents()
        {
            List<StudentDTO> list = new List<StudentDTO>();

            // Query lấy thông tin học sinh và lớp học hiện tại
            // Sử dụng LEFT JOIN để vẫn lấy được HS chưa xếp lớp
            string query = @"
                        SELECT s.student_id, s.user_id, u.fullname, u.avatar, s.dob, s.gender, s.address, 
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
                SELECT s.student_id, s.user_id, u.fullname, u.avatar, s.dob, s.gender, s.address, 
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


        private int InsertUserSafe(string fullName, string role, string avatar, string phone = "")
        {
            int newUserId = 0;
            bool inserted = false;
            int retryCount = 0;

            while (!inserted && retryCount < 5)
            {
                try
                {
                    // Tạo username: hs + 6 số ngẫu nhiên
                    string prefix = (role == "student") ? "hs" : "ph";
                    string shortCode = _random.Next(100000, 999999).ToString();
                    string username = prefix + shortCode;

                    // --- SỬA LỖI Ở ĐÂY: Dùng @param0, @param1... ---
                    string queryUser = @"INSERT INTO users (username, password, fullname, role_id, avatar, phone) 
                                         VALUES (@param0, '123456', @param1, @param2, @param3, @param4); 
                                         SELECT LAST_INSERT_ID();";

                    // Thứ tự tham số: 0:username, 1:fullname, 2:role, 3:avatar, 4:phone
                    object result = DbConnect.ExecuteScalar(queryUser, new object[] {
                        username, fullName, role, avatar, phone
                    });

                    if (result != null)
                    {
                        newUserId = Convert.ToInt32(result);
                        inserted = true;
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // Duplicate entry
                        retryCount++;
                    else
                        throw;
                }
            }
            return newUserId;
        }

        // ---------------------------------------------------------
        // 2. HÀM ADD STUDENT (Gọi hàm trên)
        // ---------------------------------------------------------
        public bool AddStudent(StudentDTO s)
        {
            // Bước 1: Tạo User Học sinh
            int newUserId = InsertUserSafe(s.FullName, "student", s.Avatar);
            if (newUserId <= 0) return false;

            // Bước 2: Tạo Student Info (Dùng @param0...)
            string queryStudent = @"INSERT INTO students (user_id, dob, gender, address) 
                                    VALUES (@param0, @param1, @param2, @param3); 
                                    SELECT LAST_INSERT_ID();";

            object studentIdObj = DbConnect.ExecuteScalar(queryStudent, new object[] {
                newUserId, s.DateOfBirth.Date, s.Gender, s.Address
            });

            if (studentIdObj == null) return false;
            int newStudentId = Convert.ToInt32(studentIdObj);

            // Bước 3: Xếp lớp
            if (s.ClassID > 0 && s.YearID > 0)
            {
                string queryClass = @"INSERT INTO student_class (student_id, class_id, school_year_id) 
                                      VALUES (@param0, @param1, @param2)";
                DbConnect.ExecuteNonQuery(queryClass, new object[] { newStudentId, s.ClassID, s.YearID });
            }

            // Bước 4: Tạo User Phụ huynh
            AddParent(newStudentId, s.FatherName, s.FatherPhone, s.FatherJob, "Cha");
            AddParent(newStudentId, s.MotherName, s.MotherPhone, s.MotherJob, "Mẹ");

            return true;
        }

        // Helper thêm phụ huynh (tách ra cho gọn)
        private void AddParent(int studentId, string name, string phone, string job, string relation)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            string username = "ph" + DateTime.Now.Ticks + (relation == "Cha" ? "1" : "2");
            object userId = DbConnect.ExecuteScalar("INSERT INTO users (username, password, fullname, phone, role_id) VALUES (@param0, '123456', @param1, @param2, 'parent'); SELECT LAST_INSERT_ID();", new object[] { username, name, phone });
            if (userId != null)
            {
                object parentId = DbConnect.ExecuteScalar("INSERT INTO parents (user_id, job) VALUES (@param0, @param1); SELECT LAST_INSERT_ID();", new object[] { userId, job });
                if (parentId != null) DbConnect.ExecuteNonQuery("INSERT INTO student_parent (student_id, parent_id, relation) VALUES (@param0, @param1, @param2)", new object[] { studentId, parentId, relation });
            }
        }

        // 4. Xóa học sinh
        public bool DeleteStudent(int studentID)
        {
            string queryGet = "SELECT user_id FROM students WHERE student_id = @param0";
            DataTable dt = DbConnect.ExecuteQuery(queryGet, new object[] { studentID });
            if (dt.Rows.Count == 0) return false;
            int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);

            // Xóa các bảng phụ thuộc
            DbConnect.ExecuteNonQuery("DELETE FROM student_class WHERE student_id = @param0", new object[] { studentID });
            DbConnect.ExecuteNonQuery("DELETE FROM scores WHERE student_id = @param0", new object[] { studentID });
            DbConnect.ExecuteNonQuery("DELETE FROM tuition WHERE student_id = @param0", new object[] { studentID });

            // Xóa Parent liên kết (Phức tạp hơn nếu parent có nhiều con, ở đây xóa link student_parent trước)
            // Lấy list parent_id để xóa user nếu cần (bỏ qua bước xóa user phụ huynh để an toàn dữ liệu)
            DbConnect.ExecuteNonQuery("DELETE FROM student_parent WHERE student_id = @param0", new object[] { studentID });

            DbConnect.ExecuteNonQuery("DELETE FROM students WHERE student_id = @param0", new object[] { studentID });
            return DbConnect.ExecuteNonQuery("DELETE FROM users WHERE user_id = @param0", new object[] { userId }) > 0;
        }

        public bool UpdateStudent(StudentDTO s)
        {
            // 1. Cập nhật thông tin cơ bản (Bảng Users và Students)
            string updateStudent = @"UPDATE students SET dob = @param0, gender = @param1, address = @param2 WHERE student_id = @param3";
            DbConnect.ExecuteNonQuery(updateStudent, new object[] { s.DateOfBirth, s.Gender, s.Address, s.StudentID });

            string updateUser = @"UPDATE users SET fullname = @param0 WHERE user_id = @param1";
            DbConnect.ExecuteNonQuery(updateUser, new object[] { s.FullName, s.UserID });

            // 2. Cập nhật Lớp (Nếu có thay đổi) - Cập nhật bản ghi mới nhất trong student_class
            // Giả sử logic là update bản ghi hiện tại
            string updateClass = @"UPDATE student_class SET class_id = @param0, school_year_id = @param1 WHERE student_id = @param2";
            // Lưu ý: Thực tế có thể cần INSERT mới nếu là chuyển lớp, ở đây ta UPDATE cho đơn giản
            DbConnect.ExecuteNonQuery(updateClass, new object[] { s.ClassID, s.YearID, s.StudentID });

            // 3. Cập nhật Phụ huynh (Khó hơn vì phải tìm ID)
            UpdateParentInfo(s.StudentID, "Cha", s.FatherName, s.FatherPhone, s.FatherJob);
            UpdateParentInfo(s.StudentID, "Mẹ", s.MotherName, s.MotherPhone, s.MotherJob);

            return true;
        }

        private void UpdateParentInfo(int studentId, string relation, string name, string phone, string job)
        {
            // Tìm parent_id dựa vào quan hệ
            string sqlFind = @"SELECT p.parent_id, p.user_id FROM student_parent sp 
                               JOIN parents p ON sp.parent_id = p.parent_id 
                               WHERE sp.student_id = @param0 AND sp.relation = @param1 LIMIT 1";
            DataTable dt = DbConnect.ExecuteQuery(sqlFind, new object[] { studentId, relation });

            if (dt.Rows.Count > 0)
            {
                // Đã có -> Update
                int parentId = Convert.ToInt32(dt.Rows[0]["parent_id"]);
                int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);

                DbConnect.ExecuteNonQuery("UPDATE users SET fullname = @param0, phone = @param1 WHERE user_id = @param2", new object[] { name, phone, userId });
                DbConnect.ExecuteNonQuery("UPDATE parents SET job = @param0 WHERE parent_id = @param1", new object[] { job, parentId });
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                // Chưa có nhưng người dùng nhập mới -> Thêm mới
                AddParent(studentId, name, phone, job, relation);
            }
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
                Avatar = row.Table.Columns.Contains("avatar") && row["avatar"] != DBNull.Value ? row["avatar"].ToString() : "",
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