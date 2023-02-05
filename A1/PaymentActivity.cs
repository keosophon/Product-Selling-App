using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class PaymentActivity : AppCompatActivity
    {
        private Bundle bundle;
        private List<Tuple<Product, int>> cartList;
        private GridLayout itemGrid;
        private int currentRow = 0;
        private double discount = 0.0;
        private double discountPercentage;
        private TextView txtDiscountPrice;
        private TextView txtSubTotalValue;
        private double subTotalValue;
        private TextView txtCourierChargeNote;
        private List<DeliveryType> deliveryTypeList;
        private RadioButton rdCourier;
        private RadioButton rdPickUp;
        private TextView txtDeliveryChargeValue;
        private decimal courierCharge;
        private TextView txtTotalValue;
        private TextView txtLogOut;
        private TextView txtDashBoard;
        private Button btnCheckOut;
        private Customer customer;
        private List<int> discountIdList;
        private RadioButton rdCard;
        private List<PaymentMode> paymentModeList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_payment);

            //link variables to UI elements
            txtDiscountPrice = FindViewById<TextView>(Resource.Id.txtDiscountValue);
            txtSubTotalValue = FindViewById<TextView>(Resource.Id.txtSubTotalValue);
            txtCourierChargeNote = FindViewById<TextView>(Resource.Id.txtNote);
            rdCourier = FindViewById<RadioButton>(Resource.Id.rdCourier);
            rdPickUp = FindViewById<RadioButton>(Resource.Id.rdPickup);
            txtDeliveryChargeValue = FindViewById<TextView>(Resource.Id.txtDeliveryChargeValue);
            txtTotalValue = FindViewById<TextView>(Resource.Id.txtTotalValue);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            btnCheckOut = FindViewById<Button>(Resource.Id.btnCheckOut);
            rdCard = FindViewById<RadioButton>(Resource.Id.rdCard);
            

            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //get cartList from bundle
            cartList = JsonConvert.DeserializeObject<List<Tuple<Product, int>>>(bundle.GetString(Resources.GetString(Resource.String.cartList)));
            discountPercentage = bundle.GetDouble(Resources.GetString(Resource.String.discount));
            customer = JsonConvert.DeserializeObject<Customer>(bundle.GetString(Resources.GetString(Resource.String.customer)));
            discountIdList = JsonConvert.DeserializeObject<List<int>>(bundle.GetString(Resources.GetString(Resource.String.discountIdList)));


            //display items in cart in gridlayout
            itemGrid = FindViewById<GridLayout>(Resource.Id.itemGrid);
            itemGrid.RowCount = cartList.Count+1;
            foreach (Tuple<Product, int> item in cartList)
            {
                subTotalValue += Convert.ToDouble(item.Item1.Price) * Convert.ToDouble(item.Item2);                
                currentRow += 1;
                int currentColumn = 0;
                TextView itemDescription = new TextView(this);
                TextView quantiy = new TextView(this);
                TextView unitPrice = new TextView(this);
                TextView subTotal = new TextView(this);

                itemDescription.Text = item.Item1.Description;
                quantiy.Text = item.Item2.ToString();
                unitPrice.Text = item.Item1.Price.ToString();
                subTotal.Text = (item.Item2 * item.Item1.Price).ToString();

                
                GridLayout.LayoutParams param = new GridLayout.LayoutParams();
                param.RowSpec = GridLayout.InvokeSpec(currentRow);
                param.ColumnSpec = GridLayout.InvokeSpec(currentColumn);
                param.Width = GridLayout.LayoutParams.WrapContent;
                currentColumn = 1;
                itemDescription.SetWidth(500);
                itemDescription.LayoutParameters = param;                
                itemDescription.SetSingleLine(false);                
                itemDescription.SetLines(2);                
                                               
                itemGrid.AddView(itemDescription);

                GridLayout.LayoutParams param1 = new GridLayout.LayoutParams();
                param1.RowSpec = GridLayout.InvokeSpec(currentRow);
                param1.ColumnSpec = GridLayout.InvokeSpec(currentColumn);
                param1.SetGravity(GravityFlags.Center);
                currentColumn += 1;
                quantiy.LayoutParameters = param1;
                itemGrid.AddView(quantiy);

                GridLayout.LayoutParams param2 = new GridLayout.LayoutParams();
                param2.RowSpec = GridLayout.InvokeSpec(currentRow);
                param2.ColumnSpec = GridLayout.InvokeSpec(currentColumn);
                param2.SetGravity(GravityFlags.Center);
                currentColumn += 1;
                unitPrice.LayoutParameters = param2;
                itemGrid.AddView(unitPrice);

                GridLayout.LayoutParams param3 = new GridLayout.LayoutParams();
                param3.RowSpec = GridLayout.InvokeSpec(currentRow);
                param3.ColumnSpec = GridLayout.InvokeSpec(currentColumn);
                param3.SetGravity(GravityFlags.Center);
                currentColumn += 1;
                subTotal.LayoutParameters = param3;
                itemGrid.AddView(subTotal);                
            }

            txtSubTotalValue.Text = subTotalValue.ToString();
            discount += subTotalValue * discountPercentage;
            txtDiscountPrice.Text = Resources.GetString(Resource.String.minus) + Math.Round(discount,2).ToString();

            this.GetDeliveryTypeList();

            //setting courier charge
            //by default courier radio button is clicked
            txtDeliveryChargeValue.Text = "+" + courierCharge.ToString();
            rdCourier.Click += DeliveryType_Click;
            rdPickUp.Click += DeliveryType_Click;           

            //Total
            txtTotalValue.Text = this.calculateTotal().ToString();

            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                var intent = new Intent(this, typeof(DashBoardActivity));
                bundle.PutString(Resources.GetString(Resource.String.cartList), JsonConvert.SerializeObject(cartList));
                intent.PutExtras(bundle);
                StartActivity(intent);
            };

            btnCheckOut.Click += BtnCheckOut_Click;
        }

        public override void OnBackPressed()
        {
            //disable back button
        }

        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            //Add order to into OrderTable
            Order order = new Order();
            order.OrderPlaced = DateTime.Now;               
            order.CustomerId = customer.Id;
            for (int i = 0; i < deliveryTypeList.Count; i++)
            {
                if (rdCourier.Checked)
                {
                    if (deliveryTypeList[i].Mechanism.ToLower() == Resources.GetString(Resource.String.courier).ToLower())
                    {
                        order.DeliveryId = deliveryTypeList[i].Id;
                        //just assume that order through courier fullfilled in 3 days from now;
                        order.OrderFulfilled = DateTime.Now.AddDays(3);
                        break;
                    }
                }
                else
                {
                    if (deliveryTypeList[i].Mechanism.ToLower() != Resources.GetString(Resource.String.courier).ToLower())
                    {
                        order.DeliveryId = deliveryTypeList[i].Id;
                        //just assume that order through pickup fullfilled in 1 days from now;
                        order.OrderFulfilled = DateTime.Now.AddDays(1);
                        break;
                    }
                }
            }
            //create orderCRUD through Factory Method Pattern
            FactoryMethod_OrderCRUD factoryMethod_OrderCRUD = new FactoryMethod_OrderCRUD();
            ICRUD<Order> orderCRUD = factoryMethod_OrderCRUD.CreateCRUD();
            int generatedOrderId = orderCRUD.Add(order);            

            //Add payment to payments table
            Payment payment = new Payment();
            payment.PaymentDate = DateTime.Now;
            payment.OrderId = generatedOrderId;
            payment.Amount = Convert.ToDecimal(txtTotalValue.Text);

            //create paymentModeCRUD through Factory Method Pattern
            FactoryMethod_PaymentModeCRUD factoryMethod_PaymentModeCRUD = new FactoryMethod_PaymentModeCRUD();
            ICRUD<PaymentMode> paymentModeCRUD = factoryMethod_PaymentModeCRUD.CreateCRUD();
            paymentModeList = paymentModeCRUD.GetObjects();

            for (int i = 0; i < paymentModeList.Count; i++)
            {
                if (rdCard.Checked)
                {
                    if (paymentModeList[i].Name.ToLower() == Resources.GetString(Resource.String.card).ToLower())
                    {
                        payment.PaymentModeId = paymentModeList[i].Id;
                        break;
                    }
                }
                else
                {
                    if (paymentModeList[i].Name.ToLower() != Resources.GetString(Resource.String.card).ToLower())
                    {
                        payment.PaymentModeId = paymentModeList[i].Id;
                        break;
                    }
                }
            }

            //create paymentCRUD through Factory Method Pattern
            FactoryMethod_PaymentCRUD factoryMethod_PaymentCRUD = new FactoryMethod_PaymentCRUD();
            ICRUD<Payment> paymentCRUD = factoryMethod_PaymentCRUD.CreateCRUD();
            paymentCRUD.Add(payment);


            //create orderDiscountCRUD through Factory Method Pattern
            FactoryMethod_OrderDiscountCRUD factoryMethod_OrderDiscountCRUD = new FactoryMethod_OrderDiscountCRUD();
            ICRUD<OrderDiscount> orderDiscountCRUD = factoryMethod_OrderDiscountCRUD.CreateCRUD();

            //add OrderDiscount into OrderDiscount table            
            for (int i=0; i < discountIdList.Count; i++)
            {
                OrderDiscount orderDiscount = new OrderDiscount();
                orderDiscount.OrderId = generatedOrderId;
                orderDiscount.DiscountId = discountIdList[i];
                orderDiscountCRUD.Add(orderDiscount);
            }

            //create orderDetailCRUD through Factory Method Pattern
            FactoryMethod_OrderDetailsCRUD factoryMethod_OrderDetailsCRUD = new FactoryMethod_OrderDetailsCRUD();
            ICRUD<OrderDetail> orderDetailCRUD = factoryMethod_OrderDetailsCRUD.CreateCRUD();

            //add order detail into OrderDetail table
            foreach(Tuple<Product,int> item in cartList)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.Quantity = item.Item2;
                orderDetail.OrderId = generatedOrderId;
                orderDetail.ProductId = item.Item1.Id;
                orderDetailCRUD.Add(orderDetail);
            }           

            
            cartList.Clear(); //reset carList
            AlertDialogBuilder.BuildAlertDialog(this, Resources.GetString(Resource.String.success), Resources.GetString(Resource.String.orderSuccess));

        }

        private double calculateTotal()
        {
            if (rdCourier.Checked){
                return Math.Round(subTotalValue - discount + Convert.ToDouble(courierCharge), 2);
            }
            else
            {
                return Math.Round(subTotalValue - discount, 2);
            }
            
        }
        private void DeliveryType_Click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Text == Resources.GetString(Resource.String.courier))
            {
                txtDeliveryChargeValue.Text = "+" + courierCharge.ToString();
            }
            else
            {
                txtDeliveryChargeValue.Text = "0";
            }
            txtTotalValue.Text = this.calculateTotal().ToString();
        }

        public void GetDeliveryTypeList()
        {

            // create deliveryTypeCRUD through Factory Method Pattern
            FactoryMethod_DeliveryTypeCRUD factoryMethod_DeliveryTypeCRUD = new FactoryMethod_DeliveryTypeCRUD();
            ICRUD<DeliveryType> deliveryTypeCRUD = factoryMethod_DeliveryTypeCRUD.CreateCRUD();

            try
            {
                deliveryTypeList = deliveryTypeCRUD.GetObjects();
                for (int i = 0; i < deliveryTypeList.Count; i++)
                {
                    if (deliveryTypeList[i].Mechanism.ToLower() == Resources.GetString(Resource.String.courier).ToLower())
                    {
                        courierCharge = deliveryTypeList[i].ExtraCharge;
                        txtCourierChargeNote.Text += " " + Resources.GetString(Resource.String.dollarSign) + deliveryTypeList[i].ExtraCharge + Resources.GetString(Resource.String.nzd);
                    }
                }
            }
            catch (Exception ex)
            {
                AlertDialogBuilder.BuildAlertDialog(this, Resources.GetString(Resource.String.error), ex.Message);
            }
        }

    }
}