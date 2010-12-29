using System;
using System.Collections.Generic;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    public interface IRoleSvc
    {
        /// <summary>
        /// Gets all the roles of a specified application,it returns a collection of role objects.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        RoleCollection Get(Application application);

        /// <summary>
        /// Gets the role of a specified role id.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns></returns>
        Role Get(long roleId);

		/// <summary>
        /// Gets the role in a specified application by with a specified name.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="name">The name of the role.</para>
        /// <returns></returns>
        Role Get(Application application, string name);
        
		/// <summary>
        /// Adds the specified role,inserts the object role into the system.
        /// </summary>
        /// <param name="role">The role.</param>
        void Add(Role role);

        /// <summary>
        /// Adds the specified roles,adding the Role objects into the RoleCollection.
        /// </summary>
        /// <param name="roles">The roles.</param>
        void Add(RoleCollection roles);

        /// <summary>
        /// Updates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        void Update(Role role);
		
        /// <summary>
        /// Deletes the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        void Delete(Role role);
    }
}
