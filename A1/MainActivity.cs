using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText txtEmailPhoneLog;
        private EditText txtPassword;
        private TextView txtRegisterNow;
        private TextView btnSingIn;

        //creae database connection
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //bind variables to UI elements
            txtEmailPhoneLog = FindViewById<EditText>(Resource.Id.txtEmailPhoneLog);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassowrdLog);
            txtRegisterNow = FindViewById<TextView>(Resource.Id.txtRegisterNow);
            btnSingIn = FindViewById<Button>(Resource.Id.btnLogin);

            //underline text in UI
            txtRegisterNow.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;

            txtEmailPhoneLog.RequestFocus();

            //link events to event handlers
            txtRegisterNow.Click += delegate
            {
                StartActivity(typeof(RegistrationActivity));
            };

            btnSingIn.Click += BtnSingIn_Click;

            this.OpenConnection();
        }
        public void OpenConnection()
        {
            var retries = 10;

            while (conn.State != ConnectionState.Open && retries > 0)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    this.BuildAlertDialog("Connection Error", ex.Message);

                }
                Thread.Sleep(500);
                retries--;
            }
        }

        public override void OnBackPressed()
        {
            //disable back button
        }

        private void BtnSingIn_Click(object sender, System.EventArgs e)
        {
            ICRUD<Customer> customerCRUD = CRUDFactory.CreateCRUD<Customer>();
            //CustomerCRUD customerCRUD = new CustomerCRUD();
            Customer cus = customerCRUD.GetObject(txtEmailPhoneLog.Text);

            if (cus == null)
            {
                this.BuildAlertDialog("Wrong Input", "Username or Password is incorrect");
                return;
            }
            

            if ((txtEmailPhoneLog.Text == cus.Email || txtEmailPhoneLog.Text == cus.Phone) && txtPassword.Text == cus.Password)
            {
                StartActivity(typeof(DashBoardActivity));
            }
            else
            {
                this.BuildAlertDialog("Wrong Input", "Username or Password is incorrect");
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
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        

        
    }
}