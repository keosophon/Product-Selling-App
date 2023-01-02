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
        private EditText txtEmailLog;
        private EditText txtPassword;
        private TextView txtForgotPassword;
        private TextView txtRegisterNow;
        private TextView btnSingIn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //bind variables to UI elements
            txtEmailLog = FindViewById<EditText>(Resource.Id.txtEmailLog);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassowrdLog);
            txtForgotPassword = FindViewById<TextView>(Resource.Id.txtForgotPassword);
            txtRegisterNow = FindViewById<TextView>(Resource.Id.txtRegisterNow);
            btnSingIn = FindViewById<Button>(Resource.Id.btnLogin);

            //underline text in UI
            txtRegisterNow.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            txtForgotPassword.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;

            txtEmailLog.RequestFocus();



            //link events to event handlers
            txtRegisterNow.Click += delegate
            {
                StartActivity(typeof(RegistrationActivity));
            };

            btnSingIn.Click += BtnSingIn_Click;
        }

        public override void OnBackPressed()
        {
            //disable back button
        }

        private void BtnSingIn_Click(object sender, System.EventArgs e)
        {
            //just test

            if (txtEmailLog.Text=="1" && txtPassword.Text=="1")
            {
                StartActivity(typeof(DashBoardActivity));
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}