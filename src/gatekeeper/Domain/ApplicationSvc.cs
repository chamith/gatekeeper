using System;
using Gatekeeper.Data;
using System.Collections.Generic;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of ApplicationSvc class.
    /// </summary>
    public class ApplicationSvc : BaseSvc, IApplicationSvc
    {
        ApplicationDao applicationDao;

        /// <summary>
        /// Initializes a new instance of the ApplicationSvc class by creating an instance of ApplicationDao class.
        /// </summary>
        public ApplicationSvc()
        {
            this.applicationDao = new ApplicationDao();
        }

        /// <summary>
        /// Gets the Application object of a specified application GUID.
        /// </summary>
        /// <param name="applicationGuid">The application GUID.</param>
        /// <returns></returns>
        public Application Get(Guid applicationGuid)
        {
            return this.applicationDao.Get(applicationGuid);
            
        }

        /// <summary>
        /// Gets the Application object of a specified application id.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns></returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public Application Get(long applicationId)
        {
            return this.applicationDao.Get(applicationId);
        }

        /// <summary>
        /// Gets all the Application object from the system,it returns a list of Application object
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public IList<Application> Get()
        {
            return this.applicationDao.Get();
        }


        /// <summary>
        /// Adds the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void Add(Application application)
        {
			application.Guid = Guid.NewGuid();
            //inserts the application into the system.
			Console.WriteLine("Adding an Application with Guid:{0}", application.Guid);
            this.applicationDao.Add(application);
        }

        /// <summary>
        /// Updates the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Update(Application application)
        {
            this.applicationDao.Update(application);
        }

        /// <summary>
        /// Deletes the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Delete(Application application)
        {
            this.applicationDao.Delete(application);
        }

    }
}
