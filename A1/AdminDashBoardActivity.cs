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
using Google.Android.Material.Tabs;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class AdminDashBoardActivity : AppCompatActivity
    {
        private TabLayout tabLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here            
            SetContentView(Resource.Layout.activity_adminDashBoard);

            tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout1);
            TabLayout.Tab paymentDetailsTab = tabLayout.NewTab();
            paymentDetailsTab.SetText("Payment Details");
            tabLayout.AddTab(paymentDetailsTab,0,true);
            TabLayout.Tab productDetailsTab = tabLayout.NewTab();
            productDetailsTab.SetText("Product Details");
            tabLayout.AddTab(productDetailsTab,1);
        }
    }
}