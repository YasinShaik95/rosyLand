using System.Text;
using api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseSqlite(builder.Configuration.GetConnectionString("DeafultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
  options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:Audience"],
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
  };
}
);

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
