using BuildFlow.Api.Domain.Entities;
using BuildFlow.Api.Interfaces.Repositories;
using BuildFlow.Api.Interfaces.Security;
using BuildFlow.Api.Interfaces.Services;
using BuildFlow.Shared.Requests;
using BuildFlow.Shared.Response;
using Microsoft.AspNetCore.Identity;

namespace BuildFlow.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ApiResponse<UserProfileResponse>> GetProfileAsync(long userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
            {
                return ApiResponse<UserProfileResponse>.FailureResponse("User not found.");
            }

            var response = new UserProfileResponse
            {
                Id = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedAt = DateTime.UtcNow 
            };

            return ApiResponse<UserProfileResponse>.SuccessResponse("Profile retrieved.", response);
        }

        public async Task<ApiResponse<UserProfileResponse>> UpdateProfileAsync(long userId, UpdateProfileRequest request)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
            {
                return ApiResponse<UserProfileResponse>.FailureResponse("User not found.");
            }

            user.FirstName = request.FirstName.Trim();
            user.LastName = request.LastName.Trim();
            user.Email = request.Email.Trim();

            await _userRepository.UpdateAsync(user);

            return await GetProfileAsync(userId);
        }

        public async Task<ApiResponse<string>> ChangePasswordAsync(long userId, ChangePasswordRequest request)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
            {
                return ApiResponse<string>.FailureResponse("User not found.");
            }

            if (!_passwordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash))
            {
                return ApiResponse<string>.FailureResponse("Current password is incorrect.");
            }

            var newHash = _passwordHasher.HashPassword(request.NewPassword);
            await _userRepository.UpdatePasswordAsync(userId, newHash);

            return ApiResponse<string>.SuccessResponse("Password updated successfully.");
        }

        public Task<ApiResponse<UserProfileResponse>> GetProfiileAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserProfileResponse>> UpdateProfileAsync(long userId, UserProfileRequest request)
        {
            throw new NotImplementedException();
        }

        Task<ApiResponse<bool>> IUserService.ChangePasswordAsync(long userId, ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }

}
