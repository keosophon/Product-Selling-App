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

namespace A1
{
    
    public class Fragment_AdminProductDetails : AndroidX.Fragment.App.Fragment
    {
        private TextView txtProductIdAdmin;
        private TextView txtProductNameAdmin;
        private TextView txtProductPriceAdmin;
        private TextView txtProductStockAdmin;
        private TextView txtProductDescriptionAdmin;
        private TextView txtProductImageSmallUrl;
        private TextView txtProductImageBigUrl;
        private Button btnAdd;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_ProductDetails, container, false);
            txtProductNameAdmin = view.FindViewById<TextView>(Resource.Id.txtProductNameAdmin);
            txtProductPriceAdmin = view.FindViewById<TextView>(Resource.Id.txtProductPriceAdmin); ;
            txtProductStockAdmin = view.FindViewById<TextView>(Resource.Id.txtProductStockAdmin); ;
            txtProductDescriptionAdmin = view.FindViewById<TextView>(Resource.Id.txtProductDescriptionAdmin);
            txtProductImageSmallUrl = view.FindViewById<TextView>(Resource.Id.txtProductImageSmallUrl);
            txtProductImageBigUrl = view.FindViewById<TextView>(Resource.Id.txtProductImageBigUrl);
            btnAdd = view.FindViewById<Button>(Resource.Id.btnAddProductAdmin);

            btnAdd.Click += BtnAdd_Click;

            return view;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductNameAdmin.Text!="" && txtProductPriceAdmin.Text!="" && txtProductStockAdmin.Text!="" && txtProductDescriptionAdmin.Text!="" && txtProductImageSmallUrl.Text!="" && txtProductImageBigUrl.Text != "")
            {
                //create productCRUD through Factory Method Design Pattern
                FactoryMethod_ProductCRUD factoryMethod_ProductCRUD = new FactoryMethod_ProductCRUD();
                ICRUD<Product> productCRUD = factoryMethod_ProductCRUD.CreateCRUD();
                try
                {
                    Product product = new Product();
                    product.Name = txtProductNameAdmin.Text;
                    product.Price = Convert.ToDecimal(txtProductPriceAdmin.Text);
                    product.Stock = Convert.ToInt32(txtProductStockAdmin.Text);
                    product.Description = txtProductDescriptionAdmin.Text;
                    product.ImageSmall = txtProductImageSmallUrl.Text;
                    product.ImageBig = txtProductImageBigUrl.Text;

                }
                catch(Exception ex)
                {

                }

            }
        }
    }
}