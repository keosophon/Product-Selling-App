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
    class FactoryMethod_OrderDetailsCRUD : CRUDFactory<OrderDetail>
    {
        /// <summary>
        /// Factory Method to create OrderDetail CRUD Implementation
        /// </summary>
        protected override ICRUD<OrderDetail> MakeCRUD()
        {
            ICRUD<OrderDetail> orderDetailCRUD = new OrderDetailCRUD();
            return orderDetailCRUD;
        }
    }
}