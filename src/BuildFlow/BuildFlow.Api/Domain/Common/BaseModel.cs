namespace BuildFlow.Api.Domain.Common
{
    public class BaseModel
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
