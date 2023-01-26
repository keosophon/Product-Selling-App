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
using Android.Graphics;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ProductViewActivity : AppCompatActivity
    {
        private ImageButton imgBtnProduct;
        private TextView txtProductName;
        private TextView txtProductPrice;
        private TextView txtProductDescription;
        private TextView txtDashBoard;
        private TextView txtLogOut;
        private Button btnBuyNow;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_productViewAdd);

            //link variables to UI
            imgBtnProduct = FindViewById<ImageButton>(Resource.Id.imgbtnProductView);
            txtProductName = FindViewById<TextView>(Resource.Id.txtProductName);
            txtProductPrice = FindViewById<TextView>(Resource.Id.txtProductPrice);
            txtProductDescription = FindViewById<TextView>(Resource.Id.txtProductDesc);
            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            btnBuyNow = FindViewById<Button>(Resource.Id.btnBuyNow);


            //display info of the product that has been cliked in Dashboard
            var product = JsonConvert.DeserializeObject<Product>(Intent.GetStringExtra("product"));            
            var bitmapImg = BitMapImageCreator.CreateBitMapFromName(Resources, product.ImageBig);
            imgBtnProduct.SetImageBitmap(bitmapImg);
            txtProductName.Text = product.Name;
            txtProductPrice.Text = Resources.GetString(Resource.String.dollarSign) + product.Price.ToString() + " " + Resources.GetString(Resource.String.nzd);
            txtProductDescription.Text = product.Description;

            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                StartActivity(typeof(DashBoardActivity));
            };

            btnBuyNow.Click += delegate
            {
                StartActivity(typeof(AddToCartActivity));
            };
        }
    }
}