using System;
using Gatekeeper.Util;
namespace Gatekeeper.ConsoleApp.Commands
{
	public class ImportCommand:CommandBase
	{
		public ImportCommand ()
		{
		}
		
		public override void Execute (string[] args)
		{
			if(args.Length == 0)
				throw new ArgumentException("file name not provided");
			else if(args.Length > 1)
				throw new ArgumentException("too many arguments");
			
			XMLImporter importer = new XMLImporter();
			
			try
			{
				importer.Import(args[0]);
			}
			catch(Exception ex)
			{
				Console.WriteLine("something went wrong.. \n{0}", ex.ToString());
			}
		}
	}
}

