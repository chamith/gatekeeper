using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Core;

namespace Gatekeeper
{ 
    /// <summary>
    /// Summary of RoleRightAssignment,it represents an assignment of a right to a role.
    /// </summary>
    public class RoleRightAssignment:BaseEntity
    {

        /// <summary>
        /// Gets or sets the role to which the right is assigned.
        /// </summary>
        /// <value>The role.</value>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the right assign to the role.
        /// </summary>
        /// <value>The right.</value>
        public Right Right { get; set; }
      
        /// <summary>
        /// Gets or sets the application to which the role belongs.
        /// </summary>
        /// <value>The application.</value>
        public Application Application { get; set; }
      
        /// <summary>
        /// Gets or sets the type of the securable object to which the role right assignment applies.
        /// </summary>
        /// <value>The type of the securable object.</value>
        public SecurableObjectType SecurableObjectType { get; set; }

    }
}
