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
    class DeliveryType
    {
        public int Id { get; set; }
        public string Mechanism { get; set; }
        public string Description { get; set; }
        public decimal ExtraCharge { get; set; }
    }
}