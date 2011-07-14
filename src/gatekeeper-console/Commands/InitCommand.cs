using System;
namespace Gatekeeper.ConsoleApp.Commands
{
	public class InitCommand:CommandBase
	{
		public InitCommand ()
		{
		}
		
		public override void Execute (string[] args)
		{
			string username = "admin";
			string firstname = "Admin";
			string lastname = "User";
			string password = "1qaz2wsx@";
			
			var userSvc = GatekeeperFactory.UserSvc;
			if(userSvc.GetByLoginName(username) == null)
			{
				var user = new Gatekeeper.AuthenticationSvc().AddUser(username, password, firstname, lastname);
			}

			Console.WriteLine("Gatekeeper initialization is complete.");
		}
	}
}

