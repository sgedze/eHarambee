using System;
using System.Collections.Generic;

#nullable disable

namespace eHarambee.Models
{
    public partial class ProductBundle
    {
        public int? ProductId { get; set; }
        public int? BundleId { get; set; }
        public int Quantity { get; set; }

        public virtual Bundle Bundle { get; set; }
        public virtual Product Product { get; set; }
    }
}
