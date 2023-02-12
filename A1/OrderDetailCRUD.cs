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
using System.Data;
using System.Data.SqlClient;

namespace A1
{
    class OrderDetailCRUD:ICRUD<OrderDetail>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public void DeleteObject(int id)
        {

        }
        public int Add(OrderDetail orderDetail)
        {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO OrderDetail(Quantity, OrderId, ProductId) " +
                "VALUES (@quantity, @orderId, @productId)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter quantityParam =
                new SqlParameter("@quantity", SqlDbType.Int, 4);
            SqlParameter orderIdParam =
                new SqlParameter("@orderId", SqlDbType.Int, 4);
            SqlParameter productIdParam =
                new SqlParameter("@productId", SqlDbType.Int, 4);

            quantityParam.Value = orderDetail.Quantity;
            orderIdParam.Value = orderDetail.OrderId;
            productIdParam.Value = orderDetail.ProductId;
            
            command.Parameters.Add(quantityParam);
            command.Parameters.Add(orderIdParam);
            command.Parameters.Add(productIdParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        public OrderDetail GetObject(string param1)
        {
            OrderDetail orderDetail = null;
            return orderDetail;
        }

        public OrderDetail GetObject(int id)
        {
            OrderDetail orderDetail = null;
            return orderDetail;
        }
        public List<OrderDetail> GetObjects()
        {
            //not required to implement in detail because not in project scope
            List<OrderDetail> orderDetailList = null;
            return orderDetailList;
        }
    }
}