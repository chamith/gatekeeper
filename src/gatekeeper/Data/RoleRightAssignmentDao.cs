using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of RoleRightAssignmentDao class.
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
    /// 				<description>9/24/2008</description>
    /// 				<description>Chamith Siriwardena</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    internal class RoleRightAssignmentDao : BaseDao<RoleRightAssignment>
    {
		internal RoleRightAssignmentDao():base(SqlMapper.Instance){}
        /// <summary>
        /// Gets all the role-right-assingments of a specified application by passing applictionId.
        /// </summary>
        /// <param name="application">The application.</param>
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
        /// 				<description>9/24/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        internal RoleRightAssignmentCollection Get(Application application)
        {
            return new RoleRightAssignmentCollection(
                this.DataMapper.QueryForList<RoleRightAssignment>(
                    "roleRightAssignment-select-by-applicationId", application.Id)
            );
        }

        /// <summary>
        /// Gets all the role-right-assignments of a specified role by passing roleId.
        /// </summary>
        /// <param name="role">The role.</param>
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
        /// 				<description>9/24/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        internal RoleRightAssignmentCollection Get(Role role)
        {
            RoleRightAssignmentCollection assignments = new RoleRightAssignmentCollection(
                this.DataMapper.QueryForList<RoleRightAssignment>(
                    "roleRightAssignment-select-by-roleId", role.Id)
            );
			
			return assignments;
			
        }
		

    }
}
