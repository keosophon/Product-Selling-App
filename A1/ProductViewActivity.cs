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
        private Bitmap bitmapImg;
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
            
            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //display info of the product that has been cliked in Dashboard
            product = JsonConvert.DeserializeObject<Product>(bundle.GetString(Resources.GetString(Resource.String.product)));
            
            try {
                bitmapImg = BitMapImageCreator.CreateBitMapFromName(Resources, product.ImageBig);
                imgBtnProduct.SetImageBitmap(bitmapImg);
                imgBtnProduct.SetScaleType(ImageButton.ScaleType.FitXy);
            }
            catch (Exception)
            {
                try
                {
                    bitmapImg = BitMapImageCreator.FetchImage(product.ImageBig);
                    imgBtnProduct.SetImageBitmap(bitmapImg);
                    imgBtnProduct.SetScaleType(ImageButton.ScaleType.FitXy);
                }
                catch(Exception)
                {
                    imgBtnProduct.ContentDescription = product.Name;

                }

            }
            
            //imgBtnProduct.SetImageBitmap(bitmapImg);
            txtProductName.Text = product.Name;
            txtProductPrice.Text = Resources.GetString(Resource.String.dollarSign) + product.Price.ToString() + " " + Resources.GetString(Resource.String.nzd);
            txtProductDescription.Text = product.Description;

            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                var intent = new Intent(this, typeof(DashBoardActivity));
                intent.PutExtras(bundle);
                StartActivity(intent);                
            };

            btnBuyNow.Click += BtnBuyNow_Click;
        }

        public override void OnBackPressed()
        {
            //disable back button
        }

        private void BtnBuyNow_Click(object sender, EventArgs e)
        {
            this.OpenAddToCartActivity();
        }

        //passing bundle containing sing-in customer and product to addToCartActivity
        private void OpenAddToCartActivity()
        {
            var intent = new Intent(this, typeof(AddToCartActivity));
            intent.PutExtras(bundle);
            StartActivity(intent);
        }
    }
}