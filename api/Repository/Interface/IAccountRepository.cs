using Microsoft.AspNetCore.Identity;

namespace api;

public interface IAccountRepository
{
  Task<IdentityResult> CreateUser(AppUser appUser, string password);
  Task<IdentityResult> CreateUserRole(AppUser appUser);
  Task<AppUser> GetUserDetails(string userName);
  Task<IList<string>> GetUserRoles(string username);
  Task<List<AppUser>> GetAllUsers();
  Task<AppUser> UpdateUserRole(string username, string rolename);
}
