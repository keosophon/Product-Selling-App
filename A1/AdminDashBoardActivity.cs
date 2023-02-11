using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Tabs;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class AdminDashBoardActivity : AppCompatActivity
    {
        private TabLayout tabLayout;
        private FrameLayout frameLayout;
        
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

            frameLayout = (FrameLayout)FindViewById(Resource.Id.frameLayout1);
            tabLayout.TabSelected += TabLayout_TabSelected;
        }
        
        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            var tab = e.Tab;
            int position = tab.Position;

            AndroidX.Fragment.App.Fragment fragment = null;
            switch (position)
            {
                case 0:
                    fragment = new Fragment_AdminPaymentDetails();
                    break;
                case 1:
                    fragment = new Fragment_AdminProductDetails();
                    break;
            }

            var fragmentTransaction = SupportFragmentManager.BeginTransaction()
                                                            .Replace(Resource.Id.frameLayout1, fragment)
                                                            .Commit();  
        }
    }
}