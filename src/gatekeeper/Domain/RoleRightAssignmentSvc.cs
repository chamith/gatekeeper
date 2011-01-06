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
    public class RoleRightAssignmentSvc : BaseSvc, IRoleRightAssignmentSvc
    {
        RoleRightAssignmentDao roleRightAssignmentDao;
		IRoleSvc roleSvc;
		IRightSvc rightSvc;
        /// <summary>
        /// Initializes a new instance of the RoleRightAssignmentSvc by creating a object of RoleRightAssignmentDao class.
        /// </summary>
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
        public void Add(RoleRightAssignment rra)
        {
            this.roleRightAssignmentDao.Add(rra);
        }

        /// <summary>
        /// Adds the specified role right assignments,adding the RoleRightAssignment objects into RoleRightAssignmentCollection.
        /// </summary>
        /// <param name="roleRightAssignments">The role right assignments.</param>
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
        public void Delete(RoleRightAssignment roleRightAssignment)
        {
            this.roleRightAssignmentDao.Delete(roleRightAssignment);
        }

        /// <summary>
        /// Deletes the specified role right assignments,deleting the RoleRightAssignment objects from the RoleRightAssignmentCollection.
        /// </summary>
        /// <param name="roleRightAssignments">The role right assignments.</param>
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
