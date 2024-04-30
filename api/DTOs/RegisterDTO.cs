using System.ComponentModel.DataAnnotations;

namespace api.DTOs;

public class RegisterDTO
{

  [Required]
  public string UserName { get; set; }
  [Required]
  public string Email { get; set; }

}
