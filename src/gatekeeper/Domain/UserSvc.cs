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
    /// <summary>
    /// Summary of UserSvc class.
    /// </summary>
    public class UserSvc : BaseSvc, IUserSvc
    {
        UserDao userDao;

        /// <summary>
        /// Initializes a new instance of the UserSvc class by creating an object of UserDao class.
        /// </summary>
        public UserSvc()
        {
            this.userDao = new UserDao();
        }

        #region Instance Members

        #region Instance Members - Public Methods


        /// <summary>
        /// Adds the specified user,inserts a user into the system.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Add(User user)
        {
            this.userDao.Add(user);
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(User user)
        {
            this.userDao.Update(user);
        }
		
        /// <summary>
        /// Deletes the specified user from the system.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Delete(User user)
        {
            this.userDao.Delete(user);
        }

        /// <summary>
        /// Gets the User object of a specified userLoginName.
        /// </summary>
        /// <param name="userLoginName">Name of the user login.</param>
        /// <returns></returns>
        public User GetByLoginName(string userLoginName)
        {
            return this.userDao.GetByLoginName(userLoginName);
        }

        /// <summary>
        /// Gets all the User objects,it returns a collection of User.
        /// </summary>
        /// <returns></returns>
        public UserCollection Get()
        {
            return this.userDao.Get();
        }

        /// <summary>
        /// Gets the User objet of a specified user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public User Get(long userId)
        {
            return this.userDao.Get(userId);
        }
		
		public void UpdateDetails(User user)
		{
			this.userDao.UpdateDetails(user);
		}
        
        #endregion

        #endregion
    }
}
