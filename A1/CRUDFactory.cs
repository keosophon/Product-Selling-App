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
    public class CRUDFactory
    {
        public static ICRUD<T> CreateCRUD<T> ()
        {
            //Type type = typeof(T);
            //if (type==typeof(Customer))
            return (ICRUD<T>)new CustomerCRUD();

        }
    }
}