using System.CodeDom;
using System.Collections.Generic;

namespace Course.MN.Users
{
	public class User
	{
		public string Id { get; set; } 
		public string Name { get; set; }
		public List<string> Phones { get; set; }

		public User()
		{
			Phones = new List<string>();
		}
	}
}