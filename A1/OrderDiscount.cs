using System;
using System.Collections.Generic;

#nullable disable

namespace A1
{
    public partial class OrderDiscount
    {
        public int OrderId { get; set; }
        public byte DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Order Order { get; set; }
    }
}
