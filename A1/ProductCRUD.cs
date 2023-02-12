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
using System.Data;

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
            string commandText = "INSERT INTO Products(Name, Price, Stock, Description, ImageSmall, ImageBig) " +
                "VALUES (@name, @price, @stock, @description, @imagesmall, @imagebig)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter nameParam =
                new SqlParameter("@name", SqlDbType.VarChar, 50);
            SqlParameter priceParam =
                new SqlParameter("@price", SqlDbType.Decimal, 6);
            SqlParameter stockParam =
                new SqlParameter("@stock", SqlDbType.Int, 4);
            SqlParameter descriptionParam =
                new SqlParameter("@description", SqlDbType.VarChar, 200);
            SqlParameter imageSmallParam =
                new SqlParameter("@imagesmall", SqlDbType.VarChar, 50);
            SqlParameter imageBigParam =
                new SqlParameter("@imagebig", SqlDbType.VarChar, 50);


            nameParam.Value = product.Name;
            priceParam.Value = product.Price;
            stockParam.Value = product.Stock;
            descriptionParam.Value = product.Description;
            imageSmallParam.Value = product.ImageSmall;
            imageBigParam.Value = product.ImageBig;

            priceParam.Precision = 6;
            priceParam.Scale = 2;

            command.Parameters.Add(nameParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(stockParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(imageSmallParam);
            command.Parameters.Add(imageBigParam);
            
            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        public Product GetObject(int id)
        {
            //no required to implement
            
            Product product = null;

            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM Products WHERE Id=@id";            
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter idParam =
                new SqlParameter("@id", SqlDbType.Int, 4);

            idParam.Value = id;            

            command.Parameters.Add(idParam);            
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                product = new Product();
                product.Id = Convert.ToInt32(reader[0].ToString());
                product.Name = reader[1].ToString();
                product.Price = Convert.ToDecimal(reader[2].ToString());
                product.Stock = Convert.ToInt32(reader[3].ToString());
                product.Description = reader[4].ToString();
                product.ImageSmall = reader[5].ToString();
                product.ImageBig = reader[6].ToString();

            }
            reader.Close();
            conn.Close();
            return product;
        }

        public Product GetObject(string name)
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

        public void DeleteObject(int id)
        {
            dbConnInstance.OpenConnection();
            string commandText = "DELETE FROM Products WHERE id=@id;";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter idParam =
                new SqlParameter("@id", SqlDbType.Int, 4);

            idParam.Value = id;

            command.Parameters.Add(idParam);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public int UpdateObject(Product product)
        {

            dbConnInstance.OpenConnection();
            string commandText = "UPDATE Products SET Name=@name, Price=@price, Stock=@stock, Description=@description, ImageSmall=@imageSmall, ImageBig=@imageBig WHERE id=@id;";
            SqlCommand command = new SqlCommand(commandText, conn);


            SqlParameter idParam =
                new SqlParameter("@id", SqlDbType.Int, 4);
            SqlParameter nameParam =
                new SqlParameter("@name", SqlDbType.VarChar, 50);
            SqlParameter priceParam =
                new SqlParameter("@price", SqlDbType.Decimal, 6);
            SqlParameter stockParam =
                new SqlParameter("@stock", SqlDbType.Int, 4);
            SqlParameter descriptionParam =
                new SqlParameter("@description", SqlDbType.VarChar, 200);
            SqlParameter imageSmallParam =
                new SqlParameter("@imageSmall", SqlDbType.VarChar, 50);
            SqlParameter imageBigParam =
                new SqlParameter("@imageBig", SqlDbType.VarChar, 50);

            idParam.Value = product.Id;
            nameParam.Value = product.Name;
            priceParam.Value = product.Price;
            stockParam.Value = product.Stock;
            descriptionParam.Value = product.Description;
            imageSmallParam.Value = product.ImageSmall;
            imageBigParam.Value = product.ImageBig;

            priceParam.Precision = 6;
            priceParam.Scale = 2;

            command.Parameters.Add(idParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(stockParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(imageSmallParam);
            command.Parameters.Add(imageBigParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}