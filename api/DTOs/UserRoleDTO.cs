using System.ComponentModel.DataAnnotations;

namespace api;

public class UserRoleDTO
{
  [Required]
  public string UserName { get; set; }
  [Required]
  public string RoleName { get; set; }
}
