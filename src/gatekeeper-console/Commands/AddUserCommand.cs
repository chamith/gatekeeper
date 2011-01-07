using System;
using Gatekeeper.Util;
using System.Text;
namespace Gatekeeper.ConsoleApp.Commands
{
	public class AddUserCommand:CommandBase
	{		
		public override void Execute (string[] args)
		{
			if(args.Length == 0)
				throw new ArgumentException("user name not provided");
			
			if(args.Length == 1)
				this.AddUser(args[0]);
			
			
		}
		
		string ReadPassword()
		{
			StringBuilder passwordBuilder = new StringBuilder();
			ConsoleKeyInfo info;
			
			do
			{
				info = Console.ReadKey(true);
				if(info.Key == ConsoleKey.Enter)
					break;
				else
				{
					passwordBuilder.Append(info.KeyChar);
					Console.Write("*");
				}
			} while (true);
			Console.WriteLine();
			
			return passwordBuilder.ToString();
		}
		
		void AddUser(string userName)
		{
			Console.Write("Password: ");
			string password = this.ReadPassword();
			
			Console.Write("First Name: ");
			string firstName = Console.ReadLine();
			
			Console.Write("Last Name: ");
			string lastName = Console.ReadLine();
			
			var user = new AuthenticationSvc().AddUser(userName, password, firstName, lastName);
			
			Console.WriteLine("User {0} ({1} {2}) has been created successfully.", user.Name, user.FirstName, user.LastName); 
			
		}
		
		void AddApplicationUser(string userName, string applicationName, string applicationRole)
		{
			//var application = GatekeeperFactory.ApplicationSvc.Get
		}
	}
}

