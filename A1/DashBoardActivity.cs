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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class DashBoardActivity : AppCompatActivity
    {
        private TextView txtDashBoard;
        private TextView txtLogOut;
        private TextView txtMedicine;
        private TextView txtSupplement;
        private TextView txtBabyCare;
        private TextView txtFullNameResult;
        private TextView txtEmailResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_dashBoard);

            //link variables to UI elements
            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            txtMedicine = FindViewById<TextView>(Resource.Id.txtMedicine);
            txtSupplement = FindViewById<TextView>(Resource.Id.txtVitaminSupplement);
            txtBabyCare = FindViewById<TextView>(Resource.Id.txtBabyCare);
            txtFullNameResult = FindViewById<TextView>(Resource.Id.txtFullNameResult);
            txtEmailResult = FindViewById<TextView>(Resource.Id.txtEmailResult);

            txtDashBoard.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            txtLogOut.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            txtMedicine.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            txtSupplement.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            txtBabyCare.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;

            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                StartActivity(typeof(DashBoardActivity));
            };


            //for testing
            txtFullNameResult.Text = ": " + "Sophon" + "Keo";
            txtEmailResult.Text = ": " + "1@gmail.com";
        }
        public override void OnBackPressed()
        {
            //disable back button
        }
    }
}