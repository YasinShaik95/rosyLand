using Microsoft.AspNetCore.Identity;

namespace api;

public class AppUser : IdentityUser
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Address { get; set; }
  public string City { get; set; }
  public string Country { get; set; }
  public string ZipCode { get; set; }
  public DateOnly DOB { get; set; }
  public string Gender { get; set; }
}
