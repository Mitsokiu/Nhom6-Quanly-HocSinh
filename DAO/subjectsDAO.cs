using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAO
{
    public class SubjectDAO
    {
        public List<SubjectDTO> GetAllSubjects()
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            string query = "SELECT id, code, name FROM subjects";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new SubjectDTO
                        {
                            Id = reader.GetInt32("id"),
                            Code = reader["code"].ToString(),
                            Name = reader["name"].ToString()
                        });
                    }
                }
            }

            return subjects;
        }

        // Thêm môn học
        public bool AddSubject(SubjectDTO sub)
        {
            string query = "INSERT INTO subjects (code, name) VALUES (@code, @name)";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", sub.Code);
                cmd.Parameters.AddWithValue("@name", sub.Name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sửa môn học
        public bool UpdateSubject(SubjectDTO sub)
        {
            string query = "UPDATE subjects SET code=@code, name=@name WHERE id=@id";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", sub.Id);
                cmd.Parameters.AddWithValue("@code", sub.Code);
                cmd.Parameters.AddWithValue("@name", sub.Name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa môn học
        public bool DeleteSubject(int id)
        {
            string query = "DELETE FROM subjects WHERE id=@id";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
