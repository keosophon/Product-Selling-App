﻿using Android.App;
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
    class FactoryMethod_PaymentModeCRUD : CRUDFactory<PaymentMode>
    {
        /// <summary>
        /// Factory Method to create Product CRUD Implementation
        /// </summary>
        protected override ICRUD<PaymentMode> MakeCRUD()
        {
            ICRUD<PaymentMode> paymentModeCRUD = new PaymentModeCRUD();
            return paymentModeCRUD;
        }

    }
}