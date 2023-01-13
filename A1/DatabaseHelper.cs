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
using System.IO;



namespace A1
{
    public static class DatabaseHelper
    {
        //copying Existing Database file to system folder for use

        private static string connectionString;
        public static void setConnectionString(Stream oldDB)
        {
            
            string oldPath = "A1.db";
            string desPath = System.Environment.GetFolderPath(
   System.Environment.SpecialFolder.Personal) + "/" + oldPath;

            FileStream newDB = new FileStream(desPath, FileMode.OpenOrCreate);

            oldDB.CopyTo(newDB);
            //newDB.Flush();
            newDB.Close();

            connectionString = desPath;
        }
        public static string getConnectionString()
        {
            return connectionString;
        }
    }
}