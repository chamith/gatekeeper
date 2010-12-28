using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Gatekeeper.Collections
{



    /// <summary>
    /// Summary of  RoleCollection.Represents a collection of roles.
    /// </summary>
    /// ///
    /// <remarks>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<description>modified</description>
    /// 			<description>by</description>
    /// 			<description>description</description>
    /// 		</listheader>
    /// 		<item>
    /// 			<description>9/18/2008</description>
    /// 			<description>Chamith</description>
    /// 			<description>initial code</description>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    public class RoleCollection : KeyedCollection<long, Role>
    {

        /// <summary>
        /// Initializes a new instance of the RoleCollection class.
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
        /// 				<description>9/18/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
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
        /// 
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/18/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
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
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/19/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        protected override long GetKeyForItem(Role item)
        {
            return item.Id;
        }
    }
}
