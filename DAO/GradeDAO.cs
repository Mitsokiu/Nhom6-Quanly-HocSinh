using MySql.Data.MySqlClient;
using System.Data;

namespace DAO
{
    public class GradeDAO
    {
        public static DataTable GetAll()
        {
            string sql = "SELECT grade_id, grade_name FROM grade_levels ORDER BY grade_name ASC";
            return DbConnect.ExecuteQuery(sql, null);
        }
    }
}
