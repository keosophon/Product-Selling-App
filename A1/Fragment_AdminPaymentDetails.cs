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
        private TextView txtOrderDate;
        private TextView txtCustomerName;                
        private TextView txtOrderPayment;
        private Button btnSearch;
        private Button btnClearForm;
        private Button btnLogOut;
        private RadioButton rdPaid;
        private RadioButton rdUnpaid;
        private Payment payment;

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
            txtOrderPayment = view.FindViewById<TextView>(Resource.Id.txtOrderPaymentAdmin);
            rdPaid = view.FindViewById<RadioButton>(Resource.Id.rdpaid);
            rdUnpaid = view.FindViewById<RadioButton>(Resource.Id.rdunpaid);

            btnLogOut = view.FindViewById<Button>(Resource.Id.btnLogOutPaymentAdmin);
            btnClearForm = view.FindViewById<Button>(Resource.Id.btnClearFormPaymentAdmin);
            btnSearch = view.FindViewById<Button>(Resource.Id.btnOrderSearchPaymentAmdin);

            btnLogOut.Click += BtnLogOut_Click;
            btnClearForm.Click += BtnClearForm_Click;
            btnSearch.Click += BtnSearch_Click;


            rdPaid.Click += PaymentStatusButton_Click;
            rdUnpaid.Click += PaymentStatusButton_Click;

            return view;
        }

        private void PaymentStatusButton_Click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Text == Resources.GetString(Resource.String.paid)){
                payment.Status = true;   
            }            
            else
            {
                payment.Status = false;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            if (txtOrderSearch.Text != "")
            {
                //create orderCRUD through Factory Method Design Pattern
                FactoryMethod_OrderCRUD factoryMethod_OrderCRUD = new FactoryMethod_OrderCRUD();
                ICRUD<Order> orderCRUD = factoryMethod_OrderCRUD.CreateCRUD();
                Order order = orderCRUD.GetObject(Convert.ToInt32(txtOrderSearch.Text));
                if (order != null)
                {

                    txtOrderDate.Text = order.OrderPlaced.ToString();

                    //create customerCRUD through Factory Method Design Pattern
                    FactoryMethod_CustomerCRUD factoryMethod_CustomerCRUD = new FactoryMethod_CustomerCRUD();
                    ICRUD<Customer> customerCRUD = factoryMethod_CustomerCRUD.CreateCRUD();
                    Customer customer = customerCRUD.GetObject(order.CustomerId);
                    txtCustomerName.Text = customer.FirstName + " " + customer.LastName;

                    //create paymentCRUD through Factory Method Design Pattern
                    FactoryMethod_PaymentCRUD factoryMethod_PaymentCRUD = new FactoryMethod_PaymentCRUD();
                    ICRUD<Payment> paymentCRUD = factoryMethod_PaymentCRUD.CreateCRUD();
                    payment = paymentCRUD.GetObject(order.Id);
                    txtOrderPayment.Text = payment.Amount.ToString();

                    if (payment.Status)
                    {
                        rdPaid.Checked = true;
                    }
                    else
                    {
                        rdUnpaid.Checked = true;
                    }
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
            
            
        }

        private void BtnClearForm_Click(object sender, EventArgs e)
        {
            txtOrderSearch.Text = "";
            txtCustomerName.Text = "";
            txtOrderDate.Text = "";
            txtOrderPayment.Text = "";
            
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Activity, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}