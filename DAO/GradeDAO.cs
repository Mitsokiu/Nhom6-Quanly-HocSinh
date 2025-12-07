using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GradeDAO
    {
        public List<GradeDTO> GetListGrade()
        {
            List<GradeDTO> list = new List<GradeDTO>();
            string query = "SELECT grade_id, grade_name FROM grade_levels";
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
    }
}
