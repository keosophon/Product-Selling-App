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


            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //get cartList from bundle
            cartList = JsonConvert.DeserializeObject<List<Tuple<Product, int>>>(bundle.GetString(Resources.GetString(Resource.String.cartList)));
            discountPercentage = bundle.GetDouble(Resources.GetString(Resource.String.discount));


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

            // create deliveryTypeCRUD through Factory Design Pattern
            ICRUD<DeliveryType> deliveryTypeCRUD = CRUDFactory.CreateCRUD<DeliveryType>();

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