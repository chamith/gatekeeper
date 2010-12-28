using System;
using System.Collections.Generic;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of ApplicationDao class.
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
    /// 				<description>9/24/2008</description>
    /// 				<description>Chamith Siriwardena</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
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
        /// <remarks>
        /// 	<list type="table">
        /// 		<listheader>
        /// 			<description>modified</description>
        /// 			<description>by</description>
        /// 			<description>description</description>
        /// 		</listheader>
        /// 		<item>
        /// 			<description>9/24/2008</description>
        /// 			<description>Chamith Siriwardena</description>
        /// 			<description>initial code</description>
        /// 		</item>
        /// 	</list>
        /// </remarks>
        internal Application Get(Guid applicationGuid)
        {
            return this.DataMapper.QueryForObject<Application>("application-select-by-guid", applicationGuid);
        }

        /// <summary>
        /// Gets all the application object from database,it returns list of  Application object.
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
        /// 				<description>9/24/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        internal IList<Application> Get()
        {
            return this.DataMapper.QueryForList<Application>("application-select-all", null);
        }


    }
}
