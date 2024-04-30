using api.Data;
using api.DTOs;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rosyLandApi.Entities;

namespace api;

public class UsersController : ApiControllerBase
{
  private readonly DataContext _dataContext;
  private readonly ITokenService _tokenService;
  public UsersController(DataContext dataContext, ITokenService tokenService)
  {
    _dataContext = dataContext;
    _tokenService = tokenService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<User>>> GetUsers()
  {
    return await _dataContext.Users.ToListAsync();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<User>> GetUser(int id)
  {
    return await _dataContext.Users.FindAsync(id);
  }

  [HttpPost]
  public async Task<ActionResult<UserDTO>> RegisterUser(RegisterDTO registerUser)
  {
    if (registerUser == null)
    {
      return BadRequest(nameof(RegisterDTO));
    }

    if (await ValidateUser(registerUser))
    {
      return BadRequest(nameof(registerUser.UserName));
    }
    else
    {
      // add user here
      var user = new User();
      return new UserDTO
      {
        UserName = user.Id,
        Token = _tokenService.CreateToken(user)
      };
    }


  }

  private async Task<bool> ValidateUser(RegisterDTO registerUSer)
  {
    return await _dataContext.Users.AnyAsync(user => user.Id == registerUSer.UserName);
  }
}
