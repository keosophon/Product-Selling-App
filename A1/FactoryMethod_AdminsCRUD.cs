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
    class FactoryMethod_AdminsCRUD : CRUDFactory<Admin>
    {
        /// <summary>
        /// Factory Method to create Customer CRUD Implementation
        /// </summary>
        protected override ICRUD<Admin> MakeCRUD()
        {
            ICRUD<Admin> adminCRUD = new AdminCRUD();
            return adminCRUD;
        }
    
    }
}