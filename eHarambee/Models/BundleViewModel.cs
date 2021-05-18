using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.Models
{
  public class BundleViewModel
  {
    public int BundleID { get; set; }
    public string BundleName { get; set; }
    public string BundleDescription { get; set; }

    public decimal? BundleCost { get; set; }

  }
}
