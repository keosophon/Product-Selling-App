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
using System.Threading;

namespace A1
{
    class CustomerCRUD : ICustomer
    {
        private static SqlConnection conn = DBConnection.getConnection();

        public void openConnection()
        {
            var retries = 10;

            while (conn.State != ConnectionState.Open && retries > 0)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    //

                }
                Thread.Sleep(500);
                retries--;
            }
        }

        public int add(Customer cs) {

            this.openConnection();
            SqlCommand command = new SqlCommand(null, conn);

            // Create and prepare an SQL statement.
            command.CommandText =
                "INSERT INTO Customers(FirstName, LastName, DoB, Email, Phone, Address) " +
                "VALUES (@fname, @lname, @dob, @email, @phone, @address)";
            
            SqlParameter fnameParam =
                new SqlParameter("@fname", SqlDbType.Text, 30);
            SqlParameter lnameParam =
                new SqlParameter("@lname", SqlDbType.Text,30);
            SqlParameter dobParam =
                new SqlParameter("@dob", SqlDbType.Date, 8);
            SqlParameter emailParam =
                new SqlParameter("@email", SqlDbType.Text,50);
            SqlParameter phoneParam =
                new SqlParameter("@phone", SqlDbType.Text,10);
            SqlParameter addressParam =
                new SqlParameter("@address", SqlDbType.Text,100 );

            fnameParam.Value = cs.FirstName;
            lnameParam.Value = cs.LastName;
            dobParam.Value = cs.DoB;
            emailParam.Value = cs.Email;
            phoneParam.Value = cs.Phone;
            addressParam.Value = cs.Address;
            command.Parameters.Add(fnameParam);
            command.Parameters.Add(lnameParam);
            command.Parameters.Add(dobParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(phoneParam);
            command.Parameters.Add(addressParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            return result;
        }
    }
}