using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(long memberId);
        Task<Member?> GetByUserAndTenantAsync(long userId, long tenantId);
        Task<IEnumerable<Member>> GetByTenantIdAsync(long tenantId);

        Task<long> CreateAsync(Member member);
        Task<bool> UpdateAsync(Member member);
        Task<bool> RemoveAsync(long memberId, long tenantId);
    }
}
