using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of UserRightAssignment class.
    /// </summary>
    public class UserRightAssignment : ObjectRight
    {

        /// <summary>
        /// Initializes a new instance of the UserRightAssignment class.
        /// </summary>
        public UserRightAssignment() { }

        /// <summary>
        /// Initializes a new instance of the UserRightAssignment class.
        /// </summary>
        /// <param name="user">The user of the application.</param>
        /// <param name="securableObject">The securable object.</param>
        /// <param name="right">The right.</param>
        public UserRightAssignment(User user, ISecurableObject securableObject, Right right)
            : base(securableObject, right)
        {
            this.User = user;
        }

        /// <summary>
        /// Gets or sets the user of the application.
        /// </summary>
        /// <value>The user.</value>
        public User User { get; set; }

    }
}
