using System;
using Gatekeeper.Data;
using System.Collections.Generic;
using Gatekeeper.Collections;
using Gatekeeper;
using Gatekeeper.Core;


namespace Gatekeeper.Domain
{
    /// <summary>
    /// Summary of RoleSvc class.
    /// </summary>
    public class UserRoleAssignmentSvc : BaseSvc, IUserRoleAssignmentSvc
    {
        UserRoleAssignmentDao userRoleAssignmentDao;
		IUserSvc userSvc;
		IRoleSvc roleSvc;
		IApplicationSvc appSvc;
        /// <summary>
        /// Initializes a new instance of the RoleSvc class by creating a object of RoleDao class.
        /// </summary>
        public UserRoleAssignmentSvc()
        {
            this.userRoleAssignmentDao = new UserRoleAssignmentDao();
			this.userSvc = GatekeeperFactory.UserSvc;
			this.roleSvc = GatekeeperFactory.RoleSvc;
			this.appSvc = GatekeeperFactory.ApplicationSvc;
        }


        public UserRoleAssignmentCollection Get(Application application, Role role, Guid securableObjectGUID)
        {
            UserRoleAssignmentCollection uras = this.userRoleAssignmentDao.Get(application, role, securableObjectGUID);
			this.PopulateDetails(uras);
			return uras;			
        }

        public UserRoleAssignment Get(User user, Role role, Guid securableObjectGUID)
        {
            return null;
        }

		
		public UserRoleAssignmentCollection Get(Application application, User user)
		{
			UserRoleAssignmentCollection uras = this.userRoleAssignmentDao.Get(application, user);
			this.PopulateDetails(uras);
			return uras;
		}
		
		public void Save(Application application, User user, Role role, ISecurableObject securableObject)
        {
			SecurableObject sObj = GatekeeperFactory.SecurableObjectSvc.Get(securableObject.SecurableObjectGuid);

			this.Save(application, user, role, sObj);
        }
		
		public void Save(Application application, User user, Role role, SecurableObject securableObject)
        {
            UserRoleAssignmentDao uraDao = new UserRoleAssignmentDao();
            //long securableObjectId = new SecurableObjectDao().GetId(securableObject.SecurableObjectGuid);
            UserRoleAssignment ura = uraDao.Get(application, user, securableObject);

            if (ura == null)
            {
                ura = new UserRoleAssignment()
                {
                    Application = application,
                    User = user,
                    Role = role,
                    SecurableObjectId = securableObject.Id
                };

                uraDao.Add(ura);
            }
            else
            {
				ura.Role = role;
                uraDao.Update(ura);
            }
        }
        /// <summary>
        /// Adds the specified role,inserts the object role into the system.
        /// </summary>
        /// <param name="role">The role.</param>
		public void Save(UserRoleAssignment userRoleAssignment)
		{           
			this.Save(userRoleAssignment.Application, userRoleAssignment.User, userRoleAssignment.Role, userRoleAssignment.SecurableObject);
		}
		
        public void Add(UserRoleAssignment userRoleAssignment)
        {
            this.userRoleAssignmentDao.Add(userRoleAssignment);
           
        }
        ///// <summary>
        ///// Adds the specified role,inserts the object role into the system.
        ///// </summary>
        ///// <param name="role">The role.</param>
        //public void Add(UserRoleAssignment userRoleAssignment)
        //{
        //    this.userRoleAssignmentDao.Insert(userRoleAssignment);
        //}

        /// <summary>
        /// Adds the specified roles,adding the Role objects into the RoleCollection.
        /// </summary>
        /// <param name="roles">The roles.</param>
        public void Add(UserRoleAssignmentCollection userRoleAssignments)
        {
            foreach (UserRoleAssignment assignment in userRoleAssignments)
                this.Add(assignment);
        }
      
      
        ///// <summary>
        ///// Updates the specified role.
        ///// </summary>
        ///// <param name="role">The role.</param>
        //public void Update(UserRoleAssignment userRoleAssignment)
        //{
        //    this.userRoleAssignmentDao.Update(userRoleAssignment);
        //}
        /// <summary>
        /// Deletes the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void Delete(Role role)
        {
            //this.userRoleAssignmentDao.Delete(role);
        }

        public void Delete(UserRoleAssignmentCollection userRoleAssignments)
        {
            foreach (UserRoleAssignment ura in userRoleAssignments)
            {
                this.Delete(ura);
            }
        }
        public void Delete(UserRoleAssignment userRoleAssignment)
        {
            this.userRoleAssignmentDao.Delete(userRoleAssignment);
        }
        public UserRoleAssignmentCollection GetUsersByApplication(Application application)
        {
            UserRoleAssignmentCollection uras = this.userRoleAssignmentDao.Get(application);
			this.PopulateDetails(uras);
			return uras;
        }
		
		public UserRoleAssignment Get(Application application, User user, SecurableObject securableObject)
		{
			UserRoleAssignment ura = this.userRoleAssignmentDao.Get(application, user, securableObject);
			this.PopulateDetails(ura);
			return ura;
		}
		
		void PopulateDetails(UserRoleAssignment ura)
		{
			if(ura == null) return;
			
			ura.Application = appSvc.Get(ura.Application.Id);
			ura.Role = roleSvc.Get(ura.Role.Id);
			ura.User = userSvc.Get(ura.User.Id);
		}
		
		void PopulateDetails(UserRoleAssignmentCollection uras)
		{
			foreach(UserRoleAssignment ura in uras)
				this.PopulateDetails(ura);
		}
    }
}
