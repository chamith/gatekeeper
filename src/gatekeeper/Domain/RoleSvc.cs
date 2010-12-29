using System;
using Gatekeeper.Data;
using System.Collections.Generic;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of RoleSvc class.
    /// </summary>
    public class RoleSvc : BaseSvc, IRoleSvc
    {
        RoleDao roleDao;

        /// <summary>
        /// Initializes a new instance of the RoleSvc class by creating a object of RoleDao class.
        /// </summary>
        public RoleSvc()
        {
            this.roleDao = new RoleDao();
        }

        /// <summary>
        /// Gets all the roles of a specified application,it returns a collection of role objects.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        public RoleCollection Get(Application application)
        {
            return this.roleDao.Get(application);
        }

        /// <summary>
        /// Gets the role of a specified role id.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns></returns>
        public Role Get(long roleId)
        {
            return this.roleDao.Get(roleId);
        }

		/// <summary>
        /// Gets the role of a specified role id.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns></returns>
        public Role Get(Application application, string name)
        {
            return this.roleDao.Get(application, name);
        }
		
        /// <summary>
        /// Adds the specified role,inserts the object role into the system.
        /// </summary>
        /// <param name="role">The role.</param>
        public void Add(Role role)
        {
            this.roleDao.Add(role);
        }

        /// <summary>
        /// Adds the specified roles,adding the Role objects into the RoleCollection.
        /// </summary>
        /// <param name="roles">The roles.</param>
        public void Add(RoleCollection roles)
        {
            foreach (Role role in roles)
                this.Add(role);
        }

        /// <summary>
        /// Updates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void Update(Role role)
        {
            this.roleDao.Update(role);
        }
		
        /// <summary>
        /// Deletes the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void Delete(Role role)
        {
            this.roleDao.Delete(role);
        }
    }
}
