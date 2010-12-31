using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Data;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of SecurableObjectTypeSvc class.
    /// </summary>
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
    public class SecurableObjectTypeSvc:BaseSvc, ISecurableObjectTypeSvc
    {
        SecurableObjectTypeDao securableObjectTypeDao;

        /// <summary>
        /// Initializes a new instance of the SecurableObjectTypeSvc class by creating a object of SecurableObjectTypeDao class .
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/26/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public SecurableObjectTypeSvc()
        {
            this.securableObjectTypeDao = new SecurableObjectTypeDao();
        }

        /// <summary>
        /// Gets the list of SecurableObjectType objects of a specified application.
        /// </summary>
        /// <param name="application">The application.</param>
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
        /// 				<description>9/26/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public SecurableObjectTypeCollection Get(Application application)
        {
            return this.securableObjectTypeDao.Get(application);
        }

        /// <summary>
        /// Gets the SecurableObjectType of a specified application and securableObjectTypeId.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="id">The securable object type id.</param>
        /// <returns></returns>
        public SecurableObjectType Get(long id)
        {
            return this.securableObjectTypeDao.Get(id);
        }

        public SecurableObjectType Get(Application application, string name)
		{
			return this.securableObjectTypeDao.Get(application, name);
		}
		
        /// <summary>
        /// Adds the specified securable object type,inserts SecurableObjectType object into the system .
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
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
        public void Add(SecurableObjectType securableObjectType)
        {
            this.securableObjectTypeDao.Add(securableObjectType);
        }
        /// <summary>
        /// Updates the specified securable object type.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
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
        public void Update(SecurableObjectType securableObjectType)
        {
            this.securableObjectTypeDao.Update(securableObjectType);
        }
		
		public void Save(SecurableObjectType securableObjectType)
        {
			if(securableObjectType.Id == 0)
            	this.securableObjectTypeDao.Add(securableObjectType);
            else
				this.securableObjectTypeDao.Update(securableObjectType);
        }
        /// <summary>
        /// Deletes the specified securable object type.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
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
        public void Delete(SecurableObjectType securableObjectType)
        {
            this.securableObjectTypeDao.Delete(securableObjectType);
        }
    }
}
