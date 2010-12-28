using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper
{

    public interface ISecurableObjectSvc
    {
        /// <summary>
        /// Saves the specified securable object,inserts the ISecurableObject object into the system .
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        void Save(SecurableObject securableObject);

        /// <summary>
        /// Adds the specified securable object,inserts the ISecurableObject object.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        void Add(SecurableObject securableObject);

		/// <summary>
        /// Deletes the specified securable object.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        void Delete(SecurableObject securableObject);
		
        /// <summary>
        /// Gets the new securable object GUID.
        /// </summary>
        /// <returns></returns>
        Guid GetNewSecurableObjectGuid();

        SecurableObject Get(Guid guid);
    }
}
