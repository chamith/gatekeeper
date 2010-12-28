using System;
using NUnit.Framework;
namespace Gatekeeper.Test
{
	[TestFixture()]
	public class AuthorizationSvcTest
	{
		[Test()]
		public void TestAddSystemSecurableObject ()
		{
			SecurableApplication system = new SecurableApplication();
			system.Name = "my system";
			system.Description = "my system can do this and that";
			new AuthorizationSvc().AddSystemSecurableObject(system);
		}
	}
}

