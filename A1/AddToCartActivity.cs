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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_addToCart);

            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);

            spQuantity = FindViewById<Spinner>(Resource.Id.spQuantity);
            cbSenior = FindViewById<CheckBox>(Resource.Id.cbSenior);
            cbWeekends = FindViewById<CheckBox>(Resource.Id.cbWeekends);
            cbCities = FindViewById<CheckBox>(Resource.Id.cbCities);
            imgProduct = FindViewById<ImageButton>(Resource.Id.imgbtnProductSmall);
            txtDescription = FindViewById<TextView>(Resource.Id.txtProductDescCart);
            txtPrice = FindViewById<TextView>(Resource.Id.txtProductPrice);

            //Creating bundle containing Sing In customer and product
            bundle = Intent.Extras;

            //display info of the product that has been cliked in Dashboard
            product = JsonConvert.DeserializeObject<Product>(bundle.GetString("product"));
            customer = JsonConvert.DeserializeObject<Customer>(bundle.GetString("customer"));
            var bitmapImg = BitMapImageCreator.CreateBitMapFromName(Resources, product.ImageSmall);
            imgProduct.SetImageBitmap(bitmapImg);
            txtPrice.Text = Resources.GetString(Resource.String.dollarSign) + product.Price.ToString() + " " + Resources.GetString(Resource.String.nzd);
            txtDescription.Text = product.Description;

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.quantity, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spQuantity.Adapter = adapter;

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
                    
                }
                else if (discountList[i].Description.ToLower().Contains(weekends))
                {
                    cbWeekends.Text = cbWeekends.Text + openParentheses + (discountList[i].Percentage * 100).ToString() + percentageSign + closeParenthese;
                }
                else
                {
                    cbCities.Text = cbCities.Text + openParentheses + (discountList[i].Percentage * 100).ToString() + percentageSign + closeParenthese;
                }

            }
            }
            catch (Exception ex)
            {
                AlertDialogBuilder.BuildAlertDialog(this, "connection error", ex.Message);
            }
           
            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                if (product != null)
                {
                    bundle.Remove("product");
                }
                var intent = new Intent(this, typeof(DashBoardActivity));
                intent.PutExtras(bundle);
                StartActivity(intent);
            };
        }

        
    }
}