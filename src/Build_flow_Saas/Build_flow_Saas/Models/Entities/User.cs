namespace Build_flow_Saas.api.Models.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        
    }
}
