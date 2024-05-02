using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api;

public class AppDbContext : IdentityDbContext<AppUser>
{
  public AppDbContext(DbContextOptions options) : base(options)
  {

  }

  public DbSet<Products> Products { get; set; }
  public DbSet<ProductShape> ProductShapes { get; set; }
  public DbSet<ProductSize> ProductSizes { get; set; }
  public DbSet<ProductType> ProductTypes { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    List<IdentityRole> roles = new List<IdentityRole>{
          new IdentityRole{
            Name = "admin",
            NormalizedName= "ADMIN"
          },
          new IdentityRole{
            Name= "user",
            NormalizedName="USER"
          }
        };

    var appUser = new AppUser
    {
      UserName = "admin",
      Email = "rosyland@gmail.com",
      EmailConfirmed = true,
      FirstName = "admin",
      LastName = "admin",
      NormalizedUserName = "ADMIN"
    };

    PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
    appUser.PasswordHash = ph.HashPassword(appUser, "iamadmin@123");

    builder.Entity<AppUser>().HasData(appUser);

    builder.Entity<IdentityRole>().HasData(roles);

    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
    {
      RoleId = roles.First(role => role.Name == "admin").Id,
      UserId = appUser.Id
    });
  }
}
