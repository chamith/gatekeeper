using System;
using System.Xml;
namespace Gatekeeper.Util
{
	public class XMLImporter
	{
		public XMLImporter ()
		{
		}
		
		public void Import(string fileName)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(fileName);
			var appNode = doc.SelectSingleNode("application");
			var appName = appNode.Attributes["name"].Value;
			var appDesc = appNode.Attributes["description"].Value;
			
			var app = new Application(){Guid = Guid.NewGuid(), Name = appName, Description = appDesc};
			GatekeeperFactory.ApplicationSvc.Add(app);
			
			this.ImportSecurableObjectTypes(app, appNode);
			this.ImportRights(app, appNode);
			this.ImportRoles(app, appNode);
		}
		
		void ImportSecurableObjectTypes(Application application, XmlNode xNodeApplication)
		{
			var list = xNodeApplication.SelectNodes("securableObjectTypes/securableObjectType");
			
			foreach(XmlNode node in list)
			{
				this.ImportSecurableObjectType(application, node);
			}
			
		}
		
		void ImportSecurableObjectType(Application application, XmlNode node)
		{
			var name = node.Attributes["name"].Value;
			var desc = node.Attributes["description"].Value;
			
			SecurableObjectType item = new SecurableObjectType()
			{
				Application = application, 
				Name = name, 
				Description = desc
			};
			
			GatekeeperFactory.SecurableObjectTypeSvc.Add(item);
			Console.WriteLine("Securable Object Type '{0}' added.", name);
		}
		
		void ImportRoles(Application application, XmlNode xNodeApplication)
		{
			var list = xNodeApplication.SelectNodes("roles/role");
			
			foreach(XmlNode node in list)
			{
				this.ImportRole(application, node);
			}
			
		}
		
		void ImportRole(Application application, XmlNode node)
		{
			var name = node.Attributes["name"].Value;
			var desc = node.Attributes["description"].Value;
			var securableObjectTypeName = node.Attributes["securableObjectType"].Value;
			var securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(application, securableObjectTypeName);
			
			var item = new Role()
			{
				Application = application, 
				Name = name, 
				Description = desc, 
				SecurableObjectType = securableObjectType
			};
			
			GatekeeperFactory.RoleSvc.Add(item);
			Console.WriteLine("Role '{0}' added.", name);
			
			this.ImportRightAssignments(application, item, node);
		}
		
		void ImportRightAssignments(Application application, Role role, XmlNode roleNode)
		{
			var list = roleNode.SelectNodes("rightAssignments/right-ref");
			
			foreach(XmlNode node in list)
			{
				this.ImportRightAssignment(application, role, node);
			}
			
		}
		
		void ImportRightAssignment(Application application, Role role, XmlNode node)
		{
			var rightName = node.Attributes["name"].Value;
			var right = GatekeeperFactory.RightSvc.Get(application, rightName);
			
			var item = new RoleRightAssignment()
			{
				Role = role,
				Right = right,
				Application = application,
				SecurableObjectType = role.SecurableObjectType
			};
			
			GatekeeperFactory.RoleRightAssignmentSvc.Add(item);
			Console.WriteLine("Role Right Assignment '{0} - {1}' added.", role.Name, rightName);
		}
		
		void ImportRights(Application application, XmlNode xNodeApplication)
		{
			var xNodeListRights = xNodeApplication.SelectNodes("rights/right");
			
			foreach(XmlNode node in xNodeListRights)
			{
				this.ImportRight(application, node);
			}
			
		}
		
		void ImportRight(Application application, XmlNode node)
		{
			var name = node.Attributes["name"].Value;
			var desc = node.Attributes["description"].Value;
			var securableObjectTypeName = node.Attributes["securableObjectType"].Value;
			var securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(application, securableObjectTypeName);
			
			Right right = new Right()
			{
				Application = application, 
				Name = name, 
				Description = desc, 
				SecurableObjectType = securableObjectType
			};
			
			GatekeeperFactory.RightSvc.Add(right);
			Console.WriteLine("Right '{0}' added.", name);
			
		}

	}
}

