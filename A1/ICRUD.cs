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
	//public interface ICRUD<T> where T : class
	public interface ICRUD<T>
	{
		public int Add(T obj) ;
		public T GetObject(string par);
		

	}
}