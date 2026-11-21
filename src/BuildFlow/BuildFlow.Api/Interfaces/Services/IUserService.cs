namespace BuildFlow.Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);

    }
}
