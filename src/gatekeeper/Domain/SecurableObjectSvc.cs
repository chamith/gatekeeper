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
    public class SecurableObjectSvc:BaseSvc, ISecurableObjectSvc
    {
        SecurableObjectDao securableObjectDao;

        /// <summary>
        /// Initializes a new instance of the SecurableObjectSvc class by creating a object of SecurableObjectDao Class .
        /// </summary>
        public SecurableObjectSvc()
        {
            this.securableObjectDao = new SecurableObjectDao();
        }
        /// <summary>
        /// Saves the specified securable object,inserts the ISecurableObject object into the system .
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        public void Save(SecurableObject securableObject)
        {
            //securableObject.SecurableObjectGuid = this.GetNewSecurableObjectGuid();
            this.securableObjectDao.Add(securableObject);
        }

        /// <summary>
        /// Adds the specified securable object,inserts the ISecurableObject object.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        public void Add(SecurableObject securableObject)
        {
            this.securableObjectDao.Add(securableObject);
        }
		
		/// <summary>
        /// Adds the specified securable object,inserts the ISecurableObject object.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        public void Add(ISecurableObject securableObject)
        {
			SecurableObject obj = new SecurableObject()
			{
				Application = securableObject.Application,
				SecurableObjectType = securableObject.SecurableObjectType,
				Guid = securableObject.SecurableObjectGuid
			};
			
            this.securableObjectDao.Add(obj);
        }
		
        /// <summary>
        /// Deletes the specified securable object.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        public void Delete(SecurableObject securableObject)
        {
            this.securableObjectDao.Delete(securableObject);
        }
        /// <summary>
        /// Gets the new securable object GUID.
        /// </summary>
        /// <returns></returns>
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
