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
    public class Customer
    {
        public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DoB { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		
		public string Password { get; set; }

		public Customer() { }

		/*
		public Customer(string fname, string lname, DateTime dob, string email, string phone, string address, string password)
		{
			this.FirstName = fname;
			this.LastName = lname;
			this.DoB = dob;
			this.Email = email;
			this.Phone = phone;
			this.Address = address;
			this.Password = password;
		}
		*/
	}
}