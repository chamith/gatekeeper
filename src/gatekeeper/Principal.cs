using System;
using System.Security.Principal;
using System.Globalization;

namespace Gatekeeper
{

    /// <summary>
    /// Summary of Principal class.
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
    /// 				<description>9/29/2008</description>
    /// 				<description>Chamith Siriwardena</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    [Serializable]
    public class Principal : IPrincipal
    {
        private IIdentity identity;
        private UserRightAssignment[] userRightAssignments;

        /// <summary>
        /// Initializes a new instance of the Principal class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="userRightAssignments">The user right assignments-array.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/29/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public Principal(IIdentity identity, UserRightAssignment[] userRightAssignments)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }

            this.identity = identity;
            this.userRightAssignments = (UserRightAssignment[])userRightAssignments.Clone();
          
        }

        /// <summary>
        /// Initializes a new instance of the Principal class.
        /// </summary>
        /// <param name="userSecurityContext">The user security context.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/29/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public Principal(UserSecurityContext userSecurityContext)
        {
            if (userSecurityContext == null)
            {
                throw new ArgumentNullException("userSecurityContext");
            }

            this.identity = userSecurityContext.User;
            this.userRightAssignments = (UserRightAssignment[])userSecurityContext.RightAssignments.ToArray().Clone();

        }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <param name="role">The name of the role for which to check gatekeeper.</param>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/29/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public virtual bool IsInRole(string role)
        {
            return false;
        }

        /// <summary>
        /// Determines whether the specified securable object GUID has right.
        /// </summary>
        /// <param name="securableObjectGUID">The securable object GUID.</param>
        /// <param name="rightName">Name of the right.</param>
        /// <returns>
        /// 	<c>true</c> if the specified securable object GUID has right; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/29/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public virtual bool HasRight(long securableObjectId, string rightName)
        {
            if ((rightName != null) && (this.userRightAssignments != null))
            {
                for (int i = 0; i < this.userRightAssignments.Length; i++)
                {
                    if ((this.userRightAssignments[i] != null) && (string.Compare(this.userRightAssignments[i].Right.Name, rightName, true, CultureInfo.InvariantCulture) == 0) && (this.userRightAssignments[i].SecurableObjectId == securableObjectId))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified securable object has right.
        /// </summary>
        /// <param name="securableObject">The securable object.</param>
        /// <param name="rightName">Name of the right.</param>
        /// <returns>
        /// 	<c>true</c> if the specified securable object has right; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/29/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public virtual bool HasRight(ISecurableObject securableObject, string rightName)
        {
            return this.HasRight(securableObject.SecurableObjectId, rightName);
        }

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="T:System.Security.Principal.IIdentity"/> object associated with the current principal.</returns>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/29/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public virtual IIdentity Identity
        {
            get
            {
                return this.identity;
            }
        }

    }
}

