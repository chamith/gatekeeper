using System;
using System.Collections.Generic;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    public interface IApplicationSvc
	{

        /// <summary>
        /// Gets the Application object of a specified application GUID.
        /// </summary>
        /// <param name="applicationGuid">The application GUID.</param>
        /// <returns></returns>
        Application Get(Guid applicationGuid);

        /// <summary>
        /// Gets the Application object of a specified application id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns></returns>
        Application Get(long applicationId);

        /// <summary>
        /// Gets all the Application object from the system,it returns a list of Application object
        /// </summary>
        /// <returns></returns>
        IList<Application> Get();

        /// <summary>
        /// Adds the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        void Add(Application application);

        /// <summary>
        /// Updates the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        void Update(Application application);

        /// <summary>
        /// Deletes the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        void Delete(Application application);

    }
}
