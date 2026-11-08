using ApiEcommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiEcommerce.Data;

public static class DataSeeder
{
  public static void SeedData(ApplicationDbContext appContext)
  {
    // 1) Roles
    if (!appContext.Roles.Any())
    {
      appContext.Roles.AddRange(
        new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
        new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
      );
    }

    // 2) Categorías
    if (!appContext.Categories.Any())
    {
      appContext.Categories.AddRange(
        new Category { Name = "Ropa y accesorios", CreationDate = DateTime.Now },
        new Category { Name = "Electrónicos", CreationDate = DateTime.Now },
        new Category { Name = "Deportes", CreationDate = DateTime.Now },
        new Category { Name = "Hogar", CreationDate = DateTime.Now },
        new Category { Name = "Libros", CreationDate = DateTime.Now }
      );
    }
    // Guardamos ya para que roles y categorías tengan Id real en la BD
    appContext.SaveChanges();

    // 3) Usuarios de demo (admin y usuario regular)
    if (!appContext.ApplicationUsers.Any())
    {
      var hasher = new PasswordHasher<ApplicationUser>();
      var adminUser = new ApplicationUser
      {
        Id = "admin-001",
        UserName = "admin@admin.com",
        NormalizedUserName = "ADMIN@ADMIN.COM",
        Email = "admin@admin.com",
        NormalizedEmail = "ADMIN@ADMIN.COM",
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        Name = "Administrador"
      };
      adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

      var regularUser = new ApplicationUser
      {
        Id = "user-001",
        UserName = "user@user.com",
        NormalizedUserName = "USER@USER.COM",
        Email = "user@user.com",
        NormalizedEmail = "USER@USER.COM",
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString(),
        Name = "Usuario Regular"
      };
      regularUser.PasswordHash = hasher.HashPassword(regularUser, "User123!");

      appContext.ApplicationUsers.AddRange(adminUser, regularUser);
    }

    // 4) Relación usuario-rol
    if (!appContext.UserRoles.Any())
    {
      appContext.UserRoles.AddRange(
        new IdentityUserRole<string> { UserId = "admin-001", RoleId = "1" }, // Admin
        new IdentityUserRole<string> { UserId = "user-001", RoleId = "2" }   // User
      );
    }
    appContext.SaveChanges();

    // 5) Productos (buscamos cada categoría por nombre)
    if (!appContext.Products.Any())
    {
      Category Cat(string name) => appContext.Categories.First(c => c.Name == name);

      var ropa = Cat("Ropa y accesorios");
      var electronicos = Cat("Electrónicos");
      var deportes = Cat("Deportes");
      var hogar = Cat("Hogar");
      var libros = Cat("Libros");

      appContext.Products.AddRange(
        new Product { Name = "Camiseta Básica", Description = "Camiseta de algodón 100%", Price = 25.99m, SKU = "PROD-001-CAM-M", Stock = 50, CategoryId = ropa.Id, Category = ropa, ImgUrl = "https://placehold.co/300x300?text=Camiseta", CreationDate = DateTime.Now },
        new Product { Name = "Smartphone Galaxy", Description = "Teléfono inteligente con 128GB", Price = 599.99m, SKU = "PROD-002-PHO-BLK", Stock = 25, CategoryId = electronicos.Id, Category = electronicos, ImgUrl = "https://placehold.co/300x300?text=Smartphone", CreationDate = DateTime.Now },
        new Product { Name = "Pelota de Fútbol", Description = "Pelota oficial FIFA", Price = 45.00m, SKU = "PROD-003-BAL-WHT", Stock = 30, CategoryId = deportes.Id, Category = deportes, ImgUrl = "https://placehold.co/300x300?text=Pelota", CreationDate = DateTime.Now },
        new Product { Name = "Lámpara de Mesa", Description = "Lámpara LED regulable", Price = 89.99m, SKU = "PROD-004-LAM-WHT", Stock = 15, CategoryId = hogar.Id, Category = hogar, ImgUrl = "https://placehold.co/300x300?text=Lampara", CreationDate = DateTime.Now },
        new Product { Name = "El Quijote", Description = "Novela clásica de Cervantes", Price = 19.99m, SKU = "PROD-005-LIB-ESP", Stock = 100, CategoryId = libros.Id, Category = libros, ImgUrl = "https://placehold.co/300x300?text=Libro", CreationDate = DateTime.Now },
        new Product { Name = "Jeans Clásicos", Description = "Pantalones vaqueros azules", Price = 79.99m, SKU = "PROD-006-PAN-BLU", Stock = 40, CategoryId = ropa.Id, Category = ropa, ImgUrl = "https://placehold.co/300x300?text=Jeans", CreationDate = DateTime.Now },
        new Product { Name = "Tablet Pro", Description = "Tablet 10.5 pulgadas con stylus incluido", Price = 459.99m, SKU = "PROD-007-TAB-SIL", Stock = 20, CategoryId = electronicos.Id, Category = electronicos, ImgUrl = "https://placehold.co/300x300?text=Tablet", CreationDate = DateTime.Now },
        new Product { Name = "Zapatillas Running", Description = "Zapatillas deportivas para correr", Price = 129.99m, SKU = "PROD-008-ZAP-BLK", Stock = 35, CategoryId = deportes.Id, Category = deportes, ImgUrl = "https://placehold.co/300x300?text=Zapatillas", CreationDate = DateTime.Now },
        new Product { Name = "Cafetera Express", Description = "Cafetera automática con molinillo integrado", Price = 299.99m, SKU = "PROD-009-CAF-BLK", Stock = 12, CategoryId = hogar.Id, Category = hogar, ImgUrl = "https://placehold.co/300x300?text=Cafetera", CreationDate = DateTime.Now },
        new Product { Name = "Programación en C#", Description = "Guía completa de programación en C# y .NET", Price = 49.99m, SKU = "PROD-010-LIB-ESP", Stock = 80, CategoryId = libros.Id, Category = libros, ImgUrl = "https://placehold.co/300x300?text=CSharp", CreationDate = DateTime.Now },
        new Product { Name = "Chaqueta Deportiva", Description = "Chaqueta impermeable para actividades al aire libre", Price = 149.99m, SKU = "PROD-011-CHA-NAV", Stock = 28, CategoryId = ropa.Id, Category = ropa, ImgUrl = "https://placehold.co/300x300?text=Chaqueta", CreationDate = DateTime.Now },
        new Product { Name = "Auriculares Bluetooth", Description = "Auriculares inalámbricos con cancelación de ruido", Price = 189.99m, SKU = "PROD-012-AUR-BLK", Stock = 45, CategoryId = electronicos.Id, Category = electronicos, ImgUrl = "https://placehold.co/300x300?text=Auriculares", CreationDate = DateTime.Now }
      );
      appContext.SaveChanges();
    }
  }
}
