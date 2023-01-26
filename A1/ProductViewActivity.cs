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
        private Bundle bundle;
        private Product product;
        //private Customer customer;
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


            //Getting customer from Dashboard
            //customer = JsonConvert.DeserializeObject<Customer>(Intent.GetStringExtra("customer"));

            
            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //display info of the product that has been cliked in Dashboard
            product = JsonConvert.DeserializeObject<Product>(bundle.GetString("product"));
            //product = JsonConvert.DeserializeObject<Product>(Intent.GetStringExtra("product"));            
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
                if (product!=null)
                {
                    bundle.Remove("product");
                }
                var intent = new Intent(this, typeof(DashBoardActivity));
                intent.PutExtras(bundle);
                StartActivity(intent);                
            };

            btnBuyNow.Click += BtnBuyNow_Click;
        }

        private void BtnBuyNow_Click(object sender, EventArgs e)
        {
            this.OpenAddToCartActivity(product);
        }

        //passing bundle containing sing-in customer and product to addToCartActivity
        private void OpenAddToCartActivity(Product product)
        {
            var intent = new Intent(this, typeof(AddToCartActivity));
            intent.PutExtras(bundle);
            StartActivity(intent);
        }
    }
}