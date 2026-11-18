using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface IRoleRepository
    {
        Task<Role?> GetByIdAsync(long roleId);
        Task<Role?> GetByNameAsync(long tenantId, string roleName);
        Task<IEnumerable<Role>> GetByTenantIdAsync(long tenantId);

        Task<long> CreateAsync(Role role);
        Task<bool> UpdateAsync(Role role);
        Task<bool> DeleteAsync(long roleId, long tenantId);
    }
}

