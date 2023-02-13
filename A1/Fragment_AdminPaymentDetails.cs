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
        private TextView txtOrderSearch;
        private TextView txtCustomerName;
        private TextView txtOrderDate;
        private TextView txtOrderDiscount;
        private TextView txtOrderPayment;
        private Button btnSearch;
        private Button btnClearForm;
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

            txtOrderSearch = view.FindViewById<TextView>(Resource.Id.txtOrderSearchPaymentAdmin);
            txtCustomerName = view.FindViewById<TextView>(Resource.Id.txtCustomerNameAdmin);
            txtOrderDate = view.FindViewById<TextView>(Resource.Id.txtOrderDatePaymentAdmin);
            txtOrderDiscount = view.FindViewById<TextView>(Resource.Id.txtOrderDiscountPaymentAdmin);
            txtOrderPayment = view.FindViewById<TextView>(Resource.Id.txtOrderPaymentAdmin);
            btnLogOut = view.FindViewById<Button>(Resource.Id.btnLogOutPaymentAdmin);
            btnClearForm = view.FindViewById<Button>(Resource.Id.btnClearFormPaymentAdmin);
            btnSearch = view.FindViewById<Button>(Resource.Id.btnOrderSearchPaymentAmdin);

            btnLogOut.Click += BtnLogOut_Click;
            btnClearForm.Click += BtnClearForm_Click;
            btnSearch.Click += BtnSearch_Click;
           

            return view;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            /*
            if (txtOrderSearch.Text != "")
            {
                //create orderCRUD through Factory Method Design Pattern
                FactoryMethod_OrderCRUD factoryMethod_OrderCRUD = new FactoryMethod_OrderCRUD();
                ICRUD<Order> orderCRUD = factoryMethod_OrderCRUD.CreateCRUD();
                Order order = orderCRUD.GetObject(Convert.ToInt32(txtOrderSearch.Text));
                if (order != null)
                {

                    txtProductNameAdmin.Text = product.Name;
                    txtProductPriceAdmin.Text = product.Price.ToString();
                    txtProductStockAdmin.Text = product.Stock.ToString();
                    txtProductDescriptionAdmin.Text = product.Description;
                    txtProductImageSmallUrl.Text = product.ImageSmall;
                    txtProductImageBigUrl.Text = product.ImageBig;
                }
                else
                {
                    AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.wrongInput), Resources.GetString(Resource.String.idNotFound));
                }
            }
            else
            {
                AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.wrongInput), Resources.GetString(Resource.String.noInputId));
            }
            */
        }

        private void BtnClearForm_Click(object sender, EventArgs e)
        {
            txtOrderSearch.Text = "";
            txtCustomerName.Text = "";
            txtOrderDate.Text = "";
            txtOrderDiscount.Text = "";
            txtOrderPayment.Text = "";
            
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Activity, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}