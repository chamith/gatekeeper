using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Gatekeeper.Core
{
	internal class EmbeddedResourceHelper
	{
		public Stream GetEmbeddedFile(Assembly assembly, string fileName)
		{
			try
			{
				// get a list of resource names from the manifest
				string [] embeddedResources = assembly.GetManifestResourceNames();

				foreach(string embeddedResource in embeddedResources)
				{
					//if(res.ToLowerInvariant().EndsWith(fileName.ToLowerInvariant()))
					if(embeddedResource.ToLowerInvariant() == fileName.ToLowerInvariant())
					{
					    Stream resourceStream = assembly.GetManifestResourceStream(embeddedResource);
                        return resourceStream;
					}
				} 

				return null;
			}
			catch(Exception e)
			{
				throw new Exception("Error occurred looking for an embedded resource in assembly " + assembly.FullName, e);
			}
		}

        public Stream GetEmbeddedFile(string assemblyName, string fileName)
		{
			Assembly assembly = Assembly.Load(assemblyName);
            return GetEmbeddedFile(assembly, fileName);
		}

		public Stream GetEmbeddedFile(Type type, string fileName)
		{
			string assemblyName = type.Assembly.GetName().Name;
			return GetEmbeddedFile(assemblyName, fileName);
		}

		public XmlDocument GetEmbeddedXml(Type type, string fileName)
		{
			Stream str = GetEmbeddedFile(type, fileName);
			XmlTextReader tr = new XmlTextReader(str);
			XmlDocument xml = new XmlDocument();
			xml.Load(tr);
			str.Close();
			return xml;
		}

		public XmlDocument GetEmbeddedXml(Assembly assembly, string fileName)
		{
			Stream str = GetEmbeddedFile(assembly, fileName);
			XmlTextReader tr = new XmlTextReader(str);
			XmlDocument xml = new XmlDocument();
			xml.Load(tr);
			str.Close();
			return xml;
		}

	}
}
