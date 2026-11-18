namespace Build_flow_Saas.api.Models.Entities
{
    public class Role : BaseModel
    {
        public long RoleId { get; set; }

        public long TenantId { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public string? Description { get; set; }

    }
}
