using System;
using System.Collections.Generic;

#nullable disable

namespace A1
{
    public partial class DeliveryType
    {
        public DeliveryType()
        {
            Orders = new HashSet<Order>();
        }

        public byte Id { get; set; }
        public string Mechanism { get; set; }
        public string Description { get; set; }
        public decimal ExtraCharge { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
