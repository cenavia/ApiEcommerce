using ApiEcommerce.Models;
using ApiEcommerce.Models.Dtos;
using Mapster;

namespace ApiEcommerce.Mapping;

public static class MapsterConfig
{
  public static void RegisterMappings()
  {
    // Category <-> CategoryDto
    TypeAdapterConfig<Category, CategoryDto>.NewConfig().TwoWays();
    TypeAdapterConfig<Category, CreateCategoryDto>.NewConfig().TwoWays();
  }
}
