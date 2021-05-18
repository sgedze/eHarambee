using System;
using System.Collections.Generic;

#nullable disable

namespace eHarambee.Models
{
    public partial class Bundle
    {
        public int BundleId { get; set; }
        public string BungleName { get; set; }
        public string BundleDescription { get; set; }
        public double? DiscountPerc { get; set; }
        public decimal? Cost { get; set; }
    }
}
