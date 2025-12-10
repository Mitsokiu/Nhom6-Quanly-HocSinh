using DTO;
using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DAO
{
    public class TuitionDAO
    {
     

        public bool AddTuitionForAllStudents(TuitionDTO tuition)
        {
            string query = @"
        INSERT INTO tuition (student_id, description,name, amount, semester_id, due_date, status)
        SELECT student_id, @param0, @param1, @param2, @param3, @param4, 'unpaid'
        FROM students
        WHERE student_id IS NOT NULL
    ";

            object[] parameters = {
        tuition.name ?? "",
        tuition.Description ?? "",
        tuition.Amount,
        tuition.SemesterId > 0 ? tuition.SemesterId : 1,
        tuition.DueDate
    };

            return DbConnect.ExecuteNonQuery(query, parameters) > 0;
        }


        public bool AddTuitionForStudent(TuitionDTO tuition)
        {
            string query = @"
                INSERT INTO tuition (student_id, name, amount, due_date, status)
                VALUES (@param0, @param1, @param2, @param3, 'unpaid')
            ";

            return DbConnect.ExecuteNonQuery(query, new object[] { tuition.StudentId, tuition.name, tuition.Amount, tuition.DueDate }) > 0;
        }


        public bool UpdateTuition(string oldName, decimal oldAmount, DateTime oldDueDate,
                            string newName, decimal newAmount, DateTime newDueDate)
        {
            string query = @"
        UPDATE tuition
        SET name = @newName,
            amount = @newAmount,
            due_date = @newDueDate
        WHERE name = @oldName
          AND amount = @oldAmount
          AND due_date = @oldDueDate
    ";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@newName", newName);
                    cmd.Parameters.AddWithValue("@newAmount", newAmount);
                    cmd.Parameters.AddWithValue("@newDueDate", newDueDate);

                    cmd.Parameters.AddWithValue("@oldName", oldName);
                    cmd.Parameters.AddWithValue("@oldAmount", oldAmount);
                    cmd.Parameters.AddWithValue("@oldDueDate", oldDueDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


       
        public bool DeleteTuition(string name, decimal amount, DateTime dueDate)
        {
            string query = @"
        DELETE FROM tuition
        WHERE name=@name AND amount=@amount AND due_date=@dueDate
    ";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@dueDate", dueDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        //    public bool DeleteTuition(string name, DateTime dueDate)
        //    {
        //        string query = @"
        //    DELETE FROM tuition
        //    WHERE name = @name

        //      AND due_date = @dueDate
        //";

        //        using (var conn = DbConnect.GetConnection())
        //        {
        //            conn.Open();
        //            using (var cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@name", name);

        //                cmd.Parameters.AddWithValue("@dueDate", dueDate);

        //                int rows = cmd.ExecuteNonQuery();
        //                return rows > 0;
        //            }
        //        }
        //    }

        public List<TuitionDTO> GetAllTuition()
        {
            string query = "SELECT * FROM tuition";
            var list = new List<TuitionDTO>();

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TuitionDTO
                        {
                            TuitionId = reader.GetInt32("tuition_id"),
                            StudentId = reader.GetInt32("student_id"),
                            name = reader.GetString("name"),
                            Amount = reader.GetDecimal("amount"),
                            DueDate = reader.GetDateTime("due_date"),
                            Status = reader.GetString("status")
                        });
                    }
                }
            }

            return list;
        }
        public List<TuitionDTO> GetAllTuitionKhoanThu()
        {
            string query = @"
        SELECT name, amount, due_date
        FROM tuition
        GROUP BY name, amount, due_date
        ORDER BY due_date
    ";
            var list = new List<TuitionDTO>();

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TuitionDTO
                        {
                            name = reader.GetString("name"),
                            Amount = reader.GetDecimal("amount"),
                            DueDate = reader.GetDateTime("due_date")
                        });
                    }
                }
            }

            return list;
        }

        // Lấy danh sách học phí kèm thông tin học sinh
        // Lấy tất cả học phí kèm thông tin học sinh, lớp theo năm học
        public List<TuitionDTO> GetTuitionWithStudentInfo(int schoolYearId)
        {
            var list = new List<TuitionDTO>();
            string query = @"
                SELECT t.tuition_id, t.student_id, t.name, t.amount, t.due_date, t.status,
                       s.dob, u.fullname AS student_name, c.class_name,
                       r.paid_date
                FROM tuition t
                JOIN students s ON t.student_id = s.student_id
                JOIN users u ON s.user_id = u.user_id
                JOIN student_class sc ON s.student_id = sc.student_id AND sc.school_year_id = @param0
                JOIN classes c ON sc.class_id = c.class_id
                LEFT JOIN receipts r ON t.tuition_id = r.tuition_id
                ORDER BY c.class_name, u.fullname
            ";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@param0", schoolYearId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TuitionDTO
                        {
                            TuitionId = reader.GetInt32("tuition_id"),
                            StudentId = reader.GetInt32("student_id"),
                            StudentName = reader.GetString("student_name"),
                            DOB = reader.GetDateTime("dob"),
                            ClassName = reader.GetString("class_name"),
                            name = reader.GetString("name"),
                            Amount = reader.GetDecimal("amount"),
                            DueDate = reader.GetDateTime("due_date"),
                            Status = reader.GetString("status"),
                            PaidDate = reader.IsDBNull(reader.GetOrdinal("paid_date"))
                                       ? (DateTime?)null
                                       : reader.GetDateTime("paid_date")
                        });
                    }
                }
            }

            return list;
        }

        // Cập nhật trạng thái học phí
        public bool UpdateTuitionStatus(int tuitionId, string newStatus, DateTime? paidDate)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                var tran = conn.BeginTransaction();

                try
                {
                    string updateStatusQuery = @"
                        UPDATE tuition SET status = @param0 WHERE tuition_id = @param1
                    ";
                    var cmdStatus = new MySqlCommand(updateStatusQuery, conn, tran);
                    cmdStatus.Parameters.AddWithValue("@param0", newStatus);
                    cmdStatus.Parameters.AddWithValue("@param1", tuitionId);
                    cmdStatus.ExecuteNonQuery();

                    if (newStatus == "paid" && paidDate.HasValue)
                    {
                        string insertReceipt = @"
                            INSERT INTO receipts (tuition_id, paid_date, amount_paid)
                            VALUES (@tuitionId, @paidDate, (SELECT amount FROM tuition WHERE tuition_id=@tuitionId))
                        ";
                        var cmdReceipt = new MySqlCommand(insertReceipt, conn, tran);
                        cmdReceipt.Parameters.AddWithValue("@tuitionId", tuitionId);
                        cmdReceipt.Parameters.AddWithValue("@paidDate", paidDate.Value);
                        cmdReceipt.ExecuteNonQuery();
                    }
                    else if (newStatus == "unpaid")
                    {
                        string deleteReceipt = "DELETE FROM receipts WHERE tuition_id=@tuitionId";
                        var cmdDelete = new MySqlCommand(deleteReceipt, conn, tran);
                        cmdDelete.Parameters.AddWithValue("@tuitionId", tuitionId);
                        cmdDelete.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }


        public DataTable GetTuitionByYearAndClass(int yearId, int classId)
        {
            string sql = @"
                SELECT 
                    t.tuition_id,
                    s.student_id,
                    u.fullname AS Hoten,
                    s.dob AS NgaySinh,
                    c.class_name AS Lop,
                    t.name AS KhoanThu,
                    t.amount AS SoTien,
                    t.due_date AS HanNop,
                    t.status AS TrangThai
                FROM tuition t
                JOIN students s ON s.student_id = t.student_id
                LEFT JOIN users u ON u.user_id = s.user_id
                JOIN student_class sc ON sc.student_id = s.student_id
                JOIN classes c ON c.class_id = sc.class_id
                WHERE sc.school_year_id = @param0
                  AND (@param1 = 0 OR sc.class_id = @param1)";

            object[] parameters = { yearId, classId };
            return DbConnect.ExecuteQuery(sql, parameters);
        }

        public bool UpdateStatus(int tuitionId, string status)
        {
            string sql = "UPDATE tuition SET status=@param0 WHERE tuition_id=@param1";
            object[] parameters = { status, tuitionId };
            int rows = DbConnect.ExecuteNonQuery(sql, parameters);
            return rows > 0;
        }
        public List<TuitionDTO> GetTuitionByStudentAndSemester(int studentID, int semesterID)
        {
            List<TuitionDTO> list = new List<TuitionDTO>();

            string query = @"
                SELECT tuition_id, name, amount, due_date, status
                FROM tuition
                WHERE student_id = @param0 AND semester_id = @param1";
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { studentID, semesterID });
            foreach (DataRow row in data.Rows)
            {
                list.Add(new TuitionDTO
                {
                    TuitionID = (int)row["tuition_id"],
                    FeeName = row["name"].ToString(),
                    Amount = Convert.ToDecimal(row["amount"]),
                    DueDate = Convert.ToDateTime(row["due_date"]),
                    Status = row["status"].ToString()
                });
            }
            return list;
        }
    }
}
