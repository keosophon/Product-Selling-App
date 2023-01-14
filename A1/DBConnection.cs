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
    /// <summary>
    /// SingleTon Design Pattern
    /// </summary>
    class DBConnection
    {
        private static readonly SqlConnection con = new SqlConnection();
        
        static DBConnection()
        {                 
            con.ConnectionString = @"Persist Security Info=False;User ID=admin;Password=123456789;Initial Catalog=A1;Server=192.168.1.106\SQLEXPRESS;Encrypt=False;Connection Timeout=1000";
        }

        public static SqlConnection getConnection()
        {
            return con;
        }
    }
}