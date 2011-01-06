using System;
using System.Collections.Generic;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of ApplicationDao class.
    /// </summary>
    internal class ApplicationDao : BaseDao<Application>
    {
		public ApplicationDao():base(SqlMapper.Instance)
		{
		}
		
        /// <summary>
        /// Gets the application object of a specified applicationGuid from database.It returns application object.
        /// </summary>
        /// <param name="applicationGuid">The application GUID of a particular application.</param>
        /// <returns></returns>
        internal Application Get(Guid applicationGuid)
        {
            return this.DataMapper.QueryForObject<Application>("application-select-by-guid", applicationGuid);
        }

        /// <summary>
        /// Gets all the application object from database,it returns list of  Application object.
        /// </summary>
        /// <returns></returns>
        internal IList<Application> Get()
        {
            return this.DataMapper.QueryForList<Application>("application-select-all", null);
        }


    }
}
