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

namespace A1
{
    
    class FactoryMethod_ProductCRUD : CRUDFactory<Product>
    {
        /// <summary>
        /// Factory Method to create Product CRUD Implementation
        /// </summary>
        protected override ICRUD<Product> MakeCRUD()
        {
            ICRUD<Product> productCRUD = new ProductCRUD();
            return productCRUD;
        }
    
    }
}