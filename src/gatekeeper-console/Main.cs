using System;
using Gatekeeper.ConsoleApp.Commands;

namespace Gatekeeper.ConsoleApp
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Gatekeeper Management Console");

			while(!ExecuteCommand());
		}

		static bool ExecuteCommand()
		{
			Console.Write("mmc> ");
			string commandLine = Console.ReadLine();
			Command cmd = CommandHelper.Parse(commandLine);
			CommandBase commandBase = null;
			bool exit = false;
			switch(cmd.CommandString)
			{
			case "users":
				commandBase = new UsersCommand();
				break;
			case "exit":
				exit = true;
				break;
			}
			
			if(commandBase!=null) commandBase.Execute(cmd.Args);
			
			return exit;
		}
	}
}
