using System;
using Gatekeeper.Data;
using System.Collections.Generic;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of RoleRightAssignmentSvc class.
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
    /// 				<description>9/25/2008</description>
    /// 				<description>Chamith Siriwardena</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    public class RoleRightAssignmentSvc : BaseSvc, IRoleRightAssignmentSvc
    {
        RoleRightAssignmentDao roleRightAssignmentDao;
		IRoleSvc roleSvc;
		IRightSvc rightSvc;
        /// <summary>
        /// Initializes a new instance of the RoleRightAssignmentSvc by creating a object of RoleRightAssignmentDao class.
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
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public RoleRightAssignmentSvc()
        {
            this.roleRightAssignmentDao = new RoleRightAssignmentDao();
			this.roleSvc = GatekeeperFactory.RoleSvc;
			this.rightSvc = GatekeeperFactory.RightSvc;
        }

        public RoleRightAssignmentCollection Get(Application application)
		{
			RoleRightAssignmentCollection assignments = this.roleRightAssignmentDao.Get(application);
			this.PopulateDetails(assignments);
			return assignments;
		}
		
        /// <summary>
        /// Gets all the Role-Right-Assignment objects of a specified role,it returns a collection of Role-Right-Assignment objects.
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
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public RoleRightAssignmentCollection Get(Role role)
        {
			RoleRightAssignmentCollection assignments = this.roleRightAssignmentDao.Get(role);
			this.PopulateDetails(assignments);
			return assignments;

        }

        /// <summary>
        /// Adds the specified rra,inserts the Role-Right-Assignment object into the system.
        /// </summary>
        /// <param name="rra">The rra.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Add(RoleRightAssignment rra)
        {
            this.roleRightAssignmentDao.Add(rra);
        }

        /// <summary>
        /// Adds the specified role right assignments,adding the RoleRightAssignment objects into RoleRightAssignmentCollection.
        /// </summary>
        /// <param name="roleRightAssignments">The role right assignments.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Add(RoleRightAssignmentCollection roleRightAssignments)
        {
            foreach (RoleRightAssignment rra in roleRightAssignments)
            {
                this.Add(rra);
            }
        }

        /// <summary>
        /// Deletes the specified role right assignment from the system.
        /// </summary>
        /// <param name="roleRightAssignment">The role right assignment.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Delete(RoleRightAssignment roleRightAssignment)
        {
            this.roleRightAssignmentDao.Delete(roleRightAssignment);
        }

        /// <summary>
        /// Deletes the specified role right assignments,deleting the RoleRightAssignment objects from the RoleRightAssignmentCollection.
        /// </summary>
        /// <param name="roleRightAssignments">The role right assignments.</param>
        /// <remarks>
        /// 	<para>
        /// 		<list type="table">
        /// 			<listheader>
        /// 				<description>modified</description>
        /// 				<description>by</description>
        /// 				<description>description</description>
        /// 			</listheader>
        /// 			<item>
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        public void Delete(RoleRightAssignmentCollection roleRightAssignments)
        {
            foreach(RoleRightAssignment rra in roleRightAssignments)
                this.Delete(rra);
        }
		
		void PopulateDetails(RoleRightAssignment assignment)
		{
			assignment.Role = this.roleSvc.Get(assignment.Role.Id);
			assignment.Right = this.rightSvc.Get(assignment.Right.Id);
		}
		
		void PopulateDetails(RoleRightAssignmentCollection roleRightAssignments)
        {
            foreach(RoleRightAssignment rra in roleRightAssignments)
                this.PopulateDetails(rra);
        }
    }
}
