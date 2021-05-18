using eHarambee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.ServiceData
{
  public class SQLProductData : IProductData
  {
    eHarambeeContext DbContext;
    public SQLProductData( eHarambeeContext _DBContext)
    {
      DbContext = _DBContext;
    }
    public async Task<List<Product>> GetAllProducts()
    {
      if (DbContext != null)
      {
        return await DbContext.Products.ToListAsync();
      }
      return null;
    
    }

    public async Task<Category> GetCategory(string categoryName)
    {
      if (DbContext != null)
      {
        return await DbContext.Categories.FirstOrDefaultAsync(cat => cat.CategoryName.ToLower() == categoryName.ToLower());

      }
      return null;
      
    }

    public   List<BundleContentsViewModel> GetFullProductContents()
    {
      if(DbContext != null)
      {
          var Contentlist =   (
           from b in DbContext.Bundles
           join pb in DbContext.ProductBundles on b.BundleId equals pb.BundleId
           join p in DbContext.Products on pb.ProductId equals p.ProductId
           select new BundleContentsViewModel
           {
             BundleID = b.BundleId,
             BundleName = b.BungleName,
             ProductID = p.ProductId,
             ProductName = p.ProductName,
             Quantity = pb.Quantity,
             Price = p.Price,

           }).ToList();

        return Contentlist;
      }
      return null;
    }

    public Product GetProductByProductID(int ProductID)
    {
      if (DbContext!=null)
      {
        return DbContext.Products.FirstOrDefault(p => p.ProductId == ProductID);

      }
      return null;
    }

    public async Task<List<Product>> GetProductsByCategory(int CategoryID)
    {
      if(DbContext != null)
      {
        return await DbContext.Products.Where(prod => prod.CategoryId == CategoryID).ToListAsync();
      }
      return null;
    }
  }
}
