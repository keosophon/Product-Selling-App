using System;
using System.Collections.Generic;

#nullable disable

namespace A1
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageSmall { get; set; }
        public string ImageBig { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
