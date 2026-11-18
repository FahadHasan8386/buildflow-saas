namespace Build_flow_Saas.api.Models.Entities
{
    public class AuthSession : BaseModel
    {
        public long AuthSessionId { get; set; }

        public long UserId { get; set; }

        public string RefreshTokenHash { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }
    }
}
