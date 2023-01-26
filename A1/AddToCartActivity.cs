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
using Newtonsoft.Json;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]

    public class AddToCartActivity : AppCompatActivity
    {
        private TextView txtDashBoard;
        private TextView txtLogOut;

        private Spinner spQuantity;
        private CheckBox cbSenior;
        private CheckBox cbWeekends;
        private CheckBox cbCities;
        private ImageButton imgProduct;
        private TextView txtDescription;
        private TextView txtPrice;
        private Product product;
        private Bundle bundle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_addToCart);            

            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);

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

            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //display info of the product that has been cliked in Dashboard
            product = JsonConvert.DeserializeObject<Product>(bundle.GetString("product"));
            //product = JsonConvert.DeserializeObject<Product>(Intent.GetStringExtra("product"));
            var bitmapImg = BitMapImageCreator.CreateBitMapFromName(Resources, product.ImageSmall);
            imgProduct.SetImageBitmap(bitmapImg);
            txtPrice.Text = Resources.GetString(Resource.String.dollarSign) + product.Price.ToString() + " " + Resources.GetString(Resource.String.nzd);
            txtDescription.Text = product.Description;

            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                if (product != null)
                {
                    bundle.Remove("product");
                }
                var intent = new Intent(this, typeof(DashBoardActivity));
                intent.PutExtras(bundle);
                StartActivity(intent);
            };
        }

        
    }
}