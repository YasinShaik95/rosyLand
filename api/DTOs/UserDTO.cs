﻿namespace api;

public class UserDTO
{
  public string UserName { get; set; }
  public string Email { get; set; }
  public string Token { get; set; }
  public IList<string> Roles { get; set; }
}
