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
    class PaymentCRUD:ICRUD<Payment>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public int Add(Payment payment)
        {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO Payment(PaymentDate, OrderId, Amount) " +
                "VALUES (@paymentDate, @orderId, @amount)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter paymentDateParam =
                new SqlParameter("@paymentDate", SqlDbType.Date, 8);
            SqlParameter orderIdParam =
                new SqlParameter("@orderId", SqlDbType.Int, 4);
            SqlParameter amountParam =
                new SqlParameter("@amount", SqlDbType.Decimal, 7);
            amountParam.Precision = 7;
            amountParam.Scale = 2;

            paymentDateParam.Value = payment.PaymentDate;
            orderIdParam.Value = payment.OrderId;
            amountParam.Value = payment.Amount;
           
            command.Parameters.Add(paymentDateParam);
            command.Parameters.Add(orderIdParam);
            command.Parameters.Add(amountParam  );

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;

        }
    }
}