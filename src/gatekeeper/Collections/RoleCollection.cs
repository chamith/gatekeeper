using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Gatekeeper.Collections
{

    /// <summary>
    /// Summary of  RoleCollection.Represents a collection of roles.
    /// </summary>
    public class RoleCollection : KeyedCollection<long, Role>
    {

        /// <summary>
        /// Initializes a new instance of the RoleCollection class.
        /// </summary>
        public RoleCollection()
        {
        }

        public Role this[string roleName]
        {
            get
            {
                foreach(Role role in this)
                {
                    if (role.Name == roleName)
                        return role;
                }

                return null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the RoleCollection class with roles as a parameter.
        /// </summary>
        /// <param name="roles">The roles,Ilist collection of Role.</param>
        public RoleCollection(IList<Role> roles)
        {
            foreach (Role role in roles)
                this.Add(role);
        }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override long GetKeyForItem(Role item)
        {
            return item.Id;
        }
    }
}
