namespace Build_flow_Saas.api.Models.Entities
{
    public class ProjectMember : BaseModel
    {
        public long ProjectMemberId { get; set; }

        public long TenantId { get; set; }

        public long ProjectId { get; set; }

        public long MemberId { get; set; }

        public DateTime JoinedAt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
