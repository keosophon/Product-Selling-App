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
       
        private TextView txtProductNameAdmin;
        private TextView txtProductPriceAdmin;
        private TextView txtProductStockAdmin;
        private TextView txtProductDescriptionAdmin;
        private TextView txtProductImageSmallUrl;
        private TextView txtProductImageBigUrl;
        private TextView txtProductSearch;
        private Button btnSearch;
        private Button btnClear;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnLogOut;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_ProductDetails, container, false);
            txtProductSearch = view.FindViewById<TextView>(Resource.Id.txtProductSearchAdmin);            
            txtProductNameAdmin = view.FindViewById<TextView>(Resource.Id.txtProductNameAdmin);
            txtProductPriceAdmin = view.FindViewById<TextView>(Resource.Id.txtProductPriceAdmin); ;
            txtProductStockAdmin = view.FindViewById<TextView>(Resource.Id.txtProductStockAdmin); ;
            txtProductDescriptionAdmin = view.FindViewById<TextView>(Resource.Id.txtProductDescriptionAdmin);
            txtProductImageSmallUrl = view.FindViewById<TextView>(Resource.Id.txtProductImageSmallUrl);
            txtProductImageBigUrl = view.FindViewById<TextView>(Resource.Id.txtProductImageBigUrl);
            btnSearch = view.FindViewById<Button>(Resource.Id.btnSearch);
            btnClear = view.FindViewById<Button>(Resource.Id.btnClear);
            btnAdd = view.FindViewById<Button>(Resource.Id.btnAddProductAdmin);
            btnDelete = view.FindViewById<Button>(Resource.Id.btnDeleteProductAdmin);
            btnUpdate = view.FindViewById<Button>(Resource.Id.btnUpdateProductAdmin);
            btnLogOut = view.FindViewById<Button>(Resource.Id.btnLogOutProductAdmin);
            btnSearch.Click += BtnSearch_Click;
            btnClear.Click += BtnClear_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;

            btnLogOut.Click += BtnLogOut_Click;

            return view;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Activity, typeof(MainActivity));
            StartActivity(intent);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtProductSearch.Text = "";
            txtProductNameAdmin.Text = "";
            txtProductPriceAdmin.Text = "";
            txtProductStockAdmin.Text = "";
            txtProductDescriptionAdmin.Text = "";
            txtProductImageSmallUrl.Text = "";
            txtProductImageBigUrl.Text = "";
            txtProductSearch.RequestFocus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductNameAdmin.Text != "" && txtProductPriceAdmin.Text != "" && txtProductStockAdmin.Text != "" && txtProductDescriptionAdmin.Text != "" && txtProductImageSmallUrl.Text != "" && txtProductImageBigUrl.Text != "")
            {
                //create productCRUD through Factory Method Design Pattern
                FactoryMethod_ProductCRUD factoryMethod_ProductCRUD = new FactoryMethod_ProductCRUD();
                ICRUD<Product> productCRUD = factoryMethod_ProductCRUD.CreateCRUD();

                try
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(txtProductSearch.Text);
                    product.Name = txtProductNameAdmin.Text;
                    product.Price = Convert.ToDecimal(txtProductPriceAdmin.Text);
                    product.Stock = Convert.ToInt32(txtProductStockAdmin.Text);
                    product.Description = txtProductDescriptionAdmin.Text;
                    product.ImageSmall = txtProductImageSmallUrl.Text;
                    product.ImageBig = txtProductImageBigUrl.Text;
                    if (productCRUD.UpdateObject(product) == 1)
                    {
                        AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.success), Resources.GetString(Resource.String.updatedSuccess));
                        txtProductSearch.Text = "";
                        txtProductNameAdmin.Text = "";
                        txtProductPriceAdmin.Text = "";
                        txtProductStockAdmin.Text = "";
                        txtProductDescriptionAdmin.Text = "";
                        txtProductImageSmallUrl.Text = "";
                        txtProductImageBigUrl.Text = "";
                        txtProductSearch.RequestFocus();
                    }
                    

                }
                catch (Exception ex)
                {
                    AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.error), ex.Message);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtProductSearch.Text != "")
            {
                //create productCRUD through Factory Method Design Pattern
                FactoryMethod_ProductCRUD factoryMethod_ProductCRUD = new FactoryMethod_ProductCRUD();
                ICRUD<Product> productCRUD = factoryMethod_ProductCRUD.CreateCRUD();
                Product product = productCRUD.GetObject(Convert.ToInt32(txtProductSearch.Text));
                if (product != null)
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
        }

        
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductSearch.Text !="")
            {
                //create productCRUD through Factory Method Design Pattern
                FactoryMethod_ProductCRUD factoryMethod_ProductCRUD = new FactoryMethod_ProductCRUD();
                ICRUD<Product> productCRUD = factoryMethod_ProductCRUD.CreateCRUD();
                try
                {
                    if (productCRUD.DeleteObject(Convert.ToInt32(txtProductSearch.Text)) == 1)
                    {
                        AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.success), Resources.GetString(Resource.String.deletedSuccess));
                        txtProductSearch.Text = "";
                        txtProductNameAdmin.Text = "";
                        txtProductPriceAdmin.Text = "";
                        txtProductStockAdmin.Text = "";
                        txtProductDescriptionAdmin.Text = "";
                        txtProductImageSmallUrl.Text = "";
                        txtProductImageBigUrl.Text = "";
                        txtProductSearch.RequestFocus();
                    }
                    else
                    {
                        AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.wrongInput), Resources.GetString(Resource.String.idNotFound));
                    }
                    
                }
                catch(Exception ex)
                {
                    AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.error), ex.Message);
                }
            }
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
                    if (productCRUD.Add(product) == 1)
                    {
                        AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.success), Resources.GetString(Resource.String.productAddSuccess));
                        txtProductSearch.Text = "";
                        txtProductNameAdmin.Text = "";
                        txtProductPriceAdmin.Text = "";
                        txtProductStockAdmin.Text = "";
                        txtProductDescriptionAdmin.Text = "";
                        txtProductImageSmallUrl.Text = "";
                        txtProductImageBigUrl.Text = "";
                        txtProductSearch.RequestFocus();
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    AlertDialogBuilder.BuildAlertDialog(Activity, Resources.GetString(Resource.String.error), ex.Message);
                }
            }
        }
    }
}