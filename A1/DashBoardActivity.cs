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

        private TextView txtProductName1;
        private TextView txtProductName2;
        private TextView txtProductName3;
        private TextView txtProductName4;
        private TextView txtProductName5;
        private TextView txtProductName6;
        private TextView txtProductName7;
        private TextView txtProductName8;
        private TextView txtProductName9;
        private TextView txtProductName10;

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
        private Button btnSeeDetails1;
        private Button btnSeeDetails2;
        private Button btnSeeDetails3;
        private Button btnSeeDetails4;
        private Button btnSeeDetails5;
        private Button btnSeeDetails6;
        private Button btnSeeDetails7;
        private Button btnSeeDetails8;
        private Button btnSeeDetails9;
        private Button btnSeeDetails10;

        private List<ImageButton> imageButtonList = new List<ImageButton>();
        private List<TextView> nameViewList = new List<TextView>();
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

            txtProductName1 = FindViewById<TextView>(Resource.Id.txtProductName1);
            txtProductName2 = FindViewById<TextView>(Resource.Id.txtProductName2);
            txtProductName3 = FindViewById<TextView>(Resource.Id.txtProductName3);
            txtProductName4 = FindViewById<TextView>(Resource.Id.txtProductName4);
            txtProductName5 = FindViewById<TextView>(Resource.Id.txtProductName5);
            txtProductName6 = FindViewById<TextView>(Resource.Id.txtProductName6);
            txtProductName7 = FindViewById<TextView>(Resource.Id.txtProductName7);
            txtProductName8 = FindViewById<TextView>(Resource.Id.txtProductName8);
            txtProductName9 = FindViewById<TextView>(Resource.Id.txtProductName9);
            txtProductName10 = FindViewById<TextView>(Resource.Id.txtProductName10);

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
            
            btnSeeDetails1 = FindViewById<Button>(Resource.Id.btnDetail1);
            btnSeeDetails1.Click += this.SeeDetails_Click;
            btnSeeDetails2 = FindViewById<Button>(Resource.Id.btnDetail2);
            btnSeeDetails2.Click += this.SeeDetails_Click;
            btnSeeDetails3 = FindViewById<Button>(Resource.Id.btnDetail3);
            btnSeeDetails3.Click += this.SeeDetails_Click;
            btnSeeDetails4 = FindViewById<Button>(Resource.Id.btnDetail4);
            btnSeeDetails4.Click += this.SeeDetails_Click;
            btnSeeDetails5 = FindViewById<Button>(Resource.Id.btnDetail5);
            btnSeeDetails5.Click += this.SeeDetails_Click;
            btnSeeDetails6 = FindViewById<Button>(Resource.Id.btnDetail6);
            btnSeeDetails6.Click += this.SeeDetails_Click;
            btnSeeDetails7 = FindViewById<Button>(Resource.Id.btnDetail7);
            btnSeeDetails7.Click += this.SeeDetails_Click;
            btnSeeDetails8 = FindViewById<Button>(Resource.Id.btnDetail8);
            btnSeeDetails8.Click += this.SeeDetails_Click;
            btnSeeDetails9 = FindViewById<Button>(Resource.Id.btnDetail9);
            btnSeeDetails9.Click += this.SeeDetails_Click;
            btnSeeDetails10 = FindViewById<Button>(Resource.Id.btnDetail10);
            btnSeeDetails10.Click += this.SeeDetails_Click;


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

            nameViewList.Add(txtProductName1);
            nameViewList.Add(txtProductName2);
            nameViewList.Add(txtProductName3);
            nameViewList.Add(txtProductName4);
            nameViewList.Add(txtProductName5);
            nameViewList.Add(txtProductName6);
            nameViewList.Add(txtProductName7);
            nameViewList.Add(txtProductName8);
            nameViewList.Add(txtProductName9);
            nameViewList.Add(txtProductName10);


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
                    nameViewList[i].Text = productList[i].Name;
                    priceViewList[i].Text = productList[i].Price.ToString();
                 }
            }
            catch (Exception ex)
            {
                this.BuildAlertDialog("Connection Error", ex.Message);
            }
        }

        private void SeeDetails_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ProductViewActivity));
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