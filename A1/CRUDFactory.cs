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
}