using Build_flow_Saas.api.Models.Enums;

namespace Build_flow_Saas.api.Models.Entities
{
    public class TaskItem : BaseModel   
    {
        public long TaskItemId { get; set; }
        public long TenantId { get; set; }
        public long ProjectId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public long CreatedByProjectMemberId { get; set; }
        public long? AssignedToProjectMemberId { get; set; }

        public TaskItemStatus Status { get; set; } = TaskItemStatus.Todo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public DateTime? DueDate { get; set; }
    }
    }
}
