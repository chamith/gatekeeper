using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Collections;

namespace Gatekeeper
{

    public interface ISecurableObjectTypeSvc
    {
        /// <summary>
        /// Gets the list of SecurableObjectType objects of a specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
        SecurableObjectTypeCollection Get(Application application);

        /// <summary>
        /// Gets the SecurableObjectType of a specified application and securableObjectTypeId.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
        /// <returns></returns>
        SecurableObjectType Get(long securableObjectTypeId);
		
        SecurableObjectType Get(Application application, string name);

        /// <summary>
        /// Adds the specified securable object type,inserts SecurableObjectType object into the system .
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
        void Add(SecurableObjectType securableObjectType);
		
        /// <summary>
        /// Updates the specified securable object type.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
        void Update(SecurableObjectType securableObjectType);

        /// <summary>
        /// Deletes the specified securable object type.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
        void Delete(SecurableObjectType securableObjectType);
        void Save(SecurableObjectType securableObjectType);
    }
}
