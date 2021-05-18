using eHarambee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.ServiceData
{
  public class SQLCustomerData : ICustomerData
  {
    eHarambeeContext dbContext;
    public SQLCustomerData(eHarambeeContext _dbContext)
    {
      dbContext = _dbContext;
    }

    public async Task<Customer> GetCustomer(string CustomerNo)
    {
      if (dbContext != null)
      {
        return await dbContext.Customers.FirstOrDefaultAsync(cust => cust.CustomerNo == CustomerNo);
      }
      return null;
    }
  }
}
