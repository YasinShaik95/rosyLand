using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace api;

public class TokenService : ITokenService
{
  private readonly IConfiguration _configuration;
  private readonly SymmetricSecurityKey _securityKey;
  public TokenService(IConfiguration config)
  {
    _configuration = config;
    _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
  }
  public string CreateToken(AppUser user)
  {
    var claims = new List<Claim>
    {
      new Claim(JwtRegisteredClaimNames.Email,user.Email),
      new Claim(JwtRegisteredClaimNames.GivenName,user.UserName)
    };

    var creds = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.Now.AddMinutes(45),
      SigningCredentials = creds,
      Issuer = _configuration["JWT:Issuer"],
      Audience = _configuration["JWT:Audience"]
    };

    var tokenHandler = new JwtSecurityTokenHandler();

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}
