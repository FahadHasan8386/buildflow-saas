using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(long taskId, long tenantId);
        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(long projectId, long tenantId);
        Task<IEnumerable<TaskItem>> GetByAssignedMemberAsync(long projectMemberId, long tenantId);

        Task<long> CreateAsync(TaskItem task);
        Task<bool> UpdateAsync(TaskItem task);
        Task<bool> DeleteAsync(long taskId, long tenantId);
    }
}
