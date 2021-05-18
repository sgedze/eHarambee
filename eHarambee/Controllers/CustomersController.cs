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
  public class CustomersController : ControllerBase
  {
    ICustomerData customerData;
    public CustomersController(ICustomerData _customerData)
    {
      customerData = _customerData;

    }

    /// <summary>
    /// Get a customer by Customer Number
    /// https://localhost:44384/api/Customers/GetCustomer/A1000
    /// </summary>
    /// <param name="custNo"> Number of the customer</param>
    /// <returns></returns>
    [HttpGet]
    [Route("api/[controller]/{action}/{custNo}")]
    public async Task<IActionResult> GetCustomer(string custNo)
    {
      try
      {
        var customer = await customerData.GetCustomer(custNo);
        if (customer == null)
        {
          return NotFound($"Costomer with Customer Number {custNo} was not found.");
        }
        return Ok(customer);

      }
      catch (Exception)
      {
        return BadRequest();

      }
    }
  }
}
