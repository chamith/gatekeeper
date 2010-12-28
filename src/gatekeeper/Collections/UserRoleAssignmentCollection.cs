using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{

    /// <summary>
    /// Summary of UserRoleAssignmentCollection class.It represents a collection of user-role assignments.
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
    /// 				<description>09/18/2008</description>
    /// 				<description>Chamith</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    public class UserRoleAssignmentCollection:List<UserRoleAssignment>
    {
        /// <summary>
        /// Initializes a new instance of the UserRoleAssignmentCollection class.
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
        /// 				<description>9/19/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public UserRoleAssignmentCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleAssignmentCollection"/> class.
        /// </summary>
        /// <param name="assignments">The assignments,Ilist collection of UserRoleAssignment.</param>
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
        public UserRoleAssignmentCollection(IList<UserRoleAssignment> assignments)
        {
            this.AddRange(assignments);
        }
    }
}
