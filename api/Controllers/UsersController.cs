﻿using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rosyLandApi.Entities;

namespace api;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly DataContext _dataContext;
  public UsersController(DataContext dataContext)
  {
    _dataContext = dataContext;
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
}