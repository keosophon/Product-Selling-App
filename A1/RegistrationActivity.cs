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
    public class RegistrationActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener
    {

        private TextView txtSelectDoB;
        private TextView txtDoB;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_registration);

            //bind variables to UI elements
            txtSelectDoB = FindViewById<TextView>(Resource.Id.txtSelectDate);
            txtDoB = FindViewById<TextView>(Resource.Id.txtDoB);

            //link event to event handler
            txtSelectDoB.Click += TxtSelectDoB_Click;
            txtSelectDoB.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
            
        }
        
        private void TxtSelectDoB_Click(object sender, EventArgs e)
        {

            DateTime today = DateTime.Today;
            DatePickerDialog dateDialog = new DatePickerDialog(this, this, today.Year, today.Month - 1, today.Day);
            dateDialog.Show();
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            DateTime selectedDate = new DateTime(year, month + 1, dayOfMonth);
            txtDoB.Text = selectedDate.ToShortDateString();
        }

    }
}