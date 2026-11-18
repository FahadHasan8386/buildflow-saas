using Build_flow_Saas.api.Models.Enums;

namespace Build_flow_Saas.api.Models.Entities
{
    public class Project : BaseModel
    {
        public long ProjectId { get; set; }
        public long TenantId { get; set; }

        public string ProjectName { get; set; } = string.Empty;
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ProjectStatus Status { get; set; } = ProjectStatus.Active;
    }
}
