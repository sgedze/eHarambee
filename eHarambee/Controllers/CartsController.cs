using eHarambee.Models;
using eHarambee.ServiceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.Controllers
{
  
  [ApiController]
  public class CartsController : ControllerBase
  {
    ICart cart;

    public CartsController(ICart _cart)
    {
      cart = _cart;
    }


    /// <summary>
    /// Checks whether the added productIds and NumberOfItems array form a full Bundle 
    /// as per Bundle table description. Check ProductBundles table for Bundle formed (ProductIDs and Quantity for the specific bundle)
    /// Api Call Example : https://localhost:44384/api/Carts/AddToCart?productId=1&productId=8&productId=9&productId=6&NumberOfItems=3&NumberOfItems=1&NumberOfItems=1&NumberOfItems=1
    /// </summary>
    /// <param name="productId">Array of productIDs</param>
    /// <param name="NumberOfItems">Array of NumberOfItems added to the cart</param>
    /// <returns> The names of the formed Bundles</returns>
    [HttpGet]
    [Route("api/[controller]/{action}")]
public async Task<IActionResult> AddToCart( [FromQuery(Name = "productId" )] int [] productId, [FromQuery(Name = "NumberOfItems")] int [] NumberOfItems)
    {
      try
      {
        var cartBundle =   cart.AddToCart(productId, NumberOfItems);
        HttpContext.Session.SetString("CartCurrentValue", cartBundle.CurrentCartValue.ToString("C", new CultureInfo("en-ZA")));
        if (cartBundle.Bundles.Count() >0)
        {
          
          return Ok(cartBundle);
        }

        

        return NotFound("Bundle formed not found");

      }
      catch (Exception)
      {

        return BadRequest();
      }

    }
    /// <summary>
    /// Gets the value of the current cart
    /// </summary>
    /// <returns> current value</returns>
    [HttpGet]
    [Route("api/[controller]/{action}")]
    public string GetCartCurrentValue()
    {
      var CurrCartValue = HttpContext.Session.GetString("CartCurrentValue");
      if (CurrCartValue != null)
      {
        return CurrCartValue;
      } 
      return "Cart is Empty, No value";
    }
  }
}
