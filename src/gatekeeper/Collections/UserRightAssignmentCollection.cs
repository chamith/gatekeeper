using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{
    /// /// <summary>
    /// Summary of UserRightAssignmentCollection.Represents a collection of UserRightAssignments.
    /// </summary>
    public class UserRightAssignmentCollection:List<UserRightAssignment>
    {

        /// <summary>
        /// Initializes a new instance of the UserRightAssignmentCollection.
        /// </summary>
        public UserRightAssignmentCollection() { }



        /// <summary>
        /// Initializes a new instance of the UserRightAssignmentCollection class with assignments as parameters.
        /// </summary>
        /// <param name="assignments">The assignment,Ilist collection of UserRightAssignment class.</param>
        public UserRightAssignmentCollection(IList<UserRightAssignment> assignments)
        {
            this.AddRange(assignments);
        }
    }
}
