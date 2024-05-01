﻿using System.ComponentModel.DataAnnotations;

namespace api;

public class RegisterDTO
{
  [Required(ErrorMessage = "Username is required.")]
  public string Username { get; set; }
  [Required(ErrorMessage = "Email is required.")]
  public string Email { get; set; }
  [Required(ErrorMessage = "Password is required.")]
  public string Password { get; set; }

}
