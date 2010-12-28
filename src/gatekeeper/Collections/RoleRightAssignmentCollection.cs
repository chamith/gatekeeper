using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{

    /// <summary>
    /// Summary of RoleRightAssignmentCollection.Represents a collection of role-right assignments.
    /// </summary>
    /// <remarks>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<description>modified</description>
    /// 			<description>by</description>
    /// 			<description>description</description>
    /// 		</listheader>
    /// 		<item>
    /// 			<description>9/19/2008</description>
    /// 			<description>Chamith</description>
    /// 			<description>initial code</description>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    public class RoleRightAssignmentCollection : List<RoleRightAssignment>
    {


        /// <summary>
        /// Initializes a new instance of the RoleRightAssignmentCollection class.
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
        public RoleRightAssignmentCollection()
        {
        }


        /// <summary>
        /// Initializes a new instance of the RoleRightAssignmentCollection class with parameter assignments.
        /// </summary>
        /// <param name="assignments">The assignments,Ilist collection of RoleRightAssignment.</param>
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
        public RoleRightAssignmentCollection(IList<RoleRightAssignment> assignments)
        {
            this.AddRange(assignments);
        }


        /// <summary>
        /// Gets the roles for a particular right.This method returns collection of roles.
        /// </summary>
        /// <param name="right">The right,object of class Right.</param>
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
        /// 				<description>9/19/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public RoleCollection GetRoles(Right right)
        {
            RoleCollection roles = new RoleCollection();

            foreach (RoleRightAssignment assignment in this)
            {
                if (assignment.Right.Id == right.Id)
                    roles.Add(assignment.Role);
                            
            }

            return roles;
        }




        /// <summary>
        /// Gets the rights for a particular role.This method returns collection of rights.
        /// </summary>
        /// <param name="role">The role,object of class Role.</param>
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
        /// 				<description>9/19/2008</description>
        /// 				<description>Chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public RightCollection GetRights(Role role)
        {
            RightCollection rights = new RightCollection();

            foreach (RoleRightAssignment assignment in this)
            {
                if (assignment.Role.Id == role.Id)
                    rights.Add(assignment.Right);
            }

            return rights;
        }



        /// <summary>
        /// Determines whether [contains] [the specified role right assignment].
        /// </summary>
        /// <param name="roleRightAssignment">The role right assignment.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified role right assignment's Role Id and Right Id are valid]; otherwise, <c>false</c>.
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
        /// 				<description>9/19/2008</description>
        /// 				<description>chamith</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public bool Contains(RoleRightAssignment roleRightAssignment)
        {
            foreach (RoleRightAssignment rra in this)
            {
                if (rra.Role.Id == roleRightAssignment.Role.Id && rra.Right.Id == roleRightAssignment.Right.Id)
                    return true;
            }

            return false;
        }
    }
}
