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
    class OrderDiscountCRUD:ICRUD<OrderDiscount>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public int Add(OrderDiscount orderDiscount)
        {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO OrderDiscount(OrderId, DiscountId) " +
                "VALUES (@orderId, @discountId)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter orderIdParam =
                new SqlParameter("@orderId", SqlDbType.Int, 4);
            SqlParameter discountIdParam =
                new SqlParameter("@amount", SqlDbType.Int, 4);

            orderIdParam.Value = orderDiscount.OrderId;
            discountIdParam.Value = orderDiscount.DiscountId;

            command.Parameters.Add(orderIdParam);
            command.Parameters.Add(discountIdParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;

        }
    }
}