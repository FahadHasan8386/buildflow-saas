using BuildFlow.Api.Domain.Common;

namespace BuildFlow.Api.Domain.Entities
{
    public class AuthSession : BaseModel
    {
        public long UserId { get; set; }

        public string RefreshTokenHash { get; set; } = string.Empty;

        public string? DeviceInfo { get; set; }
        public string? IpAddress { get; set; }

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

        public bool IsRevoked => RevokedAt.HasValue;

        public bool IsActive => !IsExpired && !IsRevoked;
    }
}
