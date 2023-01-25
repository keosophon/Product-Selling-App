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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_productViewAdd);

            imgBtnProduct = FindViewById<ImageButton>(Resource.Id.imgbtnProductView);
            txtProductName = FindViewById<TextView>(Resource.Id.txtProductName);
            txtProductPrice = FindViewById<TextView>(Resource.Id.txtProductPrice);
            txtProductDescription = FindViewById<TextView>(Resource.Id.txtProductDesc);

            var product = JsonConvert.DeserializeObject<Product>(Intent.GetStringExtra("product"));     

            int id = (int)typeof(Resource.Drawable).GetField(product.ImageBig).GetValue(null);

            // Converting Drawable Resource to Bitmap
            var bitmapImg = BitmapFactory.DecodeResource(Resources, id);
            imgBtnProduct.SetImageBitmap(bitmapImg);
            txtProductName.Text = product.Name;
            txtProductPrice.Text = product.Price.ToString();
            txtProductDescription.Text = product.Description;

        }
    }
}