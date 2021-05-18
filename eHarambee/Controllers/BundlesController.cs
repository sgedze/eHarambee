using eHarambee.ServiceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.Controllers
{
  
  [ApiController]
  public class BundlesController : ControllerBase
  {
    IBundleData bundleData;
    public BundlesController(IBundleData _bundleData)
    {
      bundleData = _bundleData;
    }

    /// <summary>
    /// Gets all bundles and compute a bundle cost by summing up all the bungle produncts
    /// and deduct the discount
    /// https://localhost:44384/api/Bundles/GetAllBundles
    /// </summary>
    /// <returns>All the bundles</returns>

    [HttpGet]
    [Route("api/[controller]/{action}")]
    public async Task<IActionResult> GetAllBundles()
    {
      try
      {
        var bundles =  bundleData.GetAllBundles();
        if (bundles != null)
        {
          return Ok(bundles);

        }
        return NotFound("No Bundles Found");
      }
      catch (Exception)
      {
        return BadRequest();

        
      }
    }
  }
}
