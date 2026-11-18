namespace Build_flow_Saas.api.Models.Enums
{
    public enum ProjectStatus : byte
    {
        Active = 1,
        Archived = 2
    }

    public enum TaskItemStatus : byte
    {
        Todo = 1,
        InProgress = 2,
        InReview = 3,
        Done = 4
    }

    public enum TaskPriority : byte
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }

    public enum NotificationType : byte
    {
        TaskAssigned = 1,
        TaskStatusChanged = 2,
        TaskCommentAdded = 3,
        AddedToProject = 4,
        AddedToTenant = 5
    }
}
