using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
	public class Person
	{
		[Key] public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string CompanyPrivateInfo { get; set; }
	}
}
