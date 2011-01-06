using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of UserRoleAssignment,it represents a role assigned to a particular user.
    /// </summary>
    public class UserRoleAssignment:BaseEntity
    {
        /// <summary>
        /// Gets or sets the user,to whom the role is assigned..
        /// </summary>
        /// <value>The user.</value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the role assigned to the user.
        /// </summary>
        /// <value>The role.</value>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the securable object id for which the user gets the role assignment..
        /// </summary>
        /// <value>The securable object id.</value>
        public long SecurableObjectId { get; set; }

        public SecurableObjectType SecurableObjectType { get; set; }
       
        /// <summary>
        /// Gets or sets the application in which the user gets the role assignment..
        /// </summary>
        /// <value>The application.</value>
        public Application Application { get; set; }

        public ISecurableObject SecurableObject { get; set; }
    }
}
