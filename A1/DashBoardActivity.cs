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
        private ImageButton imgBtnProduct2;
        private ImageButton imgBtnProduct3;
        private ImageButton imgBtnProduct4;
        private ImageButton imgBtnProduct5;
        private ImageButton imgBtnProduct6;
        private ImageButton imgBtnProduct7;
        private ImageButton imgBtnProduct8;
        private ImageButton imgBtnProduct9;
        private ImageButton imgBtnProduct10;

        private TextView txtProductDescription1;
        private TextView txtProductDescription2;
        private TextView txtProductDescription3;
        private TextView txtProductDescription4;
        private TextView txtProductDescription5;
        private TextView txtProductDescription6;
        private TextView txtProductDescription7;
        private TextView txtProductDescription8;
        private TextView txtProductDescription9;
        private TextView txtProductDescription10;

        private TextView txtProductPrice1;
        private TextView txtProductPrice2;
        private TextView txtProductPrice3;
        private TextView txtProductPrice4;
        private TextView txtProductPrice5;
        private TextView txtProductPrice6;
        private TextView txtProductPrice7;
        private TextView txtProductPrice8;
        private TextView txtProductPrice9;
        private TextView txtProductPrice10;

        private List<ImageButton> imageButtonList = new List<ImageButton>();
        private List<TextView> descriptionViewList = new List<TextView>();
        private List<TextView> priceViewList = new List<TextView>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_dashBoard);

            //link variables to UI elements
            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);

            imgBtnProduct1 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct1);
            imgBtnProduct2 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct2);
            imgBtnProduct3 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct3);
            imgBtnProduct4 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct4);
            imgBtnProduct5 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct5);
            imgBtnProduct6 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct6);
            imgBtnProduct7 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct7);
            imgBtnProduct8 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct8);
            imgBtnProduct9 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct9);
            imgBtnProduct10 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct10);

            txtProductDescription1 = FindViewById<TextView>(Resource.Id.txtProductDesc1);
            txtProductDescription2 = FindViewById<TextView>(Resource.Id.txtProductDesc2);
            txtProductDescription3 = FindViewById<TextView>(Resource.Id.txtProductDesc3);
            txtProductDescription4 = FindViewById<TextView>(Resource.Id.txtProductDesc4);
            txtProductDescription5 = FindViewById<TextView>(Resource.Id.txtProductDesc5);
            txtProductDescription6 = FindViewById<TextView>(Resource.Id.txtProductDesc6);
            txtProductDescription7 = FindViewById<TextView>(Resource.Id.txtProductDesc7);
            txtProductDescription8 = FindViewById<TextView>(Resource.Id.txtProductDesc8);
            txtProductDescription9 = FindViewById<TextView>(Resource.Id.txtProductDesc9);
            txtProductDescription10 = FindViewById<TextView>(Resource.Id.txtProductDesc10);

            txtProductPrice1 = FindViewById<TextView>(Resource.Id.txtProductPrice1);
            txtProductPrice2 = FindViewById<TextView>(Resource.Id.txtProductPrice2);
            txtProductPrice3 = FindViewById<TextView>(Resource.Id.txtProductPrice3);
            txtProductPrice4 = FindViewById<TextView>(Resource.Id.txtProductPrice4);
            txtProductPrice5 = FindViewById<TextView>(Resource.Id.txtProductPrice5);
            txtProductPrice6 = FindViewById<TextView>(Resource.Id.txtProductPrice6);
            txtProductPrice7 = FindViewById<TextView>(Resource.Id.txtProductPrice7);
            txtProductPrice8 = FindViewById<TextView>(Resource.Id.txtProductPrice8);
            txtProductPrice9 = FindViewById<TextView>(Resource.Id.txtProductPrice9);
            txtProductPrice10 = FindViewById<TextView>(Resource.Id.txtProductPrice10);

            imageButtonList.Add(imgBtnProduct1);
            imageButtonList.Add(imgBtnProduct2);
            imageButtonList.Add(imgBtnProduct3);
            imageButtonList.Add(imgBtnProduct4);
            imageButtonList.Add(imgBtnProduct5);
            imageButtonList.Add(imgBtnProduct6);
            imageButtonList.Add(imgBtnProduct7);
            imageButtonList.Add(imgBtnProduct8);
            imageButtonList.Add(imgBtnProduct9);
            imageButtonList.Add(imgBtnProduct10);

            descriptionViewList.Add(txtProductDescription1);
            descriptionViewList.Add(txtProductDescription2);
            descriptionViewList.Add(txtProductDescription3);
            descriptionViewList.Add(txtProductDescription4);
            descriptionViewList.Add(txtProductDescription5);
            descriptionViewList.Add(txtProductDescription6);
            descriptionViewList.Add(txtProductDescription7);
            descriptionViewList.Add(txtProductDescription8);
            descriptionViewList.Add(txtProductDescription9);
            descriptionViewList.Add(txtProductDescription10);


            priceViewList.Add(txtProductPrice1);
            priceViewList.Add(txtProductPrice2);
            priceViewList.Add(txtProductPrice3);
            priceViewList.Add(txtProductPrice4);
            priceViewList.Add(txtProductPrice5);
            priceViewList.Add(txtProductPrice6);
            priceViewList.Add(txtProductPrice7);
            priceViewList.Add(txtProductPrice8);
            priceViewList.Add(txtProductPrice9);
            priceViewList.Add(txtProductPrice10);

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

                for (int i = 0; i < productList.Count; i++)
                {
                    // Retrieving the local Resource ID from the name
                    int id = (int)typeof(Resource.Drawable).GetField(productList[i].ImageSmall).GetValue(null);

                    // Converting Drawable Resource to Bitmap
                    var bitmapImg = BitmapFactory.DecodeResource(Resources, id);
                    imageButtonList[i].SetImageBitmap(bitmapImg);
                    descriptionViewList[i].Text = productList[i].Description;
                    priceViewList[i].Text = productList[i].Price.ToString();

                }
            }
            catch (Exception ex)
            {
                this.BuildAlertDialog("Connection Error", ex.Message);
            }
        }     

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