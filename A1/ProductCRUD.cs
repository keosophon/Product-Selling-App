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
        private SqlConnection conn = DBConnection.GetDBConnInstance().GetConnection();

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
            //SqlCommand command = new SqlCommand(null, conn);

            /*
            // Create and prepare an SQL statement.
            command.CommandText = "SELECT * FROM Product WHERE Email=@email OR Phone=@phone;";
            SqlParameter email =
                new SqlParameter("@email", SqlDbType.VarChar, 50);
            SqlParameter phone =
                new SqlParameter("@phone", SqlDbType.VarChar, 15);

            email.Value = emailOrPhone;
            phone.Value = emailOrPhone;

            command.Parameters.Add(email);
            command.Parameters.Add(phone);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cus = new Customer();
                cus.Email = reader[4].ToString();
                cus.Phone = reader[5].ToString();
                cus.Password = reader[7].ToString();

            }
            */

            return product;
        }
    }
}