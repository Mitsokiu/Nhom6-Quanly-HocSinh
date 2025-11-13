using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DAO
{
    public class GradeDAO
    {
        public List<GradeDTO> GetAllGrades()
        {
            List<GradeDTO> grades = new List<GradeDTO>();
            string query = @"SELECT id, name, level, gvcn FROM grades"; // chỉ lấy dữ liệu từ grades

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grades.Add(new GradeDTO
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Level = reader["level"].ToString(),
                            gvcn = reader.GetString("gvcn"),
                        });
                    }
                }
            }
            return grades;
        }

        // Thêm khối/lớp mới
        public bool AddGrade(GradeDTO grade)
        {
            string query = "INSERT INTO grades (name, level, gvcn) VALUES (@name, @level, @gvcn)";
            using (MySqlConnection conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", grade.Name);
                    cmd.Parameters.AddWithValue("@level", grade.Level);
                    cmd.Parameters.AddWithValue("@gvcn", grade.gvcn ?? "");
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Cập nhật thông tin khối/lớp
        public bool UpdateGrade(GradeDTO grade)
        {
            string query = "UPDATE grades SET name=@name, level=@level, gvcn=@gvcn WHERE id=@id";
            using (MySqlConnection conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", grade.Name);
                    cmd.Parameters.AddWithValue("@level", grade.Level);
                    cmd.Parameters.AddWithValue("@gvcn", grade.gvcn ?? "");
                    cmd.Parameters.AddWithValue("@id", grade.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa khối/lớp theo ID
        public bool DeleteGrade(int id)
        {
            string query = "DELETE FROM grades WHERE id=@id";
            using (MySqlConnection conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }



    }
}
