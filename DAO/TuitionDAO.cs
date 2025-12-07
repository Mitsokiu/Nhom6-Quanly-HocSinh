using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TuitionDAO
    {
        private DbConnect db = new DbConnect();

        public List<TuitionDTO> GetTuitionByStudentAndSemester(int studentID, int semesterID)
        {
            List<TuitionDTO> list = new List<TuitionDTO>();

            string query = @"
                SELECT tuition_id, name, amount, due_date, status
                FROM tuition
                WHERE student_id = @param0 AND semester_id = @param1";
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { studentID, semesterID });
            foreach(DataRow row in data.Rows)
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
