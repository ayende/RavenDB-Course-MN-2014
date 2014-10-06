using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Course.MN.Users;
using Raven.Client.Document;

namespace Course.MN
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var store = new DocumentStore
			{
				Url = "http://localhost.fiddler:8080",
				DefaultDatabase = "Users"
			}.Initialize())
			{
				using (var s = store.OpenSession())
				{
					s.Include<Dog>(x => x.Owners).Load(1);
				}

				using (var s = store.OpenSession())
				{
					s.Include<Dog>(x => x.Owners).Load(1);
				}
			}
		}
	}
}
