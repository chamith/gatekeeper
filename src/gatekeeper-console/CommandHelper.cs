using System;
namespace Gatekeeper.ConsoleApp
{
	public class CommandHelper
	{
		public static Command Parse(string line)
		{
			string[] testArgs = line.Split(' ');
			
			return Parse(testArgs);
		}
		
		public static Command Parse(string[] args)
		{
			Command cmd = new Command();
			cmd.CommandString = args[0];
		
			if(args.Length > 1)
			{
				cmd.Args = new string[args.Length-1];
				for(int i=1;i<args.Length;i++)
					cmd.Args[i-1] = args[i];
			}
			
			return cmd;	
		}
	}
	
	public struct Command
	{
		public string CommandString {
			get;
			set;
		}
		public string[] Args {
			get;
			set;
		}
	}
}

