using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentModeId { get; set; }
        public Boolean Status { get; set; }
    }
}