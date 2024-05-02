using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace api;

public class TokenService : ITokenService
{
  private readonly IConfiguration _configuration;
  private readonly SymmetricSecurityKey _securityKey;
  private readonly UserManager<AppUser> _userManager;
  public TokenService(IConfiguration config, UserManager<AppUser> userManager)
  {
    _configuration = config;
    _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
    _userManager = userManager;
  }
  public async Task<string> CreateToken(AppUser user)
  {
    var appUser = await _userManager.FindByNameAsync(user.UserName);

    var roles = await _userManager.GetRolesAsync(appUser);

    var claims = new List<Claim>
    {
      new Claim(JwtRegisteredClaimNames.Email,user.Email),
      new Claim(JwtRegisteredClaimNames.GivenName,user.UserName)
    };

    foreach (var role in roles)
    {
      claims.Add(new Claim(ClaimTypes.Role, role));
    }

    var creds = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.Now.AddMinutes(45),
      SigningCredentials = creds,
      Issuer = _configuration["JWT:Issuer"],
      Audience = _configuration["JWT:Audience"],
    };

    var tokenHandler = new JwtSecurityTokenHandler();

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}
