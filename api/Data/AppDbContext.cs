using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api;

public class AppDbContext : IdentityDbContext
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

    builder.Entity<IdentityRole>().HasData(roles);
  }
}
