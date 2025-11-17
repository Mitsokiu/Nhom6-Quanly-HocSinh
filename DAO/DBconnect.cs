using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAO
{
    public class DbConnect
    {
        private static string connectionString = "Server=localhost;Database=school_management;User ID=root;Password=congthuan;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                        command.Parameters.AddWithValue($"@param{i}", parameters[i]);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }

            return data;
        }
        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int ExecuteNonQuery(string query, object[] parameters = null)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                        command.Parameters.AddWithValue($"@param{i}", parameters[i]);
                }
                int result = command.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }



    }
}