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
        public int SenderId { get; set; } = 1;  // mặc định người gửi là id = 1
        public string TargetRole { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

       
        public string SenderName { get; set; }
        public string SenderRole { get; set; }
        

        // Property phụ để hiển thị ngày tháng
        public string DateDisplay => CreatedAt.ToString("dd/MM/yyyy");


    }
}
