namespace DTO
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public string ClassName { get; set; }

        // --- BỔ SUNG ĐỂ HIỂN THỊ THÔNG TIN PHÂN CÔNG ---
        public string TeacherName { get; set; } 
        public int TeacherId { get; set; }
        public string YearName { get; set; }   
        public int YearId { get; set; }
        public int AssignId { get; set; }      
    }

    // Tạo thêm DTO phụ để đổ dữ liệu vào ComboBox (nếu chưa có)
    public class ComboItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}