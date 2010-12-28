using System;
using Gatekeeper.Collections;
namespace Gatekeeper.ConsoleApp.Commands
{
	public class UsersCommand:CommandBase
	{
		public UsersCommand ()
		{
			//Console.WriteLine("Users");
		}
		
		public override void Execute(string[] args)
		{
			Command cmd = CommandHelper.Parse(args);
			
			switch(cmd.CommandString)
			{
			case "list":
				this.List();
				break;
			case "add":
				this.Add(cmd.Args[0], cmd.Args[1], cmd.Args[2], cmd.Args[3]);
				break;
			}
		}
		
		void List()
		{
			UserCollection users = GatekeeperFactory.UserSvc.Get();
			
			foreach(User user in users)
				Console.WriteLine("Login Name: {0}\t Full Name:'{1} {2}'", user.LoginName, user.FirstName, user.LastName);
		}
		
		void Add(string userName, string password, string firstName, string lastName)
		{
			AuthenticationSvc authSvc = new AuthenticationSvc();
			
			User user = authSvc.AddUser(userName, password, firstName, lastName);
			Console.WriteLine("User '{0}' has been created successfully", userName);
		}
	}
}

