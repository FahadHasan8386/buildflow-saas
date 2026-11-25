using BuildFlow.Api.Domain.Common;

namespace BuildFlow.Api.Domain.Entities
{
    public class User : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string? ProfileImageUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
