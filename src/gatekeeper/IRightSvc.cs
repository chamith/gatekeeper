using System;
using System.Collections.Generic;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    public interface IRightSvc
    {
        /// <summary>
        /// Gets all the rights of a specified application,it returns collection of rights.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        RightCollection Get(Application application);

        /// <summary>
        /// Gets the right object of a specified right id.
        /// </summary>
        /// <param name="rightId">The right id.</param>
        /// <returns></returns>
        Right Get(long rightId);
		Right Get(Application application, string name);
        /// <summary>
        /// Gets all the rights of a specified role,it returns collection of rights.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        RightCollection Get(Role role);

        /// <summary>
        /// Gets all the rights of a specified securable object type,it returns a collection of rights.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
        /// <returns></returns>
        RightCollection Get(SecurableObjectType securableObjectType);

        /// <summary>
        /// Adds the specified right,inserts right into the system.
        /// </summary>
        /// <param name="right">The right.</param>
        void Add(Right right);

        /// <summary>
        /// Adds the specified rights,adding Right objects into RightCollection.
        /// </summary>
        /// <param name="rights">The rights.</param>
        void Add(RightCollection rights);

        /// <summary>
        /// Updates the specified right.
        /// </summary>
        /// <param name="right">The right.</param>
        void Update(Right right);

        /// <summary>
        /// Deletes the specified right.
        /// </summary>
        /// <param name="right">The right.</param>
        void Delete(Right right);
    }
}
