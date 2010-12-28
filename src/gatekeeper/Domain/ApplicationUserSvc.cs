using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Gatekeeper.Data;
using System.Security.Authentication;
using IBatisNet.DataMapper;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Domain
{
    public class ApplicationUserSvc : BaseSvc, IApplicationUserSvc
    {
        ApplicationUserDao userDao;
		IApplicationSvc appSvc;
		IUserSvc userSvc;
        public ApplicationUserSvc()
        {
            this.userDao = new ApplicationUserDao();
			this.appSvc = GatekeeperFactory.ApplicationSvc;
			this.userSvc = GatekeeperFactory.UserSvc;
        }

        #region Instance Members

        #region Instance Members - Public Methods

        public ApplicationUserCollection Get(Application application)
        {
            ApplicationUserCollection appUsers = this.userDao.Get(application);
			this.PopulateDetails(appUsers);
			return appUsers;
        }
		
		public ApplicationUser Get(Application application, User user)
        {
            ApplicationUser appUser = this.userDao.Get(application, user);
			this.PopulateDetails(appUser);
			return appUser;
        }
		public ApplicationUser Get(long id)
		{
			ApplicationUser appUser = this.userDao.Get(id);
			this.PopulateDetails(appUser);
			return appUser;
		}
		
		public void Save(ApplicationUser appUser)
		{
			
			if(appUser.IsNew)
				this.userDao.Add(appUser);
			else
				this.userDao.Update(appUser);
			
			this.SetApplicationRole(appUser.Application, appUser.User, appUser.Role);
		}
		
		public void Delete(ApplicationUser appUser)
		{
			this.userDao.Delete(appUser);
		}
        #endregion

        #endregion
		
		void PopulateDetails(ApplicationUser appUser)
		{
			
			appUser.Application = this.appSvc.Get(appUser.Application.Id);
			appUser.User = this.userSvc.Get(appUser.User.Id);
			appUser.Role = this.GetApplicationRole(appUser.Application, appUser.User);
		}
		
		Role GetApplicationRole(Application application, User user)
		{		
			application = GatekeeperFactory.ApplicationSvc.Get(application.Id);
			SecurableObject appSecObject = GatekeeperFactory.SecurableObjectSvc.Get(application.Guid);
			UserRoleAssignment userRoleAssignment = GatekeeperFactory.UserRoleAssignmentSvc.Get(application, user, appSecObject);
			
			if(userRoleAssignment == null)
				return null;
			
			return userRoleAssignment.Role;
		}
		
		void SetApplicationRole(Application application, User user, Role role)
		{		
			application = GatekeeperFactory.ApplicationSvc.Get(application.Id);
			SecurableObject appSecObject = GatekeeperFactory.SecurableObjectSvc.Get(application.Guid);
			GatekeeperFactory.UserRoleAssignmentSvc.Save(application, user, role, appSecObject);
		}
		
		void PopulateDetails(ApplicationUserCollection appusers)
		{
			foreach(ApplicationUser appUser in appusers)
				this.PopulateDetails(appUser);
		}
    }
}
