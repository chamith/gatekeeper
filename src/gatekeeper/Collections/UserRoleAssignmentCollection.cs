using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{

    /// <summary>
    /// Summary of UserRoleAssignmentCollection class.It represents a collection of user-role assignments.
    /// </summary>
    public class UserRoleAssignmentCollection:List<UserRoleAssignment>
    {
        /// <summary>
        /// Initializes a new instance of the UserRoleAssignmentCollection class.
        /// </summary>
        public UserRoleAssignmentCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleAssignmentCollection"/> class.
        /// </summary>
        /// <param name="assignments">The assignments,Ilist collection of UserRoleAssignment.</param>
        public UserRoleAssignmentCollection(IList<UserRoleAssignment> assignments)
        {
            this.AddRange(assignments);
        }
    }
}
