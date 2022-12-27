using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView forgotPasswordTextView;
        private TextView registerTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //bind variables to UI elements
            forgotPasswordTextView = FindViewById<TextView>(Resource.Id.txtForgotPassword);
            registerTextView = FindViewById<TextView>(Resource.Id.txtRegisterNow);

            forgotPasswordTextView.Click += delegate
            {
                StartActivity(typeof(RegistrationActivity));
            };

            registerTextView.Click += delegate
            {
                StartActivity(typeof(RegistrationActivity));
            };
        }
        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}