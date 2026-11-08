using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }
}
