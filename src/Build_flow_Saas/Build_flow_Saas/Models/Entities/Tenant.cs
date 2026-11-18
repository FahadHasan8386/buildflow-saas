namespace Build_flow_Saas.api.Models.Entities
{
    public class Tenant : BaseModel
    {
        public long TenantId { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public long CreatedByUserId { get; set; }
    }
}
