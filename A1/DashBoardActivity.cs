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
using System.Net;
using Android.Graphics;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class DashBoardActivity : AppCompatActivity
    {
        private TextView txtDashBoard;
        private TextView txtLogOut;
        private ImageButton imgBtnProduct1;
        private TextView txtProductDescription1;
        private TextView txtProductPrice1;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_dashBoard);

            //link variables to UI elements
            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            imgBtnProduct1 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct1);
            txtProductDescription1 = FindViewById<TextView>(Resource.Id.txtProductDesc1);
            txtProductPrice1 = FindViewById<TextView>(Resource.Id.txtProductPrice1);
            
            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                StartActivity(typeof(DashBoardActivity));
            };

            this.DisplayAllProducts();

        }
        
        public override void OnBackPressed()
        {
            //disable back button
        }

        public void DisplayAllProducts()
        {
            //create productCRUD through Factory Design Pattern
            ICRUD<Product> productCRUD = CRUDFactory.CreateCRUD<Product>();

            try
            {
                List<Product> productList = productCRUD.GetObjects();
                // Retrieving the local Resource ID from the name
                int id = (int)typeof(Resource.Drawable).GetField(productList[0].ImageSmall).GetValue(null);

                // Converting Drawable Resource to Bitmap
                var myImage = BitmapFactory.DecodeResource(Resources, id);
                imgBtnProduct1.SetImageBitmap(myImage);

                txtProductDescription1.Text = productList[0].Description;
                txtProductPrice1.Text = productList[0].Price.ToString();
            }
            catch (Exception ex)
            {
                this.BuildAlertDialog("Connection Error", ex.Message);
            }
        }

            
            /*
            private Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
            {
                Android.Graphics.Bitmap imageBitmap = null;

                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

                return imageBitmap;
            }
            */
        
            
            

        public void BuildAlertDialog(string title, string message)
        {
            Android.App.AlertDialog.Builder connectionException = new Android.App.AlertDialog.Builder(this);
            connectionException.SetTitle(title);
            connectionException.SetMessage(message);
            connectionException.SetNegativeButton("Return", delegate { });
            connectionException.Create();
            connectionException.Show();
        }

    }
}