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
    class FactoryMethod_DeliveryTypeCRUD : CRUDFactory<DeliveryType>
    {
        /// <summary>
        /// Factory Method to create DeliveryType CRUD Implementation
        /// </summary>
        protected override ICRUD<DeliveryType> MakeCRUD()
        {
            ICRUD<DeliveryType> deliveryTypeCRUD = new DeliveryTypeCRUD();
            return deliveryTypeCRUD;
        }
    }
}