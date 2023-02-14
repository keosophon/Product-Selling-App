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

        public int UpdateObject(Payment payment)
        {
            dbConnInstance.OpenConnection();
            string commandText = "UPDATE Payments SET Status=@status WHERE Id=@id;";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter statusParam =
                new SqlParameter("@status", SqlDbType.VarChar, 50);
            SqlParameter idParam =
                new SqlParameter("@id", SqlDbType.VarChar, 50);

            statusParam.Value = payment.Status;            
            idParam.Value = payment.Id;

            command.Parameters.Add(idParam);
            command.Parameters.Add(statusParam);
            
            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public void DeleteObject(int id)
        {

        }
        public int Add(Payment payment)
        {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO Payments(PaymentDate, OrderId, Amount, PaymentModeId, Status) " +
                "VALUES (@paymentDate, @orderId, @amount, @paymentModeId,@status)";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter paymentDateParam =
                new SqlParameter("@paymentDate", SqlDbType.DateTime, 8);
            SqlParameter orderIdParam =
                new SqlParameter("@orderId", SqlDbType.Int, 4);
            SqlParameter amountParam =
                new SqlParameter("@amount", SqlDbType.Decimal, 7);
            SqlParameter paymentModeIdParam =
                new SqlParameter("@paymentModeId", SqlDbType.Int, 4);
            SqlParameter statusParam =
                new SqlParameter("@status", SqlDbType.Bit, 1);
            amountParam.Precision = 7;
            amountParam.Scale = 2;

            paymentDateParam.Value = payment.PaymentDate;
            orderIdParam.Value = payment.OrderId;
            amountParam.Value = payment.Amount;
            paymentModeIdParam.Value = payment.PaymentModeId;
            statusParam.Value = payment.Status;


            command.Parameters.Add(paymentDateParam);
            command.Parameters.Add(orderIdParam);
            command.Parameters.Add(amountParam  );
            command.Parameters.Add(paymentModeIdParam);
            command.Parameters.Add(statusParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        public Payment GetObject(string param1)
        {
            Payment payment = null;
            return payment;

        }

        public Payment GetObject(int orderId)
        {
            Payment payment = null;
            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM Payments WHERE OrderId=@orderId";
            SqlCommand command = new SqlCommand(commandText, conn);

            SqlParameter orderIdParam =
                new SqlParameter("@orderId", SqlDbType.Int, 4);

            orderIdParam.Value = orderId;

            command.Parameters.Add(orderIdParam);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                payment = new Payment();
                payment.Id = Convert.ToInt32(reader[0].ToString());
                payment.PaymentDate = Convert.ToDateTime(reader[1].ToString());
                payment.OrderId = Convert.ToInt32(reader[2].ToString());
                payment.Amount = Convert.ToDecimal(reader[3].ToString());
                payment.PaymentModeId = Convert.ToInt32(reader[4].ToString());
                payment.Status = Convert.ToBoolean(reader[5].ToString());
            }
            reader.Close();
            conn.Close();


            return payment;
        }
        public List<Payment> GetObjects()
        {
            //not required to implement in detail because not in project scope
            List<Payment> paymentList = null;
            return paymentList;
        }
    }
}