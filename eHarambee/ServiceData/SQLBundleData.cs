using eHarambee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.ServiceData
{
  public class SQLBundleData : IBundleData
  {
    eHarambeeContext DbContext;
    public SQLBundleData( eHarambeeContext _DbContext)
    {
      DbContext = _DbContext;

    }
    public List<BundleViewModel> GetAllBundles()
    {
      if (DbContext!=null)
      {

        return  (
           from b in DbContext.Bundles
           join pb in DbContext.ProductBundles on b.BundleId equals pb.BundleId
           join p in DbContext.Products on pb.ProductId equals p.ProductId
           //group new {b.BungleName, b.BundleDescription) into g
           group new {pb,p,b} by new { b.BundleId, b.BungleName, b.BundleDescription } into g
           select new BundleViewModel
           {
             BundleID = g.Key.BundleId,
             BundleName  = g.Key.BungleName,
             BundleDescription = g.Key.BundleDescription,
             BundleCost = g.Sum(x => (x.p.Price * x.pb.Quantity) - ((x.p.Price * x.pb.Quantity)* (Decimal)(x.b.DiscountPerc)))
           }).ToList();

      }
      return null;
       
    }
  }
}
