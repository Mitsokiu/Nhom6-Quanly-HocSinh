using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string SenderName { get; set; } 
        public string SenderRole { get; set; } 
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        // Property phụ để hiển thị ngày tháng
        public string DateDisplay => CreatedAt.ToString("dd/MM/yyyy");
    }
}
