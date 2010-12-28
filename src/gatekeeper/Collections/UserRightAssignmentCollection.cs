using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{
    /// /// <summary>
    /// Summary of UserRightAssignmentCollection.Represents a collection of UserRightAssignments.
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
    public class UserRightAssignmentCollection:List<UserRightAssignment>
    {

        /// <summary>
        /// Initializes a new instance of the UserRightAssignmentCollection.
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
        public UserRightAssignmentCollection() { }



        /// <summary>
        /// Initializes a new instance of the UserRightAssignmentCollection class with assignments as parameters.
        /// </summary>
        /// <param name="assignments">The assignment,Ilist collection of UserRightAssignment class.</param>
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
        public UserRightAssignmentCollection(IList<UserRightAssignment> assignments)
        {
            this.AddRange(assignments);
        }
    }
}
