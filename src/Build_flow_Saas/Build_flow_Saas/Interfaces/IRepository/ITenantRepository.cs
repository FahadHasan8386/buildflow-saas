using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetByIdAsync(long tenantId);
        Task<IEnumerable<Tenant>> GetByCreatorUserIdAsync(long userId);

        Task<long> CreateAsync(Tenant tenant);
        Task<bool> UpdateAsync(Tenant tenant);
    }
}
