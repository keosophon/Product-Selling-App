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
using System.Data.SqlClient;

namespace A1
{
    class ProductCRUD : ICRUD<Product>
    {
        //private SqlConnection conn = DBConnection.GetDBConnInstance().GetConnection();

        public int Add(Product product)
        {
            return -1;
        }

        public Product GetObject(string name)
        {
            Product product = null;
            return product;
        }

        public Product GetObject(int id)
        {
            Product product = null;

            return product;
        }
    }
}