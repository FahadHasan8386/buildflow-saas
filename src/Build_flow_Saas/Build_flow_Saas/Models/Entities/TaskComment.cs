namespace Build_flow_Saas.api.Models.Entities
{
    public class TaskComment : BaseModel
    {
        public long TaskCommentId { get; set; }

        public long TenantId { get; set; }

        public long ProjectId { get; set; }

        public long TaskId { get; set; }

        public long AuthorProjectMemberId { get; set; }

        public string CommentText { get; set; } = string.Empty;
    }
}
