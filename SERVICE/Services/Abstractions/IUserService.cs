using ENTITY.Entities;
using ENTITY.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace SERVICE.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddModel userAddModel);
        Task<IdentityResult> UpdateUserAsync(UserUpdateModel userUpdateModel);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileModel> GetUserProfileAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileModel userProfileModel);
    }
}
