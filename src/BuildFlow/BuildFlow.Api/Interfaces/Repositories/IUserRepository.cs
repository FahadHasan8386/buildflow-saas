using BuildFlow.Api.Domain.Entities;

namespace BuildFlow.Api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(long id);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task UpdatePasswordAsync(long userId, string newPasswordHash);
        Task<bool> UpdateStatusAsync(long userId, bool isActive , string? modifiedBy = null);
    
        Task SoftDeleteAsync(long userId, string? modifiedBy = null);
    }
}
