using System;
using System.Security;
using System.Security.Permissions;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of PermissionAttribute class.
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class PermissionAttribute : CodeAccessSecurityAttribute
    {
        /// <summary>
        /// Initializes a new instance of the PermissionAttribute class.
        /// </summary>
        /// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction"/> values.</param>
        public PermissionAttribute(SecurityAction action)
            : base(action)
        {
            this.RightName = null;
        }

        /// <summary>
        /// When overridden in a derived class, creates a permission object that can then be serialized into binary form and persistently stored along with the <see cref="T:System.Security.Permissions.SecurityAction"/> in an assembly's metadata.
        /// </summary>
        /// <returns>A serializable permission object.</returns>
        public override IPermission CreatePermission()
        {
            return new Permission(this.SecurableObjectId, this.RightName);
        }

        /// <summary>
        /// Gets or sets the name of the right.
        /// </summary>
        /// <value>The name of the right.</value>
        public string RightName { get; set; }

        /// <summary>
        /// Gets or sets the securable object GUID.
        /// </summary>
        /// <value>The securable object GUID.</value>
        public long SecurableObjectId { get; set; }
    }
}

