using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security.Authentication;
using Gatekeeper.Collections;

namespace Gatekeeper
{

    public interface IUserSvc
    {
        #region Instance Members

        #region Instance Members - Public Methods

        /// <summary>
        /// Adds the specified user into the system.
        /// </summary>
        /// <param name="user">The user.</param>
        void Add(User user);

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Update(User user);
        void UpdateDetails(User user);
		
        /// <summary>
        /// Deletes the specified user from the system.
        /// </summary>
        /// <param name="user">The user.</param>
        void Delete(User user);

        /// <summary>
        /// Gets the User object of a specified userLoginName.
        /// </summary>
        /// <param name="userLoginName">Name of the user login.</param>
        /// <returns></returns>
        User GetByLoginName(string userLoginName);

        /// <summary>
        /// Gets all the User objects,it returns a collection of User.
        /// </summary>
        /// <returns></returns>
        UserCollection Get();

        /// <summary>
        /// Gets the User objet of a specified user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        User Get(long userId);
        
        #endregion

        #endregion
    }
}
