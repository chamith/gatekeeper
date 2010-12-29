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
			var user = new Gatekeeper.AuthenticationSvc().AddUser(username, password, firstname, lastname);

			Application application = new Application()
			{
				Name = "Gatekeeper Web Console",
				Description = "Manages gatekeeping options",
				Guid = new Guid("8047b7b4-3a5c-47dd-aa73-88b04f09bfca")
			};
			
			GatekeeperFactory.ApplicationSvc.Add(application);
			var adminRole = GatekeeperFactory.RoleSvc.Get(application, "admin");
			
			var appUser = new ApplicationUser(){Application = application, User = user, Role = adminRole};
			GatekeeperFactory.ApplicationUserSvc.Save(appUser);

		}
	}
}

