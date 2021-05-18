using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.Models
{
  public class BundleContentsViewModel
  {
    public int ProductID { get; set; }
    public int BundleID { get; set; }
    public string ProductName { get; set; }
    public string BundleName   { get; set; }
    public decimal Price   { get; set; }

    public bool eligible { get; set; }
    public int Quantity { get; set; }
    

  }
}
