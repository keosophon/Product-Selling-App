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
        private CheckBox cbSenior;
        private CheckBox cbWeekends;
        private CheckBox cbCities;
        private ImageButton imgProduct;
        private TextView txtDescription;
        private TextView txtPrice;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_addToCart);

            spQuantity = FindViewById<Spinner>(Resource.Id.spQuantity);
            cbSenior = FindViewById<CheckBox>(Resource.Id.cbSenior);
            cbWeekends = FindViewById<CheckBox>(Resource.Id.cbWeekends);
            cbCities = FindViewById<CheckBox>(Resource.Id.cbCities);
            imgProduct = FindViewById<ImageButton>(Resource.Id.imgbtnProductSmall);
            txtDescription = FindViewById<TextView>(Resource.Id.txtProductDescCart);
            txtPrice = FindViewById<TextView>(Resource.Id.txtProductPrice);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.quantity, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spQuantity.Adapter = adapter;

            cbSenior.Checked = true;
            cbWeekends.Checked = true;
            cbCities.Checked = true;

            cbSenior.Enabled = false;
            cbWeekends.Enabled = false;
            cbCities.Enabled = false;
            imgProduct.SetImageResource(Resource.Drawable.nurofen);
            imgProduct.SetMaxWidth(100);
            imgProduct.SetMaxHeight(100);
            txtDescription.Text = "Nurofen Ibuprofen Pain & Inflammation 100 Tablets";
            txtPrice.Text = "$9.99 NZD";
        }
    }
}