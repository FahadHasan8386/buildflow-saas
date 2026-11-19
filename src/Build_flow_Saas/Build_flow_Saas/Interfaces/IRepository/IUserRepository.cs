using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(long userId);
        Task<User?> GetByEmailAsync(string email);
        Task<long> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
    }
}
