using eHarambee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace eHarambee.ServiceData
{
  public class CartData : ICart
  {
    eHarambeeContext dbContext;
    public List<BundleViewModel> AllBundles { get; set; }
   

    public List<BundleContentsViewModel> AllBundleContents { get; set; }


    public  List<CartViewModel> CartItems { get; set; }
    
    public CartData( eHarambeeContext _dbContect)
    {
      dbContext = _dbContect;
      CartItems = new List<CartViewModel>();
      if (dbContext!= null)
      {
        SQLBundleData sQLBundleData = new SQLBundleData(dbContext);
        AllBundles = sQLBundleData.GetAllBundles();
        SQLProductData sQLProductData = new SQLProductData(dbContext);
       
        AllBundleContents = sQLProductData.GetFullProductContents();
     
         


      }


    }
    
    public CartViewModel AddToCart(int [] ProductIDs,int[] NumberOfItems)
    {
      if (dbContext!=null && ProductIDs.Length == NumberOfItems.Length)
      {

        //SQLBundleData sQLBundleData = new SQLBundleData(dbContext);
        SQLProductData sQLProductData = new SQLProductData(dbContext);

        //decrementing the total quantity of the specific product
        for (int i = 0; i < ProductIDs.Length; i++)
        {

           AllBundleContents.Where(cont => cont.ProductID == ProductIDs[i]).
           Select(up => { up.Quantity -= NumberOfItems[i]; return up; }).ToList();
        }

        // Calculating Cart Current Value
        for (int i = 0; i < ProductIDs.Length; i++)
        {

          var product = sQLProductData.GetProductByProductID(ProductIDs[i]);

          //add to cart
          CartItems.Add(new CartViewModel
          {
            ProductID = product.ProductId,
            ProductName = product.ProductName,
            Price = product.Price * NumberOfItems[i]
          });

        }

       
         



        // getting bundle names of  Bundles formed
        var verifiedCartBundles =  (from a in AllBundleContents
                                               group a by new { a.BundleID, a.BundleName } into g
                                               where g.Sum(g => g.Quantity) == 0
                                               select g.Key.BundleName).ToList();

        return new CartViewModel { Bundles = verifiedCartBundles, CurrentCartValue = CartItems.Sum(cvm => cvm.Price) }; 
        


      }

      return null;
    }

    public  decimal getCartValue()
    {
      return CartItems.Sum(p => p.Price);
    }
  }
}
