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
			
			while(!ExecuteCommand());
		}

		static bool ExecuteCommand()
		{
			Console.Write("gatesh> ");
			string commandLine = Console.ReadLine();
			Command cmd = CommandHelper.Parse(commandLine);
			CommandBase commandBase = null;
			bool exit = false;
			switch(cmd.CommandString)
			{
				case "users":
					commandBase = new UsersCommand();
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
		}
		

	}
}

