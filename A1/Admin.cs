using System;

namespace A1
{
    class Admin
    {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DoB { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }

		public string Password { get; set; }

		public Admin() { }

	}
}