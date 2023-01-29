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
using Newtonsoft.Json;

namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]

    public class AddToCartActivity : AppCompatActivity
    {
        private TextView txtDashBoard;
        private TextView txtLogOut;

        private Spinner spQuantity;
        private CheckBox cbSenior;
        private CheckBox cbWeekends;
        private CheckBox cbCities;
        private ImageButton imgProduct;
        private TextView txtDescription;
        private TextView txtPrice;
        private Product product;
        private Customer customer;
        private Bundle bundle;
        private List<Discount> discountList;
        private Button btnAddToCart;
        private List<Tuple<Product, int>> cartList;
        private Button btnViewCart1;
        private TextView txtItemsInCart;
        private int quantity;
        private decimal discount= 0;
        private List<int> discountIdList = new List<int>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_addToCart);

            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            txtItemsInCart = FindViewById<TextView>(Resource.Id.txtItemsInCart);

            spQuantity = FindViewById<Spinner>(Resource.Id.spQuantity);
            cbSenior = FindViewById<CheckBox>(Resource.Id.cbSenior);
            cbWeekends = FindViewById<CheckBox>(Resource.Id.cbWeekends);
            cbCities = FindViewById<CheckBox>(Resource.Id.cbCities);
            imgProduct = FindViewById<ImageButton>(Resource.Id.imgbtnProductSmall);
            txtDescription = FindViewById<TextView>(Resource.Id.txtProductDescCart);
            txtPrice = FindViewById<TextView>(Resource.Id.txtProductPrice);
            btnAddToCart = FindViewById<Button>(Resource.Id.btnAddToCart);
            btnViewCart1 = FindViewById<Button>(Resource.Id.btnViewCart1);

            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //display info of the product that has been cliked in Dashboard
            product = JsonConvert.DeserializeObject<Product>(bundle.GetString(Resources.GetString(Resource.String.product)));
            customer = JsonConvert.DeserializeObject<Customer>(bundle.GetString(Resources.GetString(Resource.String.customer)));
            var bitmapImg = BitMapImageCreator.CreateBitMapFromName(Resources, product.ImageSmall);
            imgProduct.SetImageBitmap(bitmapImg);
            txtPrice.Text = Resources.GetString(Resource.String.dollarSign) + product.Price.ToString() + " " + Resources.GetString(Resource.String.nzd);
            txtDescription.Text = product.Description;

            //get cartList from bundle
            cartList = JsonConvert.DeserializeObject<List<Tuple<Product, int>>>(bundle.GetString(Resources.GetString(Resource.String.cartList)));
            txtItemsInCart.Text = Resources.GetString(Resource.String.itemsInCart) + " " + cartList.Count.ToString();

            //set values for spinner
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.quantity, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spQuantity.Adapter = adapter;

            //set quantity to seletected item in spinner
            spQuantity.ItemSelected += SpQuantity_ItemSelected;


            cbSenior.Checked = false;
            cbWeekends.Checked = false;
            cbCities.Checked = false;

            //calculate customer age
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime date = DateTime.Now;

            TimeSpan span = date - customer.DoB;
            int years = (zeroTime + span).Year-1;
            int months = (zeroTime + span).Month - 1;
            int days = (zeroTime + span).Day - 1;

            int yearMonthDay = Convert.ToInt32(years.ToString() + months.ToString() + days.ToString());

            if (years>=60 && yearMonthDay > 6000)
            {
                cbSenior.Checked = true;
            }

            //find DayOfWeek of Today
            DayOfWeek day = DateTime.Now.DayOfWeek;

            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                cbWeekends.Checked = true;
            }

            //find the city of customer
            string wellington = Resources.GetString(Resource.String.wellington);
            string auckland = Resources.GetString(Resource.String.auckland);
            string address = customer.Address.ToLower();

            if (address.Contains(wellington) || address.Contains(auckland))
            {
                cbCities.Checked = true;
            }

            
            //customer can see but cannot change
            cbSenior.Enabled = false;
            cbWeekends.Enabled = false;
            cbCities.Enabled = false;
                       
            try
            {
                
            //add discount percentages to checkboxes UI
            //create discountCRUD through Factory Design Pattern
            ICRUD<Discount> discountCRUD = CRUDFactory.CreateCRUD<Discount>();
            discountList = discountCRUD.GetObjects();            
            for (int i = 0; i < discountList.Count; i++)
            {

                string senior = Resources.GetString(Resource.String.senior).ToLower();
                string weekends = Resources.GetString(Resource.String.weekends).ToLower();                
                string openParentheses = Resources.GetString(Resource.String.openParentheses);
                string closeParenthese = Resources.GetString(Resource.String.closeParentheses);
                string percentageSign = Resources.GetString(Resource.String.percentageSign);                

                if (discountList[i].Description.ToLower().Contains(senior))
                {
                    cbSenior.Text = cbSenior.Text + openParentheses + Convert.ToInt32((discountList[i].Percentage * 100)).ToString() + percentageSign + closeParenthese;   
                    if (cbSenior.Checked == true)
                    {
                            discount += discountList[i].Percentage;
                            discountIdList.Add(discountList[i].Id);
                    }
                
                }
                else if (discountList[i].Description.ToLower().Contains(weekends))
                {
                    cbWeekends.Text = cbWeekends.Text + openParentheses + Convert.ToInt32((discountList[i].Percentage * 100)).ToString() + percentageSign + closeParenthese;

                    if (cbWeekends.Checked == true)
                    {
                        discount += discountList[i].Percentage;
                        discountIdList.Add(discountList[i].Id);
                    }
                }
                else
                {
                    cbCities.Text = cbCities.Text + openParentheses + Convert.ToInt32((discountList[i].Percentage * 100)).ToString() + percentageSign + closeParenthese;
                    if (cbCities.Checked == true)
                    {
                            discount += discountList[i].Percentage;
                            discountIdList.Add(discountList[i].Id);
                    }
                }

            }
            }
            catch (Exception ex)
            {
                AlertDialogBuilder.BuildAlertDialog(this, Resources.GetString(Resource.String.error), ex.Message);
            }
           
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
            btnAddToCart.Click += BtnAddToCart_Click;
            btnViewCart1.Click += BtnViewCart1_Click;
        }

        //set quantity value
        private void SpQuantity_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            quantity = Convert.ToInt32(spinner.GetItemAtPosition(e.Position).ToString());
        }

        private void BtnViewCart1_Click(object sender, EventArgs e)
        {
            AlertDialogBuilder.BuildAlertDialog(this, "discount", discount.ToString());
            var intent = new Intent(this, typeof(PaymentActivity));
            bundle.PutString(Resources.GetString(Resource.String.cartList), JsonConvert.SerializeObject(cartList));
            bundle.PutString(Resources.GetString(Resource.String.discountIdList), JsonConvert.SerializeObject(discountIdList));
            bundle.PutDouble(Resources.GetString(Resource.String.discount), Convert.ToDouble(discount));
            intent.PutExtras(bundle);
            StartActivity(intent);
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {            
            
            cartList.Add(new Tuple<Product, int>(product, quantity));
            txtItemsInCart.Text = Resources.GetString(Resource.String.itemsInCart) + " " + cartList.Count.ToString();
        }
    }
}