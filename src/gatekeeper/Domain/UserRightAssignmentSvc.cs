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
    public class UserRightAssignmentSvc : BaseSvc, IUserRightAssignmentSvc
    {
		UserRightAssignmentDao _dao;
		public UserRightAssignmentSvc()
		{
			this._dao = new UserRightAssignmentDao();
		}


        /// <summary>
        /// Gets all the User-Right-Assignment objects of a specified application id and user id,it returns collection of UserRightAssignment objects.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public UserRightAssignmentCollection GetByApplicationUser(Application application, User user)
        {
            return this._dao.GetByApplicationUser(application, user);
        }
    }
}
