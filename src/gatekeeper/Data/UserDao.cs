using System;
using System.Security.Authentication;
using System.Collections;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of UserDao class.
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
    internal class UserDao : BaseDao<User>
    {
		internal UserDao():base(SqlMapper.Instance){}
        #region Instance Members

        #region Instance Members - Public Methods
        

        /// <summary>
        /// Gets the user object of a specified loginName by passing userLoginName.
        /// </summary>
        /// <param name="userLoginName">Name of the user login.</param>
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
        internal User GetByLoginName(string userLoginName)
        {
            return this.DataMapper.QueryForObject<User>("user-select-by-loginName", userLoginName);
        }

        /// <summary>
        /// Gets all the users,it returns the collection of user.
        /// </summary>
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
        internal UserCollection Get()
        {
            UserCollection users = new UserCollection();
            users.AddRange(this.DataMapper.QueryForList<User>("user-select-all", null));
            
            return users;
        }

		internal void UpdateDetails(User user)
		{
			this.DataMapper.Update("user-update-details", user);
		}
        #endregion

        #endregion

    }
}
