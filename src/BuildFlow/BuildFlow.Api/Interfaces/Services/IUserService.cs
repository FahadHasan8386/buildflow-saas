using BuildFlow.Shared.Response;
using BuildFlow.Shared.Requests;

namespace BuildFlow.Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<ApiResponse<UserProfileResponse>> GetProfiileAsync(long userId);
        Task<ApiResponse<UserProfileResponse>> UpdateProfileAsync(long userId, UserProfileRequest request);
        Task<ApiResponse<bool>> ChangePasswordAsync(long userId, ChangePasswordRequest request);
    }
}
