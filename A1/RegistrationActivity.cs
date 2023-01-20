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
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RegistrationActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener
    {
        private TextView txtFirstName;
        private TextView txtLastName;
        private TextView txtSelectDoB;
        private TextView txtDoB;
        private TextView txtPhone;
        private TextView txtEmail;
        private TextView txtAdress;
        private TextView txtPassword;
        private TextView txtReEnterPassword;
        private TextView txtSignIn;
        private Button btnSignUp;
                
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_registration);

            //bind variables to UI elements
            txtSelectDoB = FindViewById<TextView>(Resource.Id.txtSelectDate);
            txtDoB = FindViewById<TextView>(Resource.Id.txtDoB);
            txtFirstName = FindViewById<TextView>(Resource.Id.txtFirstNameReg);
            txtLastName = FindViewById<TextView>(Resource.Id.txtLastNameReg);
            txtPhone = FindViewById<TextView>(Resource.Id.txtPhoneNumber);
            txtEmail = FindViewById<TextView>(Resource.Id.txtEmailReg);
            txtAdress = FindViewById<TextView>(Resource.Id.txtAddress);
            txtPassword = FindViewById<TextView>(Resource.Id.txtPasswordReg);
            txtReEnterPassword = FindViewById<TextView>(Resource.Id.txtConfirmPasswordrdReg);
            txtSignIn = FindViewById<TextView>(Resource.Id.txtLoginReg);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            //link event to event handler
            txtSelectDoB.Click += TxtSelectDoB_Click;
            txtSignIn.Click += TxtSignIn_Click;
            btnSignUp.Click += BtnSignUp_Click;

            //underline text in UI
            //txtSelectDoB.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            //txtSignIn.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            
        }
            private void BtnSignUp_Click(object sender, EventArgs e)
        {   


            if (txtPassword.Text == "")
            {
                this.BuildAlertDialog("Password Error", "Password cannot be empty!");
                return;
            }

            if (txtPassword.Text != txtReEnterPassword.Text)
            {
                this.BuildAlertDialog("Password Error", "Password and Re-enter password must be the same!");
                return;
            }

            Customer cs = new Customer();
            CustomerCRUD customerCRUD = new CustomerCRUD();
            cs.FirstName = txtFirstName.Text;
            cs.LastName = txtLastName.Text;
            cs.DoB = Convert.ToDateTime(txtDoB.Text);
            cs.Phone = txtPhone.Text;
            cs.Email = txtEmail.Text;
            cs.Address = txtAdress.Text;
            cs.Password = txtPassword.Text;
            if (customerCRUD.Add(cs) == 1)
            {
                this.BuildAlertDialog("Success!", "Registration succeed!");
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtDoB.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtAdress.Text = "";
                txtPassword.Text = "";
                txtReEnterPassword.Text = "";
            }
            txtSignIn.RequestFocus();

            
            /*
            SqlConnection conn = DBConnection.getConnection();
            var retries = 10;

            while (conn.State != ConnectionState.Open && retries > 0)
            {
                try
                {
                    conn.Open();
                    this.BuildAlertDialog("Open Connection", "Open Connection To SQL Server Success!");
                }
                catch (Exception ex)
                {
                    this.BuildAlertDialog("Connection Error", ex.Message);

                }
                Thread.Sleep(500);
                retries--;
            }
            */

        }

        public override void OnBackPressed()
        {
            //disable back button on device
        }

        private void TxtSignIn_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void TxtSelectDoB_Click(object sender, EventArgs e)
        {

            DateTime today = DateTime.Today;
            DatePickerDialog dateDialog = new DatePickerDialog(this, this, today.Year, today.Month - 1, today.Day);
            dateDialog.Show();
        }

        /// <summary>
        /// It is called after clicking OK of
        /// DatePicker Dialog
        /// </summary>
        /// <param name="view"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dayOfMonth"></param>
        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {

            DateTime selectedDate = new DateTime(year, month + 1, dayOfMonth);
            txtDoB.Text = selectedDate.ToShortDateString();
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