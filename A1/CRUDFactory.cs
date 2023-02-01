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
    /// Abstract Factory of Factory Method to implement CRUD for entities
    /// </summary>
    public abstract class CRUDFactory<T>
    {
        protected abstract ICRUD<T> MakeCRUD();

        public ICRUD<T> CreateCRUD()
        {

            return this.MakeCRUD();
        }
    }


    /* -- Factory Design Page - Old - No Longer Use
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
            else if (type == typeof(DeliveryType))
                return (ICRUD<T>)new DeliveryTypeCRUD();
            else if (type == typeof(Order))
                return (ICRUD<T>)new OrderCRUD();
            else if (type == typeof(Payment))
                return (ICRUD<T>)new PaymentCRUD();
            else if (type == typeof(OrderDiscount))
                return (ICRUD<T>)new OrderDiscountCRUD();
            else if (type == typeof(OrderDetail))
                return (ICRUD<T>)new OrderDetailCRUD();

            return null;

        }
    }
    */
}