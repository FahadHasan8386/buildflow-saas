using Build_flow_Saas.api.Models.Enums;

namespace Build_flow_Saas.api.Models.Entities
{
    public class Notification : BaseModel
    {
        public long NotificationId { get; set; }
        public long TenantId { get; set; }
        public long MemberId { get; set; }

        public NotificationType Type { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
    }
}
