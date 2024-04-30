using api.Data;
using api.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions;

public static class AppServiceExtensions
{
  public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
  {
    services.AddDbContext<DataContext>(opt =>
    {
      opt.UseSqlite(config.GetConnectionString("DeafultConnection"));
    });
    services.AddCors();
    services.AddScoped<ITokenService, TokenService>();

    return services;
  }
}
