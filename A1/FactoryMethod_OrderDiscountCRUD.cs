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
    class FactoryMethod_OrderDiscountCRUD : CRUDFactory<OrderDiscount>
    {
        /// <summary>
        /// Factory Method to create OrderDiscount CRUD Implementation
        /// </summary>
        protected override ICRUD<OrderDiscount> MakeCRUD()
        {
            ICRUD<OrderDiscount> orderDiscountCRUD = new OrderDiscountCRUD();
            return orderDiscountCRUD;
        }

    }
}