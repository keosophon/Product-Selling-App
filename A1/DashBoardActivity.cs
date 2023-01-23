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
        private GridLayout productGrid;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_dashBoard);

            //link variables to UI elements
            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            productGrid = FindViewById<GridLayout>(Resource.Id.productGrid);
            //this.SetGrid(productGrid);


            
            
            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                StartActivity(typeof(DashBoardActivity));
            };

            

        }

        /*
        public void SetGrid(GridLayout productGrid)
        {
            productGrid.RowCount = 1;
            productGrid.ColumnCount = 2;
            TextView pro1 = new TextView(this);
            pro1.Text = "1";

            var pro1Params = new GridLayout.LayoutParams(GridLayout.InvokeSpec(0, 1), GridLayout.InvokeSpec(0, 1));
            pro1.LayoutParameters = pro1Params;

            TextView pro2 = new TextView(this);
            pro2.Text = "1";
            var pro2Params = new GridLayout.LayoutParams(GridLayout.InvokeSpec(0, 1), GridLayout.InvokeSpec(1, 1));
            pro2.LayoutParameters = pro2Params;
            productGrid.AddView(pro1);
            productGrid.AddView(pro2);
            

        }*/
        
        public override void OnBackPressed()
        {
            //disable back button
        }
    }
}