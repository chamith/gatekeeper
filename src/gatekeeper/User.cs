using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using Gatekeeper.Core;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of User,represents a user of an application.
    /// </summary>
    public class User : BaseEntity, IIdentity
    {

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>The name of the login.</value>
        public string LoginName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name of the User.</value>
        public string FirstName { get; set; }


        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name of the User.</value>
        public string LastName { get; set; }

        #region IIdentity Members

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <value></value>
        /// <returns>The type of authentication used to identify the user.</returns>
        public string AuthenticationType
        {
            get { return "custom"; }
        }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <value></value>
        /// <returns>true if the user was authenticated; otherwise, false.</returns>
        public bool IsAuthenticated
        {
            get { return this.Name.Equals(string.Empty); }
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <value></value>
        /// <returns>The name of the user on whose behalf the code is running.</returns>
        public string Name { get { return this.LoginName; } }

		public string PasswordHash {
			get;
			set;
		}
		public string PasswordSalt {
			get;
			set;
		}
		public string FullName {
			get{return this.FirstName + " " + this.LastName;}
		}
        #endregion
    }
}
