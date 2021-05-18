using eHarambee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.ServiceData
{
  public interface IProductData
  {
    Task<List<Product>> GetAllProducts();
    Task<List<Product>> GetProductsByCategory(int CategoryID);

    Task<Category> GetCategory(string categoryName);

    List<BundleContentsViewModel> GetFullProductContents();
    Product GetProductByProductID(int ProductID);


  }
}
