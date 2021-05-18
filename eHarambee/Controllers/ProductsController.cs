using eHarambee.ServiceData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eHarambee.Controllers
{
  
  [ApiController]
  public class ProductsController : ControllerBase
  {
    IProductData productData;
    public ProductsController(IProductData _productData)
    {
      productData = _productData;

    }


    /// <summary>
    /// Gets All the products that exist in the DB
    /// https://localhost:44384/api/Products/GetAllProducts
    /// </summary>
    /// <returns>Producs</returns>
    [HttpGet]
    [Route("api/[controller]/{action}")]
    public async Task<IActionResult> GetAllProducts()
    {
      try
      {
        var products = await productData.GetAllProducts();
        if (products != null)
        {
          return Ok(products);
        }
        return NotFound("No Products");

      }
      catch (Exception)
      {
        return BadRequest();

      }
    }

    /// <summary>
    /// Gets products by Category
    /// https://localhost:44384/api/Products/GetProductsByCategory/Cameras
    /// </summary>
    /// <param name="categoryName">Name of the Catergory</param>
    /// <returns>Products of the matched category</returns>

    [HttpGet]
      [Route("api/[controller]/{action}/{categoryName}")]
      public async Task<IActionResult> GetProductsByCategory(string categoryName = null)
      {
        try
        {
          if (categoryName == null || categoryName == "")
          {
            return BadRequest("CategoryName not provided");

          }
          var category = await productData.GetCategory(categoryName);

          if (category == null)
          {
            return NotFound($"Category {categoryName} does not exists");
          }
          var products = await productData.GetProductsByCategory(category.CategoryId);
          if (products != null)
          {
            return Ok(products);
          }
          
          return NotFound("No Products found");

        }
        catch (Exception)
        {
          return BadRequest();

        }
      }


  }
}
