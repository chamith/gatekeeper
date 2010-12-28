using System;
using NUnit.Framework;

namespace Gatekeeper.Test
{
	[TestFixture]
	public class AuthenticationSvcTest
	{
		public AuthenticationSvcTest ()
		{
		}
		
		[Test()]
		public void TestAddUser()
		{
			User user = new AuthenticationSvc().AddUser("chamith", "cys", "Chamith", "Siriwardena");
			Assert.IsNotNull(user);
		}
		[Test()]
		public void TestIsValidUser()
		{
			bool result = new AuthenticationSvc().IsValidUser("chamith", "cys");
			Assert.IsTrue(result);
		}
	}
}

