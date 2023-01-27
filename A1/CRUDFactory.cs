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
    /// <summary>
    /// Factory to create CRUD implementation for entities
    /// </summary>
    public class CRUDFactory
    {
        public static ICRUD<T> CreateCRUD<T> ()
        {
            Type type = typeof(T);
            if (type == typeof(Customer))
                return (ICRUD<T>)new CustomerCRUD();
            else if (type == typeof(Product))
                return (ICRUD<T>)new ProductCRUD();
            else if (type == typeof(Discount))
                return (ICRUD<T>)new DiscountCRUD();

            return null;

        }
    }
}