using Gatekeeper.Collections;
using System.Collections;
using System;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of UserRoleAssignmentDao class.
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
    internal class UserRoleAssignmentDao:BaseDao<UserRoleAssignment>
    {
		internal UserRoleAssignmentDao():base(SqlMapper.Instance){}
        /// <summary>
        /// Gets all the User-Role-Assignment of a specified application and user,it returns collection of user.
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
        internal UserRoleAssignmentCollection Get(Application application, User user)
        {
            Hashtable args = new Hashtable();
            args["ApplicationId"] = application.Id;
            args["UserId"] = user.Id;

            return new UserRoleAssignmentCollection(
                this.DataMapper.QueryForList<UserRoleAssignment>(
                    "userRoleAssignment-select-by-applicationId-userId", args
                )
            );
        }

        internal UserRoleAssignmentCollection Get(Application application, Role role, Guid securableObjectGUID)
        {
            Hashtable args = new Hashtable();
            args["applicationId"] = application.Id;
            args["roleId"] = role.Id;
            args["securableObjectGUID"] = securableObjectGUID;

              return new UserRoleAssignmentCollection(
                this.DataMapper.QueryForList<UserRoleAssignment>(
                    "userRoleAssignment-select-by-applicationId-roleId-securableObjectGUID", args
                )
            );
        }

        internal UserRoleAssignmentCollection Get(Application application)
        {
            Hashtable args = new Hashtable();
            args["applicationId"] = application.Id;
            //args["userId"] = user.Id;

            return new UserRoleAssignmentCollection(
                this.DataMapper.QueryForList<UserRoleAssignment>(
                    "userRoleAssignment-select-by-applicationId", args
                )
            );
        }

        internal UserRoleAssignment Get(Application application, User user, Role role, long securableObjectId)
        {
            Hashtable args = new Hashtable();
            args["ApplicationId"] = application.Id;
            args["UserId"] = user.Id;
            args["SecurableObjectId"] = securableObjectId;
            args["RoleId"] = role.Id;

            return this.DataMapper.QueryForObject<UserRoleAssignment>("userRoleAssignment-select-by-applicationId-userId-roleId-securableObjectId", args);
        }

		internal UserRoleAssignment Get(Application application, User user, SecurableObject securableObject)
        {
            Hashtable args = new Hashtable();
            args["ApplicationId"] = application.Id;
            args["UserId"] = user.Id;
            args["SecurableObjectId"] = securableObject.Id;

            return this.DataMapper.QueryForObject<UserRoleAssignment>("userRoleAssignment-select-by-applicationId-userId-securableObjectId", args);
        }

    }
}
