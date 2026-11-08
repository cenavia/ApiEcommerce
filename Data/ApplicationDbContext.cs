using ApiEcommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Obligatorio: configura las tablas AspNetUsers, AspNetRoles, AspNetUserRoles...
    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }
  // Tabla heredada de la Fase 4. 'new' indica que ocultamos a propósito
  // la propiedad Users (DbSet<ApplicationUser>) de IdentityDbContext.
  public new DbSet<User> Users { get; set; }
  public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}
