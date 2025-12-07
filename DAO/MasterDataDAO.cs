using DTO;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAO
{
    public static class MasterDataDAO
    {
        // Lấy danh sách Giáo viên (từ bảng teachers JOIN users)
        public static List<ComboItemDTO> GetListTeachers()
        {
            List<ComboItemDTO> list = new List<ComboItemDTO>();
            string query = "SELECT t.teacher_id, u.fullname FROM teachers t JOIN users u ON t.user_id = u.user_id";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ComboItemDTO
                        {
                            Id = reader.GetInt32("teacher_id"),
                            Name = reader.GetString("fullname")
                        });
                    }
                }
            }
            return list;
        }

        // Lấy danh sách Năm học
        public static List<ComboItemDTO> GetListYears()
        {
            List<ComboItemDTO> list = new List<ComboItemDTO>();
            string query = "SELECT year_id, name FROM academic_years ORDER BY year_id DESC";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ComboItemDTO
                        {
                            Id = reader.GetInt32("year_id"),
                            Name = reader.GetString("name")
                        });
                    }
                }
            }
            return list;
        }
    }
}