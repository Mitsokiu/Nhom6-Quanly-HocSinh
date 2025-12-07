using DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAO
{
    public class GradeDAO
    {
        public List<GradeDTO> GetListGrade()
        {
            List<GradeDTO> list = new List<GradeDTO>();
            string query = "SELECT grade_id, grade_name FROM grade_levels ORDER BY grade_name";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GradeDTO()
                        {
                            Id = reader.GetInt32("grade_id"),
                            Name = reader.GetString("grade_name")
                        });
                    }
                }
            }
            return list;
        }

        // --- THÊM CÁC HÀM NÀY ---
        public bool Insert(GradeDTO g)
        {
            string query = "INSERT INTO grade_levels(grade_name) VALUES(@name)";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", g.Name);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(GradeDTO g)
        {
            string query = "UPDATE grade_levels SET grade_name=@name WHERE grade_id=@id";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", g.Name);
                    cmd.Parameters.AddWithValue("@id", g.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM grade_levels WHERE grade_id=@id";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}