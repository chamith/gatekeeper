using System;
using System.Collections.Generic;
using Gatekeeper.Collections;
using Gatekeeper;


namespace Gatekeeper
{
    /// <summary>
    /// Summary of RoleSvc class.
    /// </summary>
    public interface IUserRightAssignmentSvc
    {
        /// <summary>
        /// Gets all the User-Right-Assignment objects of a specified application id and user id,it returns collection of UserRightAssignment objects.
        /// </summary>
        UserRightAssignmentCollection GetByApplicationUser(Application application, User user);
    }
}
