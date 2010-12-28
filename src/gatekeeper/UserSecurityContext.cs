using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of UserSecurityContext class.
    /// </summary>
    public class UserSecurityContext
    {

        /// <summary>
        /// Initializes a new instance of the UserSecurityContext class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="appSecContext">The app sec context.</param>
        public UserSecurityContext(User user, ApplicationSecurityContext appSecContext)
        {
            this.ApplicationSecurityContext = appSecContext;
            this.Initialize(user);
        }

        /// <summary>
        /// Initializes a new instance of the UserSecurityContext class.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="appSecContext">The app sec context.</param>
        public UserSecurityContext(string userEmail, ApplicationSecurityContext appSecContext)
        {
            User user = GatekeeperFactory.UserSvc.GetByLoginName(userEmail);

            if (user == null)
                throw new ApplicationException("User not found.");

            this.ApplicationSecurityContext = appSecContext;
            this.Initialize(user);
        }

        /// <summary>
        /// Initializes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        private void Initialize(User user)
        {
            this.User = user;
            this.RoleAssignments =
                GatekeeperFactory.UserRoleAssignmentSvc.Get(this.ApplicationSecurityContext.Application, this.User);
            this.RightAssignments =
                GatekeeperFactory.UserRightAssignmentSvc.GetByApplicationUser(this.ApplicationSecurityContext.Application, this.User);
        }

        public void Refresh()
        {
            this.Initialize(this.User);
        }

        /// <summary>
        /// Gets or sets the user of teh application.
        /// </summary>
        /// <value>The user.</value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the application security context.
        /// </summary>
        /// <value>The application security context.</value>
        public ApplicationSecurityContext ApplicationSecurityContext { get; set; }

        /// <summary>
        /// Gets or sets the role assignments-UserRoleAssignmentCollection.
        /// </summary>
        /// <value>The role assignments.</value>
        public UserRoleAssignmentCollection RoleAssignments { get; set; }

        /// <summary>
        /// Gets or sets the right assignments-UserRightAssignmentCollection.
        /// </summary>
        /// <value>The right assignments.</value>
        public UserRightAssignmentCollection RightAssignments { get; set; }

    }
}
