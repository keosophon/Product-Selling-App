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

        public void DeleteObject(int id)
        {

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