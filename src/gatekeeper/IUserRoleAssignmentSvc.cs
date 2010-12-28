using System;
using System.Collections.Generic;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    public interface IUserRoleAssignmentSvc
    {
        UserRoleAssignmentCollection Get(Application application, User user);
        UserRoleAssignment Get(Application application, User user, SecurableObject securableObject);
        UserRoleAssignmentCollection Get(Application application, Role role, Guid securableObjectGUID);
        UserRoleAssignment Get(User user, Role role, Guid securableObjectGUID);
		UserRoleAssignmentCollection GetUsersByApplication(Application application);
        void Save(Application application, User user, Role role, ISecurableObject securableObject);
        void Save(Application application, User user, Role role, SecurableObject securableObject);
        void Save(UserRoleAssignment userRoleAssignment);
        /// <summary>
        /// Adds the specified role,inserts the object role into the system.
        /// </summary>
        /// <param name="role">The role.</param>
        void Add(UserRoleAssignment userRoleAssignment);
        /// <summary>
        /// Adds the specified roles,adding the Role objects into the RoleCollection.
        /// </summary>
        /// <param name="roles">The roles.</param>
        void Add(UserRoleAssignmentCollection userRoleAssignments);
        /// <summary>
        /// Deletes the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        void Delete(Role role);
        void Delete(UserRoleAssignmentCollection userRoleAssignments);
		void Delete(UserRoleAssignment userRoleAssignment);
    }
}
