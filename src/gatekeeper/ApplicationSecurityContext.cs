using System;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    /// <summary>
    /// Represents a context where the security information of an application is kept.
    /// </summary>
    public class ApplicationSecurityContext
    {
		static log4net.ILog log = log4net.LogManager.GetLogger(typeof(ApplicationSecurityContext));
        
		/// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        public Application Application { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public RoleCollection Roles { get; set; }

        /// <summary>
        /// Gets or sets the rights.
        /// </summary>
        /// <value>The rights.</value>
        public RightCollection Rights { get; set; }

        /// <summary>
        /// Gets or sets the role right assignments.
        /// </summary>
        /// <value>The role right assignments.</value>
        public RoleRightAssignmentCollection RoleRightAssignments { get; set; }

        /// <summary>
        /// Gets or sets the securable object types.
        /// </summary>
        /// <value>The securable object types.</value>
        public SecurableObjectTypeCollection SecurableObjectTypes { get; set; }

        /// <summary>
        /// Initializes a new instance of the ApplicationSecurityContext class with applicationGuid.
        /// </summary>
        /// <param name="applicationGuid">The application GUID.</param>
        public ApplicationSecurityContext(Guid applicationGuid)
        {
            Application app = GatekeeperFactory.ApplicationSvc.Get(applicationGuid);

            if (app == null)
                throw new ApplicationException("Application not found.");

            this.Initialize(app);
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationSecurityContext class with applicationGuid.
        /// </summary>
        /// <param name="applicationGuid">The application GUID as a string</param>
        public ApplicationSecurityContext(string applicationGuid):this(new Guid(applicationGuid))
        {
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationSecurityContext class with application.
        /// </summary>
        /// <param name="application">The application.</param>
        public ApplicationSecurityContext(Application application)
        {
            this.Initialize(application);
        }

        /// <summary>
        /// Initializes the specified application,it lets roles,rights,securableobject-types,role-right-assignments of that specified application to be initialized.
        /// </summary>
        /// <param name="application">The application.</param>
        private void Initialize(Application application)
        {   //sets the property Application to application
            this.Application = application;
            
            //gets the collection of roles of specified application and assign that to property Roles. 
            this.Roles = GatekeeperFactory.RoleSvc.Get(this.Application);
			#region logging
			log.Debug("Loaded Application Roles:");
			foreach(var role in this.Roles) log.Debug(role.Name);

			#endregion

            //gets the collection of rights of specified application and assign that to property Rights. 
            this.Rights = GatekeeperFactory.RightSvc.Get(this.Application);

            //gets the collection of securableObjectType of specified application and assign that to SecurableObjectTypes. 
            this.SecurableObjectTypes = GatekeeperFactory.SecurableObjectTypeSvc.Get(this.Application);

            //gets the collection of roleRightAssignment of specified application and assign that to RoleRightAssignments. 
            this.RoleRightAssignments = GatekeeperFactory.RoleRightAssignmentSvc.Get(this.Application);

            //Initializes Right,Role,SecurableObjectType of every RoleRightAssignment object in RoleRightAssignments collection.
            foreach (RoleRightAssignment rra in this.RoleRightAssignments)
            {
                rra.Right = this.Rights[rra.Right.Id];
                rra.Role = this.Roles[rra.Role.Id];
                rra.SecurableObjectType = this.SecurableObjectTypes[rra.SecurableObjectType.Id];
                rra.Right.SecurableObjectType = rra.SecurableObjectType;
                rra.Role.SecurableObjectType = rra.SecurableObjectType;
            }
        }

        /// <summary>
        /// Gets the collection of roles of a specified right.
        /// </summary>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public RoleCollection GetRoles(Right right)
        {
            RoleCollection roles = new RoleCollection();

            //Checking whether that specified right is in each and every Role-Right-assignment object of RoleRightAssignments collection.
            //If it is there,find the role of that Role-Right-Assignment object and add that to RoleCollection-roles.
            foreach (RoleRightAssignment rra in this.RoleRightAssignments)
            {
                if (rra.Right.Id == right.Id)
                    roles.Add(rra.Role);
            }

            //returns the RoleCollection.
            return roles;
        }

        /// <summary>
        /// Gets the collection of rights of a specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public RightCollection GetRights(Role role)
        {
            RightCollection rights = new RightCollection();

            //Checking whether that specified role is in each and every Role-Right-assignment object of RoleRightAssignments collection.
            //If it is there,find the right of that Role-Right-Assignment object and add that to RightCollection-rights.
            foreach (RoleRightAssignment rra in this.RoleRightAssignments)
            {
                if (rra.Role.Id == role.Id)
                    rights.Add(rra.Right);
            }

            //returns the RightCollection.
            return rights;
        }
    }
}
