namespace Build_flow_Saas.api.Models.Entities
{
    public class Member : BaseModel
    {
        public long MemberId { get; set; }

        public long TenantId { get; set; }

        public long UserId { get; set; }

        public long RoleId { get; set; }

        public DateTime JoinedAt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
