using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    /// <summary>
    /// TimetableDAO - truy xuất DB cho thời khoá biểu.
    /// Có thể cấu hình nguồn bảng giáo viên (users hoặc teachers) để giữ tương thích.
    /// Yêu cầu: lớp DbConnect với các helper ExecuteQuery/ExecuteNonQuery/ExecuteScalar giống dự án của bạn.
    /// </summary>
    public class TimetableDAO
    {
        private DbConnect db = new DbConnect();

        // Nếu dự án của bạn có bảng teachers riêng, chuyển sang Teachers; nếu giáo viên lưu ở users, chọn Users.
        public enum TeacherSource
        {
            Users,
            Teachers
        }

        // Mặc định: Users (thường an toàn). Bạn có thể set từ nơi khác nếu cần.
        public static TeacherSource TeacherTable = TeacherSource.Users;

        #region Basic CRUD + Helpers

        public List<TimetableDTO> GetTimetableByClass(int classID, int semesterID)
        {
            List<TimetableDTO> list = new List<TimetableDTO>();

            string query = @"
        SELECT 
            s.name AS SubjectName, 
            " + (TeacherTable == TeacherSource.Users
                        ? "u.fullname"
                        : "t.teacher_name") + @" AS TeacherName, 
            tt.room, 
            tt.day, 
            tt.period
        FROM timetable tt
        JOIN subjects s ON tt.subject_id = s.subject_id
        LEFT JOIN " + (TeacherTable == TeacherSource.Users
                        ? "users u ON tt.teacher_id = u.user_id"
                        : "teachers t ON tt.teacher_id = t.teacher_id") + @"
        WHERE tt.class_id = @param0 AND tt.semester_id = @param1
        ORDER BY FIELD(tt.day,'Mon','Tue','Wed','Thu','Fri','Sat'), tt.period ASC";

            object[] parameters = { classID, semesterID };

            DataTable data = DbConnect.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new TimetableDTO
                {
                    SubjectName = row["SubjectName"].ToString(),
                    TeacherName = row["TeacherName"].ToString(),
                    Room = row["room"].ToString(),
                    Day = row["day"].ToString(),
                    Period = Convert.ToInt32(row["period"])
                });
            }

            return list;
        }


        public static DataTable GetTimetable(int semesterId)
        {
            string teacherCol = (TeacherTable == TeacherSource.Users) ? "u.full_name" : "t.teacher_name";
            string teacherJoin = (TeacherTable == TeacherSource.Users) ?
                "LEFT JOIN users u ON tt.teacher_id = u.user_id" :
                "LEFT JOIN teachers t ON tt.teacher_id = t.teacher_id";

            string query = $@"
                SELECT tt.id, tt.class_id, tt.subject_id, tt.teacher_id, 
                       tt.semester_id, tt.day, tt.period, tt.room,
                       c.class_name, s.subject_name, {teacherCol} AS teacher_name
                FROM timetable tt
                JOIN classes c ON tt.class_id = c.class_id
                JOIN subjects s ON tt.subject_id = s.subject_id
                {teacherJoin}
                WHERE tt.semester_id = @sem
                ORDER BY FIELD(tt.day,'Mon','Tue','Wed','Thu','Fri','Sat'), tt.period ASC";

            MySqlParameter[] param = {
                new MySqlParameter("@sem", semesterId)
            };

            return DbConnect.ExecuteQuery(query, param);
        }

        public static bool Insert(TimetableDTO dto)
        {
            string query = @"
                INSERT INTO timetable(class_id, subject_id, teacher_id, semester_id, day, period, room)
                VALUES (@class, @subject, @teacher, @sem, @day, @period, @room)";

            MySqlParameter[] param = {
                new MySqlParameter("@class", dto.ClassId),
                new MySqlParameter("@subject", dto.SubjectId),
                new MySqlParameter("@teacher", dto.TeacherId),
                new MySqlParameter("@sem", dto.SemesterId),
                new MySqlParameter("@day", dto.Day),
                new MySqlParameter("@period", dto.Period),
                new MySqlParameter("@room", dto.Room ?? string.Empty)
            };

            return DbConnect.ExecuteNonQuery(query, param) > 0;
        }

        public static bool Update(TimetableDTO dto)
        {
            string query = @"
                UPDATE timetable 
                SET class_id=@class, subject_id=@subject, teacher_id=@teacher,
                    semester_id=@sem, day=@day, period=@period, room=@room
                WHERE id=@id";

            MySqlParameter[] param = {
                new MySqlParameter("@id", dto.Id),
                new MySqlParameter("@class", dto.ClassId),
                new MySqlParameter("@subject", dto.SubjectId),
                new MySqlParameter("@teacher", dto.TeacherId),
                new MySqlParameter("@sem", dto.SemesterId),
                new MySqlParameter("@day", dto.Day),
                new MySqlParameter("@period", dto.Period),
                new MySqlParameter("@room", dto.Room ?? string.Empty)
            };

            return DbConnect.ExecuteNonQuery(query, param) > 0;
        }

        public static bool Delete(int id)
        {
            string query = "DELETE FROM timetable WHERE id=@id";

            MySqlParameter[] param = {
                new MySqlParameter("@id", id)
            };

            return DbConnect.ExecuteNonQuery(query, param) > 0;
        }

        public static bool IsClassBusy(int classId, int semesterId, string day, int period)
        {
            string query = @"SELECT COUNT(*) FROM timetable 
                             WHERE class_id=@c AND semester_id=@s AND day=@d AND period=@p";

            MySqlParameter[] param = {
                new MySqlParameter("@c", classId),
                new MySqlParameter("@s", semesterId),
                new MySqlParameter("@d", day),
                new MySqlParameter("@p", period)
            };

            return Convert.ToInt32(DbConnect.ExecuteScalar(query, param)) > 0;
        }

        public static bool IsTeacherBusy(int teacherId, int semesterId, string day, int period)
        {
            string query = @"SELECT COUNT(*) FROM timetable 
                             WHERE teacher_id=@t AND semester_id=@s AND day=@d AND period=@p";

            MySqlParameter[] param = {
                new MySqlParameter("@t", teacherId),
                new MySqlParameter("@s", semesterId),
                new MySqlParameter("@d", day),
                new MySqlParameter("@p", period)
            };

            return Convert.ToInt32(DbConnect.ExecuteScalar(query, param)) > 0;
        }

        #endregion

        #region Generate / Create Timetable (improved)

        /// <summary>
        /// Lấy danh sách phân công (teacher assignments).
        /// Kết quả cần có: class_id, subject_id, teacher_id, periods (số tiết cần phân)
        /// Tên bảng và cột dựa trên dự án: mặc định tìm trong teacher_assignments.
        /// </summary>

        private DataTable GetAssignments(int yearId, int semesterId)
        {
            string sql = @"
        SELECT 
            ta.class_id, 
            ta.subject_id, 
            ta.teacher_id, 
            ta.periods, 
            c.class_name
        FROM teacher_assignments ta
        INNER JOIN classes c ON c.class_id = ta.class_id
        WHERE c.year_id = @yearId AND ta.semester_id = @semesterId
        ORDER BY ta.class_id, ta.subject_id";

            DataTable dt = new DataTable();

            using (MySqlConnection conn = DbConnect.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@yearId", yearId);
                cmd.Parameters.AddWithValue("@semesterId", semesterId);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }


        /// <summary>
        /// Xoá thời khoá biểu cũ cho năm/năm học + học kỳ.
        /// </summary>
        private void DeleteTimetable(int yearId, int semesterId)
        {
            string sql =
                @"DELETE tt FROM timetable tt
                  JOIN classes c ON c.class_id = tt.class_id
                  WHERE c.year_id = @y AND tt.semester_id = @s";

            MySqlParameter[] param = {
                new MySqlParameter("@y", yearId),
                new MySqlParameter("@s", semesterId)
            };

            DbConnect.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// GenerateTimetableFromAssignment: phiên bản "nhanh" (mỗi phân công tạo 1 dòng mặc định).
        /// Giữ tương thích với code cũ nhưng cải thiện tên bảng teacher_assignments.
        /// </summary>
        public int GenerateTimetableFromAssignment(int yearId, int semesterId)
        {
            // Cách an toàn: chèn 1 tiết mặc định cho mỗi phân công (nếu cần hành vi khác, dùng CreateTimetable).
            string query = @"
                INSERT INTO timetable (class_id, subject_id, teacher_id, day, period, room, semester_id)
                SELECT 
                    ta.class_id,
                    ta.subject_id,
                    ta.teacher_id,
                    'Mon' AS day,
                    1 AS period,
                    'A1' AS room,
                    ta.semester_id
                FROM teacher_assignments ta
                JOIN classes c ON c.class_id = ta.class_id
                WHERE c.year_id = @y AND ta.semester_id = @s;
            ";

            MySqlParameter[] param = {
                new MySqlParameter("@y", yearId),
                new MySqlParameter("@s", semesterId)
            };

            return DbConnect.ExecuteNonQuery(query, param);
        }

        /// <summary>
        /// CreateTimetable: thuật toán đơn giản phân bố tiết theo assignment, tránh trùng lớp và trùng GV.
        /// - Xoá TKB cũ trước.
        /// - Duyệt assignments (class, subject, teacher, periods).
        /// - Với mỗi tiết cần đặt: tìm (day, period) đầu tiên không xung đột.
        /// - Nếu không tìm được trong khung hiện tại (days x periodMax), sẽ ghi log / bỏ qua (bạn có thể mở rộng).
        /// </summary>
        public void CreateTimetable(int yearId, int semesterId, string defaultRoom = "A1", int periodMax = 7, string[] days = null)
        {
            if (days == null)
            {
                days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            }

            // 1) Xoá TKB cũ
            DeleteTimetable(yearId, semesterId);

            // 2) Lấy phân công
            DataTable assignments = GetAssignments(yearId, semesterId);
            if (assignments == null || assignments.Rows.Count == 0) return;

            // 3) Greedy schedule:
            // Chúng ta sẽ duyệt từng phân công (order theo class/subject)
            // và cho từng "period" cần đặt: tìm earliest (day, period) không xung đột cho class và teacher.
            foreach (DataRow row in assignments.Rows)
            {
                int classId = Convert.ToInt32(row["class_id"]);
                int subjectId = Convert.ToInt32(row["subject_id"]);
                int teacherId = Convert.ToInt32(row["teacher_id"]);
                int periods = Convert.ToInt32(row["periods"]);

                int placed = 0;
                // vòng lặp cố gắng đặt mỗi tiết
                for (int dIndex = 0; dIndex < days.Length && placed < periods; dIndex++)
                {
                    for (int p = 1; p <= periodMax && placed < periods; p++)
                    {
                        string day = days[dIndex];

                        // Kiểm tra xung đột
                        if (IsClassBusy(classId, semesterId, day, p)) continue;
                        if (IsTeacherBusy(teacherId, semesterId, day, p)) continue;

                        // Chèn
                        string insert = @"
                            INSERT INTO timetable(class_id, subject_id, teacher_id, semester_id, day, period, room)
                            VALUES(@class, @subject, @teacher, @sem, @day, @period, @room)";
                        MySqlParameter[] insParam = {
                            new MySqlParameter("@class", classId),
                            new MySqlParameter("@subject", subjectId),
                            new MySqlParameter("@teacher", teacherId),
                            new MySqlParameter("@sem", semesterId),
                            new MySqlParameter("@day", day),
                            new MySqlParameter("@period", p),
                            new MySqlParameter("@room", defaultRoom)
                        };

                        DbConnect.ExecuteNonQuery(insert, insParam);
                        placed++;
                    }
                }

                // Nếu chưa đặt đủ (placed < periods), vòng lặp lại từ đầu để fill những ngày đã bỏ qua.
                // Thực hiện thêm vòng thứ hai để cố gắng đặt các tiết còn lại (ví dụ nếu periodMax nhỏ).
                int attempt = 0;
                while (placed < periods && attempt < 5)
                {
                    for (int dIndex = 0; dIndex < days.Length && placed < periods; dIndex++)
                    {
                        for (int p = 1; p <= periodMax && placed < periods; p++)
                        {
                            string day = days[dIndex];
                            if (IsClassBusy(classId, semesterId, day, p)) continue;
                            if (IsTeacherBusy(teacherId, semesterId, day, p)) continue;

                            string insert2 = @"
                                INSERT INTO timetable(class_id, subject_id, teacher_id, semester_id, day, period, room)
                                VALUES(@class, @subject, @teacher, @sem, @day, @period, @room)";
                            MySqlParameter[] insParam2 = {
                                new MySqlParameter("@class", classId),
                                new MySqlParameter("@subject", subjectId),
                                new MySqlParameter("@teacher", teacherId),
                                new MySqlParameter("@sem", semesterId),
                                new MySqlParameter("@day", day),
                                new MySqlParameter("@period", p),
                                new MySqlParameter("@room", defaultRoom)
                            };

                            DbConnect.ExecuteNonQuery(insert2, insParam2);
                            placed++;
                        }
                    }
                    attempt++;
                }

                // Nếu vẫn còn thiếu => báo log (optional). Bạn có thể collect và trả về báo cáo.
                if (placed < periods)
                {
                    // (không throw để không dừng toàn bộ quá trình) — có thể lưu vào bảng log hoặc trả về báo cáo.
                    System.Diagnostics.Debug.WriteLine($"Warning: Could not place all periods for class {classId}, subject {subjectId}. Placed {placed}/{periods}.");
                }
            }
        }

        /// <summary>
        /// Lấy TKB theo năm + học kỳ (sử dụng class.year_id để phân biệt năm).
        /// Trả về các cột: day, period, class_name, subject_name, teacher_name, room (tương thích với UI).
        /// </summary>
        public DataTable GetTimetableByYearSemester(int yearId, int semesterId)
        {
            string teacherCol = (TeacherTable == TeacherSource.Users) ? "u.full_name" : "t.teacher_name";
            string teacherJoin = (TeacherTable == TeacherSource.Users) ?
                "LEFT JOIN users u ON tt.teacher_id = u.user_id" :
                "LEFT JOIN teachers t ON tt.teacher_id = t.teacher_id";

            string sql =
                $@"SELECT tt.day, tt.period, c.class_name, s.subject_name, {teacherCol} AS teacher_name, tt.room
                   FROM timetable tt
                   JOIN classes c ON c.class_id = tt.class_id
                   JOIN subjects s ON s.subject_id = tt.subject_id
                   {teacherJoin}
                   WHERE c.year_id = @y AND tt.semester_id = @s
                   ORDER BY FIELD(tt.day,'Mon','Tue','Wed','Thu','Fri','Sat'), tt.period;";

            MySqlParameter[] param = {
                new MySqlParameter("@y", yearId),
                new MySqlParameter("@s", semesterId)
            };

            return DbConnect.ExecuteQuery(sql, param);
        }

        public DataTable GetTimetableByTeacherAndSemester(int teacherId, int semesterId)
        {
            string query = @"
        SELECT 
            t.day,
            t.period,
            c.class_name AS Class,
            s.name AS Subject,
            u.fullname AS Teacher,
            t.room AS Room
        FROM timetable t
        INNER JOIN classes c ON t.class_id = c.class_id
        INNER JOIN subjects s ON t.subject_id = s.subject_id
        INNER JOIN users u ON t.teacher_id = u.user_id
        WHERE t.teacher_id = @param0 AND t.semester_id = @param1
        ORDER BY FIELD(t.day, 'Mon','Tue','Wed','Thu','Fri','Sat'), t.period;
    ";

            object[] parameters = new object[] { teacherId, semesterId };
            return DbConnect.ExecuteQuery(query, parameters);
        }





        public static void DeleteAllTimetable()
        {
            string query = "DELETE FROM timetable";
            DbConnect.ExecuteNonQuery(query);
        }

        // Thêm một bản ghi TKB
        public static void AddTimetable(int classId, int subjectId, int teacherId, int semesterId, string day, int period)
        {
            string query = @"
                INSERT INTO timetable (class_id, subject_id, teacher_id, semester_id, day, period, room)
                VALUES (@param0,@param1,@param2,@param3,@param4,@param5,@param6)
            ";

            DbConnect.ExecuteNonQuery(query,
                new object[] { classId, subjectId, teacherId, semesterId, day, period, null });
        }


        #endregion
    }
}
