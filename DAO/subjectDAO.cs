using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace DAO
{
    public class SubjectDAO
    {
        public List<SubjectDTO> GetAll()
        {
            List<SubjectDTO> list = new List<SubjectDTO>();
            string query = "SELECT subject_id, name FROM subjects";

            DataTable dt = DbConnect.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SubjectDTO()
                {
                    SubjectId = row["subject_id"].ToString(),
                    SubjectName = row["name"].ToString()
                });
            }

            return list;
        }

        public bool Insert(SubjectDTO s)
        {
            string query = "INSERT INTO subjects(subject_id, name) VALUES(@param0, @param1)";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { s.SubjectId, s.SubjectName });
            return result > 0;
        }

        public bool Update(SubjectDTO s)
        {
            string query = "UPDATE subjects SET name=@param0 WHERE subject_id=@param1";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { s.SubjectName, s.SubjectId });
            return result > 0;
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM subjects WHERE subject_id=@param0";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }





        public List<SubjectDTO> GetAll_LinqObjects()
        {
            DataTable dt = DbConnect.ExecuteQuery("SELECT subject_id, name FROM subjects");

            // Chuyển DataTable sang List<SubjectDTO>
            var list = (from DataRow row in dt.Rows
                        select new SubjectDTO
                        {
                            subid = Convert.ToInt32(row["subid"]),
                            SubjectName = row["name"].ToString()
                        }).ToList();

            // Ví dụ: lọc tên môn có chữ "Math" và sắp xếp
            var filtered = list.Where(s => s.SubjectName.Contains("Math"))
                               .OrderBy(s => s.SubjectName)
                               .ToList();

            return filtered;
        }
    }
}
