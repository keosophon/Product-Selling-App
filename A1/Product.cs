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
    class Product
    {
		//public  int Id { get; }
		public string Name { get; set; }
		public Decimal Price { get; set; }
		public int Stock { get; set; }
		public string Description { get; set; }
		public string ImageSmall { get; set; }
		public string ImageBig { get; set; }
		

	}
}