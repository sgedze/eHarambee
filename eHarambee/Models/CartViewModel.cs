using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.Models
{
  public class CartViewModel
  {
    public int ProductID { get; set; }
    //public int BundleID { get; set; }
    public string ProductName { get; set; }
    //public string BundleName { get; set; }
    public decimal Price { get; set; }

    public decimal CurrentCartValue  { get; set; }

    public List<string> Bundles { get; set; }



  }
}
