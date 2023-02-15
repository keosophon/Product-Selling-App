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
        private RadioButton rdPaid;
        private RadioButton rdUnpaid;

        private Button btnSearch;
        private Button btnClearForm;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnLogOut;
        
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

            btnSearch = view.FindViewById<Button>(Resource.Id.btnOrderSearchPaymentAmdin);
            btnClearForm = view.FindViewById<Button>(Resource.Id.btnClearFormPaymentAdmin);
            btnDelete = view.FindViewById<Button>(Resource.Id.btnDeleterOrderPaymentAdmin);
            btnUpdate = view.FindViewById<Button>(Resource.Id.btnUpdateOrderPaymentAdmin);
            btnLogOut = view.FindViewById<Button>(Resource.Id.btnLogOutPaymentAdmin);

            btnSearch.Click += BtnSearch_Click;
            btnClearForm.Click += BtnClearForm_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnLogOut.Click += BtnLogOut_Click;                  


            rdPaid.Click += PaymentStatusButton_Click;
            rdUnpaid.Click += PaymentStatusButton_Click;

            return view;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (payment != null)
            {
                try
                {
                    FactoryMethod_PaymentCRUD factoryMethod_PaymentCRUD = new FactoryMethod_PaymentCRUD();
                    ICRUD<Payment> paymentCRUD = factoryMethod_PaymentCRUD.CreateCRUD();
                    if (paymentCRUD.UpdateObject(payment) == 1)
                    {
                        AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.success), Resources.GetString(Resource.String.success));
                        txtOrderSearch.Text = "";
                        txtOrderDate.Text = "";
                        txtCustomerName.Text = "";
                        txtOrderPayment.Text = "";                        
                        txtOrderSearch.RequestFocus();
                    }
                    payment = null;

                }
                catch (Exception ex)
                {
                    AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.error), ex.Message);
                }
                
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtOrderSearch.Text != "")
            {
                //create productCRUD through Factory Method Design Pattern
                FactoryMethod_OrderCRUD factoryMethod_OrderCRUD = new FactoryMethod_OrderCRUD();
                ICRUD<Order> orderCRUD = factoryMethod_OrderCRUD.CreateCRUD();
                try
                {
                    //deleting order will deleting payment because of cascade constraint in SQL server
                    if (orderCRUD.DeleteObject(Convert.ToInt32(txtOrderSearch.Text)) == 1)
                    {
                        AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.success), Resources.GetString(Resource.String.success));
                        txtOrderSearch.Text = "";
                        txtCustomerName.Text = "";
                        txtOrderDate.Text = "";
                        txtOrderPayment.Text = "";
                        rdPaid.Checked = false;
                        rdPaid.Checked = false;
                        txtOrderSearch.RequestFocus();
                    }
                    else
                    {
                        AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.wrongInput), Resources.GetString(Resource.String.idNotFound));
                    }
                    
                }
                catch (Exception ex)
                {
                    AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.error), ex.Message);
                }
            }
        }

        private void PaymentStatusButton_Click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Text == Resources.GetString(Resource.String.paid)){
                if (payment!=null)
                {
                    payment.Status = true;
                }
                
            }            
            else
            {
                if (payment!=null)
                {
                    payment.Status = false;
                }
                
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
            rdPaid.Checked = false;
            rdPaid.Checked = false;
            
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Activity, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}