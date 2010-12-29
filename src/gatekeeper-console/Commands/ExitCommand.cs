using System;
using Gatekeeper.ConsoleApp.Commands;
namespace Gatekeeper.ConsoleApp
{
	public class ExitCommand: CommandBase
	{
		public ExitCommand ()
		{
		}
		
		public override void Execute (string[] args)
		{
			Console.WriteLine("bye..");
		}
	}
}

