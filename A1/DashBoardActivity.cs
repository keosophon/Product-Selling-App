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

            List<Product> productList = productCRUD.GetObjects() ;

            txtProductDescription1.Text = productList[0].Description;
            txtProductPrice1.Text = productList[0].Price.ToString();




        }
    }
}