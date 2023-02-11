using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A1
{
    
    public class Fragment_AdminProductDetails : AndroidX.Fragment.App.Fragment
    {
        private TextView txtProductIdAdmin;
        private TextView txtProductNameAdmin;
        private TextView txtProductPriceAdmin;
        private TextView txtProductStockAdmin;
        private TextView txtProductDescriptionAdmin;
        private TextView txtProductImageSmallUrl;
        private TextView txtProductImageBigUrl;
        private Button btnAdd;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             return inflater.Inflate(Resource.Layout.fragment_ProductDetails, container, false);
        }
    }
}