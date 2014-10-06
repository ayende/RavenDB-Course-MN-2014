using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Course.MN.Users;
using Orders;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Client.Linq;

namespace Course.MN
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var store = new DocumentStore
			{
				Url = "http://localhost:8080",
				DefaultDatabase = "Users"
			}.Initialize())
			{

				IndexCreation.CreateIndexes(typeof (Users_Search).Assembly,
					store);

				using (var s = store.OpenSession())
				{
					var users = s.Query<User>()
						.Where(x => x.Addresses.Any(p => p.City == "Edina"))
						.ToList();

					foreach (var user in users)
					{
						user.Phones.Add("iiii");
					}

					s.SaveChanges();
				}
			}
		}

		public class Result
		{
			public double Total;
		}
	}
	public class Users_Search : AbstractIndexCreationTask<User>
	{
		public Users_Search()
		{
			Map = users =>
				from user in users
				select new
				{
					BlueHorse = new object[]
					{
						user.Name,
						user.Name.Split(),
						user.Email,
						user.Email.Split('@')
					}
				};
		}
	}

	public class Names_Search : AbstractMultiMapIndexCreationTask
	{
		public Names_Search()
		{
			AddMap<User>(users =>
				from user in users 
				select new { user.Name }
			);

			AddMap<Dog>(dogs =>
				from dog in dogs
				select new { dog.Name }
			);
		}
	}
}
