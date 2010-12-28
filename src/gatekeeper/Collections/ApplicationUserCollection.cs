using System;
using System.Collections.Generic;
using System.Text;

namespace Gatekeeper.Collections
{

    /// <summary>
    /// Represents a collection of users.
    /// </summary>
    public class ApplicationUserCollection : List<ApplicationUser>
    {
        public ApplicationUserCollection()
        {
        }

        public ApplicationUserCollection(IList<ApplicationUser> users)
        {
            foreach (ApplicationUser user in users)
                this.Add(user);
        }
    }
}
