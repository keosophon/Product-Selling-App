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
    class FactoryMethod_PaymentCRUD : CRUDFactory<Payment>
    {
        /// <summary>
        /// Factory Method to create Payment CRUD Implementation
        /// </summary>
        protected override ICRUD<Payment> MakeCRUD()
        {
            ICRUD<Payment> paymentCRUD = new PaymentCRUD();
            return paymentCRUD;
        }

    }
}