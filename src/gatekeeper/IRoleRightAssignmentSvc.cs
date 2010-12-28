using System;
using System.Collections.Generic;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    public interface IRoleRightAssignmentSvc
    {
        /// <summary>
        /// Gets all the Role-Right-Assignment objects of a specified role,it returns a collection of Role-Right-Assignment objects.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        RoleRightAssignmentCollection Get(Role role);
		
        RoleRightAssignmentCollection Get(Application application);
		
        void Add(RoleRightAssignment rra);
		
        
        /// <summary>
        /// Adds the specified role right assignments,adding the RoleRightAssignment objects into RoleRightAssignmentCollection.
        /// </summary>
        /// <param name="roleRightAssignments">The role right assignments.</param>
        void Add(RoleRightAssignmentCollection roleRightAssignments);

        /// <summary>
        /// Deletes the specified role right assignment from the system.
        /// </summary>
        /// <param name="roleRightAssignment">The role right assignment.</param>
        void Delete(RoleRightAssignment roleRightAssignment);

        /// <summary>
        /// Deletes the specified role right assignments,deleting the RoleRightAssignment objects from the RoleRightAssignmentCollection.
        /// </summary>
        /// <param name="roleRightAssignments">The role right assignments.</param>
        void Delete(RoleRightAssignmentCollection roleRightAssignments);
    }
}
