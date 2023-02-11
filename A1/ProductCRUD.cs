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
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO Customers(FirstName, LastName, DoB, Email, Phone, Address, Password) " +
                "VALUES (@fname, @lname, @dob, @email, @phone, @address,@password)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter fnameParam =
                new SqlParameter("@fname", SqlDbType.VarChar, 30);
            SqlParameter lnameParam =
                new SqlParameter("@lname", SqlDbType.VarChar, 30);
            SqlParameter dobParam =
                new SqlParameter("@dob", SqlDbType.Date, 8);
            SqlParameter emailParam =
                new SqlParameter("@email", SqlDbType.VarChar, 50);
            SqlParameter phoneParam =
                new SqlParameter("@phone", SqlDbType.VarChar, 10);
            SqlParameter addressParam =
                new SqlParameter("@address", SqlDbType.VarChar, 100);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar, 20);

            fnameParam.Value = cs.FirstName;
            lnameParam.Value = cs.LastName;
            dobParam.Value = cs.DoB;
            emailParam.Value = cs.Email;
            phoneParam.Value = cs.Phone;
            addressParam.Value = cs.Address;
            passwordParam.Value = cs.Password;
            command.Parameters.Add(fnameParam);
            command.Parameters.Add(lnameParam);
            command.Parameters.Add(dobParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(phoneParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(passwordParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;

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
                product.Id = Convert.ToInt32(reader[0].ToString());
                product.Name = reader[1].ToString();
                product.Price = Convert.ToDecimal(reader[2].ToString());
                product.Stock = Convert.ToInt32(reader[3].ToString());
                product.Description = reader[4].ToString();
                product.ImageSmall = reader[5].ToString();
                product.ImageBig = reader[6].ToString();
                productList.Add(product);

            }
            reader.Close();
            conn.Close();
            return productList;
        }
    }
}