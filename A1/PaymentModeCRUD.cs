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
    class PaymentModeCRUD : ICRUD<PaymentMode>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public void DeleteObject(int id)
        {

        }
        public int Add(PaymentMode paymentMode)
        {
            //not required to implement
            return -1;
        }

        public PaymentMode GetObject(string name)
        {
            //no required to implement

            PaymentMode paymentMode = null;
            return paymentMode;
        }

        public PaymentMode GetObject(int id)
        {
            //no required to implement
            PaymentMode paymentMode = null;
            return paymentMode;
        }

        public List<PaymentMode> GetObjects()
        {
            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM PaymentModes;";
            List<PaymentMode> paymentModeList = new List<PaymentMode>();
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PaymentMode paymentMode = new PaymentMode();
                paymentMode.Id = Convert.ToInt32(reader[0].ToString());
                paymentMode.Name = reader[1].ToString();
                paymentModeList.Add(paymentMode);
            }
            reader.Close();
            conn.Close();
            return paymentModeList;
        }
    }
}