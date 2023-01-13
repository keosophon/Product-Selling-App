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
    class Operator
    {
        private string dataSource = @"Persist Security Info=False;User ID=admin;Password=123456789;Initial Catalog=A1;Server=192.168.1.106\SQLEXPRESS;Encrypt=False;Connection Timeout=1000";
        public SqlConnection GetDBConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.dataSource;
            return con;
        }

    }
}