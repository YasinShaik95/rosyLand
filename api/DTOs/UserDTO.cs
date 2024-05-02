namespace api;

public class UserDTO
{
  public string UserName { get; set; }
  public string Email { get; set; }
  public string Token { get; set; }
  public IList<string> Roles { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Country { get; set; }
}
