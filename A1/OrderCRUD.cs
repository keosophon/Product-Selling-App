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

        public int UpdateObject(Order order)
        {
            return -1;
        }

        public void DeleteObject(int id)
        {
            dbConnInstance.OpenConnection();
            string commandText = "DELETE FROM Orders WHERE id=@id;";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter idParam =
                new SqlParameter("@id", SqlDbType.Int, 4);

            idParam.Value = id;

            command.Parameters.Add(idParam);
            command.Prepare();
            command.ExecuteNonQuery();
        }
        public int Add(Order order)
        {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO Orders(OrderPlaced, OrderFulfilled, CustomerId, DeliveryId) output INSERTED.ID " +
                "VALUES (@orderPlaced, @orderFullfilled, @customerId, @deliveryId)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter orderPlacedParam =
                new SqlParameter("@orderPlaced", SqlDbType.DateTime, 8);
            SqlParameter orderFullfilledParam =
                new SqlParameter("@orderFullfilled", SqlDbType.DateTime, 8);
            SqlParameter customerIdParam =
                new SqlParameter("@customerId", SqlDbType.Int, 4);
            SqlParameter deliveryIdParam =
                new SqlParameter("@deliveryId", SqlDbType.TinyInt);

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
            int result = (int)command.ExecuteScalar();
            conn.Close();
            return result;

        }
               
        public Order GetObject(string param1)
        {
            Order order = null;
            return order;

        }

        public Order GetObject(int id)
        {
            Order order = null;

            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM Orders WHERE Id=@id";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter idParam =
                new SqlParameter("@id", SqlDbType.Int, 4);

            idParam.Value = id;

            command.Parameters.Add(idParam);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                order = new Order();
                order.Id = Convert.ToInt32(reader[0].ToString());
                order.OrderPlaced = Convert.ToDateTime(reader[1].ToString());
                order.OrderFulfilled = Convert.ToDateTime(reader[2].ToString());
                order.CustomerId = Convert.ToInt32(reader[3].ToString());
                order.DeliveryId = Convert.ToInt32(reader[4].ToString());
            }
            reader.Close();
            conn.Close();
            return order;
        }
        public List<Order> GetObjects()
        {
            //not required to implement in detail because not in project scope
            List<Order> orderList = null;
            return orderList;
        }
        
    }
}