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

namespace A1
{
    class AlertDialogBuilder
    {
        public static void BuildAlertDialog(Android.App.Activity activity, string title, string message)
        {
            Android.App.AlertDialog.Builder connectionException = new Android.App.AlertDialog.Builder(activity);
            connectionException.SetTitle(title);
            connectionException.SetMessage(message);
            connectionException.SetNegativeButton("Return", delegate { });
            connectionException.Create();
            connectionException.Show();
        }
    }
}