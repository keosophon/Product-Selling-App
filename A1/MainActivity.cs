﻿using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
//using Android.Views;
using Android.Content;
//using System.Data.SqlClient;
//using System.Data;
//using System.Threading;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText txtEmailPhoneLog;
        private EditText txtPassword;
        private TextView txtRegisterNow;
        private TextView btnSingIn;
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

            txtEmailPhoneLog.RequestFocus();

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

            if (txtEmailPhoneLog.Text == "" || txtPassword.Text == "")
            {
                return;
            }

            //create adminCRUD through Factory Method Pattern
            FactoryMethod_AdminsCRUD factoryAdminCRUD = new FactoryMethod_AdminsCRUD();
            ICRUD<Admin> adminCRUD = factoryAdminCRUD.CreateCRUD();

            //create customerCRUD through Factory Method Pattern
            FactoryMethod_CustomerCRUD factoryCustomerCRUD = new FactoryMethod_CustomerCRUD();
            ICRUD<Customer> customerCRUD = factoryCustomerCRUD.CreateCRUD();            
            try
            {
                Admin admin = adminCRUD.GetObject(txtEmailPhoneLog.Text);
                if (admin!= null && admin.Password == txtPassword.Text)
                {
                    var intent = new Intent(this, typeof(AdminDashBoardActivity));                    
                    StartActivity(intent);                   
                }
                else
                {
                    Customer cus = customerCRUD.GetObject(txtEmailPhoneLog.Text);
                    if (cus == null)
                    {
                        AlertDialogBuilder.BuildAlertDialog(this, Resources.GetString(Resource.String.wrongInput), Resources.GetString(Resource.String.incorrectUserNamePassword));
                        return;
                    }


                    if ((txtEmailPhoneLog.Text == cus.Email || txtEmailPhoneLog.Text == cus.Phone) && txtPassword.Text == cus.Password)
                    {
                        //pass Sign In customer and empty cart to Dashboard Activity after signin
                        //like in real world, users go in a store through gate with empty cart
                        Bundle bundle = new Bundle();
                        List<Tuple<Product, int>> cartList = new List<Tuple<Product, int>>();
                        bundle.PutString(Resources.GetString(Resource.String.customer), JsonConvert.SerializeObject(cus));
                        bundle.PutString(Resources.GetString(Resource.String.cartList), JsonConvert.SerializeObject(cartList));
                        var intent = new Intent(this, typeof(DashBoardActivity));
                        intent.PutExtras(bundle);
                        StartActivity(intent);
                    }
                    else
                    {
                        AlertDialogBuilder.BuildAlertDialog(this, Resources.GetString(Resource.String.wrongInput), Resources.GetString(Resource.String.incorrectUserNamePassword));
                    }
                }         
            }
            catch (Exception ex)
            {
                AlertDialogBuilder.BuildAlertDialog(this, Resources.GetString(Resource.String.error), ex.Message);
            }
        }

        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}