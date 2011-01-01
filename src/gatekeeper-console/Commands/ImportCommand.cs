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
			XMLImporter importer = new XMLImporter();
			
		}
	}
}

