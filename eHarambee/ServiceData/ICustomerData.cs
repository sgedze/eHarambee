using eHarambee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.ServiceData
{
 public interface ICustomerData
  {
    Task<Customer> GetCustomer(string CustomerNo);

  }
}
