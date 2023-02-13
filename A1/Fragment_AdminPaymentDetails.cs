using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.Fragment.App;

namespace A1
{
    
    public class Fragment_AdminPaymentDetails : AndroidX.Fragment.App.Fragment
    {
        private Button btnLogOut;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_PaymentDetailsAdmin, container, false);

            btnLogOut = view.FindViewById<Button>(Resource.Id.btnLogOutPaymentAdmin);

            btnLogOut.Click += BtnLogOut_Click;

            return view;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Activity, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}