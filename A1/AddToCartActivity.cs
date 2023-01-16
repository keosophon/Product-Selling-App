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
using AndroidX.AppCompat.App;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class AddToCartActivity : AppCompatActivity
    {
        private Spinner spQuantity;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_addToCart);

            spQuantity = FindViewById<Spinner>(Resource.Id.spQuantity);
            

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.quantity, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spQuantity.Adapter = adapter;
        }
    }
}