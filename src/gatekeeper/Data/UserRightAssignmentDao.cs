using Gatekeeper.Collections;
using System.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of UserRightAssignmentDao class.
    /// </summary>
    internal class UserRightAssignmentDao : BaseDao<UserRightAssignment>
    {
		internal UserRightAssignmentDao():base(SqlMapper.Instance){}

        /// <summary>
        /// Gets all the User-Right-Assignment objects of a specified application id and user id,it returns collection of UserRightAssignment objects.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        private UserRightAssignmentCollection GetByApplicationIdUserId(long applicationId, long userId)
        {
            Hashtable args = new Hashtable();
            args["ApplicationId"] = applicationId;
            args["UserId"] = userId;

            return new UserRightAssignmentCollection(
                this.DataMapper.QueryForList<UserRightAssignment>(
                    "userRightAssignment-select-by-applicationId-userId", args
                )
            );
        }

        /// <summary>
        /// Gets all the User-Right-Assignment objects of a specified application id and user id,it returns collection of UserRightAssignment objects.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        internal UserRightAssignmentCollection GetByApplicationUser(Application application, User user)
        {
            return this.GetByApplicationIdUserId(application.Id, user.Id);
        }

    }
}
