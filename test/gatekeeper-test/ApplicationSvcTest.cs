using System;
using NUnit.Framework;
using System.Collections.Generic;
namespace Gatekeeper.Test
{
	[TestFixture()]
	public class ApplicationSvcTest
	{
		[Test()]
		public void TestAdd ()
		{
			Application app = new Application();
			app.Name = "sample application";
			app.Description = "the application with this and that functionality";
			
			GatekeeperFactory.ApplicationSvc.Add(app);
		}
		
		[Test()]
		public void TestGetAll()
		{
			IList<Application> apps = GatekeeperFactory.ApplicationSvc.Get();
			foreach(Application app in apps)
			{
				Console.WriteLine("Name:{0}, Guid:{1}", app.Name, app.Guid);
			}
		}
	}
}

