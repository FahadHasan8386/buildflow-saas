namespace Build_flow_Saas.api.Models.Entities
{
    public class Role
    {
        public long RoleId { get; set; }
        public long TenantId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
