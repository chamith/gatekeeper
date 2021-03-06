using System;
using Gatekeeper.Data;
using System.Collections.Generic;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of RightSvc class.
    /// </summary>
    public class RightSvc : BaseSvc, IRightSvc
    {
        RightDao rightDao;

        /// <summary>
        /// Initializes a new instance of the RightSvc class by creating object of RightDao.
        /// </summary>
        public RightSvc()
        {
            this.rightDao = new RightDao();
        }

        /// <summary>
        /// Gets all the rights of a specified application,it returns collection of rights.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        public RightCollection Get(Application application)
        {
            return this.rightDao.Get(application);
        }

        /// <summary>
        /// Gets the right object of a specified right id.
        /// </summary>
        /// <param name="rightId">The right id.</param>
        /// <returns></returns>
        public Right Get(long rightId)
        {
            return this.rightDao.Get(rightId);
        }
		
        /// <summary>
        /// Gets the right object of a specified right id.
        /// </summary>
        /// <param name="rightId">The right id.</param>
        /// <returns></returns>
        public Right Get(Application application, string name)
        {
            return this.rightDao.Get(application, name);
        }        
		
		/// <summary>
        /// Gets all the rights of a specified role,it returns collection of rights.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public RightCollection Get(Role role)
        {
            return this.rightDao.Get(role);
        }

        /// <summary>
        /// Gets all the rights of a specified securable object type,it returns a collection of rights.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
        /// <returns></returns>
        public RightCollection Get(SecurableObjectType securableObjectType)
        {
            return this.rightDao.Get(securableObjectType);
        }

        /// <summary>
        /// Adds the specified right,inserts right into the system.
        /// </summary>
        /// <param name="right">The right.</param>
        public void Add(Right right)
        {
            this.rightDao.Add(right);
        }

        /// <summary>
        /// Adds the specified rights,adding Right objects into RightCollection.
        /// </summary>
        /// <param name="rights">The rights.</param>
        public void Add(RightCollection rights)
        {
            foreach (Right right in rights)
                this.Add(right);
        }

        /// <summary>
        /// Updates the specified right.
        /// </summary>
        /// <param name="right">The right.</param>
        public void Update(Right right)
        {
            this.rightDao.Update(right);
        }

        /// <summary>
        /// Deletes the specified right.
        /// </summary>
        /// <param name="right">The right.</param>
        public void Delete(Right right)
        {
            this.rightDao.Delete(right);
        }
    }
}
