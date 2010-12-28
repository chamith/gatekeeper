using System;
namespace Gatekeeper
{
	public class AuthorizationSvc
	{
		public AuthorizationSvc ()
		{
	
		}
		
		public void AddSystemSecurableObject(SecurableApplication application)
		{
			#region Adding the application initialization data.

			GatekeeperFactory.ApplicationSvc.Add(application);
			
            // adding the system securable object type.
            SecurableObjectType systemObjectType = new SecurableObjectType()
            {
                    Id = 0,
                    Application = application,
                    Name = "System",
					Description = "System Securable Object Type"
            };

            // adding the systemObjectType as a securable object type.
            GatekeeperFactory.SecurableObjectTypeSvc.Add(systemObjectType);

			application.SecurableObjectType = systemObjectType;
			
            // adding the application as a securable object.
            this.AddSecurableObject(application);

            // defining the system administrator role.
            Role systemAdministerRole = new Role()
            {
                Application = application,
                Name = "Administrator",
                Description = "Administers the System",
                SecurableObjectType = systemObjectType
            };

            // defining the system user role.
            Role systemUserRole = new Role()
            {
                Application = application,
                Name = "User",
                Description = "Uses the System",
                SecurableObjectType = systemObjectType
            };

            // adding the system administrator and the system user roles.
            IRoleSvc roleSvc = GatekeeperFactory.RoleSvc;
            roleSvc.Add(systemAdministerRole);//adding the systemAdministerRole as a role.
            roleSvc.Add(systemUserRole);//adding the systemUserRole as a role.

            // defining the Administer_System right.
            Right administerSystemRight = new Right()
            {
                Application = application,
                Name = "Administer_System",
                Description = "Administers the System",
                SecurableObjectType = systemObjectType
            };

            // defining the View_System right.
            Right viewSystemRight = new Right()
            {
                Application = application,
                Name = "View_System",
                Description = "Views the System",
                SecurableObjectType = systemObjectType
            };

            // adding the Administer_System and the View_System rights.
            IRightSvc rightSvc = GatekeeperFactory.RightSvc;
            rightSvc.Add(administerSystemRight);//adding the administerSystemRight as a right.
            rightSvc.Add(viewSystemRight);//adding the viewSystemRight as a right.

            // adding the role-right assignment (System Admin - Administer_System)
			RoleRightAssignment admin_administer = new RoleRightAssignment()
            {
                Application = application,
                Role = systemAdministerRole,
                Right = administerSystemRight,
                SecurableObjectType = systemObjectType
            };
			
            // adding the role-right assignment (System Admin - View_System)
			RoleRightAssignment admin_view = new RoleRightAssignment()
            {
                Application = application,
                Role = systemAdministerRole,
                Right = viewSystemRight,
                SecurableObjectType = systemObjectType
            };
			
            // adding the role-right assignment (System User - View_System)
			RoleRightAssignment user_view = new RoleRightAssignment()
            {
                Application = application,
                Role = systemUserRole,
                Right = viewSystemRight,
                SecurableObjectType = systemObjectType
            };


            IRoleRightAssignmentSvc rraSvc = GatekeeperFactory.RoleRightAssignmentSvc;
			rraSvc.Add(admin_administer);
			rraSvc.Add(admin_view);
			rraSvc.Add(user_view);

            #endregion
		}
		
		public void AddSecurableObject(ISecurableObject securableObject)
		{
			SecurableObject obj = new SecurableObject()
			{
				Application = securableObject.Application,
				SecurableObjectType = securableObject.SecurableObjectType,
				Guid = securableObject.SecurableObjectGuid
			};
			
			GatekeeperFactory.SecurableObjectSvc.Add(obj);
		}
		
//		public void SetApplicationUser(Application application, User user, Role role)
//		{
//			application = GatekeeperFactory.ApplicationSvc.Get(application.Id);
//			SecurableObject appSecObject = GatekeeperFactory.SecurableObjectSvc.Get(application.Guid);
//			UserRoleAssignment applicationUserRole;
//			ApplicationUser appUser;
//			
//			appUser = new ApplicationUser()
//			{
//				Application = application,
//				User = user
//			};
//			
//			applicationUserRole = new UserRoleAssignment()
//			{
//				Application = application,
//				Role = role,
//				User = user,
//				SecurableObjectId = appSecObject.Id
//			};
//		
//			GatekeeperFactory.ApplicationUserSvc.Save(appUser);
//			GatekeeperFactory.UserRoleAssignmentSvc.Add(applicationUserRole);
//		}
//		
//		public ApplicationUser GetApplicationUser(Application application, User user)
//		{
//			ApplicationUser appUser = GatekeeperFactory.ApplicationUserSvc.Get(application, user);
//			
//			application = GatekeeperFactory.ApplicationSvc.Get(application.Id);
//			SecurableObject appSecObject = GatekeeperFactory.SecurableObjectSvc.Get(application.Guid);
//			UserRoleAssignment userRoleAssignment = GatekeeperFactory.UserRoleAssignmentSvc.Get(application, user, appSecObject);
//		}
	}
}

