using ApiEcommerce.Models;
using ApiEcommerce.Models.Dtos;
using Mapster;

namespace ApiEcommerce.Mapping;

public static class MapsterConfig
{
  public static void RegisterMappings()
  {
    // User <-> UserDto
    TypeAdapterConfig<User, UserDto>.NewConfig().TwoWays();
    TypeAdapterConfig<User, UserDataDto>.NewConfig().TwoWays();

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
