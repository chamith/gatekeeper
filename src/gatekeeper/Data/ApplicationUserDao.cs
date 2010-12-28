using System;
using System.Security.Authentication;
using System.Collections;
using Gatekeeper.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    internal class ApplicationUserDao : BaseDao<ApplicationUser>
    {
       	public ApplicationUserDao():base(SqlMapper.Instance)
		{
		}
		#region Instance Members

        #region Instance Members - Public Methods

        public ApplicationUserCollection Get(Application application)
        {
            return new ApplicationUserCollection(
                this.DataMapper.QueryForList<ApplicationUser>("applicationUser-select-by-applicationId", application.Id));
        }

        public ApplicationUserCollection Get(User user)
        {
            return new ApplicationUserCollection(
                this.DataMapper.QueryForList<ApplicationUser>("applicationUser-select-by-userId", user.Id));
        }
		
		public ApplicationUser Get(Application application, User user)
        {
			Hashtable args = new Hashtable();
			args["ApplicationId"] = application.Id;
			args["UserId"] = user.Id;
            return this.DataMapper.QueryForObject<ApplicationUser>("applicationUser-select-by-applicationId-userId", args);
        }

        #endregion

        #endregion

    }
}
