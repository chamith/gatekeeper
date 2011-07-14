using System;
using Gatekeeper.ConsoleApp.Commands;

namespace Gatekeeper.ConsoleApp
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("+---------------------------------------------+");
			Console.WriteLine ("| gatesh - a command line tool for gatekeeper |");
			Console.WriteLine ("+---------------------------------------------+");
			
			if(args.Length > 0)
			{
				ExecuteCommand(args);
			}
			else
				while(!ExecuteCommand());
		}

		static bool ExecuteCommand()
		{
			Console.Write("gatesh> ");
			string commandLine = Console.ReadLine();
			string[] args = CommandHelper.GetArgs(commandLine);
			return ExecuteCommand(args);
		}
		
		
		static bool ExecuteCommand(string[] args)
		{
			Command cmd = CommandHelper.Parse(args);
			CommandBase commandBase = null;
			bool exit = false;
			switch(cmd.CommandString)
			{
				case "users":
					commandBase = new UsersCommand();
					break;
				case "adduser":
					commandBase = new AddUserCommand();
					break;
				case "init":
					commandBase = new InitCommand();
					break;
				case "import":
					commandBase = new ImportCommand();
					break;
				case "exit":
					commandBase = new ExitCommand();
					exit = true;
					break;
			}
			
			if(commandBase!=null) commandBase.Execute(cmd.Args);
			
			return exit;
		}}
}

