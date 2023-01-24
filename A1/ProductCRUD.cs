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
    /// <summary>
    /// CRUD Implementation for Products Table
    /// </summary>
    class ProductCRUD : ICRUD<Product>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public int Add(Product product)
        {
            //not required to implement
            return -1;
        }

        public Product GetObject(string name)
        {
            //no required to implement
            
            Product product = null;
            return product;
        }

        public Product GetObject(int id)
        {
            //no required to implement
            Product product = null;

            return product;
        }

        public List<Product> GetObjects()
        {
            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM Products;";
            List<Product> productList = new List<Product>();
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())            {
                Product product = new Product();
                product.Name = reader[1].ToString();
                product.Price = Convert.ToDecimal(reader[2].ToString());
                product.Stock = Convert.ToInt32(reader[3].ToString());
                product.Description = reader[4].ToString();
                product.ImageSmall = reader[5].ToString();                
                productList.Add(product);

            }
            reader.Close();
            conn.Close();
            return productList;
        }
    }
}