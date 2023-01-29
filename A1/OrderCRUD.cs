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
    class OrderCRUD:ICRUD<Order>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public int Add(Order order)
        {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO Order(OrderPlaced, OrderFulfilled, CustomerId, DeliveryId) " +
                "VALUES (@orderPlaced, @orderFullfilled, @customerId, @deliveryId)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter orderPlacedParam =
                new SqlParameter("@orderPlaced", SqlDbType.Date, 8);
            SqlParameter orderFullfilledParam =
                new SqlParameter("@orderFullfilled", SqlDbType.Date, 8);
            SqlParameter customerIdParam =
                new SqlParameter("@customerId", SqlDbType.Int, 4);
            SqlParameter deliveryIdParam =
                new SqlParameter("@deliveryId", SqlDbType.Int, 4);

            orderPlacedParam.Value = order.OrderPlaced;
            orderFullfilledParam.Value = order.OrderFulfilled;
            customerIdParam.Value = order.CustomerId;
            deliveryIdParam.Value = order.DeliveryId;
            command.Parameters.Add(orderPlacedParam);
            command.Parameters.Add(orderFullfilledParam);
            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(deliveryIdParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        /*
        public Customer GetObject(string emailOrPhone)
        {
            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM Customers WHERE Email=@email OR Phone=@phone;";
            Customer cus = null;
            SqlCommand command = new SqlCommand(commandText, conn);

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
                cus.Id = Convert.ToInt32(reader[0].ToString());
                cus.FirstName = reader[1].ToString();
                cus.LastName = reader[1].ToString();
                cus.DoB = Convert.ToDateTime(reader[3].ToString());
                cus.Email = reader[4].ToString();
                cus.Phone = reader[5].ToString();
                cus.Address = reader[6].ToString();
                cus.Password = reader[7].ToString();

            }
            reader.Close();
            conn.Close();
            return cus;


        }

        public Customer GetObject(int id)
        {
            Customer cs = null;
            return cs;
        }
        public List<Customer> GetObjects()
        {
            //not required to implement in detail because not in project scope
            List<Customer> customersList = null;
            return customersList;
        }
        */
    }
}