using System;
using System.Collections.Generic;
using System.Text;
using Gatekeeper.Data;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of SecurableObjectSvc class.
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
    public class SecurableObjectSvc:BaseSvc, ISecurableObjectSvc
    {
        SecurableObjectDao securableObjectDao;

        /// <summary>
        /// Initializes a new instance of the SecurableObjectSvc class by creating a object of SecurableObjectDao Class .
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
        public SecurableObjectSvc()
        {
            this.securableObjectDao = new SecurableObjectDao();
        }
        /// <summary>
        /// Saves the specified securable object,inserts the ISecurableObject object into the system .
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
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
        public void Save(SecurableObject securableObject)
        {
            //securableObject.SecurableObjectGuid = this.GetNewSecurableObjectGuid();
            this.securableObjectDao.Add(securableObject);
        }

        /// <summary>
        /// Adds the specified securable object,inserts the ISecurableObject object.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
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
        public void Add(SecurableObject securableObject)
        {
            this.securableObjectDao.Add(securableObject);
        }
        /// <summary>
        /// Deletes the specified securable object.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
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
        public void Delete(SecurableObject securableObject)
        {
            this.securableObjectDao.Delete(securableObject);
        }
        /// <summary>
        /// Gets the new securable object GUID.
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
        public Guid GetNewSecurableObjectGuid()
        {
            return Guid.NewGuid();
            
        }
        public SecurableObject Get(Guid guid)
        {
            return securableObjectDao.Get(guid);

        }
    }
}
