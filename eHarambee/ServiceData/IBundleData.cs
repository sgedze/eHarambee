using eHarambee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHarambee.ServiceData
{
  public interface IBundleData
  {
    List<BundleViewModel> GetAllBundles(); 
  }
}
