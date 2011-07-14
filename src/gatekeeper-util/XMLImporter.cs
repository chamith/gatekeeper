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
			this.ImportApplicationUsers(app, appNode);
		}
		
		void ImportSecurableObjectTypes(Application application, XmlNode xNodeApplication)
		{
			Console.WriteLine("Importing Securable Object Types");
			
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
			
			Console.WriteLine("Adding Securable Object Type '{0}'", name);
			
			SecurableObjectType item = new SecurableObjectType()
			{
				Application = application, 
				Name = name, 
				Description = desc
			};
			
			try
			{
				GatekeeperFactory.SecurableObjectTypeSvc.Add(item);
				Console.WriteLine("Completed adding Securable Object Type '{0}'", name);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error occurred while adding Securable Object Type '{0}'", name);
				Console.WriteLine(ex.ToString());
			}
		}
		
		void ImportRoles(Application application, XmlNode xNodeApplication)
		{
			Console.WriteLine("Importing Roles");
			
			var list = xNodeApplication.SelectNodes("roles/role");
			
			foreach(XmlNode node in list)
			{
				this.ImportRole(application, node);
			}
			
		}
		
		void ImportRole(Application application, XmlNode node)
		{
			var name = node.Attributes["name"].Value;
			var securableObjectTypeName = node.Attributes["securableObjectType"].Value;
			
			var desc = string.Empty;
			var xAttrDescription = node.Attributes["description"];
			if(xAttrDescription != null)
				desc = xAttrDescription.Value;

			var securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(application, securableObjectTypeName);
			
			var item = new Role()
			{
				Application = application, 
				Name = name, 
				Description = desc, 
				SecurableObjectType = securableObjectType
			};
			
			Console.WriteLine("Adding Role '{0}'", name);
			
			try
			{
				GatekeeperFactory.RoleSvc.Add(item);
				Console.WriteLine("Completed adding Role '{0}'.", name);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error occurred while adding Role '{0}'.", name);
				Console.WriteLine(ex.ToString());
			}
			
			this.ImportRightAssignments(application, item, node);
		}
		
		void ImportRightAssignments(Application application, Role role, XmlNode roleNode)
		{
			Console.WriteLine("Importing Role Right Assignments for the Role '{0}'.");
			
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
			
			Console.WriteLine("Adding Role Right Assignment '{0} - {1}'.", role.Name, rightName);
			
			try
			{
				GatekeeperFactory.RoleRightAssignmentSvc.Add(item);
				Console.WriteLine("Completed adding Role Right Assignment '{0} - {1}'.", role.Name, rightName);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error occurred while adding Role Right Assignment '{0} - {1}'.", role.Name, rightName);
				Console.WriteLine(ex.ToString());
			}
		}
		
		void ImportRights(Application application, XmlNode xNodeApplication)
		{
			Console.WriteLine("Importing Rights.");
			
			var xNodeListRights = xNodeApplication.SelectNodes("rights/right");
			
			foreach(XmlNode node in xNodeListRights)
			{
				this.ImportRight(application, node);
			}
			
		}
		
		void ImportRight(Application application, XmlNode node)
		{
			var name = node.Attributes["name"].Value;
			var securableObjectTypeName = node.Attributes["securableObjectType"].Value;
			
			var desc = string.Empty;
			var xAttrDescription = node.Attributes["description"];
			if(xAttrDescription != null)
				desc = xAttrDescription.Value;

			var securableObjectType = GatekeeperFactory.SecurableObjectTypeSvc.Get(application, securableObjectTypeName);
			
			Right right = new Right()
			{
				Application = application, 
				Name = name, 
				Description = desc, 
				SecurableObjectType = securableObjectType
			};
			
			Console.WriteLine("Adding Right '{0}'.", name);
			try
			{
				GatekeeperFactory.RightSvc.Add(right);
				Console.WriteLine("Completed adding Right '{0}'.", name);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error occurred while adding Right '{0}'.", name);
				Console.WriteLine(ex.ToString());
			}
		}

		void ImportApplicationUsers(Application application, XmlNode xNodeApplication)
		{
			var xNodeListApplicationUsers = xNodeApplication.SelectNodes("applicationUsers/user-ref");
			
			foreach(XmlNode node in xNodeListApplicationUsers)
			{
				this.ImportApplicationUser(application, node);
			}
		}
		
		void ImportApplicationUser(Application application, XmlNode node)
		{
			var userName = node.Attributes["name"].Value;
			var roleName = node.Attributes["applicationRole"].Value;
			
			var user = GatekeeperFactory.UserSvc.GetByLoginName(userName);
			var role = GatekeeperFactory.RoleSvc.Get(application, roleName);
			
			if(user == null)
				Console.WriteLine("User '{0}' not found.", userName);
		
			if(role == null)
				Console.WriteLine("Role '{0}' not found.", roleName);
			
			var appUser = new ApplicationUser(){Application = application, User = user, Role = role};
			
			if(user != null && role != null)
			{
				try
				{
					GatekeeperFactory.ApplicationUserSvc.Save(appUser);
					
					Console.WriteLine("User '{0}' has been added to the Role '{1}' in Application '{2}'.", userName, roleName, application.Name);
				}
				catch(Exception ex)
				{
					Console.WriteLine("Error occurred while adding User '{0}' to the Role '{1}' in Application '{2}'.", userName, roleName, application.Name);
				}

			}
		}
	}
}

