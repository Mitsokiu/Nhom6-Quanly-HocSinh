using System;

namespace DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderRole { get; set; }
        public string TargetRole { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public string DateDisplay => CreatedAt.ToString("dd/MM/yyyy");
    }
}
