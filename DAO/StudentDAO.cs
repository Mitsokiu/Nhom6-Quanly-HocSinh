using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAO
{
    public class StudentDAO
    {
        private DbConnect db = new DbConnect();

        // ---------------------------------------------------------
        // 1. SINH USERNAME cho ho sinh
        // ---------------------------------------------------------
        private string GenerateStudentUsername(int classId)
        {
            string className = "k";
            string queryClass = "SELECT class_name FROM classes WHERE class_id = @param0";
            DataTable dtClass = DbConnect.ExecuteQuery(queryClass, new object[] { classId });
            if (dtClass.Rows.Count > 0)
                className = dtClass.Rows[0]["class_name"].ToString().ToLower().Replace(" ", "");

            string queryCount = "SELECT COUNT(*) FROM student_class WHERE class_id = @param0";
            object result = DbConnect.ExecuteScalar(queryCount, new object[] { classId });
            int nextNumber = 1;
            if (result != null) nextNumber = Convert.ToInt32(result) + 1;

            return $"hs{className}{nextNumber:D3}";
        }

        // ---------------------------------------------------------
        // 2. TẠO TÀI KHOẢN PHỤ HUYNH 
        // ---------------------------------------------------------
        private int CreateParentAccount(string fullname, string phone, string job)
        {
            if (string.IsNullOrWhiteSpace(fullname)) return -1;

            string username = "ph" + (string.IsNullOrWhiteSpace(phone) ? DateTime.Now.Ticks.ToString() : phone);

            string sqlUser = @"INSERT INTO users (username, password, fullname, phone, role_id) 
                               VALUES (@param0, '123456', @param1, @param2, 'parent'); 
                               SELECT LAST_INSERT_ID();";

            object userRes = null;
            try
            {
                userRes = DbConnect.ExecuteScalar(sqlUser, new object[] { username, fullname, phone });
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Trùng username
                {
                    username += "_" + new Random().Next(10, 99);
                    userRes = DbConnect.ExecuteScalar(sqlUser, new object[] { username, fullname, phone });
                }
                else throw;
            }

            if (userRes == null) return -1;
            int userId = Convert.ToInt32(userRes);

            string sqlParent = "INSERT INTO parents (user_id, job) VALUES (@param0, @param1); SELECT LAST_INSERT_ID();";
            object parentRes = DbConnect.ExecuteScalar(sqlParent, new object[] { userId, job });

            return (parentRes != null) ? Convert.ToInt32(parentRes) : -1;
        }

        // ---------------------------------------------------------
        // THÊM HỌC SINH
        // ---------------------------------------------------------
        public bool AddStudent(StudentDTO s)
        {
            // A. Tạo User Học sinh
            string hsUsername = GenerateStudentUsername(s.ClassID);

            string sqlUserHS = @"INSERT INTO users (username, password, fullname, role_id, avatar, phone) 
                                 VALUES (@param0, '123456', @param1, 'student', @param2, ''); 
                                 SELECT LAST_INSERT_ID();";

            object resUserHS = DbConnect.ExecuteScalar(sqlUserHS, new object[] { hsUsername, s.FullName, s.Avatar });
            if (resUserHS == null) return false;
            int hsUserId = Convert.ToInt32(resUserHS);

            // B. Tạo Student Profile
            string sqlStudent = @"INSERT INTO students (user_id, dob, gender, address) 
                                  VALUES (@param0, @param1, @param2, @param3); 
                                  SELECT LAST_INSERT_ID();";
            object resStudent = DbConnect.ExecuteScalar(sqlStudent, new object[] {
                hsUserId, s.DateOfBirth, s.Gender, s.Address
            });

            if (resStudent == null) return false;
            int newStudentId = Convert.ToInt32(resStudent);

            // C. Xếp lớp
            if (s.ClassID > 0 && s.YearID > 0)
            {
                DbConnect.ExecuteNonQuery(
                    "INSERT INTO student_class (student_id, class_id, school_year_id) VALUES (@param0, @param1, @param2)",
                    new object[] { newStudentId, s.ClassID, s.YearID }
                );
            }

            // D. Xử lý Phụ huynh
            // -- Cha --
            if (!string.IsNullOrWhiteSpace(s.FatherName))
            {
                int fatherId = CreateParentAccount(s.FatherName, s.FatherPhone, s.FatherJob);
                if (fatherId > 0)
                {
                    DbConnect.ExecuteNonQuery(
                        "INSERT INTO student_parent (student_id, parent_id, relation) VALUES (@param0, @param1, 'Cha')",
                        new object[] { newStudentId, fatherId }
                    );
                }
            }
            // -- Mẹ --
            if (!string.IsNullOrWhiteSpace(s.MotherName))
            {
                int motherId = CreateParentAccount(s.MotherName, s.MotherPhone, s.MotherJob);
                if (motherId > 0)
                {
                    DbConnect.ExecuteNonQuery(
                        "INSERT INTO student_parent (student_id, parent_id, relation) VALUES (@param0, @param1, 'Mẹ')",
                        new object[] { newStudentId, motherId }
                    );
                }
            }

            return true;
        }

        // ---------------------------------------------------------
        // LẤY DANH SÁCH
        // ---------------------------------------------------------
        public List<StudentDTO> GetStudents()
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
                  AND (u.fullname LIKE @param0 OR u.username LIKE @param0)
                ORDER BY SUBSTRING_INDEX(u.fullname, ' ', -1) ASC, u.fullname ASC";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
            foreach (DataRow row in data.Rows)
            {
                StudentDTO student = MapDataRowToStudent(row);
                GetParentInfo(student);
                list.Add(student);
            }
            return list;
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
                string rel = row["relation"].ToString();
                if (rel == "Cha")
                {
                    s.FatherName = row["fullname"].ToString();
                    s.FatherPhone = row["phone"].ToString();
                    s.FatherJob = row["job"].ToString();
                }
                else if (rel == "Mẹ")
                {
                    s.MotherName = row["fullname"].ToString();
                    s.MotherPhone = row["phone"].ToString();
                    s.MotherJob = row["job"].ToString();
                }
            }
        }

        // ---------------------------------------------------------
        // UPDATE HỌC SINH
        // ---------------------------------------------------------
        public bool UpdateStudent(StudentDTO s)
        {
            // 1. Update Students
            DbConnect.ExecuteNonQuery(
                "UPDATE students SET dob=@param0, gender=@param1, address=@param2 WHERE student_id=@param3",
                new object[] { s.DateOfBirth, s.Gender, s.Address, s.StudentID }
            );

            // 2. Update Users
            DbConnect.ExecuteNonQuery(
                "UPDATE users SET fullname=@param0 WHERE user_id=@param1",
                new object[] { s.FullName, s.UserID }
            );

            // 3. Update Lớp
            DbConnect.ExecuteNonQuery(
                "UPDATE student_class SET class_id=@param0, school_year_id=@param1 WHERE student_id=@param2",
                new object[] { s.ClassID, s.YearID, s.StudentID }
            );

            // 4. Update Phụ huynh
            UpdateOrInsertParent(s.StudentID, "Cha", s.FatherName, s.FatherPhone, s.FatherJob);
            UpdateOrInsertParent(s.StudentID, "Mẹ", s.MotherName, s.MotherPhone, s.MotherJob);

            return true;
        }

        private void UpdateOrInsertParent(int studentId, string relation, string name, string phone, string job)
        {
            string sqlFind = @"SELECT p.parent_id, p.user_id FROM student_parent sp 
                               JOIN parents p ON sp.parent_id = p.parent_id 
                               WHERE sp.student_id = @param0 AND sp.relation = @param1 LIMIT 1";
            DataTable dt = DbConnect.ExecuteQuery(sqlFind, new object[] { studentId, relation });

            if (dt.Rows.Count > 0)
            {
                // Update
                int pId = Convert.ToInt32(dt.Rows[0]["parent_id"]);
                int uId = Convert.ToInt32(dt.Rows[0]["user_id"]);

                DbConnect.ExecuteNonQuery("UPDATE users SET fullname=@param0, phone=@param1 WHERE user_id=@param2",
                    new object[] { name, phone, uId });

                DbConnect.ExecuteNonQuery("UPDATE parents SET job=@param0 WHERE parent_id=@param1",
                    new object[] { job, pId });
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                // Insert
                int newPId = CreateParentAccount(name, phone, job);
                if (newPId > 0)
                {
                    // SỬA: @p0, @p1, @p2 -> @param0, @param1, @param2
                    DbConnect.ExecuteNonQuery(
                        "INSERT INTO student_parent (student_id, parent_id, relation) VALUES (@param0, @param1, @param2)",
                        new object[] { studentId, newPId, relation }
                    );
                }
            }
        }

        // ---------------------------------------------------------
        // ---------------------------------------------------------
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

        public bool DeleteStudent(int studentID)
        {
            string queryGet = "SELECT user_id FROM students WHERE student_id = @param0";
            DataTable dt = DbConnect.ExecuteQuery(queryGet, new object[] { studentID });
            if (dt.Rows.Count == 0) return false;
            int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);

            DbConnect.ExecuteNonQuery("DELETE FROM student_parent WHERE student_id = @param0", new object[] { studentID });

            return DbConnect.ExecuteNonQuery("DELETE FROM users WHERE user_id = @param0", new object[] { userId }) > 0;
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
    }
}