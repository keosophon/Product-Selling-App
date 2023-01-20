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
    class CustomerCRUD : ICRUD<Customer>
    {

        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();        

        public int Add(Customer cs) {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO Customers(FirstName, LastName, DoB, Email, Phone, Address, Password) " +
                "VALUES (@fname, @lname, @dob, @email, @phone, @address,@password)";
            SqlCommand command = new SqlCommand(commandText, conn);                   

            SqlParameter fnameParam =
                new SqlParameter("@fname", SqlDbType.VarChar, 30);
            SqlParameter lnameParam =
                new SqlParameter("@lname", SqlDbType.VarChar, 30);
            SqlParameter dobParam =
                new SqlParameter("@dob", SqlDbType.Date, 8);
            SqlParameter emailParam =
                new SqlParameter("@email", SqlDbType.VarChar, 50);
            SqlParameter phoneParam =
                new SqlParameter("@phone", SqlDbType.VarChar, 10);
            SqlParameter addressParam =
                new SqlParameter("@address", SqlDbType.VarChar, 100);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar, 20);

            fnameParam.Value = cs.FirstName;
            lnameParam.Value = cs.LastName;
            dobParam.Value = cs.DoB;
            emailParam.Value = cs.Email;
            phoneParam.Value = cs.Phone;
            addressParam.Value = cs.Address;
            passwordParam.Value = cs.Password;
            command.Parameters.Add(fnameParam);
            command.Parameters.Add(lnameParam);
            command.Parameters.Add(dobParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(phoneParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(passwordParam);

            // Call Prepare after setting the Commandtext and Parameters.
            command.Prepare();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
            
        }

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
                cus.Email = reader[4].ToString();
                cus.Phone = reader[5].ToString();
                cus.Password = reader[7].ToString();

            }
            conn.Close();
            return cus;
            
            
        }

        public Customer GetObject(int id)
        {
            Customer cs =null;
            return cs;
        }
    }
}