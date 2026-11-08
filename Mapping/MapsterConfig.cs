using ApiEcommerce.Models;
using ApiEcommerce.Models.Dtos;
using Mapster;

namespace ApiEcommerce.Mapping;

public static class MapsterConfig
{
  public static void RegisterMappings()
  {
    // ApplicationUser <-> DTOs de usuario
    // UserName (Identity) y Username (DTO) difieren en mayúsculas: se mapean explícitamente
    TypeAdapterConfig<ApplicationUser, UserDataDto>.NewConfig()
        .Map(dest => dest.Username, src => src.UserName);
    TypeAdapterConfig<ApplicationUser, UserDto>.NewConfig()
        .Map(dest => dest.Username, src => src.UserName);

    // Product <-> ProductDto
    TypeAdapterConfig<Product, ProductDto>.NewConfig()
        .Map(dest => dest.CategoryName, src => src.Category.Name)
        .TwoWays();
    // DTO -> Product: ignoramos la navegación Category para que Mapster NO
    // "desaplane" CategoryId en un objeto Category nuevo (EF intentaría insertarlo).
    TypeAdapterConfig<CreateProductDto, Product>.NewConfig().Ignore(dest => dest.Category);
    TypeAdapterConfig<UpdateProductDto, Product>.NewConfig().Ignore(dest => dest.Category);

    // Category <-> CategoryDto
    TypeAdapterConfig<Category, CategoryDto>.NewConfig().TwoWays();
    TypeAdapterConfig<Category, CreateCategoryDto>.NewConfig().TwoWays();
  }
}
