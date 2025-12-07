using DTO;
using System.Collections.Generic;
using System.Data;
using System;

namespace DAO
{
    public class SubjectDAO
    {
        public List<SubjectDTO> GetAll()
        {
            List<SubjectDTO> list = new List<SubjectDTO>();
            string query = "SELECT subject_id, name FROM subjects ORDER BY name";

            DataTable dt = DbConnect.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SubjectDTO()
                {
                    SubjectId = Convert.ToInt32(row["subject_id"]), // Convert to int
                    SubjectName = row["name"].ToString()
                });
            }

            return list;
        }

        // Bỏ tham số ID vì DB tự tăng
        public bool Insert(SubjectDTO s)
        {
            string query = "INSERT INTO subjects(name) VALUES(@param0)";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { s.SubjectName });
            return result > 0;
        }

        public bool Update(SubjectDTO s)
        {
            string query = "UPDATE subjects SET name=@param0 WHERE subject_id=@param1";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { s.SubjectName, s.SubjectId });
            return result > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM subjects WHERE subject_id=@param0";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
    }
}