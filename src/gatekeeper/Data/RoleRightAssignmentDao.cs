using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of RoleRightAssignmentDao class.
    /// </summary>
    internal class RoleRightAssignmentDao : BaseDao<RoleRightAssignment>
    {
		internal RoleRightAssignmentDao():base(SqlMapper.Instance){}
        /// <summary>
        /// Gets all the role-right-assingments of a specified application by passing applictionId.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
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
