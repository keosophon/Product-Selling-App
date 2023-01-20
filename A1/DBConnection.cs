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
    /// <summary>
    /// Database Connection using SingleTon Design Pattern
    /// </summary>
    public sealed class DBConnection
    {
        private static DBConnection dbConnInstance;
        private readonly SqlConnection conn = new SqlConnection();
        private readonly string url = @"Persist Security Info=False;User ID=admin;Password=123456789;Initial Catalog=A1;Server=192.168.1.106\SQLEXPRESS;Encrypt=False;Connection Timeout=60;MultipleActiveResultSets=true";
        
        private DBConnection()
        {
            this.conn.ConnectionString = url;
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }

        public static DBConnection GetDBConnInstance()
        {
            if (dbConnInstance == null || dbConnInstance.conn.State == ConnectionState.Closed)
            {
                dbConnInstance = new DBConnection();
            }
            return dbConnInstance;
        }

        public void OpenConnection()
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
                    throw new Exception(ex.Message);

                }
                Thread.Sleep(500);
                retries--;
            }
        }
    }
}