namespace Build_flow_Saas.api.Models.Entities
{
    public class TaskComment
    {
        public long TaskCommentId { get; set; }
        public long TaskId { get; set; }
        public long AuthorProjectMemberId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
