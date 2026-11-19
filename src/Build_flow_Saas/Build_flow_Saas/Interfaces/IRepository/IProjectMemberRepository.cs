using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface IProjectMemberRepository
    {
        Task<ProjectMember?> GetByIdAsync(long projectMemberId);
        Task<ProjectMember?> GetByProjectAndMemberAsync(long projectId, long memberId);
        Task<IEnumerable<ProjectMember>> GetByProjectIdAsync(long projectId, long tenantId);

        Task<long> CreateAsync(ProjectMember projectMember);
        Task<bool> RemoveAsync(long projectMemberId, long tenantId);
    }
}
