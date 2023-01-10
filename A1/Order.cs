using System;
using System.Collections.Generic;

#nullable disable

namespace A1
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderFulfilled { get; set; }
        public int CustomerId { get; set; }
        public byte DeliveryId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual DeliveryType Delivery { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
