using ApiEcommerce.Models.Dtos;
using ApiEcommerce.Repository.IRepository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
      _productRepository = productRepository;
      _categoryRepository = categoryRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetProducts()
    {
      var products = _productRepository.GetProducts();
      var productsDto = products.Adapt<List<ProductDto>>();
      return Ok(productsDto);
    }

    [HttpGet("{productId:int}", Name = "GetProduct")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetProduct(int productId)
    {
      var product = _productRepository.GetProduct(productId);
      if (product == null)
      {
        return NotFound($"El producto con el id {productId} no existe");
      }
      var productDto = product.Adapt<ProductDto>();
      return Ok(productDto);
    }

    [HttpGet("searchProductByCategory/{categoryId:int}", Name = "GetProductsForCategory")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetProductsForCategory(int categoryId)
    {
      var products = _productRepository.GetProductsForCategory(categoryId);
      if (products.Count == 0)
      {
        return NotFound($"Los productos con la categoría {categoryId} no existen");
      }
      var productsDto = products.Adapt<List<ProductDto>>();
      return Ok(productsDto);
    }

    [HttpGet("searchProductByNameDescription/{searchTerm}", Name = "SearchProducts")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult SearchProducts(string searchTerm)
    {
      var products = _productRepository.SearchProducts(searchTerm);
      if (products.Count == 0)
      {
        return NotFound($"Los productos con el nombre o descripción '{searchTerm}' no existen");
      }
      var productsDto = products.Adapt<List<ProductDto>>();
      return Ok(productsDto);
    }
  }
}
