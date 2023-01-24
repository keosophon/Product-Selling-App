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
        private static DBConnection _dbConnInstance;
        private readonly SqlConnection _conn = new SqlConnection();
        private readonly string _url = @"Persist Security Info=False;User ID=admin;Password=123456789;Initial Catalog=A1;Server=192.168.1.106\SQLEXPRESS;Encrypt=False;Connection Timeout=1000;MultipleActiveResultSets=true";
        
        private DBConnection()
        {
            this._conn.ConnectionString = _url;
        }

        public SqlConnection GetConnection()
        {
            return _conn;
        }

        public static DBConnection GetDBConnInstance()
        {
            if (_dbConnInstance == null || _dbConnInstance._conn.State == ConnectionState.Closed)
            {
                _dbConnInstance = new DBConnection();
            }
            return _dbConnInstance;
        }

        public void OpenConnection()
        {
            var retries = 10;

            while (_conn.State != ConnectionState.Open && retries > 0)
            {
                try
                {
                    _conn.Open();
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