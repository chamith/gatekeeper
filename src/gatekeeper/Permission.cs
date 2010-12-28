namespace Gatekeeper
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Security;
    using System.Security.Principal;
    using System.Threading;
    using System.Security.Permissions;
    using Gatekeeper.Collections;

    /// <summary>
    /// Summary of Permission class.
    /// </summary>
    [Serializable]
    public class Permission : IPermission, IUnrestrictedPermission, ISecurityEncodable
    {
        
        private ObjectRightCollection objectRights;

        /// <summary>
        /// Initializes a new instance of the Permission class.
        /// </summary>
        public Permission()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Permission class.
        /// </summary>
        /// <param name="objectRights">The object rights.</param>
        public Permission(ObjectRightCollection objectRights)
        {
            //assings objectRights to property ObjectRights.
            this.ObjectRights = objectRights;
        }

        /// <summary>
        /// Initializes a new instance of the Permission class with .
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        /// <param name="rightName">Name of the right.</param>
        public Permission(ISecurableObject securableObject, string rightName)
        {
            this.AddObjectRight(securableObject, rightName);
        }

        public Permission(ISecurableObject securableObject, string[] rightNames)
        {
            foreach (string rightName in rightNames)
            {
                this.AddObjectRight(securableObject, rightName);
            }
        }

        public Permission(long securableObjectId, string rightName)
        {
            this.AddObjectRight(securableObjectId, rightName);
        }

        public void AddObjectRight(ISecurableObject securableObject, string rightName)
        {
			securableObject.SecurableObjectId = GatekeeperFactory.SecurableObjectSvc.Get(securableObject.SecurableObjectGuid).Id;
            this.ObjectRights.Add(new ObjectRight(securableObject, rightName));
        }

        public void AddObjectRight(long securableObjectId, string rightName)
        {
            this.ObjectRights.Add(new ObjectRight(securableObjectId, rightName));
        }

        /// <summary>
        /// Gets or sets the object rights-ObjectRightCollection.
        /// </summary>
        /// <value>The object rights.</value>
        public ObjectRightCollection ObjectRights
        {
            get
            {
                if (this.objectRights == null)
                    this.objectRights = new ObjectRightCollection();

                return this.objectRights;
            }
            set
            {
                this.objectRights = value;
            }
        }

        #region IPermission Members

        public IPermission Copy()
        {
            return new Permission(objectRights);
        }

        public void Demand()
        {
            Principal currentPrincipal = (Principal)Thread.CurrentPrincipal;

            if (currentPrincipal == null)
            {
                throw new SecurityException("current principal is not set.");
            }

            bool hasRight = false;

            foreach (ObjectRight objectRight in this.objectRights)
            {
                if (objectRight != null)
                {
                    if (hasRight = currentPrincipal.HasRight(objectRight.SecurableObjectId, objectRight.Right.Name))
                        break;
                }
            }

            if(!hasRight)
                throw new SecurityException(
                    "current principal does not have sufficient permission to perform this operation.");

        }

        public IPermission Intersect(IPermission target)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsSubsetOf(IPermission target)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IPermission Union(IPermission target)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region ISecurityEncodable Members

        public void FromXml(SecurityElement e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public SecurityElement ToXml()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IUnrestrictedPermission Members

        public bool IsUnrestricted()
        {
            return false;
        }

        #endregion

    }
}

