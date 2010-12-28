using System;
using Gatekeeper.Data;
using System.Collections.Generic;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of ApplicationSvc class.
    /// </summary>
    public class ApplicationSvc : BaseSvc, IApplicationSvc
    {
        ApplicationDao applicationDao;

        /// <summary>
        /// Initializes a new instance of the ApplicationSvc class by creating an instance of ApplicationDao class.
        /// </summary>
        public ApplicationSvc()
        {
            this.applicationDao = new ApplicationDao();
        }

        /// <summary>
        /// Gets the Application object of a specified application GUID.
        /// </summary>
        /// <param name="applicationGuid">The application GUID.</param>
        /// <returns></returns>
        public Application Get(Guid applicationGuid)
        {
            return this.applicationDao.Get(applicationGuid);
            
        }

        /// <summary>
        /// Gets the Application object of a specified application id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns></returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public Application Get(long applicationId)
        {
            return this.applicationDao.Get(applicationId);
        }

        /// <summary>
        /// Gets all the Application object from the system,it returns a list of Application object
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public IList<Application> Get()
        {
            return this.applicationDao.Get();
        }


        /// <summary>
        /// Adds the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void Add(Application application)
        {
			application.Guid = Guid.NewGuid();
            //inserts the application into the system.
			Console.WriteLine("Adding an Application with Guid:{0}", application.Guid);
            this.applicationDao.Add(application);
			this.InitializeApplication(application);
        }

        /// <summary>
        /// Updates the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Update(Application application)
        {
            this.applicationDao.Update(application);
        }

        /// <summary>
        /// Deletes the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Delete(Application application)
        {
            this.applicationDao.Delete(application);
        }

		private void InitializeApplication(Application application)
		{
			var securableApplication = new SecurableApplication();
			securableApplication.CopyFrom(application);
			
			// adding the system securable object type.
            SecurableObjectType systemObjectType = new SecurableObjectType()
            {
                    Id = 0,
                    Application = securableApplication,
                    Name = "System",
					Description = "System Securable Object Type"
            };

            // adding the systemObjectType as a securable object type.
            GatekeeperFactory.SecurableObjectTypeSvc.Add(systemObjectType);

			securableApplication.SecurableObjectType = systemObjectType;
			
            // adding the application as a securable object.
            GatekeeperFactory.SecurableObjectSvc.Add(securableApplication as ISecurableObject);

            // defining the system administrator role.
            Role systemAdministerRole = new Role()
            {
                Application = securableApplication,
                Name = "Administrator",
                Description = "Administers the System",
                SecurableObjectType = systemObjectType
            };

            // defining the system user role.
            Role systemUserRole = new Role()
            {
                Application = securableApplication,
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
                Application = securableApplication,
                Name = "Administer_System",
                Description = "Administers the System",
                SecurableObjectType = systemObjectType
            };

            // defining the View_System right.
            Right viewSystemRight = new Right()
            {
                Application = securableApplication,
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
                Application = securableApplication,
                Role = systemAdministerRole,
                Right = administerSystemRight,
                SecurableObjectType = systemObjectType
            };
			
            // adding the role-right assignment (System Admin - View_System)
			RoleRightAssignment admin_view = new RoleRightAssignment()
            {
                Application = securableApplication,
                Role = systemAdministerRole,
                Right = viewSystemRight,
                SecurableObjectType = systemObjectType
            };
			
            // adding the role-right assignment (System User - View_System)
			RoleRightAssignment user_view = new RoleRightAssignment()
            {
                Application = securableApplication,
                Role = systemUserRole,
                Right = viewSystemRight,
                SecurableObjectType = systemObjectType
            };


            IRoleRightAssignmentSvc rraSvc = GatekeeperFactory.RoleRightAssignmentSvc;
			rraSvc.Add(admin_administer);
			rraSvc.Add(admin_view);
			rraSvc.Add(user_view);
		}
    }
}
