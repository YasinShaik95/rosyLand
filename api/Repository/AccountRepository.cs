using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api;

public class AccountRepository : IAccountRepository
{
  private readonly UserManager<AppUser> _userManager;

  public AccountRepository(UserManager<AppUser> userManager)
  {
    _userManager = userManager;
  }

  public async Task<IdentityResult> CreateUser(AppUser appUser, string password)
  {
    try
    {
      return await _userManager.CreateAsync(appUser, password);
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<IdentityResult> CreateUserRole(AppUser appUser)
  {
    try
    {
      var user = await _userManager.FindByNameAsync(appUser.UserName);
      return await _userManager.AddToRoleAsync(user, "user");
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<List<AppUser>> GetAllUsers()
  {
    return await _userManager.Users.ToListAsync();
  }

  public async Task<AppUser> GetUserDetails(string userName)
  {
    try
    {
      return await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<IList<string>> GetUserRoles(string username)
  {
    try
    {
      return await _userManager.GetRolesAsync(await _userManager.FindByNameAsync(username));
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<AppUser> UpdateUserRole(string username, string rolename)
  {
    try
    {
      var user = await _userManager.FindByNameAsync(username);
      var role = await _userManager.AddToRoleAsync(user, rolename);

      return user;
    }
    catch (Exception)
    {
      throw;
    }
  }
}
