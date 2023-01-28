using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class PaymentActivity : Activity
    {
        private Bundle bundle;
        private List<Tuple<Product, int>> cartList;
        private GridLayout itemGrid;
        private int currentRow = 0;
        private double discount = 0.0;
        private double discountPercentage;
        private TextView txtDiscountPrice;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_payment);

            txtDiscountPrice = FindViewById<TextView>(Resource.Id.txtDiscountValue);


            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //get cartList from bundle
            cartList = JsonConvert.DeserializeObject<List<Tuple<Product, int>>>(bundle.GetString(Resources.GetString(Resource.String.cartList)));
            discountPercentage = bundle.GetDouble(Resources.GetString(Resource.String.discount));

            itemGrid = FindViewById<GridLayout>(Resource.Id.itemGrid);
            itemGrid.RowCount = cartList.Count*2+1;

            foreach (Tuple<Product, int> item in cartList)
            {
                discount += Convert.ToDouble(item.Item1.Price) * Convert.ToDouble(item.Item2) *discountPercentage;
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

            txtDiscountPrice.Text = Math.Round(discount,2).ToString();

        }

        
    }
}