using System;

namespace DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }           // student_id
        public string Ten { get; set; }       // fullname
        public DateTime NgaySinh { get; set; } // dob
        public string GioiTinh { get; set; }  // gender
        public string Lop { get; set; }// class_name
        public string DiaChi { get; set; }
        public int ClassId { get; set; }  // class_id

        public int YearId { get; set; }
    }
}
