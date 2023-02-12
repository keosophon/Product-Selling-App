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
    class AdminCRUD : ICRUD<Admin>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public void DeleteObject(int id)
        {

        }

        public int Add(Admin admin)
        {
            dbConnInstance.OpenConnection();
            string commandText = "INSERT INTO Admins(FirstName, LastName, DoB, Email, Phone, Address, Password) " +
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

            fnameParam.Value = admin.FirstName;
            lnameParam.Value = admin.LastName;
            dobParam.Value = admin.DoB;
            emailParam.Value = admin.Email;
            phoneParam.Value = admin.Phone;
            addressParam.Value = admin.Address;
            passwordParam.Value = admin.Password;
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

        public Admin GetObject(string emailOrPhone)
        {
            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM Admins WHERE Email=@email OR Phone=@phone;";
            Admin admin = null;
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
                admin = new Admin();
                admin.Id = Convert.ToInt32(reader[0].ToString());
                admin.FirstName = reader[1].ToString();
                admin.LastName = reader[1].ToString();
                admin.DoB = Convert.ToDateTime(reader[3].ToString());
                admin.Email = reader[4].ToString();
                admin.Phone = reader[5].ToString();
                admin.Address = reader[6].ToString();
                admin.Password = reader[7].ToString();

            }
            reader.Close();
            conn.Close();
            return admin;


        }

        public Admin GetObject(int id)
        {
            Admin admin = null;
            return admin;
        }
        public List<Admin> GetObjects()
        {
            //not required to implement in detail because not in project scope
            List<Admin> adminsList = null;
            return adminsList;
        }
    }
}