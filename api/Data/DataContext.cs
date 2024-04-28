using Microsoft.EntityFrameworkCore;
using rosyLandApi.Entities;

namespace api.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
}
