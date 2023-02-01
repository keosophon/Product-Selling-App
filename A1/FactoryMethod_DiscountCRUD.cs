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
    class FactoryMethod_DiscountCRUD : CRUDFactory<Discount>
    {
        /// <summary>
        /// Factory Method to create Discount CRUD Implementation
        /// </summary>
        protected override ICRUD<Discount> MakeCRUD()
        {
            ICRUD<Discount> discountCRUD = new DiscountCRUD();
            return discountCRUD;
        }
    }
}