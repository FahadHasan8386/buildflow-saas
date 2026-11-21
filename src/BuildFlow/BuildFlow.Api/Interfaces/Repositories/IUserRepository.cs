using BuildFlow.Api.Domain.Entities;

namespace BuildFlow.Api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(long id);

        Task<User?> GetByEmailAsync(string email);

        Task<bool> ExistsByEmailAsync(string email);

        Task<long> CreateAsync(User user);

        Task UpdateAsync(User user);

        Task UpdatePasswordAsync(long userId, string newPasswordHash);

        Task UpdateStatusAsync(long userId,bool isActive, string? modifiedBy = null);

        Task SoftDeleteAsync(long userId,string? modifiedBy = null);
    }
}
