
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api;

public class AccountController : AppControllerBase
{
  private readonly IAccountRepository _accountRepository;
  private readonly ITokenService _tokenService;
  private readonly SignInManager<AppUser> _signingInManager;
  public AccountController(IAccountRepository accountRepository, ITokenService tokenService, SignInManager<AppUser> signInManager)
  {
    _accountRepository = accountRepository;
    _tokenService = tokenService;
    _signingInManager = signInManager;
  }

  [AllowAnonymous]
  [HttpPost("register")]
  public async Task<ActionResult<UserDTO>> RegisterUser(RegisterDTO register)
  {
    if (register is null)
    {
      return BadRequest(register);
    }

    try
    {
      var appUser = new AppUser
      {
        UserName = register.Username,
        Email = register.Email
      };

      var createdUser = await _accountRepository.CreateUser(appUser, register.Password);
      if (createdUser.Succeeded)
      {
        var roleResult = await _accountRepository.CreateUserRole(appUser);
        if (roleResult.Succeeded)
        {
          return new UserDTO
          {
            UserName = appUser.UserName,
            Email = appUser.Email,
            Roles = await _accountRepository.GetUserRoles(register.Username),
            Token = await _tokenService.CreateToken(appUser)
          };
        }
        else
        {
          return StatusCode(500, roleResult.Errors);
        }
      }
      else
      {
        return StatusCode(500, createdUser.Errors);
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }

  [AllowAnonymous]
  [HttpPost("login")]
  public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
  {
    if (loginDTO is null)
    {
      return BadRequest(loginDTO);
    }

    try
    {
      var userDetails = await _accountRepository.GetUserDetails(loginDTO.Username);

      if (userDetails != null)
      {
        var result = await _signingInManager.CheckPasswordSignInAsync(userDetails, loginDTO.Password, false);

        if (result.Succeeded)
        {
          return new UserDTO
          {
            UserName = loginDTO.Username,
            Email = userDetails.Email,
            Roles = await _accountRepository.GetUserRoles(loginDTO.Username),
            Token = await _tokenService.CreateToken(new AppUser
            {
              UserName = userDetails.UserName,
              Email = userDetails.Email
            })
          };
        }
        else
        {
          return Unauthorized("Invalid Username or password");
        }

      }
      else
      {
        return Unauthorized("Invalid Username or Password");
      }
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }

  [Authorize(Roles = "admin")]
  [HttpGet("getallusers")]
  public async Task<ActionResult> GetAllUsers()
  {
    try
    {
      List<UserDTO> userresult = new List<UserDTO>();

      var users = await _accountRepository.GetAllUsers();

      users.ForEach(async user =>
      {
        userresult.Add(new UserDTO
        {
          UserName = user.UserName,
          Email = user.Email,
          FirstName = user.FirstName,
          LastName = user.LastName,
          Country = user.Country,
          Roles = await _accountRepository.GetUserRoles(user.UserName)
        });
      });

      return Ok(userresult);
    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }

  [Authorize(Roles = "admin")]
  [HttpPost("updateuserrole")]
  public async Task<ActionResult<UserDTO>> UpdateUserRole(UserRoleDTO userRole)
  {
    try
    {
      if (userRole is null) return BadRequest(userRole);

      return Ok(await _accountRepository.UpdateUserRole(userRole.UserName, userRole.RoleName));

    }
    catch (Exception ex)
    {
      return StatusCode(500, ex.Message);
    }
  }

}
