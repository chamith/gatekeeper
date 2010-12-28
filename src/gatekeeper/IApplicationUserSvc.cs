using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security.Authentication;
using Gatekeeper.Collections;

namespace Gatekeeper
{
    public interface IApplicationUserSvc
    {
        #region Instance Members

        #region Instance Members - Public Methods

        ApplicationUserCollection Get(Application application);
        ApplicationUser Get(Application application, User user);
        ApplicationUser Get(long id);
        void Save(ApplicationUser appUser);
        void Delete(ApplicationUser appUser);
		#endregion

        #endregion
    }
}
