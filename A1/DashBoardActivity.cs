using Android.App;
using Android.Content;
using Android.OS;
//using Android.Runtime;
//using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using AndroidX.AppCompat.App;
//using System.Net;
//using Android.Graphics;
using Newtonsoft.Json;


namespace A1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class DashBoardActivity : AppCompatActivity
    {
        private Bundle bundle;
        private TextView txtDashBoard;
        private TextView txtLogOut;

        private ImageButton imgBtnProduct1;
        private ImageButton imgBtnProduct2;
        private ImageButton imgBtnProduct3;
        private ImageButton imgBtnProduct4;
        private ImageButton imgBtnProduct5;
        private ImageButton imgBtnProduct6;
        private ImageButton imgBtnProduct7;
        private ImageButton imgBtnProduct8;
        private ImageButton imgBtnProduct9;
        private ImageButton imgBtnProduct10;

        private TextView txtProductName1;
        private TextView txtProductName2;
        private TextView txtProductName3;
        private TextView txtProductName4;
        private TextView txtProductName5;
        private TextView txtProductName6;
        private TextView txtProductName7;
        private TextView txtProductName8;
        private TextView txtProductName9;
        private TextView txtProductName10;

        private TextView txtProductPrice1;
        private TextView txtProductPrice2;
        private TextView txtProductPrice3;
        private TextView txtProductPrice4;
        private TextView txtProductPrice5;
        private TextView txtProductPrice6;
        private TextView txtProductPrice7;
        private TextView txtProductPrice8;
        private TextView txtProductPrice9;
        private TextView txtProductPrice10;

        private Button btnSeeDetails1;
        private Button btnSeeDetails2;
        private Button btnSeeDetails3;
        private Button btnSeeDetails4;
        private Button btnSeeDetails5;
        private Button btnSeeDetails6;
        private Button btnSeeDetails7;
        private Button btnSeeDetails8;
        private Button btnSeeDetails9;
        private Button btnSeeDetails10;

        private List<ImageButton> imageButtonList = new List<ImageButton>();
        private List<TextView> nameViewList = new List<TextView>();
        private List<TextView> priceViewList = new List<TextView>();
        private List<Button> btnSeeDetailsList = new List<Button>();
        private List<Product> productList;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_dashBoard);

            //Creating bundle which contains Sing In customer         
            bundle = Intent.Extras;            

            //link variables to UI elements
            txtDashBoard = FindViewById<TextView>(Resource.Id.txtDashBoard);
            txtLogOut = FindViewById<TextView>(Resource.Id.txtLogOut);

            imgBtnProduct1 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct1);
            imgBtnProduct1.Click += this.SeeDetails1_Click;
            imgBtnProduct2 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct2);
            imgBtnProduct2.Click += this.SeeDetails2_Click;
            imgBtnProduct3 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct3);
            imgBtnProduct3.Click += this.SeeDetails3_Click;
            imgBtnProduct4 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct4);
            imgBtnProduct4.Click += this.SeeDetails4_Click;
            imgBtnProduct5 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct5);
            imgBtnProduct5.Click += this.SeeDetails5_Click;
            imgBtnProduct6 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct6);
            imgBtnProduct6.Click += this.SeeDetails6_Click;
            imgBtnProduct7 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct7);
            imgBtnProduct7.Click += this.SeeDetails7_Click;
            imgBtnProduct8 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct8);
            imgBtnProduct8.Click += this.SeeDetails8_Click;
            imgBtnProduct9 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct9);
            imgBtnProduct9.Click += this.SeeDetails9_Click;
            imgBtnProduct10 = FindViewById<ImageButton>(Resource.Id.imgbtnProduct10);
            imgBtnProduct10.Click += this.SeeDetails10_Click;

            txtProductName1 = FindViewById<TextView>(Resource.Id.txtProductName1);
            txtProductName2 = FindViewById<TextView>(Resource.Id.txtProductName2);
            txtProductName3 = FindViewById<TextView>(Resource.Id.txtProductName3);
            txtProductName4 = FindViewById<TextView>(Resource.Id.txtProductName4);
            txtProductName5 = FindViewById<TextView>(Resource.Id.txtProductName5);
            txtProductName6 = FindViewById<TextView>(Resource.Id.txtProductName6);
            txtProductName7 = FindViewById<TextView>(Resource.Id.txtProductName7);
            txtProductName8 = FindViewById<TextView>(Resource.Id.txtProductName8);
            txtProductName9 = FindViewById<TextView>(Resource.Id.txtProductName9);
            txtProductName10 = FindViewById<TextView>(Resource.Id.txtProductName10);

            txtProductPrice1 = FindViewById<TextView>(Resource.Id.txtProductPrice1);
            txtProductPrice2 = FindViewById<TextView>(Resource.Id.txtProductPrice2);
            txtProductPrice3 = FindViewById<TextView>(Resource.Id.txtProductPrice3);
            txtProductPrice4 = FindViewById<TextView>(Resource.Id.txtProductPrice4);
            txtProductPrice5 = FindViewById<TextView>(Resource.Id.txtProductPrice5);
            txtProductPrice6 = FindViewById<TextView>(Resource.Id.txtProductPrice6);
            txtProductPrice7 = FindViewById<TextView>(Resource.Id.txtProductPrice7);
            txtProductPrice8 = FindViewById<TextView>(Resource.Id.txtProductPrice8);
            txtProductPrice9 = FindViewById<TextView>(Resource.Id.txtProductPrice9);
            txtProductPrice10 = FindViewById<TextView>(Resource.Id.txtProductPrice10);
            
            btnSeeDetails1 = FindViewById<Button>(Resource.Id.btnDetail1);
            btnSeeDetails1.Click += this.SeeDetails1_Click;
            btnSeeDetails2 = FindViewById<Button>(Resource.Id.btnDetail2);
            btnSeeDetails2.Click += this.SeeDetails2_Click;
            btnSeeDetails3 = FindViewById<Button>(Resource.Id.btnDetail3);
            btnSeeDetails3.Click += this.SeeDetails3_Click;
            btnSeeDetails4 = FindViewById<Button>(Resource.Id.btnDetail4);
            btnSeeDetails4.Click += this.SeeDetails4_Click;
            btnSeeDetails5 = FindViewById<Button>(Resource.Id.btnDetail5);
            btnSeeDetails5.Click += this.SeeDetails5_Click;
            btnSeeDetails6 = FindViewById<Button>(Resource.Id.btnDetail6);
            btnSeeDetails6.Click += this.SeeDetails6_Click;
            btnSeeDetails7 = FindViewById<Button>(Resource.Id.btnDetail7);
            btnSeeDetails7.Click += this.SeeDetails7_Click;
            btnSeeDetails8 = FindViewById<Button>(Resource.Id.btnDetail8);
            btnSeeDetails8.Click += this.SeeDetails8_Click;
            btnSeeDetails9 = FindViewById<Button>(Resource.Id.btnDetail9);
            btnSeeDetails9.Click += this.SeeDetails9_Click;
            btnSeeDetails10 = FindViewById<Button>(Resource.Id.btnDetail10);
            btnSeeDetails10.Click += this.SeeDetails10_Click;


            imageButtonList.Add(imgBtnProduct1);
            imageButtonList.Add(imgBtnProduct2);
            imageButtonList.Add(imgBtnProduct3);
            imageButtonList.Add(imgBtnProduct4);
            imageButtonList.Add(imgBtnProduct5);
            imageButtonList.Add(imgBtnProduct6);
            imageButtonList.Add(imgBtnProduct7);
            imageButtonList.Add(imgBtnProduct8);
            imageButtonList.Add(imgBtnProduct9);
            imageButtonList.Add(imgBtnProduct10);

            nameViewList.Add(txtProductName1);
            nameViewList.Add(txtProductName2);
            nameViewList.Add(txtProductName3);
            nameViewList.Add(txtProductName4);
            nameViewList.Add(txtProductName5);
            nameViewList.Add(txtProductName6);
            nameViewList.Add(txtProductName7);
            nameViewList.Add(txtProductName8);
            nameViewList.Add(txtProductName9);
            nameViewList.Add(txtProductName10);


            priceViewList.Add(txtProductPrice1);
            priceViewList.Add(txtProductPrice2);
            priceViewList.Add(txtProductPrice3);
            priceViewList.Add(txtProductPrice4);
            priceViewList.Add(txtProductPrice5);
            priceViewList.Add(txtProductPrice6);
            priceViewList.Add(txtProductPrice7);
            priceViewList.Add(txtProductPrice8);
            priceViewList.Add(txtProductPrice9);
            priceViewList.Add(txtProductPrice10);

            btnSeeDetailsList.Add(btnSeeDetails1);
            btnSeeDetailsList.Add(btnSeeDetails2);
            btnSeeDetailsList.Add(btnSeeDetails3);
            btnSeeDetailsList.Add(btnSeeDetails4);
            btnSeeDetailsList.Add(btnSeeDetails5);
            btnSeeDetailsList.Add(btnSeeDetails6);
            btnSeeDetailsList.Add(btnSeeDetails7);
            btnSeeDetailsList.Add(btnSeeDetails8);
            btnSeeDetailsList.Add(btnSeeDetails9);
            btnSeeDetailsList.Add(btnSeeDetails10);

            

            txtLogOut.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            txtDashBoard.Click += delegate
            {
                var intent = new Intent(this, typeof(DashBoardActivity));
                intent.PutExtras(bundle);
                StartActivity(intent);
            };

            

            this.DisplayAllProducts();            

        }

        
        public override void OnBackPressed()
        {
            //disable back button
        }

        public void DisplayAllProducts()
        {

            //create productCRUD through Factory Method Design Pattern
            FactoryMethod_ProductCRUD factoryMethod_ProductCRUD = new FactoryMethod_ProductCRUD();
            ICRUD<Product> productCRUD = factoryMethod_ProductCRUD.CreateCRUD();

            try
            {
                productList = productCRUD.GetObjects();
                for (int i = 0; i < productList.Count; i++)
                {   
                    if (i== imageButtonList.Count)
                    {
                        
                        break;
                    }

                    try
                    {
                        var bitmapImg = BitMapImageCreator.CreateBitMapFromName(Resources, productList[i].ImageSmall);
                        imageButtonList[i].SetImageBitmap(bitmapImg);
                        imageButtonList[i].SetScaleType(ImageButton.ScaleType.FitXy);
                    }
                    catch(Exception)
                    {
                        try
                        {
                            imageButtonList[i].SetImageBitmap(BitMapImageCreator.FetchImage(productList[i].ImageSmall));
                            imageButtonList[i].SetScaleType(ImageButton.ScaleType.FitXy);
                        }
                        catch (Exception)
                        {
                            imageButtonList[i].ContentDescription = productList[i].Name;
                        }
                        
                    }
                                        
                    nameViewList[i].Text = productList[i].Name;
                    priceViewList[i].Text = Resources.GetString(Resource.String.dollarSign) + productList[i].Price.ToString() + " " + Resources.GetString(Resource.String.nzd);
                }
                
                for (int i= 0; i < imageButtonList.Count; i++)
                {
                    if (nameViewList[i].Text == Resources.GetString(Resource.String.productName))
                    {
                        imageButtonList[i].Visibility = Android.Views.ViewStates.Invisible;
                        nameViewList[i].Visibility = Android.Views.ViewStates.Invisible;
                        priceViewList[i].Visibility = Android.Views.ViewStates.Invisible;
                        btnSeeDetailsList[i].Visibility = Android.Views.ViewStates.Invisible;
                        
                    }                    
                }
                
            }
            catch (Exception ex)
            {
                AlertDialogBuilder.BuildAlertDialog(this, Resources.GetString(Resource.String.error), ex.Message);
            }
        }

        private void SeeDetails1_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[0]);
        }

        private void SeeDetails2_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[1]);
        }

        private void SeeDetails3_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[2]);
        }

        private void SeeDetails4_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[3]);
        }

        private void SeeDetails5_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[4]);
        }

        private void SeeDetails6_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[5]);
        }

        private void SeeDetails7_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[6]);
        }

        private void SeeDetails8_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[7]);
        }

        private void SeeDetails9_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[8]);
        }

        private void SeeDetails10_Click(object sender, EventArgs e)
        {
            this.OpenProductViewPage(productList[9]);
        }

        private void OpenProductViewPage(Product product)
        {
            //pass Sing In customer, empyt cartList and product to Product View Activity to see product details
            //like in real world, users grab a product from shelves, need to see its details before putting into the cart.
            bundle.PutString(Resources.GetString(Resource.String.product), JsonConvert.SerializeObject(product));
            var intent = new Intent(this, typeof(ProductViewActivity));
            intent.PutExtras(bundle);
            StartActivity(intent);
        }

        public void BuildAlertDialog(string title, string message)
        {
            AlertDialogBuilder.BuildAlertDialog(this, title, message);
        }

        
    }
}