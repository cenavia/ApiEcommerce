using ApiEcommerce.Models;
using ApiEcommerce.Models.Dtos;
using Mapster;

namespace ApiEcommerce.Mapping;

public static class MapsterConfig
{
  public static void RegisterMappings()
  {
    // Product <-> ProductDto
    TypeAdapterConfig<Product, ProductDto>.NewConfig()
        .Map(dest => dest.CategoryName, src => src.Category.Name)
        .TwoWays();
    TypeAdapterConfig<Product, CreateProductDto>.NewConfig().TwoWays();
    TypeAdapterConfig<Product, UpdateProductDto>.NewConfig().TwoWays();

    // Category <-> CategoryDto
    TypeAdapterConfig<Category, CategoryDto>.NewConfig().TwoWays();
    TypeAdapterConfig<Category, CreateCategoryDto>.NewConfig().TwoWays();
  }
}
