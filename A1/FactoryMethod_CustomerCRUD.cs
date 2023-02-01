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
   
    class FactoryMethod_CustomerCRUD :CRUDFactory<Customer>
    {
        /// <summary>
        /// Factory Method to create Customer CRUD Implementation
        /// </summary>
        protected override ICRUD<Customer> MakeCRUD()
        {
            ICRUD<Customer> customerCRUD = new CustomerCRUD();
            return customerCRUD;
        }
    }
}