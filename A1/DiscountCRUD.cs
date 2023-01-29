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
    /// CRUD Implementation for Discount Table
    /// </summary>
    class DiscountCRUD : ICRUD<Discount>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public int Add(Discount discount)
        {
            //not required to implement
            return -1;
        }

        public Discount GetObject(string name)
        {
            //no required to implement

            Discount discount = null;
            return discount;
            ;
        }

        public Discount GetObject(int id)
        {
            //no required to implement
            Discount discount = null;

            return discount;
        }

        public List<Discount> GetObjects()
        {
            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM Discounts;";
            List<Discount> discountList = new List<Discount>();
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Discount discount = new Discount();
                discount.Id = Convert.ToInt32(reader[0].ToString());
                discount.Name = reader[1].ToString();
                discount.Percentage = Convert.ToDecimal(reader[2].ToString());                
                discount.Description = reader[3].ToString();
                discountList.Add(discount);
            }
            reader.Close();
            conn.Close();
            return discountList;
        }
    }
}