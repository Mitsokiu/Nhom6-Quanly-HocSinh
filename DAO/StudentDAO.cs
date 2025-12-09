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
        private static readonly Random _random = new Random();
        //private StudentDAO dao = new StudentDAO();
        public static DataTable GetStudents(int yearId, int classId)
        {

            DataTable dt = new DataTable();
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT 
                s.student_id AS Id,
                u.fullname AS Ten,
                s.dob AS 'Ngay Sinh',
                s.gender AS 'Gioi Tinh',
                s.address AS DiaChi,
                c.class_name AS Lop

            FROM students s
            JOIN users u ON u.user_id = s.user_id
            LEFT JOIN student_class sc
                   ON sc.student_id = s.student_id 
                  AND sc.school_year_id = @year_id
            LEFT JOIN classes c 
                   ON c.class_id = sc.class_id
        ";

                if (classId > 0)
                    sql += " WHERE sc.class_id = @class_id";

                sql += " ORDER BY u.fullname";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@year_id", yearId);
                    if (classId > 0)
                        cmd.Parameters.AddWithValue("@class_id", classId);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable GetStudentById(int studentId, int yearId)
        {
            DataTable dt = new DataTable();

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT 
                s.student_id AS Id,
                u.fullname AS Ten,
                s.dob AS NgaySinh,
                s.gender AS GioiTinh,
                s.address AS DiaChi,
                c.class_name AS Lop
            FROM students s
            JOIN users u ON u.user_id = s.user_id
            LEFT JOIN student_class sc 
                   ON sc.student_id = s.student_id
                  AND sc.school_year_id = @year_id
            LEFT JOIN classes c 
                   ON c.class_id = sc.class_id
            WHERE s.student_id = @student_id
            LIMIT 1
        ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@student_id", studentId);
                    cmd.Parameters.AddWithValue("@year_id", yearId);

                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }



        public static bool UpdateStudent(StudentDTO student)
        {
            try
            {
                using (var conn = DbConnect.GetConnection())
                {
                    conn.Open();

                    string sqlStudent = @"
                UPDATE students s
                JOIN users u ON s.user_id = u.user_id
                SET u.fullname = @Ten,
                    s.dob = @NgaySinh,
                    s.gender = @GioiTinh,
                    s.address = @DiaChi
                WHERE s.student_id = @Id
            ";

                    using (var cmd = new MySqlCommand(sqlStudent, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", student.Ten);
                        cmd.Parameters.AddWithValue("@NgaySinh", student.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", student.GioiTinh);
                        cmd.Parameters.AddWithValue("@DiaChi", student.DiaChi ?? "");
                        cmd.Parameters.AddWithValue("@Id", student.Id);
                        cmd.ExecuteNonQuery();
                    }

                    if (student.ClassId > 0 && student.YearId > 0)
                    {
                        string sqlClass = @"
                        UPDATE student_class
                        SET class_id = @ClassId
                        WHERE student_id = @Id AND school_year_id = @YearId
                    ";

                        

                        using (var cmdClass = new MySqlCommand(sqlClass, conn))
                        {
                            cmdClass.Parameters.AddWithValue("@Id", student.Id);
                            cmdClass.Parameters.AddWithValue("@ClassId", student.ClassId);
                            cmdClass.Parameters.AddWithValue("@YearId", student.YearId);
                            cmdClass.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                return false;
            }
        }

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
            return -1; 
        }

        public int GetStudentIdByUserId(int userID)
        {
            String query = "SELECT student_id FROM students WHERE user_id = @param0";
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { userID });
            if (data.Rows.Count > 0)
                return (int)data.Rows[0]["student_id"];
            return -1;
        }



        // 1. Lấy toàn bộ danh sách học sinh (Kèm Lớp và Năm học)
        //public List<StudentDTO> GetStudents()
        //{
        //    List<StudentDTO> list = new List<StudentDTO>();

        //    // Query lấy thông tin học sinh và lớp học hiện tại
        //    // Sử dụng LEFT JOIN để vẫn lấy được HS chưa xếp lớp
        //    string query = @"
        //                SELECT s.student_id, s.user_id, u.fullname, s.dob, s.gender, s.address, 
        //                        c.class_id, c.class_name, ay.name AS year_name
        //                FROM students s
        //                JOIN users u ON s.user_id = u.user_id
        //                LEFT JOIN student_class sc ON s.student_id = sc.student_id
        //                LEFT JOIN classes c ON sc.class_id = c.class_id
        //                LEFT JOIN academic_years ay ON sc.school_year_id = ay.year_id
        //                WHERE u.role_id = 'student'
        //                ORDER BY s.student_id DESC";

        //    DataTable data = DbConnect.ExecuteQuery(query);
        //    //foreach (DataRow row in data.Rows)
        //    //{
        //    //    StudentDTO student = MapDataRowToStudent(row);
        //    //    // Gọi hàm lấy thêm thông tin phụ huynh
        //    //    GetParentInfo(student);
        //    //    list.Add(student);
        //    //}
        //    return list;
        //}

        public List<StudentDTO> GetStudents()
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
        ORDER BY s.student_id DESC";

            DataTable data = DbConnect.ExecuteQuery(query);

          
                foreach (DataRow row in data.Rows)
                {
                    StudentDTO student = new StudentDTO
                    {
                        StudentID = Convert.ToInt32(row["student_id"]),
                        UserID = Convert.ToInt32(row["user_id"]),
                        FullName = row["fullname"].ToString(),
                        DateOfBirth = row["dob"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["dob"]),
                        Gender = row["gender"].ToString(),
                        Address = row["address"].ToString(),
                        ClassID = row["class_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["class_id"]),
                        ClassName = row["class_name"].ToString(),
                        AcademicYear = row["year_name"].ToString()
                    };
                    list.Add(student);
                }


             
            return list;
        }


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
                    string prefix = (role == "student") ? "hs" : "ph";
                    string shortCode = _random.Next(100000, 999999).ToString();
                    string username = prefix + shortCode;

                    string queryUser = @"INSERT INTO users (username, password, fullname, role_id, avatar, phone) 
                                         VALUES (@param0, '123456', @param1, @param2, @param3, @param4); 
                                         SELECT LAST_INSERT_ID();";

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
                    if (ex.Number == 1062) 
                        retryCount++;
                    else
                        throw;
                }
            }
            return newUserId;
        }

    
        public bool AddStudent(StudentDTO s)
        {
            int newUserId = InsertUserSafe(s.FullName, "student", s.Avatar);
            if (newUserId <= 0) return false;

            string queryStudent = @"INSERT INTO students (user_id, dob, gender, address) 
                                    VALUES (@param0, @param1, @param2, @param3); 
                                    SELECT LAST_INSERT_ID();";

            object studentIdObj = DbConnect.ExecuteScalar(queryStudent, new object[] {
                newUserId, s.DateOfBirth.Date, s.Gender, s.Address
            });

            if (studentIdObj == null) return false;
            int newStudentId = Convert.ToInt32(studentIdObj);

            if (s.ClassID > 0 && s.YearID > 0)
            {
                string queryClass = @"INSERT INTO student_class (student_id, class_id, school_year_id) 
                                      VALUES (@param0, @param1, @param2)";
                DbConnect.ExecuteNonQuery(queryClass, new object[] { newStudentId, s.ClassID, s.YearID });
            }

            AddParent(newStudentId, s.FatherName, s.FatherPhone, s.FatherJob, "Cha");
            AddParent(newStudentId, s.MotherName, s.MotherPhone, s.MotherJob, "Mẹ");

            return true;
        }

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

        public bool DeleteStudent(int studentID)
        {
            string queryGet = "SELECT user_id FROM students WHERE student_id = @param0";
            DataTable dt = DbConnect.ExecuteQuery(queryGet, new object[] { studentID });
            if (dt.Rows.Count == 0) return false;
            int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);

            DbConnect.ExecuteNonQuery("DELETE FROM student_class WHERE student_id = @param0", new object[] { studentID });
            DbConnect.ExecuteNonQuery("DELETE FROM scores WHERE student_id = @param0", new object[] { studentID });
            DbConnect.ExecuteNonQuery("DELETE FROM tuition WHERE student_id = @param0", new object[] { studentID });

           
            DbConnect.ExecuteNonQuery("DELETE FROM student_parent WHERE student_id = @param0", new object[] { studentID });

            DbConnect.ExecuteNonQuery("DELETE FROM students WHERE student_id = @param0", new object[] { studentID });
            return DbConnect.ExecuteNonQuery("DELETE FROM users WHERE user_id = @param0", new object[] { userId }) > 0;
        }

        public bool UpdateStudents(StudentDTO s)
        {
            string updateStudent = @"UPDATE students SET dob = @param0, gender = @param1, address = @param2 WHERE student_id = @param3";
            DbConnect.ExecuteNonQuery(updateStudent, new object[] { s.DateOfBirth, s.Gender, s.Address, s.StudentID });

            string updateUser = @"UPDATE users SET fullname = @param0 WHERE user_id = @param1";
            DbConnect.ExecuteNonQuery(updateUser, new object[] { s.FullName, s.UserID });

   
            string updateClass = @"UPDATE student_class SET class_id = @param0, school_year_id = @param1 WHERE student_id = @param2";
            DbConnect.ExecuteNonQuery(updateClass, new object[] { s.ClassID, s.YearID, s.StudentID });

            UpdateParentInfo(s.StudentID, "Cha", s.FatherName, s.FatherPhone, s.FatherJob);
            UpdateParentInfo(s.StudentID, "Mẹ", s.MotherName, s.MotherPhone, s.MotherJob);

            return true;
        }

        private void UpdateParentInfo(int studentId, string relation, string name, string phone, string job)
        {
            string sqlFind = @"SELECT p.parent_id, p.user_id FROM student_parent sp 
                               JOIN parents p ON sp.parent_id = p.parent_id 
                               WHERE sp.student_id = @param0 AND sp.relation = @param1 LIMIT 1";
            DataTable dt = DbConnect.ExecuteQuery(sqlFind, new object[] { studentId, relation });

            if (dt.Rows.Count > 0)
            {
                int parentId = Convert.ToInt32(dt.Rows[0]["parent_id"]);
                int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);

                DbConnect.ExecuteNonQuery("UPDATE users SET fullname = @param0, phone = @param1 WHERE user_id = @param2", new object[] { name, phone, userId });
                DbConnect.ExecuteNonQuery("UPDATE parents SET job = @param0 WHERE parent_id = @param1", new object[] { job, parentId });
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                AddParent(studentId, name, phone, job, relation);
            }
        }

        public DataTable GetAllClasses()
        {
            return DbConnect.ExecuteQuery("SELECT class_id, class_name FROM classes");
        }

        public DataTable GetAllYears()
        {
            return DbConnect.ExecuteQuery("SELECT year_id, name FROM academic_years");
        }

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
        public DataTable GetStudentMainInfo(int userId)
        {
            string query = @"
                SELECT 
                    s.student_id, u.fullname, u.email, u.phone,
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

        public List<StudentDTO> GetStudentss()
        {
            List<StudentDTO> list = new List<StudentDTO>();
            string query = @"
                SELECT s.student_id, s.user_id, u.fullname,s.dob, s.gender, s.address, 
                       c.class_id, c.class_name, ay.name AS year_name
                FROM students s
                JOIN users u ON s.user_id = u.user_id
                LEFT JOIN student_class sc ON s.student_id = sc.student_id
                LEFT JOIN classes c ON sc.class_id = c.class_id
                LEFT JOIN academic_years ay ON sc.school_year_id = ay.year_id
                WHERE u.role_id = 'student'
                ORDER BY SUBSTRING_INDEX(u.fullname, ' ', -1) ASC, u.fullname ASC";

            DataTable data = DbConnect.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                StudentDTO student = MapDataRowToStudent(row);
                GetParentInfo(student);
                list.Add(student);
            }
            return list;
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

        public StudentProfileDTO GetStudentProfile(int userId)
        {
            StudentProfileDTO profile = new StudentProfileDTO();

            DataTable dtMain = GetStudentMainInfo(userId);

            if (dtMain.Rows.Count > 0)
            {
                DataRow row = dtMain.Rows[0];
                int sId = Convert.ToInt32(row["student_id"]);

                profile.StudentId = sId;
                profile.StudentCode = "HS" + sId.ToString("D6");
                profile.FullName = row["fullname"].ToString();
                profile.Email = row["email"].ToString();
                profile.Phone = row["phone"].ToString();
                profile.Address = row["address"].ToString();

                string genderRaw = row["gender"].ToString();
                profile.Gender = (genderRaw == "Male") ? "Nam" : "Nữ";

                if (row["dob"] != DBNull.Value)
                    profile.DateOfBirth = Convert.ToDateTime(row["dob"]);

                profile.ClassName = row["class_name"].ToString();
                profile.SchoolYear = row["school_year"].ToString();

                profile.TeacherName = row["gvcn_name"].ToString();
                profile.TeacherPhone = row["gvcn_phone"].ToString();

                if (row.Table.Columns.Contains("avatar") && row["avatar"] != DBNull.Value)
                {
                    profile.Avatar = row["avatar"].ToString();
                }
                else
                {
                    profile.Avatar = "";
                }



                DataTable dtParents = GetStudentParents(sId);
                foreach (DataRow pRow in dtParents.Rows)
                {
                    string relation = pRow["relation"].ToString().Trim();

                    if (relation.Equals("Cha", StringComparison.OrdinalIgnoreCase))
                    {
                        profile.FatherName = pRow["fullname"].ToString();
                        profile.FatherPhone = pRow["phone"].ToString();
                        profile.FatherEmail = pRow["email"].ToString();
                        profile.FatherJob = pRow["job"].ToString();
                    }
                    else if (relation.Equals("Mẹ", StringComparison.OrdinalIgnoreCase))
                    {
                        profile.MotherName = pRow["fullname"].ToString();
                        profile.MotherPhone = pRow["phone"].ToString();
                        profile.MotherEmail = pRow["email"].ToString();
                        profile.MotherJob = pRow["job"].ToString();
                    }
                }
            }
            return profile;
        }

    }
}
