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
        public UserRightAssignmentCollection GetByApplicationUser(Application application, User user)
        {
            return this._dao.GetByApplicationUser(application, user);
        }
    }
}
