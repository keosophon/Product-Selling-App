using System;
using System.Collections.Generic;

#nullable disable

namespace A1
{
    public partial class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }

        public virtual Order Order { get; set; }
    }
}
