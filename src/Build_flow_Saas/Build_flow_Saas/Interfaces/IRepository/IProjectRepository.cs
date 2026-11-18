using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(long projectId, long tenantId);
        Task<IEnumerable<Project>> GetByTenantIdAsync(long tenantId);

        Task<long> CreateAsync(Project project);
        Task<bool> UpdateAsync(Project project);
        Task<bool> DeleteAsync(long projectId, long tenantId);
    }
}
